using QuickMapping.Concrete.Mappers;
using QuickMapping.Exceptions;
using QuickMapping.Options;
using QuickMapping.Validations;
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
        MappingOptions options)
    {

        Type? listType;

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
            if (IsPrimitive.Check(destinationElementType) &&
                IsPrimitive.Check(sourceElementType))
            {
                addMethod.Invoke(list, [sourceElement]);
            }
            else
            {
                var destinationElementObject = ObjectMapper.Map(
                sourceElementType,
                destinationElementType,
                depth,
                sourceElement,
                options,
                destination);

                addMethod.Invoke(list, [destinationElementObject]);
            }
        }
        return list ??
            throw new MapperException("IEnumerable Mapper failed");
    }
}
