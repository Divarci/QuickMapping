namespace QuickMapping.Helpers;
public static class Validations
{
    public static bool IsPrimitive(Type type) =>
        type.IsPrimitive ||
            new Type[] {
                typeof(string),
                typeof(decimal),
                typeof(DateTime),
                typeof(DateTimeOffset),
                typeof(TimeSpan),
                typeof(Guid)
            }.Contains(type) ||
            Convert.GetTypeCode(type) != TypeCode.Object;
}
