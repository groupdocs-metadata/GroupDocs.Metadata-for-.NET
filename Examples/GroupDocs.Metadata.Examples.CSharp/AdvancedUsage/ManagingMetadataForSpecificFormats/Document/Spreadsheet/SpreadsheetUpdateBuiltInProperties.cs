// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2023 GroupDocs. All Rights Reserved.
// </copyright>

namespace GroupDocs.Metadata.Examples.CSharp.AdvancedUsage.ManagingMetadataForSpecificFormats.Document.Spreadsheet
{
    using System;
    using Formats.Document;


    /// <summary>
    /// This example shows how to update built-in metadata properties in a spreadsheet.
    /// </summary>
    public static class SpreadsheetUpdateBuiltInProperties
    {
        public static void Run()
        {
            using (Metadata metadata = new Metadata(Constants.InputXlsx))
            {
                var root = metadata.GetRootPackage<SpreadsheetRootPackage>();

                root.DocumentProperties.Author = "test author";
                root.DocumentProperties.CreatedTime = DateTime.Now;
                root.DocumentProperties.Company = "GroupDocs";
                root.DocumentProperties.Category = "test category";
                root.DocumentProperties.Keywords = "metadata, built-in, update";

                // ... 

                metadata.Save(Constants.OutputXlsx);
            }
        }
    }
}
