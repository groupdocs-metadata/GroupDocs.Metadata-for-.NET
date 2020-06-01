// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2020 GroupDocs. All Rights Reserved.
// </copyright>

namespace GroupDocs.Metadata.Examples.CSharp.AdvancedUsage.ManagingMetadataForSpecificFormats.Document.Pdf
{
    using Formats.Document;

    /// <summary>
    /// This code snippet demonstrates how to update custom metadata properties in a PDF document.
    /// </summary>
    public static class PdfUpdateCustomProperties
    {
        public static void Run()
        {
            using (Metadata metadata = new Metadata(Constants.InputPdf))
            {
                var root = metadata.GetRootPackage<PdfRootPackage>();

                root.DocumentProperties.Set("customProperty1", "some value");

                metadata.Save(Constants.OutputPdf);
            }
        }
    }
}
