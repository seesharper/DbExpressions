using System.Collections.Generic;

namespace DbExpressions
{
    /// <summary>
    /// Represents a batch of <see cref="DbExpression"/> instances. 
    /// </summary>
    public class DbBatchExpression : DbListExpression
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DbBatchExpression"/> class.
        /// </summary>
        internal DbBatchExpression()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DbBatchExpression"/> class.
        /// </summary>
        /// <param name="dbExpressions">A <see cref="IEnumerable{T}"/> that 
        /// contains <see cref="DbExpression"/> instances to be copied to the new list.</param>
        internal DbBatchExpression(IEnumerable<DbExpression> dbExpressions) : base(dbExpressions)
        {
        }

        /// <summary>
        /// Gets the <see cref="DbExpressionType"/> of the <see cref="DbExpression"/>.
        /// </summary>
        /// <value></value>
        public override DbExpressionType ExpressionType
        {
            get { return DbExpressionType.Batch; }
        }
    }
}
