namespace DbExpressions
{
    /// <summary>
    /// Specifies the type of <see cref="DbUnaryExpression"/>.
    /// </summary>
    public enum DbUnaryExpressionType
    {
        /// <summary>
        /// A node that represents negating the result of a boolean <see cref="DbExpression"/>
        /// </summary>
        Not,

        /// <summary>
        /// A node that represents a conversion operation.
        /// </summary>
        Cast,        
    }
}
