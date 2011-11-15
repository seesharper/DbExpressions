namespace DbExpressions
{
    /// <summary>
    /// Represents a table reference in the query.
    /// </summary>
    public class DbTableExpression : DbExpression
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="DbTableExpression"/> class.
        /// </summary>
        /// <param name="tableName">The name of the table.</param>
        internal DbTableExpression(string tableName)
        {
            TableName = tableName;
        }

        /// <summary>
        /// Gets the <see cref="DbExpressionType"/> of the <see cref="DbExpression"/>.
        /// </summary>
        /// <value></value>
        public override DbExpressionType ExpressionType
        {
            get { return DbExpressionType.Table; }
        }

        /// <summary>
        /// Gets the name of the table.
        /// </summary>
        public string TableName { get; private set; }

    }
}
