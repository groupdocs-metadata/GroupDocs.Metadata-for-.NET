using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using GroupDocs.Metadata.Utils;
using GroupDocs.Metadata;

namespace GroupDocs.Metadata.Examples.CSharp
{
    public static class Common
    {
        private const string SourceFolderPath = "../../../Data/Source/";
        private const string DestinationFolderPath = "../../../Data/Destination/";
        private const string LicenseFilePath = "Groupdocs.Metadata.lic";

        /// <summary>
        /// Maps source file path
        /// </summary>
        /// <param name="FileName">Source File Name</param>
        /// <returns>Returns complete source file path</returns>
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

        /// <summary>
        /// Maps destination file path
        /// </summary>
        /// <param name="DestinationFileName">Destination File Name</param>
        /// <returns>Returns complete destination file path</returns>
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
        public static string GetFilePathFromUser(string statement)
        {
            try
            {
                Console.WriteLine(statement);
                string filePath = Console.ReadLine();
                return filePath;

            }
            catch (Exception exp)
            {
                Console.Write(exp.Message);
                return exp.Message;
            }
        }
        /// <summary>
        /// Retrieves format of the file
        /// </summary>
        /// <param name="FilePath">File Path</param>
        /// <returns>Returns file format</returns>
        public static string GetFileFormat(string FilePath)
        {
            try
            {
                // path to the dir with files
                string path = MapSourceFilePath(FilePath);
                string fileFormat = "Invalid Format";

                // recognize file by it's signature
                GroupDocs.Metadata.Formats.FormatBase format = FormatFactory.RecognizeFormat(path);

                if (format != null)
                {
                    fileFormat = format.Type.ToString();
                }

                return fileFormat;

            }
            catch (Exception exp)
            {
                return exp.Message;
            }

        }
        /// <summary>
        /// Applies product license
        /// </summary>
        public static void ApplyLicense()
        {
            try
            {
                // initialize License
                License lic = new License();

                lic.SetLicense(LicenseFilePath);
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.Message);
            }
        }

    }
}
