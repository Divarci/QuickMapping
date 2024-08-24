using QuickMapping.Options;

namespace QuickMapping.Concrete.CollectionMappers;
public static class ArrayMapper
{
    public static bool Validate(Type collectionType) =>
        collectionType.IsArray;

    public static object Map(
       Type sourceElementType,
       Type destinationElementType,
       object source,
       object? destination,
       int depth,
       MappingOptions options,
       string previousProcess)
    {
        var sourceArray = (Array)source;

        var destinationArray = Array
            .CreateInstance(destinationElementType, sourceArray.Length);

        for (int i = 0; i < sourceArray.Length; i++)
        {
            depth--;

            var destinationElementObject = ObjectMapper.Map(
                sourceElementType,
                destinationElementType,
                depth,
                sourceArray.GetValue(i)!,
                options,
                destination,
                previousProcess);

            depth++;

            destinationArray.SetValue(destinationElementObject, i);
        }
        return destinationArray;
    }
}
