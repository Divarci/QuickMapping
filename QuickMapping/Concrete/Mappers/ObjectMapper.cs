using QuickMapping.Exceptions;
using QuickMapping.Helpers;
using QuickMapping.Options;

namespace QuickMapping.Concrete.Mappers;
public static class ObjectMapper
{
    public static object? Map(
       Type sourceType,
       Type destinationType,
       int depth, 
       object source,
       MappingOptions options,
       object? destination = null)
    {
        if (source is null || depth <= 0)
            return null;

        var isSourceCollection = Caching.IsCollection(sourceType);
        var isDestinationCollection = Caching.IsCollection(destinationType);

        if (isSourceCollection != isDestinationCollection)
            throw new MapperException("Unsupported mapping type");

        if (isSourceCollection && isDestinationCollection)
        {
            if (!Validations.IsCollectionValid(sourceType, destinationType))
                throw new MapperException("Unsupported Mapping Type");

            return CollectionMapper.Map(
                sourceType,
                destinationType,
                ref depth,
                source,
                options,
                destination);
        }

        return SingleUnitMapper.Map(
            sourceType,
            destinationType,
            ref depth,
            source,
            options,
            destination);

    }
}
