using System;
using System.Linq;

namespace DbExpressions
{
    /// <summary>
    /// Provides the fluent interface that targets a 'SELECT' query.
    /// </summary>
    public static class DbSelectQueryExtensions
    {

        private static readonly DbExpressionFactory DbExpressionFactory = new DbExpressionFactory();

        /// <summary>
        /// Specifies the projecton of the query.
        /// </summary>
        /// <param name="dbSelectQuery">The target <see cref="DbSelectQuery"/></param>
        /// <param name="expressionSelector">A <see cref="Func{T,TResult}"/> used to specify the <see cref="DbExpression"/> that represents the projection.</param>
        /// <returns></returns>
        public static DbSelectQuery Select(this DbSelectQuery dbSelectQuery, params Func<DbExpressionFactory, DbExpression>[] expressionSelector)
        {
            return Select(dbSelectQuery, DbExpressionFactory.List(expressionSelector.Select(e => e(DbExpressionFactory))));
        }

        /// <summary>
        /// Specifies the projecton of the query.
        /// </summary>
        /// <param name="dbSelectQuery">The target <see cref="DbSelectQuery"/></param>
        /// <param name="expressionSelector">A <see cref="Func{T,TResult}"/> used to specify the <see cref="DbExpression"/> that represents the projection.</param>
        /// <returns></returns>
        public static DbSelectQuery SelectDistinct(this DbSelectQuery dbSelectQuery, params Func<DbExpressionFactory, DbExpression>[] expressionSelector)
        {
            return SelectDistinct(dbSelectQuery, DbExpressionFactory.List(expressionSelector.Select(e => e(DbExpressionFactory))));
        }

        /// <summary>
        /// Specifies the projection of the query.
        /// </summary>
        /// <param name="dbSelectQuery">The target <see cref="DbSelectQuery"/></param>
        /// <param name="expression">The <see cref="DbExpression"/> that represents the projection.</param>
        /// <returns><see cref="DbSelectQuery"/></returns>
        public static DbSelectQuery Select(this DbSelectQuery dbSelectQuery, DbExpression expression)
        {
            dbSelectQuery.QueryExpression.ProjectionExpression = expression;
            return dbSelectQuery;
        }

        /// <summary>
        /// Specifies the projection of the query.
        /// </summary>
        /// <param name="dbSelectQuery">The target <see cref="DbSelectQuery"/></param>
        /// <param name="expression">The <see cref="DbExpression"/> that represents the projection.</param>
        /// <returns><see cref="DbSelectQuery"/></returns>
        public static DbSelectQuery SelectDistinct(this DbSelectQuery dbSelectQuery, DbExpression expression)
        {
            dbSelectQuery.QueryExpression.ProjectionExpression = expression;
            dbSelectQuery.QueryExpression.IsDistinct = true;
            return dbSelectQuery;
        }



        /// <summary>
        /// Creates a <see cref="DbOrderByExpression"/> that represents ordering the result set.
        /// </summary>        
        /// <param name="dbSelectQuery">The target <see cref="DbQuery{TQueryExpression}"/>.</param>
        /// <param name="expressionSelector">A function used to specify an element in the 'ORDER BY' clause.</param>
        /// <param name="orderByExpressionType">Specifies the sort order direction.</param>
        /// <returns></returns>
        public static DbQuery<DbSelectExpression> OrderBy(this DbQuery<DbSelectExpression> dbSelectQuery, Func<DbExpressionFactory, DbExpression> expressionSelector, DbOrderByExpressionType orderByExpressionType)
        {
            var dbExpression = (DbExpression)DbExpressionFactory.MakeOrderBy(orderByExpressionType, expressionSelector(DbExpressionFactory));
            if (!dbSelectQuery.QueryExpression.OrderByExpression.IsNull())
                dbExpression = DbExpressionFactory.List(new[] { dbSelectQuery.QueryExpression.OrderByExpression, dbExpression });
            dbSelectQuery.QueryExpression.OrderByExpression = dbExpression;
            return dbSelectQuery;
        }

        /// <summary>
        /// Creates a new <see cref="DbOrderByExpression"/> that represents an ascending ordering of the result set.        
        /// </summary>
        /// <param name="dbSelectQuery">The target <see cref="DbQuery{TQueryExpression}"/>.</param>
        /// <param name="expressionSelector">A function used to specify an element in the 'ORDER BY' clause.</param>
        public static DbQuery<DbSelectExpression> OrderByAscending(this DbQuery<DbSelectExpression> dbSelectQuery, Func<DbExpressionFactory, DbExpression> expressionSelector)
        {
            return OrderBy(dbSelectQuery, expressionSelector, DbOrderByExpressionType.Ascending);
        }

        /// <summary>
        /// Creates a new <see cref="DbOrderByExpression"/> that represents an descending ordering of the result set.
        /// </summary>
        /// <param name="dbSelectQuery">The target <see cref="DbQuery{TQueryExpression}"/>.</param>
        /// <param name="expressionSelector">A function used to specify an element in the 'ORDER BY' clause.</param>
        public static DbQuery<DbSelectExpression> OrderByDescending(this DbQuery<DbSelectExpression> dbSelectQuery, Func<DbExpressionFactory, DbExpression> expressionSelector)
        {
            return OrderBy(dbSelectQuery, expressionSelector, DbOrderByExpressionType.Ascending);
        }

        /// <summary>
        /// Limits the numbers of rows returned by the query.
        /// </summary>
        /// <param name="dbSelectQuery">The target <see cref="DbQuery{TQueryExpression}"/>.</param>
        /// <param name="expressionSelector">A function used to create a <see cref="DbExpression"/> that the number of rows to return.</param>
        /// <returns><see cref="DbQuery{TQueryExpression}"/></returns>
        public static DbQuery<DbSelectExpression> Take(this DbQuery<DbSelectExpression> dbSelectQuery, Func<DbExpressionFactory, DbExpression> expressionSelector)
        {
            dbSelectQuery.QueryExpression.TakeExpression = expressionSelector(DbExpressionFactory);
            return dbSelectQuery;
        }

        /// <summary>
        /// Limits the numbers of rows returned by the query.
        /// </summary>
        /// <param name="dbSelectQuery">The target <see cref="DbQuery{TQueryExpression}"/>.</param>
        /// <param name="count">The number of rows to return.</param>
        /// <returns><see cref="DbQuery{TQueryExpression}"/></returns>
        public static DbQuery<DbSelectExpression> Take(this DbQuery<DbSelectExpression> dbSelectQuery, int count)
        {
            dbSelectQuery.QueryExpression.TakeExpression = DbExpressionFactory.Constant(count);
            return dbSelectQuery;

        }

        /// <summary>
        /// Bypasses a specified number of rows in the result set.
        /// </summary>
        /// <param name="dbSelectQuery">The target <see cref="DbQuery{TQueryExpression}"/>.</param>
        /// <param name="expressionSelector">A function used to create a <see cref="DbExpression"/> that the number of rows to bypass.</param>
        /// <returns><see cref="DbQuery{TQueryExpression}"/></returns>
        public static DbQuery<DbSelectExpression> Skip(this DbQuery<DbSelectExpression> dbSelectQuery, Func<DbExpressionFactory, DbExpression> expressionSelector)
        {
            dbSelectQuery.QueryExpression.SkipExpression = expressionSelector(DbExpressionFactory);
            return dbSelectQuery;
        }


        /// <summary>
        /// Bypasses a specified number of rows in the result set.
        /// </summary>
        /// <param name="dbSelectQuery">The target <see cref="DbQuery{TQueryExpression}"/>.</param>
        /// <param name="count">The number of rows to bypass in the result set</param>
        /// <returns><see cref="DbQuery{TQueryExpression}"/></returns>
        public static DbQuery<DbSelectExpression> Skip(this DbQuery<DbSelectExpression> dbSelectQuery, int count)
        {
            dbSelectQuery.QueryExpression.SkipExpression = DbExpressionFactory.Constant(count);
            return dbSelectQuery;
        }

        /// <summary>
        /// Collects data across multiple records and group the results by one or more columns.
        /// </summary>
        /// <param name="dbSelectQuery">The target <see cref="DbQuery{TQueryExpression}"/>.</param>
        /// <param name="expressionSelector">A function used to specify an element in the 'GROUP BY' clause.</param>
        /// <returns><see cref="DbQuery{TQueryExpression}"/></returns>
        public static DbQuery<DbSelectExpression> GroupBy(this DbQuery<DbSelectExpression> dbSelectQuery, Func<DbExpressionFactory, DbExpression> expressionSelector)
        {
            var dbExpression = expressionSelector(DbExpressionFactory);
            if (!dbSelectQuery.QueryExpression.GroupByExpression.IsNull())
                dbExpression = DbExpressionFactory.List(new[] { dbSelectQuery.QueryExpression.GroupByExpression, dbExpression });
            dbSelectQuery.QueryExpression.GroupByExpression = dbExpression;
            return dbSelectQuery;
        }

        /// <summary>
        /// Specifies a search condition for a group or an aggregate.
        /// </summary>
        /// <param name="dbSelectQuery">The target <see cref="DbQuery{TQueryExpression}"/>.</param>
        /// <param name="expressionSelector">A function used to specify the 'HAVING' expression.</param>
        /// <returns></returns>
        public static DbQuery<DbSelectExpression> Having(this DbQuery<DbSelectExpression> dbSelectQuery, Func<DbExpressionFactory, DbExpression> expressionSelector)
        {
            var dbExpression = expressionSelector(DbExpressionFactory);
            if (!dbSelectQuery.QueryExpression.HavingExpression.IsNull())
                dbExpression = DbExpressionFactory.List(new[] { dbSelectQuery.QueryExpression.HavingExpression, dbExpression });
            dbSelectQuery.QueryExpression.HavingExpression = dbExpression;
            return dbSelectQuery;
        }




    }
}
