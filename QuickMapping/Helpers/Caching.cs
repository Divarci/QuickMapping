using System.Collections.Concurrent;
using System.Linq.Expressions;
using System.Reflection;

namespace QuickMapping.Helpers
{
    public static class Caching
    {
        private static ConcurrentDictionary<Type, Dictionary<string, PropertyInfo>> _propertiesWithDefaultCase = new();
        private static ConcurrentDictionary<Type, Dictionary<string, PropertyInfo>> _propertiesWithLowerCase = new();
        private static ConcurrentDictionary<Type, bool> _primitiveCheckList = new();
        private static ConcurrentDictionary<Type, bool> _collectionCheckList = new();
        private static ConcurrentDictionary<Type, Type> _elementTypeList = new();
        private static ConcurrentDictionary<Type, Type> _genericArgList = new();
        private static ConcurrentDictionary<Type, Type> _genericTypeDefinitions = new();
        private static ConcurrentDictionary<PropertyInfo, Type> _getPropertyTypes = new();
        private static ConcurrentDictionary<Type, Func<object>> _getInstanceInfoList = new();
        private static ConcurrentDictionary<Type[], bool> _getCollectionValidationList = new();

        public static Dictionary<string, PropertyInfo> GetPropertiesWithDefaultCase(Type type) =>
            _propertiesWithDefaultCase
            .GetOrAdd(
                type,
                t => t.GetProperties()
                      .ToDictionary(x => x.Name));

        public static Dictionary<string, PropertyInfo> GetPropertiesWithLowerCase(Type type) =>
            _propertiesWithLowerCase
            .GetOrAdd(
                type,
                t => t.GetProperties()
                      .ToDictionary(x => x.Name.ToLower()));

        public static bool IsPrimitiveOrCached(Type type) =>
            _primitiveCheckList
            .GetOrAdd(
                type,
                key => Validations.IsPrimitive(type));

        public static bool IsCollection(Type type) =>
            _collectionCheckList
            .GetOrAdd(
                type,
                key => Validations.CollectionCheck(type));

        public static Type GetElementType(Type type) =>
            _elementTypeList
            .GetOrAdd(
                type,
                t => t.GetElementType()!);

        public static Type GetGenericArgType(Type type) =>
            _genericArgList
            .GetOrAdd(
                type,
                t => t.GetGenericArguments()[0]);

        public static Type GetGenericTypeDefinition(Type type) =>
            _genericTypeDefinitions
            .GetOrAdd(
                type,
                t => t.GetGenericTypeDefinition());

        public static Type GetPropertyType(PropertyInfo propertyInfo) =>
            _getPropertyTypes
            .GetOrAdd(
                propertyInfo,
                t => t.PropertyType);            
      
        public static Func<object> GetInstance(Type type) =>
           _getInstanceInfoList
           .GetOrAdd(
               type,
               key => InstanceFactory.CreateInstance(type));

        public static bool IsCollectionValid(Type sourceType,Type destinationType) =>
            _getCollectionValidationList
            .GetOrAdd(
                [sourceType,destinationType],
                key => Validations.IsCollectionValid(sourceType, destinationType));


    }
}
