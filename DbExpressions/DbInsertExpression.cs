namespace DbExpressions
{
    /// <summary>
    /// Represents an 'INSERT' database query.
    /// </summary>
    public class DbInsertExpression : DbQueryExpression
    {
        /// <summary>
        /// Gets the <see cref="DbExpressionType"/> of the <see cref="DbExpression"/>.
        /// </summary>
        /// <value></value>
        public override DbExpressionType ExpressionType
        {
            get { return DbExpressionType.Insert; }
        }

        /// <summary>
        /// Gets or sets the target <see cref="DbExpression"/> that represents the database table to insert into.
        /// </summary>
        public DbExpression Target { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="DbExpression"/> that represents the target columns for the insert statement.
        /// </summary>
        public DbExpression TargetColumns { get; set; }


        /// <summary>
        /// Gets or sets the <see cref="DbExpression"/> that represents a value or a list of values to be inserted.
        /// </summary>
        public DbExpression Values { get; set; }

    }
}
