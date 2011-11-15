namespace DbExpressions
{
    /// <summary>
    /// Specifies the type of <see cref="DbAggregateFunctionExpression"/>.
    /// </summary>
    public enum DbAggregateFunctionExpressionType
    {
        /// <summary>
        /// A node that represents returning the number of items in the expression.
        /// </summary>
        Count,

        /// <summary>
        /// Returns the minimum value in the expression. 
        /// </summary>
        Min,

        /// <summary>
        /// Returns the maximum value in the expression. 
        /// </summary>
        Max,

        /// <summary>
        /// A node that represents returning the average of the values in the expression.
        /// </summary>
        Avg,

        /// <summary>
        /// A node that represents returning the sum of all values in the expression.
        /// </summary>
        Sum
    }
}
