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
    }
}
