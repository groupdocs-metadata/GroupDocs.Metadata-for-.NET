// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2023 GroupDocs. All Rights Reserved.
// </copyright>

namespace GroupDocs.Metadata.Examples.CSharp.AdvancedUsage.ManagingMetadataForSpecificFormats.Document.Pdf
{
    using System;
    using Formats.Document;

    /// <summary>
    /// This code snippet demonstrates how to update built-in metadata properties in a PDF document.
    /// </summary>
    public static class PdfUpdateBuiltInProperties
    {
        public static void Run()
        {
            using (Metadata metadata = new Metadata(Constants.InputPdf))
            {
                var root = metadata.GetRootPackage<PdfRootPackage>();

                root.DocumentProperties.Author = "test author";
                root.DocumentProperties.CreatedDate = DateTime.Now;
                root.DocumentProperties.Title = "test title";
                root.DocumentProperties.Keywords = "metadata, built-in, update";

                // ... 

                metadata.Save(Constants.OutputPdf);
            }
        }
    }
}
