namespace DbExpressions
{
    /// <summary>
    /// Represents a 'DELETE' database query.
    /// </summary>
    public class DbDeleteExpression : DbQueryExpression
    {
        /// <summary>
        /// Gets the <see cref="DbExpressionType"/> of the <see cref="DbExpression"/>.
        /// </summary>
        /// <value></value>
        public override DbExpressionType ExpressionType
        {
            get { return DbExpressionType.Delete; }
        }

        /// <summary>
        /// Gets or sets the target <see cref="DbExpression"/> that represents the database table to delete from.
        /// </summary>
        public DbExpression Target { get; set; }
    }
}
