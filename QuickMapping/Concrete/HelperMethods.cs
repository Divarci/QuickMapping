using QuickMapping.Exceptions;
using QuickMapping.Options;
using System.Collections;
using System.Reflection;

namespace QuickMapping.Concrete;
public static class HelperMethods
{
    private const string COLLECTION = "Collection";
    private const string SINGLE_UNIT = "SingleUnit";

    public static object? MapObject(
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

        if (previousProcess is COLLECTION)
            depth++;

        bool isCollection = typeof(IEnumerable).IsAssignableFrom(sourceType) && sourceType != typeof(string);

        if (isCollection)
            return CollectionMapper(destinationType, ref depth, source, options, destination);

        return SingleUnitMapper(sourceType, destinationType, ref depth, source, options, destination);
    }

    private static object? SingleUnitMapper(
        Type sourceType,
        Type destinationType,
        ref int depth,
        object source,
        MappingOptions options,
        object? destination = null)
    {
        Dictionary<string, PropertyInfo> sourceProperties;

        if (options is not null && !options.IsSensitiveCase)
            sourceProperties = sourceType.GetProperties().ToDictionary(p => p.Name.ToLower());
        else
            sourceProperties = sourceType.GetProperties().ToDictionary(p => p.Name);

        var destinationProperties = destinationType.GetProperties();

        var mappedObject = destination ?? Activator.CreateInstance(destinationType);

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

            if (destinationProperty.PropertyType.IsClass && destinationProperty.PropertyType != typeof(string))
            {
                var nestedValue = sourceProperty!.GetValue(source) ??
                    throw new MapperException("Nested value can not be null");

                depth--;

                var nestedDestination = destination;

                if (nestedValue is ICollection)
                    nestedDestination = null;

                var subDestination = MapObject(
                    sourceProperty.PropertyType,
                    destinationProperty.PropertyType,
                    depth,
                    nestedValue,
                    options!,
                    nestedDestination,
                    SINGLE_UNIT);

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

    private static object? CollectionMapper(
        Type destinationType,
        ref int depth,
        object source,
        MappingOptions options,
        object? destination = null)
    {
        if (source is not IEnumerable sourceList)
            throw new MapperException("Source object of type is not an IEnumerable");

        if (destinationType.IsAbstract || destinationType.IsInterface)
            throw new MapperException("Destination object of type can not be an abstract type");

        var destinationObject = Activator.CreateInstance(destinationType) ??
            throw new MapperException("Destination object activator error");

        var destinationList = (IList)destinationObject ??
            throw new MapperException("Destination object must be a Collection");

        var typeOfDestinationObject = destinationType.GetGenericArguments()[0];

        foreach (var item in sourceList)
        {
            depth--;

            var destinationOutObject = MapObject(
                item.GetType(),
                typeOfDestinationObject,
                depth,
                item,
                options,
                destination,
                COLLECTION);

            depth++;

            destinationList.Add(destinationOutObject);
        }

        return destinationList;
    }
}
