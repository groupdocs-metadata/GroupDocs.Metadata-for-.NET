// <copyright company="Aspose Pty Ltd">
//  Copyright (C) 2011-2023 GroupDocs. All Rights Reserved.
// </copyright>

namespace GroupDocs.Metadata.Examples.CSharp.AdvancedUsage.ManagingMetadataForSpecificFormats.Ebook
{
    using System;
    using Formats.Ebook;

    /// <summary>
    /// This code sample shows how to read EPUB format-specific metadata properties.
    /// </summary>
    public static class EpubReadNativeMetadataProperties
    {
        public static void Run()
        {
            using (Metadata metadata = new Metadata(Constants.InputEpub))
            {
                var root = metadata.GetRootPackage<EpubRootPackage>();

                Console.WriteLine(root.EpubPackage.Version);
                Console.WriteLine(root.EpubPackage.UniqueIdentifier);
                Console.WriteLine(root.EpubPackage.ImageCover != null ? root.EpubPackage.ImageCover.Length : 0);
                Console.WriteLine(root.EpubPackage.Description);
                Console.WriteLine(root.EpubPackage.Title);

                // ...
            }
        }
    }
}
