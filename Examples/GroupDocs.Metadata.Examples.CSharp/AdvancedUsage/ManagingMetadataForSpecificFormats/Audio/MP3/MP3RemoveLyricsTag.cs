// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2025 GroupDocs. All Rights Reserved.
// </copyright> 

namespace GroupDocs.Metadata.Examples.CSharp.AdvancedUsage.ManagingMetadataForSpecificFormats.Audio.MP3
{
    using Formats.Audio;
    using System;

    /// <summary>
    /// This example shows how to remove the ID3v2 tag from an MP3 file.
    /// </summary>
    public static class MP3RemoveLyricsTag
    {
        public static void Run()
        {
            Console.WriteLine("\n--------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("[Example Advanced Usage] # MP3RemoveLyricsTag : How to remove the ID3v2 tag from an MP3 file.\n");
            using (Metadata metadata = new Metadata(Constants.MP3WithLyrics))
            {
                var root = metadata.GetRootPackage<MP3RootPackage>();

                root.Lyrics3V2 = null;

                metadata.Save(Constants.OutputMp3);
            }
        }
    }
}
