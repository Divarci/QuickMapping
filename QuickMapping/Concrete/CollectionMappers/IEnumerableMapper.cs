using QuickMapping.Concrete.Mappers;
using QuickMapping.Exceptions;
using QuickMapping.Options;
using System.Collections;

namespace QuickMapping.Concrete.CollectionMappers;
public static class IEnumerableMapper
{
    public static bool Validate(Type elementType, Type collectionType) =>
        typeof(IEnumerable<>)
        .MakeGenericType(elementType)
        .IsAssignableFrom(collectionType);

    public static object Map(
        Type destinationType,
        Type sourceElementType,
        Type destinationElementType,
        object source,
        object? destination,
        int depth,
        MappingOptions options,
        string previousProcess)
    {

        Type? listType = null;

        if (destinationType.IsInterface)        
            listType = typeof(List<>)
                .MakeGenericType(destinationElementType);
        else        
            listType = destinationType
                .GetGenericTypeDefinition()
                .MakeGenericType(destinationElementType);

        var list = Activator.CreateInstance(listType);

        var addMethod = listType.GetMethod("Add") ??
            throw new MapperException("Destination type does not have add method");

        var iterateSource = (IEnumerable)source;     
            
        foreach (var sourceElement in iterateSource)
        {
            if (PrimitiveMapper.Validate(destinationElementType) &&
            PrimitiveMapper.Validate(sourceElementType))
            {
                addMethod.Invoke(list, [sourceElement]);
            }
            else
            {
                depth--;

                var destinationElementObject = ObjectMapper.Map(
                sourceElementType,
                destinationElementType,
                depth,
                sourceElement,
                options,
                destination,
                previousProcess);

                addMethod.Invoke(list, [destinationElementObject]);

                depth++;
            }
        }
        return list ??
            throw new MapperException("IEnumerable Mapper failed");
    }
}
