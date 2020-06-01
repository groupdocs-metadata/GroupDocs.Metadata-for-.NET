// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2020 GroupDocs. All Rights Reserved.
// </copyright> 

namespace GroupDocs.Metadata.Examples.CSharp.AdvancedUsage.ManagingMetadataForSpecificFormats.Audio.MP3
{
    using Formats.Audio;

    /// <summary>
    /// The code sample shows how to update the ID3v2 tag in an MP3 file.
    /// </summary>
    public static class MP3UpdateID3V2Tag
    {
        public static void Run()
        {
            using (Metadata metadata = new Metadata(Constants.MP3WithID3V2))
            {
                var root = metadata.GetRootPackage<MP3RootPackage>();

                if (root.ID3V2 == null)
                {
                    root.ID3V2 = new ID3V2Tag();
                }

                root.ID3V2.Album = "test album";
                root.ID3V2.Artist = "test artist";
                root.ID3V2.Band = "test band";
                root.ID3V2.TrackNumber = "1";
                root.ID3V2.MusicalKey = "C#";
                root.ID3V2.Title = "code sample";
                root.ID3V2.Date = "2019";

                // ...

                metadata.Save(Constants.OutputMp3);
            }
        }
    }
}
