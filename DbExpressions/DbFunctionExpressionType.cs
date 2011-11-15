
namespace DbExpressions
{
    /// <summary>
    /// Describes the node types for the nodes of an <see cref="DbExpression"/> tree.     
    /// </summary>
    /// <value></value>
    public enum DbFunctionExpressionType
    {
        /// <summary>
        /// A node that represents a string function 
        /// </summary>
        String,

        /// <summary>
        /// A node that represents a datetime function
        /// </summary>
        DateTime,

        /// <summary>
        /// A node that represents an aggregate function.
        /// </summary>
        Aggregate,

        /// <summary>
        /// A node that represents a mathematical function
        /// </summary>
        Mathematical
    }
}
