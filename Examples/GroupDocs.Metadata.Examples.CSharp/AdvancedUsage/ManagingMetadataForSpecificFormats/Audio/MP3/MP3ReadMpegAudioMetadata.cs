// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2019 GroupDocs. All Rights Reserved.
// </copyright> 

namespace GroupDocs.Metadata.Examples.CSharp.AdvancedUsage.ManagingMetadataForSpecificFormats.Audio.MP3
{
    using Formats.Audio;
    using System;

    /// <summary>
    /// This example demonstrates how to read MPEG audio metadata from an MP3 file.
    /// </summary>
    public class MP3ReadMpegAudioMetadata
    {
        public static void Run()
        {
            using (Metadata metadata = new Metadata(Constants.MP3WithID3V2))
            {
                var root = metadata.GetRootPackage<MP3RootPackage>();

                Console.WriteLine(root.MpegAudioPackage.Bitrate);
                Console.WriteLine(root.MpegAudioPackage.ChannelMode);
                Console.WriteLine(root.MpegAudioPackage.Emphasis);
                Console.WriteLine(root.MpegAudioPackage.Frequency);
                Console.WriteLine(root.MpegAudioPackage.HeaderPosition);
                Console.WriteLine(root.MpegAudioPackage.Layer);

                // ...
            }
        }
    }
}
