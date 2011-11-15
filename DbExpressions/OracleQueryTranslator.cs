using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace DbExpressions
{
    /// <summary>
    /// Translates a <see cref="DbExpression"/> into a Oracle specific string representation.
    /// </summary>     
    public class OracleQueryTranslator : DbQueryTranslator
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MySqlQueryTranslator"/> class.
        /// </summary>
        /// <param name="providerFactory">The <see cref="DbProviderFactory"/> that corresponds to this provider.</param>
        public OracleQueryTranslator(DbProviderFactory providerFactory)
            : base(providerFactory)
        {
        }


        public override DbTranslateResult Translate(DbExpression dbExpression)
        {
            dbExpression = ReplaceSquareWithPower(dbExpression);
            return base.Translate(dbExpression);
        }

        private DbExpression ReplaceSquareWithPower(DbExpression dbExpression)
        {
            return dbExpression.Replace<DbMathematicalFunctionExpression>(
                dme => dme.MathematicalFunctionExpressionType == DbMathematicalFunctionExpressionType.Square,
                te => ExpressionFactory.Power(te.Arguments[0], ExpressionFactory.Constant(2)));
        }


        private DbExpression AddRowNumWhereClause(DbExpression dbExpression)
        {
            //dbExpression.Replace<DbSelectQuery>(dsq => (dsq.GetQueryExpression().)
            return null;
        }


        /// <summary>
        /// Translates the <paramref name="binaryExpression"/> into a string representation.
        /// </summary>
        /// <param name="binaryExpression">The <see cref="DbBinaryExpression"/> to translate.</param>
        /// <returns><see cref="string"/></returns>
        protected override DbExpression VisitBinaryExpression(DbBinaryExpression binaryExpression)
        {
            var body = "({0}{1}{2})";
            if (binaryExpression.BinaryExpressionType == DbBinaryExpressionType.Assignment)
            {
                body = "{0} = {1}";
                return
                    ExpressionFactory.Sql(string.Format(body, Visit(binaryExpression.LeftExpression),
                                                        Visit(binaryExpression.RightExpression)));
            }

            var leftExpression = Visit(binaryExpression.LeftExpression);
            var rightExpression = Visit(binaryExpression.RightExpression);

            if (binaryExpression.RightExpression.ExpressionType == DbExpressionType.Constant && ((DbConstantExpression)binaryExpression.RightExpression).Value == null)
            {
                if (binaryExpression.BinaryExpressionType == DbBinaryExpressionType.Equal)
                    return ExpressionFactory.Sql(string.Format("({0} IS {1})", leftExpression, rightExpression));
                if (binaryExpression.BinaryExpressionType == DbBinaryExpressionType.NotEqual)
                    return ExpressionFactory.Sql(string.Format("({0} IS NOT {1})", leftExpression, rightExpression));
            }

            if (binaryExpression.LeftExpression.ExpressionType == DbExpressionType.Constant && ((DbConstantExpression)binaryExpression.LeftExpression).Value == null)
            {
                if (binaryExpression.BinaryExpressionType == DbBinaryExpressionType.Equal)
                    return ExpressionFactory.Sql(string.Format("({0} IS {1})", rightExpression, leftExpression));
                if (binaryExpression.BinaryExpressionType == DbBinaryExpressionType.NotEqual)
                    return ExpressionFactory.Sql(string.Format("({0} IS NOT {1})", rightExpression, leftExpression));
            }


            var sqlFragment = string.Format(body, leftExpression,
                 GetBinaryOperator(binaryExpression.BinaryExpressionType),
                                  rightExpression);
            return ExpressionFactory.Sql(sqlFragment);
        }

        /// <summary>
        /// Translates the <paramref name="stringFunctionExpression"/> into a string representation.
        /// </summary>
        /// <param name="stringFunctionExpression">The <see cref="DbStringFunctionExpression"/> to translate.</param>
        /// <returns><see cref="string"/></returns>
        protected override DbExpression VisitStringFunctionExpression(DbStringFunctionExpression stringFunctionExpression)
        {
            var functionName = GetStringFunctionBody(stringFunctionExpression.StringFunctionExpressionType);
            var functionSyntax = CreateDefaultFunctionSyntax(functionName, stringFunctionExpression.Arguments);
            return functionSyntax;
        }

        /// <summary>
        /// Translates the <paramref name="mathematicalFunctionExpression"/> into a string representation.
        /// </summary>
        /// <param name="mathematicalFunctionExpression">The <see cref="DbMathematicalFunctionExpression"/> to translate.</param>
        /// <returns><see cref="string"/></returns>
        protected override DbExpression VisitMathematicalFunctionExpression(DbMathematicalFunctionExpression mathematicalFunctionExpression)
        {
            var functionName = GetMathematicalFunctionBody(mathematicalFunctionExpression.MathematicalFunctionExpressionType);
            var functionSyntax = CreateDefaultFunctionSyntax(functionName, mathematicalFunctionExpression.Arguments);
            return functionSyntax;
        }

        /// <summary>
        /// Translates the <paramref name="aggregateFunctionExpression"/> into a string representation.
        /// </summary>
        /// <param name="aggregateFunctionExpression">The <see cref="DbAggregateFunctionExpression"/> to translate.</param>
        /// <returns><see cref="string"/></returns>
        protected override DbExpression VisitAggregateFunctionExpression(DbAggregateFunctionExpression aggregateFunctionExpression)
        {
            var functionName = GetAggregateFunctionBody(aggregateFunctionExpression.AggregateFunctionExpressionType);
            var functionSyntax = CreateDefaultFunctionSyntax(functionName, aggregateFunctionExpression.Arguments);
            return functionSyntax;
        }

        /// <summary>
        /// Translates the <paramref name="dateTimeFunctionExpression"/> into a string representation.
        /// </summary>
        /// <param name="dateTimeFunctionExpression">The <see cref="DbDateTimeFunctionExpression"/> to translate.</param>
        /// <returns><see cref="string"/></returns>
        protected override DbExpression VisitDateTimeFunctionExpression(DbDateTimeFunctionExpression dateTimeFunctionExpression)
        {
            string body = GetDateTimeFunctionBody(dateTimeFunctionExpression.DateTimeFunctionExpressionType);
            switch (dateTimeFunctionExpression.DateTimeFunctionExpressionType)
            {
                case DbDateTimeFunctionExpressionType.AddYears:
                case DbDateTimeFunctionExpressionType.AddMonths:
                case DbDateTimeFunctionExpressionType.AddDays:
                case DbDateTimeFunctionExpressionType.AddHours:
                case DbDateTimeFunctionExpressionType.AddMinutes:
                case DbDateTimeFunctionExpressionType.AddSeconds:
                case DbDateTimeFunctionExpressionType.AddMilliseconds:
                    return CreateDefaultDateTimeFunctionSyntax(body, dateTimeFunctionExpression.Arguments);
                default:
                    return CreateDefaultDateTimeFunctionSyntax(body, dateTimeFunctionExpression.Arguments);
            }
        }

        /// <summary>
        /// Creates the default syntax for calling the datetime function identified by <paramref name="functionBody"/>
        /// </summary>
        /// <param name="functionBody">The function body without the actual arguments</param>
        /// <param name="arguments">A list of <see cref="DbExpression"/> instances representing the function arguments.</param>
        /// <returns><see cref="string"/></returns>
        private DbSqlExpression CreateDefaultDateTimeFunctionSyntax(string functionBody, IEnumerable<DbExpression> arguments)
        {
            if (arguments.Count() == 0)
                return ExpressionFactory.Sql(functionBody);            
            var translatedArguments = arguments.Select(Visit).ToArray();
            var functionCall = string.Format(functionBody, translatedArguments);
            return ExpressionFactory.Sql(functionCall);
        }




        /// <summary>
        /// Translates the <paramref name="selectExpression"/> into a string representation.
        /// </summary>
        /// <param name="selectExpression">The <see cref="DbSelectExpression"/> to translate.</param>
        /// <returns><see cref="string"/></returns>
        protected override DbExpression VisitSelectExpression(DbSelectExpression selectExpression)
        {
            var sb = new StringBuilder();


            string pagingSyntax = null;
            if (ContainsSkipAndTake(selectExpression))            
                pagingSyntax = string.Format("ROWNUM <= {0} AND ROWNUM > {1} ", Visit(selectExpression.TakeExpression), Visit(selectExpression.SkipExpression));
            else if (ContainsTake(selectExpression))
                pagingSyntax = string.Format("ROWNUM <= {0} ", Visit(selectExpression.TakeExpression));
            else if (ContainsSkip(selectExpression))
                pagingSyntax = string.Format("ROWNUM > {0} ", Visit(selectExpression.SkipExpression));

            if (!selectExpression.ProjectionExpression.IsNull())
            {
                if (selectExpression.IsDistinct)
                    sb.Append("SELECT DISTINCT ");
                else
                    sb.Append("SELECT ");
                sb.AppendLine();
                sb.AppendFormat(1, "{0} ", Visit(selectExpression.ProjectionExpression));
            }

            if (!selectExpression.FromExpression.IsNull())
            {
                sb.AppendLine();
                sb.AppendLine("FROM ");
                sb.AppendFormat(1, "{0} ", Visit(selectExpression.FromExpression));
            }

            if (!selectExpression.WhereExpression.IsNull())
            {
                sb.AppendLine();
                sb.AppendLine("WHERE ");
                sb.AppendFormat(1, "{0} ", Visit(selectExpression.WhereExpression));
                if (pagingSyntax != null)
                    sb.AppendFormat(1, "AND {0} ", pagingSyntax);
            }
            else
            {
                if (pagingSyntax != null)
                {
                    sb.AppendLine("WHERE ");
                    sb.AppendFormat(1, "{0} ", pagingSyntax);
                }
            }


            if (!selectExpression.GroupByExpression.IsNull())
            {
                sb.AppendLine();
                sb.AppendLine("GROUP BY ");
                sb.AppendFormat(1, "{0} ", Visit(selectExpression.GroupByExpression));
            }

            if (!selectExpression.HavingExpression.IsNull())
            {
                sb.AppendLine();
                sb.AppendLine("HAVING ");
                sb.AppendFormat(1, "{0} ", Visit(selectExpression.HavingExpression));
            }

            if (!selectExpression.OrderByExpression.IsNull())
            {
                sb.AppendLine();
                sb.AppendLine("ORDER BY ");
                sb.AppendFormat(1, "{0} ", Visit(selectExpression.OrderByExpression));
            }
            
            if (selectExpression.IsSubQuery)
                return ExpressionFactory.Sql(string.Format("({0})", sb.ToString().Trim()));

            return ExpressionFactory.Sql(sb.ToString().Trim());
        }

        private static bool ContainsSkip(DbSelectExpression selectExpression)
        {
            return selectExpression.TakeExpression.IsNull() && !selectExpression.SkipExpression.IsNull();
        }

        private static bool ContainsTake(DbSelectExpression selectExpression)
        {
            return !selectExpression.TakeExpression.IsNull() && selectExpression.SkipExpression.IsNull();
        }

        private static bool ContainsSkipAndTake(DbSelectExpression selectExpression)
        {
            return !selectExpression.TakeExpression.IsNull() && !selectExpression.SkipExpression.IsNull();
        }


        /// <summary>
        /// Translates the <paramref name="updateExpression"/> into a string representation.
        /// </summary>
        /// <param name="updateExpression">The <see cref="DbUpdateExpression"/> to translate.</param>
        /// <returns><see cref="string"/></returns>
        protected override DbExpression VisitUpdateExpression(DbUpdateExpression updateExpression)
        {
            var sb = new StringBuilder();

            if (updateExpression.FromExpression.IsNull())
                sb.AppendFormat("UPDATE {0} ", Visit(updateExpression.Target));
            else
                sb.AppendFormat("UPDATE {0} ", Visit(updateExpression.FromExpression));


            if (!updateExpression.SetExpression.IsNull())
            {
                sb.AppendLine();
                sb.AppendFormat("SET {0} ", Visit(updateExpression.SetExpression));
            }

            if (!updateExpression.WhereExpression.IsNull())
            {
                sb.AppendLine();
                sb.AppendLine("WHERE ");
                sb.AppendFormat(1, "{0} ", Visit(updateExpression.WhereExpression));
            }

            return ExpressionFactory.Sql(sb.ToString().Trim());
        }

        /// <summary>
        /// Translates the <paramref name="insertExpression"/> into a string representation.
        /// </summary>
        /// <param name="insertExpression">The <see cref="DbInsertExpression"/> to translate.</param>
        /// <returns><see cref="string"/></returns>
        protected override DbExpression VisitInsertExpression(DbInsertExpression insertExpression)
        {
            var sb = new StringBuilder();
            sb.AppendFormat("INSERT INTO {0} ", Visit(insertExpression.Target));
            if (!insertExpression.TargetColumns.IsNull())
            {
                sb.AppendFormat("({0}) ", Visit(insertExpression.TargetColumns));
            }

            if (!insertExpression.Values.IsNull())
            {
                sb.AppendFormat("VALUES({0}) ", Visit(insertExpression.Values));
            }

            return ExpressionFactory.Sql(sb.ToString().Trim());
        }

        /// <summary>
        /// Translates the <paramref name="deleteExpression"/> into a string representation.
        /// </summary>
        /// <param name="deleteExpression">The <see cref="DbDeleteExpression"/> to translate.</param>
        /// <returns><see cref="string"/></returns>
        protected override DbExpression VisitDeleteExpression(DbDeleteExpression deleteExpression)
        {
            var sb = new StringBuilder();
            
            if (deleteExpression.FromExpression.IsNull())
            {
                sb.AppendFormat("DELETE FROM {0} ", Visit(deleteExpression.Target));
            }
            else
            {
                var aliasExpression = deleteExpression.FromExpression.Find<DbAliasExpression>(ae => ae.Target.Equals(deleteExpression.Target)).FirstOrDefault();
                if (aliasExpression.IsNull())
                    sb.AppendFormat("DELETE {0} ", Visit(deleteExpression.Target));
                else
                    sb.AppendFormat("DELETE {0} ", aliasExpression.Alias);
                sb.AppendLine();
                sb.AppendLine("FROM ");
                sb.AppendFormat(1, "{0} ", Visit(deleteExpression.FromExpression));
            }
            

            if (!deleteExpression.WhereExpression.IsNull())
            {
                sb.AppendLine();
                sb.AppendLine("WHERE ");
                sb.AppendFormat(1, "{0} ", Visit(deleteExpression.WhereExpression));
            }

            return ExpressionFactory.Sql(sb.ToString().Trim());
        }


        /// <summary>
        /// Translates the <paramref name="columnExpression"/> into a string representation.
        /// </summary>
        /// <param name="columnExpression">The <see cref="DbColumnExpression"/> to translate.</param>
        /// <returns><see cref="string"/></returns>
        protected override DbExpression VisitColumnExpression(DbColumnExpression columnExpression)
        {
            var sqlFragment = QuoteIdentifier(columnExpression.ColumnName);
            return ExpressionFactory.Sql(sqlFragment);
        }

        /// <summary>
        /// Translates the <paramref name="tableExpression"/> into a string representation.
        /// </summary>
        /// <param name="tableExpression">The <see cref="DbTableExpression"/> to translate.</param>
        /// <returns><see cref="string"/></returns>
        protected override DbExpression VisitTableExpression(DbTableExpression tableExpression)
        {
            var sqlFragment = QuoteIdentifier(tableExpression.TableName);
            return ExpressionFactory.Sql(sqlFragment);
        }

        /// <summary>
        /// Translates the <paramref name="constantExpression"/> into a string representation.
        /// </summary>
        /// <param name="constantExpression">The <see cref="DbConstantExpression"/> to translate.</param>
        /// <returns><see cref="string"/></returns>
        protected override DbExpression VisitConstantExpression(DbConstantExpression constantExpression)
        {
            if (constantExpression.Value == null)
                return ExpressionFactory.Sql("NULL");
            var parameterName = string.Format(":?p{0}", Parameters.Count());
            CreateParameter(parameterName, constantExpression.Value);
            return ExpressionFactory.Sql(parameterName);
        }

        /// <summary>
        /// Translates the <paramref name="aliasExpression"/> into a string representation.
        /// </summary>
        /// <param name="aliasExpression">The <see cref="DbAliasExpression"/> to translate.</param>
        /// <returns><see cref="string"/></returns>
        protected override DbExpression VisitAliasExpression(DbAliasExpression aliasExpression)
        {
            string syntax = string.Format("{0} {1}", Visit(aliasExpression.Target), aliasExpression.Alias);
            return ExpressionFactory.Sql(syntax);
        }

        /// <summary>
        /// Translates the <paramref name="concatExpression"/> into a string representation.
        /// </summary>
        /// <param name="concatExpression">The <see cref="DbConcatExpression"/> to translate.</param>
        /// <returns><see cref="string"/></returns>
        protected override DbExpression VisitConcatExpression(DbConcatExpression concatExpression)
        {
            string syntax = string.Format("{0} {1}", Visit(concatExpression.LeftExpression),
                                          Visit(concatExpression.RightExpression));
            return ExpressionFactory.Sql(syntax);
        }

        /// <summary>
        /// Translates the <paramref name="conditionalExpression"/> into a string representation.
        /// </summary>
        /// <param name="conditionalExpression">The <see cref="DbConditionalExpression"/> to translate.</param>
        /// <returns><see cref="string"/></returns>
        protected override DbExpression VisitConditionalExpression(DbConditionalExpression conditionalExpression)
        {
            string syntax = string.Format("CASE WHEN {0} THEN {1} ELSE {2} END", Visit(conditionalExpression.Condition),
                                          Visit(conditionalExpression.IfTrue), Visit(conditionalExpression.IfFalse));
            return ExpressionFactory.Sql(syntax);
        }

        /// <summary>
        /// Translates the <paramref name="existsExpression"/> into a string representation.
        /// </summary>
        /// <param name="existsExpression">The <see cref="DbExistsExpression"/> to translate.</param>
        /// <returns><see cref="string"/></returns>
        protected override DbExpression VisitExistsExpression(DbExistsExpression existsExpression)
        {
            var syntax = string.Format("EXISTS{0}", Visit(existsExpression.SubSelectExpression));
            return ExpressionFactory.Sql(syntax);
        }

        /// <summary>
        /// Translates the <paramref name="listExpression"/> into a string representation.
        /// </summary>
        /// <param name="listExpression">The <see cref="DbListExpression"/> to translate.</param>
        /// <returns><see cref="string"/></returns>
        protected override DbExpression VisitListExpression(DbListExpression listExpression)
        {
            if (listExpression.Count() == 0)
                return ExpressionFactory.Sql(string.Empty);
            //var syntax =  listExpression.Select(e => Visit(e)).Aggregate((current, next) => current + "," + next);
            var syntax = listExpression.Select(e => Visit(e).ToString()).Aggregate((current, next) => current + "," + next);
            return ExpressionFactory.Sql(syntax);
        }


        /// <summary>
        /// Translates the <paramref name="batchExpression"/> into a string representation.
        /// </summary>
        /// <param name="batchExpression">The <see cref="DbBatchExpression"/> to translate.</param>
        /// <returns><see cref="string"/></returns>
        protected override DbExpression VisitBatchExpression(DbBatchExpression batchExpression)
        {
            if (batchExpression.Count() == 0)
                return ExpressionFactory.Sql(string.Empty);
            var sb = new StringBuilder();
            sb.AppendLine("begin ");
            foreach (var dbExpression in batchExpression)
            {
                sb.AppendFormat(1, "{0};", Visit(dbExpression));
                sb.AppendLine();
            }
            sb.AppendLine(" end;");
            return ExpressionFactory.Sql(sb.ToString());
        }




        /// <summary>
        /// Translates the <paramref name="inExpression"/> into a string representation.
        /// </summary>
        /// <param name="inExpression">The <see cref="DbInExpression"/> to translate.</param>
        /// <returns><see cref="string"/></returns>
        protected override DbExpression VisitInExpression(DbInExpression inExpression)
        {
            string body = "{0} IN({1})";
            if (inExpression.Expression.ExpressionType == DbExpressionType.Query || inExpression.Expression.ExpressionType == DbExpressionType.Select)
                body = "{0} IN{1}";
            string syntax = string.Format(body, Visit(inExpression.Target), Visit(inExpression.Expression));
            return ExpressionFactory.Sql(syntax);
        }

        /// <summary>
        /// Translates the <paramref name="joinExpression"/> into a string representation.
        /// </summary>
        /// <param name="joinExpression">The <see cref="DbJoinExpression"/> to translate.</param>
        /// <returns><see cref="string"/></returns>
        protected override DbExpression VisitJoinExpression(DbJoinExpression joinExpression)
        {
            string body;
            switch (joinExpression.JoinExpressionType)
            {
                case DbJoinExpressionType.InnerJoin:
                    body = "INNER JOIN {0} ON {1}";
                    break;
                case DbJoinExpressionType.LeftOuterJoin:
                    body = "LEFT OUTER JOIN {0} ON {1}";
                    break;
                case DbJoinExpressionType.RightOuterJoin:
                    body = "RIGHT OUTER JOIN {0} ON {1}";
                    break;
                default:
                    throw new ArgumentOutOfRangeException("joinExpression",
                                                          string.Format(
                                                              "The JoinExpressionType '{0}' is not supported",
                                                              joinExpression.JoinExpressionType));
            }

            string syntax = string.Format(body, Visit(joinExpression.Target), Visit(joinExpression.Condition));
            return ExpressionFactory.Sql(syntax);
        }




        /// <summary>
        /// Translates the <paramref name="unaryExpression"/> into a string representation.
        /// </summary>
        /// <param name="unaryExpression">The <see cref="DbUnaryExpression"/> to translate.</param>
        /// <returns><see cref="string"/></returns>
        protected override DbExpression VisitUnaryExpression(DbUnaryExpression unaryExpression)
        {
            string syntax;

            switch (unaryExpression.UnaryExpressionType)
            {
                case DbUnaryExpressionType.Not:
                    syntax = string.Format("NOT {0}", Visit(unaryExpression.Operand));
                    break;
                case DbUnaryExpressionType.Cast:
                    syntax = string.Format("CAST({0} AS {1})",
                                           Visit(unaryExpression.Operand),
                                           GetCastFunctionBody(unaryExpression.TargetType));
                    break;
                default:
                    throw new ArgumentOutOfRangeException("unaryExpression",
                                                          string.Format(
                                                              "The UnaryExpressionType '{0}' is not supported",
                                                              unaryExpression.UnaryExpressionType));
            }

            return ExpressionFactory.Sql(syntax);
        }


        private static string GetCastFunctionBody(Type type)
        {
            if (type == typeof(string))
                return "VARCHAR(MAX)";
            if (type == typeof(int))
                return "INT";
            if (type == typeof(short))
                return "SMALLINT";
            if (type == typeof(byte))
                return "TINYINT";
            if (type == typeof(long))
                return "BIGINT";
            if (type == typeof(decimal))
                return "MONEY";
            if (type == typeof(double))
                return "FLOAT";
            if (type == typeof(DateTime))
                return "DATETIME";
            if (type == typeof(Guid))
                return "UNIQUEIDENTIFIER";
            if (type == typeof(bool))
                return "BIT";
            if (type == typeof(Single))
                return "REAL";
            throw new ArgumentOutOfRangeException("type", string.Format("No conversion exists for the type: {0}", type.Name));
        }


        /// <summary>
        /// Translates the <paramref name="orderByExpression"/> into a string representation.
        /// </summary>
        /// <param name="orderByExpression">The <see cref="DbOrderByExpression"/> to translate.</param>
        /// <returns><see cref="string"/></returns>
        protected override DbExpression VisitOrderByExpression(DbOrderByExpression orderByExpression)
        {
            string body = orderByExpression.OrderByExpressionType == DbOrderByExpressionType.Ascending
                              ? "{0} ASC"
                              : "{0} DESC";
            string syntax = string.Format(body, Visit(orderByExpression.Expression));
            return ExpressionFactory.Sql(syntax);
        }

        /// <summary>
        /// Translates the <paramref name="prefixExpression"/> into a string representation.
        /// </summary>
        /// <param name="prefixExpression">The <see cref="DbPrefixExpression"/> to translate.</param>
        /// <returns><see cref="string"/></returns>
        protected override DbExpression VisitPrefixExpression(DbPrefixExpression prefixExpression)
        {
            string syntax = string.Format("\"{0}\".{1}", prefixExpression.Prefix, Visit(prefixExpression.Target));
            return ExpressionFactory.Sql(syntax);

        }


        /// <summary>
        /// Gets the textual representation of the <paramref name="binaryExpressionType"/>
        /// </summary>
        /// <param name="binaryExpressionType">The <see cref="DbBinaryExpressionType"/> for which to return the textual representation.</param>
        /// <returns><see cref="string"/></returns>
        protected virtual string GetBinaryOperator(DbBinaryExpressionType binaryExpressionType)
        {
            switch (binaryExpressionType)
            {
                case DbBinaryExpressionType.And:
                    return " AND ";
                case DbBinaryExpressionType.Or:
                    return " OR ";
                case DbBinaryExpressionType.Equal:
                case DbBinaryExpressionType.Assignment:
                    return " = ";
                case DbBinaryExpressionType.NotEqual:
                    return " <> ";
                case DbBinaryExpressionType.GreaterThanOrEqual:
                    return " >= ";
                case DbBinaryExpressionType.GreaterThan:
                    return " > ";
                case DbBinaryExpressionType.LessThan:
                    return " < ";
                case DbBinaryExpressionType.LessThanOrEqual:
                    return " <= ";
                case DbBinaryExpressionType.Add:
                    return " + ";
                case DbBinaryExpressionType.Subtract:
                    return " - ";
                case DbBinaryExpressionType.Multiply:
                    return " * ";
                case DbBinaryExpressionType.Divide:
                    return " / ";
                default:
                    throw new ArgumentOutOfRangeException("binaryExpressionType", binaryExpressionType, "is not supported");
            }
        }

        /// <summary>
        /// Gets the textual representation of the <paramref name="aggregateFunctionExpressionType"/>
        /// </summary>
        /// <param name="aggregateFunctionExpressionType">The <see cref="DbAggregateFunctionExpressionType"/> for which to return the textual representation.</param>
        /// <returns><see cref="string"/></returns>
        protected virtual string GetAggregateFunctionBody(DbAggregateFunctionExpressionType aggregateFunctionExpressionType)
        {
            switch (aggregateFunctionExpressionType)
            {
                case DbAggregateFunctionExpressionType.Avg:
                    return "AVG({0})";
                case DbAggregateFunctionExpressionType.Count:
                    return "COUNT({0})";
                case DbAggregateFunctionExpressionType.Max:
                    return "MAX({0})";
                case DbAggregateFunctionExpressionType.Min:
                    return "MIN({0})";
                case DbAggregateFunctionExpressionType.Sum:
                    return "SUM({0})";
                default:
                    throw new ArgumentOutOfRangeException("aggregateFunctionExpressionType", aggregateFunctionExpressionType, " is not supported");
            }
        }

        /// <summary>
        /// Creates the default syntax for calling the function identified by <paramref name="functionBody"/>
        /// </summary>
        /// <param name="functionBody">The function body without the actual arguments</param>
        /// <param name="arguments">A list of <see cref="DbExpression"/> instances representing the function arguments.</param>
        /// <returns><see cref="string"/></returns>
        protected virtual DbSqlExpression CreateDefaultFunctionSyntax(string functionBody, IEnumerable<DbExpression> arguments)
        {
            if (arguments.Count() == 0)
                return ExpressionFactory.Sql(functionBody);
            var argumentString = arguments.Select(a => Visit(a).ToString()).Aggregate((current, next) => current + "," + next);
            var functionCall = string.Format(functionBody, argumentString);
            return ExpressionFactory.Sql(functionCall);
        }

        /// <summary>
        /// Returns the name of the function as it is defined in the target DBMS.
        /// </summary>
        /// <param name="stringFunctionExpressionType">The <see cref="DbStringFunctionExpressionType"/> that specifies the function name to return.</param>
        /// <returns><see cref="string"/></returns>
        protected virtual string GetStringFunctionBody(DbStringFunctionExpressionType stringFunctionExpressionType)
        {
            switch (stringFunctionExpressionType)
            {
                case DbStringFunctionExpressionType.Length:
                    return "LENGTH({0})";
                case DbStringFunctionExpressionType.Replace:
                    return "REPLACE({0})";
                case DbStringFunctionExpressionType.Reverse:
                    return "REVERSE({0})";
                case DbStringFunctionExpressionType.ToLower:
                    return "LOWER({0})";
                case DbStringFunctionExpressionType.ToUpper:
                    return "UPPER({0})";
                case DbStringFunctionExpressionType.Trim:
                    return "TRIM({0})";
                case DbStringFunctionExpressionType.TrimStart:
                    return "LTRIM({0})";
                case DbStringFunctionExpressionType.TrimEnd:
                    return "RTRIM({0})";
                case DbStringFunctionExpressionType.SoundEx:
                    return "SOUNDEX({0})";
                case DbStringFunctionExpressionType.SubString:
                    return "SUBSTR({0})";
                default:
                    throw new ArgumentOutOfRangeException("stringFunctionExpressionType", stringFunctionExpressionType, " is not supported");
            }

        }

        /// <summary>
        /// Returns the name of the function as it is defined in the target DBMS.
        /// </summary>
        /// <param name="mathematicalFunctionExpressionType">The <see cref="DbMathematicalFunctionExpressionType"/> that specifies the function name to return.</param>
        /// <returns><see cref="string"/></returns>
        protected virtual string GetMathematicalFunctionBody(DbMathematicalFunctionExpressionType mathematicalFunctionExpressionType)
        {
            switch (mathematicalFunctionExpressionType)
            {
                case DbMathematicalFunctionExpressionType.Abs:
                    return "ABS({0})";
                case DbMathematicalFunctionExpressionType.Acos:
                    return "ACOS({0})";
                case DbMathematicalFunctionExpressionType.Asin:
                    return "ASIN({0})";
                case DbMathematicalFunctionExpressionType.Atan:
                    return "ATAN({0})";
                case DbMathematicalFunctionExpressionType.Atan2:
                    return "ATAN2({0})";
                case DbMathematicalFunctionExpressionType.Ceiling:
                    return "CEIL({0})";
                case DbMathematicalFunctionExpressionType.Cos:
                    return "COS({0})";
                case DbMathematicalFunctionExpressionType.Cot:
                    return "COSH({0})";
                case DbMathematicalFunctionExpressionType.Degrees:
                    return "DEGREES({0})";
                case DbMathematicalFunctionExpressionType.Exp:
                    return "EXP({0})";
                case DbMathematicalFunctionExpressionType.Floor:
                    return "FLOOR({0})";
                case DbMathematicalFunctionExpressionType.Log:
                    return "LOG({0})";
                case DbMathematicalFunctionExpressionType.Log10:
                    return "LOG(10,{0})";
                case DbMathematicalFunctionExpressionType.PI:
                    return "ACOS(-1)";
                case DbMathematicalFunctionExpressionType.Power:
                    return "POWER({0})";
                case DbMathematicalFunctionExpressionType.Radians:
                    return "RADIANS({0})";
                case DbMathematicalFunctionExpressionType.Rand:
                    return "dbms_random.value";
                case DbMathematicalFunctionExpressionType.RandSeed:
                    return "RAND({0})";
                case DbMathematicalFunctionExpressionType.Round:
                    return "ROUND({0})";
                case DbMathematicalFunctionExpressionType.Sign:
                    return "SIGN({0})";
                case DbMathematicalFunctionExpressionType.Sin:
                    return "SIN({0})";
                case DbMathematicalFunctionExpressionType.Sqrt:
                    return "SQRT({0})";
                case DbMathematicalFunctionExpressionType.Tan:
                    return "TAN({0})";
                default:
                    throw new ArgumentOutOfRangeException("mathematicalFunctionExpressionType", mathematicalFunctionExpressionType, " is not supported");
            }
        }

        private static string GetDateTimeFunctionBody(DbDateTimeFunctionExpressionType dateTimeFunctionExpressionType)
        {
            switch (dateTimeFunctionExpressionType)
            {
                case DbDateTimeFunctionExpressionType.AddYears:
                    return "DATE_ADD({0}, INTERVAL {1} YEAR)";
                case DbDateTimeFunctionExpressionType.AddMonths:
                    return "DATE_ADD({0}, INTERVAL {1} MONTH)";
                case DbDateTimeFunctionExpressionType.AddDays:
                    return "{0} + {1}";
                case DbDateTimeFunctionExpressionType.AddHours:
                    return "{0} + ({1}/24)";
                case DbDateTimeFunctionExpressionType.AddMinutes:
                    return "DATE_ADD({0}, INTERVAL {1} MINUTE)";
                case DbDateTimeFunctionExpressionType.AddSeconds:
                    return "DATE_ADD({0}, INTERVAL {1} SECOND)";
                case DbDateTimeFunctionExpressionType.AddMilliseconds:                    
                    return "{0} + NUMTODSINTERVAL({1} / 1000, 'SECOND')";
                case DbDateTimeFunctionExpressionType.Date:
                    return "TRUNC({0})";
                case DbDateTimeFunctionExpressionType.DayOfMonth:
                    return "EXTRACT(DAY FROM {0})";
                case DbDateTimeFunctionExpressionType.DayOfWeek:
                    return "TO_CHAR({0} ,'D')";
                case DbDateTimeFunctionExpressionType.DayOfYear:
                    return "DAYOFYEAR({0})";
                case DbDateTimeFunctionExpressionType.Year:
                    return "EXTRACT(YEAR FROM {0})";
                case DbDateTimeFunctionExpressionType.Month:
                    return "EXTRACT(MONTH FROM {0})";
                case DbDateTimeFunctionExpressionType.Hour:
                    return "EXTRACT(HOUR FROM {0})";
                case DbDateTimeFunctionExpressionType.Minute:
                    return "EXTRACT(MINUTE FROM {0})";
                case DbDateTimeFunctionExpressionType.Second:
                    return "ROUND(EXTRACT(SECOND FROM {0}))";
                case DbDateTimeFunctionExpressionType.MilliSecond:
                    return "TO_CHAR({0},'FF3')";                
                case DbDateTimeFunctionExpressionType.Now:
                    return "CURRENT_TIMESTAMP()";
                case DbDateTimeFunctionExpressionType.ToDay:
                    return "TRUNC(CURRENT_DATE)";

                default:
                    throw new ArgumentOutOfRangeException("dateTimeFunctionExpressionType",
                                                          string.Format(
                                                              "The DateTimeFunctionExpressionType '{0}' is not supported",
                                                              dateTimeFunctionExpressionType));

            }
        }

    }
}
