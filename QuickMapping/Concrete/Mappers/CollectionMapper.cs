using QuickMapping.Concrete.CollectionMappers;
using QuickMapping.Exceptions;
using QuickMapping.Options;

namespace QuickMapping.Concrete.Mappers;
public static class CollectionMapper
{
    public static object? Map(
        Type sourceType,
        Type destinationType,
        ref int depth,
        object source,
        MappingOptions options,
        object? destination = null)
    {
        if (source == null)
            throw new MapperException("Source can not be null");

        if (ArrayMapper.Validate(sourceType, destinationType))
            return ArrayMapper.Map(
               sourceType,
               destinationType,
               source,
               destination,
               depth,
               options);

        var sourceElementType = sourceType
            .GetGenericArguments()
            .FirstOrDefault() ??
            throw new MapperException("Source type must be a generic collection");

        var destinationElementType = destinationType
            .GetGenericArguments()
            .FirstOrDefault() ??
            throw new MapperException("Destination type must be a generic collection");

        if (IReadOnlyCollectionMapper.Validate(destinationElementType, destinationType, source) &&
            IReadOnlyCollectionMapper.Validate(sourceElementType, sourceType, source))
            return IReadOnlyCollectionMapper.Map(
                sourceElementType,
                destinationElementType,
                source,
                destination,
                depth,
                options);

        if (IQueryableMapper.Validate(destinationElementType, destinationType) &&
            IQueryableMapper.Validate(sourceElementType, sourceType))
            return IQueryableMapper.Map(
                destinationType,
                sourceElementType,
                destinationElementType,
                source,
                destination,
                depth,
                options);

        if (IEnumerableMapper.Validate(destinationElementType, destinationType) &&
            IEnumerableMapper.Validate(sourceElementType, sourceType))
            return IEnumerableMapper.Map(
                destinationType,
                sourceElementType,
                destinationElementType,
                source,
                destination,
                depth,
                options);

        throw new MapperException("Unsupported mapping type");
    }
}
