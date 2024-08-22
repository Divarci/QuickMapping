using QuickMapping.Abstract;
using QuickMapping.Exceptions;
using QuickMapping.Options;
using System.Collections;
using System.Reflection;

namespace QuickMapping.Concrete;
public class QuickMapper : IQuickMapper
{
    private readonly MappingOptions? _options;

    private const string COLLECTION = "Collection";
    private const string SINGLE_UNIT = "SingleUnit";

    public QuickMapper() { }

    public QuickMapper(MappingOptions options) =>
        _options = options;    

    public Destination Map<Source, Destination>(Source source, int depth)
    {
        if (source is null)
            throw new MapperException("Mapper source can not be null");

        if (depth <= 0)
            throw new MapperException("Depth must be greater than 0");

        var mappedObject = MapObject(typeof(Source), typeof(Destination), depth, source);

        return (Destination)mappedObject!;
    }

    public Destination Map<Source, Destination>(Source source, Destination destination, int depth)
    {
        if (source is null)
            throw new MapperException("Mapper source can not be null");

        if (destination is null)
            throw new MapperException("Mapper destination can not be null");

        if (depth <= 0)
            throw new MapperException("Depth must be greater than 0");

        var mappedObject = MapObject(typeof(Source), typeof(Destination), depth, source, destination);

        return (Destination)mappedObject!;
    }

    private object? MapObject(
        Type sourceType,
        Type destinationType,
        int depth, object source,
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
            return CollectionMapper(destinationType, ref depth, source, destination);

        return SingleUnitMapper(sourceType, destinationType, ref depth, source, destination);
    }

    private object? SingleUnitMapper(
        Type sourceType,
        Type destinationType,
        ref int depth,
        object source,
        object? destination = null)
    {
        Dictionary<string, PropertyInfo> sourceProperties;

        if(_options is not null && !_options.IsSensitiveCase)
            sourceProperties = sourceType.GetProperties().ToDictionary(p => p.Name.ToLower());
        else 
            sourceProperties = sourceType.GetProperties().ToDictionary(p => p.Name);

        var destinationProperties = destinationType.GetProperties();

        var mappedObject = destination ?? Activator.CreateInstance(destinationType);

        foreach (var destinationProperty in destinationProperties)
        {
            PropertyInfo? sourceProperty = null;

            if (_options is not null && !_options.IsSensitiveCase)
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

    private object? CollectionMapper(
        Type destinationType,
        ref int depth,
        object source,
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
                destination,
                COLLECTION);

            depth++;

            destinationList.Add(destinationOutObject);
        }

        return destinationList;
    }
}
