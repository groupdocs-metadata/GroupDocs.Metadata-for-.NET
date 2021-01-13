// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2021 GroupDocs. All Rights Reserved.
// </copyright> 

namespace GroupDocs.Metadata.Examples.CSharp.AdvancedUsage.ManagingMetadataForSpecificFormats.Audio.MP3
{
    using System;
    using Formats.Audio;

    /// <summary>
    /// This code sample shows how to read the Lyrics tag from an MP3 file.
    /// </summary>
    public static class MP3ReadLyricsTag
    {
        public static void Run()
        {
            using (Metadata metadata = new Metadata(Constants.MP3WithLyrics))
            {
                var root = metadata.GetRootPackage<MP3RootPackage>();

                if (root.Lyrics3V2 != null)
                {
                    Console.WriteLine(root.Lyrics3V2.Lyrics);
                    Console.WriteLine(root.Lyrics3V2.Album);
                    Console.WriteLine(root.Lyrics3V2.Artist);
                    Console.WriteLine(root.Lyrics3V2.Track);

                    // ...

                    // Alternatively, you can loop through a full list of tag fields
                    foreach (var field in root.Lyrics3V2.ToList())
                    {
                        Console.WriteLine("{0} = {1}", field.ID, field.Data);
                    }
                }
            }
        }
    }
}
