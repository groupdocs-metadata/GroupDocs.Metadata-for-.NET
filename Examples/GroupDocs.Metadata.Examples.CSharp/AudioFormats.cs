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
            private const string filePath = "Audio/Mp3/sample.mp3";
            //


            //EndEx:SourceMp3FilePath + SourceMp3DirectoryPath


            /// <summary>
            ///  Exports metadata of Mp3 format to Excel. 
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
            /// Detects MP3 audio format
            /// Recognition engine detect file only by internal file structure, not extension
            /// 
            /// </summary>
            public static void DetectMp3Format()
            {
                string[] files = Directory.GetFiles(directoryPath);

                foreach (string path in files)
                {
                    // detect format
                    using (FormatBase format = GroupDocs.Metadata.Tools.FormatFactory.RecognizeFormat(path))
                    {

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
            }


            /// <summary>
            /// Reads ID3v2 tag in MP3 format
            /// Supported ID3v2.3 and ID3v2.4, ID3v2.2 is obsolete by ID3.org
            /// </summary> 
            public static void ReadID3v2Tag()
            {
                try
                {
                    //ExStart:ReadID3v2Tag
                    // initialize Mp3Format class
                    using (Mp3Format mp3Format = new Mp3Format((Common.MapSourceFilePath(filePath))))
                    {
                        // get ID3 v2 tag
                        Id3v2Tag id3v2 = mp3Format.Id3v2 ?? new Id3v2Tag();
                        if (id3v2 != null)
                        {
                            // write ID3v2 version
                            Console.WriteLine("Version: {0}", id3v2.Version);

                            // write known frames' values
                            Console.WriteLine("Title: {0}", id3v2.Title);
                            Console.WriteLine("Artist: {0}", id3v2.Artist);
                            Console.WriteLine("Album: {0}", id3v2.Album);
                            Console.WriteLine("Comment: {0}", id3v2.Comment);
                            Console.WriteLine("Composers: {0}", id3v2.Composers);
                            Console.WriteLine("Band: {0}", id3v2.Band);
                            Console.WriteLine("Track Number: {0}", id3v2.TrackNumber);
                            Console.WriteLine("Year: {0}", id3v2.Year);

                            // in trial mode only first 5 frames are available
                            TagFrame[] idFrames = id3v2.Frames;

                            foreach (TagFrame tagFrame in idFrames)
                            {
                                Console.WriteLine("Frame: {0}, value: {1}", tagFrame.Name, tagFrame.GetFormattedValue());
                            }
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
            /// Updates ID3v2 tag in MP3 format
            /// </summary> 
            /// 
            public static void UpdateID3v2Tag()
            {
                try
                {
                    //ExStart:UpdateID3v2Tag
                    // initialize Mp3Format class
                    using (Mp3Format mp3Format = new Mp3Format((Common.MapSourceFilePath(filePath))))
                    {

                        // get id3v2 tag
                        Id3v2Tag id3Tag = mp3Format.Id3v2 ?? new Id3v2Tag();

                        // set artist
                        id3Tag.Artist = "A-ha";

                        // set title
                        id3Tag.Title = "Take on me";

                        // set band
                        id3Tag.Band = "A-ha";

                        // set comment
                        id3Tag.Comment = "GroupDocs.Metadata creator";

                        // set track number
                        id3Tag.TrackNumber = "5";

                        // set year
                        id3Tag.Year = "1986";

                        // update ID3v2 tag
                        mp3Format.UpdateId3v2(id3Tag);

                        // and commit changes
                        mp3Format.Save(); 
                    }
                    //ExEnd:UpdateID3v2Tag
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            /// <summary>
            /// Removes ID3v2 tag in MP3 format
            /// </summary> 
            public static void RemoveID3v2Tag()
            {
                //ExStart:RemoveID3v2Tag
                // init Mp3Format class
                using (Mp3Format mp3Format = new Mp3Format((Common.MapSourceFilePath(filePath))))
                {

                    // remove ID3v2 tag
                    mp3Format.RemoveId3v2();

                    // and commit changes
                    mp3Format.Save(); 
                }
                //ExEnd:RemoveID3v2Tag
            }

            /// <summary>
            /// Reads ID3v1 tag in MP3 format
            /// </summary> 
            /// 
            public static void ReadID3v1Tag()
            {
                try
                {
                    //ExStart:ReadID3v1Tag
                    // initialize Mp3Format class
                    using (Mp3Format mp3Format = new Mp3Format((Common.MapSourceFilePath(filePath))))
                    {
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
                    }
                    //ExEnd:ReadID3v1Tag
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            /// <summary>
            /// Updates ID3v1 tag in MP3 format
            /// </summary> 
            /// 
            public static void UpdateID3v1Tag()
            {
                try
                {
                    //ExStart:UpdateID3v1Tag
                    // initialize Mp3Format class
                    using (Mp3Format mp3Format = new Mp3Format((Common.MapSourceFilePath(filePath))))
                    {

                        // create id3v1 tag
                        Id3v1Tag id3Tag = new Id3v1Tag();

                        // set artist
                        id3Tag.Artist = "A-ha";

                        // set title
                        id3Tag.Title = "Take on me";

                        // update ID3v1 tag
                        mp3Format.UpdateId3v1(id3Tag);

                        // and commit changes
                        mp3Format.Save(); 
                    }
                    //ExEnd:UpdateID3v1Tag
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            /// <summary>
            /// Reads MPEG audio information
            /// </summary> 
            /// 
            public static void ReadMPEGAudioInfo()
            {
                try
                {
                    //ExStart:ReadMPEGAudioInfo
                    // get MPEG audio info
                    MpegAudio audioInfo = (MpegAudio)MetadataUtility.ExtractSpecificMetadata(Common.MapSourceFilePath(filePath), MetadataType.MpegAudio);

                    // another approach is to use Mp3Format directly:

                    // init Mp3Format class
                    // Mp3Format mp3Format = new Mp3Format((Common.MapSourceFilePath(filePath));

                    // get MPEG audio info
                    // MpegAudio audioInfo = mp3Format.AudioDetails;

                    // display MPEG audio version
                    Console.WriteLine("MPEG audio version: {0}", audioInfo.MpegAudioVersion);

                    // display layer version
                    Console.WriteLine("Layer version: {0}", audioInfo.LayerVersion);

                    // display header offset
                    Console.WriteLine("Header offset: {0}", audioInfo.HeaderPosition);

                    // display bitrate
                    Console.WriteLine("Bitrate: {0}", audioInfo.Bitrate);

                    // display frequency
                    Console.WriteLine("Frequency: {0}", audioInfo.Frequency);

                    // display channel mode
                    Console.WriteLine("Channel mode: {0}", audioInfo.ChannelMode);

                    // display original bit
                    Console.WriteLine("Is original: {0}", audioInfo.IsOriginal);

                    // display protected bit
                    Console.WriteLine("Is protected: {0}", audioInfo.IsProtected);
                    //ExEnd:ReadMPEGAudioInfo
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            /// <summary>
            /// Reads Lyrics3 tag in Mp3 format
            /// </summary>
            public static void ReadLayrics3Tag()
            {
                try
                {
                    //ExStart:ReadLayrics3TagInMp3
                    // initialize Mp3Format class
                    using (Mp3Format mp3Format = new Mp3Format((Common.MapSourceFilePath(filePath))))
                    {

                        // get Lyrics3 v2.00 tag
                        Lyrics3Tag lyrics3Tag = mp3Format.Lyrics3v2;

                        // check if Lyrics3 is presented. It could be absent.
                        if (lyrics3Tag != null)
                        {
                            // Display defined tag values
                            Console.WriteLine("Album: {0}", lyrics3Tag.Album);
                            Console.WriteLine("Artist: {0}", lyrics3Tag.Artist);
                            Console.WriteLine("Track: {0}", lyrics3Tag.Track);

                            // get all fields presented in Lyrics3Tag
                            Lyrics3Field[] allFields = lyrics3Tag.Fields;

                            foreach (Lyrics3Field lyrics3Field in allFields)
                            {
                                Console.WriteLine("Name: {0}, value: {1}", lyrics3Field.Name, lyrics3Field.Value);

                            }
                        } 
                    }
                    //ExEnd:ReadLayrics3TagInMp3
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            /// <summary>
            /// Reads Id3 metadata directly in MP3 format
            /// </summary>
            public static void ReadId3MetadataDirectly()
            {
                //ExStart:ReadId3MetadataInMp3Directly
                // init Mp3Format class
                using (Mp3Format mp3Format = new Mp3Format(Common.MapSourceFilePath(filePath)))
                {

                    // read album in ID3 v1
                    MetadataProperty album = mp3Format[MetadataKey.Id3v1.Album];
                    Console.WriteLine(album);

                    // read title in ID3 v2
                    MetadataProperty title = mp3Format[MetadataKey.Id3v2.Title];
                    Console.WriteLine(title);

                    // create custom ID3v2 key
                    // TCOP is used for 'Copyright' property according to the ID3 specification
                    MetadataKey copyrightKey = new MetadataKey(MetadataType.Id3v2, "TCOP");

                    // read copyright property
                    MetadataProperty copyright = mp3Format[copyrightKey];
                    Console.WriteLine(copyright); 
                }
                //ExEnd:ReadId3MetadataInMp3Directly
            }


            /// <summary>
            /// Shows how to read APEV2 tags in MP3 format
            /// Feature is supported in version 17.9.0 or greater of the API
            /// </summary>
            public static void ReadApev2Tag()
            {
                //ExStart:ReadApev2TagMp3
                // initialize Mp3Format. If file is not Mp3 then appropriate exception will throw.
                using (Mp3Format mp3Format = new Mp3Format(Common.MapSourceFilePath(filePath)))
                {

                    // get APEv2 tag
                    Apev2Metadata apev2 = mp3Format.APEv2;

                    //NOTE: please remember you may use different approaches to getting metadata                

                    // second approach
                    apev2 = (Apev2Metadata)MetadataUtility.ExtractSpecificMetadata(Common.MapSourceFilePath(filePath), MetadataType.APEv2);

                    // check if APEv2 tag is presented
                    if (apev2 != null)
                    {
                        // Display tag properties
                        Console.WriteLine("Album: {0}", apev2.Album);
                        Console.WriteLine("Artist: {0}", apev2.Artist);
                        Console.WriteLine("Comment: {0}", apev2.Comment);
                        Console.WriteLine("Genre: {0}", apev2.Genre);
                        Console.WriteLine("Title: {0}", apev2.Title);
                        Console.WriteLine("Track: {0}", apev2.Track);
                    } 
                }
                //ExEnd:ReadApev2TagMp3
            }

            public static void RemoveLayrics3Tag()
            {
                //ExStart:RemoveLayrics3Tag
                // initialize Mp3Format. If file is not Mp3 then appropriate exception will throw.
                using (Mp3Format mp3Format = new Mp3Format(Common.MapSourceFilePath(filePath)))
                {

                    // remove Lyrics3 tag
                    mp3Format.RemoveLyrics3v2();

                    // and commit changes
                    mp3Format.Save(); 
                }
                //ExEnd:RemoveLayrics3Tag

            }

            public static void CleanMetadata()
            {
                //ExStart:CleanMetadata
                // initialize Mp3Format. If file is not Mp3 then appropriate exception will throw.
                using (Mp3Format mp3Format = new Mp3Format(Common.MapSourceFilePath(filePath)))
                {
                    // removes id3/lyrics/ape tags
                    mp3Format.CleanMetadata();

                    // and commit changes
                    mp3Format.Save(); 
                }
                //ExEnd:CleanMetadata

            }

            public static void RemoveAPEV2Tag()
            {
                //ExStart:RemoveAPEV2Tag
                // initialize Mp3Format. If file is not Mp3 then appropriate exception will throw.
                using (Mp3Format mp3Format = new Mp3Format(Common.MapSourceFilePath(filePath)))
                {

                    // remove APE v2.0 tag
                    mp3Format.RemoveAPEv2();

                    // and commit changes
                    mp3Format.Save(); 
                }
                //ExEnd:RemoveAPEV2Tag

            }

            /// <summary>
            /// Validate ID3 input metadata before saving
            /// Feature is supported in version 18.2 or greater of the API
            /// </summary>
            public static void ValidateID3Metadata()
            {
                try
                {
                    //init Mp3Format class
                    using (Mp3Format mp3Format = new Mp3Format(Common.MapSourceFilePath(filePath)))
                    {
                        // set album but with invalid length
                        mp3Format.Id3v1Properties.Album = "this is very looooooooong album name but must be less 30 characters";

                        try
                        {
                            // and commit changes
                            mp3Format.Save();
                        }
                        catch (Shared.Exceptions.GroupDocsException e)
                        {
                            //e.Message is "Property 'album': Length could not be grater then 30"
                            Console.WriteLine(e);
                        }
                    }

                }
                catch (Exception exp)
                {

                    Console.WriteLine(exp.Message);
                }
            }
            /// <summary>
            /// Read additional properties from ID3v2 tag
            /// Feature is supported in version 18.2 or greater of the API
            /// </summary>
            public static void ReadAdditionalID3v2Properties()
            {
                try
                {
                    // init Mp3Format class
                    using (Mp3Format mp3Format = new Mp3Format(Common.MapSourceFilePath(filePath)))
                    {

                        // get ID3 v2 tag
                        Id3v2Tag id3v2 = mp3Format.Id3v2;

                        if (id3v2 != null)
                        {
                            // read sub-title
                            Console.WriteLine("Subtitle: {0}", id3v2.Subtitle);

                            // read musical key
                            Console.WriteLine("Musical key: {0}", id3v2.MusicalKey);

                            // read length in milliseconds
                            Console.WriteLine("Length in milliseconds: {0}", id3v2.LengthInMilliseconds);

                            // read original album
                            Console.WriteLine("Original album: {0}", id3v2.OriginalAlbum);

                            // read size in bytes. Please note that is present TSIZ tag and may be overrided by invalid value
                            Console.WriteLine("Original album: {0}", id3v2.SizeInBytes);

                            // read TSRC value
                            Console.WriteLine("Original album: {0}", id3v2.ISRC);

                            // read TSSE value
                            Console.WriteLine("Original album: {0}", id3v2.SoftwareHardware);

                            // read PCNT value
                            Console.WriteLine("Original album: {0}", id3v2.PlayCounter);
                        }

                        // and close input stream
                        mp3Format.Dispose(); 
                    }

                }
                catch (Exception exp)
                {
                    Console.WriteLine(exp.Message);
                }
            }
            /// <summary>
            /// Update ID3v2 tag using properties 
            /// Feature is supported in version 18.2 or greater of the API
            /// </summary>
            public static void UpdateID3v2TagUsingProperties()
            {
                try
                {
                    // init Mp3Format class
                    using (Mp3Format mp3Format = new Mp3Format(Common.MapSourceFilePath(filePath)))
                    {
                        // get id3v2 tag. It creates new tag if metadata not exist so user does not need to check it by null.
                        Id3v2Tag id3Tag = mp3Format.Id3v2Properties;

                        // set artist
                        id3Tag.Artist = "A-ha";

                        // set title
                        id3Tag.Title = "Take on me";

                        // set band
                        id3Tag.Band = "A-ha";

                        // set comment
                        id3Tag.Comment = "GroupDocs.Metadata creator";

                        // set track number
                        id3Tag.TrackNumber = "5";

                        // set year
                        id3Tag.Year = "1986";

                        // and commit changes
                        mp3Format.Save();
                    }
                }
                catch (Exception exp)
                {

                    Console.WriteLine(exp.Message);
                }
            }
            /// <summary>
            /// Update ID3v1 tag using properties 
            /// Feature is supported in version 18.2 or greater of the API
            /// </summary>
            public static void UpdateID3v1TagUsingProperties()
            {
                try
                {
                    // init Mp3Format class
                    using (Mp3Format mp3Format = new Mp3Format(Common.MapSourceFilePath(filePath)))
                    {
                        // get id3v1 tag
                        Id3v1Tag id3Tag = mp3Format.Id3v1Properties;

                        // set artist
                        id3Tag.Artist = "A-ha";

                        // set comment
                        id3Tag.Comment = "By GroupDocs.Metadata";

                        // set title
                        id3Tag.Title = "Take on me";

                        // set year
                        id3Tag.Year = "1986";

                        // and commit changes
                        mp3Format.Save();
                    }

                }
                catch (Exception exp)
                {
                    Console.WriteLine(exp.Message);
                }
            }
            /// <summary>
            /// Update or Remove Image Cover tag from ID3 audio tag 
            /// Feature is supported in version 18.2 or greater of the API
            /// </summary>
            public static void UpdateOrRemoveImageCoverID3()
            {
                try
                {
                    // init Mp3Format class
                    using (Mp3Format mp3Format = new Mp3Format(Common.MapSourceFilePath(filePath)))
                    {
                        // get id3v2
                        var metadata = mp3Format.GetId3v2Tag();

                        if (metadata == null)
                        {
                            return;
                        }

                        // remove image cover
                        metadata.RemoveImageCover();

                        // update metadata
                        mp3Format.UpdateId3v2(metadata);

                        // and store to other file
                        mp3Format.Save(Common.MapDestinationFilePath(filePath));
                    }

                }
                catch (Exception exp)
                {
                    Console.WriteLine(exp.Message);
                }
            }
            // <summary>
            /// Update ID3v2 Tag Using Stream
            /// </summary>
            public static void UpdateID3v2TagUsingStream()
            {
                using (Stream stream = File.Open(Common.MapDestinationFilePath(filePath), FileMode.OpenOrCreate, FileAccess.ReadWrite))
                {
                    using (Mp3Format format = new Mp3Format(Common.MapSourceFilePath(filePath)))
                    {
                        // get id3v2 tag
                        Id3v2Tag id3Tag = format.Id3v2Properties ?? new Id3v2Tag();

                        // set artist
                        id3Tag.Artist = "A-ha";

                        // set title
                        id3Tag.Title = "Take on me";

                        // set band
                        id3Tag.Band = "A-ha";

                        // set comment
                        id3Tag.Comment = "GroupDocs.Metadata creator";

                        // set track number
                        id3Tag.TrackNumber = "5";

                        // set year
                        id3Tag.Year = "1986";

                        // update ID3v2 tag
                        format.UpdateId3v2(id3Tag);

                        format.Save(stream);
                    }
                    // The stream is still open here
                }
            }

            /// <summary>
            /// Read ID3v2 Tag Using Stream
            /// </summary>
            public static void ReadID3v2TagUsingStream()
            {
                using (Stream stream = File.Open(Common.MapSourceFilePath(filePath), FileMode.Open, FileAccess.ReadWrite))
                {
                    using (Mp3Format format = new Mp3Format(stream))
                    {
                        // get ID3 v2 tag
                        Id3v2Tag id3v2 = format.Id3v2Properties ?? new Id3v2Tag();
                        if (id3v2 != null)
                        {
                            // write ID3v2 version
                            Console.WriteLine("Version: {0}", id3v2.Version);

                            // write known frames' values
                            Console.WriteLine("Title: {0}", id3v2.Title);
                            Console.WriteLine("Artist: {0}", id3v2.Artist);
                            Console.WriteLine("Album: {0}", id3v2.Album);
                            Console.WriteLine("Comment: {0}", id3v2.Comment);
                            Console.WriteLine("Composers: {0}", id3v2.Composers);
                            Console.WriteLine("Band: {0}", id3v2.Band);
                            Console.WriteLine("Track Number: {0}", id3v2.TrackNumber);
                            Console.WriteLine("Year: {0}", id3v2.Year);

                            // in trial mode only first 5 frames are available
                            TagFrame[] idFrames = id3v2.Frames;

                            foreach (TagFrame tagFrame in idFrames)
                            {
                                Console.WriteLine("Frame: {0}, value: {1}", tagFrame.Name, tagFrame.GetFormattedValue());
                            }
                        }
                    }
                    // The stream is still open here
                }

            }

            /// <summary>
            /// Read ImageCover using Metadata Utility 
            /// Feature is supported in version 18.4 or greater of the API
            /// </summary>
            public static void ReadImageCoverMetadataUtility()
            {
                try
                {
                    //Read DublinCore Metadata
                    ThumbnailMetadata thumbnailMetadata = (ThumbnailMetadata)MetadataUtility.ExtractSpecificMetadata(Common.MapSourceFilePath(filePath), MetadataType.Thumbnail);

                    if (thumbnailMetadata != null)
                    {
                        // get Mime Type 
                        Console.WriteLine(thumbnailMetadata.MimeType);
                        // get Length 
                        Console.WriteLine(thumbnailMetadata.ImageData.Length);

                    }

                }
                catch (Exception exp)
                {

                    Console.WriteLine(exp.Message);
                }
            }

            /// <summary>
            /// Read Image Cover from ID3 audio tag
            /// Feature is supported in version 18.2 or greater of the API
            /// </summary>
            public static void ReadImageCoverID3()
            {
                try
                {
                    // init Mp3Format class
                    using (Mp3Format mp3Format = new Mp3Format(Common.MapSourceFilePath(filePath)))
                    {
                        // get id3v2
                        var metadata = mp3Format.GetId3v2Tag();

                        // check if ID3v2 is exist
                        if (metadata == null)
                        {
                            return;
                        }

                        // read APIC frames
                        var frames = metadata["APIC"];

                        if (frames != null && frames.Length == 1)
                        {
                            // get AttachedPictureFrame
                            AttachedPictureFrame picture = (AttachedPictureFrame)frames[0];

                            // use 'jpeg' as default extension
                            string extension = ".jpeg";
                            string mimeType = picture.MIMEType;

                            // try resolve extension from MIME
                            if (mimeType != null)
                            {
                                if (mimeType.Contains("jpg"))
                                {
                                    extension = ".jpeg";
                                }
                                else if (mimeType.Contains("bmp"))
                                {
                                    extension = ".bmp";
                                }
                                else if (mimeType.Contains("png"))
                                {
                                    extension = ".png";
                                }
                            }

                            // prepare file name
                            string file = string.Format(Common.MapDestinationFilePath(filePath), extension);

                            // and store it to the file system
                            System.IO.File.WriteAllBytes(file, picture.PictureData);
                        }
                    }

                }
                catch (Exception exp)
                {
                    Console.WriteLine(exp.Message);
                }
            }
        }

        public static class Wav
        {
            // initialize file path and directory path
            //ExStart:SourceWavFilePath + SourceWavDirectoryPath 
            private const string directoryPath = "Audio/Wav";
            private const string filePath = "Audio/Wav/sample.wav";
            //ExEnd:SourceWavFilePath + SourceWavDirectoryPath

            /// <summary>
            /// Detects Wav audio format
            /// </summary>
            public static void DetectWavFormat()
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

                    if (format.Type == DocumentType.Wav)
                    {
                        Console.WriteLine("File {0} has WAV format", Path.GetFileName(path));
                    }
                }
            }

            /// <summary>
            /// Reads audio details
            /// </summary>
            public static void ReadAudioDetails()
            {
                try
                {
                    //ExStart:ReadAudioDetailsInWav
                    // initialize WavFormat class
                    using (WavFormat wavFormat = new WavFormat((Common.MapSourceFilePath(filePath))))
                    {

                        // get audio info
                        WavAudioInfo audioInfo = wavFormat.AudioInfo;

                        // display bits per sample
                        Console.WriteLine("Bits per sample: {0}", audioInfo.BitsPerSample);

                        // display audio format version
                        Console.WriteLine("Audio format: {0}", audioInfo.AudioFormat);

                        // display number of channels
                        Console.WriteLine("Number of channels: {0}", audioInfo.NumberOfChannels);

                        // display sample rate
                        Console.WriteLine("Sample rate: {0}", audioInfo.SampleRate); 
                    }
                    //ExEnd:ReadAudioDetailsInWav
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            /// <summary>
            /// Update XMP Metadata
            /// Feature is supported in version 18.6 or greater of the API
            /// </summary>
            public static void UpdateXmpMetadata()
            {
                using (WavFormat format = new WavFormat(Common.MapSourceFilePath(filePath)))
                {
                    Console.WriteLine(format.XmpValues.Schemes.XmpBasic.CreateDate);
                    Console.WriteLine(format.XmpValues.Schemes.XmpBasic.Label);
                    Console.WriteLine(format.XmpValues.Schemes.DublinCore.Subject);
                    Console.WriteLine(format.XmpValues.Schemes.DublinCore.Format);

                    format.XmpValues.Schemes.XmpBasic.CreateDate = DateTime.Now;
                    format.XmpValues.Schemes.XmpBasic.Label = "Test";
                    format.XmpValues.Schemes.DublinCore.Subject = "WAV XMP Test";
                    format.XmpValues.Schemes.DublinCore.Format = "WAV Audio";

                    format.Save(Common.MapDestinationFilePath(filePath));
                }
            }
            /// <summary>
            /// Remove XMP Metadata
            /// Feature is supported in version 18.6 or greater of the API
            /// </summary>
            public static void RemoveXmpMetadata()
            {
                using (WavFormat format = new WavFormat(Common.MapSourceFilePath(filePath)))
                {
                    format.RemoveXmpData();
                    format.Save(Common.MapDestinationFilePath(filePath));
                }
            }
            /// <summary>
            /// Update XMP Metadata usin Stream
            /// Feature is supported in version 18.6 or greater of the API
            /// </summary>
            public static void UpdateXmpMetadataUsingStream()
            {
                using (Stream stream = File.Open(Common.MapDestinationFilePath(filePath), FileMode.OpenOrCreate, FileAccess.ReadWrite))
                {
                    using (WavFormat format = new WavFormat(Common.MapSourceFilePath(filePath)))
                    {
                        Console.WriteLine(format.XmpValues.Schemes.XmpBasic.CreateDate);
                        Console.WriteLine(format.XmpValues.Schemes.XmpBasic.Label);
                        Console.WriteLine(format.XmpValues.Schemes.DublinCore.Subject);
                        Console.WriteLine(format.XmpValues.Schemes.DublinCore.Format);

                        format.XmpValues.Schemes.XmpBasic.CreateDate = DateTime.Now;
                        format.XmpValues.Schemes.XmpBasic.Label = "Test";
                        format.XmpValues.Schemes.DublinCore.Subject = "WAV XMP Test";
                        format.XmpValues.Schemes.DublinCore.Format = "WAV Audio";

                        format.Save(stream);
                    }
                    // The stream is still open here
                }
            }
        }
    }
}
