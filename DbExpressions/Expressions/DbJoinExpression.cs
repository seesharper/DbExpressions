namespace DbExpressions
{
    /// <summary>
    /// Represents a 'JOIN' in the query.
    /// </summary>
    public class DbJoinExpression : DbExpression
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="DbJoinExpression"/> class.
        /// </summary>
        /// <param name="joinExpressionType">The <see cref="DbJoinExpressionType"/> that specifies the type of <see cref="DbJoinExpression"/> to create.</param>
        /// <param name="target">The join target <see cref="DbExpression"/>.</param>
        /// <param name="condition">The join condition.</param>
        internal DbJoinExpression(DbJoinExpressionType joinExpressionType, DbExpression target, DbExpression condition)
        {
            JoinExpressionType = joinExpressionType;
            Target = target;
            Condition = condition;
        }

        /// <summary>
        /// Gets the <see cref="DbExpressionType"/> of the <see cref="DbExpression"/>.
        /// </summary>
        /// <value></value>
        public override DbExpressionType ExpressionType
        {
            get { return DbExpressionType.Join; }
        }

        /// <summary>
        /// Specifies the type of <see cref="DbJoinExpression"/>.
        /// </summary>
        public DbJoinExpressionType JoinExpressionType{ get; private set; }

        /// <summary>
        /// Gets or sets the target <see cref="DbExpression"/>
        /// </summary>
        public DbExpression Target { get; private set; }

        /// <summary>
        /// Specifies the condition on which the join is based
        /// </summary>
        public DbExpression Condition { get; private set; }
    }
}
