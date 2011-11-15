using System.Data;

namespace DbExpressions
{

    /// <summary>
    /// Provides the common interface for implementing <see cref="DbQuery{TQueryExpression}"/>
    /// </summary>
    public abstract class DbQuery : DbExpression
    {        
        /// <summary>
        /// Returns the <see cref="DbExpression"/> that the <see cref="DbQuery{TQueryExpression}"/> implementation operates on.
        /// </summary>
        /// <remarks>
        /// This method may not be needed when proper covariance is added to the .Net framework.
        /// </remarks>
        /// <returns><see cref="DbExpression"/></returns>
        internal abstract DbQueryExpression GetQueryExpression();

    }

    /// <summary>
    /// Provides the common interface for implementing <see cref="DbQuery{TQueryExpression}"/>
    /// </summary>
    /// <typeparam name="TQueryExpression"></typeparam>
    public abstract class DbQuery<TQueryExpression> : 
        DbQuery where TQueryExpression:DbQueryExpression, new()
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="DbQuery{TQueryExpression}"/> class.
        /// </summary>
        internal DbQuery()
        {
            QueryExpression = new TQueryExpression();
        }

        /// <summary>
        /// Gets the <see cref="DbExpressionType"/> of the <see cref="DbExpression"/>.
        /// </summary>
        /// <value></value>
        public override DbExpressionType ExpressionType
        {
            get { return DbExpressionType.Query; }
        }
        
        /// <summary>
        /// Gets or sets the <see cref="DbQueryExpression"/> that this <see cref="DbQuery{TQueryExpression}"/> operates on.
        /// </summary>
        internal TQueryExpression QueryExpression { get; set; }

      
        internal override DbQueryExpression GetQueryExpression()
        {
            return QueryExpression;
        }

        /// <summary>
        /// Translates the query into an executable <see cref="IDbCommand"/> instance using the default provider.       
        /// </summary>
        /// <returns><see cref="IDbCommand"/></returns>
        public IDbCommand Translate()
        {
            var translator = DbQueryTranslatorFactory.GetQueryTranslator();
            return translator.Translate(this).CreateCommand();            
        }

        /// <summary>
        /// Translates the query into an executable <see cref="IDbCommand"/> instance.
        /// </summary>
        /// <param name="providerName">The name of the provider used translate the query.</param>
        /// <returns><see cref="IDbCommand"/></returns>
        public IDbCommand Translate(string providerName)
        {
            var translator = DbQueryTranslatorFactory.GetQueryTranslator(providerName);
            return translator.Translate(this).CreateCommand();
        }
    }

    /// <summary>
    /// Represents a "SELECT" query.
    /// </summary>
    public class DbSelectQuery : DbQuery<DbSelectExpression>
    {
        
    }

    /// <summary>
    /// Represents an "UPDATE" query.
    /// </summary>
    public class DbUpdateQuery : DbQuery<DbUpdateExpression>
    {

    }

    /// <summary>
    /// Represents an "UPDATE" query.
    /// </summary>
    public class DbInsertQuery : DbQuery<DbInsertExpression>
    {

    }

    /// <summary>
    /// Represents a "DELETE" query.
    /// </summary>
    public class DbDeleteQuery : DbQuery<DbDeleteExpression>
    {
        
    }

}
