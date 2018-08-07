namespace DbExpressions
{
    /// <summary>
    /// Represents an element in the 'ORDER BY' clause of the query.
    /// </summary>
    public class DbOrderByExpression : DbExpression
    {                
        /// <summary>
        /// Gets or sets the <see cref="DbExpression"/> that represents an element in the 'ORDER BY' clause.
        /// </summary>
        public DbExpression Expression { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="DbOrderByExpressionType"/> that specifies the sort order 
        /// used by this <see cref="DbOrderByExpression"/>.
        /// </summary>
        public DbOrderByExpressionType OrderByExpressionType { get; set; }

        /// <summary>
        /// Gets the <see cref="DbExpressionType"/> of the <see cref="DbExpression"/>.
        /// </summary>
        public override DbExpressionType ExpressionType
        {
            get { return DbExpressionType.OrderBy; }
        }
    }
}
