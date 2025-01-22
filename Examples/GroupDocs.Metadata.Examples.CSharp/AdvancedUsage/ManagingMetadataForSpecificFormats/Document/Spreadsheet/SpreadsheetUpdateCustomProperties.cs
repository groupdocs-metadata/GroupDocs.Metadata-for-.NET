// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2025 GroupDocs. All Rights Reserved.
// </copyright>

namespace GroupDocs.Metadata.Examples.CSharp.AdvancedUsage.ManagingMetadataForSpecificFormats.Document.Spreadsheet
{
    using Formats.Document;
    using System;

    /// <summary>
    /// This code snippet demonstrates how to update custom metadata properties in a spreadsheet.
    /// </summary>
    public static class SpreadsheetUpdateCustomProperties
    {
        public static void Run()
        {
            Console.WriteLine("\n--------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("[Example Advanced Usage] # SpreadsheetUpdateCustomProperties : How to update custom metadata properties in a spreadsheet.\n");
            using (Metadata metadata = new Metadata(Constants.InputXls))
            {
                var root = metadata.GetRootPackage<SpreadsheetRootPackage>();

                root.DocumentProperties.Set("customProperty1", "some value");
                root.DocumentProperties.Set("customProperty2", 7);

                // Set a content type property
                root.DocumentProperties.ContentTypeProperties.Set("customContentTypeProperty", "custom value");

                metadata.Save(Constants.OutputXls);
            }
        }
    }
}
