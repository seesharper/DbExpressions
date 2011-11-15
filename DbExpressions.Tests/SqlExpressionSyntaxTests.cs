using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DbExpressions.Tests
{
    //[TestClass]
    public class SqlExpressionSyntaxTests : DbExpressionSyntaxTests
    {
        protected override DbQueryTranslator QueryTranslator
        {
            get { return DbQueryTranslatorFactory.GetQueryTranslator("System.Data.SqlClient"); }
        }

        public override string AndExpressionSyntax
        {
            get { return "(@p0 AND @p1)"; }
        }

        public override string AddExpressionSyntax
        {
            get { return "(@p0 + @p1)"; }
        }

        public override string AliasExpressionSyntax
        {
            get { return "[SomeTable] AS t0"; }
        }

        public override string AssignExpressionSyntax
        {
            get { return "[SomeColumn] = @p0"; }
        }

        public override string AssignNullExpressionSyntax
        {
            get { return "[SomeColumn] = NULL"; }
        }

        public override string AvgExpressionSyntax
        {
            get { return "AVG([SomeColumn])"; }
        }

        public override string ColumnExpressionSyntax
        {
            get { return "[SomeColumn]"; }
        }

        public override string ConcatExpressionSyntax
        {
            get { return "[SomeTable] [SomeOtherTable]"; }
        }

        public override string ConditionalExpressionSyntax
        {
            get { return "CASE WHEN ([SomeColumn] = @p0) THEN @p1 ELSE @p2 END"; }
        }

        public override string ConstantExpressionSyntax
        {
            get { return "@p0"; }
        }

        public override string CountExpressionSyntax
        {
            get { return "COUNT([SomeColumn])"; }
        }

        public override string DivideExpressionSyntax
        {
            get { return "(@p0 / @p1)"; }
        }

        public override string EqualExpressionSyntax
        {
            get { return "([SomeColumn] = @p0)"; }
        }

        public override string ExistsExpressionSyntax
        {
            get { return "EXISTS(SELECT [SomeColumn] FROM [SomeTable])"; }
        }

        public override string GreaterThanExpressionSyntax
        {
            get { return "([SomeColumn] > @p0)"; }
        }


        public override string GreaterThanOrEqualExpressionSyntax
        {
            get { return "([SomeColumn] >= @p0)"; }
        }


        public override string InValueRangeExpressionSyntax
        {
            get { return "[SomeColumn] IN(@p0,@p1)"; }
        }

        public override string InSubQueryExpressionSyntax
        {
            get { return "[SomeColumn] IN(SELECT [SomeOtherColumn] FROM [SomeOtherTable])"; }
        }

        public override string InnerJoinExpressionSyntax
        {
            get { return "INNER JOIN [SomeTable] ON ([SomeColumn] = [SomeOtherColumn])"; }
        }

        public override string LeftOuterJoinExpressionSyntax
        {
            get { return "LEFT OUTER JOIN [SomeTable] ON ([SomeColumn] = [SomeOtherColumn])"; }
        }

        public override string RightOuterJoinExpressionSyntax
        {
            get { return "RIGHT OUTER JOIN [SomeTable] ON ([SomeColumn] = [SomeOtherColumn])"; }
        }

        public override string LengthExpressionSyntax
        {
            get { return "LEN([SomeColumn])"; }
        }

        public override string LessThanExpressionSyntax
        {
            get { return "([SomeColumn] < @p0)"; }
        }

        public override string LessThanOrEqualExpressionSyntax
        {
            get { return "([SomeColumn] <= @p0)"; }
        }

        public override string ListExpressionSyntax
        {
            get { return "[SomeColumn],[SomeOtherColumn]"; }
        }

        public override string BatchExpressionSyntax
        {
            get { return "[SomeColumn];[SomeOtherColumn];"; }
        }

        public override string MaxExpressionSyntax
        {
            get { return "MAX([SomeColumn])"; }
        }

        public override string MinExpressionSyntax
        {
            get { return "MIN([SomeColumn])"; }
        }

        public override string MultiplyExpressionSyntax
        {
            get { return "(@p0 * @p1)"; }
        }

        public override string SubstractExpressionSyntax
        {
            get { return "(@p0 - @p1)"; }
        }

        public override string NotExpressionSyntax
        {
            get { return "NOT ([SomeColumn] = @p0)"; }
        }

        public override string DistinctExpressionSyntax
        {
            get { return "SELECT DISTINCT [SomeColumn]"; }
        }

        public override string DistinctWithTopExpressionSyntax
        {
            get { return "SELECT DISTINCT TOP(@p0) [SomeColumn]"; }
        }

        public override string NotEqualExpressionSyntax
        {
            get { return "([SomeColumn] <> @p0)"; }
        }

        public override string OrExpressionSyntax
        {
            get { return "(@p0 OR @p1)"; }
        }

        public override string OrderByAscendingExpressionSyntax
        {
            get { return "[SomeColumn] ASC"; }
        }

        public override string OrderByDescendingExpressionSyntax
        {
            get { return "[SomeColumn] DESC"; }
        }

        public override string PrefixExpressionSyntax
        {
            get { return "[t0].[SomeColumn]"; }
        }

        public override string ReplaceExpressionSyntax
        {
            get { return "REPLACE([SomeColumn],@p0,@p1)"; }
        }

        public override string ReverseExpressionSyntax
        {
            get { return "REVERSE([SomeColumn])"; }
        }

        public override string SoundExExpressionSyntax
        {
            get { return "SOUNDEX([SomeColumn])"; }
        }

        public override string SumExpressionSyntax
        {
            get { return "SUM([SomeColumn])"; }
        }

        public override string TableExpressionSyntax
        {
            get { return "[SomeTable]"; }
        }

        public override string ToLowerExpressionSyntax
        {
            get { return "LOWER([SomeColumn])"; }
        }

        public override string ToUpperExpressionSyntax
        {
            get { return "UPPER([SomeColumn])"; }
        }

        public override string TrimExpressionSyntax
        {
            get { return "LTRIM(RTRIM([SomeColumn]))"; }
        }

        public override string TrimStartExpressionSyntax
        {
            get { return "LTRIM([SomeColumn])"; }
        }

        public override string TrimEndExpressionSyntax
        {
            get { return "RTRIM([SomeColumn])"; }
        }

        public override string SubStringExpressionSyntax
        {
            get { return "SUBSTR([SomeColumn],@p0,@p1)"; }
        }

        public override string DateExpressionSyntax
        {
            get { return "CONVERT(DATETIME,CONVERT(VARCHAR,[SomeColumn],102))"; }
        }

        public override string YearExpressionSyntax
        {
            get { return "DATEPART(year,[SomeColumn])"; }
        }

        public override string MonthExpressionSyntax
        {
            get { return "DATEPART(month,[SomeColumn])"; }
        }

        public override string HourExpressionSyntax
        {
            get { return "DATEPART(hour,[SomeColumn])"; }
        }

        public override string MinuteExpressionSyntax
        {
            get { return "DATEPART(minute,[SomeColumn])"; }
        }

        public override string SecondExpressionSyntax
        {
            get { return "DATEPART(second,[SomeColumn])"; }
        }

        public override string MillisecondExpressionSyntax
        {
            get { return "DATEPART(millisecond,[SomeColumn])"; }
        }

        public override string DayOfYearExpressionSyntax
        {
            get { return "DATEPART(dayofyear,[SomeColumn])"; }
        }

        public override string DayOfMonthExpressionSyntax
        {
            get { return "DATEPART(day,[SomeColumn])"; }
        }

        public override string DayOfWeekExpressionSyntax
        {
            get { return "DATEPART(weekday,[SomeColumn])"; }
        }

        public override string AddYearsExpressionSyntax
        {
            get { return "DATEADD(year,@p0,[SomeColumn])"; }
        }

        public override string AddMonthsExpressionSyntax
        {
            get { return "DATEADD(month,@p0,[SomeColumn])"; }
        }

        public override string AddDaysExpressionSyntax
        {
            get { return "DATEADD(day,@p0,[SomeColumn])"; }
        }

        public override string AddHoursExpressionSyntax
        {
            get { return "DATEADD(hour,@p0,[SomeColumn])"; }
        }

        public override string AddMinutesExpressionSyntax
        {
            get { return "DATEADD(minute,@p0,[SomeColumn])"; }
        }

        public override string AddSecondsExpressionSyntax
        {
            get { return "DATEADD(second,@p0,[SomeColumn])"; }
        }

        public override string AddMilliSecondsExpressionSyntax
        {
            get { return "DATEADD(millisecond,@p0,[SomeColumn])"; }
        }

        public override string NowExpressionSyntax
        {
            get { return "GETDATE()"; }
        }


        public override string ToDayExpressionSyntax
        {
            get { return "CONVERT(DATETIME,CONVERT(VARCHAR,GETDATE(),102))"; }
        }

        public override string UpdateExpressionSyntax
        {
            get { return "UPDATE [SomeTable] SET [SomeColumn] = @p0 WHERE ([SomeColumn] = @p1)"; }
        }

        public override string UpdateExpressionWithAliasedTargetSyntax
        {
            get { return "UPDATE [SomeTable] SET [SomeColumn] = @p0 FROM [SomeTable] AS t0 WHERE ([SomeColumn] = @p1)"; }
        }

        public override string UpdateExpressionWithFromClauseSyntax
        {
            get { return "UPDATE [SomeTable] SET [SomeColumn] = @p0 FROM [SomeTable] AS t0 INNER JOIN [SomeOtherTable] AS t1 ON ([t0].[Id] = [t1].[Id]) WHERE ([t0].[SomeColumn] = @p1)"; }
        }


        public override string InsertExpressionSyntax
        {
            get { return "INSERT INTO [SomeTable] ([SomeColumn]) VALUES(@p0)"; }
        }

        public override string DeleteExpressionSyntax
        {
            get { return "DELETE FROM [SomeTable] WHERE ([SomeColumn] = @p0)"; }
        }

        public override string DeleteExpressionWithAliasedTargetSyntax
        {
            get { return "DELETE t0 FROM [SomeTable] AS t0 WHERE ([t0].[SomeColumn] = @p0)"; }
        }

        public override string SelectExpressionSyntax
        {
            get { return "SELECT [SomeColumn] FROM [SomeTable]"; }
        }

        public override string SelectExpressionWithTakeSyntax
        {
            get { return "SELECT TOP(@p0) [SomeColumn] FROM [SomeTable]"; }
        }

        public override string SelectExpressionWithSkipSyntax
        {
            get
            {
                return "SELECT [SomeColumn] FROM (SELECT [SomeColumn], ROW_NUMBER() OVER (ORDER BY [SomeColumn]) AS [ROW_NUMBER] FROM [SomeTable] ) AS __numbered__result WHERE [ROW_NUMBER] > @p0 ORDER BY [ROW_NUMBER]";                    
            }
        }

        public override string SelectExpressionWithSkipAndTakeSyntax
        {
            get
            {
                return
                    "SELECT [SomeColumn] FROM (SELECT [SomeColumn], ROW_NUMBER() OVER (ORDER BY [SomeColumn]) AS [ROW_NUMBER] \r\nFROM \r\n\t[SomeTable] ) AS __numbered__result WHERE [ROW_NUMBER] BETWEEN @p0 + 1 AND @p0 + @p1 ORDER BY [ROW_NUMBER]";
            }
        }

        public override string SelectExpressionWithOrderBySyntax
        {
            get { return "SELECT [SomeColumn] FROM [SomeTable] ORDER BY [SomeColumn] ASC"; }
        }

        public override string SelectExpressionWithGroupBySyntax
        {
            get { return "SELECT [SomeColumn] FROM [SomeTable] GROUP BY [SomeColumn]"; }
        }

        public override string SelectExpressionWithGroupByHavingSyntax
        {
            get { return "SELECT [SomeColumn] FROM [SomeTable] GROUP BY [SomeColumn] HAVING ([SomeColumn] > @p0)"; }
        }

        public override string AbsExpressionSyntax
        {
            get { return "ABS([SomeColumn])"; }
        }

        public override string AcosExpressionSyntax
        {
            get { return "ACOS([SomeColumn])"; }
        }

        public override string AsinExpressionSyntax
        {
            get { return "ASIN([SomeColumn])"; }
        }

        public override string AtanExpressionSyntax
        {
            get { return "ATAN([SomeColumn])"; }
        }

        public override string Atan2ExpressionSyntax
        {
            get { return "ATAN2([SomeColumn])"; }
        }

        public override string CeilingExpressionSyntax
        {
            get { return "CEILING([SomeColumn])"; }
        }

        public override string CosExpressionSyntax
        {
            get { return "COS([SomeColumn])"; }
        }

        public override string CotExpressionSyntax
        {
            get { return "COT([SomeColumn])"; }
        }

        public override string DegressExpressionSyntax
        {
            get { return "DEGREES([SomeColumn])"; }
        }

        public override string ExpExpressionSyntax
        {
            get { return "EXP([SomeColumn])"; }
        }

        public override string FloorExpressionSyntax
        {
            get { return "FLOOR([SomeColumn])"; }
        }

        public override string LogExpressionSyntax
        {
            get { return "LOG([SomeColumn])"; }
        }

        public override string Log10ExpressionSyntax
        {
            get { return "LOG10([SomeColumn])"; }
        }

        public override string PIExpressionSyntax
        {
            get { return "PI()"; }
        }

        public override string PowerExpressionSyntax
        {
            get { return "POWER([SomeColumn],@p0)"; }
        }

        public override string RadiansExpressionSyntax
        {
            get { return "RADIANS([SomeColumn])"; }
        }

        public override string RandExpressionSyntax
        {
            get { return "RAND()"; }
        }

        public override string RandWithSeedExpressionSyntax
        {
            get { return "RAND(@p0)"; }
        }

        public override string RoundExpressionSyntax
        {
            get { return "ROUND([SomeColumn],@p0)"; }
        }

        public override string SignExpressionSyntax
        {
            get { return "SIGN([SomeColumn])"; }
        }

        public override string SinExpressionSyntax
        {
            get { return "SIN([SomeColumn])"; }
        }

        public override string SqrtExpressionSyntax
        {
            get { return "SQRT([SomeColumn])"; }
        }

        public override string SquareExpressionSyntax
        {
            get { return "SQUARE([SomeColumn])"; }
        }

        public override string TanExpressionSyntax
        {
            get { return "TAN([SomeColumn])"; }
        }

        public override string NullCheckEqualsExpressionSyntax
        {
            get { return "([SomeColumn] IS NULL)"; }
        }

        public override string NullCheckNotEqualsExpressionSyntax
        {
            get { return "([SomeColumn] IS NOT NULL)"; }
        }
    }
}
