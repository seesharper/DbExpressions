namespace DbExpressions
{
    /// <summary>
    /// Represents calling a built in string function in the target DBMS.
    /// </summary>
    public class DbStringFunctionExpression : DbFunctionExpression
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="DbStringFunctionExpression"/> class.
        /// </summary>
        /// <param name="stringFunctionExpressionType">The <see cref="DbStringFunctionExpressionType"/> of the <see cref="DbStringFunctionExpression"/>.</param>
        /// <param name="arguments">The arguments used when calling the function.</param>
        internal DbStringFunctionExpression(DbStringFunctionExpressionType stringFunctionExpressionType, DbExpression[] arguments) : base(DbFunctionExpressionType.String, arguments)
        {
            StringFunctionExpressionType = stringFunctionExpressionType;
        }

        /// <summary>
        /// Gets the <see cref="DbStringFunctionExpressionType"/> for this <see cref="DbStringFunctionExpression"/>.
        /// </summary>
        public DbStringFunctionExpressionType StringFunctionExpressionType { get; private set; }
    }
}
