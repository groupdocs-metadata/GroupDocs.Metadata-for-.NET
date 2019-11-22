// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2019 GroupDocs. All Rights Reserved.
// </copyright>

namespace GroupDocs.Metadata.Examples.CSharp.AdvancedUsage.ManagingMetadataForSpecificFormats.Document.Pdf
{
    using System;
    using Formats.Document;
    using Tagging;

    /// <summary>
    /// This code sample shows how to extract custom metadata properties from a PDF document.
    /// </summary>
    public static class PdfReadCustomProperties
    {
        public static void Run()
        {
            using (Metadata metadata = new Metadata(Constants.InputPdf))
            {
                var root = metadata.GetRootPackage<PdfRootPackage>();

                var customProperties = root.DocumentProperties.FindProperties(p => !p.Tags.Contains(Tags.Document.BuiltIn));

                foreach (var property in customProperties)
                {
                    Console.WriteLine("{0} = {1}", property.Name, property.Value);
                }
            }
        }
    }
}
