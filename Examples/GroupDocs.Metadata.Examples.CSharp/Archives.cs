using GroupDocs.Metadata.Examples.Utilities.CSharp;
using GroupDocs.Metadata.Formats;
using GroupDocs.Metadata.Formats.Archive;
using GroupDocs.Metadata.Tools;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace GroupDocs.Metadata.Examples.CSharp
{
    public static class Archives
    {
        public static class Zip
        {
            // initialize file path
            //ExStart:SourceDocFilePath
            private const string filePath = "Archives/Zip/sample.zip";
            //ExEnd:SourceDocFilePath

            /// <summary>
            /// Detects Zip format via Format Factory
            /// </summary>
            public static void DetectZipFormat()
            {
                //ExStart:DetectZipFormat
                // recognize format
                using (FormatBase format = FormatFactory.RecognizeFormat(Common.MapSourceFilePath(filePath)))
                {
                    
                    // check format type
                    if (format.Type == DocumentType.Zip)
                    {
                        Console.WriteLine("File: {0} has correct format", Path.GetFileName(Common.MapSourceFilePath(filePath)));
                    } 
                }
                //ExEnd:DetectZipFormat
            }

            /// <summary>
            /// Gets info of Zip file 
            /// </summary> 
            /// 
            public static void GetZipMatadata()
            {

                try
                {
                    //ExStart:GetZipMatadata
                    // initialize  
                    using (ZipFormat zipFormat = new ZipFormat(Common.MapSourceFilePath(filePath)))
                    {
                        // get info
                        ZipMetadata info = zipFormat.ZipInfo;

                        // get total entries
                        Console.WriteLine("Total Entries : {0}, ", info.TotalEntries);

                        //get comments 
                        Console.WriteLine("Comments : {0}, ", info.Comment);
                        foreach (var fileInfo in info.Files)
                        {
                            // get file name 
                            Console.WriteLine("File Name : {0}, ", fileInfo.Name);

                            // get compressed size
                            Console.WriteLine("CompressedSize : {0}, ", fileInfo.CompressedSize);

                            // get uncompressed size
                            Console.WriteLine("UncompressedSize : {0}, ", fileInfo.UncompressedSize);

                            // get compression method
                            Console.WriteLine("CompressionMethod : {0}, ", fileInfo.CompressionMethod);

                        } 
                    }
                    //ExEnd:GetZipMatadata
                }
                catch (Exception exp)
                {

                    Console.WriteLine(exp.Message);
                }

            }

            /// <summary>
            /// Removes comment in Zip file 
            /// </summary> 
            /// 
            public static void RemoveComment()
            {

                try
                {
                    //ExStart:RemoveCommentZIPFile_17.12
                    // initialize 
                    using (ZipFormat zipFormat = new ZipFormat(Common.MapSourceFilePath(filePath)))
                    {
                        // remove user comment
                        zipFormat.RemoveFileComment();

                        // and commit changes
                        zipFormat.Save(); 
                    }
                    //ExEnd:RemoveCommentZIPFile_17.12
                }
                catch (Exception exp)
                {
                    Console.WriteLine(exp.Message);
                }

            }
            /// <summary>
            /// Get Zip Metadata using stream
            /// Feature is supported in version 18.5 or greater of the API
            /// </summary>
            public static void GetZipMatadataUsingStream()
            {
                try
                {
                    using (Stream stream = File.Open(Common.MapSourceFilePath(filePath), FileMode.Open, FileAccess.ReadWrite))
                    {
                        using (ZipFormat format = new ZipFormat(stream))
                        {
                            // get info
                            ZipMetadata info = format.ZipInfo;

                            // get total entries
                            Console.WriteLine("Total Entries : {0}, ", info.TotalEntries);

                            //get comments 
                            Console.WriteLine("Comments : {0}, ", info.Comment);
                            foreach (var fileInfo in info.Files)
                            {
                                // get file name 
                                Console.WriteLine("File Name : {0}, ", fileInfo.Name);

                                // get compressed size
                                Console.WriteLine("CompressedSize : {0}, ", fileInfo.CompressedSize);

                                // get uncompressed size
                                Console.WriteLine("UncompressedSize : {0}, ", fileInfo.UncompressedSize);

                                // get compression method
                                Console.WriteLine("CompressionMethod : {0}, ", fileInfo.CompressionMethod);

                            }
                        }
                        // The stream is still open here
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            /// <summary>
            /// Update Zip Comment 
            /// Feature is supported in version 18.5 or greater of the API
            /// </summary>
            public static void UpdateComment()
            {
                try
                {
                    using (ZipFormat format = new ZipFormat(Common.MapSourceFilePath(filePath)))
                    {
                        format.ZipInfo.Comment = "test comment";
                        
                        //Or you can update it using ZipFileComment Property
                        //format.ZipFileComment = "test comment";
                    
                        format.Save(Common.MapDestinationFilePath(filePath));
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }


    }
}
