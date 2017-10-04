using GroupDocs.Metadata.Examples.Utilities.CSharp;
using GroupDocs.Metadata.Formats.Archive;
using System;
using System.Collections.Generic;
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
            /// Gets info of Zip file 
            /// </summary> 
            /// 
            public static void GetZipMatadata()
            {

                try
                {
                    //ExStart:GetZipMatadata
                    // initialize DocFormat
                    ZipFormat movFormat = new ZipFormat(Common.MapSourceFilePath(filePath));
                    // get info
                    ZipMetadata info = movFormat.ZipInfo;

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
                    //ExEnd:GetZipMatadata
                }
                catch (Exception exp)
                {

                    Console.WriteLine(exp.Message);
                }

            }

        }
      

    }
}
