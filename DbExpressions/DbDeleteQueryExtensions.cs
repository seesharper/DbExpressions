using System;

namespace DbExpressions
{
    /// <summary>
    /// Provides the fluent interface that targets a 'DELETE' query.
    /// </summary>
    public static class DbDeleteQueryExtensions
    {
        private static readonly DbExpressionFactory DbExpressionFactory = new DbExpressionFactory();

        /// <summary>
        /// Creates a <see cref="DbQuery{TQueryExpression}"/> that is used to delete data from the database.
        /// </summary>
        /// <param name="dbDeleteQuery">The target <see cref="DbDeleteQuery"/>.</param>
        /// <param name="targetSelector">A <see cref="Func{T,TResult}"/> used to 
        /// specify the <see cref="DbExpression"/> that represents the target table or view.</param>
        /// <returns>A <see cref="DbDeleteQuery"/> instance.</returns>
        public static DbDeleteQuery Delete(this DbDeleteQuery dbDeleteQuery, Func<DbExpressionFactory, DbExpression> targetSelector)
        {
            return Delete(dbDeleteQuery, targetSelector(DbExpressionFactory));
        }

        /// <summary>
        /// Creates a <see cref="DbQuery{TQueryExpression}"/> that is used to delete data from the database.
        /// </summary>
        /// <param name="dbDeleteQuery">The target <see cref="DbDeleteQuery"/>.</param>
        /// <param name="target">The <see cref="DbExpression"/> that represents the target table or view.</param>
        /// <returns>A <see cref="DbDeleteQuery"/> instance.</returns>
        public static DbDeleteQuery Delete(this DbDeleteQuery dbDeleteQuery, DbExpression target)
        {
            dbDeleteQuery.QueryExpression.Target = target;
            return dbDeleteQuery;
        }
    }
}
