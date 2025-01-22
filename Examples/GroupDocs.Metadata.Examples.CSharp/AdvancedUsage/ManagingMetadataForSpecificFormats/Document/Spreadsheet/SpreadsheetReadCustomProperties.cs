// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2025 GroupDocs. All Rights Reserved.
// </copyright>

namespace GroupDocs.Metadata.Examples.CSharp.AdvancedUsage.ManagingMetadataForSpecificFormats.Document.Spreadsheet
{
    using System;
    using Formats.Document;
    using Tagging;

    /// <summary>
    /// This code snippet demonstrates how to extract custom metadata properties from a spreadsheet.
    /// </summary>
    public static class SpreadsheetReadCustomProperties
    {
        public static void Run()
        {
            Console.WriteLine("\n--------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("[Example Advanced Usage] # SpreadsheetReadCustomProperties : How to extract custom metadata properties from a spreadsheet.\n");
            using (Metadata metadata = new Metadata(Constants.InputXls))
            {
                var root = metadata.GetRootPackage<SpreadsheetRootPackage>();

                var customProperties = root.DocumentProperties.FindProperties(p => !p.Tags.Contains(Tags.Document.BuiltIn));

                foreach (var property in customProperties)
                {
                    Console.WriteLine("{0} = {1}", property.Name, property.Value);
                }

                // Extract only content type properties if required
                foreach (var contentTypeProperty in root.DocumentProperties.ContentTypeProperties.ToList())
                {
                    Console.WriteLine("{0}, {1} = {2}", contentTypeProperty.SpreadsheetPropertyType, contentTypeProperty.Name, contentTypeProperty.SpreadsheetPropertyValue);
                }
            }
        }
    }
}
