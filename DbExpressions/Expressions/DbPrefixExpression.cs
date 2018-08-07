namespace DbExpressions
{
    /// <summary>
    /// Represents a prefixed <see cref="DbExpression"/> 
    /// </summary>
    public class DbPrefixExpression : DbExpression
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="DbPrefixExpression"/> class.
        /// </summary>
        /// <param name="target">The target.</param>
        /// <param name="prefix">the prefix to be used to reference the <paramref name="target"/></param>
        internal DbPrefixExpression(DbExpression target, string prefix)
        {
            Target = target;
            Prefix = prefix;
        }

        /// <summary>
        /// Gets the target <see cref="DbExpression"/> to be prefixed.
        /// </summary>
        public DbExpression Target { get; private set; }


        /// <summary>
        /// Gets the prefix to be used to reference the <see cref="Target"/>
        /// </summary>
        public string Prefix { get; private set; }

        /// <summary>
        /// Gets the <see cref="DbExpressionType"/> of the <see cref="DbExpression"/>.
        /// </summary>
        /// <value></value>
        public override DbExpressionType ExpressionType
        {
            get { return DbExpressionType.Prefix; }
        }
    }
}
