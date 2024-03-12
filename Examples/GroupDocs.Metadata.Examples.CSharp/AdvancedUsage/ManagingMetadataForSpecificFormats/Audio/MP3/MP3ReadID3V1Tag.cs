// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2024 GroupDocs. All Rights Reserved.
// </copyright> 

namespace GroupDocs.Metadata.Examples.CSharp.AdvancedUsage.ManagingMetadataForSpecificFormats.Audio.MP3
{
    using System;
    using Formats.Audio;

    /// <summary>
    /// This code sample shows how to read the ID3v1 tag in an MP3 file.
    /// </summary>
    public static class MP3ReadID3V1Tag
    {
        public static void Run()
        {
            Console.WriteLine("\n--------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("[Example Advanced Usage] # MP3ReadID3V1Tag : How to read the ID3v1 tag in an MP3 file.\n");
            using (Metadata metadata = new Metadata(Constants.MP3WithID3V1))
            {
                var root = metadata.GetRootPackage<MP3RootPackage>();

                if (root.ID3V1 != null)
                {
                    Console.WriteLine(root.ID3V1.Album);
                    Console.WriteLine(root.ID3V1.Artist);
                    Console.WriteLine(root.ID3V1.Title);
                    Console.WriteLine(root.ID3V1.Version);
                    Console.WriteLine(root.ID3V1.Comment);

                    // ...
                }
            }
        }
    }
}
