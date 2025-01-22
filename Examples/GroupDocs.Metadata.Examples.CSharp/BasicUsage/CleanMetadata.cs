// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2025 GroupDocs. All Rights Reserved.
// </copyright>

namespace GroupDocs.Metadata.Examples.CSharp.BasicUsage
{
    using System;

    /// <summary>
    /// This example demonstrates how to remove all detected metadata packages/properties from a file.
    /// </summary>
    public static class CleanMetadata
    {
        public static void Run()
        {
            Console.WriteLine("\n--------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("[Example Basic Usage] # CleanMetadata : How to remove all detected metadata packages/properties from a file.\n");
            // Constants.InputPdf is an absolute or relative path to your document. Ex: @"C:\Docs\source.pdf"
            using (Metadata metadata = new Metadata(Constants.InputPdf))
            {
                // Remove detected metadata packages
                var affected = metadata.Sanitize();
                Console.WriteLine("Properties removed: {0}", affected);

                metadata.Save(Constants.OutputPdf);
            }
        }
    }
}
