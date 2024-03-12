// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2024 GroupDocs. All Rights Reserved.
// </copyright>

namespace GroupDocs.Metadata.Examples.CSharp.AdvancedUsage.ManagingMetadataForSpecificFormats.Document.WordProcessing
{
    using Formats.Document;
    using System;

    /// <summary>
    /// This code sample demonstrates how to update document statistics for a WordProcessing document.
    /// </summary>
    public static class WordProcessingUpdateDocumentStatistics
    {
        public static void Run()
        {
            Console.WriteLine("\n--------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("[Example Advanced Usage] # WordProcessingUpdateDocumentStatistics : How to update document statistics for a WordProcessing document.\n");
            using (Metadata metadata = new Metadata(Constants.InputDoc))
            {
                var root = metadata.GetRootPackage<WordProcessingRootPackage>();

                root.UpdateDocumentStatistics();

                metadata.Save(Constants.OutputDoc);
            }
        }
    }
}
