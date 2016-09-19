using GroupDocs.Metadata.Examples.Utilities.CSharp;
using GroupDocs.Metadata.Formats;
using GroupDocs.Metadata.Formats.Audio;
using GroupDocs.Metadata.Tools;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace GroupDocs.Metadata.Examples.CSharp
{
    public static class AudioFormats
    {
        public static class Mp3
        {
            // initialize file path and directory path
            //ExStart:SourceMp3FilePath + SourceMp3DirectoryPath
            //string dir = @"C:\\download files";
            private const string directoryPath = "Audio/Mp3";
            private const string filePath = "Audio/Mp3/test.mp3";
            //ExEnd:SourceMp3FilePath + SourceMp3DirectoryPath


            /// <summary>
            ///  Export metadata of Mp3 format to Excel. 
            ///  Each new metadata type will be presented in separate sheet
            /// </summary>
            public static void ExportMetadataToExcel()
            {
                // path to the out dir
                string outputDir = directoryPath;

                // get mp3 files only
                string[] files = Directory.GetFiles(directoryPath, "*.mp3");

                foreach (string path in files)
                {
                    // get excel file as byte array
                    byte[] bytes = ExportFacade.ExportToExcel(path);

                    // prepare excel file name
                    string resultFileName = string.Format("{0}\\{1}.xlsx", outputDir, Path.GetFileNameWithoutExtension(path));

                    // remove output file if exist
                    if (File.Exists(resultFileName))
                    {
                        File.Delete(resultFileName);
                    }

                    // write file to the file system
                    File.WriteAllBytes(resultFileName, bytes);
                }

            }

            /// <summary>
            /// Detect MP3 audio format
            /// Recognition engine detect file only by internal file structure, not extension
            /// 
            /// </summary>
            public static void DetectMp3Format()
            {
                string[] files = Directory.GetFiles(directoryPath);

                foreach (string path in files)
                {
                    // detect format
                    FormatBase format = GroupDocs.Metadata.Tools.FormatFactory.RecognizeFormat(path);
                    if (format == null)
                    {
                        // skip unsupported format
                        continue;
                    }

                    if (format.Type == DocumentType.Mp3)
                    {
                        Console.WriteLine("File {0} has MP3 format", Path.GetFileName(path));
                    }
                }
            }


            /// <summary>
            /// Read ID3v2 tag in MP3 format
            /// Supported ID3v2.3 and ID3v2.4, ID3v2.2 is obsolete by ID3.org
            /// </summary> 
            public static void ReadID3v2Tag()
            {
                try
                {
                    //ExStart:ReadID3v2Tag
                    // initialize Mp3Format class
                    Mp3Format mp3Format = new Mp3Format((Common.MapSourceFilePath(filePath)));

                    // get ID3 v2 tag
                    Id3v2Tag id3v2 = mp3Format.Id3v2;
                    if (id3v2 != null)
                    {
                        // write ID3v2 version
                        Console.WriteLine("Version: {0}", id3v2.Version);

                        // write known frames' values
                        Console.WriteLine("Album: {0}", id3v2.Album);
                        Console.WriteLine("Comment: {0}", id3v2.Comment);
                        Console.WriteLine("Composers: {0}", id3v2.Composers);

                        // in trial mode only first 5 frames are available
                        TagFrame[] idFrames = id3v2.Frames;

                        foreach (TagFrame tagFrame in idFrames)
                        {
                            Console.WriteLine("Frame: {0}, value: {1}", tagFrame.Name, tagFrame.GetFormattedValue());
                        }
                    }
                    //ExEnd:ReadID3v2Tag
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            /// <summary>
            /// Read ID3v1 tag in MP3 format
            /// </summary> 
            /// 
            public static void ReadID3v1Tag()
            {
                try
                {
                    //ExStart:ReadID3v1Tag
                    // initialize Mp3Format class
                    Mp3Format mp3Format = new Mp3Format((Common.MapSourceFilePath(filePath)));

                    // get ID3v1 tag
                    Id3v1Tag id3V1 = mp3Format.Id3v1;

                    //NOTE: please remember you may use different approaches to getting metadata                

                    // second approach
                    //id3V1 = (Id3v1Tag)MetadataUtility.ExtractSpecificMetadata(file, MetadataType.Id3v1);

                    // check if ID3v1 is presented. It could be absent in Mpeg file.
                    if (id3V1 != null)
                    {
                        // Display version
                        Console.WriteLine("ID3v1 version: {0}", id3V1.Version);

                        // Display tag properties
                        Console.WriteLine("Album: {0}", id3V1.Album);
                        Console.WriteLine("Artist: {0}", id3V1.Artist);
                        Console.WriteLine("Comment: {0}", id3V1.Comment);
                        Console.WriteLine("Genre: {0}", id3V1.Genre);
                        Console.WriteLine("Title: {0}", id3V1.Title);
                        Console.WriteLine("Year: {0}", id3V1.Year);

                        if (id3V1.Version == "ID3v1.1")
                        {
                            // Track number is presented only in ID3 v1.1
                            Console.WriteLine("Track number: {0}", id3V1.TrackNumber);
                        }
                    }

                    //ExEnd:ReadID3v1Tag
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            /// <summary>
            /// Read MPEG audio information
            /// </summary> 
            /// 
            public static void ReadMPEGAudioInfo()
            {
                try
                {
                    //ExStart:ReadMPEGAudioInfo
                    // initialize Mp3Format class
                    Mp3Format mp3Format = new Mp3Format((Common.MapSourceFilePath(filePath)));

                    // get MPEG audio info
                    MpegAudio audioInfo = mp3Format.AudioDetails;

                    // display MPEG audio version
                    Console.WriteLine("MPEG audio version: {0}", audioInfo.MpegAudioVersion);

                    // display layer version
                    Console.WriteLine("Layer version: {0}", audioInfo.LayerVersion);

                    // display protected bit
                    Console.WriteLine("Is protected: {0}", audioInfo.IsProtected);
                    //ExEnd:ReadMPEGAudioInfo
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

        }
    }
}
