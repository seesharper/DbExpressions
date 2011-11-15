namespace DbExpressions
{
    /// <summary>
    /// Represents determining if a given value matches any value in a sub query or a list.
    /// </summary>
    public class DbInExpression : DbExpression
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DbInExpression"/> class.
        /// </summary>
        /// <param name="target">The target <see cref="DbExpression"/></param>
        /// <param name="expression">The <see cref="DbExpression"/> that either represents a sub query or a list of values.</param>
        public DbInExpression(DbExpression target, DbExpression expression)
        {
            Target = target;
            Expression = expression;
        }

        /// <summary>
        /// Gets the target <see cref="DbExpression"/>
        /// </summary>
        public DbExpression Target { get; private set; }
        
        /// <summary>
        /// Gets the <see cref="DbExpression"/> that either represents a sub query or a list of values.
        /// </summary>
        public DbExpression Expression { get; private set; }


        /// <summary>
        /// Gets the <see cref="DbExpressionType"/> of the <see cref="DbExpression"/>.
        /// </summary>
        /// <value></value>
        public override DbExpressionType ExpressionType
        {
            get { return DbExpressionType.In; }
        }
    }
}
