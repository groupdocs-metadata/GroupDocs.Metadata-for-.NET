// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2023 GroupDocs. All Rights Reserved.
// </copyright>

namespace GroupDocs.Metadata.Examples.CSharp.AdvancedUsage.ManagingMetadataForSpecificFormats.Document.Presentation
{
    using System;
    using Formats.Document;

    /// <summary>
    /// This example demonstrates how to detect the exact type of a presentation and extract some additional file format information.
    /// </summary>
    public static class PresentationReadFileFormatProperties
    {
        public static void Run()
        {
            using (Metadata metadata = new Metadata(Constants.InputPptx))
            {
                var root = metadata.GetRootPackage<PresentationRootPackage>();

                Console.WriteLine(root.FileType.FileFormat);
                Console.WriteLine(root.FileType.PresentationFormat);
                Console.WriteLine(root.FileType.MimeType);
                Console.WriteLine(root.FileType.Extension);
            }
        }
    }
}
