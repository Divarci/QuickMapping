using QuickMapping.Exceptions;
using QuickMapping.Options;
using System.Reflection;

namespace QuickMapping.Concrete.CollectionMappers;
public static class IQueryableMapper
{
    public static bool Validate(Type elementType, Type collectionType) =>
            typeof(IQueryable<>)
            .MakeGenericType(elementType)
            .IsAssignableFrom(collectionType);

    private static readonly MethodInfo AsQueryableMethod = typeof(Queryable)
            .GetMethods(BindingFlags.Static | BindingFlags.Public)
            .FirstOrDefault(m => m.Name == "AsQueryable" && m.IsGenericMethod) ??
            throw new MapperException("AsQueryable not found");

    public static object? Map(
        Type destinationType,
        Type sourceElementType,
        Type destinationElementType,
        object source,
        object? destination,
        int depth,
        MappingOptions options)
    {
        var mappedObject = IEnumerableMapper.Map(destinationType, sourceElementType, 
            destinationElementType, source, destination, depth, options);
      
        var genericQueryableMethod = AsQueryableMethod.MakeGenericMethod(destinationElementType);

        var queryableList = genericQueryableMethod.Invoke(null, [mappedObject]);
        return queryableList;
    }
}
