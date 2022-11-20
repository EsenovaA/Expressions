using System;
using System.Linq.Expressions;

namespace ExpressionTrees.Task2.ExpressionMapping
{
    public class MappingGenerator<TSource, TDestination>
    {
        private readonly Expression<Func<TSource, TDestination>> _diffrentFieldsMap;

        public MappingGenerator(Expression<Func<TSource, TDestination>> diffrentFieldsMap)
        {
            _diffrentFieldsMap = diffrentFieldsMap;
        }

        public Mapper<TSource, TDestination> Generate()
        {
            var sourceParam = Expression.Parameter(typeof(TSource));
            // TODO: add _diffrentFieldsMap using somewhere here
            var mapFunction =
                Expression.Lambda<Func<TSource, TDestination>>(
                    Expression.New(typeof(TDestination)),
                    sourceParam
                );

            return new Mapper<TSource, TDestination>(mapFunction.Compile());
        }
    }
}
