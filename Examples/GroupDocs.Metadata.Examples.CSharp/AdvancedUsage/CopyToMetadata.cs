// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2024 GroupDocs. All Rights Reserved.
// </copyright>

using GroupDocs.Metadata.Common;
using GroupDocs.Metadata.Tagging;
using System.IO;
using System;
using GroupDocs.Metadata.Formats.Document;
using GroupDocs.Metadata.Import;

namespace GroupDocs.Metadata.Examples.CSharp.AdvancedUsage
{
    /// <summary>
    /// This example demonstrates how to copy metadata properties to other file. 
    /// </summary>
    public static class CopyToMetadata
    {
        public static void Run()
        {
            Console.WriteLine("\n--------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("[Example Advanced Usage] # CopyToMetadata : How to copy metadata properties to other file.\n");
            using (Metadata source_metadata = new Metadata(Constants.InputPdf))
            using (Metadata destination_metadata = new Metadata(Constants.CopyPdf))
            {
                var source_root = source_metadata.GetRootPackage<PdfRootPackage>();

                Console.WriteLine("\nBefore copy:");
                Console.WriteLine("\nSource package:");
                Console.WriteLine(source_root.DocumentProperties.Author);
                Console.WriteLine(source_root.DocumentProperties.CreatedDate);
                Console.WriteLine(source_root.DocumentProperties.Producer);

                var destination_root = destination_metadata.GetRootPackage<PdfRootPackage>();

                Console.WriteLine("\nDestination package:");
                Console.WriteLine(destination_root.DocumentProperties.Author);
                Console.WriteLine(destination_root.DocumentProperties.CreatedDate);
                Console.WriteLine(destination_root.DocumentProperties.Producer);

                source_metadata.CopyTo(destination_root);

                Console.WriteLine("\n\nAfter copy:");
                Console.WriteLine("\nDestination package:");
                Console.WriteLine(destination_root.DocumentProperties.Author);
                Console.WriteLine(destination_root.DocumentProperties.CreatedDate);
                Console.WriteLine(destination_root.DocumentProperties.Producer);

            }
            
        }
    }
}
