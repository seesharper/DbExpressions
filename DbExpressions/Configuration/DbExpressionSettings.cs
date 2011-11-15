using System.Configuration;

namespace DbExpressions.Configuration
{
    /// <summary>
    /// Configures the dbExpression section. 
    /// </summary>
    public class DbExpressionSettings : ConfigurationSection
    {
        /// <summary>
        /// Gets or sets the name of the default provider.
        /// </summary>
        [ConfigurationProperty("defaultProvider",DefaultValue = "System.Data.SqlClient")]
        public string DefaultProvider
        {
            get { return (string)this["defaultProvider"]; }

            set { this["defaultProvider"] = value; }
        }
        
        /// <summary>
        /// Gets a list of <see cref="QueryTranslatorElement"/> instances.
        /// </summary>
        [ConfigurationProperty("queryTranslators", IsDefaultCollection = true)]
        public QueryTranslatorElementCollection QueryTranslators
        {
            get { return this["queryTranslators"] as QueryTranslatorElementCollection; }
        }
    }
}
