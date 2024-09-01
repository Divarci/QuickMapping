using QuickMapping.Exceptions;
using QuickMapping.Options;
using QuickMapping.Validations;
using System.Collections;
using System.Security.AccessControl;

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

        if (CollectionCheck(sourceType) && CollectionCheck(destinationType))
        {
            DictionaryValidation(sourceType, destinationType);

            ArrayValidation(sourceType, destinationType);

            CollectionValidation(sourceType, destinationType);

            return CollectionMapper.Map(
                destinationType,
                ref depth,
                source,
                options,
                destination);
        }

        if (CollectionCheck(sourceType) && !CollectionCheck(destinationType))
            throw new MapperException("Unsupported mapping type");

        if (!CollectionCheck(sourceType) && CollectionCheck(destinationType))
            throw new MapperException("Unsupported mapping type");

        return SingleUnitMapper.Map(
            sourceType,
            destinationType,
            ref depth,
            source,
            options,
            destination);
    }

    private static bool CollectionCheck(Type type) =>
        typeof(IEnumerable)
        .IsAssignableFrom(type) &&
        type != typeof(string);

    private static void DictionaryValidation(Type sourceType, Type destinationType)
    {
        if (CollectionCheck(sourceType) &&
                sourceType.Name.Contains("Dictionary") || sourceType.Name.Contains("KeyValue"))
            throw new MapperException("Unsupported mapping type");

        if (CollectionCheck(destinationType) &&
           destinationType.Name.Contains("Dictionary") || destinationType.Name.Contains("KeyValue"))
            throw new MapperException("Unsupported mapping type");
    }

    private static void ArrayValidation(Type sourceType, Type destinationType)
    {
        if (sourceType.IsArray)
        {
            if (!destinationType.IsArray)
                throw new MapperException("Unsupported mapping type");

            if (IsPrimitive.Check(sourceType.GetElementType()!) &&
                IsPrimitive.Check(destinationType.GetElementType()!))
                if (sourceType.GetElementType() != destinationType.GetElementType())
                    throw new MapperException("Unsupported mapping type");

            if (IsPrimitive.Check(sourceType.GetElementType()!) &&
                !IsPrimitive.Check(destinationType.GetElementType()!))
                throw new MapperException("Unsupported mapping type");


            if (!IsPrimitive.Check(sourceType.GetElementType()!) &&
                IsPrimitive.Check(destinationType.GetElementType()!))
                throw new MapperException("Unsupported mapping type");
        }

        if(destinationType.IsArray)
            if(!sourceType.IsArray)
                throw new MapperException("Unsupported mapping type");
    }

    private static void CollectionValidation(Type sourceType, Type destinationType)
    {
        if (sourceType.IsArray && destinationType.IsArray)
            return;

        if (IsPrimitive.Check(sourceType.GetGenericArguments()[0]) &&
            IsPrimitive.Check(destinationType.GetGenericArguments()[0]))
            if (sourceType.GetGenericArguments()[0] !=
                destinationType.GetGenericArguments()[0])
                throw new MapperException("Unsupported mapping type");

        if (IsPrimitive.Check(sourceType.GetGenericArguments()[0]) &&
            !IsPrimitive.Check(destinationType.GetGenericArguments()[0]))
            throw new MapperException("Unsupported mapping type");

        if (!IsPrimitive.Check(sourceType.GetGenericArguments()[0]) &&
            IsPrimitive.Check(destinationType.GetGenericArguments()[0]))
            throw new MapperException("Unsupported mapping type");

        if (sourceType.GetGenericTypeDefinition() !=
            destinationType.GetGenericTypeDefinition())
            throw new MapperException("Unsupported mapping type");
    }
}
