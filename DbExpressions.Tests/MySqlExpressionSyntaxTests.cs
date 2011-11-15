using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DbExpressions.Tests
{
    //[TestClass]
    public class MySqlExpressionSyntaxTests : DbExpressionSyntaxTests
    {
        protected override DbQueryTranslator QueryTranslator
        {
            get { return DbQueryTranslatorFactory.GetQueryTranslator("MySql.Data.MySqlClient"); }
        }

        public override string AndExpressionSyntax
        {
            get { return "(?p0 AND ?p1)"; }
        }

        public override string AddExpressionSyntax
        {
            get { return "(?p0 + ?p1)"; }
        }

        public override string AliasExpressionSyntax
        {
            get { return "`SomeTable` AS t0"; }
        }

        public override string AssignExpressionSyntax
        {
            get { return "`SomeColumn` = ?p0"; }
        }

        public override string AssignNullExpressionSyntax
        {
            get { return "`SomeColumn` = NULL"; }
        }

        public override string AvgExpressionSyntax
        {
            get { return "AVG(`SomeColumn`)"; }
        }

        public override string ColumnExpressionSyntax
        {
            get { return "`SomeColumn`"; }
        }

        public override string ConcatExpressionSyntax
        {
            get { return "`SomeTable` `SomeOtherTable`"; }
        }

        public override string ConditionalExpressionSyntax
        {
            get { return "CASE WHEN (`SomeColumn` = ?p0) THEN ?p1 ELSE ?p2 END"; }
        }

        public override string ConstantExpressionSyntax
        {
            get { return "?p0"; }
        }

        public override string CountExpressionSyntax
        {
            get { return "COUNT(`SomeColumn`)"; }
        }

        public override string DivideExpressionSyntax
        {
            get { return "(?p0 / ?p1)"; }
        }

        public override string EqualExpressionSyntax
        {
            get { return "(`SomeColumn` = ?p0)"; }
        }

        public override string ExistsExpressionSyntax
        {
            get { return "EXISTS(SELECT `SomeColumn` FROM `SomeTable`)"; }
        }

        public override string GreaterThanExpressionSyntax
        {
            get { return "(`SomeColumn` > ?p0)"; }
        }

        public override string GreaterThanOrEqualExpressionSyntax
        {
            get { return "(`SomeColumn` >= ?p0)"; }
        }

        public override string InValueRangeExpressionSyntax
        {            
             get { return "`SomeColumn` IN(?p0,?p1)"; }
        }

        public override string InSubQueryExpressionSyntax
        {
            get { return "`SomeColumn` IN(SELECT `SomeOtherColumn` FROM `SomeOtherTable`)"; }
        }

        public override string InnerJoinExpressionSyntax
        {
            get { return "INNER JOIN `SomeTable` ON (`SomeColumn` = `SomeOtherColumn`)"; }
        }

        public override string LeftOuterJoinExpressionSyntax
        {
            get { return "LEFT OUTER JOIN `SomeTable` ON (`SomeColumn` = `SomeOtherColumn`)"; }
        }

        public override string RightOuterJoinExpressionSyntax
        {
            get { return "RIGHT OUTER JOIN `SomeTable` ON (`SomeColumn` = `SomeOtherColumn`)"; }
        }

        public override string LengthExpressionSyntax
        {
            get { return "LENGTH(`SomeColumn`)"; }
        }

        public override string LessThanExpressionSyntax
        {
            get { return "(`SomeColumn` < ?p0)"; }
        }

        public override string LessThanOrEqualExpressionSyntax
        {
            get { return "(`SomeColumn` <= ?p0)"; }
        }

        public override string ListExpressionSyntax
        {
            get { return "`SomeColumn`,`SomeOtherColumn`"; }
        }

        public override string BatchExpressionSyntax
        {
            get { return "`SomeColumn`;`SomeOtherColumn`;"; }
        }

        public override string MaxExpressionSyntax
        {
            get { return "MAX(`SomeColumn`)"; }
        }

        public override string MinExpressionSyntax
        {
            get { return "MIN(`SomeColumn`)"; }
        }

        public override string MultiplyExpressionSyntax
        {
            get { return "(?p0 * ?p1)"; }
        }

        public override string SubstractExpressionSyntax
        {
            get { return "(?p0 - ?p1)"; }
        }

        public override string NotExpressionSyntax
        {
            get { return "NOT (`SomeColumn` = ?p0)"; }
        }

        public override string DistinctExpressionSyntax
        {
            get { return "SELECT DISTINCT `SomeColumn`"; }
        }

        public override string DistinctWithTopExpressionSyntax
        {
            get { return "SELECT DISTINCT `SomeColumn` LIMIT ?p0"; }
        }

        public override string NotEqualExpressionSyntax
        {
            get { return "(`SomeColumn` <> ?p0)"; }
        }

        public override string OrExpressionSyntax
        {
            get { return "(?p0 OR ?p1)"; }
        }


        public override string OrderByAscendingExpressionSyntax
        {
            get { return "`SomeColumn` ASC"; }
        }

        public override string OrderByDescendingExpressionSyntax
        {
            get { return "`SomeColumn` DESC"; }
        }

        public override string PrefixExpressionSyntax
        {
            get { return "`t0`.`SomeColumn`"; }
        }

        public override string ReplaceExpressionSyntax
        {
            get { return "REPLACE(`SomeColumn`,?p0,?p1)"; }
        }

        public override string ReverseExpressionSyntax
        {
            get { return "REVERSE(`SomeColumn`)"; }
        }

        public override string SoundExExpressionSyntax
        {
            get { return "SOUNDEX(`SomeColumn`)"; }
        }

        public override string SumExpressionSyntax
        {
            get { return "SUM(`SomeColumn`)"; }
        }

        public override string TableExpressionSyntax
        {
            get { return "`SomeTable`"; }
        }

        public override string ToLowerExpressionSyntax
        {
            get { return "LOWER(`SomeColumn`)"; }
        }

        public override string ToUpperExpressionSyntax
        {
            get { return "UPPER(`SomeColumn`)"; }
        }

        public override string TrimExpressionSyntax
        {
            get { return "TRIM(`SomeColumn`)"; }
        }

        public override string TrimStartExpressionSyntax
        {
            get { return "LTRIM(`SomeColumn`)"; }
        }

        public override string TrimEndExpressionSyntax
        {
            get { return "RTRIM(`SomeColumn`)"; }
        }

        public override string SubStringExpressionSyntax
        {
            get { return "SUBSTRING(`SomeColumn`,?p0,?p1)"; }
        }

        public override string DateExpressionSyntax
        {
            get { return "DATE(`SomeColumn`)"; }
        }

        public override string YearExpressionSyntax
        {
            get { return "EXTRACT(YEAR FROM `SomeColumn`)"; }
        }

        public override string MonthExpressionSyntax
        {
            get { return "EXTRACT(MONTH FROM `SomeColumn`)"; }
        }

        public override string HourExpressionSyntax
        {
            get { return "EXTRACT(HOUR FROM `SomeColumn`)"; }
        }

        public override string MinuteExpressionSyntax
        {
            get { return "EXTRACT(MINUTE FROM `SomeColumn`)"; }
        }

        public override string SecondExpressionSyntax
        {
            get { return "EXTRACT(SECOND FROM `SomeColumn`)"; }
        }

        public override string MillisecondExpressionSyntax
        {
            get { return "(EXTRACT(MICROSECOND FROM `SomeColumn`) DIV 1000)"; }
        }

        public override string DayOfYearExpressionSyntax
        {
            get { return "DAYOFYEAR(`SomeColumn`)"; }
        }

        public override string DayOfMonthExpressionSyntax
        {
            get { return "EXTRACT(DAY FROM `SomeColumn`)"; }
        }

        public override string DayOfWeekExpressionSyntax
        {
            get { return "WEEKDAY(`SomeColumn`)"; }
        }

        public override string AddYearsExpressionSyntax
        {
            get { return "DATE_ADD(`SomeColumn`, INTERVAL ?p0 YEAR)"; }
        }

        public override string AddMonthsExpressionSyntax
        {
            get { return "DATE_ADD(`SomeColumn`, INTERVAL ?p0 MONTH)"; }
        }

        public override string AddDaysExpressionSyntax
        {
            get { return "DATE_ADD(`SomeColumn`, INTERVAL ?p0 DAY)"; }
        }

        public override string AddHoursExpressionSyntax
        {
            get { return "DATE_ADD(`SomeColumn`, INTERVAL ?p0 HOUR)"; }
        }

        public override string AddMinutesExpressionSyntax
        {
            get { return "DATE_ADD(`SomeColumn`, INTERVAL ?p0 MINUTE)"; }
        }

        public override string AddSecondsExpressionSyntax
        {
            get { return "DATE_ADD(`SomeColumn`, INTERVAL ?p0 SECOND)"; }
        }

        public override string AddMilliSecondsExpressionSyntax
        {
            get { return "DATE_ADD(`SomeColumn`, INTERVAL ?p0 * 1000 MICROSECOND)"; }            
        }

        public override string NowExpressionSyntax
        {
            get { return "CURRENT_TIMESTAMP()"; }
        }

        public override string ToDayExpressionSyntax
        {
            get { return "CURRENT_DATE()"; }
        }

        public override string UpdateExpressionSyntax
        {
            get { return "UPDATE `SomeTable` SET `SomeColumn` = ?p0 WHERE (`SomeColumn` = ?p1)"; }
        }

        public override string UpdateExpressionWithAliasedTargetSyntax
        {
            get { return "UPDATE `SomeTable` AS t0 SET `SomeColumn` = ?p0 WHERE (`SomeColumn` = ?p1)"; }           
        }

        public override string UpdateExpressionWithFromClauseSyntax
        {
            get { return "UPDATE `SomeTable` AS t0 INNER JOIN `SomeOtherTable` AS t1 ON (`t0`.`Id` = `t1`.`Id`) SET `SomeColumn` = ?p0 WHERE (`t0`.`SomeColumn` = ?p1)"; }
        }


        public override string InsertExpressionSyntax
        {
            get { return "INSERT INTO `SomeTable` (`SomeColumn`) VALUES(?p0)"; }
        }

        public override string DeleteExpressionSyntax
        {
            get { return "DELETE FROM `SomeTable` WHERE (`SomeColumn` = ?p0)"; }
        }

        public override string DeleteExpressionWithAliasedTargetSyntax
        {
            get { return "DELETE t0 FROM `SomeTable` AS t0 WHERE (`t0`.`SomeColumn` = ?p0)"; }
        }

        public override string SelectExpressionSyntax
        {
            get { return "SELECT `SomeColumn` FROM `SomeTable`"; }
        }

        public override string SelectExpressionWithTakeSyntax
        {
            get { return "SELECT `SomeColumn` FROM `SomeTable` LIMIT ?p0"; }
        }

        public override string SelectExpressionWithSkipSyntax
        {
            get { return "SELECT `SomeColumn` FROM `SomeTable` LIMIT ?p0 OFFSET 18446744073709551615"; }
        }

        public override string SelectExpressionWithSkipAndTakeSyntax
        {
            get { return "SELECT `SomeColumn` FROM `SomeTable` LIMIT ?p0 OFFSET ?p1"; }
        }

        public override string SelectExpressionWithOrderBySyntax
        {
            get { return "SELECT `SomeColumn` FROM `SomeTable` ORDER BY `SomeColumn` ASC"; }
        }

        public override string SelectExpressionWithGroupBySyntax
        {
            get { return "SELECT `SomeColumn` FROM `SomeTable` GROUP BY `SomeColumn`"; }
        }

        public override string SelectExpressionWithGroupByHavingSyntax
        {
            get { return "SELECT `SomeColumn` FROM `SomeTable` GROUP BY `SomeColumn` HAVING (`SomeColumn` > ?p0)"; }
        }

        public override string AbsExpressionSyntax
        {
            get { return "ABS(`SomeColumn`)"; }
        }

        public override string AcosExpressionSyntax
        {
            get { return "ACOS(`SomeColumn`)"; }
        }

        public override string AsinExpressionSyntax
        {
            get { return "ASIN(`SomeColumn`)"; }
        }

        public override string AtanExpressionSyntax
        {
            get { return "ATAN(`SomeColumn`)"; }
        }

        public override string Atan2ExpressionSyntax
        {
            get { return "ATAN2(`SomeColumn`)"; }
        }

        public override string CeilingExpressionSyntax
        {
            get { return "CEILING(`SomeColumn`)"; }
        }

        public override string CosExpressionSyntax
        {
            get { return "COS(`SomeColumn`)"; }
        }

        public override string CotExpressionSyntax
        {
            get { return "COT(`SomeColumn`)"; }
        }

        public override string DegressExpressionSyntax
        {
            get { return "DEGREES(`SomeColumn`)"; }
        }

        public override string ExpExpressionSyntax
        {
            get { return "EXP(`SomeColumn`)"; }
        }

        public override string FloorExpressionSyntax
        {
            get { return "FLOOR(`SomeColumn`)"; }
        }

        public override string LogExpressionSyntax
        {
            get { return "LOG(`SomeColumn`)"; }
        }

        public override string Log10ExpressionSyntax
        {
            get { return "LOG10(`SomeColumn`)"; }
        }

        public override string PIExpressionSyntax
        {
            get { return "PI()"; }
        }

        public override string PowerExpressionSyntax
        {
            get { return "POWER(`SomeColumn`,?p0)"; }
        }

        public override string RadiansExpressionSyntax
        {
            get { return "RADIANS(`SomeColumn`)"; }
        }

        public override string RandExpressionSyntax
        {
            get { return "RAND()"; }
        }

        public override string RandWithSeedExpressionSyntax
        {
            get { return "RAND(?p0)"; }
        }

        public override string RoundExpressionSyntax
        {
            get { return "ROUND(`SomeColumn`,?p0)"; }
        }

        public override string SignExpressionSyntax
        {
            get { return "SIGN(`SomeColumn`)"; }
        }

        public override string SinExpressionSyntax
        {
            get { return "SIN(`SomeColumn`)"; }
        }

        public override string SqrtExpressionSyntax
        {
            get { return "SQRT(`SomeColumn`)"; }
        }

        public override string SquareExpressionSyntax
        {
            get { return "POWER(`SomeColumn`,?p0)"; }
        }

        public override string TanExpressionSyntax
        {
            get { return "TAN(`SomeColumn`)"; }
        }

        public override string NullCheckEqualsExpressionSyntax
        {
            get { return "(`SomeColumn` IS NULL)"; }
        }

        public override string NullCheckNotEqualsExpressionSyntax
        {
            get { return "(`SomeColumn` IS NOT NULL)"; }
        }
    }
}
