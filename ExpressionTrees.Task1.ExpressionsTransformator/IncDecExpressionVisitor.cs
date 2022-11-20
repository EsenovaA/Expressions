using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ExpressionTrees.Task1.ExpressionsTransformer
{
    public class IncDecExpressionVisitor : ExpressionVisitor
    {
        protected override Expression VisitBinary(BinaryExpression node)
        {
            switch (node.NodeType)
            {
                case ExpressionType.Add:

                    if (node.Right is ConstantExpression expAdd)
                    {
                        if (expAdd.Value is int intValue)
                        {
                            if (intValue == 1)
                            {
                                return Expression.Increment(node.Left);
                            }
                        }
                    } 
                    
                    break;

                case ExpressionType.Subtract:

                    if (node.Right is ConstantExpression expSub)
                    {
                        if (expSub.Value is int intValue)
                        {
                            if (intValue == 1)
                            {
                                return Expression.Decrement(node.Left);
                            }
                        }
                    }

                    break;

                default:
                    throw new NotSupportedException($"Operation '{node.NodeType}' is not supported");
            };

            return node;
        }
        
    }
}
