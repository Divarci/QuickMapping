using QuickMapping.Exceptions;
using QuickMapping.Options;
using QuickMapping.Validations;
using System.Linq.Expressions;

namespace QuickMapping.Extensions;
public static class MapperExtensions
{
    /// <summary>
    /// There are two <strong>params</strong> required. Creates <strong>queryable objects</strong> for LINQ
    /// <list type="number">
    /// <item><param name="source">The <em>source</em> object</param></item>
    /// <item><param name="depth">The count of mapping <em>depth</em></param></item>
    /// <item><param name="options">Th  <em>options</em> of mapping</param></item>
    /// </list>
    /// </summary>
    /// <returns>The <strong>queryable object</strong>.</returns>
    public static IQueryable<DestinationElement> MapTo<DestinationElement>(
        this IQueryable source,
        int depth,
        MappingOptions? options)
    {
        if (source is null)
            throw new MapperException("Source can not be null");

        var destinationType = typeof(DestinationElement);
        var sourceType = source.ElementType;

        var parameter = Expression.Parameter(sourceType, "x");

        var memberInitExpression = CreateMemberInitExpression(
            parameter,
            sourceType,
            destinationType,
            depth);

        var lambda = Expression.Lambda(memberInitExpression, parameter);

        var result = Expression.Call(
            typeof(Queryable),
            "Select",
            [sourceType, destinationType],
            source.Expression,
            lambda);

        return source.Provider.CreateQuery<DestinationElement>(result);
    }

    private static Expression CreateMemberInitExpression(
        Expression parameter,
        Type sourceType,
        Type destinationType,
        int depth)
    {
        var sourceProperties = sourceType.GetProperties();
        var destinationProperties = destinationType.GetProperties();

        List<MemberAssignment?> bindings = destinationProperties
            .Select(destProp =>
        {
            var sourceProp = sourceProperties.FirstOrDefault(sp => sp.Name == destProp.Name);

            if (sourceProp is null)
                return null;

            //SIMPLE TYPE MAPPING
            if (IsPrimitive.Check(sourceProp.PropertyType))
                return Expression.Bind(destProp, Expression.Property(parameter, sourceProp));

            //COLLECTION MAPPING
            else if (sourceProp.PropertyType.IsGenericType &&
                     typeof(System.Collections.IEnumerable).IsAssignableFrom(sourceProp.PropertyType) &&
                     depth > 1)

            {
                var nestedSourceType = sourceProp.PropertyType.GetGenericArguments().First();
                var nestedDestinationType = destProp.PropertyType.GetGenericArguments().First();

                var nestedParameter = Expression.Parameter(nestedSourceType, "k");

                depth--;

                var nestedMemberInit = CreateMemberInitExpression(
                    nestedParameter,
                    nestedSourceType,
                    nestedDestinationType,
                    depth);

                depth++;

                var selectExpression = Expression.Call(
                    typeof(Enumerable),
                    "Select",
                    [nestedSourceType, nestedDestinationType],
                    Expression.Property(parameter, sourceProp),
                    Expression.Lambda(nestedMemberInit, nestedParameter));

                return Expression.Bind(destProp, selectExpression);
            }

            //SINGLE COMPLE UNIT MAPPING
            else if (sourceProp.PropertyType.IsClass &&
            sourceProp.PropertyType != typeof(string) &&
            depth > 1)
            {
                depth--;

                var nestedMemberInit = CreateMemberInitExpression(
                    Expression.Property(parameter, sourceProp),
                    sourceProp.PropertyType,
                    destProp.PropertyType,
                    depth);

                depth++;

                return Expression.Bind(destProp, nestedMemberInit);
            }

            else return null;

        }).Where(b => b != null).ToList();

        var newExpression = Expression.New(destinationType);
        return Expression.MemberInit(newExpression, bindings!);
    }   
}