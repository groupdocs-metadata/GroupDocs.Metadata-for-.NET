using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using GroupDocs.Metadata.Tools;
using GroupDocs.Metadata;
using GroupDocs.Metadata.Formats;
using GroupDocs.Metadata.Exceptions;
using GroupDocs.Metadata.Formats.Document;

namespace GroupDocs.Metadata.Examples.Utilities.CSharp
{
    public static class Common
    {
        //ExStart:CommonProperties
        private const string SourceFolderPath = "../../../Data/Source/";
        private const string DestinationFolderPath = "../../../Data/Destination/";
        private const string LicenseFilePath = @"D:\GroupDocs.Total.NET.lic";
        private const string publicKey = "Public key for your account";
        private const string privateKey = "private key for your account";
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


        //ExStart:ReadMetadataUsingKey
        /// <summary>
        /// Reads metadata property by defined key for any supported format
        /// </summary>
        /// <param name="directorPath">Directory path</param>
        public static void ReadMetadataUsingKey(string directoryPath)
        {
            try
            {
                // path to the files directory
                directoryPath = MapSourceFilePath(directoryPath);

                // get array of files inside directory
                string[] files = Directory.GetFiles(directoryPath);
                foreach (var file in files)
                {
                    // recognize first file
                    FormatBase format = FormatFactory.RecognizeFormat(file);

                    // try get EXIF artist
                    var exifArtist = format[MetadataKey.EXIF.Artist];
                    Console.WriteLine(exifArtist);

                    // try get dc:creator XMP value
                    var creator = format[MetadataKey.XMP.DublinCore.Creator];
                    Console.WriteLine(creator);

                    // try get xmp:creatorTool
                    var creatorTool = format[MetadataKey.XMP.BaseSchema.CreatorTool];
                    Console.WriteLine(creatorTool);

                    // try get IPTC Application Record keywords
                    var iptcKeywords = format[MetadataKey.IPTC.ApplicationRecord.Keywords];
                    Console.WriteLine(iptcKeywords);
                }

            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.Message);
            }
        }
        //ExEnd:ReadMetadataUsingKey

        //ExStart:EnumerateMetadata
        /// <summary>
        /// Reads metadata property by defined key for any supported format
        /// </summary>
        /// <param name="directorPath">Directory path</param>
        public static void EnumerateMetadata(string directoryPath)
        {
            try
            {
                // path to the files directory
                directoryPath = MapSourceFilePath(directoryPath);

                // get all files inside the directory
                string[] files = Directory.GetFiles(directoryPath);

                foreach (string file in files)
                {
                    FormatBase format;
                    try
                    {
                        // try to recognize file
                        format = FormatFactory.RecognizeFormat(file);
                    }
                    catch (InvalidFormatException)
                    {
                        // skip unsupported formats
                        continue;
                    }
                    catch (DocumentProtectedException)
                    {
                        // skip password protected documents
                        continue;
                    }

                    if (format == null)
                    {
                        // skip unsupported formats
                        continue;
                    }

                    // get all metadata presented in file
                    Metadata[] metadataArray = format.GetMetadata();

                    // go through metadata array
                    foreach (Metadata metadata in metadataArray)
                    {
                        // and display all metadata items
                        Console.WriteLine("Metadata type: {0}", metadata.MetadataType);

                        // use foreach statement for Metadata class to evaluate all metadata properties
                        foreach (MetadataProperty property in metadata)
                        {
                            Console.WriteLine(property);
                        }
                    }
                }

            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.Message);
            }
        }
        //ExEnd:EnumerateMetadata

        /// <summary>
        /// shows how to use library in licensed mode using Dynabic.Metered account
        /// </summary>
        public static void UseDynabicMeteredAccount()
        {
            //ExStart:UseDynabicMeteredAccount
            // initialize Metered API
            GroupDocs.Metadata.Metered metered = new Metered();

            // set-up credentials
            metered.SetMeteredKey(publicKey, privateKey);

            // do some work:

            // Open Word document
            using (DocFormat docFormat = new DocFormat(MapSourceFilePath("Documents/Doc/Metadata_testfile.docx")))
            {

                // remove hidden metadata
                docFormat.RemoveHiddenData(new DocInspectionOptions(DocInspectorOptionsEnum.All));

                // and get consumption quantity
                decimal consumptionQuantity = GroupDocs.Metadata.Metered.GetConsumptionQuantity(); 
            }
            //ExEnd:UseDynabicMeteredAccount
        }
    }
}
