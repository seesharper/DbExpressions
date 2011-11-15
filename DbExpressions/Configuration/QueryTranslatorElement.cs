using System;
using System.ComponentModel;
using System.Configuration;

namespace DbExpressions.Configuration
{    
    /// <summary>
    /// Represents a configuration element in a configuration file.
    /// </summary>
    public class QueryTranslatorElement : ConfigurationElement
    {
        /// <summary>
        /// Gets or sets the provider invariant name.
        /// </summary>
        [ConfigurationProperty("providerName")]
        public string ProviderName
        {
            get { return (string)this["providerName"]; }
            set { this["providerName"] = value; }
        }

        /// <summary>
        /// Gets or sets the query translator type
        /// </summary>
        [TypeConverter(typeof(TypeNameConverter))]
        [ConfigurationProperty("type")]
        public Type Type
        {
            get { return (Type)this["type"]; }
            set { this["type"] = value; }
        }            
    }
}
