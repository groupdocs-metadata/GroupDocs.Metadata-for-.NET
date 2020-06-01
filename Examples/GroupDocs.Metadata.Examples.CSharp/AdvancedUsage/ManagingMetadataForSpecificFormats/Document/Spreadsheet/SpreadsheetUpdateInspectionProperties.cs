// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2020 GroupDocs. All Rights Reserved.
// </copyright>

namespace GroupDocs.Metadata.Examples.CSharp.AdvancedUsage.ManagingMetadataForSpecificFormats.Document.Spreadsheet
{
    using Formats.Document;

    /// <summary>
    /// This code sample shows hot to remove inspection properties from a spreadsheet.
    /// </summary>
    public static class SpreadsheetUpdateInspectionProperties
    {
        public static void Run()
        {
            using (Metadata metadata = new Metadata(Constants.InputXlsx))
            {
                var root = metadata.GetRootPackage<SpreadsheetRootPackage>();

                root.InspectionPackage.ClearComments();
                root.InspectionPackage.ClearDigitalSignatures();
                root.InspectionPackage.ClearHiddenSheets();

                metadata.Save(Constants.OutputXlsx);
            }
        }
    }
}
