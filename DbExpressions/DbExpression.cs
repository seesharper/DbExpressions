using System;

namespace DbExpressions
{
    /// <summary>
    /// Provides the base class from which the classes that represent expression tree nodes are derived.
    /// </summary>
    public abstract class DbExpression
    {
        private static readonly DbExpressionFactory ExpressionFactory = new DbExpressionFactory();

        [ThreadStatic]
        private static DbQueryTranslator dbQueryTranslator;
                           
        /// <summary>
        /// Gets the <see cref="DbExpressionType"/> of the <see cref="DbExpression"/>.
        /// </summary>
        public abstract DbExpressionType ExpressionType { get; }

        #region Operator Overloads

        /// <summary>
        /// Implements the operator ==.
        /// </summary>
        /// <param name="leftExpression">The left expression.</param>
        /// <param name="rightExpression">The right expression.</param>
        /// <returns>A <see cref="DbExpression"/> instance.</returns>
        public static DbExpression operator ==(DbExpression leftExpression, DbExpression rightExpression)
        {
            return ExpressionFactory.Equal(
                leftExpression.IsNull() ? ExpressionFactory.Constant(null) : leftExpression,
                rightExpression.IsNull() ? ExpressionFactory.Constant(null) : rightExpression);
        }

        /// <summary>
        /// Implements the operator ==.
        /// </summary>
        /// <param name="leftExpression">The left expression.</param>
        /// <param name="value">The value to be compared with <paramref name="leftExpression"/></param>
        /// <returns>A <see cref="DbExpression"/> instance.</returns>
        public static DbExpression operator ==(DbExpression leftExpression, object value)
        {
            return ExpressionFactory.Equal(leftExpression, ExpressionFactory.Constant(value));
        }

        /// <summary>
        /// Implements the operator ==.
        /// </summary>
        /// <param name="value">The value to be compared with <paramref name="rightExpression"/></param>
        /// <param name="rightExpression">The right expression.</param>
        /// <returns>A <see cref="DbExpression"/> instance.</returns>
        public static DbExpression operator ==(object value, DbExpression rightExpression)
        {
            return ExpressionFactory.Equal(ExpressionFactory.Constant(value), rightExpression);
        }

        /// <summary>
        /// Implements the operator !=.
        /// </summary>
        /// <param name="leftExpression">The left expression.</param>
        /// <param name="rightExpression">The right expression.</param>
        /// <returns>A <see cref="DbExpression"/> instance.</returns>
        public static DbExpression operator !=(DbExpression leftExpression, DbExpression rightExpression)
        {
            return ExpressionFactory.NotEqual(
                leftExpression.IsNull() ? ExpressionFactory.Constant(null) : leftExpression,
                rightExpression.IsNull() ? ExpressionFactory.Constant(null) : rightExpression);
        }

        /// <summary>
        /// Implements the operator !=.
        /// </summary>
        /// <param name="value">The value to be compared with <paramref name="rightExpression"/></param>
        /// <param name="rightExpression">The right expression.</param>
        /// <returns>A <see cref="DbExpression"/> instance.</returns>
        public static DbExpression operator !=(object value, DbExpression rightExpression)
        {
            return ExpressionFactory.NotEqual(ExpressionFactory.Constant(value), rightExpression);
        }

        /// <summary>
        /// Implements the operator !=.
        /// </summary>
        /// <param name="leftExpression">The left expression.</param>
        /// <param name="value">The value to be compared with <paramref name="leftExpression"/></param>
        /// <returns>A <see cref="DbExpression"/> instance.</returns>
        public static DbExpression operator !=(DbExpression leftExpression, object value)
        {
            return ExpressionFactory.NotEqual(leftExpression, ExpressionFactory.Constant(value));
        }

        /// <summary>
        /// Implements the operator >.
        /// </summary>
        /// <param name="leftExpression">The left expression.</param>
        /// <param name="rightExpression">The right expression.</param>
        /// <returns>A <see cref="DbExpression"/> instance.</returns>
        public static DbExpression operator >(DbExpression leftExpression, DbExpression rightExpression)
        {
            return ExpressionFactory.GreaterThan(leftExpression, rightExpression);
        }

        /// <summary>
        /// Implements the less than operator.
        /// </summary>
        /// <param name="leftExpression">The left expression.</param>
        /// <param name="rightExpression">The right expression.</param>
        /// <returns>A <see cref="DbExpression"/> instance.</returns>
        public static DbExpression operator <(DbExpression leftExpression, DbExpression rightExpression)
        {
            return ExpressionFactory.LessThan(leftExpression, rightExpression);
        }

        /// <summary>
        /// Implements the operator >.
        /// </summary>
        /// <param name="leftExpression">The left expression.</param>
        /// <param name="value">The value to be compared with <paramref name="leftExpression"/></param>
        /// <returns>A <see cref="DbExpression"/> instance.</returns>
        public static DbExpression operator >(DbExpression leftExpression, object value)
        {
            return ExpressionFactory.GreaterThan(leftExpression, ExpressionFactory.Constant(value));
        }

        /// <summary>
        /// Implements the less than operator.
        /// </summary>
        /// <param name="leftExpression">The left expression.</param>
        /// <param name="value">The value to be compared with <paramref name="leftExpression"/></param>
        /// <returns>A <see cref="DbExpression"/> instance.</returns>
        public static DbExpression operator <(DbExpression leftExpression, object value)
        {
            return ExpressionFactory.LessThan(leftExpression, ExpressionFactory.Constant(value));
        }

        /// <summary>
        /// Implements the less than operator.
        /// </summary>
        /// <param name="value">The value to be compared with <paramref name="rightExpression"/></param>
        /// <param name="rightExpression">The right expression.</param>
        /// <returns>A <see cref="DbExpression"/> instance.</returns>
        public static DbExpression operator <(object value, DbExpression rightExpression)
        {
            return ExpressionFactory.LessThan(ExpressionFactory.Constant(value), rightExpression);
        }

        /// <summary>
        /// Implements the greater than operator.
        /// </summary>
        /// <param name="value">The value to be compared with <paramref name="rightExpression"/></param>
        /// <param name="rightExpression">The right expression.</param>
        /// <returns>A <see cref="DbExpression"/> instance.</returns>
        public static DbExpression operator >(object value, DbExpression rightExpression)
        {
            return ExpressionFactory.GreaterThan(ExpressionFactory.Constant(value), rightExpression);
        }

        /// <summary>
        /// Implements the greater than or equal operator.
        /// </summary>
        /// <param name="leftExpression">The left expression.</param>
        /// <param name="rightExpression">The right expression.</param>
        /// <returns>A <see cref="DbExpression"/> instance.</returns>
        public static DbExpression operator >=(DbExpression leftExpression, DbExpression rightExpression)
        {
            return ExpressionFactory.GreaterThanOrEqual(leftExpression, rightExpression);
        }

        /// <summary>
        /// Implements the less than or equal operator.
        /// </summary>
        /// <param name="leftExpression">The left expression.</param>
        /// <param name="rightExpression">The right expression.</param>
        /// <returns>A <see cref="DbExpression"/> instance.</returns>
        public static DbExpression operator <=(DbExpression leftExpression, DbExpression rightExpression)
        {
            return ExpressionFactory.LessThanOrEqual(leftExpression, rightExpression);
        }

        /// <summary>
        /// Implements the greater or equal operator. 
        /// </summary>
        /// <param name="leftExpression">The left expression.</param>
        /// <param name="value">The value to be compared with <paramref name="leftExpression"/></param>
        /// <returns>A <see cref="DbExpression"/> instance.</returns>
        public static DbExpression operator >=(DbExpression leftExpression, object value)
        {
            return ExpressionFactory.GreaterThanOrEqual(leftExpression, ExpressionFactory.Constant(value));
        }

        /// <summary>
        /// Implements the less than or equal operator.
        /// </summary>
        /// <param name="leftExpression">The left expression.</param>
        /// <param name="value">The value to be compared with <paramref name="leftExpression"/></param>
        /// <returns>A <see cref="DbExpression"/> instance.</returns>
        public static DbExpression operator <=(DbExpression leftExpression, object value)
        {
            return ExpressionFactory.LessThanOrEqual(leftExpression, ExpressionFactory.Constant(value));
        }

        /// <summary>
        /// Implements the less than or equal operator.
        /// </summary>
        /// <param name="value">The value to be compared with <paramref name="rightExpression"/></param>
        /// <param name="rightExpression">The right expression.</param>
        /// <returns>A <see cref="DbExpression"/> instance.</returns>
        public static DbExpression operator <=(object value, DbExpression rightExpression)
        {
            return ExpressionFactory.LessThanOrEqual(ExpressionFactory.Constant(value), rightExpression);
        }

        /// <summary>
        /// Implements the operator >=.
        /// </summary>
        /// <param name="value">The value to be compared with <paramref name="rightExpression"/></param>
        /// <param name="rightExpression">The right expression.</param>
        /// <returns>A <see cref="DbExpression"/> instance.</returns>
        public static DbExpression operator >=(object value, DbExpression rightExpression)
        {
            return ExpressionFactory.GreaterThanOrEqual(ExpressionFactory.Constant(value), rightExpression);
        }
       
        /// <summary>
        /// Implements the operator &amp;.
        /// </summary>
        /// <param name="leftExpression">The left expression.</param>
        /// <param name="rightExpression">The right expression.</param>
        /// <returns>The result of the operator.</returns>
        public static DbExpression operator &(DbExpression leftExpression, DbExpression rightExpression)
        {
            return ExpressionFactory.And(leftExpression, rightExpression);
        }

        /// <summary>
        /// Implements the operator |;.
        /// </summary>
        /// <param name="leftExpression">The left expression.</param>
        /// <param name="rightExpression">The right expression.</param>
        /// <returns>The result of the operator.</returns>
        public static DbExpression operator |(DbExpression leftExpression, DbExpression rightExpression)
        {
            return ExpressionFactory.Or(leftExpression, rightExpression);
        }
               
        /// <summary>
        /// Determines whether the specified <see cref="T:System.Object"/> is equal to the current <see cref="T:System.Object"/>.
        /// </summary>
        /// <returns>
        /// true if the specified <see cref="T:System.Object"/> is equal to the current <see cref="T:System.Object"/>; otherwise, false.
        /// </returns>
        /// <param name="obj">The <see cref="T:System.Object"/> to compare with the current <see cref="T:System.Object"/>. </param><filterpriority>2</filterpriority>
        public override bool Equals(object obj)
        {
            return obj.ToString() == ToString();
        }

        /// <summary>
        /// Serves as a hash function for a particular type. 
        /// </summary>
        /// <returns>
        /// A hash code for the current <see cref="T:System.Object"/>.
        /// </returns>
        /// <filterpriority>2</filterpriority>
        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }

        #endregion

        /// <summary>
        /// Returns a <see cref="System.String"/> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String"/> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            InitializeQueryTranslator();
            return dbQueryTranslator.Translate(this).Sql;
        }

        private static void InitializeQueryTranslator()
        {
            if (dbQueryTranslator == null)
                dbQueryTranslator = DbQueryTranslatorFactory.GetQueryTranslator();
        }
    }
}
