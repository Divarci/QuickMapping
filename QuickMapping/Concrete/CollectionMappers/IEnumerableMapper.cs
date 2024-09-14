using QuickMapping.Concrete.Mappers;
using QuickMapping.Exceptions;
using QuickMapping.Helpers;
using QuickMapping.Options;
using System.Collections;

namespace QuickMapping.Concrete.CollectionMappers;
public static class IEnumerableMapper
{
    public static bool Validate(Type elementType, Type collectionType) =>
        typeof(IEnumerable<>)
        .MakeGenericType(elementType)
        .IsAssignableFrom(collectionType);
    public static object Map(
        Type destinationType,
        Type sourceElementType,
        Type destinationElementType,
        object source,
        object? destination,
        int depth,
        MappingOptions options)
    {

        IList list;

        if (destinationType.IsInterface)
            list = (IList)Caching.GetInstance(typeof(List<>)
                .MakeGenericType(destinationElementType))();
        else
            list = (IList)Caching.GetInstance(destinationType)();

        if (Caching.IsPrimitiveOrCached(destinationElementType) &
            Caching.IsPrimitiveOrCached(sourceElementType))
            return source;

        var iterateSource = (IEnumerable)source;

        foreach (var sourceElement in iterateSource)
        {
            var destinationElementObject = ObjectMapper.Map(
            sourceElementType,
            destinationElementType,
            depth,
            sourceElement,
            options,
            destination);

            list.Add(destinationElementObject);

        }
        return list ??
            throw new MapperException("IEnumerable Mapper failed");
    }
}
