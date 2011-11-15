using System;
using System.Collections.Generic;
using System.Linq;

namespace DbExpressions
{
    /// <summary>
    /// Contains the methods to create the various <see cref="DbExpression"/> types.
    /// </summary>
    /// <seealso cref="DbExpressionType"/>
    public class DbExpressionFactory
    {        
        #region Binary Expressions

        /// <summary>
        ///  Creates a <see cref="DbBinaryExpression"/>.
        /// </summary>
        /// <param name="binaryExpressionType">The <see cref="DbBinaryExpressionType"/> that specifies the type of binary expression to create.</param>
        /// <param name="leftExpression">A <see cref="DbExpression"/> that represents the left operand.</param>
        /// <param name="rightExpression">A <see cref="DbExpression"/> that represents the right operand.</param>
        /// <returns>A <see cref="DbBinaryExpression"/> instance.</returns>
        public DbBinaryExpression MakeBinary(DbBinaryExpressionType binaryExpressionType, DbExpression leftExpression, DbExpression rightExpression)
        {
            var binaryExpression = new DbBinaryExpression(binaryExpressionType, leftExpression, rightExpression);
            return binaryExpression;
        }

        /// <summary>
        /// Creates a <see cref="DbBinaryExpression"/> that represents a logical <b>AND</b> operation.
        /// </summary>
        /// <param name="leftExpression">A <see cref="DbExpression"/> that represents the left operand.</param>
        /// <param name="rightExpression">A <see cref="DbExpression"/> that represents the right operand.</param>
        /// <returns>A <see cref="DbBinaryExpression"/> instance.</returns>
        public DbBinaryExpression And(DbExpression leftExpression, DbExpression rightExpression)
        {
            return MakeBinary(DbBinaryExpressionType.And, leftExpression, rightExpression);            
        }

        /// <summary>
        /// Creates a <see cref="DbBinaryExpression"/> that represents a logical <b>OR</b> operation.
        /// </summary>
        /// <param name="leftExpression">A <see cref="DbExpression"/> that represents the left operand.</param>
        /// <param name="rightExpression">A <see cref="DbExpression"/> that represents the right operand.</param>
        /// <returns>A <see cref="DbBinaryExpression"/> instance.</returns>
        public DbBinaryExpression Or(DbExpression leftExpression, DbExpression rightExpression)
        {
            return MakeBinary(DbBinaryExpressionType.Or, leftExpression, rightExpression);            
        }

        /// <summary>
        /// Creates a <see cref="DbBinaryExpression"/> that represents an equality comparison.
        /// </summary>
        /// <param name="leftExpression">A <see cref="DbExpression"/> that represents the left operand.</param>
        /// <param name="rightExpression">A <see cref="DbExpression"/> that represents the right operand.</param>
        /// <returns>A <see cref="DbBinaryExpression"/> instance.</returns>
        public DbBinaryExpression Equal(DbExpression leftExpression, DbExpression rightExpression)
        {
            return MakeBinary(DbBinaryExpressionType.Equal, leftExpression, rightExpression);            
        }

        /// <summary>
        /// Creates a <see cref="DbBinaryExpression"/> that represents an inequality comparison.
        /// </summary>
        /// <param name="leftExpression">A <see cref="DbExpression"/> that represents the left operand.</param>
        /// <param name="rightExpression">A <see cref="DbExpression"/> that represents the right operand.</param>
        /// <returns>A <see cref="DbBinaryExpression"/> instance.</returns>
        public DbBinaryExpression NotEqual(DbExpression leftExpression, DbExpression rightExpression)
        {
            return MakeBinary(DbBinaryExpressionType.NotEqual, leftExpression, rightExpression);            
        }

        /// <summary>
        /// Creates a <see cref="DbBinaryExpression"/> that represents a 'greater than' comparison.
        /// </summary>
        /// <param name="leftExpression">A <see cref="DbExpression"/> that represents the left operand.</param>
        /// <param name="rightExpression">A <see cref="DbExpression"/> that represents the right operand.</param>
        /// <returns>A <see cref="DbBinaryExpression"/> instance.</returns>
        public DbBinaryExpression GreaterThan(DbExpression leftExpression, DbExpression rightExpression)
        {
            return MakeBinary(DbBinaryExpressionType.GreaterThan, leftExpression, rightExpression);            
        }

        /// <summary>
        /// Creates a <see cref="DbBinaryExpression"/> that represents a 'greater than or equal' comparison.
        /// </summary>
        /// <param name="leftExpression">A <see cref="DbExpression"/> that represents the left operand.</param>
        /// <param name="rightExpression">A <see cref="DbExpression"/> that represents the right operand.</param>
        /// <returns>A <see cref="DbBinaryExpression"/> instance.</returns>
        public DbBinaryExpression GreaterThanOrEqual(DbExpression leftExpression, DbExpression rightExpression)
        {
            return MakeBinary(DbBinaryExpressionType.GreaterThanOrEqual, leftExpression, rightExpression);            
        }

        /// <summary>
        /// Creates a <see cref="DbBinaryExpression"/> that represents a 'less than' comparison.
        /// </summary>
        /// <param name="leftExpression">A <see cref="DbExpression"/> that represents the left operand.</param>
        /// <param name="rightExpression">A <see cref="DbExpression"/> that represents the right operand.</param>
        /// <returns>A <see cref="DbBinaryExpression"/> instance.</returns>
        public DbBinaryExpression LessThan(DbExpression leftExpression, DbExpression rightExpression)
        {
            return MakeBinary(DbBinaryExpressionType.LessThan, leftExpression, rightExpression);            
        }

        /// <summary>
        /// Creates a <see cref="DbBinaryExpression"/> that represents a 'less than or equal' comparison.
        /// </summary>
        /// <param name="leftExpression">A <see cref="DbExpression"/> that represents the left operand.</param>
        /// <param name="rightExpression">A <see cref="DbExpression"/> that represents the right operand.</param>
        /// <returns>A <see cref="DbBinaryExpression"/> instance.</returns>
        public DbBinaryExpression LessThanOrEqual(DbExpression leftExpression, DbExpression rightExpression)
        {
            return MakeBinary(DbBinaryExpressionType.LessThanOrEqual, leftExpression, rightExpression);            
        }

        /// <summary>
        /// Creates a <see cref="DbBinaryExpression"/> that represents arithmetic addition.
        /// </summary>
        /// <param name="leftExpression">A <see cref="DbExpression"/> that represents the left operand.</param>
        /// <param name="rightExpression">A <see cref="DbExpression"/> that represents the right operand.</param>
        /// <returns>A <see cref="DbBinaryExpression"/> instance.</returns>
        public DbBinaryExpression Add(DbExpression leftExpression, DbExpression rightExpression)
        {
            return MakeBinary(DbBinaryExpressionType.Add, leftExpression, rightExpression);            
        }

        /// <summary>
        /// Creates a <see cref="DbBinaryExpression"/> that represents arithmetic subtraction.
        /// </summary>
        /// <param name="leftExpression">A <see cref="DbExpression"/> that represents the left operand.</param>
        /// <param name="rightExpression">A <see cref="DbExpression"/> that represents the right operand.</param>
        /// <returns>A <see cref="DbBinaryExpression"/> instance.</returns>
        public DbBinaryExpression Subtract(DbExpression leftExpression, DbExpression rightExpression)
        {
            return MakeBinary(DbBinaryExpressionType.Subtract, leftExpression, rightExpression);            
        }

        /// <summary>
        /// Creates a <see cref="DbBinaryExpression"/> that represents arithmetic division.
        /// </summary>
        /// <param name="leftExpression">A <see cref="DbExpression"/> that represents the left operand.</param>
        /// <param name="rightExpression">A <see cref="DbExpression"/> that represents the right operand.</param>
        /// <returns>A <see cref="DbBinaryExpression"/> instance.</returns>
        public DbBinaryExpression Divide(DbExpression leftExpression, DbExpression rightExpression)
        {
            return MakeBinary(DbBinaryExpressionType.Divide, leftExpression, rightExpression);            
        }

        /// <summary>
        /// Creates a <see cref="DbBinaryExpression"/> that represents arithmetic multiplication.
        /// </summary>
        /// <param name="leftExpression">A <see cref="DbExpression"/> that represents the left operand.</param>
        /// <param name="rightExpression">A <see cref="DbExpression"/> that represents the right operand.</param>
        /// <returns>A <see cref="DbBinaryExpression"/> instance.</returns>
        public DbBinaryExpression Multiply(DbExpression leftExpression, DbExpression rightExpression)
        {
            return MakeBinary(DbBinaryExpressionType.Multiply, leftExpression, rightExpression);
        }

        /// <summary>
        /// Creates a <see cref="DbBinaryExpression"/> that represents a column or variable assignment.
        /// </summary>
        /// <param name="leftExpression">A <see cref="DbExpression"/> that represents the left operand.</param>
        /// <param name="rightExpression">A <see cref="DbExpression"/> that represents the right operand.</param>
        /// <returns>A <see cref="DbBinaryExpression"/> instance.</returns>
        public DbBinaryExpression Assign(DbExpression leftExpression, DbExpression rightExpression)
        {
            return MakeBinary(DbBinaryExpressionType.Assignment, leftExpression, rightExpression);
        }
        #endregion

        #region Aggregate Functions

        /// <summary>
        /// Creates a <see cref="DbAggregateFunctionExpression"/>.
        /// </summary>
        /// <param name="aggregateFunctionExpressionType">The <see cref="DbAggregateFunctionExpressionType"/> that specifies the type of aggregate expression to create.</param>
        /// <param name="target">The <see cref="DbExpression"/> that the aggregate function operates on.</param>
        /// <returns>A <see cref="DbAggregateFunctionExpression"/> instance.</returns>
        public DbAggregateFunctionExpression MakeAggregateFunction(DbAggregateFunctionExpressionType aggregateFunctionExpressionType, DbExpression target)
        {
            var aggregateExpression = new DbAggregateFunctionExpression(aggregateFunctionExpressionType, new[] { target });
            return aggregateExpression;
        }

        /// <summary>
        /// Creates a <see cref="DbAggregateFunctionExpression"/> that represents returning the sum of all values in the <paramref name="target"/> expression.
        /// </summary>
        /// <param name="target">The <see cref="DbExpression"/> that the aggregate function operates on.</param>
        /// <returns>A <see cref="DbAggregateFunctionExpression"/> instance.</returns>
        public DbAggregateFunctionExpression Sum(DbExpression target)
        {
            return MakeAggregateFunction(DbAggregateFunctionExpressionType.Sum, target);
        }

        /// <summary>
        /// Creates a <see cref="DbAggregateFunctionExpression"/> that represents returning the average of the values in the <paramref name="target"/> expression.
        /// </summary>
        /// <param name="target">The <see cref="DbExpression"/> that the aggregate function operates on.</param>
        /// <returns>A <see cref="DbAggregateFunctionExpression"/> instance.</returns>
        public DbAggregateFunctionExpression Avg(DbExpression target)
        {
            return MakeAggregateFunction(DbAggregateFunctionExpressionType.Avg, target);
        }

        /// <summary>
        /// Creates a <see cref="DbAggregateFunctionExpression"/> that represents returning the minimum value in the <paramref name="target"/> expression.
        /// </summary>
        /// <param name="target">The <see cref="DbExpression"/> that the aggregate function operates on.</param>
        /// <returns>A <see cref="DbAggregateFunctionExpression"/> instance.</returns>
        public DbAggregateFunctionExpression Min(DbExpression target)
        {
            return MakeAggregateFunction(DbAggregateFunctionExpressionType.Min, target);
        }

        /// <summary>
        /// Creates a <see cref="DbAggregateFunctionExpression"/> that represents returning the maximum value in the <paramref name="target"/> expression.
        /// </summary>
        /// <param name="target">The <see cref="DbExpression"/> that the aggregate function operates on.</param>
        /// <returns>A <see cref="DbAggregateFunctionExpression"/> instance.</returns>
        public DbAggregateFunctionExpression Max(DbExpression target)
        {
            return MakeAggregateFunction(DbAggregateFunctionExpressionType.Max, target);
        }

        /// <summary>
        /// Creates a <see cref="DbAggregateFunctionExpression"/> that represents returning the number of items in the <paramref name="target"/> expression.
        /// </summary>
        /// <param name="target">The <see cref="DbExpression"/> that the aggregate function operates on.</param>
        /// <returns>A <see cref="DbAggregateFunctionExpression"/> instance.</returns>
        public DbAggregateFunctionExpression Count(DbExpression target)
        {
            return MakeAggregateFunction(DbAggregateFunctionExpressionType.Count, target);
        }

        #endregion

        #region String Functions
        
        /// <summary>
        /// Creates a new <see cref="DbStringFunctionExpression"/>.
        /// </summary>
        /// <param name="stringFunctionExpressionType">The <see cref="DbStringFunctionExpressionType"/> that specifies the type of <see cref="DbStringFunctionExpression"/> to create.</param>
        /// <param name="arguments">A list of <see cref="DbExpression"/> instances that is used as arguments when calling the function.</param>
        /// <returns>A <see cref="DbStringFunctionExpression"/> instance.</returns>
        public DbStringFunctionExpression MakeStringFunction(DbStringFunctionExpressionType stringFunctionExpressionType, DbExpression[] arguments)
        {
            var stringFunctionExpression = new DbStringFunctionExpression(stringFunctionExpressionType, arguments);
            return stringFunctionExpression;
        }

        /// <summary>
        /// Creates a <see cref="DbStringFunctionExpression"/> that converts the result of the <paramref name="expression"/> to an 'UPPER' textual representation.
        /// </summary>
        /// <param name="expression">The <see cref="DbExpression"/> that represents the string to convert.</param>
        /// <returns>A <see cref="DbStringFunctionExpression"/> instance.</returns>
        public DbStringFunctionExpression ToUpper(DbExpression expression)
        {
            return MakeStringFunction(DbStringFunctionExpressionType.ToUpper, new[] { expression });
        }

        /// <summary>
        /// Creates a <see cref="DbStringFunctionExpression"/> that converts the result of the <paramref name="expression"/> to an 'lower' textual representation.
        /// </summary>
        /// <param name="expression">The <see cref="DbExpression"/> that represents the string to convert.</param>
        /// <returns>A <see cref="DbStringFunctionExpression"/> instance.</returns>
        public DbStringFunctionExpression ToLower(DbExpression expression)
        {
            return MakeStringFunction(DbStringFunctionExpressionType.ToLower, new[] { expression });            
        }

        /// <summary>
        /// Creates a <see cref="DbStringFunctionExpression"/> that returns the length of the  <paramref name="expression"/>.
        /// </summary>
        /// <param name="expression">The <see cref="DbExpression"/> that represents the string to convert.</param>
        /// <returns>A <see cref="DbStringFunctionExpression"/> instance.</returns>
        public DbStringFunctionExpression Length(DbExpression expression)
        {
            return MakeStringFunction(DbStringFunctionExpressionType.Length, new[] { expression });            
        }

        /// <summary>
        /// Creates a <see cref="DbStringFunctionExpression"/> that represents removing all leading and trailing 
        /// spaces from a string. 
        /// </summary>
        /// <param name="expression">The <see cref="DbExpression"/> that represents the string to trim.</param>
        /// <returns>A <see cref="DbStringFunctionExpression"/> instance.</returns>
        public DbStringFunctionExpression Trim(DbExpression expression)
        {
            return MakeStringFunction(DbStringFunctionExpressionType.Trim, new[] { expression });            
        }

        /// <summary>
        /// Creates a <see cref="DbStringFunctionExpression"/> that represents removing all trailing 
        /// spaces from a string. 
        /// </summary>
        /// <param name="expression">The <see cref="DbExpression"/> that represents the string to trim.</param>
        /// <returns>A <see cref="DbStringFunctionExpression"/> instance.</returns>
        public DbStringFunctionExpression TrimEnd(DbExpression expression)
        {
            return MakeStringFunction(DbStringFunctionExpressionType.TrimEnd, new[] { expression });            
        }

        /// <summary>
        /// Creates a <see cref="DbStringFunctionExpression"/> that represents removing all leading
        /// spaces from a string. 
        /// </summary>
        /// <param name="expression">The <see cref="DbExpression"/> that represents the string to trim.</param>
        /// <returns>A <see cref="DbStringFunctionExpression"/> instance.</returns>
        public DbStringFunctionExpression TrimStart(DbExpression expression)
        {
            return MakeStringFunction(DbStringFunctionExpressionType.TrimStart, new[] { expression });            
        }

        /// <summary>
        /// Creates a <see cref="DbStringFunctionExpression"/> that represents replacing 
        /// all occurrences of a specified string value with another string value.
        /// </summary>
        /// <param name="expression">The <see cref="DbExpression"/> that represents target string.</param>
        /// <param name="oldValue">The value to be replaced.</param>
        /// <param name="newValue">The value to replace all occurrences of <paramref name="oldValue"/>.</param>
        /// <returns>A <see cref="DbStringFunctionExpression"/> instance.</returns>
        public DbStringFunctionExpression Replace(DbExpression expression, DbExpression oldValue, DbExpression newValue)
        {
            return MakeStringFunction(DbStringFunctionExpressionType.Replace, new[] { expression, oldValue, newValue });                        
        }

        /// <summary>
        /// Creates a <see cref="DbStringFunctionExpression"/> that represents reversing a string value.         
        /// </summary>
        /// <param name="expression">The <see cref="DbExpression"/> to convert.</param>
        /// <returns>A <see cref="DbStringFunctionExpression"/> instance.</returns>
        public DbStringFunctionExpression Reverse(DbExpression expression)
        {
            return MakeStringFunction(DbStringFunctionExpressionType.Reverse, new[] { expression });
        }

        /// <summary>
        /// Creates a <see cref="DbStringFunctionExpression"/> that represents returning a four-character code to evaluate the similarity 
        /// of two strings.
        /// </summary>
        /// <param name="expression">The <see cref="DbExpression"/> that represents the string for which to return the SoundEx code.</param>
        /// <returns>A <see cref="DbStringFunctionExpression"/> instance.</returns>
        public DbStringFunctionExpression SoundEx(DbExpression expression)
        {
            return MakeStringFunction(DbStringFunctionExpressionType.SoundEx, new[] { expression });
        }

        /// <summary>
        /// Creates a <see cref="DbStringFunctionExpression"/> that represents returning the substring from a string. 
        /// </summary>
        /// <param name="expression">The <see cref="DbExpression"/> that represents the string for which to return the substring.</param>
        /// <param name="startExpression">The <see cref="DbExpression"/> that represents the staring position.</param>
        /// <param name="lengthExpression">The <see cref="DbExpression"/> that represents the length of the sub string.</param>
        /// <returns>A <see cref="DbStringFunctionExpression"/> instance.</returns>
        public DbStringFunctionExpression SubString(DbExpression expression, DbExpression startExpression, DbExpression lengthExpression)
        {
            return MakeStringFunction(DbStringFunctionExpressionType.SubString, new[] { expression, startExpression, lengthExpression });
        }

        #endregion

        #region DateTime Functions

        /// <summary>
        /// Creates a new <see cref="DbDateTimeFunctionExpression"/>.
        /// </summary>
        /// <param name="dateTimeFunctionExpressionType">The <see cref="DbDateTimeFunctionExpressionType"/> that specifies the type of <see cref="DbDateTimeFunctionExpression"/> to create.</param>
        /// <param name="arguments">A list of <see cref="DbExpression"/> instances that is used as arguments when calling the function.</param>
        /// <returns>A <see cref="DbDateTimeFunctionExpression"/> instance.</returns>
        public DbDateTimeFunctionExpression MakeDateTimeFunction(DbDateTimeFunctionExpressionType dateTimeFunctionExpressionType, DbExpression[] arguments)
        {
            var dateTimeFunctionExpression = new DbDateTimeFunctionExpression(dateTimeFunctionExpressionType, arguments);
            return dateTimeFunctionExpression;
        }

        /// <summary>
        /// Creates a <see cref="DbDateTimeFunctionExpression"/> that represents adding the specified number of years
        /// to the <paramref name="target"/> date time.
        /// </summary>
        /// <param name="target">A <see cref="DbExpression"/> that represents the target date time.</param>
        /// <param name="numberExpression">A <see cref="DbExpression"/> that represents the number of years to add.</param>
        /// <returns>A <see cref="DbDateTimeFunctionExpression"/> instance.</returns>
        public DbDateTimeFunctionExpression AddYears(DbExpression target, DbExpression numberExpression)
        {
            return MakeDateTimeFunction(DbDateTimeFunctionExpressionType.AddYears, new[] { target, numberExpression });
        }

        /// <summary>
        /// Creates a <see cref="DbDateTimeFunctionExpression"/> that represents adding the specified number of months
        /// to the <paramref name="target"/> date time.
        /// </summary>
        /// <param name="target">A <see cref="DbExpression"/> that represents the target date time.</param>
        /// <param name="numberExpression">A <see cref="DbExpression"/> that represents the number of months to add.</param>
        /// <returns>A <see cref="DbDateTimeFunctionExpression"/> instance.</returns>
        public DbDateTimeFunctionExpression AddMonths(DbExpression target, DbExpression numberExpression)
        {
            return MakeDateTimeFunction(DbDateTimeFunctionExpressionType.AddMonths, new[] { target, numberExpression });
        }

        /// <summary>
        /// Creates a <see cref="DbDateTimeFunctionExpression"/> that represents adding the specified number of days
        /// to the <paramref name="target"/> date time.
        /// </summary>
        /// <param name="target">A <see cref="DbExpression"/> that represents the target date time.</param>
        /// <param name="numberExpression">A <see cref="DbExpression"/> that represents the number of days to add.</param>
        /// <returns>A <see cref="DbDateTimeFunctionExpression"/> instance.</returns>
        public DbDateTimeFunctionExpression AddDays(DbExpression target, DbExpression numberExpression)
        {
            return MakeDateTimeFunction(DbDateTimeFunctionExpressionType.AddDays, new[] { target, numberExpression });
        }

        /// <summary>
        /// Creates a <see cref="DbDateTimeFunctionExpression"/> that represents adding the specified number of hours
        /// to the <paramref name="target"/> date time.
        /// </summary>
        /// <param name="target">A <see cref="DbExpression"/> that represents the target date time.</param>
        /// <param name="numberExpression">A <see cref="DbExpression"/> that represents the number of hours to add.</param>
        /// <returns>A <see cref="DbDateTimeFunctionExpression"/> instance.</returns>
        public DbDateTimeFunctionExpression AddHours(DbExpression target, DbExpression numberExpression)
        {
            return MakeDateTimeFunction(DbDateTimeFunctionExpressionType.AddHours, new[] { target, numberExpression });
        }

        /// <summary>
        /// Creates a <see cref="DbDateTimeFunctionExpression"/> that represents adding the specified number of minutes
        /// to the <paramref name="target"/> date time.
        /// </summary>
        /// <param name="target">A <see cref="DbExpression"/> that represents the target date time.</param>
        /// <param name="numberExpression">A <see cref="DbExpression"/> that represents the number of minutes to add.</param>
        /// <returns>A <see cref="DbDateTimeFunctionExpression"/> instance.</returns>
        public DbDateTimeFunctionExpression AddMinutes(DbExpression target, DbExpression numberExpression)
        {
            return MakeDateTimeFunction(DbDateTimeFunctionExpressionType.AddMinutes, new[] { target, numberExpression });
        }

        /// <summary>
        /// Creates a <see cref="DbDateTimeFunctionExpression"/> that represents adding the specified number of seconds
        /// to the <paramref name="target"/> date time.
        /// </summary>
        /// <param name="target">A <see cref="DbExpression"/> that represents the target date time.</param>
        /// <param name="numberExpression">A <see cref="DbExpression"/> that represents the number of seconds to add.</param>
        /// <returns>A <see cref="DbDateTimeFunctionExpression"/> instance.</returns>
        public DbDateTimeFunctionExpression AddSeconds(DbExpression target, DbExpression numberExpression)
        {
            return MakeDateTimeFunction(DbDateTimeFunctionExpressionType.AddSeconds, new[] { target, numberExpression });
        }

        /// <summary>
        /// Creates a <see cref="DbDateTimeFunctionExpression"/> that represents adding the specified number of milliseconds
        /// to the <paramref name="target"/> date time.
        /// </summary>
        /// <param name="target">A <see cref="DbExpression"/> that represents the target date time.</param>
        /// <param name="numberExpression">A <see cref="DbExpression"/> that represents the number of milliseconds to add.</param>
        /// <returns>A <see cref="DbDateTimeFunctionExpression"/> instance.</returns>
        public DbDateTimeFunctionExpression AddMilliseconds(DbExpression target, DbExpression numberExpression)
        {
            return MakeDateTimeFunction(DbDateTimeFunctionExpressionType.AddMilliseconds, new[] { target, numberExpression });
        }

        /// <summary>
        /// Creates a <see cref="DbDateTimeFunctionExpression"/> that represents returning the date portion of a date time value.        
        /// </summary>
        /// <param name="target">A <see cref="DbExpression"/> that represents the target date time.</param>        
        /// <returns>A <see cref="DbDateTimeFunctionExpression"/> instance.</returns>
        public DbDateTimeFunctionExpression Date(DbExpression target)
        {
            return MakeDateTimeFunction(DbDateTimeFunctionExpressionType.Date, new[] { target });
        }

        /// <summary>
        /// Creates a <see cref="DbDateTimeFunctionExpression"/> that represents returning the day of the month.
        /// </summary>
        /// <param name="target">A <see cref="DbExpression"/> that represents the target date time.</param>        
        /// <returns>A <see cref="DbDateTimeFunctionExpression"/> instance.</returns>
        public DbDateTimeFunctionExpression DayOfMonth(DbExpression target)
        {
            return MakeDateTimeFunction(DbDateTimeFunctionExpressionType.DayOfMonth, new[] { target });
        }

        /// <summary>
        /// Creates a <see cref="DbDateTimeFunctionExpression"/> that represents returning the day of the week.
        /// </summary>
        /// <param name="target">A <see cref="DbExpression"/> that represents the target date time.</param>        
        /// <returns>A <see cref="DbDateTimeFunctionExpression"/> instance.</returns>
        public DbDateTimeFunctionExpression DayOfWeek(DbExpression target)
        {
            return MakeDateTimeFunction(DbDateTimeFunctionExpressionType.DayOfWeek, new[] { target });
        }

        /// <summary>
        /// Creates a <see cref="DbDateTimeFunctionExpression"/> that represents returning the day of the year.
        /// </summary>
        /// <param name="target">A <see cref="DbExpression"/> that represents the target date time.</param>        
        /// <returns>A <see cref="DbDateTimeFunctionExpression"/> instance.</returns>
        public DbDateTimeFunctionExpression DayOfYear(DbExpression target)
        {
            return MakeDateTimeFunction(DbDateTimeFunctionExpressionType.DayOfYear, new[] { target });
        }

        /// <summary>
        /// Creates a <see cref="DbDateTimeFunctionExpression"/> that represents returning year component of a date/time value.
        /// </summary>
        /// <param name="target">A <see cref="DbExpression"/> that represents the target date time.</param>        
        /// <returns>A <see cref="DbDateTimeFunctionExpression"/> instance.</returns>
        public DbDateTimeFunctionExpression Year(DbExpression target)
        {
            return MakeDateTimeFunction(DbDateTimeFunctionExpressionType.Year, new[] { target });
        }

        /// <summary>
        /// Creates a <see cref="DbDateTimeFunctionExpression"/> that represents returning month component of a date/time value.
        /// </summary>
        /// <param name="target">A <see cref="DbExpression"/> that represents the target date time.</param>        
        /// <returns>A <see cref="DbDateTimeFunctionExpression"/> instance.</returns>
        public DbDateTimeFunctionExpression Month(DbExpression target)
        {
            return MakeDateTimeFunction(DbDateTimeFunctionExpressionType.Month, new[] { target });
        }        

        /// <summary>
        /// Creates a <see cref="DbDateTimeFunctionExpression"/> that represents returning hour component of a date/time value.
        /// </summary>
        /// <param name="target">A <see cref="DbExpression"/> that represents the target date time.</param>        
        /// <returns>A <see cref="DbDateTimeFunctionExpression"/> instance.</returns>
        public DbDateTimeFunctionExpression Hour(DbExpression target)
        {
            return MakeDateTimeFunction(DbDateTimeFunctionExpressionType.Hour, new[] { target });
        }

        /// <summary>
        /// Creates a <see cref="DbDateTimeFunctionExpression"/> that represents returning minute component of a date/time value.
        /// </summary>
        /// <param name="target">A <see cref="DbExpression"/> that represents the target date time.</param>        
        /// <returns>A <see cref="DbDateTimeFunctionExpression"/> instance.</returns>
        public DbDateTimeFunctionExpression Minute(DbExpression target)
        {
            return MakeDateTimeFunction(DbDateTimeFunctionExpressionType.Minute, new[] { target });
        }

        /// <summary>
        /// Creates a <see cref="DbDateTimeFunctionExpression"/> that represents returning second component of a date/time value.
        /// </summary>
        /// <param name="target">A <see cref="DbExpression"/> that represents the target date time.</param>        
        /// <returns>A <see cref="DbDateTimeFunctionExpression"/> instance.</returns>
        public DbDateTimeFunctionExpression Second(DbExpression target)
        {
            return MakeDateTimeFunction(DbDateTimeFunctionExpressionType.Second, new[] { target });
        }

        /// <summary>
        /// Creates a <see cref="DbDateTimeFunctionExpression"/> that represents returning millisecond component of a date/time value.
        /// </summary>
        /// <param name="target">A <see cref="DbExpression"/> that represents the target date time.</param>        
        /// <returns>A <see cref="DbDateTimeFunctionExpression"/> instance.</returns>
        public DbDateTimeFunctionExpression Millisecond(DbExpression target)
        {
            return MakeDateTimeFunction(DbDateTimeFunctionExpressionType.MilliSecond, new[] { target });
        }

        /// <summary>
        /// Creates a <see cref="DbDateTimeFunctionExpression"/> that represents returning the current date.
        /// </summary>
        /// <returns>A <see cref="DbDateTimeFunctionExpression"/> instance.</returns>
        public DbDateTimeFunctionExpression ToDay()
        {
            return MakeDateTimeFunction(DbDateTimeFunctionExpressionType.ToDay, new DbExpression[] { });                                    
        }

        /// <summary>
        /// Creates a <see cref="DbDateTimeFunctionExpression"/> that represents returning the current date and time.
        /// </summary>
        /// <returns>A <see cref="DbDateTimeFunctionExpression"/> instance.</returns>
        public DbDateTimeFunctionExpression Now()
        {
            return MakeDateTimeFunction(DbDateTimeFunctionExpressionType.Now, new DbExpression[] { });
        }

        #endregion

        #region Mathematical Functions

        /// <summary>
        /// Creates a new <see cref="DbDateTimeFunctionExpression"/>.
        /// </summary>
        /// <param name="mathematicalFunctionExpressionType">The <see cref="DbMathematicalFunctionExpressionType"/> that specifies the type of <see cref="DbMathematicalFunctionExpression"/> to create.</param>
        /// <param name="arguments">A list of <see cref="DbExpression"/> instances that is used as arguments when calling the function.</param>
        /// <returns>A <see cref="DbMathematicalFunctionExpression"/> instance.</returns>
        public DbMathematicalFunctionExpression MakeMathematicalFunction(DbMathematicalFunctionExpressionType mathematicalFunctionExpressionType, DbExpression[] arguments)
        {
            var mathematicalFunctionExpression = new DbMathematicalFunctionExpression(mathematicalFunctionExpressionType, arguments);
            return mathematicalFunctionExpression;
        }

        /// <summary>
        /// Creates a <see cref="DbMathematicalFunctionExpression"/> that represents returning 
        /// the absolute (positive) value of the specified numeric expression.
        /// </summary>
        /// <param name="target">The target <see cref="DbExpression"/> that represents a numeric value.</param>
        /// <returns>A <see cref="DbMathematicalFunctionExpression"/> instance.</returns>
        public DbMathematicalFunctionExpression Abs(DbExpression target)
        {
            return MakeMathematicalFunction(DbMathematicalFunctionExpressionType.Abs, new[] { target });
        }

        /// <summary>
        /// Creates a <see cref="DbMathematicalFunctionExpression"/> that represents returning 
        /// the angle, in radians, whose cosine is the specified float expression; also called arccosine.
        /// </summary>
        /// <param name="target">The target <see cref="DbExpression"/> that represents a numeric value.</param>
        /// <returns>A <see cref="DbMathematicalFunctionExpression"/> instance.</returns>
        public DbMathematicalFunctionExpression Acos(DbExpression target)
        {
            return MakeMathematicalFunction(DbMathematicalFunctionExpressionType.Acos, new[] { target });
        }

        /// <summary>
        /// Creates a <see cref="DbMathematicalFunctionExpression"/> that represents returning 
        /// the angle, in radians, whose cosine is the specified float expression; also called arccosine.
        /// </summary>
        /// <param name="target">The target <see cref="DbExpression"/> that represents a numeric value.</param>
        /// <returns>A <see cref="DbMathematicalFunctionExpression"/> instance.</returns>
        public DbMathematicalFunctionExpression Asin(DbExpression target)
        {
            return MakeMathematicalFunction(DbMathematicalFunctionExpressionType.Asin, new[] { target });
        }

        /// <summary>
        /// Creates a <see cref="DbMathematicalFunctionExpression"/> that represents returning 
        /// the angle in radians whose tangent is a specified float expression. This is also called arctangent.
        /// </summary>
        /// <param name="expression">The target <see cref="DbExpression"/> that represents a numeric value.</param>
        /// <returns>A <see cref="DbMathematicalFunctionExpression"/> instance.</returns>
        public DbMathematicalFunctionExpression Atan(DbExpression expression)
        {
            return MakeMathematicalFunction(DbMathematicalFunctionExpressionType.Atan, new[] { expression });
        }

        /// <summary>
        /// Creates a <see cref="DbMathematicalFunctionExpression"/> that represents returning 
        /// the angle, in radians, between the positive x-axis and the ray from the origin to the point (y, x), 
        /// where x and y are the values of the two specified float expressions.
        /// </summary>
        /// <param name="x">A <see cref="DbExpression"/> that represents a numeric value (x).</param>
        /// <param name="y">A <see cref="DbExpression"/> that represents a numeric value (y).</param>
        /// <returns>A <see cref="DbMathematicalFunctionExpression"/> instance.</returns>
        public DbMathematicalFunctionExpression Atan2(DbExpression x, DbExpression y)
        {
            return MakeMathematicalFunction(DbMathematicalFunctionExpressionType.Atan2, new[] { x, y });
        }

        /// <summary>
        /// Creates a <see cref="DbMathematicalFunctionExpression"/> that represents returning 
        /// the smallest integer greater than, or equal to, the specified numeric expression.
        /// </summary>
        /// <param name="target">The target <see cref="DbExpression"/> that represents a numeric value.</param>
        /// <returns>A <see cref="DbMathematicalFunctionExpression"/> instance.</returns>
        public DbMathematicalFunctionExpression Ceiling(DbExpression target)
        {
            return MakeMathematicalFunction(DbMathematicalFunctionExpressionType.Ceiling, new[] { target });
        }

        /// <summary>
        /// Creates a <see cref="DbMathematicalFunctionExpression"/> that represents returning 
        /// the trigonometric cosine of the specified angle, in radians, in the specified expression.
        /// </summary>
        /// <param name="target">The target <see cref="DbExpression"/> that represents a numeric value.</param>
        /// <returns>A <see cref="DbMathematicalFunctionExpression"/> instance.</returns>
        public DbMathematicalFunctionExpression Cos(DbExpression target)
        {
            return MakeMathematicalFunction(DbMathematicalFunctionExpressionType.Cos, new[] { target });
        }

        /// <summary>
        /// Creates a <see cref="DbMathematicalFunctionExpression"/> that represents returning 
        /// the trigonometric cotangent of the specified angle, in radians, in the specified float expression.
        /// </summary>
        /// <param name="target">The target <see cref="DbExpression"/> that represents a numeric value.</param>
        /// <returns>A <see cref="DbMathematicalFunctionExpression"/> instance.</returns>
        public DbMathematicalFunctionExpression Cot(DbExpression target)
        {
            return MakeMathematicalFunction(DbMathematicalFunctionExpressionType.Cot, new[] { target });
        }

        /// <summary>
        /// Creates a <see cref="DbMathematicalFunctionExpression"/> that represents returning 
        /// the corresponding angle in degrees for an angle specified in radians.
        /// </summary>
        /// <param name="target">The target <see cref="DbExpression"/> that represents a numeric value.</param>
        /// <returns>A <see cref="DbMathematicalFunctionExpression"/> instance.</returns>
        public DbMathematicalFunctionExpression Degrees(DbExpression target)
        {
            return MakeMathematicalFunction(DbMathematicalFunctionExpressionType.Degrees, new[] { target });
        }

        /// <summary>
        /// Creates a <see cref="DbMathematicalFunctionExpression"/> that represents returning 
        /// the exponential value of the specified float expression.
        /// </summary>
        /// <param name="target">The target <see cref="DbExpression"/> that represents a numeric value.</param>
        /// <returns>A <see cref="DbMathematicalFunctionExpression"/> instance.</returns>
        public DbMathematicalFunctionExpression Exp(DbExpression target)
        {
            return MakeMathematicalFunction(DbMathematicalFunctionExpressionType.Exp, new[] { target });
        }

        /// <summary>
        /// Creates a <see cref="DbMathematicalFunctionExpression"/> that represents returning 
        /// the largest integer less than or equal to the specified numeric expression.
        /// </summary>
        /// <param name="target">The target <see cref="DbExpression"/> that represents a numeric value.</param>
        /// <returns>A <see cref="DbMathematicalFunctionExpression"/> instance.</returns>
        public DbMathematicalFunctionExpression Floor(DbExpression target)
        {
            return MakeMathematicalFunction(DbMathematicalFunctionExpressionType.Floor, new[] { target });
        }

        /// <summary>
        /// Creates a <see cref="DbMathematicalFunctionExpression"/> that represents returning 
        /// the natural logarithm of the specified float expression.
        /// </summary>
        /// <param name="target">The target <see cref="DbExpression"/> that represents a numeric value.</param>
        /// <returns>A <see cref="DbMathematicalFunctionExpression"/> instance.</returns>
        public DbMathematicalFunctionExpression Log(DbExpression target)
        {
            return MakeMathematicalFunction(DbMathematicalFunctionExpressionType.Log, new[] { target });
        }

        /// <summary>
        /// Creates a <see cref="DbMathematicalFunctionExpression"/> that represents returning 
        /// the base-10 logarithm of the specified float expression.
        /// </summary>
        /// <param name="target">The target <see cref="DbExpression"/> that represents a numeric value.</param>
        /// <returns>A <see cref="DbMathematicalFunctionExpression"/> instance.</returns>
        public DbMathematicalFunctionExpression Log10(DbExpression target)
        {
            return MakeMathematicalFunction(DbMathematicalFunctionExpressionType.Log10, new[] { target });
        }

        /// <summary>
        /// Creates a <see cref="DbMathematicalFunctionExpression"/> that represents returning the constant value of PI.        
        /// </summary>        
        /// <returns>A <see cref="DbMathematicalFunctionExpression"/> instance.</returns>
        public DbMathematicalFunctionExpression PI()
        {
            return MakeMathematicalFunction(DbMathematicalFunctionExpressionType.PI, new DbExpression[] { });
        }

        /// <summary>
        /// Creates a <see cref="DbMathematicalFunctionExpression"/> that represents returning 
        /// the value of the specified expression to the specified power.
        /// </summary>
        /// <param name="target">The target <see cref="DbExpression"/> that represents a numeric value.</param>
        /// <param name="y">The power to which to raise the numeric value.</param>
        /// <returns>A <see cref="DbMathematicalFunctionExpression"/> instance.</returns>
        public DbMathematicalFunctionExpression Power(DbExpression target, DbExpression y)
        {
            return MakeMathematicalFunction(DbMathematicalFunctionExpressionType.Power, new[] { target, y });
        }

        /// <summary>
        /// Creates a <see cref="DbMathematicalFunctionExpression"/> that represents returning 
        /// the radians of the specified numeric expression.
        /// </summary>
        /// <param name="target">The target <see cref="DbExpression"/> that represents a numeric value.</param>
        /// <returns>A <see cref="DbMathematicalFunctionExpression"/> instance.</returns>
        public DbMathematicalFunctionExpression Radians(DbExpression target)
        {
            return MakeMathematicalFunction(DbMathematicalFunctionExpressionType.Radians, new[] { target });
        }

        /// <summary>
        /// Creates a <see cref="DbMathematicalFunctionExpression"/> that represents returning 
        /// a pseudo-random float value from 0 through 1, exclusive.
        /// </summary>
        /// <param name="seed">The target <see cref="DbExpression"/> that represents the seed value.</param>
        /// <returns>A <see cref="DbMathematicalFunctionExpression"/> instance.</returns>
        public DbMathematicalFunctionExpression Rand(DbExpression seed)
        {
            return MakeMathematicalFunction(DbMathematicalFunctionExpressionType.RandSeed, new[] { seed });
        }

        /// <summary>
        /// Creates a <see cref="DbMathematicalFunctionExpression"/> that represents returning 
        /// a pseudo-random float value from 0 through 1, exclusive.
        /// </summary>        
        /// <returns>A <see cref="DbMathematicalFunctionExpression"/> instance.</returns>
        public DbMathematicalFunctionExpression Rand()
        {
            return MakeMathematicalFunction(DbMathematicalFunctionExpressionType.Rand, new DbExpression[] { });
        }

        /// <summary>
        /// Creates a <see cref="DbMathematicalFunctionExpression"/> that represents returning 
        /// a pseudo-random float value from 0 through 1, exclusive.
        /// </summary>        
        /// <param name="target">The target <see cref="DbExpression"/> that represents a numeric value.</param>
        /// <param name="precision">A <see cref="DbExpression"/> that represents the number of decimals returned.</param>
        /// <returns>A <see cref="DbMathematicalFunctionExpression"/> instance.</returns>
        public DbMathematicalFunctionExpression Round(DbExpression target, DbExpression precision)
        {
            return MakeMathematicalFunction(DbMathematicalFunctionExpressionType.Round, new[] { target, precision });
        }

        /// <summary>
        /// Creates a <see cref="DbMathematicalFunctionExpression"/> that represents returning the  
        /// positive (+1), zero (0), or negative (-1) sign of the specified expression.
        /// </summary>        
        /// <param name="target">The target <see cref="DbExpression"/> that represents a numeric value.</param>
        /// <returns>A <see cref="DbMathematicalFunctionExpression"/> instance.</returns>
        public DbMathematicalFunctionExpression Sign(DbExpression target)
        {
            return MakeMathematicalFunction(DbMathematicalFunctionExpressionType.Sign, new[] { target });
        }

        /// <summary>
        /// Creates a <see cref="DbMathematicalFunctionExpression"/> that represents returning 
        /// the trigonometric sine of the specified angle, in radians, and in an approximate numeric, float, expression.
        /// </summary>        
        /// <param name="target">The target <see cref="DbExpression"/> that represents a numeric value.</param>
        /// <returns>A <see cref="DbMathematicalFunctionExpression"/> instance.</returns>
        public DbMathematicalFunctionExpression Sin(DbExpression target)
        {
            return MakeMathematicalFunction(DbMathematicalFunctionExpressionType.Sin, new[] { target });
        }

        /// <summary>
        /// Creates a <see cref="DbMathematicalFunctionExpression"/> that represents returning 
        /// the square root of the specified float value.
        /// </summary>        
        /// <param name="target">The target <see cref="DbExpression"/> that represents a numeric value.</param>
        /// <returns>A <see cref="DbMathematicalFunctionExpression"/> instance.</returns>
        public DbMathematicalFunctionExpression Sqrt(DbExpression target)
        {
            return MakeMathematicalFunction(DbMathematicalFunctionExpressionType.Sqrt, new[] { target });
        }

        /// <summary>
        /// Creates a <see cref="DbMathematicalFunctionExpression"/> that represents returning 
        /// the square of the specified float value.
        /// </summary>        
        /// <param name="target">The target <see cref="DbExpression"/> that represents a numeric value.</param>
        /// <returns>A <see cref="DbMathematicalFunctionExpression"/> instance.</returns>
        public DbMathematicalFunctionExpression Square(DbExpression target)
        {
            return MakeMathematicalFunction(DbMathematicalFunctionExpressionType.Square, new[] { target });
        }

        /// <summary>
        /// Creates a <see cref="DbMathematicalFunctionExpression"/> that represents returning 
        /// the tangent of the input expression.
        /// </summary>        
        /// <param name="target">The target <see cref="DbExpression"/> that represents a numeric value.</param>
        /// <returns>A <see cref="DbMathematicalFunctionExpression"/> instance.</returns>
        public DbMathematicalFunctionExpression Tan(DbExpression target)
        {
            return MakeMathematicalFunction(DbMathematicalFunctionExpressionType.Tan, new[] { target });
        }

        #endregion  

        #region Language Constructs       
        /// <summary>
        /// Creates a new <see cref="DbColumnExpression"/>.
        /// </summary>
        /// <param name="columnName">The name of the column.</param>
        /// <returns>A <see cref="DbColumnExpression"/> instance.</returns>
        public DbColumnExpression Column(string columnName)
        {
            return new DbColumnExpression(columnName);
        }

        /// <summary>
        /// Creates a new <see cref="DbColumnExpression"/> that is wrapped inside a <see cref="DbPrefixExpression"/>.
        /// </summary>
        /// <param name="prefix">The column prefix.</param>
        /// <param name="columnName">The name of the column.</param>
        /// <returns>A <see cref="DbPrefixExpression"/> instance.</returns>
        public DbPrefixExpression Column(string prefix, string columnName)
        {
            var columnExpression = Column(columnName);
            var prefixExpression = Prefix(columnExpression, prefix);
            return prefixExpression;
        }

        /// <summary>
        /// Creates a new <see cref="DbColumnExpression"/>.
        /// </summary>
        /// <param name="tableName">The name of the table.</param>
        /// <returns>A <see cref="DbTableExpression"/> instance.</returns>
        public DbTableExpression Table(string tableName)
        {
            return new DbTableExpression(tableName);
        }

        /// <summary>
        /// Creates a new <see cref="DbTableExpression"/> that is wrapped inside a <see cref="DbAliasExpression"/>.
        /// </summary>
        /// <param name="tableName">The name of the table.</param>
        /// <param name="alias">The table alias.</param>
        /// <returns>A <see cref="DbAliasExpression"/> instance.</returns>
        public DbAliasExpression Table(string tableName, string alias)
        {
            var tableExpression = Table(tableName);
            var aliasExpression = Alias(tableExpression, alias);
            return aliasExpression;
        }

        /// <summary>
        /// Creates a new <see cref="DbJoinExpression"/>.
        /// </summary>
        /// <param name="joinType">The <see cref="DbJoinExpressionType"/> that specifies the type of join to create.</param>
        /// <param name="target">The join target.</param>
        /// <param name="condition">The join condition.</param>
        /// <returns>A <see cref="DbJoinExpression"/> instance.</returns>
        public DbJoinExpression MakeJoin(DbJoinExpressionType joinType, DbExpression target, DbExpression condition)
        {
            var joinExpression = new DbJoinExpression(joinType, target, condition);
            return joinExpression;
        }
        
        /// <summary>
        /// Create a new <see cref="DbJoinExpression"/> that represents an 'INNER JOIN'.
        /// </summary>
        /// <param name="target">The join target.</param>
        /// <param name="condition">The join condition.</param>
        /// <returns>A <see cref="DbJoinExpression"/> instance.</returns>
        public DbJoinExpression InnerJoin(DbExpression target, DbExpression condition)
        {
            return MakeJoin(DbJoinExpressionType.InnerJoin, target, condition);
        }

        /// <summary>
        /// Create a new <see cref="DbJoinExpression"/> that represents a 'LEFT OUTER JOIN'.
        /// </summary>
        /// <param name="target">The join target.</param>
        /// <param name="condition">The join condition.</param>
        /// <returns>A <see cref="DbJoinExpression"/> instance.</returns>
        public DbJoinExpression LeftOuterJoin(DbExpression target, DbExpression condition)
        {
            return MakeJoin(DbJoinExpressionType.LeftOuterJoin, target, condition);
        }

        /// <summary>
        /// Create a new <see cref="DbJoinExpression"/> that represents a 'RIGHT OUTER JOIN'.
        /// </summary>
        /// <param name="target">The join target.</param>
        /// <param name="condition">The join condition.</param>
        /// <returns>A <see cref="DbJoinExpression"/> instance.</returns>
        public DbJoinExpression RightOuterJoin(DbExpression target, DbExpression condition)
        {
            return MakeJoin(DbJoinExpressionType.RightOuterJoin, target, condition);
        }

        /// <summary>
        /// Creates a new <see cref="DbOrderByExpression"/> that represents ordering the result set.
        /// </summary>
        /// <param name="orderByExpressionType">The <see cref="DbOrderByExpressionType"/> that specifies the ordering direction.</param>
        /// <param name="expression">The <see cref="DbExpression"/> representing an element in the 'ORDER BY' clause.</param>        
        /// <returns>A <see cref="DbOrderByExpression"/> instance.</returns>        
        public DbOrderByExpression MakeOrderBy(DbOrderByExpressionType orderByExpressionType, DbExpression expression)
        {
            var dbOrderByExpression = new DbOrderByExpression
                                      { OrderByExpressionType = orderByExpressionType, Expression = expression };
            return dbOrderByExpression;
        }

        /// <summary>
        /// Creates a new <see cref="DbOrderByExpression"/> that represents an ascending ordering of the result set.
        /// </summary>
        /// <param name="expression">The <see cref="DbExpression"/> representing an element in the 'ORDER BY' clause.</param>        
        /// <returns>A <see cref="DbOrderByExpression"/> instance.</returns>        
        public DbOrderByExpression OrderByAscending(DbExpression expression)
        {
            return MakeOrderBy(DbOrderByExpressionType.Ascending, expression);
        }

        /// <summary>
        /// Creates a new <see cref="DbOrderByExpression"/> that represents an descending ordering of the result set.
        /// </summary>
        /// <param name="expression">The <see cref="DbExpression"/> representing an element in the 'ORDER BY' clause.</param>        
        /// <returns>A <see cref="DbOrderByExpression"/> instance.</returns>        
        public DbOrderByExpression OrderByDescending(DbExpression expression)
        {
            return MakeOrderBy(DbOrderByExpressionType.Descending, expression);
        }

        /// <summary>
        /// Creates a new <see cref="DbListExpression"/>.
        /// </summary>
        /// <returns>A <see cref="DbListExpression"/> instance.</returns>
        public DbListExpression List()
        {
            return new DbListExpression();
        }

        /// <summary>
        /// Creates a new <see cref="DbConditionalExpression"/>.
        /// </summary>
        /// <param name="condition">The <see cref="DbExpression"/> that is evaluated.</param>
        /// <param name="trueExpression">The <see cref="DbExpression"/> that is executed if the <paramref name="condition"/> evaluates to <b>true</b>.</param>
        /// <param name="falseExpression">The <see cref="DbExpression"/> that is executed if the <paramref name="condition"/> evaluates to <b>false</b>.</param>
        /// <returns>A <see cref="DbConditionalExpression"/> instance.</returns>
        public DbConditionalExpression Conditional(DbExpression condition, DbExpression trueExpression, DbExpression falseExpression)
        {
            var conditionalExpression = new DbConditionalExpression
                                        { Condition = condition, IfTrue = trueExpression, IfFalse = falseExpression };
            return conditionalExpression;
        }

        /// <summary>
        /// Creates a new <see cref="DbListExpression"/>.
        /// </summary>
        /// <param name="dbExpressions">A <see cref="IEnumerable{T}"/> that 
        /// contains <see cref="DbExpression"/> instances to be copied to the new list.</param>
        /// <returns>A <see cref="DbListExpression"/> instance.</returns>
        public DbListExpression List(IEnumerable<DbExpression> dbExpressions)
        {
            return new DbListExpression(dbExpressions);
        }

        /// <summary>
        /// Creates a new <see cref="DbBatchExpression"/>.
        /// </summary>
        /// <param name="dbExpressions">A <see cref="IEnumerable{T}"/> that 
        /// contains <see cref="DbExpression"/> instances to be copied represented by the <see cref="DbBatchExpression"/>.</param>
        /// <returns>A <see cref="DbBatchExpression"/> instance.</returns>
        public DbBatchExpression Batch(IEnumerable<DbExpression> dbExpressions)
        {
            return new DbBatchExpression(dbExpressions);
        }

        /// <summary>
        /// Creates a new <see cref="DbConstantExpression"/>.
        /// </summary>
        /// <param name="value">The value that this <see cref="DbConstantExpression"/> represents.</param>
        /// <returns>A <see cref="DbConstantExpression"/> instance.</returns>
        public DbConstantExpression Constant(object value)
        {
            return new DbConstantExpression(value);
        }

        /// <summary>
        /// Creates a new <see cref="DbAliasExpression"/>.
        /// </summary>
        /// <param name="target">The target <see cref="DbExpression"/> to be aliased.</param>        
        /// <param name="alias">the alias to be used to reference the <paramref name="target"/>.</param>
        /// <returns>A <see cref="DbAliasExpression"/> instance.</returns>
        public DbAliasExpression Alias(DbExpression target, string alias)
        {
            return new DbAliasExpression(target, alias);
        }

        /// <summary>
        /// Creates a new <see cref="DbPrefixExpression"/>.
        /// </summary>
        /// <param name="target">The target <see cref="DbExpression"/> to be aliased.</param>
        /// <param name="prefix">the prefix to be used to reference the <paramref name="target"/>.</param>
        /// <returns>A <see cref="DbPrefixExpression"/> instance.</returns>        
        public DbPrefixExpression Prefix(DbExpression target, string prefix)
        {
            return new DbPrefixExpression(target, prefix);
        }

        /// <summary>
        /// Creates a new <see cref="DbSelectQuery"/> that represents a sub query.
        /// </summary>
        /// <param name="expressionSelector">A <see cref="Func{T,TResult}"/> to specify the <see cref="DbExpression"/>.</param>
        /// <returns>A <see cref="DbSelectQuery"/> instance.</returns>
        public DbSelectQuery Select(params Func<DbExpressionFactory, DbExpression>[] expressionSelector)
        {
            return Select(List(expressionSelector.Select(e => e(this))));                        
        }

        /// <summary>
        /// Creates a new <see cref="DbSelectQuery"/> that represents a sub query.
        /// </summary>        
        /// <param name="expression">The <see cref="DbExpression"/> that represents the projection.</param>
        /// <returns>A <see cref="DbSelectQuery"/> instance.</returns>
        public DbSelectQuery Select(DbExpression expression)
        {
            var dbSelectQuery = new DbSelectQuery
                                    {
                                        QueryExpression =
                                            {
                                                IsSubQuery = true,
                                                ProjectionExpression = expression
                                            }
                                    };
            return dbSelectQuery;
        }

        /// <summary>
        /// Creates a new <see cref="DbSelectQuery"/> that represents a distinct sub query.
        /// </summary>
        /// <param name="expressionSelector">A <see cref="Func{T,TResult}"/> to specify the <see cref="DbExpression"/>.</param>
        /// <returns>A <see cref="DbSelectQuery"/> instance.</returns>
        public DbSelectQuery SelectDistinct(params Func<DbExpressionFactory, DbExpression>[] expressionSelector)
        {
            return SelectDistinct(List(expressionSelector.Select(e => e(this))));
        }

        /// <summary>
        /// Creates a new <see cref="DbSelectQuery"/> that represents a distinct sub query.
        /// </summary>        
        /// <param name="expression">The <see cref="DbExpression"/> that represents the projection.</param>
        /// <returns>A <see cref="DbSelectQuery"/> instance.</returns>
        public DbSelectQuery SelectDistinct(DbExpression expression)
        {
            var dbSelectQuery = new DbSelectQuery
            {
                QueryExpression =
                {
                    IsSubQuery = true,
                    IsDistinct = true,
                    ProjectionExpression = expression
                }
            };
            return dbSelectQuery;
        }

        /// <summary>
        /// Creates a new <see cref="DbConcatExpression"/>.
        /// </summary>
        /// <param name="leftExpression">The left operand of the concatenate operation.</param>
        /// <param name="rightExpression">The right operand of the concatenate operation.</param>
        /// <returns>A <see cref="DbConcatExpression"/> instance.</returns>
        public DbConcatExpression Concat(DbExpression leftExpression, DbExpression rightExpression)
        {
            var concatExpression = new DbConcatExpression
                                   { LeftExpression = leftExpression, RightExpression = rightExpression };
            return concatExpression;
        }

        /// <summary>
        /// Creates a new <see cref="DbExistsExpression"/>.
        /// </summary>
        /// <param name="subSelectQuery">The <see cref="DbQuery{TQueryExpression}"/> that is used as the sub query.</param>
        /// <returns>A <see cref="DbExistsExpression"/> instance.</returns>
        public DbExistsExpression Exists(DbQuery<DbSelectExpression> subSelectQuery)
        {
            return new DbExistsExpression(subSelectQuery.QueryExpression);
        }

        /// <summary>
        /// Creates a new <see cref="DbExistsExpression"/>.
        /// </summary>
        /// <param name="subQuerySelector">The <see cref="DbQuery{TQueryExpression}"/> that is used as the sub query.</param>
        /// <returns>A <see cref="DbExistsExpression"/>instance.</returns>
        public DbExistsExpression Exists(Func<DbExpressionFactory, DbQuery<DbSelectExpression>> subQuerySelector)
        {
            return Exists(subQuerySelector(this));
        }

        /// <summary>
        /// Creates a new <see cref="DbInExpression"/>.
        /// </summary>
        /// <param name="target">The target <see cref="DbExpression"/>.</param>
        /// <param name="values">A list of values to test for a match.</param>
        /// <returns>A <see cref="DbInExpression"/> instance.</returns>
        public DbInExpression In(DbExpression target, object[] values)
        {
            var expressions = values.Select(Constant).Cast<DbExpression>().ToList();
            var inExpression = In(target, List(expressions));
            return inExpression;
        }

        /// <summary>
        /// Creates a new <see cref="DbInExpression"/>.
        /// </summary>
        /// <param name="target">The target <see cref="DbExpression"/>.</param>
        /// <param name="selectQuery">A sub query that has a result set of one column.</param>
        /// <returns>A <see cref="DbInExpression"/> instance.</returns>
        public DbInExpression In(DbExpression target, DbQuery<DbSelectExpression> selectQuery)
        {            
            var inExpression = In(target, (DbExpression)selectQuery);
            return inExpression;
        }

        /// <summary>
        /// Creates a new <see cref="DbInExpression"/>.
        /// </summary>
        /// <param name="target">The target <see cref="DbExpression"/>.</param>
        /// <param name="expression">The <see cref="DbExpression"/> that represents a set of values or a sub query.</param>
        /// <returns>A <see cref="DbInExpression"/> instance.</returns>
        public DbInExpression In(DbExpression target, DbExpression expression)
        {
            var inExpression = new DbInExpression(target, expression);
            return inExpression;
        }
               
        /// <summary>
        /// Creates a new <see cref="DbUnaryExpression"/>.
        /// </summary>
        /// <param name="unaryExpressionType">The <see cref="DbUnaryExpressionType"/> that specifies the type of unary expression to create.</param>
        /// <param name="operand">The <see cref="DbExpression"/> that represents the unary operand.</param>
        /// <param name="targetType">The <see cref="Type"/> that specifies the type to convert to.</param>
        /// <returns>A <see cref="DbUnaryExpression"/> instance.</returns>
        public DbUnaryExpression MakeUnary(DbUnaryExpressionType unaryExpressionType, DbExpression operand, Type targetType)
        {
            var unaryExpression = new DbUnaryExpression(unaryExpressionType, operand, targetType);
            return unaryExpression;
        }

        /// <summary>
        /// Creates a new <see cref="DbUnaryExpression"/> that represents negating the result of a boolean <see cref="DbExpression"/>.
        /// </summary>
        /// <param name="operand">The <see cref="DbExpression"/> that represents the unary operand.</param>
        /// <returns>A <see cref="DbUnaryExpression"/> instance.</returns>
        public DbUnaryExpression Not(DbExpression operand)
        {
            return MakeUnary(DbUnaryExpressionType.Not, operand, null);
        }

        /// <summary>
        /// Creates a new <see cref="DbUnaryExpression"/> that represents a conversion operation.
        /// </summary>
        /// <param name="operand">The <see cref="DbExpression"/> that represents the unary operand.</param>
        /// <param name="targetType">The <see cref="Type"/> that specifies the type to convert to.</param>
        /// <returns>A <see cref="DbUnaryExpression"/> instance.</returns>
        public DbUnaryExpression Cast(DbExpression operand, Type targetType)
        {
            return MakeUnary(DbUnaryExpressionType.Cast, operand, targetType);
        }
       
        /// <summary>
        /// Creates a new <see cref="DbDeleteExpression"/> that represents delete statement.
        /// </summary>
        /// <param name="target">The <see cref="DbExpression"/> that represents the delete target.</param>
        /// <param name="fromExpression">The <see cref="DbExpression"/> that represents the 'FROM' clause of the query.</param>
        /// <param name="whereExpression">the <see cref="DbExpression"/> that represents the 'WHERE' clause of the query.</param>
        /// <returns>A <see cref="DbDeleteExpression"/> instance.</returns>
        public DbDeleteExpression Delete(DbExpression target, DbExpression fromExpression, DbExpression whereExpression)
        {
            var dbDeleteExpression = new
                DbDeleteExpression
                                         {
                                             Target = target,
                                             FromExpression = fromExpression,
                                             WhereExpression = whereExpression
                                         };
            return dbDeleteExpression;
        }

        /// <summary>
        /// Creates a new <see cref="DbSqlExpression"/> that represents the SQL 
        /// created when translating a <see cref="DbExpression"/> instance.
        /// </summary>
        /// <param name="sqlFragment">The SQL that this <see cref="DbSqlExpression"/> represents.</param>
        /// <returns>A <see cref="DbSqlExpression"/> instance.</returns>
        public DbSqlExpression Sql(string sqlFragment)
        {
            return new DbSqlExpression(sqlFragment);
        }
        #endregion
    }
}
