namespace DbExpressions
{
    /// <summary>
    /// Represents an 'UPDATE' database query.
    /// </summary>
    public class DbUpdateExpression : DbQueryExpression
    {
        /// <summary>
        /// Gets the <see cref="DbExpressionType"/> of the <see cref="DbExpression"/>.
        /// </summary>
        /// <value></value>
        public override DbExpressionType ExpressionType
        {
            get { return DbExpressionType.Update; }
        }

        /// <summary>
        /// Gets or sets the target <see cref="DbExpression"/> that represents the database table to be updated.
        /// </summary>
        public DbExpression Target { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="DbExpression"/> that represents assigning values 
        /// to columns or variables.
        /// </summary>
        public DbExpression SetExpression { get; set; }
    }
}
