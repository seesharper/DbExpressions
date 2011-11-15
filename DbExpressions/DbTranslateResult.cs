using System.Collections.Generic;
using System.Data;
using System.Data.Common;

namespace DbExpressions
{
    /// <summary>
    /// Represents the result of translating a <see cref="DbExpression"/> tree.
    /// </summary>
    public class DbTranslateResult
    {
        private readonly DbProviderFactory _dbProviderFactory;

        /// <summary>
        /// Initializes a new instance of the <see cref="DbTranslateResult"/> class.
        /// </summary>
        /// <param name="sql">The generated SQL statement.</param>
        /// <param name="parameters">A <see cref="List{T}"/> of <see cref="IDataParameter"/> 
        /// instances that are referenced in the query.</param>
        /// <param name="dbProviderFactory">The <see cref="DbProviderFactory"/> instance.</param>
        internal DbTranslateResult(string sql, IEnumerable<IDataParameter> parameters, DbProviderFactory dbProviderFactory)
        {
            _dbProviderFactory = dbProviderFactory;
            Sql = sql;
            Parameters = parameters;
        }
        
        /// <summary>
        /// Gets or sets a <see cref="IEnumerable{T}"/> that contains the 
        /// <see cref="IDataParameter"/> instances that has been created for constant expressions.
        /// </summary>
        public IEnumerable<IDataParameter> Parameters { get; private set; }

        /// <summary>
        /// Gets the Sql statement that has been created from a <see cref="DbExpression"/> tree.
        /// </summary>
        public string Sql { get; private set; }        


        /// <summary>
        /// Creates a new <see cref="IDbCommand"/> instance based on this <see cref="DbTranslateResult"/>.
        /// </summary>
        /// <returns><see cref="IDbCommand"/></returns>
        public IDbCommand CreateCommand()
        {
            var command = _dbProviderFactory.CreateCommand();
            if (command != null)
            {
                command.CommandText = Sql;
                foreach (var dataParameter in Parameters)
                {
                    command.Parameters.Add(dataParameter);
                }
                return command;
            }
            return null;
        }
    }
}
