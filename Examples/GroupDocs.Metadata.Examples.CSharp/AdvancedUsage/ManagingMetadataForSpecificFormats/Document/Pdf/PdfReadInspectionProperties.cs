// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2020 GroupDocs. All Rights Reserved.
// </copyright>

namespace GroupDocs.Metadata.Examples.CSharp.AdvancedUsage.ManagingMetadataForSpecificFormats.Document.Pdf
{
    using Formats.Document;
    using System;

    /// <summary>
    /// This example demonstrates how to inspect a PDF document.
    /// </summary>
    public static class PdfReadInspectionProperties
    {
        public static void Run()
        {
            using (Metadata metadata = new Metadata(Constants.SignedPdf))
            {
                var root = metadata.GetRootPackage<PdfRootPackage>();

                if (root.InspectionPackage.Annotations != null)
                {
                    foreach (var annotation in root.InspectionPackage.Annotations)
                    {
                        Console.WriteLine(annotation.Name);
                        Console.WriteLine(annotation.Text);
                        Console.WriteLine(annotation.PageNumber);
                    }
                }

                if (root.InspectionPackage.Attachments != null)
                {
                    foreach (var attachment in root.InspectionPackage.Attachments)
                    {
                        Console.WriteLine(attachment.Name);
                        Console.WriteLine(attachment.MimeType);
                        Console.WriteLine(attachment.Description);
                    }
                }

                if (root.InspectionPackage.Bookmarks != null)
                {
                    foreach (var bookmark in root.InspectionPackage.Bookmarks)
                    {
                        Console.WriteLine(bookmark.Title);
                    }
                }

                if (root.InspectionPackage.DigitalSignatures != null)
                {
                    foreach (var signature in root.InspectionPackage.DigitalSignatures)
                    {
                        Console.WriteLine(signature.CertificateSubject);
                        Console.WriteLine(signature.Comments);
                        Console.WriteLine(signature.SignTime);

                        // ...
                    }
                }

                if (root.InspectionPackage.Fields != null)
                {
                    foreach (var field in root.InspectionPackage.Fields)
                    {
                        Console.WriteLine(field.Name);
                        Console.WriteLine(field.Value);

                        // ...
                    }
                }
            }
        }
    }
}