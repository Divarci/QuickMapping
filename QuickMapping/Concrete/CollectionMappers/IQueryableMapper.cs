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

    public static object? Map(
        Type destinationType,
        Type sourceElementType,
        Type destinationElementType,
        object source,
        object? destination,
        int depth,
        MappingOptions options,
        string previousProcess)
    {
        var mappedObject = IEnumerableMapper.Map(destinationType, sourceElementType, 
            destinationElementType, source, destination, depth, options, previousProcess);

        Type queryableType = typeof(Queryable);
        string methodName = "AsQueryable";

        MethodInfo? asQueryableMethod = queryableType
            .GetMethods(BindingFlags.Static | BindingFlags.Public)
            .FirstOrDefault(m => m.Name == methodName && m.IsGenericMethod) ??
            throw new MapperException("AsQueryable not found");

        var genericQueryableMethod = asQueryableMethod.MakeGenericMethod(destinationElementType);

        var queryableList = genericQueryableMethod.Invoke(null, [mappedObject]);
        return queryableList;
    }
}
