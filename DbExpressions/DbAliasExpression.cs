namespace DbExpressions
{
    /// <summary>
    /// Represents an aliased <see cref="DbExpression"/> 
    /// </summary>
    public class DbAliasExpression : DbExpression
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DbAliasExpression"/> class.
        /// </summary>
        /// <param name="target">The target <see cref="DbExpression"/> to be aliased.</param>
        /// <param name="alias">the alias to be used to reference the <paramref name="target"/></param>
        internal DbAliasExpression(DbExpression target, string alias)
        {
            Target = target;
            Alias = alias;
        }

        /// <summary>
        /// Gets the target <see cref="DbExpression"/> to be aliased.
        /// </summary>
        public DbExpression Target { get; private set; }

        /// <summary>
        /// Gets the alias to be used to reference the <see cref="Target"/>
        /// </summary>
        public string Alias { get; private set; }

        /// <summary>
        /// Gets the <see cref="DbExpressionType"/> of the <see cref="DbExpression"/>.
        /// </summary>
        /// <value></value>
        public override DbExpressionType ExpressionType
        {
            get { return DbExpressionType.Alias; }
        }
    }
}
