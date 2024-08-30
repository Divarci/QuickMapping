using QuickMapping.Exceptions;
using QuickMapping.Options;
using QuickMapping.Validations;
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
        {
            if(sourceType.IsArray)
                if(IsPrimitive.Check(sourceType.GetElementType()!))
                    if(sourceType.GetElementType() != destinationType.GetElementType())
                        throw new MapperException("Unsupported mapping type");

            if (!sourceType.IsArray && sourceType.GetGenericTypeDefinition() != destinationType.GetGenericTypeDefinition())
                throw new MapperException("Unsupported mapping type");

            return CollectionMapper.Map(
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
