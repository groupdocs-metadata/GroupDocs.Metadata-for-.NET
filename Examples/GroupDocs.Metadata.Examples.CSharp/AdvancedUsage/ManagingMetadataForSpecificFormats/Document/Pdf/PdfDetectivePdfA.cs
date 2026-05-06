// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2026 GroupDocs. All Rights Reserved.
// </copyright>

namespace GroupDocs.Metadata.Examples.CSharp.AdvancedUsage.ManagingMetadataForSpecificFormats.Document.Pdf
{
    using System;
    using Formats.Document;

    /// <summary>
    /// This code sample shows how indicating whether the document conforms to any PDF/A standard.
    /// </summary>
    public static class PdfDetectivePdfA
    {
        public static void Run()
        {
            Console.WriteLine("\n--------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("[Example Advanced Usage] # PdfDetectivePdfA : How indicating whether the document conforms to any PDF/A standard.\n");
            using (Metadata metadata = new Metadata(Constants.InputPdfA))
            {
                var root = metadata.GetRootPackage<PdfRootPackage>();

                if (root.FileType.IsPdfA)
                {
                    Console.WriteLine("PDF/A version: {0}", root.FileType.PdfFormat);
                }
                else
                {
                    Console.WriteLine("The document is not PDF/A compliant.");
                }
            }
        }
    }
}
