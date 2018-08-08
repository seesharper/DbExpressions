namespace DbExpressions
{
    /// <summary>
    /// Specifies the type of <see cref="DbQuery{TQueryExpression}"/>.
    /// </summary>
    public enum DbQueryType
    {
        /// <summary>
        /// A node that represents a 'SELECT' query.
        /// </summary>
        Select,
        /// <summary>
        /// A node that represents a 'UPDATE' query.
        /// </summary>
        Update,
        /// <summary>
        /// A node that represents a 'INSERT' query.
        /// </summary>
        Insert,

        /// <summary>
        /// A node that represents a 'DELETE' query.
        /// </summary>
        Delete,

    }
}
