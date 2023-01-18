// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2023 GroupDocs. All Rights Reserved.
// </copyright>

namespace GroupDocs.Metadata.Examples.CSharp.AdvancedUsage.LoadingFiles
{
    using System;
    using Common;
    using Formats.Document;
    using Options;


    /// <summary>
    /// This example demonstrates how to load a file of some particular format.
    /// </summary>
    public static class LoadingFileOfSpecificFormat
    {
        public static void Run()
        {
            // Explicitly specifying the format of a file to load you can spare some time on detecting the format
            var loadOptions = new LoadOptions(FileFormat.Spreadsheet);

            // Constants.InputXls is an absolute or relative path to your document. Ex: @"C:\Docs\source.xls"
            using (Metadata metadata = new Metadata(Constants.InputXls, loadOptions))
            {
                var root = metadata.GetRootPackage<SpreadsheetRootPackage>();

                // Use format-specific properties to extract or edit metadata

                Console.WriteLine(root.DocumentProperties.Author);

                // ...
            }
        }
    }
}
