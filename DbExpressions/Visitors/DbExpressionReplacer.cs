using System;

namespace DbExpressions
{
    /// <summary>
    /// A class that is capable of doing a find and replace in an <see cref="DbExpression"/> tree.
    /// </summary>
    /// <typeparam name="TDbExpression">The type of <see cref="DbExpression"/> to find and replace.</typeparam>
    public class DbExpressionReplacer<TDbExpression> : DbExpressionVisitor where TDbExpression : DbExpression
    {
        private Func<TDbExpression, DbExpression> _replaceWith;
        private Func<TDbExpression, bool> _predicate;

        /// <summary>
        /// Searches for expressions using the given <paramref name="predicate"/> and 
        /// replaces matches with the result from the <paramref name="replaceWith"/> delegate.          
        /// </summary>
        /// <param name="expression">The <see cref="DbExpression"/> that 
        /// represents the sub tree for which to start searching.</param>
        /// <param name="predicate">The <see cref="Func{T,TResult}"/> used to filter the result.</param>
        /// <param name="replaceWith">The <see cref="Func{T,TResult}"/> 
        /// used to specify the replacement expression.</param>
        /// <returns>The modified <see cref="DbExpression"/> tree.</returns>
        public DbExpression Replace(DbExpression expression, Func<TDbExpression, bool> predicate, Func<TDbExpression, DbExpression> replaceWith)            
        {
            _replaceWith = replaceWith;
            _predicate = predicate;
            return Visit(expression);
        }

        /// <summary>
        /// Visits each node of the <see cref="DbExpression"/> tree checks 
        /// if the current expression matches the predicate. If a match is found 
        /// the expression will be replaced.        
        /// </summary>
        /// <param name="expression">The <see cref="DbExpression"/> currently being visited.</param>
        /// <returns>The modified <see cref="DbExpression"/> tree.</returns>
        public override DbExpression Visit(DbExpression expression)
        {
            if (!expression.IsNull() && expression is TDbExpression)
                if (_predicate((TDbExpression)expression))
                    return _replaceWith((TDbExpression)expression);
            return base.Visit(expression);
        }
    }
}
