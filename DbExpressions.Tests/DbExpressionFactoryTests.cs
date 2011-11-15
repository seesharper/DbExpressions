using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DbExpressions.Tests
{
    [TestClass]
    public class DbExpressionFactoryTests 
    {
        #region Factory Language Constructs

        [TestMethod]
        public void ShouldCreateTableExpression()
        {
            var factory = new DbExpressionFactory();
            var expression = factory.Table("SomeTable");
            Assert.IsNotNull(expression);
            Assert.IsNotNull(expression.TableName);
            Assert.IsTrue(expression.ExpressionType == DbExpressionType.Table);
        }

        [TestMethod]
        public void ShouldCreateAliasedTableExpression()
        {
            var factory = new DbExpressionFactory();
            var expression = factory.Table("SomeTable", "t0");
            Assert.IsNotNull(expression);
            Assert.IsNotNull(expression.Target);
            Assert.IsTrue(expression.ExpressionType == DbExpressionType.Alias);
        }


        [TestMethod]
        public void ShouldCreateColumnExpression()
        {
            var factory = new DbExpressionFactory();
            var expression = factory.Column("SomeColumn");
            Assert.IsNotNull(expression);
            Assert.IsNotNull(expression.ColumnName);
            Assert.IsTrue(expression.ExpressionType == DbExpressionType.Column);
        }

        [TestMethod]
        public void ShouldCreatePrefixedColumnExpression()
        {
            var factory = new DbExpressionFactory();
            var expression = factory.Column("t0", "SomeColumn");
            Assert.IsNotNull(expression);
            Assert.IsNotNull(expression.Target);
            Assert.IsNotNull(expression.Prefix);
            Assert.IsTrue(expression.ExpressionType == DbExpressionType.Prefix);
        }

        [TestMethod]
        public void ShouldCreateAliasExpression()
        {
            var factory = new DbExpressionFactory();
            var expression = factory.Alias(factory.Column("SomeColumn"), "sc");
            Assert.IsNotNull(expression.Target);
            Assert.IsNotNull(expression.Alias);
            Assert.IsTrue(expression.ExpressionType == DbExpressionType.Alias);
        }

        [TestMethod]
        public void ShouldCreateContantExpression()
        {
            var factory = new DbExpressionFactory();
            var expression = factory.Constant("SomeValue");
            Assert.IsNotNull(expression.Value);
            Assert.IsTrue(expression.ExpressionType == DbExpressionType.Constant);
        }


        [TestMethod]
        public void ShouldCreatePrefixExpression()
        {
            var factory = new DbExpressionFactory();
            var expression = factory.Prefix(factory.Column("SomeColumn"), "sc");
            Assert.IsNotNull(expression.Target);
            Assert.IsNotNull(expression.Prefix);
            Assert.IsTrue(expression.ExpressionType == DbExpressionType.Prefix);
        }

        [TestMethod]
        public void ShouldCreateOrderByAscendingExpression()
        {
            var factory = new DbExpressionFactory();
            var expression = factory.OrderByAscending(factory.Column("SomeColumn"));
            Assert.IsNotNull(expression.Expression);
            Assert.IsTrue(expression.OrderByExpressionType == DbOrderByExpressionType.Ascending);
            Assert.IsTrue(expression.ExpressionType == DbExpressionType.OrderBy);
        }
        
        [TestMethod]
        public void ShouldCreateOrderByDescendingExpression()
        {
            var factory = new DbExpressionFactory();
            var expression = factory.OrderByDescending(factory.Column("SomeColumn"));
            Assert.IsNotNull(expression.Expression);
            Assert.IsTrue(expression.OrderByExpressionType == DbOrderByExpressionType.Descending);
            Assert.IsTrue(expression.ExpressionType == DbExpressionType.OrderBy);
        }

        [TestMethod]
        public void ShouldCreateInnerJoinExpression()
        {
            var factory = new DbExpressionFactory();
            var expression = factory.InnerJoin(factory.Table("SomeTable"),
                                               factory.Column("SomeColumn") == factory.Column("SomeOtherColumn"));
            Assert.IsNotNull(expression.Condition);
            Assert.IsNotNull(expression.Target);

            Assert.IsTrue(expression.ExpressionType == DbExpressionType.Join);
            Assert.IsTrue(expression.JoinExpressionType == DbJoinExpressionType.InnerJoin);
        }

        [TestMethod]
        public void ShouldCreateLeftOuterExpression()
        {
            var factory = new DbExpressionFactory();
            var expression = factory.LeftOuterJoin(factory.Table("SomeTable"),
                                               factory.Column("SomeColumn") == factory.Column("SomeOtherColumn"));
            Assert.IsNotNull(expression.Condition);
            Assert.IsNotNull(expression.Target);

            Assert.IsTrue(expression.ExpressionType == DbExpressionType.Join);
            Assert.IsTrue(expression.JoinExpressionType == DbJoinExpressionType.LeftOuterJoin);
        }

        [TestMethod]
        public void ShouldCreateRightOuterExpression()
        {
            var factory = new DbExpressionFactory();
            var expression = factory.RightOuterJoin(factory.Table("SomeTable"),
                                               factory.Column("SomeColumn") == factory.Column("SomeOtherColumn"));
            Assert.IsNotNull(expression.Condition);
            Assert.IsNotNull(expression.Target);

            Assert.IsTrue(expression.ExpressionType == DbExpressionType.Join);
            Assert.IsTrue(expression.JoinExpressionType == DbJoinExpressionType.RightOuterJoin);
        }

        [TestMethod]
        public void ShouldCreateConcatExpression()
        {
            var factory = new DbExpressionFactory();
            var expression = factory.Concat(factory.Constant("DummyExpression"),
                                            factory.Constant("AnotherDummyExpression"));
            Assert.IsNotNull(expression.LeftExpression);
            Assert.IsNotNull(expression.RightExpression);
            Assert.IsTrue(expression.ExpressionType == DbExpressionType.Concat);
        }

        [TestMethod]
        public void ShouldCreateListExpression()
        {
            var factory = new DbExpressionFactory();
            var expression =
                factory.List(new DbExpression[] { factory.Column("SomeColumn"), factory.Column("SomeOtherColumn") });
            Assert.IsTrue(expression.Count() == 2);
            Assert.IsTrue(expression.ExpressionType == DbExpressionType.List);
        }

        [TestMethod]
        public void ShouldCreateEmptyListExpression()
        {
            var factory = new DbExpressionFactory();
            var expression =
                factory.List();
            Assert.IsTrue(expression.Count() == 0);
            Assert.IsTrue(expression.ExpressionType == DbExpressionType.List);
        }

        [TestMethod]
        public void ShouldCreateBatchExpression()
        {
            var factory = new DbExpressionFactory();
            var expression =
                factory.Batch(new DbExpression[] { factory.Column("SomeColumn"), factory.Column("SomeOtherColumn") });
            Assert.IsTrue(expression.Count() == 2);
            Assert.IsTrue(expression.ExpressionType == DbExpressionType.Batch);
        }



        [TestMethod]
        public void ShouldCreateConditionalExpression()
        {
            var factory = new DbExpressionFactory();
            var expression = factory.Conditional(factory.Column("SomeColumn") == factory.Constant("SomeValue"),
                                factory.Constant("ValueWhenTrue"), factory.Constant("ValueWhenFalse"));
            Assert.IsNotNull(expression.Condition);
            Assert.IsNotNull(expression.IfFalse);
            Assert.IsNotNull(expression.IfTrue);
            Assert.IsTrue(expression.ExpressionType == DbExpressionType.Conditional);
        }

        [TestMethod]
        public void ShouldCreateExistsExpression()
        {
            var factory = new DbExpressionFactory();
            var expression = factory.Exists(factory.Select(e => e.Column("SomeColumn")));
            Assert.IsNotNull(expression.SubSelectExpression);
            Assert.IsTrue(expression.ExpressionType == DbExpressionType.Exists);
        }

        [TestMethod]
        public void ShouldCreateInExpressionUsingValueRange()
        {
            var factory = new DbExpressionFactory();
            var expression = factory.In(factory.Column("SomeColumn"), new object[] { 1, 2 });
            Assert.IsNotNull(expression.Expression);
            Assert.IsTrue(expression.ExpressionType == DbExpressionType.In);
        }

        [TestMethod]
        public void ShouldCreateInExpressionUsingSubSelect()
        {
            var factory = new DbExpressionFactory();
            var expression = factory.In(factory.Column("SomeColumn"),
                                        factory.Select(f => f.Column("SomeOtherColumn")).From(e => e.Table("SomeTable")));
            Assert.IsNotNull(expression.Expression);
            Assert.IsTrue(expression.ExpressionType == DbExpressionType.In);
        }

        [TestMethod]
        public void ShouldCreateNotExpression()
        {
            var factory = new DbExpressionFactory();
            var expression = factory.Not(factory.In(factory.Column("SomeColumn"), new object[] { 1, 2 }));
            Assert.IsNotNull(expression.Operand);
            Assert.IsTrue(expression.ExpressionType == DbExpressionType.Unary);
            Assert.IsTrue(expression.UnaryExpressionType == DbUnaryExpressionType.Not);
        }
        

        #endregion

        #region Factory (Aggregate Functions)

        [TestMethod]
        public void ShouldCreateSumExpression()
        {
            var factory = new DbExpressionFactory();
            var aggregateExpression = factory.Sum(factory.Column("SomeColumn"));
            ValidateAggregateExpression(aggregateExpression, DbAggregateFunctionExpressionType.Sum);
        }

        [TestMethod]
        public void ShouldCreateAvgExpression()
        {
            var factory = new DbExpressionFactory();
            var aggregateExpression = factory.Avg(factory.Column("SomeColumn"));
            ValidateAggregateExpression(aggregateExpression, DbAggregateFunctionExpressionType.Avg);
        }

        [TestMethod]
        public void ShouldCreateCountExpression()
        {
            var factory = new DbExpressionFactory();
            var aggregateExpression = factory.Count(factory.Column("SomeColumn"));
            ValidateAggregateExpression(aggregateExpression, DbAggregateFunctionExpressionType.Count);
        }

        [TestMethod]
        public void ShouldCreateMaxExpression()
        {
            var factory = new DbExpressionFactory();
            var aggregateExpression = factory.Max(factory.Column("SomeColumn"));
            ValidateAggregateExpression(aggregateExpression, DbAggregateFunctionExpressionType.Max);
        }

        [TestMethod]
        public void ShouldCreateMinExpression()
        {
            var factory = new DbExpressionFactory();
            var aggregateExpression = factory.Min(factory.Column("SomeColumn"));
            ValidateAggregateExpression(aggregateExpression, DbAggregateFunctionExpressionType.Min);
        }


        [TestMethod]
        public void ShouldCreateCastExpression()
        {
            var factory = new DbExpressionFactory();
            var castExpression = factory.Cast(factory.Column("SomeColumn"), typeof(Int32));
            var test = castExpression.ToString();
        }


        private void ValidateAggregateExpression(DbAggregateFunctionExpression aggregateFunctionExpression, DbAggregateFunctionExpressionType aggregateFunctionExpressionType)
        {
            Assert.IsTrue(aggregateFunctionExpression.ExpressionType == DbExpressionType.Function);
            Assert.IsTrue(aggregateFunctionExpression.FunctionExpressionType == DbFunctionExpressionType.Aggregate);
            Assert.IsNotNull(aggregateFunctionExpression.Arguments);
            Assert.IsTrue(aggregateFunctionExpression.Arguments.Length > 0);
        }


        #endregion

        #region Factory (String Functions)

        [TestMethod]
        public void ShouldCreateLengthExpression()
        {
            var factory = new DbExpressionFactory();
            var stringFunctionExpression = factory.Length(factory.Column("SomeStringColumn"));
            ValidateStringFunctionExpression(stringFunctionExpression, DbStringFunctionExpressionType.Length);
        }

        [TestMethod]
        public void ShouldCreateReplaceExpression()
        {
            var factory = new DbExpressionFactory();
            var stringFunctionExpression = factory.Replace(factory.Column("SomeStringColumn"), factory.Constant("OldValue"), factory.Constant("NewValue"));
            ValidateStringFunctionExpression(stringFunctionExpression, DbStringFunctionExpressionType.Replace);
        }

        [TestMethod]
        public void ShouldCreateReverseExpression()
        {
            var factory = new DbExpressionFactory();
            var stringFunctionExpression = factory.Reverse(factory.Column("SomeStringColumn"));
            ValidateStringFunctionExpression(stringFunctionExpression, DbStringFunctionExpressionType.Reverse);
        }

        [TestMethod]
        public void ShouldCreateSoundExExpression()
        {
            var factory = new DbExpressionFactory();
            var stringFunctionExpression = factory.SoundEx(factory.Column("SomeStringColumn"));
            ValidateStringFunctionExpression(stringFunctionExpression, DbStringFunctionExpressionType.SoundEx);
        }

        [TestMethod]
        public void ShouldCreateSubStringExpression()
        {
            var factory = new DbExpressionFactory();
            var stringFunctionExpression = factory.SubString(factory.Column("SomeStringColumn"), factory.Constant(1), factory.Constant(2));
            ValidateStringFunctionExpression(stringFunctionExpression, DbStringFunctionExpressionType.SubString);
        }

        [TestMethod]
        public void ShouldCreateToLowerExpression()
        {
            var factory = new DbExpressionFactory();
            var stringFunctionExpression = factory.ToLower(factory.Column("SomeStringColumn"));
            ValidateStringFunctionExpression(stringFunctionExpression, DbStringFunctionExpressionType.ToLower);
        }

        [TestMethod]
        public void ShouldCreateToUpperExpression()
        {
            var factory = new DbExpressionFactory();
            var stringFunctionExpression = factory.ToUpper(factory.Column("SomeStringColumn"));
            ValidateStringFunctionExpression(stringFunctionExpression, DbStringFunctionExpressionType.ToUpper);
        }

        [TestMethod]
        public void ShouldCreateTrimExpression()
        {
            var factory = new DbExpressionFactory();
            var stringFunctionExpression = factory.Trim(factory.Column("SomeStringColumn"));
            ValidateStringFunctionExpression(stringFunctionExpression, DbStringFunctionExpressionType.Trim);
        }

        [TestMethod]
        public void ShouldCreateTrimStartExpression()
        {
            var factory = new DbExpressionFactory();
            var stringFunctionExpression = factory.TrimStart(factory.Column("SomeStringColumn"));
            ValidateStringFunctionExpression(stringFunctionExpression, DbStringFunctionExpressionType.TrimStart);
        }

        [TestMethod]
        public void ShouldCreateTrimStartEndExpression()
        {
            var factory = new DbExpressionFactory();
            var stringFunctionExpression = factory.TrimEnd(factory.Column("SomeStringColumn"));
            ValidateStringFunctionExpression(stringFunctionExpression, DbStringFunctionExpressionType.TrimEnd);
        }



        private void ValidateStringFunctionExpression(DbStringFunctionExpression stringFunctionExpression, DbStringFunctionExpressionType stringFunctionExpressionType)
        {
            Assert.IsTrue(stringFunctionExpression.ExpressionType == DbExpressionType.Function);
            Assert.IsTrue(stringFunctionExpression.StringFunctionExpressionType == stringFunctionExpressionType);
            Assert.IsNotNull(stringFunctionExpression.Arguments);
            Assert.IsTrue(stringFunctionExpression.Arguments.Length > 0);
        }

        private void ValidateDateTimeFunctionExpression(DbDateTimeFunctionExpression dateTimeFunctionExpression, DbDateTimeFunctionExpressionType dateTimeFunctionExpressionType)
        {
            Assert.IsTrue(dateTimeFunctionExpression.ExpressionType == DbExpressionType.Function);
            Assert.IsTrue(dateTimeFunctionExpression.DateTimeFunctionExpressionType == dateTimeFunctionExpressionType);
            Assert.IsNotNull(dateTimeFunctionExpression.Arguments);
        }

        private void ValidateMathematicalFunctionExpression(DbMathematicalFunctionExpression mathematicalFunctionExpression, DbMathematicalFunctionExpressionType mathematicalFunctionExpressionType)
        {
            Assert.IsTrue(mathematicalFunctionExpression.ExpressionType == DbExpressionType.Function);
            Assert.IsTrue(mathematicalFunctionExpression.MathematicalFunctionExpressionType == mathematicalFunctionExpressionType);
            Assert.IsNotNull(mathematicalFunctionExpression.Arguments);
        }


        #endregion

        #region Factory (Binary Expressions)

        [TestMethod]
        public void ShouldCreateAddExpression()
        {
            var factory = new DbExpressionFactory();
            DbBinaryExpression binaryExpression;
            binaryExpression = factory.Add(factory.Constant(1), factory.Constant(2));
            ValidateBinaryExpression(binaryExpression, DbBinaryExpressionType.Add);
        }

        [TestMethod]
        public void ShouldCreateAndExpression()
        {
            var factory = new DbExpressionFactory();
            DbBinaryExpression binaryExpression;
            binaryExpression = factory.And(factory.Constant(1), factory.Constant(2));
            ValidateBinaryExpression(binaryExpression, DbBinaryExpressionType.And);
        }

        [TestMethod]
        public void ShouldCreateAssignmentExpression()
        {
            var factory = new DbExpressionFactory();
            DbBinaryExpression binaryExpression;
            binaryExpression = factory.Assign(factory.Constant(1), factory.Constant(2));
            ValidateBinaryExpression(binaryExpression, DbBinaryExpressionType.Assignment);
        }

        [TestMethod]
        public void ShouldCreateDivideExpression()
        {
            var factory = new DbExpressionFactory();
            DbBinaryExpression binaryExpression;
            binaryExpression = factory.Divide(factory.Constant(1), factory.Constant(2));
            ValidateBinaryExpression(binaryExpression, DbBinaryExpressionType.Divide);
        }

        [TestMethod]
        public void ShouldCreateEqualExpression()
        {
            var factory = new DbExpressionFactory();
            DbBinaryExpression binaryExpression;
            binaryExpression = factory.Equal(factory.Constant(1), factory.Constant(2));
            ValidateBinaryExpression(binaryExpression, DbBinaryExpressionType.Equal);
        }

        [TestMethod]
        public void ShouldCreateGreaterThanExpression()
        {
            var factory = new DbExpressionFactory();
            DbBinaryExpression binaryExpression;
            binaryExpression = factory.GreaterThan(factory.Constant(1), factory.Constant(2));
            ValidateBinaryExpression(binaryExpression, DbBinaryExpressionType.GreaterThan);
        }

        [TestMethod]
        public void ShouldCreateGreaterThanOrEqualExpression()
        {
            var factory = new DbExpressionFactory();
            DbBinaryExpression binaryExpression;
            binaryExpression = factory.GreaterThanOrEqual(factory.Constant(1), factory.Constant(2));
            ValidateBinaryExpression(binaryExpression, DbBinaryExpressionType.GreaterThanOrEqual);
        }

        [TestMethod]
        public void ShouldCreateLessThanExpression()
        {
            var factory = new DbExpressionFactory();
            DbBinaryExpression binaryExpression;
            binaryExpression = factory.LessThan(factory.Constant(1), factory.Constant(2));
            ValidateBinaryExpression(binaryExpression, DbBinaryExpressionType.LessThan);
        }

        [TestMethod]
        public void ShouldCreateLessThanOrEqualExpression()
        {
            var factory = new DbExpressionFactory();
            DbBinaryExpression binaryExpression;
            binaryExpression = factory.LessThanOrEqual(factory.Constant(1), factory.Constant(2));
            ValidateBinaryExpression(binaryExpression, DbBinaryExpressionType.LessThanOrEqual);
        }

        [TestMethod]
        public void ShouldCreateMultiplyExpression()
        {
            var factory = new DbExpressionFactory();
            DbBinaryExpression binaryExpression;
            binaryExpression = factory.Multiply(factory.Constant(1), factory.Constant(2));
            ValidateBinaryExpression(binaryExpression, DbBinaryExpressionType.Multiply);
        }

        [TestMethod]
        public void ShouldCreateNotEqualExpression()
        {
            var factory = new DbExpressionFactory();
            DbBinaryExpression binaryExpression;
            binaryExpression = factory.NotEqual(factory.Constant(1), factory.Constant(2));
            ValidateBinaryExpression(binaryExpression, DbBinaryExpressionType.NotEqual);
        }

        [TestMethod]
        public void ShouldCreateOrExpression()
        {
            var factory = new DbExpressionFactory();
            DbBinaryExpression binaryExpression;
            binaryExpression = factory.Or(factory.Constant(1), factory.Constant(2));
            ValidateBinaryExpression(binaryExpression, DbBinaryExpressionType.Or);
        }

        [TestMethod]
        public void ShouldCreateSubstractExpression()
        {
            var factory = new DbExpressionFactory();
            DbBinaryExpression binaryExpression;
            binaryExpression = factory.Subtract(factory.Constant(1), factory.Constant(2));
            ValidateBinaryExpression(binaryExpression, DbBinaryExpressionType.Subtract);
        }

        [TestMethod]
        public void ShouldCreateAddYearsExpression()
        {
            var factory = new DbExpressionFactory();
            DbDateTimeFunctionExpression dateTimeFunctionExpression;
            dateTimeFunctionExpression = factory.AddYears(factory.Column("SomeDateTimeColumn"), factory.Constant(2));
            ValidateDateTimeFunctionExpression(dateTimeFunctionExpression, DbDateTimeFunctionExpressionType.AddYears);
        }

        [TestMethod]
        public void ShouldCreateAddMonthsExpression()
        {
            var factory = new DbExpressionFactory();
            DbDateTimeFunctionExpression dateTimeFunctionExpression;
            dateTimeFunctionExpression = factory.AddMonths(factory.Column("SomeDateTimeColumn"), factory.Constant(2));
            ValidateDateTimeFunctionExpression(dateTimeFunctionExpression, DbDateTimeFunctionExpressionType.AddMonths);
        }

        [TestMethod]
        public void ShouldCreateAddDaysExpression()
        {
            var factory = new DbExpressionFactory();
            DbDateTimeFunctionExpression dateTimeFunctionExpression;
            dateTimeFunctionExpression = factory.AddDays(factory.Column("SomeDateTimeColumn"), factory.Constant(2));
            ValidateDateTimeFunctionExpression(dateTimeFunctionExpression, DbDateTimeFunctionExpressionType.AddDays);
        }

        [TestMethod]
        public void ShouldCreateAddHoursExpression()
        {
            var factory = new DbExpressionFactory();
            DbDateTimeFunctionExpression dateTimeFunctionExpression;
            dateTimeFunctionExpression = factory.AddHours(factory.Column("SomeDateTimeColumn"), factory.Constant(2));
            ValidateDateTimeFunctionExpression(dateTimeFunctionExpression, DbDateTimeFunctionExpressionType.AddHours);
        }

        [TestMethod]
        public void ShouldCreateAddMinutesExpression()
        {
            var factory = new DbExpressionFactory();
            DbDateTimeFunctionExpression dateTimeFunctionExpression;
            dateTimeFunctionExpression = factory.AddMinutes(factory.Column("SomeDateTimeColumn"), factory.Constant(2));
            ValidateDateTimeFunctionExpression(dateTimeFunctionExpression, DbDateTimeFunctionExpressionType.AddMinutes);
        }


        [TestMethod]
        public void ShouldCreateAddSecondsExpression()
        {
            var factory = new DbExpressionFactory();
            DbDateTimeFunctionExpression dateTimeFunctionExpression;
            dateTimeFunctionExpression = factory.AddSeconds(factory.Column("SomeDateTimeColumn"), factory.Constant(2));
            ValidateDateTimeFunctionExpression(dateTimeFunctionExpression, DbDateTimeFunctionExpressionType.AddSeconds);
        }

        [TestMethod]
        public void ShouldCreateAddMillisecondsExpression()
        {
            var factory = new DbExpressionFactory();
            DbDateTimeFunctionExpression dateTimeFunctionExpression;
            dateTimeFunctionExpression = factory.AddMilliseconds(factory.Column("SomeDateTimeColumn"), factory.Constant(2));
            ValidateDateTimeFunctionExpression(dateTimeFunctionExpression, DbDateTimeFunctionExpressionType.AddMilliseconds);
        }

        [TestMethod]
        public void ShouldCreateDateExpression()
        {
            var factory = new DbExpressionFactory();
            DbDateTimeFunctionExpression dateTimeFunctionExpression;
            dateTimeFunctionExpression = factory.Date(factory.Column("SomeDateTimeColumn"));
            ValidateDateTimeFunctionExpression(dateTimeFunctionExpression, DbDateTimeFunctionExpressionType.Date);
        }

        [TestMethod]
        public void ShouldCreateYearExpression()
        {
            var factory = new DbExpressionFactory();
            DbDateTimeFunctionExpression dateTimeFunctionExpression;
            dateTimeFunctionExpression = factory.Year(factory.Column("SomeDateTimeColumn"));
            ValidateDateTimeFunctionExpression(dateTimeFunctionExpression, DbDateTimeFunctionExpressionType.Year);
        }

        [TestMethod]
        public void ShouldCreateMonthExpression()
        {
            var factory = new DbExpressionFactory();
            DbDateTimeFunctionExpression dateTimeFunctionExpression;
            dateTimeFunctionExpression = factory.Month(factory.Column("SomeDateTimeColumn"));
            ValidateDateTimeFunctionExpression(dateTimeFunctionExpression, DbDateTimeFunctionExpressionType.Month);
        }

        [TestMethod]
        public void ShouldCreateHourExpression()
        {
            var factory = new DbExpressionFactory();
            DbDateTimeFunctionExpression dateTimeFunctionExpression;
            dateTimeFunctionExpression = factory.Hour(factory.Column("SomeDateTimeColumn"));
            ValidateDateTimeFunctionExpression(dateTimeFunctionExpression, DbDateTimeFunctionExpressionType.Hour);
        }

        [TestMethod]
        public void ShouldCreateMinuteExpression()
        {
            var factory = new DbExpressionFactory();
            DbDateTimeFunctionExpression dateTimeFunctionExpression;
            dateTimeFunctionExpression = factory.Minute(factory.Column("SomeDateTimeColumn"));
            ValidateDateTimeFunctionExpression(dateTimeFunctionExpression, DbDateTimeFunctionExpressionType.Minute);
        }

        [TestMethod]
        public void ShouldCreateSecondExpression()
        {
            var factory = new DbExpressionFactory();
            DbDateTimeFunctionExpression dateTimeFunctionExpression;
            dateTimeFunctionExpression = factory.Second(factory.Column("SomeDateTimeColumn"));
            ValidateDateTimeFunctionExpression(dateTimeFunctionExpression, DbDateTimeFunctionExpressionType.Second);
        }

        [TestMethod]
        public void ShouldCreateMillisecondExpression()
        {
            var factory = new DbExpressionFactory();
            DbDateTimeFunctionExpression dateTimeFunctionExpression;
            dateTimeFunctionExpression = factory.Millisecond(factory.Column("SomeDateTimeColumn"));
            ValidateDateTimeFunctionExpression(dateTimeFunctionExpression, DbDateTimeFunctionExpressionType.MilliSecond);
        }

        [TestMethod]
        public void ShouldCreateDayOfYearExpression()
        {
            var factory = new DbExpressionFactory();
            DbDateTimeFunctionExpression dateTimeFunctionExpression;
            dateTimeFunctionExpression = factory.DayOfYear(factory.Column("SomeDateTimeColumn"));
            ValidateDateTimeFunctionExpression(dateTimeFunctionExpression, DbDateTimeFunctionExpressionType.DayOfYear);
        }

        [TestMethod]
        public void ShouldCreateDayOfMonthExpression()
        {
            var factory = new DbExpressionFactory();
            DbDateTimeFunctionExpression dateTimeFunctionExpression;
            dateTimeFunctionExpression = factory.DayOfMonth(factory.Column("SomeDateTimeColumn"));
            ValidateDateTimeFunctionExpression(dateTimeFunctionExpression, DbDateTimeFunctionExpressionType.DayOfMonth);
        }

        [TestMethod]
        public void ShouldCreateDayOfWeekExpression()
        {
            var factory = new DbExpressionFactory();
            DbDateTimeFunctionExpression dateTimeFunctionExpression;
            dateTimeFunctionExpression = factory.DayOfWeek(factory.Column("SomeDateTimeColumn"));
            ValidateDateTimeFunctionExpression(dateTimeFunctionExpression, DbDateTimeFunctionExpressionType.DayOfWeek);
        }

        [TestMethod]
        public void ShouldCreateNowExpression()
        {
            var factory = new DbExpressionFactory();
            DbDateTimeFunctionExpression dateTimeFunctionExpression;
            dateTimeFunctionExpression = factory.Now();
            ValidateDateTimeFunctionExpression(dateTimeFunctionExpression, DbDateTimeFunctionExpressionType.Now);
        }



        private void ValidateBinaryExpression(DbBinaryExpression binaryExpression, DbBinaryExpressionType binaryExpressionType)
        {
            Assert.IsNotNull(binaryExpression);
            Assert.IsNotNull(binaryExpression.LeftExpression);
            Assert.IsNotNull(binaryExpression.RightExpression);
            Assert.IsTrue(binaryExpression.ExpressionType == DbExpressionType.Binary);
            Assert.IsTrue(binaryExpression.BinaryExpressionType == binaryExpressionType);
        }

        #endregion    

        #region Factory (Mathematical Expression)

        [TestMethod]
        public void ShouldCreateAbsExpression()
        {
            var factory = new DbExpressionFactory();
            DbMathematicalFunctionExpression mathematicalFunctionExpression = factory.Abs(factory.Column("SomeColumn"));
            ValidateMathematicalFunctionExpression(mathematicalFunctionExpression, DbMathematicalFunctionExpressionType.Abs);
        }

        [TestMethod]
        public void ShouldCreateAcosExpression()
        {
            var factory = new DbExpressionFactory();
            DbMathematicalFunctionExpression mathematicalFunctionExpression = factory.Acos(factory.Column("SomeColumn"));
            ValidateMathematicalFunctionExpression(mathematicalFunctionExpression, DbMathematicalFunctionExpressionType.Acos);
        }

        [TestMethod]
        public void ShouldCreateAsinExpression()
        {
            var factory = new DbExpressionFactory();
            DbMathematicalFunctionExpression mathematicalFunctionExpression = factory.Asin(factory.Column("SomeColumn"));
            ValidateMathematicalFunctionExpression(mathematicalFunctionExpression, DbMathematicalFunctionExpressionType.Asin);
        }

        [TestMethod]
        public void ShouldCreateAtanExpression()
        {
            var factory = new DbExpressionFactory();
            DbMathematicalFunctionExpression mathematicalFunctionExpression = factory.Atan(factory.Column("SomeColumn"));
            ValidateMathematicalFunctionExpression(mathematicalFunctionExpression, DbMathematicalFunctionExpressionType.Atan);
        }

        [TestMethod]
        public void ShouldCreateAtan2Expression()
        {
            var factory = new DbExpressionFactory();
            DbMathematicalFunctionExpression mathematicalFunctionExpression = factory.Atan2(factory.Column("SomeColumn"), factory.Constant(1));
            ValidateMathematicalFunctionExpression(mathematicalFunctionExpression, DbMathematicalFunctionExpressionType.Atan2);
        }

        [TestMethod]
        public void ShouldCreateCeilingExpression()
        {
            var factory = new DbExpressionFactory();
            DbMathematicalFunctionExpression mathematicalFunctionExpression = factory.Ceiling(factory.Column("SomeColumn"));
            ValidateMathematicalFunctionExpression(mathematicalFunctionExpression, DbMathematicalFunctionExpressionType.Ceiling);
        }

        [TestMethod]
        public void ShouldCreateCosExpression()
        {
            var factory = new DbExpressionFactory();
            DbMathematicalFunctionExpression mathematicalFunctionExpression = factory.Cos(factory.Column("SomeColumn"));
            ValidateMathematicalFunctionExpression(mathematicalFunctionExpression, DbMathematicalFunctionExpressionType.Cos);
        }

        [TestMethod]
        public void ShouldCreateCotExpression()
        {
            var factory = new DbExpressionFactory();
            DbMathematicalFunctionExpression mathematicalFunctionExpression = factory.Cot(factory.Column("SomeColumn"));
            ValidateMathematicalFunctionExpression(mathematicalFunctionExpression, DbMathematicalFunctionExpressionType.Cot);
        }

        [TestMethod]
        public void ShouldCreateDegreesExpression()
        {
            var factory = new DbExpressionFactory();
            DbMathematicalFunctionExpression mathematicalFunctionExpression = factory.Degrees(factory.Column("SomeColumn"));
            ValidateMathematicalFunctionExpression(mathematicalFunctionExpression, DbMathematicalFunctionExpressionType.Degrees);
        }

        [TestMethod]
        public void ShouldCreateExpExpression()
        {
            var factory = new DbExpressionFactory();
            DbMathematicalFunctionExpression mathematicalFunctionExpression = factory.Exp(factory.Column("SomeColumn"));
            ValidateMathematicalFunctionExpression(mathematicalFunctionExpression, DbMathematicalFunctionExpressionType.Exp);
        }

        [TestMethod]
        public void ShouldCreateFloorExpression()
        {
            var factory = new DbExpressionFactory();
            DbMathematicalFunctionExpression mathematicalFunctionExpression = factory.Floor(factory.Column("SomeColumn"));
            ValidateMathematicalFunctionExpression(mathematicalFunctionExpression, DbMathematicalFunctionExpressionType.Floor);
        }

        [TestMethod]
        public void ShouldCreateLogExpression()
        {
            var factory = new DbExpressionFactory();
            DbMathematicalFunctionExpression mathematicalFunctionExpression = factory.Log(factory.Column("SomeColumn"));
            ValidateMathematicalFunctionExpression(mathematicalFunctionExpression, DbMathematicalFunctionExpressionType.Log);
        }

        [TestMethod]
        public void ShouldCreateLog10Expression()
        {
            var factory = new DbExpressionFactory();
            DbMathematicalFunctionExpression mathematicalFunctionExpression = factory.Log10(factory.Column("SomeColumn"));
            ValidateMathematicalFunctionExpression(mathematicalFunctionExpression, DbMathematicalFunctionExpressionType.Log10);
        }

        [TestMethod]
        public void ShouldCreatePIExpression()
        {
            var factory = new DbExpressionFactory();
            DbMathematicalFunctionExpression mathematicalFunctionExpression = factory.PI();
            ValidateMathematicalFunctionExpression(mathematicalFunctionExpression, DbMathematicalFunctionExpressionType.PI);
        }

        [TestMethod]
        public void ShouldCreatePowerExpression()
        {
            var factory = new DbExpressionFactory();
            DbMathematicalFunctionExpression mathematicalFunctionExpression = factory.Power(factory.Column("SomeColumn"),factory.Constant(2));
            ValidateMathematicalFunctionExpression(mathematicalFunctionExpression, DbMathematicalFunctionExpressionType.Power);
        }

        [TestMethod]
        public void ShouldCreateRadiansExpression()
        {
            var factory = new DbExpressionFactory();
            DbMathematicalFunctionExpression mathematicalFunctionExpression = factory.Radians(factory.Column("SomeColumn"));
            ValidateMathematicalFunctionExpression(mathematicalFunctionExpression, DbMathematicalFunctionExpressionType.Radians);
        }

        [TestMethod]
        public void ShouldCreateRandExpression()
        {
            var factory = new DbExpressionFactory();
            DbMathematicalFunctionExpression mathematicalFunctionExpression = factory.Rand();
            ValidateMathematicalFunctionExpression(mathematicalFunctionExpression, DbMathematicalFunctionExpressionType.Rand);
        }

        [TestMethod]
        public void ShouldCreateRandWithSeedExpression()
        {
            var factory = new DbExpressionFactory();
            DbMathematicalFunctionExpression mathematicalFunctionExpression = factory.Rand(factory.Constant(10));
            ValidateMathematicalFunctionExpression(mathematicalFunctionExpression, DbMathematicalFunctionExpressionType.RandSeed);
        }



        [TestMethod]
        public void ShouldCreateRoundExpression()
        {
            var factory = new DbExpressionFactory();
            DbMathematicalFunctionExpression mathematicalFunctionExpression = factory.Round(factory.Column("SomeColumn"), factory.Constant(2));
            ValidateMathematicalFunctionExpression(mathematicalFunctionExpression, DbMathematicalFunctionExpressionType.Round);
        }

        [TestMethod]
        public void ShouldCreateSignExpression()
        {
            var factory = new DbExpressionFactory();
            DbMathematicalFunctionExpression mathematicalFunctionExpression = factory.Sign(factory.Column("SomeColumn"));
            ValidateMathematicalFunctionExpression(mathematicalFunctionExpression, DbMathematicalFunctionExpressionType.Sign);
        }

        [TestMethod]
        public void ShouldCreateSinExpression()
        {
            var factory = new DbExpressionFactory();
            DbMathematicalFunctionExpression mathematicalFunctionExpression = factory.Sin(factory.Column("SomeColumn"));
            ValidateMathematicalFunctionExpression(mathematicalFunctionExpression, DbMathematicalFunctionExpressionType.Sin);
        }

        [TestMethod]
        public void ShouldCreateSqrtExpression()
        {
            var factory = new DbExpressionFactory();
            DbMathematicalFunctionExpression mathematicalFunctionExpression = factory.Sqrt(factory.Column("SomeColumn"));
            ValidateMathematicalFunctionExpression(mathematicalFunctionExpression, DbMathematicalFunctionExpressionType.Sqrt);
        }

        [TestMethod]
        public void ShouldCreateSquareExpression()
        {
            var factory = new DbExpressionFactory();
            DbMathematicalFunctionExpression mathematicalFunctionExpression = factory.Square(factory.Column("SomeColumn"));
            ValidateMathematicalFunctionExpression(mathematicalFunctionExpression, DbMathematicalFunctionExpressionType.Square);
        }

        [TestMethod]
        public void ShouldCreateTanExpression()
        {
            var factory = new DbExpressionFactory();
            DbMathematicalFunctionExpression mathematicalFunctionExpression = factory.Tan(factory.Column("SomeColumn"));
            ValidateMathematicalFunctionExpression(mathematicalFunctionExpression, DbMathematicalFunctionExpressionType.Tan);
        }
        

        #endregion

        #region Operator Overloading

        [TestMethod]
        public void ShouldCreateEqualsUsingOperatorOverloading()
        {
            var factory = new DbExpressionFactory();
            var expression = (DbBinaryExpression) (factory.Column("SomeColumn") == 1);
            Assert.AreEqual(DbBinaryExpressionType.Equal, expression.BinaryExpressionType);            
        }

        [TestMethod]
        public void ShouldCreateGreaterThanOrEqualsUsingOperatorOverloading()
        {
            var factory = new DbExpressionFactory();
            var expression = (DbBinaryExpression)(factory.Column("SomeColumn") >= 1);
            Assert.AreEqual(DbBinaryExpressionType.GreaterThanOrEqual, expression.BinaryExpressionType);
        }

        [TestMethod]
        public void ShouldCreateGreaterThanUsingOperatorOverloading()
        {
            var factory = new DbExpressionFactory();
            var expression = (DbBinaryExpression)(factory.Column("SomeColumn") > 1);
            Assert.AreEqual(DbBinaryExpressionType.GreaterThan, expression.BinaryExpressionType);
        }

        [TestMethod]
        public void ShouldCreateLessThanUsingOperatorOverloading()
        {
            var factory = new DbExpressionFactory();
            var expression = (DbBinaryExpression)(factory.Column("SomeColumn") < 1);
            Assert.AreEqual(DbBinaryExpressionType.LessThan, expression.BinaryExpressionType);
        }

        [TestMethod]
        public void ShouldCreateLessThanOrEqualUsingOperatorOverloading()
        {
            var factory = new DbExpressionFactory();
            var expression = (DbBinaryExpression)(factory.Column("SomeColumn") <= 1);
            Assert.AreEqual(DbBinaryExpressionType.LessThanOrEqual, expression.BinaryExpressionType);
        }

        [TestMethod]
        public void ShouldCreateNotEqualOperatorOverloading()
        {
            var factory = new DbExpressionFactory();
            var expression = (DbBinaryExpression)(factory.Column("SomeColumn") != 1);
            Assert.AreEqual(DbBinaryExpressionType.NotEqual, expression.BinaryExpressionType);
        }

        [TestMethod]
        public void ShouldCreateAndUsingOperatorOverloading()
        {
            var factory = new DbExpressionFactory();
            var expression = (DbBinaryExpression)(factory.Column("SomeColumn") & factory.Column("SomeOtherColumn"));
            Assert.AreEqual(DbBinaryExpressionType.And, expression.BinaryExpressionType);
        }

        [TestMethod]
        public void ShouldCreateOrUsingOperatorOverloading()
        {
            var factory = new DbExpressionFactory();
            var expression = (DbBinaryExpression)(factory.Column("SomeColumn") | factory.Column("SomeOtherColumn"));
            Assert.AreEqual(DbBinaryExpressionType.Or, expression.BinaryExpressionType);
        }

        [TestMethod]
        public void ShoudCreateConstantExpressionWhenCheckingForNull()
        {
            var factory = new DbExpressionFactory();
            var expression = (DbBinaryExpression)(factory.Column("SomeColumn") == null);
            Assert.IsNotNull(expression.RightExpression);
        }

        [TestMethod]
        public void ShoudCreateConstantExpressionWhenCheckingForNotNull()
        {
            var factory = new DbExpressionFactory();
            var expression = (DbBinaryExpression)(factory.Column("SomeColumn") != null);
            Assert.IsNotNull(expression.RightExpression);
        }
        #endregion

        #region Utility Functions

        [TestMethod]
        public void ShouldFindExpressionsOfParticularTypeUsingPredicate()
        {
            var dbSelectQuery = new DbSelectQuery();
            var expression = dbSelectQuery.Select(f => f.Column("SomeColumn")).From(f => f.Table("SomeTable"));
            var result = expression.Find<DbColumnExpression>(c => c.ColumnName == "SomeColumn");
            Assert.IsTrue(result.Count() == 1);
        }

        [TestMethod]
        public void ShouldReplaceExpressionsOfParticularTypeUsingPredicate()
        {
            var factory = new DbExpressionFactory();
            var dbSelectQuery = new DbSelectQuery();
            var expression = dbSelectQuery.Select(f => f.Column("SomeColumn")).From(f => f.Table("SomeTable"));
            expression.Replace<DbTableExpression>(te => true, te => factory.Alias(te, "t0"));
            var result = expression.Find<DbAliasExpression>(ae => true);
            Assert.IsTrue(result.Count() == 1);
        }

        [TestMethod]
        public void ShouldCreateAliasExpressionUsingAsExtension()
        {
            var factory = new DbExpressionFactory();
            var tableExpression = factory.Table("SomeTable");
            var aliasExpression = tableExpression.As("t0");
            Assert.AreEqual(DbExpressionType.Alias,aliasExpression.ExpressionType);
        }


        #endregion
    }
}
