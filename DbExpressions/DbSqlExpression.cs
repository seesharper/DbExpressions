namespace DbExpressions
{
    /// <summary>
    /// Represents the SQL fragment created when translating a <see cref="DbExpression"/>
    /// </summary>
    public class DbSqlExpression : DbExpression
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DbSqlExpression"/> class.
        /// </summary>
        /// <param name="sql">The SQL.</param>
        public DbSqlExpression(string sql)
        {
            Sql = sql;
        }

        /// <summary>
        /// Gets the <see cref="DbExpressionType"/> of the <see cref="DbExpression"/>.
        /// </summary>
        /// <value></value>
        public override DbExpressionType ExpressionType
        {
            get { return DbExpressionType.Sql; }
        }
        
        /// <summary>
        /// Gets the SQL that this <see cref="DbSqlExpression"/> represents.
        /// </summary>
        public string Sql { get; private set; }


        /// <summary>
        /// Returns a <see cref="System.String"/> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String"/> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return Sql;
        }
    }
}
