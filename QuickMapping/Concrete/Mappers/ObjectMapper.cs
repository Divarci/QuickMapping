using QuickMapping.Exceptions;
using QuickMapping.Helpers;
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
       object? destination = null)
    {
        if (source is null)
            return null;

        if (depth <= 0)
            return null!;

        var isSourceCollection = CollectionCheck(sourceType);
        var isDestinationCollection = CollectionCheck(destinationType);

        if (isSourceCollection && isDestinationCollection)
        {
            var isSourceArray = sourceType.IsArray;
            var isDestinationArray = destinationType.IsArray;

            DictionaryValidation(sourceType, destinationType, isSourceCollection, isDestinationCollection);

            ArrayValidation(sourceType, destinationType, isSourceArray, isDestinationArray);

            CollectionValidation(sourceType, destinationType, isSourceArray, isDestinationArray);

            return CollectionMapper.Map(
                sourceType,
                destinationType,
                ref depth,
                source,
                options,
                destination);
        }

        if (!isSourceCollection && !isDestinationCollection)
            return SingleUnitMapper.Map(
                sourceType,
                destinationType,
                ref depth,
                source,
                options,
                destination);

        throw new MapperException("Unsupported mapping type");
    }

    private static bool CollectionCheck(Type type) =>
        typeof(IEnumerable)
        .IsAssignableFrom(type) &&
        type != typeof(string);
  
    private static void DictionaryValidation(Type sourceType, Type destinationType,
        bool isSourceCollection, bool isDestinationCollection)
    {
        if (isSourceCollection || isDestinationCollection)
            if (sourceType.Name.Contains("Dictionary") || sourceType.Name.Contains("KeyValue") ||
                destinationType.Name.Contains("Dictionary") || destinationType.Name.Contains("KeyValue"))
                throw new MapperException("Unsupported mapping type");
    }

    private static void ArrayValidation(Type sourceType, Type destinationType,
        bool isSourceArray, bool isDestinationArray)
    {
        if (isSourceArray && isDestinationArray)
        {
            var sourceElementType = sourceType.GetElementType();
            var destinationElementType = destinationType.GetElementType();

            var resultForSourceElement = Caching.IsPrimitiveOrCached(sourceElementType!);
            var resultForDestinationElement = Caching.IsPrimitiveOrCached(destinationElementType!);

            if ((resultForDestinationElement != resultForSourceElement) || 
                (resultForSourceElement && resultForDestinationElement && (sourceElementType != destinationElementType)))
                throw new MapperException("Unsupported mapping type");

            return;
        }

        if (!isSourceArray && !isDestinationArray)
            return;

        throw new MapperException("Unsupported mapping type");
    }

    private static void CollectionValidation(Type sourceType, Type destinationType,
        bool isSourceArray, bool isDestinationArray)
    {
        if (isSourceArray && isDestinationArray)
            return;

        var sourceGenericArg = sourceType.GetGenericArguments()[0];
        var destinationGenericArg = destinationType.GetGenericArguments()[0];

        var isSourcePrimitive = Caching.IsPrimitiveOrCached(sourceGenericArg);
        var isDestinationPrimitive = Caching.IsPrimitiveOrCached(destinationGenericArg);

        if (isSourcePrimitive && isDestinationPrimitive && (sourceGenericArg != destinationGenericArg))
            throw new MapperException("Unsupported mapping type");

        if (isSourcePrimitive != isDestinationPrimitive)
            throw new MapperException("Unsupported mapping type");

        var sourceGenericDef = sourceType.GetGenericTypeDefinition();
        var destinationGenericDef = destinationType.GetGenericTypeDefinition();

        if (sourceGenericDef != destinationGenericDef)
            throw new MapperException("Unsupported mapping type");

    }
}
