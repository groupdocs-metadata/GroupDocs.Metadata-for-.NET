using GroupDocs.Metadata.Examples.Utilities.CSharp;
using GroupDocs.Metadata.Formats;
using GroupDocs.Metadata.Tools;
using System;
using System.IO;

namespace GroupDocs.Metadata.Examples.CSharp.Utilities
{
    //ExStart:MIMETypeDetector
    public class MIMETypeDetector
    {

        /// <summary>
        ///Retrieves MIME type of the specific file or file stream.
        /// </summary>
        /// <param name="directory">Directory Path</param>
        public static void GetMimeType(string directory)
        {
            try
            {
                //ExStart: MIMETypeDetection
                // get all files inside directory
                string[] files = Directory.GetFiles(Common.MapSourceFilePath(directory));

                foreach (string path in files)
                {
                    // get MIME type string
                    string mimeType = MetadataUtility.GetMimeType(path);

                    Console.WriteLine("File: {0}, MIME type: {1}", Path.GetFileName(path), mimeType);
                }
                //ExEnd: MIMETypeDetection
            }
            catch (Exception exp)
            {
                Console.WriteLine("Exception occurred: " + exp.Message);
            }
        }

        /// <summary>
        /// Gets and returns MIME type in the file using MIMEType property in FormatBase class or it's children.
        /// </summary>
        /// <param name="path">File Path</param> 
        public static void GetMimeTypeUsingFormatBaseApproach(string filePath)
        {
            try
            {
                //ExStart: MIMETypeDetectionUsingFormatBase
                // recognize format
                using (FormatBase format = FormatFactory.RecognizeFormat(Common.MapSourceFilePath(filePath)))
                {
                    // and get MIME type
                    string mimeType = format.MIMEType;
                    Console.WriteLine("MIME type: {0}", mimeType); 
                }
                //ExEnd: MIMETypeDetectionUsingFormatBase
            }
            catch (Exception exp)
            {
                Console.WriteLine("Exception occurred: " + exp.Message);
            }
        }
    }
    //ExEnd:MIMETypeDetector
}
