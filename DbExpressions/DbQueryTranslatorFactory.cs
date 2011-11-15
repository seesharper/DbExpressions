using System;
using System.Collections.Concurrent;
using System.Configuration;
using System.Data.Common;
using System.Reflection;
using DbExpressions.Configuration;
using System.Linq;

namespace DbExpressions
{        
    /// <summary>
    /// Factory class that creates <see cref="DbQueryTranslator"/> instances.
    /// </summary>
    public static class DbQueryTranslatorFactory
    {
        private static readonly ConcurrentDictionary<string, Type> QueryTranslatorTypes
            = new ConcurrentDictionary<string, Type>();

        private static string _defaultProviderName;

        static DbQueryTranslatorFactory()
        {
            RegisterBuiltinTranslators();            
            _defaultProviderName = "System.Data.SqlClient";
            RegisterConfiguredTranslators();
        }

        private static void RegisterConfiguredTranslators()
        {
            DbExpressionSettings dbExpressionSettings;
            try
            {
                dbExpressionSettings =
                (DbExpressionSettings)ConfigurationManager.GetSection("dbExpressions");            
            }
            catch (Exception ex)
            {
                
                throw;
            }
            
            if (dbExpressionSettings == null)
                return;
            _defaultProviderName = dbExpressionSettings.DefaultProvider;
            foreach (var translatorElement in dbExpressionSettings.QueryTranslators)
            {
                var queryTranslatorElement = (QueryTranslatorElement) translatorElement;
                RegisterQueryTranslator(queryTranslatorElement.ProviderName,queryTranslatorElement.Type);
            }
        }

        private static void RegisterBuiltinTranslators()
        {
            RegisterQueryTranslator("System.Data.SqlClient",typeof(SqlQueryTranslator));
            RegisterQueryTranslator("MySql.Data.MySqlClient", typeof(MySqlQueryTranslator));
            RegisterQueryTranslator("System.Data.SQLite", typeof(SQLiteQueryTranslator));
            RegisterQueryTranslator("Oracle.DataAccess.Client", typeof(OracleQueryTranslator));
        }

        /// <summary>
        /// Gets a new <see cref="DbQueryTranslator"/> instance.
        /// </summary>
        /// <param name="invariantProviderName">The invariant provider name.</param>
        /// <returns><see cref="DbQueryTranslator"/></returns>
        public static DbQueryTranslator GetQueryTranslator(string invariantProviderName)
        {
            Type translatorType;
            QueryTranslatorTypes.TryGetValue(invariantProviderName, out translatorType);
            if (translatorType == null)
                throw new ArgumentOutOfRangeException("invariantProviderName",
                    string.Format("No query translator found for the target provider : {0}",invariantProviderName));
            return CreateInstance(invariantProviderName, translatorType);

        }

        /// <summary>
        /// Gets a new <see cref="DbQueryTranslator"/> instance according to the configured default provider name.
        /// </summary>
        /// <remarks>
        /// The default value is "System.Data.SqlClient", but this can be overridden in app/web.config.
        /// The default provider is also used to translate an expression in the <see cref="DbExpression.ToString"/> method.
        /// </remarks>
        /// <seealso cref="DbExpressionSettings"/>
        /// <returns></returns>
        public static DbQueryTranslator GetQueryTranslator()
        {
            return GetQueryTranslator(_defaultProviderName);
        }

        /// <summary>
        /// Registers a new <see cref="DbQueryTranslator"/> type for the target provider.
        /// </summary>
        /// <param name="providerInvariantName">The invarient name of the provider.</param>
        /// <param name="queryTranslatorType">The concrete implementation of <see cref="DbQueryTranslator"/> that targets this provider.</param>
        public static void RegisterQueryTranslator(string providerInvariantName, Type queryTranslatorType)
        {
            QueryTranslatorTypes.AddOrUpdate(providerInvariantName,
              queryTranslatorType, (key, oldValue) => queryTranslatorType);
        }

        /// <summary>
        /// Specifies the name of the default provider that will be used if otherwise not specified.
        /// This will also be used in the ToString() override to provide a textual representation of the query during debugging.
        /// </summary>
        /// <param name="providerInvariantName"></param>
        public static void SetDefaultProvider(string providerInvariantName)
        {
            _defaultProviderName = providerInvariantName;
        }



        private static DbQueryTranslator CreateInstance(string providerInvariantName, Type type)
        {
            var providerFactory = CreateProviderFactory(providerInvariantName);
            return (DbQueryTranslator)Activator.CreateInstance(type, new object[] {providerFactory});
        }

        private static DbProviderFactory CreateProviderFactory(string providerInvariantName)
        {            
            return DbProviderFactories.GetFactory(providerInvariantName);
        }

        
    }
}
