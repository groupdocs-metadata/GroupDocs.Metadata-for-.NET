// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2023 GroupDocs. All Rights Reserved.
// </copyright> 

namespace GroupDocs.Metadata.Examples.CSharp.AdvancedUsage.ManagingMetadataForSpecificFormats.Audio.MP3
{
    using Formats.Audio;

    /// <summary>
    /// This example shows how to update the Lyrics tag in an MP3 file
    /// </summary>
    public static class MP3UpdateLyricsTag
    {
        public static void Run()
        {
            using (Metadata metadata = new Metadata(Constants.MP3WithLyrics))
            {
                var root = metadata.GetRootPackage<MP3RootPackage>();

                if (root.Lyrics3V2 == null)
                {
                    root.Lyrics3V2 = new LyricsTag();
                }

                root.Lyrics3V2.Lyrics = "[00:01]Test lyrics";
                root.Lyrics3V2.Artist = "test artist";
                root.Lyrics3V2.Album = "test album";
                root.Lyrics3V2.Track = "test track";

                // You can add a fully custom field to the tag
                root.Lyrics3V2.Set(new LyricsField("ABC", "custom value"));

                // ...

                metadata.Save(Constants.OutputMp3);
            }
        }
    }
}
