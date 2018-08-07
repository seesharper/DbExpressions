namespace DbExpressions
{
    /// <summary>
    /// Describes the node types for the nodes of an <see cref="DbExpression"/> tree.     
    /// </summary>
    /// <value></value>
    public enum DbExpressionType
    {
        /// <summary>
        /// A node that represents a <see cref="DbBinaryExpressionType"/>,
        /// <seealso cref="DbBinaryExpression"/>.
        /// </summary>
        Binary,
        
        /// <summary>
        /// A node that represents a list of <see cref="DbExpression"/> instances.
        /// </summary>
        List,

        /// <summary>
        /// A node that represents the execution of multiple statements as one batch.
        /// </summary>
        Batch,
              
        /// <summary>
        /// A node that represents calling a function.
        /// </summary>
        Function,

        /// <summary>
        /// A node that represents a <see cref="DbExpression"/> that has a constant value.
        /// </summary>
        Constant,

        /// <summary>
        /// A node the represents the 'SELECT' clause of the query.
        /// </summary>
        Select,
        
        /// <summary>
        /// A node the represents the 'INSERT' clause of the query.
        /// </summary>
        Insert,

        /// <summary>
        /// A node the represents the 'UPDATE' clause of the query.
        /// </summary>
        Update,

        /// <summary>
        /// A node the represents the 'DELETE' clause of the query.
        /// </summary>
        Delete,

        /// <summary>
        /// A node that represents a <see cref="DbQuery{TQueryExpression}"/>. 
        /// </summary>
        Query,

        /// <summary>
        /// A node that represents an element in the 'ORDER BY' clause of the query.
        /// </summary>
        OrderBy,

        /// <summary>
        /// A node the represents the 'GROUP BY' clause of the query.
        /// </summary>
        GroupBy,

        /// <summary>
        /// A node that represents a table reference in the query.
        /// </summary>
        Table,

        /// <summary>
        /// A node that represents a column reference in the query.
        /// </summary>
        Column,

        /// <summary>
        /// A node that represents a 'JOIN' in the query.
        /// </summary>
        Join,

        /// <summary>
        /// A node that represents an 'EXISTS' subquery.
        /// </summary>
        Exists,

        /// <summary>
        /// A node that represents an alised <see cref="DbExpression"/>.
        /// </summary>
        Alias,

        /// <summary>
        /// A node that represents a <see cref="DbExpression"/> prefix.
        /// </summary>
        Prefix,

        /// <summary>
        /// A node the represents a <see cref="DbUnaryExpression"/>.
        /// </summary>
        Unary,

        /// <summary>
        /// A node that represents a <see cref="DbConditionalExpression"/>.
        /// </summary>
        Conditional,
 
        /// <summary>
        /// A node that represents a <see cref="DbConcatExpression"/>.
        /// </summary>
        Concat,

        /// <summary>
        /// A node that represents a <see cref="DbInExpression"/>.
        /// </summary>
        In,

        /// <summary>
        /// A node that represents a sql fragment.
        /// </summary>
        Sql
    }
}
