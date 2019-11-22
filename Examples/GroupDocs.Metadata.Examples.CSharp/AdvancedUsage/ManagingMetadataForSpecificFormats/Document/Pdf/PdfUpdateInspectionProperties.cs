// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2019 GroupDocs. All Rights Reserved.
// </copyright>

namespace GroupDocs.Metadata.Examples.CSharp.AdvancedUsage.ManagingMetadataForSpecificFormats.Document.Pdf
{
    using Formats.Document;

    /// <summary>
    ///  This code sample demonstrates how to remove the inspection properties in a PDF document.
    /// </summary>
    public static class PdfUpdateInspectionProperties
    {
        public static void Run()
        {
            using (Metadata metadata = new Metadata(Constants.SignedPdf))
            {
                var root = metadata.GetRootPackage<PdfRootPackage>();

                root.InspectionPackage.ClearAnnotations();
                root.InspectionPackage.ClearAttachments();
                root.InspectionPackage.ClearFields();
                root.InspectionPackage.ClearBookmarks();
                root.InspectionPackage.ClearDigitalSignatures();

                metadata.Save(Constants.OutputPdf);
            }
        }
    }
}
