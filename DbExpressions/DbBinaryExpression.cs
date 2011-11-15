namespace DbExpressions
{
    /// <summary>
    /// Represents a <see cref="DbExpression"/> that has a binary operator.
    /// </summary>
    public class DbBinaryExpression : DbExpression
    {        
        /// <summary>
        /// Initializes a new instance of the <see cref="DbBinaryExpression"/> class.
        /// </summary>
        /// <param name="binaryExpressionType">The <see cref="DbBinaryExpressionType"/> that this <see cref="DbBinaryExpression"/> represents.</param>
        /// <param name="leftExpression">The left expression.</param>
        /// <param name="rightExpression">The right expression.</param>
        internal DbBinaryExpression(DbBinaryExpressionType binaryExpressionType, DbExpression leftExpression, DbExpression rightExpression)
        {
            BinaryExpressionType = binaryExpressionType;
            LeftExpression = leftExpression;
            RightExpression = rightExpression;
        }

        /// <summary>
        /// Gets the left operand of the binary operation.
        /// </summary>
        public DbExpression LeftExpression { get; private set; }

        /// <summary>
        /// Gets the right operand of the binary operation.
        /// </summary>
        public DbExpression RightExpression { get; private set; }

        /// <summary>
        /// Gets the <see cref="DbExpressionType"/> of the <see cref="DbExpression"/>.
        /// </summary>
        public override DbExpressionType ExpressionType
        {
            get { return DbExpressionType.Binary; }
        }

        /// <summary>
        /// Gets the <see cref="DbBinaryExpressionType"/> that this <see cref="DbBinaryExpression"/> represents.
        /// </summary>
        public DbBinaryExpressionType BinaryExpressionType { get; private set; }
    }
}
