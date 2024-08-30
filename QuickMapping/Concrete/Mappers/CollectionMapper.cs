using QuickMapping.Concrete.CollectionMappers;
using QuickMapping.Exceptions;
using QuickMapping.Options;

namespace QuickMapping.Concrete.Mappers;
public static class CollectionMapper
{
    public static object? Map(
        Type destinationType,
        ref int depth,
        object source,
        MappingOptions options,
        object? destination = null)
    {
        if (source == null)
            throw new MapperException("Source can not be null");

        var sourceType = source.GetType();

        if (ArrayMapper.Validate(sourceType, destinationType))       
            return source;        

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
                options,
                MapperDefaults.COLLECTION);

        if (IQueryableMapper.Validate(destinationElementType, destinationType) &&
            IQueryableMapper.Validate(sourceElementType, sourceType))
            return IQueryableMapper.Map(
                destinationType,
                sourceElementType,
                destinationElementType,
                source,
                destination,
                depth,
                options,
                MapperDefaults.COLLECTION);

        if (IEnumerableMapper.Validate(destinationElementType, destinationType) &&
            IEnumerableMapper.Validate(sourceElementType, sourceType))
            return IEnumerableMapper.Map(
                destinationType,
                sourceElementType,
                destinationElementType,
                source,
                destination,
                depth,
                options,
                MapperDefaults.COLLECTION);

        throw new MapperException("Unsupported mapping type");
    }
}
