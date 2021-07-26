﻿using GroupDocs.Metadata.WebForms.Products.Common.Util.Parser;
using System;
using System.Collections.Specialized;
using System.Configuration;

namespace GroupDocs.Metadata.WebForms.Products.Common.Config
{
    /// <summary>
    /// Server configuration
    /// </summary>
    public class ServerConfiguration : ConfigurationSection
    {
        public int HttpPort { get; set; } = 8080;
        public string HostAddress { get; set; } = "localhost";
        private readonly NameValueCollection serverConfiguration = (NameValueCollection)ConfigurationManager.GetSection("serverConfiguration");

        /// <summary>
        /// Get server configuration section of the web.config
        /// </summary>
        public ServerConfiguration() {
            YamlParser parser = new YamlParser();
            dynamic configuration = parser.GetConfiguration("server");
            ConfigurationValuesGetter valuesGetter = new ConfigurationValuesGetter(configuration);
            int defaultPort = Convert.ToInt32(serverConfiguration["httpPort"]);
            HttpPort = valuesGetter.GetIntegerPropertyValue("connector", defaultPort, "port");
            HostAddress = valuesGetter.GetStringPropertyValue("hostAddress", HostAddress);
        }
    }
}