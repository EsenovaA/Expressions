using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace ExpressionTrees.Task1.ExpressionsTransformer
{
    public class ParametersToConstantsVisitor : ExpressionVisitor
    {
        private Dictionary<string, ConstantExpression> _parameters = new Dictionary<string, ConstantExpression>();

        public ParametersToConstantsVisitor(Dictionary<string, ConstantExpression> parameters)
        {
            _parameters = parameters;
        }

        protected override Expression VisitParameter(ParameterExpression node)
            => _parameters.TryGetValue(node.Name, out var ce) ? (Expression)ce : node;

        protected override Expression VisitLambda<T>(Expression<T> node)
            => Expression.Lambda(Visit(node.Body), node.Parameters); 

    }
}
