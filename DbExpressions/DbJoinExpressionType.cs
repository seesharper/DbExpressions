namespace DbExpressions
{
    /// <summary>
    /// Specifies the type of <see cref="DbJoinExpression"/>.
    /// </summary>
    public enum  DbJoinExpressionType
    {
        /// <summary>
        /// Specifies all matching pairs of rows are returned.
        /// </summary>
        InnerJoin,
        /// <summary>
        /// Specifies that all rows from the left table 
        /// not meeting the join condition are included in the result set, 
        /// and output columns from the other table are set to NULL 
        /// in addition to all rows returned by the inner join.
        /// </summary>
        LeftOuterJoin,

        /// <summary>
        /// Specifies all rows from the right table 
        /// not meeting the join condition are included in the result set, 
        /// and output columns that correspond to the other table are set to NULL, 
        /// in addition to all rows returned by the inner join.
        /// </summary>
        RightOuterJoin
    }
}
