using GroupDocs.Metadata.MVC.Products.Common.Util.Parser;
using GroupDocs.Metadata.MVC.Products.Common.Util.Directory;
using System;
using System.Diagnostics;
using System.IO;

namespace GroupDocs.Metadata.MVC.Products.Common.Config
{
    /// <summary>
    /// Application configuration
    /// </summary>
    public class ApplicationConfiguration
    {
        public string LicensePath { get; set; } = "Licenses";

        /// <summary>
        /// Get license path from the application configuration section of the web.config
        /// </summary>
        public ApplicationConfiguration()
        {
            YamlParser parser = new YamlParser();
            dynamic configuration = parser.GetConfiguration("application");
            ConfigurationValuesGetter valuesGetter = new ConfigurationValuesGetter(configuration);
            string license = valuesGetter.GetStringPropertyValue("licensePath");
            if (String.IsNullOrEmpty(license))
            {
                string[] files = System.IO.Directory.GetFiles(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, LicensePath), "*.lic");
                LicensePath = Path.Combine(LicensePath, files[0]);
            }
            else
            {
                if (!DirectoryUtils.IsFullPath(license))
                {
                    license = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, license);
                    if (!Directory.Exists(Path.GetDirectoryName(license)))
                    {
                        Directory.CreateDirectory(Path.GetDirectoryName(license));
                    }
                }
                LicensePath = license;
                if (!File.Exists(LicensePath))
                {                    
                    Debug.WriteLine("License file path is incorrect, launched in trial mode");
                    LicensePath = "";
                }
            }
        }
    }
}