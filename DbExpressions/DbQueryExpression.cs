namespace DbExpressions
{
    /// <summary>
    /// Provides the base class from which the classes that represents database queries are derived.
    /// </summary>
    public abstract class DbQueryExpression : DbExpression
    {
        /// <summary>
        /// Gets or sets the <see cref="DbExpression"/> that represents the 'FROM' clause of the query.
        /// </summary>
        public DbExpression FromExpression { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="DbExpression"/> that represents the 'WHERE' clause of the query.
        /// </summary>
        public DbExpression WhereExpression { get; set; }
              
    }
}
    