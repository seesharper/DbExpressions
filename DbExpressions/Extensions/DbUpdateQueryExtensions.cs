using System;

namespace DbExpressions
{
    /// <summary>
    /// Provides the fluent interface that targets an 'UPDATE' query.
    /// </summary>
    public static class DbUpdateQueryExtensions
    {
        
        private static readonly DbExpressionFactory DbExpressionFactory = new DbExpressionFactory();
        

        /// <summary>
        /// Specifies the target table to update.
        /// </summary>
        /// <param name="dbUpdateQuery">The target <see cref="DbUpdateQuery"/></param>
        /// <param name="target">The <see cref="DbExpression"/> that represents the target table or view.</param>
        /// <returns><see cref="DbUpdateQuery"/></returns>
        public static DbUpdateQuery Update(this DbUpdateQuery dbUpdateQuery, DbExpression target)
        {
            dbUpdateQuery.QueryExpression.Target = target;
            return dbUpdateQuery;
        }

        /// <summary>
        /// Specifies the target table to update.
        /// </summary>
        /// <param name="dbUpdateQuery">The target <see cref="DbUpdateQuery"/></param>
        /// <param name="targetSelector">A <see cref="Func{T,TResult}"/> used to 
        /// specify the <see cref="DbExpression"/> that represents the target table or view.</param>
        /// <returns><see cref="DbUpdateQuery"/></returns>
        public static DbUpdateQuery Update(this DbUpdateQuery dbUpdateQuery, Func<DbExpressionFactory, DbExpression> targetSelector)
        {
            return Update(dbUpdateQuery, targetSelector(DbExpressionFactory));    
        }

        /// <summary>
        /// Specifies the column to be updated.
        /// </summary>
        /// <param name="dbUpdateQuery">The target <see cref="DbQuery{TQueryExpression}"/>.</param>
        /// <param name="columnSelector">A function used to specify the column to be updated.</param>
        /// <param name="valueSelector">A function used to specify the new value.</param>
        /// <returns><see cref="DbQuery{TQueryExpression}"/></returns>
        public static DbQuery<DbUpdateExpression> Set(this DbQuery<DbUpdateExpression> dbUpdateQuery,
            Func<DbExpressionFactory, DbExpression> columnSelector, Func<DbExpressionFactory, DbExpression> valueSelector)
        {
            return Set(dbUpdateQuery,columnSelector(DbExpressionFactory), valueSelector(DbExpressionFactory));
        }

        /// <summary>
        /// Specifies the column to be updated.
        /// </summary>
        /// <param name="dbUpdateQuery">The target <see cref="DbQuery{TQueryExpression}"/>.</param>
        /// <param name="columnSelector">A function used to specify the column to be updated.</param>
        /// <param name="value">The new value.</param>
        /// <returns><see cref="DbQuery{TQueryExpression}"/></returns>
        public static DbQuery<DbUpdateExpression> Set(this DbQuery<DbUpdateExpression> dbUpdateQuery, Func<DbExpressionFactory, DbExpression> columnSelector, object value)
        {
            return Set(dbUpdateQuery,columnSelector(DbExpressionFactory), DbExpressionFactory.Constant(value));
        }

        /// <summary>
        /// Specifies the column to be updated.
        /// </summary>
        /// <param name="dbUpdateQuery">The target <see cref="DbQuery{TQueryExpression}"/>.</param>
        /// <param name="target">The <see cref="DbExpression"/> that represents the target table or view.</param>
        /// <param name="valueExpression">The <see cref="DbExpression"/> that represents the new value.</param>
        /// <returns><see cref="DbQuery{TQueryExpression}"/></returns>
        public static DbQuery<DbUpdateExpression> Set(this DbQuery<DbUpdateExpression> dbUpdateQuery, DbExpression target, DbExpression valueExpression)
        {
            var dbExpression = (DbExpression)DbExpressionFactory.Assign(target, valueExpression);
            if (!dbUpdateQuery.QueryExpression.SetExpression.IsNull())
                dbExpression = DbExpressionFactory.List(new[] { dbUpdateQuery.QueryExpression.SetExpression, dbExpression });
            dbUpdateQuery.QueryExpression.SetExpression = dbExpression;
            return dbUpdateQuery;
        }


    }
}
