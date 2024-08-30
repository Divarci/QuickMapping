using QuickMapping.Concrete.Mappers;
using QuickMapping.Exceptions;
using QuickMapping.Options;

namespace QuickMapping.Concrete.CollectionMappers;
public static class ArrayMapper
{
    public static bool Validate(Type sourceType, Type destinationType) =>
        sourceType.IsArray && destinationType.IsArray;

    public static object Map(
       Type sourceElementType,
       Type destinationElementType,
       object source,
       object? destination,
       int depth,
    MappingOptions options,
       string previousProcess)
    {
        if (sourceElementType.Name != destinationElementType.Name)
            throw new MapperException("Source Collection type and Destination Collection type must be equal");

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
