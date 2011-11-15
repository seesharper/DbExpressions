using System;
using System.Collections.Generic;

namespace DbExpressions
{
    /// <summary>
    /// A class used to search for <see cref="DbExpression"/> instances. 
    /// </summary>
    /// <typeparam name="TDbExpression">The type of <see cref="DbExpression"/> to search for.</typeparam>
    public class DbExpressionFinder<TDbExpression> : DbExpressionVisitor where TDbExpression : DbExpression
    {
        private readonly IList<TDbExpression> _result = new List<TDbExpression>();
        private Func<TDbExpression, bool> _predicate;

        /// <summary>
        /// Returns a list of <typeparamref name="TDbExpression"/> instances that matches the <paramref name="predicate"/>.
        /// </summary>
        /// <param name="expression">The <see cref="DbExpression"/> that represents the sub tree for which to start searching.</param>
        /// <param name="predicate">The <see cref="Func{T,TResult}"/> used to filter the result.</param>
        /// <returns>A list of <see cref="DbExpression"/> instances that matches the given predicate.</returns>
        public IEnumerable<TDbExpression> Find(DbExpression expression, Func<TDbExpression, bool> predicate)
        {
            _result.Clear();
            _predicate = predicate;
            Visit(expression);
            return _result;
        }

        /// <summary>
        /// Visits each node of the <see cref="DbExpression"/> tree checks 
        /// if the current expression matches the predicate.         
        /// </summary>
        /// <param name="dbExpression">The <see cref="DbExpression"/> currently being visited.</param>
        /// <returns>A <see cref="DbExpression"/> instance.</returns>
        public override DbExpression Visit(DbExpression dbExpression)
        {
            if (!dbExpression.IsNull() && dbExpression.GetType() == typeof(TDbExpression))
            {
                if (_predicate((TDbExpression)dbExpression))
                    _result.Add((TDbExpression)dbExpression);
            }

            return base.Visit(dbExpression);
        }
    }
}
