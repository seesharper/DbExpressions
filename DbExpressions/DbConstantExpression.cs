namespace DbExpressions
{
    /// <summary>
    /// Represents a <see cref="DbExpression"/> that has a constant value.
    /// </summary>
    public class DbConstantExpression : DbExpression
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DbConstantExpression"/> class.
        /// </summary>
        /// <param name="value">The value of the constant expression.</param>
        internal DbConstantExpression(object value)            
        {
            Value = value;
        }

        /// <summary>
        /// Gets the value of the constant expression.
        /// </summary>
        public object Value { get; private set; }

        /// <summary>
        /// Gets the <see cref="DbExpressionType"/> of the <see cref="DbExpression"/>.
        /// </summary>
        public override DbExpressionType ExpressionType
        {
            get { return DbExpressionType.Constant; }
        }
    }
}
