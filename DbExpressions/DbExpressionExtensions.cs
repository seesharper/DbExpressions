using System;
using System.Collections.Generic;

namespace DbExpressions
{
    /// <summary>
    /// Contains extension methods that targets the <see cref="DbExpression"/> type.
    /// </summary>
    public static class DbExpressionExtensions
    {        
        private static readonly DbExpressionFactory ExpressionFactory = new DbExpressionFactory();
        
        /// <summary>
        /// Determines whether the specified <see cref="DbExpression"/> is null.
        /// </summary>
        /// <param name="dbExpression">The target <see cref="DbExpression"/></param>
        /// <returns>
        /// <c>true</c> if the specified <see cref="DbExpression"/> is null; otherwise, <c>false</c>.
        /// </returns>
        /// <remarks>
        /// This method is needed because of the operator overloading between <see cref="DbExpression"/> instances.
        /// </remarks>
        public static bool IsNull(this DbExpression dbExpression)
        {
            return ((object)dbExpression) == null;
        }

        /// <summary>
        /// Returns a list of <typeparamref name="TDbExpression"/> instances that matches the <paramref name="predicate"/>.
        /// </summary>
        /// <typeparam name="TDbExpression">The type of <see cref="DbExpression"/> to search for.</typeparam>
        /// <param name="expression">The <see cref="DbExpression"/> that represents the sub tree for which to start searching.</param>
        /// <param name="predicate">The <see cref="Func{T,TResult}"/> used to filter the result</param>
        /// <returns>A list of <see cref="DbExpression"/> instances that matches the given predicate.</returns>
        public static IEnumerable<TDbExpression> Find<TDbExpression>(this DbExpression expression, Func<TDbExpression, bool> predicate) where TDbExpression : DbExpression
        {
            var finder = new DbExpressionFinder<TDbExpression>();
            return finder.Find(expression, predicate);
        }

        /// <summary>
        /// Searches for expressions using the given <paramref name="predicate"/> and replaces matches with 
        /// the result from the <paramref name="replaceWith"/> delegate.
        /// </summary>
        /// <typeparam name="TDbExpression">The type of <see cref="DbExpression"/> to search for.</typeparam>
        /// <param name="dbExpression">The <see cref="DbExpression"/> that represents the sub tree 
        /// for which to start searching.</param>
        /// <param name="predicate">The <see cref="Func{T,TResult}"/> used to filter the result</param>
        /// <param name="replaceWith">The <see cref="Func{T,TResult}"/> used to specify the replacement expression.</param>
        /// <returns>The modified <see cref="DbExpression"/> tree.</returns>
        public static DbExpression Replace<TDbExpression>(this DbExpression dbExpression, Func<TDbExpression, bool> predicate, Func<TDbExpression, DbExpression> replaceWith) where TDbExpression : DbExpression
        {
            var replacer = new DbExpressionReplacer<TDbExpression>();
            return replacer.Replace(dbExpression, predicate, replaceWith);
        }

        /// <summary>
        /// Creates a new <see cref="DbAliasExpression"/> for the target <paramref name="dbExpression"/>.
        /// </summary>
        /// <param name="dbExpression">The <see cref="DbExpression"/> to be aliased.</param>
        /// <param name="alias">The alias</param>
        /// <returns>A <see cref="DbAliasExpression"/> instance.</returns>
        public static DbAliasExpression As(this DbExpression dbExpression, string alias)
        {
            return ExpressionFactory.Alias(dbExpression, alias);
        }
    }
}
