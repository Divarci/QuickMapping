using QuickMapping.Options;
using System.Collections;

namespace QuickMapping.Concrete.Mappers;
public static class ObjectMapper
{
    public static object? Map(
       Type sourceType,
       Type destinationType,
       int depth, object source,
       MappingOptions options,
       object? destination = null,
       string? previousProcess = null)
    {
        if (source is null)
            return null;

        if (depth <= 0)
            return null!;

        if (previousProcess is MapperDefaults.COLLECTION)
            depth++;

        bool isCollection = typeof(IEnumerable)
            .IsAssignableFrom(sourceType) &&
            sourceType != typeof(string);

        if (isCollection)
            return CollectionMapper.Map(
                destinationType,
                ref depth,
                source,
                options,
                destination);

        return SingleUnitMapper.Map(
            sourceType,
            destinationType,
            ref depth,
            source,
            options,
            destination);
    }
}
