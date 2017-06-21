using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GroupDocs.Metadata.Examples.Utilities.CSharp;
using GroupDocs.Metadata.Formats;
using GroupDocs.Metadata.Formats.Video;
using GroupDocs.Metadata.Tools;
using System.IO;
using GroupDocs.Metadata.Xmp;

namespace GroupDocs.Metadata.Examples.CSharp
{
    public static class VideoFormats
    {
        public static class Avi
        {
            // initialize file path and directory path
            //ExStart:SourceAviFilePath + SourcAviDirectoryPath
            private const string directoryPath = "Video/Avi";
            private const string filePath = "Video/Avi/sample.avi";
            
            //ExEnd:SourceAviFilePath + SourcAviDirectoryPath

            //ExStart:OutputDataFilePathAvi
            private const string OutputDataFilePathAvi = "Documents/Xls/metadata-avi.xls";

            /// <summary>
            /// Detects AVI video format via Format Factory
            /// </summary>
            public static void DetectAviFormat()
            {
                //ExStart:DetectAviFormat
                // recognize format
                FormatBase format = FormatFactory.RecognizeFormat(Common.MapSourceFilePath(filePath));

                // check format type
                if (format.Type == DocumentType.AVI)
                {
                    // cast it to AviFormat
                    AviFormat aviFormat = format as AviFormat;

                    // and get it MIME type
                    string mimeType = aviFormat.MIMEType;
                    Console.WriteLine(mimeType);
                }
                //ExEnd:DetectAviFormat
            }


            /// <summary>
            /// demonstrates how to read AVIMAINHEADER of AVI format
            /// </summary>
            public static void ReadAviMainHeader()
            {
                //ExStart:ReadAviMainHeader
                // initialize AviFormat
                AviFormat aviFormat = new AviFormat(Common.MapSourceFilePath(filePath));

                // get AVI header
                AviHeader header = aviFormat.Header;

                // display video width
                Console.WriteLine("Video width: {0}", header.Width);

                // display video height
                Console.WriteLine("Video height: {0}", header.Height);

                // display total frames
                Console.WriteLine("Total frames: {0}", header.TotalFrames);

                // display number of streams in file
                Console.WriteLine("Number of streams: {0}", header.Streams);

                // display suggested buffer size for reading the file
                Console.WriteLine("Suggested buffer size: {0}", header.SuggestedBufferSize);
                //ExEnd:ReadAviMainHeader
            }

            /// <summary>
            /// Exports AVI metadata to Csv,Xls file
            /// </summary>
            public static void ExportMetadata()
            {
                try
                {
                    //ExStart:ExportMetadataAvi
                    // export to excel
                    byte[] content = ExportFacade.ExportToExcel(Common.MapSourceFilePath(filePath));

                    // write data to the file
                    File.WriteAllBytes(Common.MapDestinationFilePath(OutputDataFilePathAvi), content);
                    //ExEnd:ExportMetadataAvi
                    Console.WriteLine("Metadata has been export successfully");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }

            /// <summary>
            /// Shows how to read, update and remove XMP metadata in AVI format
            /// Feature is supported in version 17.06 or greater
            /// </summary>
            public static void DealWithXmpMetaData() {
                //ExStart:DealWithXmpMetaData
                // initialize AviFormat
                AviFormat aviFormat = new AviFormat(Common.MapSourceFilePath(filePath));

                // get XMP
                var xmpMetadata = aviFormat.GetXmpData();

                // create XMP if absent
                if (xmpMetadata == null)
                {
                    xmpMetadata = new XmpPacketWrapper();
                }

                // setup properties
                xmpMetadata.Schemes.DublinCore.Format = "avi";
                xmpMetadata.Schemes.XmpBasic.CreateDate = DateTime.UtcNow;
                xmpMetadata.Schemes.XmpBasic.CreatorTool = "GroupDocs.Metadata";

                // update xmp
                aviFormat.SetXmpData(xmpMetadata);

                // and commit changes
                aviFormat.Save();
                //ExEnd:DealWithXmpMetaData
            }
        }
    }
}



