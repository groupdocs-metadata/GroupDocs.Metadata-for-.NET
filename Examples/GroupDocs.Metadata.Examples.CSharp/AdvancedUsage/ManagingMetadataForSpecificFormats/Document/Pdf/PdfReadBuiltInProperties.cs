// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2024 GroupDocs. All Rights Reserved.
// </copyright>

namespace GroupDocs.Metadata.Examples.CSharp.AdvancedUsage.ManagingMetadataForSpecificFormats.Document.Pdf
{
    using System;
    using Formats.Document;

    /// <summary>
    /// This code sample shows how to extract built-in metadata properties from a PDF document.
    /// </summary>
    public static class PdfReadBuiltInProperties
    {
        public static void Run()
        {
            Console.WriteLine("\n--------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("[Example Advanced Usage] # PdfReadBuiltInProperties : How to extract built-in metadata properties from a PDF document.\n");
            using (Metadata metadata = new Metadata(Constants.InputPdf))
            {
                var root = metadata.GetRootPackage<PdfRootPackage>();

                Console.WriteLine(root.DocumentProperties.Author);
                Console.WriteLine(root.DocumentProperties.CreatedDate);
                Console.WriteLine(root.DocumentProperties.Subject);
                Console.WriteLine(root.DocumentProperties.Producer);
                Console.WriteLine(root.DocumentProperties.Keywords);

                // ... 
            }
        }
    }
}
