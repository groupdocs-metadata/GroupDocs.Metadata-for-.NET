using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using GroupDocs.Metadata.Tools;
using GroupDocs.Metadata;

namespace GroupDocs.Metadata.Examples.CSharp
{
    public static class Common
    {
        //ExStart:CommonProperties
        private const string SourceFolderPath = "../../../Data/Source/";
        private const string DestinationFolderPath = "../../../Data/Destination/";
        private const string LicenseFilePath = "Groupdocs.Metadata.lic";
        //ExEnd:CommonProperties

        //ExStart:MapSourceFilePath
        /// <summary>
        /// Maps source file path
        /// </summary>
        /// <param name="FileName">Source File Name</param>
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

    }
}
