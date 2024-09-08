using QuickMapping.Concrete.Mappers;
using QuickMapping.Exceptions;
using QuickMapping.Options;
using QuickMapping.Helpers;

namespace QuickMapping.Concrete.CollectionMappers;
public static class ArrayMapper
{
    public static bool Validate(Type sourceType, Type destinationType) =>
        sourceType.IsArray && destinationType.IsArray;

    public static object Map(
       Type sourceType,
       Type destinationType,
       object source,
       object? destination,
       int depth,
       MappingOptions options)
    {
        var sourceArray = (Array)source;

        if (sourceArray.Length < 0)
            throw new MapperException("Source can not be empty object");

        if (Caching.IsPrimitiveOrCached(sourceArray.GetValue(0)!.GetType()))
            return sourceArray;

        var sourceElementType = sourceType.GetElementType();
        var destinationElementType = destinationType.GetElementType();

        var destinationArray = Array.CreateInstance(destinationElementType!, sourceArray.Length);

        for (int i = 0; i < sourceArray.Length; i++)
        {
            var destinationElementObject = ObjectMapper.Map(
                sourceElementType!,
                destinationElementType!,
                depth,
                sourceArray.GetValue(i)!,
                options,
                destination);

            destinationArray.SetValue(destinationElementObject, i);
            continue;
        }
        return destinationArray;
    }
}
