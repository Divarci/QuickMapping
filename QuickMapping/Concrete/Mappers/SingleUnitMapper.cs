using QuickMapping.Exceptions;
using QuickMapping.Helpers;
using QuickMapping.Options;
using System.Collections;
using System.Linq.Expressions;
using System.Reflection;

namespace QuickMapping.Concrete.Mappers;
public static class SingleUnitMapper
{
    public static object? Map(
       Type sourceType,
       Type destinationType,
       ref int depth,
       object source,
       MappingOptions options,
       object? destination = null)
    {
        Dictionary<string, PropertyInfo> sourceProperties;
        Dictionary<string, PropertyInfo> destinationProperties;

        if (options is not null && !options.IsSensitiveCase)
        {
            sourceProperties = Caching
                .GetPropertiesWithLowerCase(sourceType);               

            destinationProperties = Caching
                .GetPropertiesWithLowerCase(destinationType);
        }
        else
        {
            sourceProperties = Caching
                .GetPropertiesWithDefaultCase(sourceType);             

            destinationProperties = Caching
                .GetPropertiesWithDefaultCase(destinationType);
        }

        var mappedObject = destination ?? Caching.GetInstance(destinationType)();

        foreach (var destinationProperty in destinationProperties)
        {

            if (!sourceProperties.TryGetValue(destinationProperty.Key, out PropertyInfo? sourceProperty))
                continue;

            var dstinationPropertyType = Caching.GetPropertyType(destinationProperty.Value);
            var sourcePropertyType = Caching.GetPropertyType(sourceProperty);

            if (dstinationPropertyType == sourcePropertyType)
            {
                var value = sourceProperty.GetValue(source) ??
                    throw new MapperException("Source property value can not be null");

                destinationProperty.Value.SetValue(mappedObject, value);
                continue;
            }

            if ((dstinationPropertyType.IsClass || dstinationPropertyType.IsInterface) &&
                 dstinationPropertyType != typeof(string))
            {
                var nestedValue = sourceProperty!.GetValue(source) ??
                    throw new MapperException("Nested value can not be null");

                depth--;

                object? nestedDestination = null;

                if (destination is not null)
                    nestedDestination = destinationProperty!.Value.GetValue(destination);

                if (nestedValue is IEnumerable)
                    nestedDestination = null;

                var subDestination = ObjectMapper.Map(
                    sourcePropertyType,
                    dstinationPropertyType,
                    depth,
                    nestedValue,
                    options!,
                    nestedDestination);

                depth++;

                destinationProperty.Value.SetValue(mappedObject, subDestination);

                continue;
            }
        }
        return mappedObject;
    }
}
