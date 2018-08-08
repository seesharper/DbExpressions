namespace DbExpressions
{
    /// <summary>
    /// Represents a subquery to test for existence of rows.
    /// </summary>
    public class DbExistsExpression : DbExpression
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DbExistsExpression"/> class.
        /// </summary>
        /// <param name="subSelectExpression">The <see cref="DbSelectExpression"/> that is used as the sub query.</param>
        internal DbExistsExpression(DbSelectExpression subSelectExpression)
        {
            SubSelectExpression = subSelectExpression;
        }

        /// <summary>
        /// Gets the <see cref="DbSelectExpression"/> that is used as the sub query.
        /// </summary>
        public DbSelectExpression SubSelectExpression { get; private set; }
                
        /// <summary>
        /// Gets the <see cref="DbExpressionType"/> of the <see cref="DbExpression"/>.
        /// </summary>
        /// <value></value>
        public override DbExpressionType ExpressionType
        {
            get { return DbExpressionType.Exists; }
        }
    }
}
