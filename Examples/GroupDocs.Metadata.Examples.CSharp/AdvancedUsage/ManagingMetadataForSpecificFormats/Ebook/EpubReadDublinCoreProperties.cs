// <copyright company="Aspose Pty Ltd">
//  Copyright (C) 2011-2020 GroupDocs. All Rights Reserved.
// </copyright>

namespace GroupDocs.Metadata.Examples.CSharp.AdvancedUsage.ManagingMetadataForSpecificFormats.Ebook
{
    using System;
    using Formats.Ebook;

    /// <summary>
    /// This example shows how to extract Dublin Core metadata from an EPUB file.
    /// </summary>
    public static class EpubReadDublinCoreProperties
    {
        public static void Run()
        {
            using (Metadata metadata = new Metadata(Constants.InputEpub))
            {
                var root = metadata.GetRootPackage<EpubRootPackage>();

                if (root.DublinCorePackage != null)
                {
                    Console.WriteLine(root.DublinCorePackage.Rights);
                    Console.WriteLine(root.DublinCorePackage.Publisher);
                    Console.WriteLine(root.DublinCorePackage.Title);
                    Console.WriteLine(root.DublinCorePackage.Creator);
                    Console.WriteLine(root.DublinCorePackage.Language);
                    Console.WriteLine(root.DublinCorePackage.Date);

                    // ...
                }
            }
        }
    }
}
