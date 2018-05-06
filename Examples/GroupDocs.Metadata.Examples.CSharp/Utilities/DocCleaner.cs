using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GroupDocs.Metadata.Formats;
using GroupDocs.Metadata.Formats.Document;
using GroupDocs.Metadata.Tools;
using System.IO;
using GroupDocs.Metadata; 

namespace GroupDocs.Metadata.Examples.Utilities.CSharp
{
    //ExStart:DocCleaner
    public class DocCleaner
    {
        // Absolute path to the GroupDocs.Metadata license file
        private const string LicensePath = @"GroupDocs.Metadata.lic";

        // Absolute path to the documents directory
        public string DocumentsPath { get; set; }

        static DocCleaner()
        {
            /* set product license 
             * uncomment following function if you have product license
             * */
            //SetInternalLicense();
        }

        public DocCleaner(string documentsPath)
        {
            // check if directory exists
            if (!Directory.Exists(Common.MapSourceFilePath( documentsPath)))
            {
                throw new DirectoryNotFoundException("Directory not found: " + documentsPath);
            }

            this.DocumentsPath = documentsPath;
        }
        /// <summary>
        /// Applies the product license
        /// </summary>
        private static void SetInternalLicense()
        { 
            License license = new License();
            license.SetLicense(LicensePath);
        }

        /// <summary>
        /// Takes author name and removes metadata in files created by specified author
        /// </summary>
        /// <param name="authorName">Author name</param>
        public void RemoveMetadataByAuthor(string authorName)
        {
            // Map directory in source folder
            string sourceDirectoryPath = Common.MapSourceFilePath(this.DocumentsPath);
            
            // get files presented in target directory
            string[] files = Directory.GetFiles(sourceDirectoryPath);

            foreach (string path in files)
            {
                // recognize format
                using (FormatBase format = FormatFactory.RecognizeFormat(path))
                {
                    // initialize DocFormat
                    DocFormat docFormat = format as DocFormat;
                    if (docFormat != null)
                    {
                        // get document properties
                        DocMetadata properties = docFormat.DocumentProperties;

                        // check if author is the same
                        if (string.Equals(properties.Author, authorName, StringComparison.OrdinalIgnoreCase))
                        {
                            // remove comments
                            docFormat.ClearComments();

                            List<string> customKeys = new List<string>();

                            // find all custom keys
                            foreach (KeyValuePair<string, PropertyValue> keyValuePair in properties)
                            {
                                if (!properties.IsBuiltIn(keyValuePair.Key))
                                {
                                    customKeys.Add(keyValuePair.Key);
                                }
                            }

                            // and remove all of them
                            foreach (string key in customKeys)
                            {
                                properties.Remove(key);
                            }
                            //====== yet to change things =========================
                            // and commit changes
                            string fileName = Path.GetFileName(path);
                            string outputFilePath = Common.MapDestinationFilePath(this.DocumentsPath + "/" + fileName);
                            docFormat.Save(outputFilePath);
                            //=====================================================
                        }
                    } 
                }
            }

            Console.WriteLine("Press any key to exit.");
        }
    }
    //ExEnd:DocCleaner
}
