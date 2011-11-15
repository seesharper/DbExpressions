namespace DbExpressions
{    
    /// <summary>
    /// Represents a 'SELECT' database query.
    /// </summary>
    public class DbSelectExpression : DbQueryExpression
    {
        /// <summary>
        /// Gets or sets the <see cref="DbExpression"/> that represents the projection of the query.
        /// </summary>
        public DbExpression ProjectionExpression { get; set; }
        
        /// <summary>
        /// Gets or sets the <see cref="DbExpression"/> that represents the 'GROUP BY' clause of the query.
        /// </summary>
        public DbExpression GroupByExpression { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="DbExpression"/> that represents the 'HAVING' clause of the query.
        /// </summary>
        public DbExpression HavingExpression { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="DbExpression"/> that represents the 'ORDER BY' clause of the query.
        /// </summary>
        public DbExpression OrderByExpression { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="DbExpression"/> that is used to limit the number of rows returned by the query.
        /// </summary>
        public DbExpression TakeExpression { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="DbExpression"/> that is used to bypass a number of rows in the result set.
        /// </summary>
        public DbExpression SkipExpression { get; set; }

        /// <summary>
        /// Gets or sets a <see cref="bool"/> value that indicate if this <see cref="DbSelectExpression"/> should be treated as a sub query.
        /// </summary>
        public bool IsSubQuery { get; set; }

        /// <summary>
        /// Gets or sets a <see cref="bool"/> value that indicate if this <see cref="DbSelectExpression"/> represents a distinct selection of rows.
        /// </summary>
        public bool IsDistinct { get; set; }

        /// <summary>
        /// Gets the <see cref="DbExpressionType"/> of the <see cref="DbExpression"/>.
        /// </summary>
        public override DbExpressionType ExpressionType
        {
            get { return DbExpressionType.Select; }
        }
    }
}
