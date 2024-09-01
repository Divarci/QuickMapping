using QuickMapping.Concrete.Mappers;
using QuickMapping.Options;
using QuickMapping.Validations;

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
        
        var destinationArray = Array
            .CreateInstance(destinationType.GetElementType()!, sourceArray.Length);

        for (int i = 0; i < sourceArray.Length; i++)
        {
            if (IsPrimitive.Check(sourceArray.GetValue(i)!.GetType()))
            {                
                destinationArray.SetValue(sourceArray.GetValue(i), i);
                continue;
            }
            else
            {
                var destinationElementObject = ObjectMapper.Map(
                    sourceType.GetElementType()!,
                    destinationType.GetElementType()!,
                    depth,
                    sourceArray.GetValue(i)!,
                    options,
                    destination);

                destinationArray.SetValue(destinationElementObject, i);
                continue;
            }
        }
        return destinationArray;
    }
}
