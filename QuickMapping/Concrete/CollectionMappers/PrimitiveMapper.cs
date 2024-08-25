namespace QuickMapping.Concrete.CollectionMappers;
public static class PrimitiveMapper
{    public static bool Validate(Type elementType) =>
       elementType.IsPrimitive ||
       elementType == typeof(string);   
}
