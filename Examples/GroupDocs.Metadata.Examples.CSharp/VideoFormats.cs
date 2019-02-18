using System;
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
            //Source file path
            private const string filePath = "Video/Avi/sample.avi";
            //Output data file path
            private const string OutputDataFilePathAvi = "Documents/Xls/metadata-avi.xls";
            /// <summary>
            /// Detects AVI video format via Format Factory
            /// </summary>
            public static void DetectAviFormat()
            {
                //ExStart:DetectAviFormat
                // recognize format
                using (FormatBase format = FormatFactory.RecognizeFormat(Common.MapSourceFilePath(filePath)))
                {
                    // check format type
                    if (format.Type == DocumentType.AVI)
                    {
                        // cast it to AviFormat
                        AviFormat aviFormat = format as AviFormat;

                        // and get it MIME type
                        string mimeType = aviFormat.MIMEType;
                        Console.WriteLine(mimeType);
                    }
                }
                //ExEnd:DetectAviFormat
            }


            /// <summary>
            /// Demonstrates how to read AVIMAINHEADER of AVI format
            /// </summary>
            public static void ReadAviMainHeader()
            {
                //ExStart:ReadAviMainHeader
                // initialize AviFormat
                using (AviFormat aviFormat = new AviFormat(Common.MapSourceFilePath(filePath)))
                {
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
                }
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
            public static void DealWithXmpMetaData()
            {
                //ExStart:DealWithXmpMetaData
                // initialize AviFormat
                using (AviFormat aviFormat = new AviFormat(Common.MapSourceFilePath(filePath)))
                {

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
                }
                //ExEnd:DealWithXmpMetaData
            }

            public static void CleanMetadata()
            {
                //ExStart:CleanMetadata
                // initialize AviFormat
                using (AviFormat aviFormat = new AviFormat(Common.MapSourceFilePath(filePath)))
                {

                    // removes all metadata
                    aviFormat.CleanMetadata();

                    // commit changes
                    aviFormat.Save();
                }
                //ExEnd:DealWithXmpMetaData
            }
            /// <summary>
            /// Clean AVI Format Metadata
            /// Feature is supported in version 18.6 or greater of the API
            /// </summary>
            public static void ReadAviMainHeaderUsingStream()
            {
                using (Stream stream = File.Open(Common.MapDestinationFilePath(filePath), FileMode.OpenOrCreate, FileAccess.ReadWrite))
                {
                    using (AviFormat format = new AviFormat(Common.MapSourceFilePath(filePath)))
                    {
                        // get AVI header
                        AviHeader header = format.Header;

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
                    }
                    // The stream is still open here
                }
            }
        }
        public static class Flv
        {
            // Source file path 
            private const string filePath = "Video/Flv/sample.flv";
            /// <summary>
            /// Check FLV file format 
            /// This method is supported by version 18.11 or higher 
            /// </summary>
            public static void DetectFlvFormat()
            {
                using (FileFormatChecker checker = new FileFormatChecker(Common.MapSourceFilePath(filePath)))
                {
                    if (checker.GetDocumentType() == DocumentType.Flv)
                    {
                        // The file is an FLV video
                        Console.WriteLine("This is a valid FLV file...");
                    }
                }
            }
            /// <summary>
            /// Gets XMP Metadata of FLV file format 
            /// This method is supported by version 18.11 or higher 
            /// </summary>
            public static void GetXMPMetadata()
            {

                using (FlvFormat format = new FlvFormat(Common.MapSourceFilePath(filePath)))
                {
                    Console.WriteLine(format.XmpValues.Schemes.XmpBasic.CreateDate);
                    Console.WriteLine(format.XmpValues.Schemes.XmpBasic.Label);
                    Console.WriteLine(format.XmpValues.Schemes.DublinCore.Source);
                    Console.WriteLine(format.XmpValues.Schemes.DublinCore.Format);

                }
            }

            public static void UpdateXMPMetadata()
            {

                using (FlvFormat format = new FlvFormat(Common.MapSourceFilePath(filePath)))
                {

                    format.XmpValues.Schemes.XmpBasic.CreateDate = DateTime.Now;
                    format.XmpValues.Schemes.XmpBasic.Label = "Test";
                    format.XmpValues.Schemes.DublinCore.Source = "http://groupdocs.com";
                    format.XmpValues.Schemes.DublinCore.Format = "FLV Video";

                    format.Save(Common.MapDestinationFilePath(filePath));

                    Console.WriteLine("File saved to destination folder...");
                }
            }
            /// <summary>
            /// Removes XMP Metadata of FLV file format 
            /// This method is supported by version 18.11 or higher 
            /// </summary>
            public static void RemoveXMPMetadata()
            {
                using (FlvFormat format = new FlvFormat(Common.MapSourceFilePath(filePath)))
                {
                    format.RemoveXmpData();
                    format.Save(Common.MapDestinationFilePath(filePath));
                }
            }
            /// <summary>
            /// Reads FLV header metadata 
            /// This method is supported by version 18.11 or greater 
            /// </summary>
            public static void ReadFlvHeaderMetadata()
            {
                using (FlvFormat format = new FlvFormat(Common.MapSourceFilePath(filePath)))
                {
                    Console.WriteLine(format.Header.Version);
                    Console.WriteLine(format.Header.HasVideoTags);
                    Console.WriteLine(format.Header.HasAudioTags);
                    Console.WriteLine(Convert.ToString(format.Header.TypeFlags, 2).PadLeft(8, '0'));
                }
            }
        }
        public static class Mov
        {
            //Source file path 
            private const string filePath = "Video/Mov/sample.mov";
            /// <summary>
            /// Detects Mov video format via Format Factory
            /// </summary>
            public static void DetectMovFormat()
            {
                //ExStart:DetectMovFormat
                // recognize format
                using (FormatBase format = FormatFactory.RecognizeFormat(Common.MapSourceFilePath(filePath)))
                {
                    // check format type
                    if (format.Type == DocumentType.Mov)
                    {
                        // cast it to MovFormat
                        MovFormat movFormat = format as MovFormat;

                        // and get it MIME type;
                        string mimeType = movFormat.MIMEType;
                        Console.WriteLine(mimeType);
                    }
                }
                //ExEnd:DetectMovFormat
            }
            /// <summary>
            /// This example demonstrates how to get CANON maker-notes
            /// </summary>
            public static void GetMovFormatMetadata()
            {
                //ExStart:GetMovFormatMetadata
                // initialize mov format
                using (MovFormat movFormat = new MovFormat(Common.MapSourceFilePath(filePath)))
                {
                    // display mime type
                    Console.WriteLine("MIME type: {0}", movFormat.MIMEType);

                    foreach (var info in movFormat.QuickTimeInfo.Atoms)
                    {
                        // get name
                        Console.WriteLine("Name: {0}", info.Name);

                        // get offset
                        Console.WriteLine("Offset: {0}", info.Offset);

                        // get data
                        Console.WriteLine("Data: {0}", info.Data);

                        // get size
                        Console.WriteLine("Size: {0}", info.Size);

                        // get type
                        Console.WriteLine("Type: {0}", info.Type);

                    }
                }
                //ExEnd:GetMovFormatMetadata
            }
        }
        public static class Mkv
        {
            //Source file path
            private const string filePath = "Video/Mkv/sample.mkv";
            /// <summary>
            /// This method gets MKV file format metadata 
            /// This method is supported by version 19.1 or greater 
            /// </summary>
            public static void GetMetadata()
            {
                using (MatroskaFormat format = new MatroskaFormat(Common.MapSourceFilePath(filePath)))
                {
                    Console.WriteLine("DocType: {0}", format.EbmlHeader.DocType);
                    Console.WriteLine("DocTypeReadVersion: {0}", format.EbmlHeader.DocTypeReadVersion);
                    Console.WriteLine("DocTypeVersion: {0}", format.EbmlHeader.DocTypeVersion);
                    Console.WriteLine("ReadVersion: {0}", format.EbmlHeader.ReadVersion);
                    Console.WriteLine("Version: {0}", format.EbmlHeader.Version);
                }
            }
            /// <summary>
            /// This method gets Matroska Segment Info Metadata
            /// This method is supported by version 19.1 or greater 
            /// </summary>
            public static void MatroskaSegmentInfoMetadata()
            {
                using (MatroskaFormat format = new MatroskaFormat(Common.MapSourceFilePath(filePath)))
                {
                    foreach (MatroskaSegmentInfoMetadata segment in format.Segments)
                    {
                        Console.WriteLine("DateUtc: {0}", segment.DateUtc);
                        Console.WriteLine("Duration: {0}", segment.Duration);
                        Console.WriteLine("MuxingApp: {0}", segment.MuxingApp);
                        Console.WriteLine("SegmentFilename: {0}", segment.SegmentFilename);
                        Console.WriteLine("SegmentUid: {0}", segment.SegmentUid);
                        Console.WriteLine("TimecodeScale: {0}", segment.TimecodeScale);
                        Console.WriteLine("Title: {0}", segment.Title);
                        Console.WriteLine("WritingApp: {0}", segment.WritingApp);
                    }
                }

            }
            /// <summary>
            /// This method gets Matroska Tag Metadata
            /// This method is supported by version 19.1 or greater 
            /// </summary>
            public static void MatroskaTagMetadata()
            {
                using (MatroskaFormat format = new MatroskaFormat(Common.MapSourceFilePath(filePath)))
                {
                    foreach (MatroskaTagMetadata tag in format.Tags)
                    {
                        Console.WriteLine("TargetType: {0}", tag.TargetType);
                        Console.WriteLine("TargetTypeValue: {0}", tag.TargetTypeValue);
                        Console.WriteLine("TagTrackUid: {0}", tag.TagTrackUid);
                        foreach (MetadataProperty simpleTag in tag.SimpleTags)
                        {
                            Console.WriteLine("GetFormattedValue: {0}", simpleTag.GetFormattedValue());
                        }
                    }
                }
            }
            /// <summary>
            /// This method gets Matroska Track Metadata
            /// This method is supported by version 19.1 or greater 
            /// </summary>
            public static void MatroskaTrackMetadata()
            {
                using (MatroskaFormat format = new MatroskaFormat(Common.MapSourceFilePath(filePath)))
                {
                    foreach (MatroskaTrackMetadata track in format.Tracks)
                    {
                        Console.WriteLine("CodecId: {0}", track.CodecId);
                        Console.WriteLine("CodecName: {0}", track.CodecName);
                        Console.WriteLine("DefaultDuration: {0}", track.DefaultDuration);
                        Console.WriteLine("FlagEnabled: {0}", track.FlagEnabled);
                        Console.WriteLine("Language: {0}", track.Language);
                        Console.WriteLine("LanguageIetf: {0}", track.LanguageIetf);
                        Console.WriteLine("Name: {0}", track.Name);
                        Console.WriteLine("TrackNumber: {0}", track.TrackNumber);
                        Console.WriteLine("TrackType: {0}", track.TrackType);
                        Console.WriteLine("TrackUid: {0}", track.TrackUid);
                        MatroskaAudioTrackMetadata audioTrack = track as MatroskaAudioTrackMetadata;
                        if (audioTrack != null)
                        {
                            Console.WriteLine("SamplingFrequency: {0}", audioTrack.SamplingFrequency);
                            Console.WriteLine("OutputSamplingFrequency: {0}", audioTrack.OutputSamplingFrequency);
                            Console.WriteLine("Channels: {0}", audioTrack.Channels);
                            Console.WriteLine("BitDepth: {0}", audioTrack.BitDepth);
                        }
                        MatroskaVideoTrackMetadata videoTrack = track as MatroskaVideoTrackMetadata;
                        if (videoTrack != null)
                        {
                            Console.WriteLine("FlagInterlaced: {0}", videoTrack.FlagInterlaced);
                            Console.WriteLine("FieldOrder: {0}", videoTrack.FieldOrder);
                            Console.WriteLine("StereoMode: {0}", videoTrack.StereoMode);
                            Console.WriteLine("AlphaMode: {0}", videoTrack.AlphaMode);
                            Console.WriteLine("PixelWidth: {0}", videoTrack.PixelWidth);
                            Console.WriteLine("PixelHeight: {0}", videoTrack.PixelHeight);
                            Console.WriteLine("PixelCropBottom: {0}", videoTrack.PixelCropBottom);
                            Console.WriteLine("PixelCropTop: {0}", videoTrack.PixelCropTop);
                            Console.WriteLine("PixelCropLeft: {0}", videoTrack.PixelCropLeft);
                            Console.WriteLine("PixelCropRight: {0}", videoTrack.PixelCropRight);
                            Console.WriteLine("DisplayWidth: {0}", videoTrack.DisplayWidth);
                            Console.WriteLine("DisplayHeight: {0}", videoTrack.DisplayHeight);
                            Console.WriteLine("DisplayUnit: {0}", videoTrack.DisplayUnit);
                        }
                    }
                }
            }
        }
        public static class Asf
        {
            //Source file path
            private const string filePath = "Video/ASF/sample.asf";
            /// <summary>
            /// This method gets ASF video native metadata
            /// This method is supported by version 19.2 or greater 
            /// </summary>
            public static void GetMetadata()
            {
                //ExStart:GetASFNativeMetadata
                using (AsfFormat format = new AsfFormat(Common.MapSourceFilePath(filePath)))
                {
                    // get AsfMetadata
                    var metadata = format.AsfInfo;

                    //Display properties
                    Console.WriteLine("Creation date: {0}",metadata.CreationDate);
                    Console.WriteLine("File id: {0}", metadata.FileId);
                    Console.WriteLine("Flags: {0}", metadata.Flags);

                    // Display Asf Codec Information
                    foreach (AsfCodecInfo codecInfo in metadata.CodecInformation)
                    {
                        Console.WriteLine("Codec type: {0}", codecInfo.CodecType);
                        Console.WriteLine("Description: {0}", codecInfo.Description);
                        Console.WriteLine("Codec information: {0}", codecInfo.Information);
                        Console.WriteLine(codecInfo.Name);
                    }
                    // Display metadata descriptors
                    foreach (AsfBaseDescriptor descriptor in metadata.MetadataDescriptors)
                    {

                        Console.WriteLine("Name: {0}", descriptor.Name);
                        Console.WriteLine("Formatted value: {0}", descriptor.GetFormattedValue());
                        AsfMetadataDescriptor metadataDescriptor = descriptor as AsfMetadataDescriptor;
                        if (metadataDescriptor != null)
                        {
                            Console.WriteLine("Language: {0}", metadataDescriptor.Language);
                            Console.WriteLine("Stream number: {0}", metadataDescriptor.StreamNumber);
                            Console.WriteLine("Original name: {0}", metadataDescriptor.OriginalName);
                        }
                    }
                    //Dispay the base stream related metadata 
                    foreach (AsfBaseStreamProperty property in metadata.StreamProperties)
                    {
                        Console.WriteLine("Alternate bitrate: {0}", property.AlternateBitrate);
                        Console.WriteLine("Average bitrate: {0}", property.AverageBitrate);
                        Console.WriteLine("Average time per frame: {0}", property.AverageTimePerFrame);
                        Console.WriteLine("Bitrate: {0}", property.Bitrate);
                        Console.WriteLine("Stream end time: {0}", property.EndTime);
                        Console.WriteLine("Stream flags: {0}", property.Flags);
                        Console.WriteLine("Stream language: {0}", property.Language);
                        Console.WriteLine("Stream start time: {0}", property.StartTime);
                        Console.WriteLine("Stream number: {0}", property.StreamNumber);
                        Console.WriteLine("Stream type: {0}", property.StreamType);
                        
                        //Display the audio stream related metadata
                        AsfAudioStreamProperty audioStreamProperty = property as AsfAudioStreamProperty;
                        if (audioStreamProperty != null)
                        {
                            Console.WriteLine("Audio bits per sample: {0}", audioStreamProperty.BitsPerSample);
                            Console.WriteLine("Audio channels: {0}", audioStreamProperty.Channels);
                            Console.WriteLine("Audio format tag: {0}", audioStreamProperty.FormatTag);
                            Console.WriteLine("Audio samples per second: {0}", audioStreamProperty.SamplesPerSecond);
                        }
                        //Display the vedio stream related metadata
                        AsfVideoStreamProperty videoStreamProperty = property as AsfVideoStreamProperty;
                        if (videoStreamProperty != null)
                        {
                            Console.WriteLine("Video bits per pixels: {0}", videoStreamProperty.BitsPerPixels);
                            Console.WriteLine("Compression: {0}", videoStreamProperty.Compression);
                            Console.WriteLine("Image height: {0}", videoStreamProperty.ImageHeight);
                            Console.WriteLine("Image width: {0}", videoStreamProperty.ImageWidth);
                        }
                    }
                }
                //ExEnd:GetASFNativeMetadata
            }
            /// <summary>
            /// This method gets ASF video XMP metadata
            /// This method is supported by version 19.2 or greater
            /// </summary>
            public static void GetXMPMetadata()
            {
                //ExStart: GetASFXMPMetadata
                using (AsfFormat asfFormat = new AsfFormat(Common.MapSourceFilePath(filePath)))
                {
                    //Get XMP Basic metadata
                    var xmpMetadata = asfFormat.XmpValues.Schemes.XmpBasic;

                    // Display some properties from the XMP Basic metadata
                    Console.WriteLine("Creation date: {0}", xmpMetadata.CreateDate);
                    Console.WriteLine("Label: {0}", xmpMetadata.Label);
                    Console.WriteLine("Rating: {0}", xmpMetadata.Rating);
                }

                //ExEnd:GetASFXMPMetadata
            }
            /// <summary>
            /// This method write ASF video XMP metadata
            /// This method is supported by version 19.2 or greater
            /// </summary>
            public static void SetXMPMetadata()
            {
                //ExStart: WriteASFXMPMetadata
                using (AsfFormat asfFormat = new AsfFormat(Common.MapSourceFilePath(filePath)))
                {
                    //Get XMP Basic metadata
                    var xmpMetadata = asfFormat.XmpValues.Schemes.XmpBasic;

                    // set some properties to write xmp data
                    xmpMetadata.CreateDate = DateTime.Now;
                    xmpMetadata.Rating = 4;
                    xmpMetadata.Nickname = "ASF Video";

                    // Update the ASF file
                    asfFormat.Save(Common.MapDestinationFilePath(filePath));
                }

                //ExEnd:WriteASFXMPMetadata
            }
            /// <summary>
            /// This method remove ASF video XMP metadata
            /// This method is supported by version 19.2 or greater
            /// </summary>
            public static void RemoveXMPMetadata()
            {
                //ExStart: RemoveASFXMPMetadata
                using (AsfFormat format = new AsfFormat(Common.MapSourceFilePath(filePath)))
                {
                    // Remove all XMP data from ASF file
                    format.RemoveXmpData();
                    
                    // Update the ASF file
                    format.Save(Common.MapDestinationFilePath(filePath));
                }

                //ExEnd:RemoveASFXMPMetadata
            }
        }
    }
}



