using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using GroupDocs.Metadata.Formats;
using GroupDocs.Metadata.Tools;

namespace GroupDocs.Metadata.Examples.Utilities.CSharp
{
    //ExStart:FormatRecognizer
    public class FormatRecognizer
    {
        // absolute path to the GroupDocs.Metadata license file.
        private const string LicensePath = @"GroupDocs.Metadata.lic";

        static FormatRecognizer()
        {
            /* set product license 
             * uncomment following function if you have product license
             * */
            SetInternalLicense();
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
        /// Gets directory name and recognizes format of files in that directory
        /// </summary>
        /// <param name="directorPath">Directory path</param>
        public void GetFileFormats(string directorPath)
        {
            try
            {
                // path to the document
                directorPath = Common.MapSourceFilePath(directorPath);

                // get array of files inside directory
                string[] files = Directory.GetFiles(directorPath);

                foreach (string path in files)
                {
                    // recognize file by it's signature
                    FormatBase format = FormatFactory.RecognizeFormat(path);

                    if (format != null)
                    {
                        Console.WriteLine("File: {0}, type: {1}", Path.GetFileName(path), format.Type);
                    }
                }
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.Message);
            }
        }
    }
    //ExEnd:FormatRecognizer
}
