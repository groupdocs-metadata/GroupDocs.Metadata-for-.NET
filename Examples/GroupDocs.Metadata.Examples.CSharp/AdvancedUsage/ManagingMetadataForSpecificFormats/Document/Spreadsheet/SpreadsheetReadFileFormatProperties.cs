// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2019 GroupDocs. All Rights Reserved.
// </copyright>

namespace GroupDocs.Metadata.Examples.CSharp.AdvancedUsage.ManagingMetadataForSpecificFormats.Document.Spreadsheet
{
    using System;
    using Formats.Document;

    /// <summary>
    /// This example shows how to detect the exact type of a loaded spreadsheet and extract some additional file format information.
    /// </summary>
    public static class SpreadsheetReadFileFormatProperties
    {
        public static void Run()
        {
            using (Metadata metadata = new Metadata(Constants.InputXlsx))
            {
                var root = metadata.GetRootPackage<SpreadsheetRootPackage>();

                Console.WriteLine(root.FileType.FileFormat);
                Console.WriteLine(root.FileType.SpreadsheetFormat);
                Console.WriteLine(root.FileType.MimeType);
                Console.WriteLine(root.FileType.Extension);
            }
        }
    }
}
