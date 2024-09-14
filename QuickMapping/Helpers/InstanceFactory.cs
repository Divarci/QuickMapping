using QuickMapping.Exceptions;
using System.Collections.ObjectModel;
using System.Linq.Expressions;

namespace QuickMapping.Helpers
{
    public static class InstanceFactory
    {     
        public static Func<object> CreateInstance(Type type)
        {
            var ctor = type.GetConstructor(Type.EmptyTypes)!;

            var newExp = Expression.New(ctor);

            return Expression.Lambda<Func<object>>(newExp).Compile();
        }

        public static Func<object, object> CreateReadOnlyCollectionInstance(Type readonlyCollectionType, Type elementType)
        {           
            var constructor = readonlyCollectionType
                .GetConstructor([typeof(IList<>).MakeGenericType(elementType)]) ??
                throw new MapperException("Constructor not found");           

            var param = Expression.Parameter(typeof(object), "list");

            var castParam = Expression.Convert(param, typeof(IList<>).MakeGenericType(elementType));

            var newExp = Expression.New(constructor, castParam);

            var lambda = Expression.Lambda<Func<object, object>>(Expression.Convert(newExp, typeof(object)), param);

            return lambda.Compile();
        }
    }

}
