namespace DbExpressions
{
    /// <summary>
    /// Represents a column reference in the query.
    /// </summary>
    public class DbColumnExpression : DbExpression
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DbColumnExpression"/> class.
        /// </summary>
        /// <param name="columnName">The name of the column.</param>
        internal DbColumnExpression(string columnName)
        {
            ColumnName = columnName;
        }

        /// <summary>
        /// Gets the <see cref="DbExpressionType"/> of the <see cref="DbExpression"/>.
        /// </summary>
        public override DbExpressionType ExpressionType
        {
            get { return DbExpressionType.Column; }
        }

        /// <summary>
        /// Gets the name of the column.
        /// </summary>        
        public string ColumnName { get; private set; }
    }
}
