using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DbExpressions.Tests
{
    [TestClass]
    public class OracleExpressionSyntaxTests : DbExpressionSyntaxTests
    {
       

        protected override DbQueryTranslator QueryTranslator
        {
            get { return DbQueryTranslatorFactory.GetQueryTranslator("Oracle.DataAccess.Client"); }
        }

        public override string AndExpressionSyntax
        {
            get { throw new NotImplementedException(); }
        }

        public override string AddExpressionSyntax
        {
            get { return "(:?p0 + :?p1)"; }
        }

        public override string AliasExpressionSyntax
        {
            get { throw new NotImplementedException(); }
        }

        public override string AssignExpressionSyntax
        {
            get { throw new NotImplementedException(); }
        }

        public override string AssignNullExpressionSyntax
        {
            get { return "\"SomeColumn\" = NULL"; }
        }

        public override string AvgExpressionSyntax
        {
            get { return "AVG(\"SomeColumn\")"; }
        }

        public override string ColumnExpressionSyntax
        {
            get { return "\"SomeColumn\""; }
        }

        public override string ConcatExpressionSyntax
        {
            get { return "\"SomeTable\" \"SomeOtherTable\""; }
        }

        public override string ConditionalExpressionSyntax
        {
            get { throw new NotImplementedException(); }
        }

        public override string ConstantExpressionSyntax
        {
            get { throw new NotImplementedException(); }
        }

        public override string CountExpressionSyntax
        {
            get { return "COUNT(\"SomeColumn\")"; }
        }

        public override string DivideExpressionSyntax
        {
            get { throw new NotImplementedException(); }
        }

        public override string EqualExpressionSyntax
        {
            get { return "(\"SomeColumn\" = :?p0)"; }
        }

        public override string ExistsExpressionSyntax
        {
            get { throw new NotImplementedException(); }
        }

        public override string GreaterThanExpressionSyntax
        {
            get { return "(\"SomeColumn\" > :?p0)"; }
        }

        public override string GreaterThanOrEqualExpressionSyntax
        {
            get { throw new NotImplementedException(); }
        }

        public override string InValueRangeExpressionSyntax
        {
            get { return "\"SomeColumn\" IN(:?p0,:?p1)"; }
        }

        public override string InSubQueryExpressionSyntax
        {
            get { return "\"SomeColumn\" IN(SELECT \"SomeOtherColumn\" FROM \"SomeOtherTable\")"; }
        }

        public override string InnerJoinExpressionSyntax
        {
            get { return "INNER JOIN \"SomeTable\" ON (\"SomeColumn\" = \"SomeOtherColumn\")"; }
        }

        public override string LeftOuterJoinExpressionSyntax
        {
            get { return "LEFT OUTER JOIN \"SomeTable\" ON (\"SomeColumn\" = \"SomeOtherColumn\")"; }
        }

        public override string RightOuterJoinExpressionSyntax
        {
            get { throw new NotImplementedException(); }
        }

        public override string LengthExpressionSyntax
        {
            get { return "LENGTH(\"SomeColumn\")"; }
        }

        public override string LessThanExpressionSyntax
        {
            get { return "(\"SomeColumn\" < :?p0)"; }
        }

        public override string LessThanOrEqualExpressionSyntax
        {
            get { throw new NotImplementedException(); }
        }

        public override string ListExpressionSyntax
        {
            get { return "\"SomeColumn\",\"SomeOtherColumn\""; }
        }

        public override string BatchExpressionSyntax
        {
            get { return "begin \"SomeColumn\";\"SomeOtherColumn\"; end;"; }
        }

        public override string MaxExpressionSyntax
        {
            get { return "MAX(\"SomeColumn\")"; }
        }

        public override string MinExpressionSyntax
        {
            get { return "MIN(\"SomeColumn\")"; }
        }

        public override string MultiplyExpressionSyntax
        {
            get { throw new NotImplementedException(); }
        }

        public override string SubstractExpressionSyntax
        {
            get { return "(:?p0 - :?p1)"; }
        }

        public override string NotExpressionSyntax
        {
            get { return "NOT (\"SomeColumn\" = :?p0)"; }
        }

        public override string DistinctExpressionSyntax
        {
            get { return "SELECT DISTINCT \"SomeColumn\""; }
        }

        public override string DistinctWithTopExpressionSyntax
        {
            get { return "SELECT DISTINCT \"SomeColumn\" WHERE ROWNUM <= :?p0"; }
        }

        public override string NotEqualExpressionSyntax
        {
            get { throw new NotImplementedException(); }
        }

        public override string OrExpressionSyntax
        {
            get { return "(:?p0 OR :?p1)"; }
        }

        public override string OrderByAscendingExpressionSyntax
        {
            get { return "\"SomeColumn\" ASC"; }
        }

        public override string OrderByDescendingExpressionSyntax
        {
            get { throw new NotImplementedException(); }
        }

        public override string PrefixExpressionSyntax
        {
            get { return "\"t0\".\"SomeColumn\""; }
        }

        public override string ReplaceExpressionSyntax
        {
            get { return "REPLACE(\"SomeColumn\",:?p0,:?p1)"; }
        }

        public override string ReverseExpressionSyntax
        {
            get { throw new NotImplementedException(); }
        }

        public override string SoundExExpressionSyntax
        {
            get { throw new NotImplementedException(); }
        }

        public override string SumExpressionSyntax
        {
            get { return "SUM(\"SomeColumn\")"; }
        }

        public override string TableExpressionSyntax
        {
            get { throw new NotImplementedException(); }
        }

        public override string ToLowerExpressionSyntax
        {
            get { throw new NotImplementedException(); }
        }

        public override string ToUpperExpressionSyntax
        {
            get { throw new NotImplementedException(); }
        }

        public override string TrimExpressionSyntax
        {
            get { return "TRIM(\"SomeColumn\")"; }
        }

        public override string TrimStartExpressionSyntax
        {
            get { return "LTRIM(\"SomeColumn\")"; }
        }

        public override string TrimEndExpressionSyntax
        {
            get { return "RTRIM(\"SomeColumn\")"; }
        }

        public override string SubStringExpressionSyntax
        {
            get { return "SUBSTR(\"SomeColumn\",:?p0,:?p1)"; }
        }

        public override string DateExpressionSyntax
        {
            get { return "TRUNC(\"SomeColumn\")"; }
        }

        public override string YearExpressionSyntax
        {
            get { return "EXTRACT(YEAR FROM \"SomeColumn\")"; }
        }

        public override string MonthExpressionSyntax
        {
            get { throw new NotImplementedException(); }
        }

        public override string HourExpressionSyntax
        {
            get { throw new NotImplementedException(); }
        }

        public override string MinuteExpressionSyntax
        {
            get { return "EXTRACT(MINUTE FROM \"SomeColumn\")"; }
        }

        public override string SecondExpressionSyntax
        {
            get { return "ROUND(EXTRACT(SECOND FROM \"SomeColumn\"))"; }
        }

        public override string MillisecondExpressionSyntax
        {
            get { return "TO_CHAR(\"SomeColumn\",'FF3')"; }
        }

        public override string DayOfYearExpressionSyntax
        {
            get { throw new NotImplementedException(); }
        }

        public override string DayOfMonthExpressionSyntax
        {
            get { return "EXTRACT(DAY FROM \"SomeColumn\")"; }
        }

        public override string DayOfWeekExpressionSyntax
        {
            get { return "TO_CHAR(\"SomeColumn\" ,'D')"; }
        }

        public override string AddYearsExpressionSyntax
        {
            get { throw new NotImplementedException(); }
        }

        public override string AddMonthsExpressionSyntax
        {
            get { throw new NotImplementedException(); }
        }

        public override string AddDaysExpressionSyntax
        {
            get { return "\"SomeColumn\" + :?p0"; }
        }

        public override string AddHoursExpressionSyntax
        {
            get { return "\"SomeColumn\" + (:?p0/24)"; }
        }

        public override string AddMinutesExpressionSyntax
        {
            get { throw new NotImplementedException(); }
        }

        public override string AddSecondsExpressionSyntax
        {
            get { throw new NotImplementedException(); }
        }

        public override string AddMilliSecondsExpressionSyntax
        {
            get { return "\"SomeColumn\" + NUMTODSINTERVAL(:?p0 / 1000, 'SECOND')"; }
        }

        public override string NowExpressionSyntax
        {
            get { throw new NotImplementedException(); }
        }

        public override string ToDayExpressionSyntax
        {
            get { return "TRUNC(CURRENT_DATE)"; }
        }

        public override string UpdateExpressionSyntax
        {
            get { return "UPDATE \"SomeTable\" SET \"SomeColumn\" = :?p0 WHERE (\"SomeColumn\" = :?p1)"; }
        }

        public override string UpdateExpressionWithAliasedTargetSyntax
        {
            get { return "UPDATE \"SomeTable\" t0 SET \"SomeColumn\" = :?p0 WHERE (\"SomeColumn\" = :?p1)"; }
        }

        public override string UpdateExpressionWithFromClauseSyntax
        {
            get { return "UPDATE \"SomeTable\" t0 INNER JOIN \"SomeOtherTable\" t1 ON (\"t0\".\"Id\" = \"t1\".\"Id\") SET \"SomeColumn\" = :?p0 WHERE (\"t0\".\"SomeColumn\" = :?p1)"; }
        }

        public override string InsertExpressionSyntax
        {
            get { return "INSERT INTO \"SomeTable\" (\"SomeColumn\") VALUES(:?p0)"; }
        }

        public override string DeleteExpressionSyntax
        {
            get { throw new NotImplementedException(); }
        }

        public override string DeleteExpressionWithAliasedTargetSyntax
        {
            get { return "DELETE FROM \"SomeTable\" t0 WHERE (\"t0\".\"SomeColumn\" = :?p0)"; }
        }

        public override string SelectExpressionSyntax
        {
            get { return "SELECT \"SomeColumn\" FROM \"SomeTable\""; }
        }

        public override string SelectExpressionWithTakeSyntax
        {
            get { return "SELECT \"SomeColumn\" FROM \"SomeTable\" WHERE ROWNUM <= :?p0"; }
        }

        public override string SelectExpressionWithSkipSyntax
        {
            get { return "SELECT \"SomeColumn\" FROM \"SomeTable\" WHERE ROWNUM > :?p0"; }
        }

        public override string SelectExpressionWithSkipAndTakeSyntax
        {
            get { throw new NotImplementedException(); }
        }

        public override string SelectExpressionWithOrderBySyntax
        {
            get { throw new NotImplementedException(); }
        }

        public override string SelectExpressionWithGroupBySyntax
        {
            get { throw new NotImplementedException(); }
        }

        public override string SelectExpressionWithGroupByHavingSyntax
        {
            get { return "SELECT \"SomeColumn\" FROM \"SomeTable\" GROUP BY \"SomeColumn\" HAVING (\"SomeColumn\" > :?p0)"; }
        }

        public override string AbsExpressionSyntax
        {
            get { return "ABS(\"SomeColumn\")"; }
        }

        public override string AcosExpressionSyntax
        {
            get { throw new NotImplementedException(); }
        }

        public override string AsinExpressionSyntax
        {
            get { return "ASIN(\"SomeColumn\")"; }
        }

        public override string AtanExpressionSyntax
        {
            get { return "ATAN(\"SomeColumn\")"; }
        }

        public override string Atan2ExpressionSyntax
        {
            get { return "ATAN2(\"SomeColumn\",:?p0)"; }
        }

        public override string CeilingExpressionSyntax
        {
            get { return "CEIL(\"SomeColumn\")"; }
        }

        public override string CosExpressionSyntax
        {
            get { return "COS(\"SomeColumn\")"; }
        }

        public override string CotExpressionSyntax
        {
            get { return "COSH(\"SomeColumn\")"; }
        }

        public override string DegressExpressionSyntax
        {
            get { throw new NotImplementedException(); }
        }

        public override string ExpExpressionSyntax
        {
            get { throw new NotImplementedException(); }
        }

        public override string FloorExpressionSyntax
        {
            get { throw new NotImplementedException(); }
        }

        public override string LogExpressionSyntax
        {
            get { throw new NotImplementedException(); }
        }

        public override string Log10ExpressionSyntax
        {
            get { return "LOG(10,\"SomeColumn\")"; }
        }

        public override string PIExpressionSyntax
        {
            get { return "ACOS(-1)"; }
        }

        public override string PowerExpressionSyntax
        {
            get { return "POWER(\"SomeColumn\",:?p0)"; }
        }

        public override string RadiansExpressionSyntax
        {
            get { throw new NotImplementedException(); }
        }

        public override string RandExpressionSyntax
        {
            get { return "dbms_random.value"; }
        }

        public override string RandWithSeedExpressionSyntax
        {
            get { throw new NotImplementedException(); }
        }

        public override string RoundExpressionSyntax
        {
            get { return "ROUND(\"SomeColumn\",:?p0)"; }
        }

        public override string SignExpressionSyntax
        {
            get { throw new NotImplementedException(); }
        }

        public override string SinExpressionSyntax
        {
            get { return "SIN(\"SomeColumn\")"; }
        }

        public override string SqrtExpressionSyntax
        {
            get { return "SQRT(\"SomeColumn\")"; }
        }

        public override string SquareExpressionSyntax
        {
            get { return "POWER(\"SomeColumn\",:?p0)"; }
        }

        public override string TanExpressionSyntax
        {
            get { throw new NotImplementedException(); }
        }

        public override string NullCheckEqualsExpressionSyntax
        {
            get { return "(\"SomeColumn\" IS NULL)"; }
        }

        public override string NullCheckNotEqualsExpressionSyntax
        {
            get { return "(\"SomeColumn\" IS NOT NULL)"; }
        }
    }
}
