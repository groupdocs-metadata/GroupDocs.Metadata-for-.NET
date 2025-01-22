// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2025 GroupDocs. All Rights Reserved.
// </copyright>

using GroupDocs.Metadata.Formats.Document;
using GroupDocs.Metadata.Import;

namespace GroupDocs.Metadata.Examples.CSharp.AdvancedUsage
{
    using System;
    using System.IO;

    /// <summary>
    /// This example demonstrates how to import metadata properties from json. 
    /// </summary>
    public static class ImportMetadata
    {
        public static void Run()
        {
            Console.WriteLine("\n--------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("[Example Advanced Usage] # ImportMetadata : How to import metadata from json.\n");
            Console.WriteLine("Before import:\n");
            using (Metadata metadata = new Metadata(Constants.InputPdf))
            {
                var root = metadata.GetRootPackage<PdfRootPackage>();

                Console.WriteLine(root.DocumentProperties.Author);
                Console.WriteLine(root.DocumentProperties.CreatedDate);
                Console.WriteLine(root.DocumentProperties.Producer);

                var manager = new ImportManager(root);
                manager.Import(Constants.ImportPdf, ImportFormat.Json, new JsonImportOptions());
                metadata.Save(Constants.OutputPdf);
            }
            Console.WriteLine("\nAfter import:\n");
            using (Metadata metadata = new Metadata(Constants.OutputPdf))
            {
                var root = metadata.GetRootPackage<PdfRootPackage>();

                Console.WriteLine(root.DocumentProperties.Author);
                Console.WriteLine(root.DocumentProperties.CreatedDate);
                Console.WriteLine(root.DocumentProperties.Producer);
            }
        }
    }
}