﻿using QuickMapping.Concrete.Mappers;
using QuickMapping.Exceptions;
using QuickMapping.Options;
using QuickMapping.Helpers;
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
        MappingOptions options)
    {
        var listType = typeof(List<>)
            .MakeGenericType(destinationElementType);

        var list = (IList)Caching.GetInstance(listType)();

        if (Caching.IsPrimitiveOrCached(destinationElementType) &&
            Caching.IsPrimitiveOrCached(sourceElementType))
            return source;

        var iterateSource = (IEnumerable)source;

        foreach (var sourceElement in iterateSource)
        {
            var destinationElementObject = ObjectMapper.Map(
            sourceElementType,
            destinationElementType,
            depth,
            sourceElement,
            options,
            destination);

            list.Add(destinationElementObject);
        }

        var readonlyListType = typeof(ReadOnlyCollection<>).MakeGenericType(destinationElementType);

        return Caching.GetReadonlyCollectionInstance(readonlyListType, destinationElementType)(list) ??
            throw new MapperException("IReadonlyMapper failed");
    }
}
