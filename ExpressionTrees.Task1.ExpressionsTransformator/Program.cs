/*
 * Create a class based on ExpressionVisitor, which makes expression tree transformation:
 * 1. converts expressions like <variable> + 1 to increment operations, <variable> - 1 - into decrement operations.
 * 2. changes parameter values in a lambda expression to constants, taking the following as transformation parameters:
 *    - source expression;
 *    - dictionary: <parameter name: value for replacement>
 * The results could be printed in console or checked via Debugger using any Visualizer.
 */
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ExpressionTrees.Task1.ExpressionsTransformer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("1. Expression Visitor for increment/decrement.");
            Console.WriteLine();

            var visitor = new IncDecExpressionVisitor();
            Expression<Func<int, int>> exprTreeIncr = num => num + 1;
            Expression<Func<int, int>> exprTreeDecr = num => num - 1;

            Console.WriteLine($"Source expression for increment: {exprTreeIncr}.");
            var visitedIncr = visitor.Visit(exprTreeIncr);
            Console.WriteLine($"Modified expression for increment {visitedIncr}.");

            Console.WriteLine($"Source expression for decrement: {exprTreeDecr}.");
            var visitedDecr = visitor.Visit(exprTreeDecr);
            Console.WriteLine($"Modified expression for increment {visitedDecr}.");

            Console.WriteLine();
            Console.WriteLine("2. Expression Visitor for transformation parameter values.");
            Console.WriteLine();

            Expression<Func<int, int, int>> add = (x, y) => ((2 * x) + y);
            Console.WriteLine($"Source expression with parameters: {add}.");

            var parameters = new Dictionary<string, ConstantExpression>();
            parameters.Add("x", Expression.Constant(4));
            parameters.Add("y", Expression.Constant(1));

            var paramVisitor = new ParametersToConstantsVisitor(parameters);
            var result = (LambdaExpression)paramVisitor.Visit(add);
            Console.WriteLine($"Modified expression with parameters: {result}.");

            Console.ReadLine();
        }
    }
}
