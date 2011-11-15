using System.Collections;
using System.Collections.Generic;

namespace DbExpressions
{
    /// <summary>
    /// Represents a list of <see cref="DbExpression"/> instances.
    /// </summary>
    public class DbListExpression : DbExpression, IEnumerable<DbExpression>
    {
        private readonly List<DbExpression> _dbExpressions = new List<DbExpression>();

        /// <summary>
        /// Initializes a new instance of the <see cref="DbListExpression"/> class.
        /// </summary>
        internal DbListExpression()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DbListExpression"/> class.
        /// </summary>
        /// <param name="dbExpressions">A <see cref="IEnumerable{T}"/> that 
        /// contains <see cref="DbExpression"/> instances to be copied to the new list.</param>
        internal DbListExpression(IEnumerable<DbExpression> dbExpressions)
        {
            _dbExpressions.AddRange(dbExpressions);
        }


        /// <summary>
        /// Gets the <see cref="DbExpressionType"/> of the <see cref="DbExpression"/>.
        /// </summary>
        /// <value></value>
        public override DbExpressionType ExpressionType
        {
            get { return DbExpressionType.List; }
        }

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.Collections.Generic.IEnumerator`1"/> that can be used to iterate through the collection.
        /// </returns>
        public IEnumerator<DbExpression> GetEnumerator()
        {
            return _dbExpressions.GetEnumerator();
        }

        /// <summary>
        /// Returns an enumerator that iterates through a collection.
        /// </summary>
        /// <returns>
        /// An <see cref="T:System.Collections.IEnumerator"/> object that can be used to iterate through the collection.
        /// </returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
