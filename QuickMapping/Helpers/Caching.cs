using System.Collections.Concurrent;
using System.Reflection;

namespace QuickMapping.Helpers;
public static class Caching
{
    public static readonly ConcurrentDictionary<Type, PropertyInfo[]> _cachedProperties = new();
    public static readonly ConcurrentDictionary<Type, bool> _cachedBools = new();

    public static PropertyInfo[] GetProperties(Type type) =>
        _cachedProperties.GetOrAdd(type, t => t.GetProperties());

    public static bool IsPrimitiveOrCached(Type type) =>
       _cachedBools.GetOrAdd(type, Validations.IsPrimitive(type));
}
