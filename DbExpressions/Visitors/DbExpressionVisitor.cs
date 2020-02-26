using System;
using System.Collections.Generic;
using System.Linq;

namespace DbExpressions
{
    /// <summary>
    /// Represents a visitor or rewriter for <see cref="DbExpression"/> trees.
    /// </summary>
    public class DbExpressionVisitor
    {        
        /// <summary>
        /// Initializes a new instance of the <see cref="DbExpressionVisitor"/> class.
        /// </summary>
        public DbExpressionVisitor()
        {
            ExpressionFactory = new DbExpressionFactory();
        }

        /// <summary>
        /// Gets the <see cref="DbExpressionFactory"/> instance used to create new <see cref="DbExpression"/> instances.
        /// </summary>
        protected DbExpressionFactory ExpressionFactory { get; private set; }

        /// <summary>
        /// Visits each node of the <see cref="DbExpression"/> tree and rewrites the tree if any changes has been made to any of the child nodes.
        /// </summary>
        /// <param name="dbExpression">The <see cref="DbExpression"/> to visit.</param>
        /// <returns>A <see cref="DbExpression"/> instance.</returns>
        public virtual DbExpression Visit(DbExpression dbExpression)
        {
            if (dbExpression.IsNull())
                return dbExpression;
            var expressionType = dbExpression.ExpressionType;
            switch (expressionType)
            {
                case DbExpressionType.Function:
                    return VisitFunctionExpression((DbFunctionExpression)dbExpression);
                case DbExpressionType.Select:
                    return VisitSelectExpression((DbSelectExpression)dbExpression);
                case DbExpressionType.Update:
                    return VisitUpdateExpression((DbUpdateExpression)dbExpression);
                case DbExpressionType.Insert:
                    return VisitInsertExpression((DbInsertExpression)dbExpression);
                case DbExpressionType.Delete:
                    return VisitDeleteExpression((DbDeleteExpression)dbExpression);
                case DbExpressionType.Column:
                    return VisitColumnExpression((DbColumnExpression)dbExpression);
                case DbExpressionType.Table:
                    return VisitTableExpression((DbTableExpression)dbExpression);
                case DbExpressionType.Binary:
                    return VisitBinaryExpression((DbBinaryExpression)dbExpression);
                case DbExpressionType.Constant:
                    return VisitConstantExpression((DbConstantExpression)dbExpression);
                case DbExpressionType.Alias:
                    return VisitAliasExpression((DbAliasExpression)dbExpression);
                case DbExpressionType.Concat:
                    return VisitConcatExpression((DbConcatExpression)dbExpression);
                case DbExpressionType.Conditional:
                    return VisitConditionalExpression((DbConditionalExpression)dbExpression);
                case DbExpressionType.Exists:
                    return VisitExistsExpression((DbExistsExpression)dbExpression);
                case DbExpressionType.List:
                    return VisitListExpression((DbListExpression)dbExpression);
                case DbExpressionType.Batch:
                    return VisitBatchExpression((DbBatchExpression)dbExpression);
                case DbExpressionType.In:
                    return VisitInExpression((DbInExpression)dbExpression);
                case DbExpressionType.Query:
                    return VisitQueryExpression((DbQuery)dbExpression);
                case DbExpressionType.Join:
                    return VisitJoinExpression((DbJoinExpression)dbExpression);
                case DbExpressionType.Unary:
                    return VisitUnaryExpression((DbUnaryExpression)dbExpression);
                case DbExpressionType.OrderBy:
                    return VisitOrderByExpression((DbOrderByExpression)dbExpression);
                case DbExpressionType.Prefix:
                    return VisitPrefixExpression((DbPrefixExpression)dbExpression);
                case DbExpressionType.Sql:                    
                    return VisitSqlExpression((DbSqlExpression)dbExpression);
            }
            throw new ArgumentOutOfRangeException(
                "dbExpression",
                string.Format("The expression type '{0}' is not supported", dbExpression.ExpressionType));                                        
        }

        /// <summary>
        /// Visits <see cref="DbSqlExpression"/> nodes.
        /// </summary>
        /// <param name="sqlExpression">The <see cref="DbSqlExpression"/> to visit</param>
        /// <returns>A <see cref="Db"/></returns>
        protected virtual DbExpression VisitSqlExpression(DbSqlExpression sqlExpression)
        {
            return sqlExpression;
        }

        /// <summary>
        /// Translates the <paramref name="binaryExpression"/> into a string representation.
        /// </summary>
        /// <param name="binaryExpression">The <see cref="DbBinaryExpression"/> to translate.</param>
        /// <returns><see cref="DbExpression"/></returns>
        protected virtual DbExpression VisitBinaryExpression(DbBinaryExpression binaryExpression)
        {
            var leftExpression = Visit(binaryExpression.LeftExpression);
            var rightExpression = Visit(binaryExpression.RightExpression);
            if (!leftExpression.Equals(binaryExpression.LeftExpression) ||
                !rightExpression.Equals(binaryExpression.RightExpression))
            {
                return ExpressionFactory.MakeBinary(binaryExpression.BinaryExpressionType, leftExpression, rightExpression);
            }

            return binaryExpression;
        }

        /// <summary>
        /// Translates the <paramref name="functionExpression"/> into a string representation.
        /// </summary>
        /// <param name="functionExpression">The <see cref="DbFunctionExpression"/> to translate.</param>
        /// <returns><see cref="DbExpression"/></returns>
        protected virtual DbExpression VisitFunctionExpression(DbFunctionExpression functionExpression)
        {
            switch (functionExpression.FunctionExpressionType)
            {
                case DbFunctionExpressionType.String:
                    return VisitStringFunctionExpression((DbStringFunctionExpression)functionExpression);
                case DbFunctionExpressionType.Aggregate:
                    return VisitAggregateFunctionExpression((DbAggregateFunctionExpression)functionExpression);
                case DbFunctionExpressionType.DateTime:
                    return VisitDateTimeFunctionExpression((DbDateTimeFunctionExpression)functionExpression);
                case DbFunctionExpressionType.Mathematical:
                    return VisitMathematicalFunctionExpression((DbMathematicalFunctionExpression)functionExpression);
                default:
                    throw new ArgumentOutOfRangeException("functionExpression", functionExpression.FunctionExpressionType, "Not supported");
            }
        }

        /// <summary>
        /// Translates the <paramref name="stringFunctionExpression"/> into a string representation.
        /// </summary>
        /// <param name="stringFunctionExpression">The <see cref="DbStringFunctionExpression"/> to translate.</param>
        /// <returns><see cref="DbExpression"/></returns>
        protected virtual DbExpression VisitStringFunctionExpression(DbStringFunctionExpression stringFunctionExpression)
        {            
            var arguments = VisitListExpression(stringFunctionExpression.Arguments);
            if (!ReferenceEquals(arguments, stringFunctionExpression.Arguments))
                return ExpressionFactory.MakeStringFunction(stringFunctionExpression.StringFunctionExpressionType,
                                                            arguments.ToArray());

            return stringFunctionExpression;
        }

        /// <summary>
        /// Translates the <paramref name="aggregateFunctionExpression"/> into a string representation.
        /// </summary>
        /// <param name="aggregateFunctionExpression">The <see cref="DbAggregateFunctionExpression"/> to translate.</param>
        /// <returns><see cref="DbExpression"/></returns>
        protected virtual DbExpression VisitAggregateFunctionExpression(DbAggregateFunctionExpression aggregateFunctionExpression)
        {
            var arguments = VisitListExpression(aggregateFunctionExpression.Arguments);
            if (!ReferenceEquals(arguments, aggregateFunctionExpression.Arguments))
                return ExpressionFactory.MakeAggregateFunction(aggregateFunctionExpression.AggregateFunctionExpressionType,
                                                            arguments.First());            
            return aggregateFunctionExpression;
        }

        /// <summary>
        /// Translates the <paramref name="dateTimeFunctionExpression"/> into a string representation.
        /// </summary>
        /// <param name="dateTimeFunctionExpression">The <see cref="DbDateTimeFunctionExpression"/> to translate.</param>
        /// <returns><see cref="DbExpression"/></returns>
        protected virtual DbExpression VisitDateTimeFunctionExpression(DbDateTimeFunctionExpression dateTimeFunctionExpression)
        {
            var arguments = VisitListExpression(dateTimeFunctionExpression.Arguments);
            if (!ReferenceEquals(arguments, dateTimeFunctionExpression.Arguments))
                return ExpressionFactory.MakeDateTimeFunction(dateTimeFunctionExpression.DateTimeFunctionExpressionType,
                                                            arguments.ToArray());

            return dateTimeFunctionExpression;
        }


        /// <summary>
        /// Translates the <paramref name="mathematicalFunctionExpression"/> into a string representation.
        /// </summary>
        /// <param name="mathematicalFunctionExpression">The <see cref="DbMathematicalFunctionExpression"/> to translate.</param>
        /// <returns><see cref="DbExpression"/></returns>
        protected virtual DbExpression VisitMathematicalFunctionExpression(DbMathematicalFunctionExpression mathematicalFunctionExpression)
        {
            var arguments = VisitListExpression(mathematicalFunctionExpression.Arguments);
            if (!ReferenceEquals(arguments, mathematicalFunctionExpression.Arguments))
                return ExpressionFactory.MakeMathematicalFunction(mathematicalFunctionExpression.MathematicalFunctionExpressionType,
                                                            arguments.ToArray());

            return mathematicalFunctionExpression;
        }

        /// <summary>
        /// Translates the <paramref name="selectExpression"/> into a string representation.
        /// </summary>
        /// <param name="selectExpression">The <see cref="DbSelectExpression"/> to translate.</param>
        /// <returns><see cref="DbExpression"/></returns>
        protected virtual DbExpression VisitSelectExpression(DbSelectExpression selectExpression)
        {
            var projectionExpression = Visit(selectExpression.ProjectionExpression);
            var fromExpression = Visit(selectExpression.FromExpression);
            var whereExpression = Visit(selectExpression.WhereExpression);
            var orderByExpression = Visit(selectExpression.OrderByExpression);
            var groupByExpression = Visit(selectExpression.GroupByExpression);
            var havingExpression = Visit(selectExpression.HavingExpression);
            var takeExpression = Visit(selectExpression.TakeExpression);
            var skipExpression = Visit(selectExpression.SkipExpression);
            
            if (!ReferenceEquals(projectionExpression,selectExpression.ProjectionExpression) ||
                !ReferenceEquals(fromExpression, selectExpression.FromExpression) ||
                !ReferenceEquals(whereExpression, selectExpression.WhereExpression) ||
                !ReferenceEquals(orderByExpression, selectExpression.OrderByExpression) ||
                !ReferenceEquals(groupByExpression, selectExpression.GroupByExpression) ||
                !ReferenceEquals(havingExpression, selectExpression.HavingExpression) ||
                !ReferenceEquals(takeExpression, selectExpression.TakeExpression) ||
                !ReferenceEquals(skipExpression, selectExpression.SkipExpression)                                                
                )
            {
                selectExpression.ProjectionExpression = projectionExpression;
                selectExpression.FromExpression = fromExpression;
                selectExpression.WhereExpression = whereExpression;
                selectExpression.OrderByExpression = orderByExpression;
                selectExpression.GroupByExpression = groupByExpression;
                selectExpression.HavingExpression = havingExpression;
                selectExpression.TakeExpression = takeExpression;
                selectExpression.SkipExpression = skipExpression;
            }            
            return selectExpression;
        }


        /// <summary>
        /// Translates the <paramref name="updateExpression"/> into a string representation.
        /// </summary>
        /// <param name="updateExpression">The <see cref="DbUpdateExpression"/> to translate.</param>
        /// <returns><see cref="DbExpression"/></returns>
        protected virtual DbExpression VisitUpdateExpression(DbUpdateExpression updateExpression)
        {            
            var targetExpression = Visit(updateExpression.Target);
            var fromExpression = Visit(updateExpression.FromExpression);
            var setExpression = Visit(updateExpression.SetExpression);
            var whereExpression = Visit(updateExpression.WhereExpression);
            if (!ReferenceEquals(targetExpression,updateExpression.Target))
                updateExpression.Target = targetExpression;
            if (!ReferenceEquals(fromExpression, updateExpression.FromExpression))
                updateExpression.FromExpression = fromExpression;
            if (!ReferenceEquals(setExpression, updateExpression.SetExpression))
                updateExpression.SetExpression = setExpression;
            if (!ReferenceEquals(whereExpression, updateExpression.WhereExpression))
                updateExpression.WhereExpression= whereExpression;
            return updateExpression;
        }

        /// <summary>
        /// Translates the <paramref name="insertExpression"/> into a string representation.
        /// </summary>
        /// <param name="insertExpression">The <see cref="DbInsertExpression"/> to translate.</param>
        /// <returns><see cref="DbExpression"/></returns>
        protected virtual DbExpression VisitInsertExpression(DbInsertExpression insertExpression)
        {
            var targetExpression = Visit(insertExpression.Target);
            var fromExpression = Visit(insertExpression.FromExpression);
            var valuesExpression = Visit(insertExpression.Values);
            var columnsExpression = Visit(insertExpression.TargetColumns);

            if (!ReferenceEquals(targetExpression, insertExpression.Target))
                insertExpression.Target = targetExpression;
            if (!ReferenceEquals(fromExpression, insertExpression.FromExpression))
                insertExpression.FromExpression = fromExpression;
            if (!ReferenceEquals(valuesExpression, insertExpression.Values))
                insertExpression.Values = valuesExpression;
            if (!ReferenceEquals(columnsExpression, insertExpression.TargetColumns))
                insertExpression.TargetColumns = columnsExpression;
            return insertExpression;
        }

        /// <summary>
        /// Translates the <paramref name="deleteExpression"/> into a string representation.
        /// </summary>
        /// <param name="deleteExpression">The <see cref="DbDeleteExpression"/> to translate.</param>
        /// <returns><see cref="DbExpression"/></returns>
        protected virtual DbExpression  VisitDeleteExpression(DbDeleteExpression deleteExpression)
        {
            var targetExpression = Visit(deleteExpression.Target);
            var fromExpression = Visit(deleteExpression.FromExpression);
            var whereExpression = Visit(deleteExpression.WhereExpression);
            if (!ReferenceEquals(targetExpression,deleteExpression.Target) ||
                !ReferenceEquals(fromExpression,deleteExpression.FromExpression) ||
                !ReferenceEquals(whereExpression,deleteExpression.WhereExpression))
            {
                return ExpressionFactory.Delete(targetExpression, fromExpression, whereExpression);                                
            }
            return deleteExpression;
        }


        /// <summary>
        /// Translates the <paramref name="columnExpression"/> into a string representation.
        /// </summary>
        /// <param name="columnExpression">The <see cref="DbColumnExpression"/> to translate.</param>
        /// <returns><see cref="DbExpression"/></returns>
        protected virtual DbExpression VisitColumnExpression(DbColumnExpression columnExpression)
        {
            return columnExpression;
        }

        /// <summary>
        /// Translates the <paramref name="tableExpression"/> into a string representation.
        /// </summary>
        /// <param name="tableExpression">The <see cref="DbTableExpression"/> to translate.</param>
        /// <returns><see cref="DbExpression"/></returns>
        protected virtual DbExpression VisitTableExpression(DbTableExpression tableExpression)
        {            
            return tableExpression;
        }

        /// <summary>
        /// Translates the <paramref name="constantExpression"/> into a string representation.
        /// </summary>
        /// <param name="constantExpression">The <see cref="DbConstantExpression"/> to translate.</param>
        /// <returns><see cref="DbExpression"/></returns>
        protected virtual DbExpression VisitConstantExpression(DbConstantExpression constantExpression)
        {
            return constantExpression;
        }

        /// <summary>
        /// Translates the <paramref name="aliasExpression"/> into a string representation.
        /// </summary>
        /// <param name="aliasExpression">The <see cref="DbAliasExpression"/> to translate.</param>
        /// <returns><see cref="DbExpression"/></returns>
        protected virtual DbExpression VisitAliasExpression(DbAliasExpression aliasExpression)
        {
            var targetExpression = Visit(aliasExpression.Target);
            if (!ReferenceEquals(targetExpression, aliasExpression))            
                return ExpressionFactory.Alias(targetExpression, aliasExpression.Alias);            
            return aliasExpression;
        }

        /// <summary>
        /// Translates the <paramref name="concatExpression"/> into a string representation.
        /// </summary>
        /// <param name="concatExpression">The <see cref="DbConcatExpression"/> to translate.</param>
        /// <returns><see cref="DbExpression"/></returns>
        protected virtual DbExpression VisitConcatExpression(DbConcatExpression concatExpression)
        {
            var leftExpression = Visit(concatExpression.LeftExpression);
            var rightExpression = Visit(concatExpression.RightExpression);
            if (!ReferenceEquals(concatExpression.LeftExpression, leftExpression) ||
                !ReferenceEquals(concatExpression.RightExpression, rightExpression))
            {
                return ExpressionFactory.Concat(leftExpression, rightExpression);
            }

            return concatExpression;
        }

        /// <summary>
        /// Translates the <paramref name="conditionalExpression"/> into a string representation.
        /// </summary>
        /// <param name="conditionalExpression">The <see cref="DbConditionalExpression"/> to translate.</param>
        /// <returns><see cref="DbExpression"/></returns>
        protected virtual DbExpression VisitConditionalExpression(DbConditionalExpression conditionalExpression)
        {
            var conditionExpression = Visit(conditionalExpression.Condition);
            var ifFalseExpression = Visit(conditionalExpression.IfFalse);
            var ifTrueExpression = Visit(conditionalExpression.IfTrue);
            if (!ReferenceEquals(conditionalExpression.Condition, conditionExpression) ||
                !ReferenceEquals(conditionalExpression.IfFalse, ifFalseExpression) ||
                !ReferenceEquals(conditionalExpression.IfTrue, ifTrueExpression))
            {
                return ExpressionFactory.Conditional(conditionExpression, ifTrueExpression, ifFalseExpression);
            }
            return conditionalExpression;
        }

        /// <summary>
        /// Translates the <paramref name="existsExpression"/> into a string representation.
        /// </summary>
        /// <param name="existsExpression">The <see cref="DbExistsExpression"/> to translate.</param>
        /// <returns><see cref="DbExpression"/></returns>
        protected virtual DbExpression VisitExistsExpression(DbExistsExpression existsExpression)
        {
            var subSelectExpression = Visit(existsExpression.SubSelectExpression);
            if (!ReferenceEquals(existsExpression.SubSelectExpression, subSelectExpression))
                return ExpressionFactory.Exists((DbQuery<DbSelectExpression>)subSelectExpression);
            return existsExpression;
        }

        /// <summary>
        /// Translates the <paramref name="batchExpression"/> into a string representation.
        /// </summary>
        /// <param name="batchExpression">The <see cref="DbBatchExpression"/> to translate.</param>
        /// <returns><see cref="DbExpression"/></returns>
        protected virtual DbExpression VisitBatchExpression(DbBatchExpression batchExpression)
        {
            DbExpression[] originalList = batchExpression.ToArray();

            var list = VisitListExpression(originalList);
            if (!ReferenceEquals(originalList, list))
                return ExpressionFactory.Batch(list);

            return batchExpression;
        }


        /// <summary>
        /// Translates the <paramref name="listExpression"/> into a string representation.
        /// </summary>
        /// <param name="listExpression">The <see cref="DbListExpression"/> to translate.</param>
        /// <returns><see cref="DbExpression"/></returns>
        protected virtual DbExpression VisitListExpression(DbListExpression listExpression)
        {
            DbExpression[] originalList = listExpression.ToArray();

            var list = VisitListExpression(originalList);
            if (!ReferenceEquals(originalList, list))
                return ExpressionFactory.List(list);

            return listExpression;
        }


        private IEnumerable<DbExpression> VisitListExpression(DbExpression[] originalList)
        {
            List<DbExpression> list = null;

            for (int i = 0; i < originalList.Length; i++)
            {
                var expression = Visit(originalList[i]);

                if (list != null)
                {
                    //One of the previous expressions has changed and 
                    //we add this to the new list regardsless if this expression has changed.
                    list.Add(expression);
                }
                else if (!ReferenceEquals(expression, originalList[i]))
                {
                    //The expression has been modified and we create a new list                    
                    list = new List<DbExpression>(originalList.Length);
                    for (int j = 0; j < i; j++)
                    {
                        //Add all expressions that appeared before the modified expression.
                        list.Add(originalList[j]);
                    }
                    //Add the modified expression to the list
                    list.Add(expression);
                }
            }

            //If one of the expressions has been modified, we return the new list.
            if (list != null)
                return list;

            return originalList;
        }


        /// <summary>
        /// Translates the <paramref name="inExpression"/> into a string representation.
        /// </summary>
        /// <param name="inExpression">The <see cref="DbInExpression"/> to translate.</param>
        /// <returns><see cref="DbExpression"/></returns>
        protected virtual DbExpression VisitInExpression(DbInExpression inExpression)
        {
            var expression = Visit(inExpression.Expression);
            var targetExpression = Visit(inExpression.Target);
            if (!ReferenceEquals(expression, inExpression.Expression) ||
                !ReferenceEquals(targetExpression, inExpression.Target))
            {
                return ExpressionFactory.In(targetExpression, expression);
            }

            return inExpression;
        }


        /// <summary>
        /// Translates the <paramref name="query"/> into a string representation.
        /// </summary>
        /// <param name="query">The <see cref="DbInExpression"/> to translate.</param>
        /// <returns><see cref="DbExpression"/></returns>
        protected virtual DbExpression VisitQueryExpression(DbQuery query)
        {            
            return Visit(query.GetQueryExpression());        
        }

        /// <summary>
        /// Translates the <paramref name="joinExpression"/> into a string representation.
        /// </summary>
        /// <param name="joinExpression">The <see cref="DbJoinExpression"/> to translate.</param>
        /// <returns><see cref="DbExpression"/></returns>
        protected virtual DbExpression VisitJoinExpression(DbJoinExpression joinExpression)
        {
            var conditionExpression = Visit(joinExpression.Condition);
            var targetExpression = Visit(joinExpression.Target);
            if (!ReferenceEquals(conditionExpression,joinExpression.Condition) ||
                !ReferenceEquals(targetExpression,joinExpression.Target))
            {
                return ExpressionFactory.MakeJoin(joinExpression.JoinExpressionType, targetExpression,
                                                  conditionExpression);
            }
            
            return joinExpression;
        }

        /// <summary>
        /// Translates the <paramref name="unaryExpression"/> into a string representation.
        /// </summary>
        /// <param name="unaryExpression">The <see cref="DbUnaryExpression"/> to translate.</param>
        /// <returns><see cref="DbExpression"/></returns>
        protected virtual DbExpression VisitUnaryExpression(DbUnaryExpression unaryExpression)
        {
            var operandExpression = Visit(unaryExpression.Operand);
            if (!ReferenceEquals(operandExpression, unaryExpression.Operand))
                return ExpressionFactory.MakeUnary(unaryExpression.UnaryExpressionType, operandExpression,
                                                   unaryExpression.TargetType);
            return unaryExpression;
        }


        /// <summary>
        /// Translates the <paramref name="orderByExpression"/> into a string representation.
        /// </summary>
        /// <param name="orderByExpression">The <see cref="DbOrderByExpression"/> to translate.</param>
        /// <returns><see cref="DbExpression"/></returns>
        protected virtual DbExpression VisitOrderByExpression(DbOrderByExpression orderByExpression)
        {
            var expression = Visit(orderByExpression.Expression);
            if (!ReferenceEquals(expression,orderByExpression.Expression))
                return ExpressionFactory.MakeOrderBy(orderByExpression.OrderByExpressionType, expression);
            
            return orderByExpression;
        }

     


        /// <summary>
        /// Translates the <paramref name="prefixExpression"/> into a string representation.
        /// </summary>
        /// <param name="prefixExpression">The <see cref="DbPrefixExpression"/> to translate.</param>
        /// <returns><see cref="DbExpression"/></returns>
        protected virtual DbExpression VisitPrefixExpression(DbPrefixExpression prefixExpression)
        {
            var targetExpression = Visit(prefixExpression.Target);
            if (!ReferenceEquals(targetExpression, prefixExpression.Target))
                return ExpressionFactory.Prefix(targetExpression, prefixExpression.Prefix);
            return prefixExpression;
        }

    }

}
