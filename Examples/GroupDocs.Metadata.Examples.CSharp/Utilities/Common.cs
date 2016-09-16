using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using GroupDocs.Metadata.Tools;
using GroupDocs.Metadata;
using GroupDocs.Metadata.Formats;

namespace GroupDocs.Metadata.Examples.Utilities.CSharp
{
    public static class Common
    {
        //ExStart:CommonProperties
        private const string SourceFolderPath = "../../../Data/Source/";
        private const string DestinationFolderPath = "../../../Data/Destination/";
        private const string LicenseFilePath = @"D:\ASPOSE\LICENSE\GroupDocs.Total.lic";
        //ExEnd:CommonProperties

        //ExStart:MapSourceFilePath
        /// <summary>
        /// Maps source file path
        /// </summary>
        /// <param name="SourceFileName">Source File Name</param>
        /// <returns>Returns complete path of source file</returns>
        public static string MapSourceFilePath(string SourceFileName)
        {
            try
            {
                return SourceFolderPath + SourceFileName;
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.Message);
                return exp.Message;
            }
        }
        //ExEnd:MapSourceFilePath
        //ExStart:MapDestinationFilePath
        /// <summary>
        /// Maps destination file path
        /// </summary>
        /// <param name="DestinationFileName">Destination File Name</param>
        /// <returns>Returns complete path of destination file</returns>
        public static string MapDestinationFilePath(string DestinationFileName)
        {
            try
            {
                return DestinationFolderPath + DestinationFileName;
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.Message);
                return exp.Message;
            }
        }
        //ExEnd:MapDestinationFilePath

        //ExStart:ApplyLicense
        /// <summary>
        /// Applies product license
        /// </summary>
        public static void ApplyLicense()
        {
            try
            {
                // initialize License
                License lic = new License();

                // apply license
                lic.SetLicense(LicenseFilePath);
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.Message);
            }
        }
        //ExEnd:ApplyLicense

        //ExStart:FormatRecognizer
        /// <summary>
        /// Gets directory name and recognizes format of files in that directory
        /// </summary>
        /// <param name="directorPath">Directory path</param>
        public static void GetFileFormats(string directorPath)
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
        //ExEnd:FormatRecognizer
     }
}
