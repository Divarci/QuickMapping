using QuickMapping.Exceptions;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq.Expressions;
using System.Reflection;

namespace QuickMapping.Helpers;
public static class Expressions
{
    public static object CreateInstance(Type destinationType)
    {
        var newExp = Expression.New(destinationType);

        var lambda = Expression.Lambda<Func<object>>(Expression.Convert(newExp, typeof(object)));
        var compiledLambda = lambda.Compile();

        return compiledLambda();
    }

    public static object CreateInstanceWithConstructor(Type destinationType, object @object)
    {
        var objectType = @object.GetType();

        ConstructorInfo constructor = destinationType.GetConstructor([objectType])
        ?? throw new MapperException("Constructor not found");

        var constructorParam = Expression.Constant(@object, objectType);
        var newExp = Expression.New(constructor, constructorParam);

        var lambda = Expression.Lambda<Func<object>>(Expression.Convert(newExp, typeof(object)));
        var compiledLambda = lambda.Compile();

        return compiledLambda();
    }

    public static Array CreateArrayInstance(Type elementType, int length)
    {
        var createInstanceMethod = typeof(Array).GetMethod("CreateInstance", [typeof(Type), typeof(int)])
            ?? throw new MapperException("Array.CreateInstance method not found");

        var elementTypeExpression = Expression.Constant(elementType, typeof(Type));
        var lengthExpression = Expression.Constant(length, typeof(int));

        var methodCallExpression = Expression.Call(createInstanceMethod, elementTypeExpression, lengthExpression);

        var lambda = Expression.Lambda<Func<Array>>(methodCallExpression);
        var compiledLambda = lambda.Compile();

        return compiledLambda();
    }
}
