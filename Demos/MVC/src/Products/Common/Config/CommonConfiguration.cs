using GroupDocs.Metadata.MVC.Products.Common.Util.Parser;
using Newtonsoft.Json;
using System;
using System.Collections.Specialized;
using System.Configuration;

namespace GroupDocs.Metadata.MVC.Products.Common.Config
{
    /// <summary>
    /// CommonConfiguration
    /// </summary>
    public class CommonConfiguration : ConfigurationSection
    {
        [JsonProperty]
        public bool download { get; set; }

        [JsonProperty]
        public bool upload { get; set; }

        [JsonProperty]
        public bool browse { get; set; }

        [JsonProperty]
        public bool rewrite { get; set; }

        private readonly NameValueCollection commonConfiguration = (NameValueCollection)ConfigurationManager.GetSection("commonConfiguration");

        /// <summary>
        /// Constructor
        /// </summary>
        public CommonConfiguration()
        {
            YamlParser parser = new YamlParser();
            dynamic configuration = parser.GetConfiguration("common");
            ConfigurationValuesGetter valuesGetter = new ConfigurationValuesGetter(configuration);
            download = valuesGetter.GetBooleanPropertyValue("download", Convert.ToBoolean(commonConfiguration["isDownload"]));
            upload = valuesGetter.GetBooleanPropertyValue("upload", Convert.ToBoolean(commonConfiguration["isUpload"]));
            browse = valuesGetter.GetBooleanPropertyValue("browse", Convert.ToBoolean(commonConfiguration["isBrowse"]));
            rewrite = valuesGetter.GetBooleanPropertyValue("rewrite", Convert.ToBoolean(commonConfiguration["isRewrite"]));
        }
    }
}