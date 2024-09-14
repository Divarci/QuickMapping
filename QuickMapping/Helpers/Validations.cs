using QuickMapping.Exceptions;
using System.Collections;

namespace QuickMapping.Helpers;
public static class Validations
{
    public static bool IsPrimitive(Type type) =>
        type.IsPrimitive ||
            new Type[] {
                typeof(string),
                typeof(decimal),
                typeof(DateTime),
                typeof(DateTimeOffset),
                typeof(TimeSpan),
                typeof(Guid)
            }.Contains(type) ||
            Convert.GetTypeCode(type) != TypeCode.Object;

    public static bool CollectionCheck(Type type) =>
        typeof(IEnumerable).IsAssignableFrom(type) &&
        type != typeof(string);

    public static bool IsCollectionValid(Type sourceType, Type destinationType)
    {
        var isSourceArray = sourceType.IsArray;
        var isDestinationArray = destinationType.IsArray;

        if (!PairValidation(sourceType, destinationType) ||
            !ArrayValidation(sourceType, destinationType, isSourceArray, isDestinationArray) ||
            !CollectionValidation(sourceType, destinationType, isSourceArray, isDestinationArray))
            return false;

        return true;
    }

    private static bool PairValidation(Type sourceType, Type destinationType)
    {
        if (typeof(Dictionary<,>).IsAssignableFrom(sourceType) ||
            typeof(KeyValuePair<,>).IsAssignableFrom(sourceType) ||
            typeof(Dictionary<,>).IsAssignableFrom(destinationType) ||
            typeof(KeyValuePair<,>).IsAssignableFrom(destinationType))
            return false;

        return true;
    }

    private static bool ArrayValidation(Type sourceType, Type destinationType,
        bool isSourceArray, bool isDestinationArray)
    {
        if (isSourceArray != isDestinationArray)
            return false;

        if (isSourceArray && isDestinationArray)
        {
            var sourceElementType = Caching.GetElementType(sourceType);
            var destinationElementType = Caching.GetElementType(destinationType);

            var resultForSourceElement = Caching.IsPrimitiveOrCached(sourceElementType!);
            var resultForDestinationElement = Caching.IsPrimitiveOrCached(destinationElementType!);

            if ((resultForDestinationElement != resultForSourceElement) ||
                (resultForSourceElement && resultForDestinationElement && (sourceElementType != destinationElementType)))
                return false;
        }

        return true;
    }

    private static bool CollectionValidation(Type sourceType, Type destinationType,
        bool isSourceArray, bool isDestinationArray)
    {
        if (isSourceArray && isDestinationArray)
            return true;

        var sourceGenericArg = Caching.GetGenericArgType(sourceType);
        var destinationGenericArg = Caching.GetGenericArgType(destinationType);

        var isSourcePrimitive = Caching.IsPrimitiveOrCached(sourceGenericArg);
        var isDestinationPrimitive = Caching.IsPrimitiveOrCached(destinationGenericArg);

        if (isSourcePrimitive && isDestinationPrimitive && (sourceGenericArg != destinationGenericArg))
            return false;

        if (isSourcePrimitive != isDestinationPrimitive)
            return false;

        var sourceGenericDef = Caching.GetGenericTypeDefinition(sourceType);
        var destinationGenericDef = Caching.GetGenericTypeDefinition(destinationType);

        if (sourceGenericDef != destinationGenericDef)
            return false;

        return true;
    }
}
