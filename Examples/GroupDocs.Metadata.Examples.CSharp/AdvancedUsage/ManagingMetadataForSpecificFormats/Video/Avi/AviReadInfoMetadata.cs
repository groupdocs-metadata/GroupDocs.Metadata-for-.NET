// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2024 GroupDocs. All Rights Reserved.
// </copyright>

namespace GroupDocs.Metadata.Examples.CSharp.AdvancedUsage.ManagingMetadataForSpecificFormats.Video.Avi
{
    using System;
    using Formats.Video;

    /// <summary>
    /// This code sample shows how to extract INFO chunk metadata from an AVI file.
    /// </summary>
    public static class AviReadInfoMetadata
    {
        public static void Run()
        {
            Console.WriteLine("\n--------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("[Example Advanced Usage] # AviReadInfoMetadata : How to extract INFO chunk metadata from an AVI file.\n");
            using (Metadata metadata = new Metadata(Constants.InputAvi))
            {
                var root = metadata.GetRootPackage<AviRootPackage>();
                if (root.RiffInfoPackage != null)
                {
                    Console.WriteLine(root.RiffInfoPackage.Artist);
                    Console.WriteLine(root.RiffInfoPackage.Comment);
                    Console.WriteLine(root.RiffInfoPackage.Copyright);
                    Console.WriteLine(root.RiffInfoPackage.CreationDate);
                    Console.WriteLine(root.RiffInfoPackage.Software);
                    Console.WriteLine(root.RiffInfoPackage.Engineer);
                    Console.WriteLine(root.RiffInfoPackage.Genre);

                    // ...
                }
            }
        }
    }
}
