// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2021 GroupDocs. All Rights Reserved.
// </copyright>

namespace GroupDocs.Metadata.Examples.CSharp.AdvancedUsage.ManagingMetadataForSpecificFormats.Document.WordProcessing
{
    using System;
    using Formats.Document;

    /// <summary>
    /// This example demonstrates how to extract Dublin Core metadata from a WordProcessing document.
    /// </summary>
    public static class WordProcessingReadDublinCoreProperties
    {
        public static void Run()
        {
            using (Metadata metadata = new Metadata(Constants.InputDocx))
            {
                var root = metadata.GetRootPackage<WordProcessingRootPackage>();

                if (root.DublinCorePackage != null)
                {
                    Console.WriteLine(root.DublinCorePackage.Format);
                    Console.WriteLine(root.DublinCorePackage.Contributor);
                    Console.WriteLine(root.DublinCorePackage.Coverage);
                    Console.WriteLine(root.DublinCorePackage.Creator);
                    Console.WriteLine(root.DublinCorePackage.Source);
                    Console.WriteLine(root.DublinCorePackage.Description);

                    // ...
                }
            }
        }
    }
}
