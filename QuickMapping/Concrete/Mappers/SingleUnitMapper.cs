using QuickMapping.Exceptions;
using QuickMapping.Options;
using System.Collections;
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

        if (options is not null && !options.IsSensitiveCase)
            sourceProperties = sourceType
                .GetProperties()
                .ToDictionary(p => p.Name.ToLower());
        else
            sourceProperties = sourceType
                .GetProperties()
                .ToDictionary(p => p.Name);

        var destinationProperties = destinationType.GetProperties();

        var mappedObject = destination
            ?? Activator.CreateInstance(destinationType);

        foreach (var destinationProperty in destinationProperties)
        {
            PropertyInfo? sourceProperty = null;

            if (options is not null && !options.IsSensitiveCase)
            {
                if (!sourceProperties.TryGetValue(destinationProperty.Name.ToLower(), out sourceProperty))
                    continue;
            }
            else
            {
                if (!sourceProperties.TryGetValue(destinationProperty.Name, out sourceProperty))
                    continue;
            }


            if ((destinationProperty.PropertyType.IsClass || destinationProperty.PropertyType.IsInterface) &&
                 destinationProperty.PropertyType != typeof(string))
            {
                var nestedValue = sourceProperty!.GetValue(source) ??
                    throw new MapperException("Nested value can not be null");

                depth--;

                object? nestedDestination = null;

                if(destination is not null)
                    nestedDestination = destinationProperty!.GetValue(destination);

                if (nestedValue is IEnumerable)
                    nestedDestination = null;

                var subDestination = ObjectMapper.Map(
                    sourceProperty.PropertyType,
                    destinationProperty.PropertyType,
                    depth,
                    nestedValue,
                    options!,
                    nestedDestination,
                    MapperDefaults.SINGLE_UNIT);

                depth++;

                destinationProperty.SetValue(mappedObject, subDestination);

                continue;
            }

            if (destinationProperty.PropertyType == sourceProperty!.PropertyType)
            {
                var value = sourceProperty.GetValue(source) ??
                    throw new MapperException("Source property value can not be null");

                destinationProperty.SetValue(mappedObject, value);
                continue;
            }
        }
        return mappedObject;
    }
}
