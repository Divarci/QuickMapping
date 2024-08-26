﻿using QuickMapping.Concrete.Mappers;
using QuickMapping.Exceptions;
using QuickMapping.Options;
using System.Collections;
using System.Collections.ObjectModel;

namespace QuickMapping.Concrete.CollectionMappers;
public static class IReadOnlyCollectionMapper
{
    public static bool Validate(Type elementType, Type collectionType, object @object)
    {
        var typeCheck = typeof(IEnumerable<>)
            .MakeGenericType(elementType)
            .IsAssignableFrom(collectionType);

        var nameCheck = collectionType
            .Name.ToLower()
            .Contains("readonly");

        return (typeCheck && nameCheck);
    }

    public static object Map(
        Type sourceElementType,
        Type destinationElementType,
        object source,
        object? destination,
        int depth,
        MappingOptions options,
        string previousProcess)
    {
        var listType = typeof(List<>)
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

        var readonlyListType = typeof(ReadOnlyCollection<>).MakeGenericType(destinationElementType);

        return Activator.CreateInstance(readonlyListType, list) ??
            throw new MapperException("IReadonlyMapper failed");
    }
}