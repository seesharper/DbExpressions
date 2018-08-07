namespace DbExpressions
{
    /// <summary>
    /// Represents a concatenate operation between two <see cref="DbExpression"/> instances.
    /// </summary>
    public class DbConcatExpression : DbExpression
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DbConcatExpression"/> class.
        /// </summary>
        internal DbConcatExpression()
        {
        }

        /// <summary>
        /// Gets the left operand of the concatenate operation.
        /// </summary>
        public DbExpression LeftExpression { get; internal set; }

        /// <summary>
        /// Gets the right operand of the concatenate operation.
        /// </summary>
        public DbExpression RightExpression { get; internal set; }
            
        /// <summary>
        /// Gets the <see cref="DbExpressionType"/> of the <see cref="DbExpression"/>.
        /// </summary>
        /// <value></value>
        public override DbExpressionType ExpressionType
        {
            get { return DbExpressionType.Concat; }
        }
    }
}
