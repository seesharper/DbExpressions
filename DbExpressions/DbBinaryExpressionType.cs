namespace DbExpressions
{
    /// <summary>
    /// Specifies the type of <see cref="DbBinaryExpression"/>.
    /// </summary>
    public enum DbBinaryExpressionType
    {
        /// <summary>
        /// A node that represents a logical AND operation.
        /// </summary>        
        And,

        /// <summary>
        /// A node that represents a logical OR operation.
        /// </summary>        
        Or,

        /// <summary>
        /// A node that represents an equality comparison.
        /// </summary>        
        Equal,

        /// <summary>
        /// A node that represents an inequality comparison.
        /// </summary>        
        NotEqual,

        /// <summary>
        /// A node that represents a "greater than" comparison.
        /// </summary>        
        GreaterThan,

        /// <summary>
        /// A node that represents a "greater than or equal" comparison.
        /// </summary>
        GreaterThanOrEqual,

        /// <summary>
        /// A node that represents a "less than" comparison.
        /// </summary>
        LessThan,

        /// <summary>
        /// A node that represents a "less than or equal" comparison.
        /// </summary>
        LessThanOrEqual,

        /// <summary>
        /// A node that represents arithmetic addition.
        /// </summary>
        Add,

        /// <summary>
        /// A node that represents arithmetic subtraction.
        /// </summary>
        Subtract,

        /// <summary>
        /// A node that represents arithmetic multiplication.
        /// </summary>
        Multiply,

        /// <summary>
        /// A node that represents arithmetic division.
        /// </summary>
        Divide,   

        /// <summary>
        /// A node that represents a column or variable assignment
        /// </summary>
        Assignment
    }
}
