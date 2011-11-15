namespace DbExpressions
{
    /// <summary>
    /// Represents the 'GROUP BY' clause of the query.
    /// </summary>
    public class DbGroupByExpression : DbExpression
    {
        
        /// <summary>
        /// Initializes a new instance of the <see cref="DbGroupByExpression"/> class.
        /// </summary>
        internal DbGroupByExpression() {}        

        /// <summary>
        /// Gets the target <see cref="DbExpression"/> used to create the group.
        /// </summary>
        public DbExpression TargetExpression { get; internal set; }

        /// <summary>
        /// Gets the <see cref="DbExpression"/> that represents a search condition for a group.
        /// </summary>
        public DbExpression HavingExpression { get; internal set; }

        /// <summary>
        /// Gets the <see cref="DbExpressionType"/> of the <see cref="DbExpression"/>.
        /// </summary>
        public override DbExpressionType ExpressionType
        {
            get { return DbExpressionType.GroupBy; }
        }
    }
}
