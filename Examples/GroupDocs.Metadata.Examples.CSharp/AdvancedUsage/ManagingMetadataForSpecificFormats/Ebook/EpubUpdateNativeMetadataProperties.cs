// <copyright company="Aspose Pty Ltd">
//  Copyright (C) 2011-2024 GroupDocs. All Rights Reserved.
// </copyright>

namespace GroupDocs.Metadata.Examples.CSharp.AdvancedUsage.ManagingMetadataForSpecificFormats.Ebook
{
    using Formats.Ebook;
    using System;

    /// <summary>
    /// This code sample shows how to update EPUB format-specific metadata properties.
    /// </summary>
    public class EpubUpdateNativeMetadataProperties
    {
        public static void Run()
        {
            Console.WriteLine("\n--------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("[Example Advanced Usage] # EpubUpdateNativeMetadataProperties : How to update EPUB format-specific metadata properties.\n");
            using (Metadata metadata = new Metadata(Constants.InputEpub))
            {
                var root = metadata.GetRootPackage<EpubRootPackage>();

                root.EpubPackage.Creator = "GroupDocs";
                root.EpubPackage.Description = "test e-book";
                root.EpubPackage.Format = "EPUB";
                root.EpubPackage.Date = DateTime.Now.ToString();

                // ...

                metadata.Save(Constants.OutputEpub);
            }
        }
    }
}
