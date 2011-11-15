using System;

namespace DbExpressions
{
    /// <summary>
    /// Represents the fluent interface that applies to all query types (SELECT,INSERT, UPDATE AND DELETE)
    /// </summary>
    public static class DbQueryExtensions
    {
        
        private static readonly DbExpressionFactory DbExpressionFactory = new DbExpressionFactory();


        /// <summary>
        /// Specifies the tables, views, derived tables, and joined tables used in DELETE, SELECT, and UPDATE statements.
        /// </summary>
        /// <param name="query">The target <see cref="DbQuery{TQueryExpression}"/></param>
        /// <param name="expressionSelector">A <see cref="Func{T,TResult}"/> to specify the <see cref="DbExpression"/>.</param>
        /// <returns><see cref="DbQuery{TQueryExpression}"/></returns>
        public static DbQuery<TQueryExpression> From<TQueryExpression>(this DbQuery<TQueryExpression> query, Func<DbExpressionFactory, DbExpression> expressionSelector)
        where TQueryExpression : DbQueryExpression, new()
        {
            return From(query,expressionSelector(DbExpressionFactory));
        }

        /// <summary>
        /// Specifies the tables, views, derived tables, and joined tables used in DELETE, SELECT, and UPDATE statements.
        /// </summary>
        /// <param name="query">The target <see cref="DbQuery{TQueryExpression}"/></param>
        /// <param name="expression">A <see cref="DbExpression"/> that represents the from clause.</param>
        /// <returns><see cref="DbQuery{TQueryExpression}"/></returns>
        public static DbQuery<TQueryExpression> From<TQueryExpression>(this DbQuery<TQueryExpression> query, DbExpression expression)
            where TQueryExpression : DbQueryExpression, new()
        {
            var dbExpression = expression;
            if (!query.QueryExpression.FromExpression.IsNull())
                if (dbExpression.ExpressionType == DbExpressionType.Join)
                    dbExpression = DbExpressionFactory.Concat(query.QueryExpression.FromExpression, dbExpression);
                else
                    dbExpression = DbExpressionFactory.List(new[] {query.QueryExpression.FromExpression, expression });
            query.QueryExpression.FromExpression = dbExpression;
            return query;
        }


        /// <summary>
        /// Creates a <see cref="DbJoinExpression"/> between the current 'FROM' clause and the expression returned by the <paramref name="target"/> functor.
        /// </summary>
        /// <param name="joinExpressionType">Specifies the type of join expression.</param>
        /// <param name="query">The target <see cref="DbQuery{TQueryExpression}"/></param>
        /// <param name="target">The target join expression.</param>
        /// <param name="condition">A <see cref="DbExpression"/> that specifies the join condition.</param>
        /// <returns><see cref="DbQuery{TQueryExpression}"/></returns>
        public static DbQuery<TQueryExpression> Join<TQueryExpression>(this DbQuery<TQueryExpression> query, 
            DbJoinExpressionType joinExpressionType, Func<DbExpressionFactory, DbExpression> target, 
            Func<DbExpressionFactory, DbExpression> condition) where TQueryExpression : DbQueryExpression, new()
        {
            return Join(query,joinExpressionType, target(DbExpressionFactory), condition(DbExpressionFactory));            
        }

        /// <summary>
        /// Creates a <see cref="DbJoinExpression"/> between the current 'FROM' clause and the expression returned by the <paramref name="target"/> functor.
        /// </summary>
        /// <param name="joinExpressionType">Specifies the type of join expression.</param>
        /// <param name="query">The target <see cref="DbQuery{TQueryExpression}"/></param>
        /// <param name="target">The target join expression.</param>
        /// <param name="condition">A <see cref="DbExpression"/> that specifies the join condition.</param>
        /// <returns><see cref="DbQuery{TQueryExpression}"/></returns>
        public static DbQuery<TQueryExpression> Join<TQueryExpression>(this DbQuery<TQueryExpression> query,
            DbJoinExpressionType joinExpressionType, DbExpression target,
            DbExpression condition) where TQueryExpression : DbQueryExpression, new()
        {
            
            var dbExpression = (DbExpression)DbExpressionFactory.MakeJoin(joinExpressionType, target, condition);
            if (!query.QueryExpression.FromExpression.IsNull())
                dbExpression = DbExpressionFactory.Concat(query.QueryExpression.FromExpression, dbExpression);
            query.QueryExpression.FromExpression = dbExpression;
            return query;
        }


        /// <summary>
        /// Creates an 'INNER JOIN' between the current 'FROM' clause and the expression returned by the <paramref name="target"/> functor.
        /// </summary>
        /// <param name="query">The target <see cref="DbQuery{TQueryExpression}"/></param>
        /// <param name="target">The target join expression.</param>
        /// <param name="condition">A <see cref="DbExpression"/> that specifies the join condition.</param>
        /// <returns><see cref="DbQuery{TQueryExpression}"/></returns>
        public static DbQuery<TQueryExpression> InnerJoin<TQueryExpression>(this DbQuery<TQueryExpression> query,
            Func<DbExpressionFactory, DbExpression> target, Func<DbExpressionFactory, DbExpression> condition)
            where TQueryExpression : DbQueryExpression, new()
        {
            return Join(query,DbJoinExpressionType.InnerJoin, target, condition);
        }

        /// <summary>
        /// Creates an 'INNER JOIN' between the current 'FROM' clause and the expression returned by the <paramref name="target"/> functor.
        /// </summary>
        /// <param name="query">The target <see cref="DbQuery{TQueryExpression}"/></param>
        /// <param name="target">The target join expression.</param>
        /// <param name="condition">A <see cref="DbExpression"/> that specifies the join condition.</param>
        /// <returns><see cref="DbQuery{TQueryExpression}"/></returns>
        public static DbQuery<TQueryExpression> InnerJoin<TQueryExpression>(this DbQuery<TQueryExpression> query,
            DbExpression target, DbExpression condition)
            where TQueryExpression : DbQueryExpression, new()
        {
            return Join(query, DbJoinExpressionType.InnerJoin, target, condition);
        }

        /// <summary>
        /// Creates an 'LEFT OUTER JOIN' between the current 'FROM' clause and the expression returned by the <paramref name="target"/> functor.
        /// </summary>
        /// <param name="query">The target <see cref="DbQuery{TQueryExpression}"/></param>
        /// <param name="target">The target join expression.</param>
        /// <param name="condition">A <see cref="DbExpression"/> that specifies the join condition.</param>
        /// <returns><see cref="DbQuery{TQueryExpression}"/></returns>
        public static DbQuery<TQueryExpression> LeftOuterJoin<TQueryExpression>(this DbQuery<TQueryExpression> query, 
            Func<DbExpressionFactory, DbExpression> target, Func<DbExpressionFactory, DbExpression> condition)
            where TQueryExpression : DbQueryExpression, new()
        {
            return Join(query,DbJoinExpressionType.LeftOuterJoin, target, condition);
        }

        /// <summary>
        /// Creates an 'LEFT OUTER JOIN' between the current 'FROM' clause and the expression returned by the <paramref name="target"/> functor.
        /// </summary>
        /// <param name="query">The target <see cref="DbQuery{TQueryExpression}"/></param>
        /// <param name="target">The target join expression.</param>
        /// <param name="condition">A <see cref="DbExpression"/> that specifies the join condition.</param>
        /// <returns><see cref="DbQuery{TQueryExpression}"/></returns>
        public static DbQuery<TQueryExpression> LeftOuterJoin<TQueryExpression>(this DbQuery<TQueryExpression> query,
            DbExpression target, DbExpression condition)
            where TQueryExpression : DbQueryExpression, new()
        {
            return Join(query, DbJoinExpressionType.LeftOuterJoin, target, condition);
        }

        /// <summary>
        /// Creates an 'RIGHT OUTER JOIN' between the current 'FROM' clause and the expression returned by the <paramref name="target"/> functor.
        /// </summary>
        /// <param name="query">The target <see cref="DbQuery{TQueryExpression}"/></param>
        /// <param name="target">The target join expression.</param>
        /// <param name="condition">A <see cref="DbExpression"/> that specifies the join condition.</param>
        /// <returns><see cref="DbQuery{TQueryExpression}"/></returns>
        public static DbQuery<TQueryExpression> RightOuterJoin<TQueryExpression>(this DbQuery<TQueryExpression> query, 
            Func<DbExpressionFactory, DbExpression> target, Func<DbExpressionFactory, DbExpression> condition)
            where TQueryExpression : DbQueryExpression, new()
        {
            return Join(query,DbJoinExpressionType.RightOuterJoin, target, condition);
        }


        /// <summary>
        /// Creates an 'RIGHT OUTER JOIN' between the current 'FROM' clause and the expression returned by the <paramref name="target"/> functor.
        /// </summary>
        /// <param name="query">The target <see cref="DbQuery{TQueryExpression}"/></param>
        /// <param name="target">The target join expression.</param>
        /// <param name="condition">A <see cref="DbExpression"/> that specifies the join condition.</param>
        /// <returns><see cref="DbQuery{TQueryExpression}"/></returns>
        public static DbQuery<TQueryExpression> RightOuterJoin<TQueryExpression>(this DbQuery<TQueryExpression> query,
            DbExpression target, DbExpression condition)
            where TQueryExpression : DbQueryExpression, new()
        {
            return Join(query, DbJoinExpressionType.RightOuterJoin, target, condition);
        }

        /// <summary>
        /// Specifies the search condition for the rows returned by the query.
        /// </summary>
        /// <param name="query">The target <see cref="DbQuery{TQueryExpression}"/></param>
        /// <param name="expressionSelector">A <see cref="Func{T,TResult}"/> to specify the <see cref="DbExpression"/>.</param>
        /// <returns><see cref="DbQuery{TQueryExpression}"/></returns>
        public static DbQuery<TQueryExpression> Where<TQueryExpression>(this DbQuery<TQueryExpression> query,
            Func<DbExpressionFactory, DbExpression> expressionSelector)
            where TQueryExpression : DbQueryExpression, new()
        {
            return Where(query,expressionSelector(DbExpressionFactory));
        }

        /// <summary>
        /// Specifies the search condition for the rows returned by the query.
        /// </summary>
        /// <param name="query">The target <see cref="DbQuery{TQueryExpression}"/></param>
        /// <param name="dbExpression">The <see cref="DbExpression"/> that makes up the search condition.</param>
        /// <returns></returns>
        public static DbQuery<TQueryExpression> Where<TQueryExpression>(this DbQuery<TQueryExpression> query,DbExpression dbExpression)
            where TQueryExpression : DbQueryExpression, new()
        {
            if (!query.QueryExpression.WhereExpression.IsNull())
                dbExpression = DbExpressionFactory.And(query.QueryExpression.WhereExpression, dbExpression);
            query.QueryExpression.WhereExpression = dbExpression;
            return query;
        }

        
    }
}
