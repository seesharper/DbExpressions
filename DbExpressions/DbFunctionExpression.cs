namespace DbExpressions
{
    /// <summary>
    /// Represents calling a built in function in the target DBMS.
    /// </summary>
    public class DbFunctionExpression : DbExpression
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DbFunctionExpression"/> class.
        /// </summary>        
        /// <param name="functionExpressionType">The <see cref="DbFunctionExpressionType"/> of the <see cref="DbFunctionExpression"/>.</param>        
        /// <param name="arguments">The arguments used when calling the function.</param>
        internal DbFunctionExpression(DbFunctionExpressionType functionExpressionType, DbExpression[] arguments)
        {
            FunctionExpressionType = functionExpressionType;       
            Arguments = arguments;                        
        }

        /// <summary>
        /// Gets the <see cref="DbFunctionExpressionType"/> for this <see cref="DbFunctionExpression"/>.
        /// </summary>
        public DbFunctionExpressionType FunctionExpressionType { get; private set; }
        
        /// <summary>
        /// Gets the arguments used to execute the method.
        /// </summary>        
        public DbExpression[] Arguments { get; private set; }

        /// <summary>
        /// Gets the <see cref="DbExpressionType"/> of the <see cref="DbExpression"/>.
        /// </summary>
        public override DbExpressionType ExpressionType
        {
            get { return DbExpressionType.Function; }
        }
    }
}
