using System;
using System.Linq;

namespace DbExpressions
{
    /// <summary>
    /// Provides the fluent interface that targets an 'INSERT' query.
    /// </summary>
    public static class DbInsertQueryExtensions
    {
        
        private static readonly DbExpressionFactory DbExpressionFactory = new DbExpressionFactory();

        /// <summary>
        /// Creates a <see cref="DbQuery{TQueryExpression}"/> that is used to insert data into the database.
        /// </summary>
        /// <param name="dbInsertQuery">The target <see cref="DbInsertQuery"/></param>
        /// <param name="targetSelector">A <see cref="Func{T,TResult}"/> used to 
        /// specify the <see cref="DbExpression"/> that represents the target table or view.</param>
        /// <returns><see cref="DbQuery{TQueryExpression}"/></returns>
        public static DbInsertQuery Insert(this DbInsertQuery dbInsertQuery, Func<DbExpressionFactory, DbExpression> targetSelector)
        {
            return Insert(dbInsertQuery, targetSelector(DbExpressionFactory));
        }


        /// <summary>
        /// Creates a <see cref="DbQuery{TQueryExpression}"/> that is used to insert data into the database.
        /// </summary>
        /// <param name="dbInsertQuery">The target <see cref="DbInsertQuery"/></param>
        /// <param name="target">The <see cref="DbExpression"/> that represents the target table or view.</param>
        /// <returns><see cref="DbQuery{TQueryExpression}"/></returns>
        public static DbInsertQuery Insert(this DbInsertQuery dbInsertQuery,DbExpression target)
        {
            dbInsertQuery.QueryExpression.Target = target;            
            return dbInsertQuery;
        }        

        /// <summary>
        /// Specifies the target columns.
        /// </summary>
        /// <param name="dbInsertQuery">The target <see cref="DbQuery{TQueryExpression}"/>.</param>
        /// <param name="columnSelector">A function used to specify the target columns.</param>
        /// <returns><see cref="DbQuery{TQueryExpression}"/></returns>
        public static DbQuery<DbInsertExpression> Columns(this DbQuery<DbInsertExpression> dbInsertQuery,params Func<DbExpressionFactory, DbExpression>[] columnSelector)
        {
            return Columns(dbInsertQuery,DbExpressionFactory.List(columnSelector.Select(e => e(DbExpressionFactory))));
        }

        /// <summary>
        /// Specifies the target columns.
        /// </summary>
        /// <param name="dbInsertQuery">The target <see cref="DbQuery{TQueryExpression}"/>.</param>
        /// <param name="columnsExpression">The <see cref="DbExpression"/> that represents the target columns.</param>
        /// <returns><see cref="DbQuery{TQueryExpression}"/></returns>
        public static DbQuery<DbInsertExpression> Columns(this DbQuery<DbInsertExpression> dbInsertQuery, DbExpression columnsExpression)
        {
            dbInsertQuery.QueryExpression.TargetColumns = columnsExpression;
            return dbInsertQuery;
        }

        /// <summary>
        /// Specifies the values to be inserted.
        /// </summary>
        /// <param name="dbInsertQuery">The target <see cref="DbQuery{TQueryExpression}"/>.</param>
        /// <param name="valueSelector">A <see cref="Func{T,TResult}"/> used to specify the values to be inserted.</param>
        /// <returns><see cref="DbQuery{TQueryExpression}"/></returns>
        public static DbQuery<DbInsertExpression> Values(this DbQuery<DbInsertExpression> dbInsertQuery, params Func<DbExpressionFactory, DbExpression>[] valueSelector)
        {
            return Values(dbInsertQuery, DbExpressionFactory.List(valueSelector.Select(e => e(DbExpressionFactory))));
        }

        /// <summary>
        /// Specifies the values to be inserted.
        /// </summary>
        /// <param name="dbInsertQuery">The target <see cref="DbQuery{TQueryExpression}"/>.</param>
        /// <param name="valuesExpression">The <see cref="DbExpression"/> that represents the values to be inserted.</param>
        /// <returns><see cref="DbQuery{TQueryExpression}"/></returns>
        public static DbQuery<DbInsertExpression> Values(this DbQuery<DbInsertExpression> dbInsertQuery, DbExpression valuesExpression)
        {
            dbInsertQuery.QueryExpression.Values = valuesExpression;
            return dbInsertQuery;
        }        

    }
}
