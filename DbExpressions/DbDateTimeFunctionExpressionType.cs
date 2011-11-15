namespace DbExpressions
{
    /// <summary>
    /// Describes the node types that represents calling date/time functions.
    /// </summary>
    public enum DbDateTimeFunctionExpressionType
    {
        /// <summary>
        /// A node that represents adding the specified number of years to a date/time
        /// </summary>
        AddYears,
       
        /// <summary>
        /// A node that represents adding the specified number of months to a date/time
        /// </summary>
        AddMonths,

        /// <summary>
        /// A node that represents adding the specified number of days to a date/time
        /// </summary>
        AddDays,

        /// <summary>
        /// A node that represents adding the specified number of hours to a date/time
        /// </summary>       
        AddHours,

        /// <summary>
        /// A node that represents adding the specified number of minutes to a date/time
        /// </summary>
        AddMinutes,

        /// <summary>
        /// A node that represents adding the specified number of seconds to a date/time
        /// </summary>
        AddSeconds,
        
        /// <summary>
        /// A node that represents adding the specified number of milliseconds to a date/time
        /// </summary>
        AddMilliseconds,
        
        /// <summary>
        /// A node that represents returning the date component of a date/time value.
        /// </summary>
        Date,
        
        /// <summary>
        /// A node that represents returning the day of the month. 
        /// </summary>
        DayOfMonth,

        /// <summary>
        /// A node that represents returning the day of the week.
        /// </summary>
        DayOfWeek,

        /// <summary>
        /// A node that represents returning the day of the year.
        /// </summary>        
        DayOfYear,

        /// <summary>
        /// A node that represents returning the year component of a date/time value.
        /// </summary>        
        Year,
        
        /// <summary>
        /// A node that represents returning the month component of a date/time value.
        /// </summary>
        Month,
        
        /// <summary>
        /// A node that represents returning the hour component of a date/time value.
        /// </summary>        
        Hour,
        
        /// <summary>
        /// A node that represents returning the millisecond component of a date/time value.
        /// </summary>
        MilliSecond,

        /// <summary>
        /// A node that represents returning the minute component of a date/time value.
        /// </summary>
        Minute,
       
        /// <summary>
        /// A node that represents returning the current date and time.
        /// </summary>
        Now,
        
        /// <summary>
        /// A node that represents returning the second component of a date/time value.
        /// </summary>
        Second,

        /// <summary>
        /// A node that represents returning the current date.
        /// </summary>
        ToDay
    }
}
