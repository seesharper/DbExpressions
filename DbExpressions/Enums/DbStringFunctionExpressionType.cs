namespace DbExpressions
{
    /// <summary>
    /// Describes the node types that represents calling string functions.
    /// </summary>
    public enum DbStringFunctionExpressionType
    {
        /// <summary>
        /// A node that represents changing a string to uppercase.
        /// </summary>
        ToUpper,

        /// <summary>
        /// A node that represents changing a string to lowercase.
        /// </summary>
        ToLower,

        /// <summary>
        /// A node that represents returning the length of a string.
        /// </summary>
        Length,

        /// <summary>
        /// A node that represents removing all leading and trailing spaces from a string.         
        /// </summary>
        Trim,

        /// <summary>
        /// A node that represents removing all leading spaces from a string.
        /// </summary>
        TrimStart,

        /// <summary>
        /// A node that represents removing all trailing spaces from a string.
        /// </summary>
        TrimEnd,

        /// <summary>
        /// A node that represents replacing 
        /// all occurrences of a specified string value with another string value.
        /// </summary>
        Replace,

        /// <summary>
        /// A node that represents reversing a string value.         
        /// </summary>
        Reverse,

        /// <summary>
        /// A node that represents returning a four-character code to evaluate the similarity 
        /// of two strings.
        /// </summary>
        SoundEx,

        /// <summary>
        /// A node that represents retriving a substring from a string.
        /// </summary>
        SubString
    }
}
