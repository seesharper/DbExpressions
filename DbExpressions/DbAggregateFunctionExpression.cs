namespace DbExpressions
{
    /// <summary>
    /// Represents calling an aggregate function in the target DBMS.
    /// </summary>
    public class DbAggregateFunctionExpression : DbFunctionExpression
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DbAggregateFunctionExpression"/> class.
        /// </summary>
        /// <param name="aggregateFunctionExpressionType">The <see cref="DbAggregateFunctionExpressionType"/> of the <see cref="DbAggregateFunctionExpression"/>.</param>
        /// <param name="arguments">The arguments used when calling the function.</param>
        internal DbAggregateFunctionExpression(DbAggregateFunctionExpressionType aggregateFunctionExpressionType, DbExpression[] arguments) 
            : base(DbFunctionExpressionType.Aggregate, arguments)
        {
            AggregateFunctionExpressionType = aggregateFunctionExpressionType;
        }

        /// <summary>
        /// Gets the <see cref="DbAggregateFunctionExpressionType"/> for this <see cref="DbAggregateFunctionExpression"/>.
        /// </summary>
        public DbAggregateFunctionExpressionType AggregateFunctionExpressionType { get; private set; }
    }
}
