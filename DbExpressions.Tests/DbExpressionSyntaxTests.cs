using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DbExpressions.Tests
{
    [TestClass]
    public abstract class DbExpressionSyntaxTests
    {
        protected abstract DbQueryTranslator QueryTranslator { get; }

        protected DbExpressionFactory ExpressionFactory { get; private set; }

        protected DbExpressionSyntaxTests()
        {
            ExpressionFactory = new DbExpressionFactory();
        }


       [TestMethod]
        public void ShouldTranslateAndExpression()
        {
            var expression = ExpressionFactory.And(ExpressionFactory.Constant(1), ExpressionFactory.Constant(2));
            var result = QueryTranslator.Translate(expression);
            Assert.AreEqual(AndExpressionSyntax,result.Sql);
        }

       [TestMethod]
        public void ShouldTranslateAddExpression()
        {
            var expression = ExpressionFactory.Add(ExpressionFactory.Constant(1), ExpressionFactory.Constant(2));
            var result = QueryTranslator.Translate(expression);
            Assert.AreEqual(AddExpressionSyntax,result.Sql);
        }

       [TestMethod]
        public void ShouldTranslateAliasExpression()
        {
            var expression = ExpressionFactory.Alias(ExpressionFactory.Table("SomeTable"), "t0");
            var result = QueryTranslator.Translate(expression);
            Assert.AreEqual(AliasExpressionSyntax,result.Sql);
        }

       [TestMethod]
        public void ShouldTranslateAssignExpression()
        {
            var expression = ExpressionFactory.Assign(ExpressionFactory.Column("SomeColumn"),
                                                      ExpressionFactory.Constant(1));
            var result = QueryTranslator.Translate(expression);
            Assert.AreEqual(AssignExpressionSyntax, result.Sql);
        }

       [TestMethod]
       public void ShouldTranslateAssignNullExpression()
       {
           var expression = ExpressionFactory.Assign(ExpressionFactory.Column("SomeColumn"),
                                                     ExpressionFactory.Constant(null));
           var result = QueryTranslator.Translate(expression);
           Assert.AreEqual(AssignNullExpressionSyntax, result.Sql);
       }

       [TestMethod]
        public void ShouldTranslateAvgExpression()
        {
            var expression = ExpressionFactory.Avg(ExpressionFactory.Column("SomeColumn"));
            var result = QueryTranslator.Translate(expression);
            Assert.AreEqual(AvgExpressionSyntax, result.Sql);
        }

       [TestMethod]
        public void ShouldTranslateColumnExpression()
        {
            var expression = ExpressionFactory.Column("SomeColumn");
            var result = QueryTranslator.Translate(expression);
            Assert.AreEqual(ColumnExpressionSyntax, result.Sql);
        }

       [TestMethod]
        public void ShouldTranslateConcatExpression()
        {
            var expression = ExpressionFactory.Concat(ExpressionFactory.Table("SomeTable"),
                                                      ExpressionFactory.Table("SomeOtherTable"));
            var result = QueryTranslator.Translate(expression);
            Assert.AreEqual(ConcatExpressionSyntax, result.Sql);
        }

       [TestMethod]
        public void ShouldTranslateConditionalExpression()
        {
            var expression = ExpressionFactory.Conditional(ExpressionFactory.Column("SomeColumn") == ExpressionFactory.Constant("SomeValue"),
                                ExpressionFactory.Constant("ValueWhenTrue"), ExpressionFactory.Constant("ValueWhenFalse"));

            var result = QueryTranslator.Translate(expression);
            Assert.AreEqual(ConditionalExpressionSyntax, result.Sql);
        }

       [TestMethod]
        public void ShouldTranslateConstantExpression()
        {
            var expression = ExpressionFactory.Constant(1);

            var result = QueryTranslator.Translate(expression);
            Assert.AreEqual(ConstantExpressionSyntax, result.Sql);
        }

       [TestMethod]
        public void ShouldTranslateCountExpression()
        {
            var expression = ExpressionFactory.Count(ExpressionFactory.Column("SomeColumn"));
            var result = QueryTranslator.Translate(expression);
            Assert.AreEqual(CountExpressionSyntax, result.Sql);
        }

       [TestMethod]
        public void ShouldTranslateDivideExpression()
        {
            var expression = ExpressionFactory.Divide(ExpressionFactory.Constant(1), ExpressionFactory.Constant(2));
            var result = QueryTranslator.Translate(expression);
            Assert.AreEqual(DivideExpressionSyntax, result.Sql);
        }

       [TestMethod]
        public void ShouldTranslateEqualExpression()
        {
            var expression = ExpressionFactory.Equal(ExpressionFactory.Column("SomeColumn"),
                                                     ExpressionFactory.Constant("SomeValue"));
            var result = QueryTranslator.Translate(expression);
            Assert.AreEqual(EqualExpressionSyntax, result.Sql);
        }

       [TestMethod]
        public void ShouldTranslateExistsExpression()
        {
            var expression =
                ExpressionFactory.Exists(ExpressionFactory.Select(f => f.Column("SomeColumn")).From(f => f.Table("SomeTable")));
            var result = QueryTranslator.Translate(expression);
            Assert.AreEqual(ExistsExpressionSyntax.Strip(), result.Sql.Strip());
        }

       [TestMethod]
        public void ShouldTranslateGreaterThanExpression()
        {
            var expression =
                ExpressionFactory.GreaterThan(ExpressionFactory.Column("SomeColumn"),
                                              ExpressionFactory.Constant("SomeValue"));
            var result = QueryTranslator.Translate(expression);
            Assert.AreEqual(GreaterThanExpressionSyntax, result.Sql);
        }

       [TestMethod]
        public void ShouldTranslateGreaterThanOrEqualExpression()
        {
            var expression =
                ExpressionFactory.GreaterThanOrEqual(ExpressionFactory.Column("SomeColumn"),
                                              ExpressionFactory.Constant("SomeValue"));
            var result = QueryTranslator.Translate(expression);
            Assert.AreEqual(GreaterThanOrEqualExpressionSyntax, result.Sql);
        }

       [TestMethod]
        public void ShouldTranslateInExpressionUsingValueRange()
        {
            var expression =
                ExpressionFactory.In(ExpressionFactory.Column("SomeColumn"), new object[] {1, 2});
            var result = QueryTranslator.Translate(expression);
            Assert.AreEqual(InValueRangeExpressionSyntax, result.Sql);
        }

       [TestMethod]
        public void ShouldTranslateInExpressionUsingSubQuery()
        {
            var expression =
                ExpressionFactory.In(ExpressionFactory.Column("SomeColumn"),
                                     ExpressionFactory.Select(f => f.Column("SomeOtherColumn")).From(
                                         f => f.Table("SomeOtherTable")));

            var result = QueryTranslator.Translate(expression);
            Assert.AreEqual(InSubQueryExpressionSyntax.Strip(), result.Sql.Strip());
        }

       [TestMethod]
        public void ShouldTranslateInnerJoinExpression()
        {
            var expression =
                ExpressionFactory.InnerJoin(ExpressionFactory.Table("SomeTable"),
                                            ExpressionFactory.Equal(ExpressionFactory.Column("SomeColumn"),
                                                                    ExpressionFactory.Column("SomeOtherColumn")));

            var result = QueryTranslator.Translate(expression);
            Assert.AreEqual(InnerJoinExpressionSyntax, result.Sql);
        }

       [TestMethod]
        public void ShouldTranslateLeftOuterJoinExpression()
        {
            var expression =
                ExpressionFactory.LeftOuterJoin(ExpressionFactory.Table("SomeTable"),
                                            ExpressionFactory.Equal(ExpressionFactory.Column("SomeColumn"),
                                                                    ExpressionFactory.Column("SomeOtherColumn")));

            var result = QueryTranslator.Translate(expression);
            Assert.AreEqual(LeftOuterJoinExpressionSyntax, result.Sql);
        }

       [TestMethod]
        public void ShouldTranslateRightOuterJoinExpression()
        {
            if (GetType() == typeof(SQLiteExpressionSyntaxTests))
                return;
           var expression =
                ExpressionFactory.RightOuterJoin(ExpressionFactory.Table("SomeTable"),
                                            ExpressionFactory.Equal(ExpressionFactory.Column("SomeColumn"),
                                                                    ExpressionFactory.Column("SomeOtherColumn")));

            var result = QueryTranslator.Translate(expression);
            Assert.AreEqual(RightOuterJoinExpressionSyntax, result.Sql);
        }

       [TestMethod]
        public void ShouldTranslateLengthExpression()
        {
            var expression =
                ExpressionFactory.Length(ExpressionFactory.Column("SomeColumn"));

            var result = QueryTranslator.Translate(expression);
            Assert.AreEqual(LengthExpressionSyntax, result.Sql);
        }

       [TestMethod]
        public void ShouldTranslateLessThanExpression()
        {
            var expression =
                ExpressionFactory.LessThan(ExpressionFactory.Column("SomeColumn"),
                                              ExpressionFactory.Constant("SomeValue"));
            var result = QueryTranslator.Translate(expression);
            Assert.AreEqual(LessThanExpressionSyntax, result.Sql);
        }

       [TestMethod]
        public void ShouldTranslateLessThanOrEqualExpression()
        {
            var expression =
                ExpressionFactory.LessThanOrEqual(ExpressionFactory.Column("SomeColumn"),
                                              ExpressionFactory.Constant("SomeValue"));
            var result = QueryTranslator.Translate(expression);
            Assert.AreEqual(LessThanOrEqualExpressionSyntax, result.Sql);
        }

       [TestMethod]
        public void ShouldTranslateListExpression()
        {
            var expression =
                ExpressionFactory.List(new []{ExpressionFactory.Column("SomeColumn"),
                                       ExpressionFactory.Column("SomeOtherColumn")});
            var result = QueryTranslator.Translate(expression);
            Assert.AreEqual(ListExpressionSyntax, result.Sql);
        }

       [TestMethod]
        public void ShouldTranslateBatchExpression()
        {
            var expression =
                ExpressionFactory.Batch(new[]{ExpressionFactory.Column("SomeColumn"),
                                       ExpressionFactory.Column("SomeOtherColumn")});
            var result = QueryTranslator.Translate(expression);
            Assert.AreEqual(BatchExpressionSyntax.Clean(), result.Sql.Clean());
        }

       [TestMethod]
        public void ShouldTranslateMaxExpression()
        {
            var expression =
                ExpressionFactory.Max(ExpressionFactory.Column("SomeColumn"));
            var result = QueryTranslator.Translate(expression);
            Assert.AreEqual(MaxExpressionSyntax, result.Sql);
        }

       [TestMethod]
        public void ShouldTranslateMinExpression()
        {
            var expression =
                ExpressionFactory.Min(ExpressionFactory.Column("SomeColumn"));
            var result = QueryTranslator.Translate(expression);
            Assert.AreEqual(MinExpressionSyntax, result.Sql);
        }

       [TestMethod]
        public void ShouldTranslateMultiplyExpression()
        {
            var expression = ExpressionFactory.Multiply(ExpressionFactory.Constant(1), ExpressionFactory.Constant(2));
            var result = QueryTranslator.Translate(expression);
            Assert.AreEqual(MultiplyExpressionSyntax, result.Sql);
        }

       [TestMethod]
        public void ShouldTranslateSubstractExpression()
        {
            var expression = ExpressionFactory.Subtract(ExpressionFactory.Constant(1), ExpressionFactory.Constant(2));
            var result = QueryTranslator.Translate(expression);
            Assert.AreEqual(SubstractExpressionSyntax, result.Sql);
        }

       [TestMethod]
        public void ShouldTranslateNotExpression()
        {
            var expression =
                ExpressionFactory.Not(ExpressionFactory.Equal(ExpressionFactory.Column("SomeColumn"),
                                                              ExpressionFactory.Constant(1)));
            var result = QueryTranslator.Translate(expression);
            Assert.AreEqual(NotExpressionSyntax, result.Sql);
        }

       [TestMethod]
       public void ShouldTranslateDistinctExpression()
       {
           var dbSelectQuery = new DbSelectQuery();
           dbSelectQuery.SelectDistinct(f => f.Column("SomeColumn"));                                           
           var result = QueryTranslator.Translate(dbSelectQuery);
           Assert.AreEqual(DistinctExpressionSyntax.Clean(), result.Sql.Clean());
       }

       [TestMethod]
       public void ShouldTranslateDistinctWithTopExpression()
       {
           var dbSelectQuery = new DbSelectQuery();
           dbSelectQuery.SelectDistinct(f => f.Column("SomeColumn")).Take(1);
           var result = QueryTranslator.Translate(dbSelectQuery);
           Assert.AreEqual(DistinctWithTopExpressionSyntax.Clean(), result.Sql.Clean());
       }


       [TestMethod]
        public void ShouldTranslateNotEqualExpression()
        {
            var expression = ExpressionFactory.NotEqual(ExpressionFactory.Column("SomeColumn"),
                                                 ExpressionFactory.Constant("SomeValue"));
            var result = QueryTranslator.Translate(expression);
            Assert.AreEqual(NotEqualExpressionSyntax, result.Sql);
        }

       [TestMethod]
        public void ShouldTranslateOrExpression()
        {
            var expression = ExpressionFactory.Or(ExpressionFactory.Constant(1), ExpressionFactory.Constant(2));
            var result = QueryTranslator.Translate(expression);
            Assert.AreEqual(OrExpressionSyntax, result.Sql);
        }

       [TestMethod]
        public void ShouldTranslateOrderByAscendingExpression()
        {
            var expression = ExpressionFactory.OrderByAscending(ExpressionFactory.Column("SomeColumn"));
            var result = QueryTranslator.Translate(expression);
            Assert.AreEqual(OrderByAscendingExpressionSyntax, result.Sql);
        }

       [TestMethod]
        public void ShouldTranslateOrderByDescendingExpression()
        {
            var expression = ExpressionFactory.OrderByDescending(ExpressionFactory.Column("SomeColumn"));
            var result = QueryTranslator.Translate(expression);
            Assert.AreEqual(OrderByDescendingExpressionSyntax, result.Sql);
        }

       [TestMethod]
        public void ShouldTranslatePrefixExpression()
        {
            var expression = ExpressionFactory.Prefix(ExpressionFactory.Column("SomeColumn"), "t0");
            var result = QueryTranslator.Translate(expression);
            Assert.AreEqual(PrefixExpressionSyntax, result.Sql);
        }

       [TestMethod]
        public void ShouldTranslateReplaceExpression()
        {
            var expression = ExpressionFactory.Replace(ExpressionFactory.Column("SomeColumn"),
                                                       ExpressionFactory.Constant("OldValue"),
                                                       ExpressionFactory.Constant("NewValue"));
            var result = QueryTranslator.Translate(expression);
            Assert.AreEqual(ReplaceExpressionSyntax, result.Sql);
        }

       [TestMethod]
        public void ShouldTranslateReverseExpression()
        {
            var expression = ExpressionFactory.Reverse(ExpressionFactory.Column("SomeColumn"));
            var result = QueryTranslator.Translate(expression);
            Assert.AreEqual(ReverseExpressionSyntax, result.Sql);
        }

       [TestMethod]
        public void ShouldTranslateSoundExExpression()
        {
            var expression = ExpressionFactory.SoundEx(ExpressionFactory.Column("SomeColumn"));
            var result = QueryTranslator.Translate(expression);
            Assert.AreEqual(SoundExExpressionSyntax, result.Sql);
        }

       [TestMethod]
        public void ShouldTranslateSumExpression()
        {
            var expression = ExpressionFactory.Sum(ExpressionFactory.Column("SomeColumn"));
            var result = QueryTranslator.Translate(expression);
            Assert.AreEqual(SumExpressionSyntax , result.Sql);
        }

       [TestMethod]
        public void ShouldTranslateTableExpression()
        {
            var expression = ExpressionFactory.Table("SomeTable");
            var result = QueryTranslator.Translate(expression);
            Assert.AreEqual(TableExpressionSyntax, result.Sql);
        }

       [TestMethod]
        public void ShouldTranslateToLowerExpression()
        {
            var expression = ExpressionFactory.ToLower(ExpressionFactory.Column("SomeColumn"));
            var result = QueryTranslator.Translate(expression);
            Assert.AreEqual(ToLowerExpressionSyntax, result.Sql);
        }

       [TestMethod]
        public void ShouldTranslateToUpperExpression()
        {
            var expression = ExpressionFactory.ToUpper(ExpressionFactory.Column("SomeColumn"));
            var result = QueryTranslator.Translate(expression);
            Assert.AreEqual(ToUpperExpressionSyntax, result.Sql);
        }

       [TestMethod]
        public void ShouldTranslateTrimExpression()
        {
            var expression = ExpressionFactory.Trim(ExpressionFactory.Column("SomeColumn"));
            var result = QueryTranslator.Translate(expression);
            Assert.AreEqual(TrimExpressionSyntax, result.Sql);
        }

       [TestMethod]
        public void ShouldTranslateTrimStartExpression()
        {
            var expression = ExpressionFactory.TrimStart(ExpressionFactory.Column("SomeColumn"));
            var result = QueryTranslator.Translate(expression);
            Assert.AreEqual(TrimStartExpressionSyntax, result.Sql);
        }

       [TestMethod]
        public void ShouldTranslateTrimEndExpression()
        {
            var expression = ExpressionFactory.TrimEnd(ExpressionFactory.Column("SomeColumn"));
            var result = QueryTranslator.Translate(expression);
            Assert.AreEqual(TrimEndExpressionSyntax, result.Sql);
        }
        
       [TestMethod]
        public void ShouldTranslateSubStringExpression()
        {
            var expression = ExpressionFactory.SubString(ExpressionFactory.Column("SomeColumn"),
                                                         ExpressionFactory.Constant(1), ExpressionFactory.Constant(2));
            var result = QueryTranslator.Translate(expression);
            Assert.AreEqual(SubStringExpressionSyntax, result.Sql);
        }

       [TestMethod]
        public void ShouldTranslateDateExpression()
        {
            var expression = ExpressionFactory.Date(ExpressionFactory.Column("SomeColumn"));
            var result = QueryTranslator.Translate(expression);
            Assert.AreEqual(DateExpressionSyntax, result.Sql);
        }

       [TestMethod]
        public void ShouldTranslateYearExpression()
        {
            var expression = ExpressionFactory.Year(ExpressionFactory.Column("SomeColumn"));
            var result = QueryTranslator.Translate(expression);
            Assert.AreEqual(YearExpressionSyntax, result.Sql);
        }

       [TestMethod]
        public void ShouldTranslateMonthExpression()
        {
            var expression = ExpressionFactory.Month(ExpressionFactory.Column("SomeColumn"));
            var result = QueryTranslator.Translate(expression);
            Assert.AreEqual(MonthExpressionSyntax, result.Sql);
        }

       [TestMethod]
        public void ShouldTranslateHourExpression()
        {
            var expression = ExpressionFactory.Hour(ExpressionFactory.Column("SomeColumn"));
            var result = QueryTranslator.Translate(expression);
            Assert.AreEqual(HourExpressionSyntax, result.Sql);
        }

       [TestMethod]
        public void ShouldTranslateNowExpression()
        {
            var expression = ExpressionFactory.Now();
            var result = QueryTranslator.Translate(expression);
            Assert.AreEqual(NowExpressionSyntax, result.Sql);
        }

       [TestMethod]
        public void ShouldTranslateTodayExpression()
        {
            var expression = ExpressionFactory.ToDay();
            var result = QueryTranslator.Translate(expression);
            Assert.AreEqual(ToDayExpressionSyntax, result.Sql);
        }


       [TestMethod]
        public void ShouldTranslateMinuteExpression()
        {
            var expression = ExpressionFactory.Minute(ExpressionFactory.Column("SomeColumn"));
            var result = QueryTranslator.Translate(expression);
            Assert.AreEqual(MinuteExpressionSyntax, result.Sql);
        }

       [TestMethod]
        public void ShouldTranslateSecondExpression()
        {
            var expression = ExpressionFactory.Second(ExpressionFactory.Column("SomeColumn"));
            var result = QueryTranslator.Translate(expression);
            Assert.AreEqual(SecondExpressionSyntax, result.Sql);
        }

       [TestMethod]
        public void ShouldTranslateMillisecondExpression()
        {
            if (GetType() == typeof(SQLiteExpressionSyntaxTests))
                return;
           var expression = ExpressionFactory.Millisecond(ExpressionFactory.Column("SomeColumn"));
            var result = QueryTranslator.Translate(expression);
            Assert.AreEqual(MillisecondExpressionSyntax, result.Sql);
        }

       [TestMethod]
        public void ShouldTranslateDayOfYearExpression()
        {
            var expression = ExpressionFactory.DayOfYear(ExpressionFactory.Column("SomeColumn"));
            var result = QueryTranslator.Translate(expression);
            Assert.AreEqual(DayOfYearExpressionSyntax, result.Sql);
        }

       [TestMethod]
        public void ShouldTranslateDayOfMonthExpression()
        {
            var expression = ExpressionFactory.DayOfMonth(ExpressionFactory.Column("SomeColumn"));
            var result = QueryTranslator.Translate(expression);
            Assert.AreEqual(DayOfMonthExpressionSyntax, result.Sql);
        }

       [TestMethod]
        public void ShouldTranslateDayOfWeekExpression()
        {
            var expression = ExpressionFactory.DayOfWeek(ExpressionFactory.Column("SomeColumn"));
            var result = QueryTranslator.Translate(expression);
            Assert.AreEqual(DayOfWeekExpressionSyntax, result.Sql);
        }

       [TestMethod]
        public void ShouldTranslateAddYearsExpression()
        {
            var expression = ExpressionFactory.AddYears(ExpressionFactory.Column("SomeColumn"),ExpressionFactory.Constant(1));
            var result = QueryTranslator.Translate(expression);
            Assert.AreEqual(AddYearsExpressionSyntax, result.Sql);
        }

       [TestMethod]
        public void ShouldTranslateAddMonthsExpression()
        {
            var expression = ExpressionFactory.AddMonths(ExpressionFactory.Column("SomeColumn"), ExpressionFactory.Constant(1));
            var result = QueryTranslator.Translate(expression);
            Assert.AreEqual(AddMonthsExpressionSyntax, result.Sql);
        }

       [TestMethod]
        public void ShouldTranslateAddDaysExpression()
        {
            var expression = ExpressionFactory.AddDays(ExpressionFactory.Column("SomeColumn"), ExpressionFactory.Constant(1));
            var result = QueryTranslator.Translate(expression);
            Assert.AreEqual(AddDaysExpressionSyntax, result.Sql);
        }

       [TestMethod]
        public void ShouldTranslateAddHoursExpression()
        {
            var expression = ExpressionFactory.AddHours(ExpressionFactory.Column("SomeColumn"), ExpressionFactory.Constant(1));
            var result = QueryTranslator.Translate(expression);
            Assert.AreEqual(AddHoursExpressionSyntax, result.Sql);
        }

       [TestMethod]
        public void ShouldTranslateAddMinutesExpression()
        {
            var expression = ExpressionFactory.AddMinutes(ExpressionFactory.Column("SomeColumn"), ExpressionFactory.Constant(1));
            var result = QueryTranslator.Translate(expression);
            Assert.AreEqual(AddMinutesExpressionSyntax, result.Sql);
        }

       [TestMethod]
        public void ShouldTranslateAddSecondsExpression()
        {
            var expression = ExpressionFactory.AddSeconds(ExpressionFactory.Column("SomeColumn"), ExpressionFactory.Constant(1));
            var result = QueryTranslator.Translate(expression);
            Assert.AreEqual(AddSecondsExpressionSyntax, result.Sql);
        }

        [TestMethod]
        public void ShouldTranslateAddMillisecondsExpression()
        {
            if (GetType() == typeof(SQLiteExpressionSyntaxTests))
                return;
            var expression = ExpressionFactory.AddMilliseconds(ExpressionFactory.Column("SomeColumn"), ExpressionFactory.Constant(1));
            var result = QueryTranslator.Translate(expression);
            Assert.AreEqual(AddMilliSecondsExpressionSyntax, result.Sql);
        }


        [TestMethod]
        public void ShouldTranslateAbsExpression()
        {
            var expression = ExpressionFactory.Abs(ExpressionFactory.Column("SomeColumn"));
            var result = QueryTranslator.Translate(expression);
            Assert.AreEqual(AbsExpressionSyntax, result.Sql);
        }

        [TestMethod]
        public void ShouldTranslateAcosExpression()
        {
            var expression = ExpressionFactory.Acos(ExpressionFactory.Column("SomeColumn"));
            var result = QueryTranslator.Translate(expression);
            Assert.AreEqual(AcosExpressionSyntax, result.Sql);
        }

        [TestMethod]
        public void ShouldTranslateAsinExpression()
        {
            var expression = ExpressionFactory.Asin(ExpressionFactory.Column("SomeColumn"));
            var result = QueryTranslator.Translate(expression);
            Assert.AreEqual(AsinExpressionSyntax, result.Sql);
        }

        [TestMethod]
        public void ShouldTranslateAtanExpression()
        {
            var expression = ExpressionFactory.Atan(ExpressionFactory.Column("SomeColumn"));
            var result = QueryTranslator.Translate(expression);
            Assert.AreEqual(AtanExpressionSyntax, result.Sql);
        }

        [TestMethod]
        public void ShouldTranslateAtan2Expression()
        {
            var expression = ExpressionFactory.Atan2(ExpressionFactory.Column("SomeColumn"), ExpressionFactory.Constant(1));
            var result = QueryTranslator.Translate(expression);
            Assert.AreEqual(Atan2ExpressionSyntax, result.Sql);
        }

        [TestMethod]
        public void ShouldTranslateCeilingExpression()
        {
            var expression = ExpressionFactory.Ceiling(ExpressionFactory.Column("SomeColumn"));
            var result = QueryTranslator.Translate(expression);
            Assert.AreEqual(CeilingExpressionSyntax, result.Sql);
        }

        [TestMethod]
        public void ShouldTranslateCosExpression()
        {
            var expression = ExpressionFactory.Cos(ExpressionFactory.Column("SomeColumn"));
            var result = QueryTranslator.Translate(expression);
            Assert.AreEqual(CosExpressionSyntax, result.Sql);
        }

        [TestMethod]
        public void ShouldTranslateCotExpression()
        {
            var expression = ExpressionFactory.Cot(ExpressionFactory.Column("SomeColumn"));
            var result = QueryTranslator.Translate(expression);
            Assert.AreEqual(CotExpressionSyntax, result.Sql);
        }

        [TestMethod]
        public void ShouldTranslateDegreesExpression()
        {
            var expression = ExpressionFactory.Degrees(ExpressionFactory.Column("SomeColumn"));
            var result = QueryTranslator.Translate(expression);
            Assert.AreEqual(DegressExpressionSyntax, result.Sql);
        }

        [TestMethod]
        public void ShouldTranslateExpExpression()
        {
            var expression = ExpressionFactory.Exp(ExpressionFactory.Column("SomeColumn"));
            var result = QueryTranslator.Translate(expression);
            Assert.AreEqual(ExpExpressionSyntax, result.Sql);
        }

        [TestMethod]
        public void ShouldTranslateFloorExpression()
        {
            var expression = ExpressionFactory.Floor(ExpressionFactory.Column("SomeColumn"));
            var result = QueryTranslator.Translate(expression);
            Assert.AreEqual(FloorExpressionSyntax, result.Sql);
        }

        [TestMethod]
        public void ShouldTranslateLogExpression()
        {
            var expression = ExpressionFactory.Log(ExpressionFactory.Column("SomeColumn"));
            var result = QueryTranslator.Translate(expression);
            Assert.AreEqual(LogExpressionSyntax, result.Sql);
        }

        [TestMethod]
        public void ShouldTranslateLog10Expression()
        {
            var expression = ExpressionFactory.Log10(ExpressionFactory.Column("SomeColumn"));
            var result = QueryTranslator.Translate(expression);
            Assert.AreEqual(Log10ExpressionSyntax, result.Sql);
        }

        [TestMethod]
        public void ShouldTranslatePIExpression()
        {
            var expression = ExpressionFactory.PI();
            var result = QueryTranslator.Translate(expression);
            Assert.AreEqual(PIExpressionSyntax, result.Sql);
        }

        [TestMethod]
        public void ShouldTranslatePowerExpression()
        {
            var expression = ExpressionFactory.Power(ExpressionFactory.Column("SomeColumn"),ExpressionFactory.Constant(2));
            var result = QueryTranslator.Translate(expression);
            Assert.AreEqual(PowerExpressionSyntax, result.Sql);
        }

        [TestMethod, Ignore]
        public void ShouldTranslateRadiansExpression()
        {
            var expression = ExpressionFactory.Radians(ExpressionFactory.Column("SomeColumn"));
            var result = QueryTranslator.Translate(expression);
            Assert.AreEqual(RadiansExpressionSyntax, result.Sql);
        }

        [TestMethod]
        public void ShouldTranslateRandExpression()
        {
            var expression = ExpressionFactory.Rand();
            var result = QueryTranslator.Translate(expression);
            Assert.AreEqual(RandExpressionSyntax, result.Sql);
        }

        [TestMethod]
        public void ShouldTranslateRandWithSeedExpression()
        {
            if (GetType() == typeof(SQLiteExpressionSyntaxTests))
                return;
            var expression = ExpressionFactory.Rand(ExpressionFactory.Constant(10));
            var result = QueryTranslator.Translate(expression);
            Assert.AreEqual(RandWithSeedExpressionSyntax, result.Sql);
        }

        [TestMethod]
        public void ShouldTranslateRoundExpression()
        {
            var expression = ExpressionFactory.Round(ExpressionFactory.Column("SomeColumn"),ExpressionFactory.Constant(2));
            var result = QueryTranslator.Translate(expression);
            Assert.AreEqual(RoundExpressionSyntax, result.Sql);
        }

        [TestMethod]
        public void ShouldTranslateSignExpression()
        {
            var expression = ExpressionFactory.Sign(ExpressionFactory.Column("SomeColumn"));
            var result = QueryTranslator.Translate(expression);
            Assert.AreEqual(SignExpressionSyntax, result.Sql);
        }

        [TestMethod]
        public void ShouldTranslateSinExpression()
        {
            var expression = ExpressionFactory.Sin(ExpressionFactory.Column("SomeColumn"));
            var result = QueryTranslator.Translate(expression);
            Assert.AreEqual(SinExpressionSyntax, result.Sql);
        }

        [TestMethod]
        public void ShouldTranslateSqrtExpression()
        {
            var expression = ExpressionFactory.Sqrt(ExpressionFactory.Column("SomeColumn"));
            var result = QueryTranslator.Translate(expression);
            Assert.AreEqual(SqrtExpressionSyntax, result.Sql);
        }

        [TestMethod]
        public void ShouldTranslateSquareExpression()
        {
            var expression = ExpressionFactory.Square(ExpressionFactory.Column("SomeColumn"));
            var result = QueryTranslator.Translate(expression);
            Assert.AreEqual(SquareExpressionSyntax, result.Sql);
        }

        [TestMethod]
        public void ShouldTranslateTanExpression()
        {
            var expression = ExpressionFactory.Tan(ExpressionFactory.Column("SomeColumn"));
            var result = QueryTranslator.Translate(expression);
            Assert.AreEqual(TanExpressionSyntax, result.Sql);
        }

        [TestMethod]
        public void ShouldTranslateUpdateExpression()
        {
            var dbUpdateQuery = new DbUpdateQuery();
            var expression = dbUpdateQuery.Update(e => e.Table("SomeTable"))
                .Set(e => e.Column("SomeColumn"), 1)
                .Where(e => e.Column("SomeColumn") == e.Constant(2));

            var result = QueryTranslator.Translate(expression);
            Assert.AreEqual(UpdateExpressionSyntax.Clean(), result.Sql.Clean());
        }


        [TestMethod]
        public void ShouldTranslateUpdateExpressionWithAliasedTarget()
        {
            if (GetType() == typeof(SQLiteExpressionSyntaxTests))
                return;
            var dbUpdateQuery = new DbUpdateQuery();
            var expression = dbUpdateQuery.Update(e => e.Table("SomeTable", "t0"))
                .Set(e => e.Column("SomeColumn"), 1)
                .Where(e => e.Column("SomeColumn") == e.Constant(2));

            var result = QueryTranslator.Translate(expression);
            Assert.AreEqual(UpdateExpressionWithAliasedTargetSyntax.Clean(), result.Sql.Clean());
        }

        [TestMethod]
        public void ShouldTranslateUpdateExpressionWithFromClause()
        {
            if (GetType() == typeof(SQLiteExpressionSyntaxTests))
                return;
            var dbUpdateQuery = new DbUpdateQuery();
            var expression = dbUpdateQuery.Update(e => e.Table("SomeTable", "t0"))
                .Set(e => e.Column("SomeColumn"), 1)
                .From(e => e.Table("SomeTable", "t0")).InnerJoin(e => e.Table("SomeOtherTable","t1"), e=> e.Column("t0","Id") == e.Column("t1","Id"))
                .Where(e => e.Column("t0","SomeColumn") == e.Constant(2));

            var result = QueryTranslator.Translate(expression);
            Assert.AreEqual(UpdateExpressionWithFromClauseSyntax.Clean(), result.Sql.Clean());
        }



       [TestMethod]
        public void ShouldTranslateInsertExpression()
        {
           var dbInsertQuery = new DbInsertQuery();
           var expression = dbInsertQuery.Insert(e => e.Table("SomeTable"))
                .Columns(e => e.Column("SomeColumn")).Values(e => e.Constant(1));
            var result = QueryTranslator.Translate(expression);
            Assert.AreEqual(InsertExpressionSyntax.Clean(), result.Sql.Clean());
        }

       [TestMethod]
        public void ShouldTranslateDeleteExpression()
        {
           var dbDeleteQuery = new DbDeleteQuery();
           var expression = dbDeleteQuery.Delete(e => e.Table("SomeTable"))
                .Where(e => e.Column("SomeColumn") == e.Constant(1));
            var result = QueryTranslator.Translate(expression);
            Assert.AreEqual(DeleteExpressionSyntax.Clean(), result.Sql.Clean());
        }
       
        [TestMethod]
        public void ShouldTranslateDeleteExpressionWithAliasedTarget()
        {
            if (GetType() == typeof(SQLiteExpressionSyntaxTests))
                return;
            var dbDeleteQuery = new DbDeleteQuery();
            var expression = dbDeleteQuery.Delete(e => e.Table("SomeTable", "t0"))
                .Where(e => e.Column("t0", "SomeColumn") == e.Constant(1));
            var result = QueryTranslator.Translate(expression);
            Assert.AreEqual(DeleteExpressionWithAliasedTargetSyntax.Clean(), result.Sql.Clean());
        }
              
        [TestMethod]
        public void ShouldTranslateDeleteExpressionAliasedTargetInFromExpression()
        {
            if (GetType() == typeof(SQLiteExpressionSyntaxTests))
                return;
            var dbDeleteQuery = new DbDeleteQuery();
            var expression = dbDeleteQuery.Delete(e => e.Table("SomeTable"))
                .From(e => e.Table("SomeTable", "t0")).Where(e => e.Column("t0", "SomeColumn") == e.Constant(1));
            var result = QueryTranslator.Translate(expression);
            Assert.AreEqual(DeleteExpressionWithAliasedTargetSyntax.Clean(), result.Sql.Clean());
        }


        [TestMethod]
        public void ShouldTranslateSelectExpression()
        {
            var dbSelectQuery = new DbSelectQuery();
            var expression = dbSelectQuery.Select(e => e.Column("SomeColumn"))
                .From(e => e.Table("SomeTable"));
            var result = QueryTranslator.Translate(expression);
            Assert.AreEqual(SelectExpressionSyntax.Clean(), result.Sql.Clean());
        }

        [TestMethod]
        public void ShouldTranslateSelectExpressionWithOrderBy()
        {
            var dbSelectQuery = new DbSelectQuery();
            var expression = dbSelectQuery.Select(e => e.Column("SomeColumn"))
                .From(e => e.Table("SomeTable")).OrderBy(e => e.Column("SomeColumn"),DbOrderByExpressionType.Ascending);
            var result = QueryTranslator.Translate(expression);
            Assert.AreEqual(SelectExpressionWithOrderBySyntax.Clean(), result.Sql.Clean());
        }

        [TestMethod]
        public void ShouldTranslateSelectExpressionWithGroupBy()
        {
            var dbSelectQuery = new DbSelectQuery();
            var expression = dbSelectQuery.Select(e => e.Column("SomeColumn"))
                .From(e => e.Table("SomeTable")).GroupBy(e => e.Column("SomeColumn"));
            var result = QueryTranslator.Translate(expression);
            Assert.AreEqual(SelectExpressionWithGroupBySyntax.Clean(), result.Sql.Clean());
        }


        [TestMethod]
        public void ShouldTranslateSelectExpressionWithGroupByHaving()
        {
            var dbSelectQuery = new DbSelectQuery();
            var expression = dbSelectQuery.Select(e => e.Column("SomeColumn"))
                .From(e => e.Table("SomeTable")).GroupBy(e => e.Column("SomeColumn")).Having(
                    e => e.Column("SomeColumn") > 1);
            var result = QueryTranslator.Translate(expression);
            Assert.AreEqual(SelectExpressionWithGroupByHavingSyntax.Clean(), result.Sql.Clean());
        }

        [TestMethod]
        public void ShouldTranslateSelectExpressionTake()
        {
            var dbSelectQuery = new DbSelectQuery();
            var expression = dbSelectQuery.Select(e => e.Column("SomeColumn"))
                .From(e => e.Table("SomeTable")).Take(1);
            var result = QueryTranslator.Translate(expression);
            Assert.AreEqual(SelectExpressionWithTakeSyntax.Clean(), result.Sql.Clean());
        }

        [TestMethod]
        public void ShouldTranslateSelectExpressionSkip()
        {
            var dbSelectQuery = new DbSelectQuery();
            var expression = dbSelectQuery.Select(e => e.Column("SomeColumn"))
                .From(e => e.Table("SomeTable")).Skip(1);
            var result = QueryTranslator.Translate(expression);
            Assert.AreEqual(SelectExpressionWithSkipSyntax.Clean(), result.Sql.Clean());
        }

        [TestMethod]
        public void ShouldTranslateSelectExpressionWithSkipAndTake()
        {
            var dbSelectQuery = new DbSelectQuery();
            var expression = dbSelectQuery.Select(e => e.Column("SomeColumn"))
                .From(e => e.Table("SomeTable")).Skip(2).Take(3);
            var result = QueryTranslator.Translate(expression);
            Assert.AreEqual(SelectExpressionWithSkipAndTakeSyntax.Clean(), result.Sql.Clean());
        }


        



        [TestMethod]
        public void ShouldTranslateNullWithEquals()
        {
            var expression = ExpressionFactory.Equal(ExpressionFactory.Column("SomeColumn"),ExpressionFactory.Constant(null));            
            var result = QueryTranslator.Translate(expression);
            Assert.AreEqual(NullCheckEqualsExpressionSyntax.Clean(), result.Sql.Clean());
        }

        [TestMethod]
        public void ShouldTranslateNullWithEqualsReversed()
        {
            var expression = ExpressionFactory.Equal(ExpressionFactory.Constant(null), ExpressionFactory.Column("SomeColumn"));
            var result = QueryTranslator.Translate(expression);
            Assert.AreEqual(NullCheckEqualsExpressionSyntax.Clean(), result.Sql.Clean());
        }

        [TestMethod]
        public void ShouldTranslateNullWithNotEquals()
        {
            var expression = ExpressionFactory.NotEqual(ExpressionFactory.Column("SomeColumn"), ExpressionFactory.Constant(null));
            var result = QueryTranslator.Translate(expression);
            Assert.AreEqual(NullCheckNotEqualsExpressionSyntax.Clean(), result.Sql.Clean());
        }

        [TestMethod]
        public void ShouldTranslateNullWithNotEqualsReversed()
        {
            var expression = ExpressionFactory.NotEqual(ExpressionFactory.Constant(null), ExpressionFactory.Column("SomeColumn"));
            var result = QueryTranslator.Translate(expression);
            Assert.AreEqual(NullCheckNotEqualsExpressionSyntax.Clean(), result.Sql.Clean());
        }

        


        public abstract string AndExpressionSyntax { get; }

        public abstract string AddExpressionSyntax { get; }

        public abstract string AliasExpressionSyntax { get; }
        
        public abstract string AssignExpressionSyntax { get; }

        public abstract string AssignNullExpressionSyntax { get; }

        public abstract string AvgExpressionSyntax { get; }

        public abstract string ColumnExpressionSyntax { get; }

        public abstract string ConcatExpressionSyntax { get; }

        public abstract string ConditionalExpressionSyntax { get; }

        public abstract string ConstantExpressionSyntax { get; }

        public abstract string CountExpressionSyntax { get; }

        public abstract string DivideExpressionSyntax { get; }

        public abstract string EqualExpressionSyntax { get; }
        
        public abstract string ExistsExpressionSyntax { get; }

        public abstract string GreaterThanExpressionSyntax { get; }

        public abstract string GreaterThanOrEqualExpressionSyntax { get; }

        public abstract string InValueRangeExpressionSyntax { get; }

        public abstract string InSubQueryExpressionSyntax { get; }

        public abstract string InnerJoinExpressionSyntax { get; }

        public abstract string LeftOuterJoinExpressionSyntax { get; }

        public abstract string RightOuterJoinExpressionSyntax { get; }

        public abstract string LengthExpressionSyntax { get; }

        public abstract string LessThanExpressionSyntax { get; }

        public abstract string LessThanOrEqualExpressionSyntax { get; }

        public abstract string ListExpressionSyntax { get; }

        public abstract string BatchExpressionSyntax { get; }
        
        public abstract string MaxExpressionSyntax { get; }

        public abstract string MinExpressionSyntax { get; }

        public abstract string MultiplyExpressionSyntax { get; }

        public abstract string SubstractExpressionSyntax { get; }

        public abstract string NotExpressionSyntax { get; }
        
        public abstract string DistinctExpressionSyntax { get; }

        public abstract string DistinctWithTopExpressionSyntax { get; }

        public abstract string NotEqualExpressionSyntax { get; }

        public abstract string OrExpressionSyntax { get; }
        
        public abstract string OrderByAscendingExpressionSyntax { get; }

        public abstract string OrderByDescendingExpressionSyntax { get; }

        public abstract string PrefixExpressionSyntax { get; }

        public abstract string ReplaceExpressionSyntax { get; }

        public abstract string ReverseExpressionSyntax { get; }

        public abstract string SoundExExpressionSyntax { get; }

        public abstract string SumExpressionSyntax { get; }

        public abstract string TableExpressionSyntax { get; }

        public abstract string ToLowerExpressionSyntax { get; }

        public abstract string ToUpperExpressionSyntax { get; }

        public abstract string TrimExpressionSyntax { get; }

        public abstract string TrimStartExpressionSyntax { get; }

        public abstract string TrimEndExpressionSyntax { get; }

        public abstract string SubStringExpressionSyntax { get; }

        public abstract string DateExpressionSyntax { get; }

        public abstract string YearExpressionSyntax { get; }

        public abstract string MonthExpressionSyntax { get; }

        public abstract string HourExpressionSyntax { get; }

        public abstract string MinuteExpressionSyntax { get; }

        public abstract string SecondExpressionSyntax { get; }

        public abstract string MillisecondExpressionSyntax { get; }

        public abstract string DayOfYearExpressionSyntax { get; }

        public abstract string DayOfMonthExpressionSyntax { get; }

        public abstract string DayOfWeekExpressionSyntax { get; }

        public abstract string AddYearsExpressionSyntax { get; }

        public abstract string AddMonthsExpressionSyntax { get; }

        public abstract string AddDaysExpressionSyntax { get; }

        public abstract string AddHoursExpressionSyntax { get; }
        
        public abstract string AddMinutesExpressionSyntax { get; }

        public abstract string AddSecondsExpressionSyntax { get; }
        
        public abstract string AddMilliSecondsExpressionSyntax { get; }

        public abstract string NowExpressionSyntax { get; }

        public abstract string ToDayExpressionSyntax { get; }
        
        public abstract string UpdateExpressionSyntax { get; }

        public abstract string UpdateExpressionWithAliasedTargetSyntax { get; }

        public abstract string UpdateExpressionWithFromClauseSyntax { get; }

        public abstract string InsertExpressionSyntax { get; }

        public abstract string DeleteExpressionSyntax { get; }

        public abstract string DeleteExpressionWithAliasedTargetSyntax { get; }

        public abstract string SelectExpressionSyntax { get; }
        
        public abstract string SelectExpressionWithTakeSyntax { get; }

        public abstract string SelectExpressionWithSkipSyntax { get; }

        public abstract string SelectExpressionWithSkipAndTakeSyntax { get; }

        public abstract string SelectExpressionWithOrderBySyntax { get; }

        public abstract string SelectExpressionWithGroupBySyntax { get; }

        public abstract string SelectExpressionWithGroupByHavingSyntax { get; }


        public abstract string AbsExpressionSyntax {get;}

        public abstract string AcosExpressionSyntax { get; }

        public abstract string AsinExpressionSyntax { get; }

        public abstract string AtanExpressionSyntax { get; }

        public abstract string Atan2ExpressionSyntax { get; }

        public abstract string CeilingExpressionSyntax { get; }

        public abstract string CosExpressionSyntax { get; }

        public abstract string CotExpressionSyntax { get; }

        public abstract string DegressExpressionSyntax { get; }

        public abstract string ExpExpressionSyntax { get; }

        public abstract string FloorExpressionSyntax { get; }

        public abstract string LogExpressionSyntax { get; }

        public abstract string Log10ExpressionSyntax { get; }

        public abstract string PIExpressionSyntax { get; }

        public abstract string PowerExpressionSyntax { get; }

        public abstract string RadiansExpressionSyntax { get; }

        public abstract string RandExpressionSyntax { get; }

        public abstract string RandWithSeedExpressionSyntax { get; }

        public abstract string RoundExpressionSyntax { get; }

        public abstract string SignExpressionSyntax { get; }

        public abstract string SinExpressionSyntax { get; }

        public abstract string SqrtExpressionSyntax { get; }

        public abstract string SquareExpressionSyntax { get; }

        public abstract string TanExpressionSyntax { get; }

        public abstract string NullCheckEqualsExpressionSyntax { get; }

        public abstract string NullCheckNotEqualsExpressionSyntax { get; }
    }
}
