namespace DbExpressions
{
    /// <summary>
    /// Represents calling a built in mathematical function in the target DBMS.
    /// </summary>
    public class DbMathematicalFunctionExpression : DbFunctionExpression
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DbMathematicalFunctionExpression"/> class.
        /// </summary>
        /// <param name="mathematicalFunctionExpressionType">The <see cref="DbMathematicalFunctionExpressionType"/> of the <see cref="DbMathematicalFunctionExpression"/>.</param>
        /// <param name="arguments">The arguments used when calling the function.</param>
        internal DbMathematicalFunctionExpression(DbMathematicalFunctionExpressionType mathematicalFunctionExpressionType, DbExpression[] arguments) 
            : base(DbFunctionExpressionType.Mathematical, arguments)
        {
            MathematicalFunctionExpressionType = mathematicalFunctionExpressionType;
        }

        /// <summary>
        /// Gets the <see cref="DbMathematicalFunctionExpressionType"/> for this <see cref="DbMathematicalFunctionExpression"/>.
        /// </summary>
        public DbMathematicalFunctionExpressionType MathematicalFunctionExpressionType { get; private set; }
    }
}
