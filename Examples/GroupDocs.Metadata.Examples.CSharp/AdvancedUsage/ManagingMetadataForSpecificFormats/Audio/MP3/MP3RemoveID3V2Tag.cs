// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2024 GroupDocs. All Rights Reserved.
// </copyright> 

namespace GroupDocs.Metadata.Examples.CSharp.AdvancedUsage.ManagingMetadataForSpecificFormats.Audio.MP3
{
    using Formats.Audio;
    using System;

    /// <summary>
    /// The code sample below shows how to remove the ID3v2 tag from an MP3 file.
    /// </summary>
    public static class MP3RemoveID3V2Tag
    {
        public static void Run()
        {
            Console.WriteLine("\n--------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("[Example Advanced Usage] # MP3RemoveID3V2Tag : How to remove the ID3v2 tag from an MP3 file.\n");
            using (Metadata metadata = new Metadata(Constants.MP3WithID3V2))
            {
                var root = metadata.GetRootPackage<MP3RootPackage>();

                root.ID3V2 = null;

                metadata.Save(Constants.OutputMp3);
            }
        }
    }
}
