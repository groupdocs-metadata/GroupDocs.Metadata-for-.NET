// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2021 GroupDocs. All Rights Reserved.
// </copyright> 

namespace GroupDocs.Metadata.Examples.CSharp.AdvancedUsage.ManagingMetadataForSpecificFormats.Audio.MP3
{
    using System;
    using Formats.Audio;

    /// <summary>
    /// This example demonstrates how to read the APEv2 tag in an MP3 file.
    /// </summary>
    public static class MP3ReadApeTag
    {
        public static void Run()
        {
            using (Metadata metadata = new Metadata(Constants.MP3WithApe))
            {
                var root = metadata.GetRootPackage<MP3RootPackage>();

                if (root.ApeV2 != null)
                {
                    Console.WriteLine(root.ApeV2.Album);
                    Console.WriteLine(root.ApeV2.Title);
                    Console.WriteLine(root.ApeV2.Artist);
                    Console.WriteLine(root.ApeV2.Composer);
                    Console.WriteLine(root.ApeV2.Copyright);
                    Console.WriteLine(root.ApeV2.Genre);
                    Console.WriteLine(root.ApeV2.Language);

                    // ...
                }
            }
        }
    }
}
