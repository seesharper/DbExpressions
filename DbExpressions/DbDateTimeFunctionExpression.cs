namespace DbExpressions
{
    /// <summary>
    /// Represents calling a built in date/time function in the target DBMS.
    /// </summary>
    public class DbDateTimeFunctionExpression : DbFunctionExpression
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DbDateTimeFunctionExpression"/> class.
        /// </summary>
        /// <param name="dateTimeFunctionExpressionType">The <see cref="DbDateTimeFunctionExpressionType"/> of the <see cref="DbDateTimeFunctionExpression"/>.</param>
        /// <param name="arguments">The arguments used when calling the function.</param>
        internal DbDateTimeFunctionExpression(DbDateTimeFunctionExpressionType dateTimeFunctionExpressionType, DbExpression[] arguments)
            : base(DbFunctionExpressionType.DateTime, arguments)
        {
            DateTimeFunctionExpressionType = dateTimeFunctionExpressionType;
        }

        /// <summary>
        /// Gets the <see cref="DbDateTimeFunctionExpressionType"/> for this <see cref="DbDateTimeFunctionExpression"/>.
        /// </summary>
        public DbDateTimeFunctionExpressionType DateTimeFunctionExpressionType { get; private set; }
    }
}
