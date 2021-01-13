// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2021 GroupDocs. All Rights Reserved.
// </copyright>

namespace GroupDocs.Metadata.Examples.CSharp.AdvancedUsage.ManagingMetadataForSpecificFormats.Document.WordProcessing
{
    using Formats.Document;

    /// <summary>
    /// This code sample demonstrates how to update document statistics for a WordProcessing document.
    /// </summary>
    public static class WordProcessingUpdateDocumentStatistics
    {
        public static void Run()
        {
            using (Metadata metadata = new Metadata(Constants.InputDoc))
            {
                var root = metadata.GetRootPackage<WordProcessingRootPackage>();

                root.UpdateDocumentStatistics();

                metadata.Save(Constants.OutputDoc);
            }
        }
    }
}
