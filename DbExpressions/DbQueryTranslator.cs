using System.Collections.Generic;
using System.Data;
using System.Data.Common;

namespace DbExpressions
{
    /// <summary>
    ///  Provides a base class for database-specific implementations.
    /// </summary>
    public abstract class DbQueryTranslator : DbExpressionVisitor
    {   

        private readonly DbCommandBuilder _commandBuilder;
        private readonly DbProviderFactory _providerFactory;


        /// <summary>
        /// Initializes a new instance of the <see cref="DbQueryTranslator"/> class.
        /// </summary>
        /// <param name="providerFactory"></param>
        protected DbQueryTranslator(DbProviderFactory providerFactory)
        {
            _providerFactory = providerFactory;
            _commandBuilder = _providerFactory.CreateCommandBuilder();
            Parameters = new List<IDataParameter>();
        }

        /// <summary>
        /// Translates the <paramref name="dbExpression"/> into a <see cref="DbTranslateResult"/> instance.
        /// </summary>
        /// <param name="dbExpression">The <see cref="DbExpression"/> to translate.</param>
        /// <returns><see cref="DbTranslateResult"/></returns>
        public virtual DbTranslateResult Translate(DbExpression dbExpression)
        {
            Parameters.Clear();
            var sqlExpression = Visit(dbExpression);
            var translateResult = new DbTranslateResult(((DbSqlExpression)sqlExpression).Sql,Parameters,_providerFactory);
            return translateResult;
        }
       
        /// <summary>
        /// Gets a list of <see cref="IDataParameter"/> instances. 
        /// </summary>
        protected IList<IDataParameter> Parameters { get; private set; }

        /// <summary>
        /// Quotes the <paramref name="unquotedIdentifier"/>.
        /// </summary>
        /// <param name="unquotedIdentifier">The original unquoted identifier.</param>
        /// <returns><see cref="string"/></returns>
        protected virtual string QuoteIdentifier(string unquotedIdentifier)
        {            
            return _commandBuilder.QuoteIdentifier(unquotedIdentifier);
        }

        /// <summary>
        /// Creates a new <see cref="IDataParameter"/> used in the result of the query translation.
        /// </summary>
        /// <param name="name">The name of the parameter.</param>
        /// <param name="value">The parameter value.</param>
        protected virtual void CreateParameter(string name, object value)
        {
            var parameter = _providerFactory.CreateParameter();
            parameter.ParameterName = name;
            parameter.Value = value;            
            Parameters.Add(parameter);
        }        
    }
}
