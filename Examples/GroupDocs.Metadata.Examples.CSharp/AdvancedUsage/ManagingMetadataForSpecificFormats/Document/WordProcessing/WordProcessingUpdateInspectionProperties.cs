﻿// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2025 GroupDocs. All Rights Reserved.
// </copyright>

namespace GroupDocs.Metadata.Examples.CSharp.AdvancedUsage.ManagingMetadataForSpecificFormats.Document.WordProcessing
{
    using Formats.Document;
    using System;

    /// <summary>
    /// This code sample shows how to update inspection properties in a WordProcessing document.
    /// </summary>
    public static class WordProcessingUpdateInspectionProperties
    {
        public static void Run()
        {
            Console.WriteLine("\n--------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("[Example Advanced Usage] # WordProcessingUpdateInspectionProperties : How to update inspection properties in a WordProcessing document.\n");
            using (Metadata metadata = new Metadata(Constants.InputDoc))
            {
                var root = metadata.GetRootPackage<WordProcessingRootPackage>();

                root.InspectionPackage.ClearComments();
                root.InspectionPackage.AcceptAllRevisions();
                root.InspectionPackage.ClearFields();
                root.InspectionPackage.ClearHiddenText();

                metadata.Save(Constants.OutputDoc);
            }
        }
    }
}
