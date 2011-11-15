namespace DbExpressions
{
    /// <summary>
    /// Represents a <see cref="DbExpression"/> that has a conditional operator.
    /// </summary>
    public class DbConditionalExpression : DbExpression
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DbConditionalExpression"/> class.
        /// </summary>
        internal DbConditionalExpression()
        {            
        }
        
        /// <summary>
        /// Gets the <see cref="DbExpression"/> that is executed if the <see cref="Condition"/> evaluates to <b>true</b>.
        /// </summary>
        public DbExpression IfTrue { get; internal set; }

        /// <summary>
        /// Gets the <see cref="DbExpression"/> that is executed if the <see cref="Condition"/> evaluates to <b>false</b>.
        /// </summary>
        public DbExpression IfFalse { get; internal set; }

        /// <summary>
        /// Gets the <see cref="DbExpression"/> that is evaluated. 
        /// </summary>
        public DbExpression Condition { get; internal set; }

        /// <summary>
        /// Gets the <see cref="DbExpressionType"/> of the <see cref="DbExpression"/>.
        /// </summary>
        /// <value></value>
        public override DbExpressionType ExpressionType
        {
            get { return DbExpressionType.Conditional; }
        }
    }
}
