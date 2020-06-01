// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2020 GroupDocs. All Rights Reserved.
// </copyright>

namespace GroupDocs.Metadata.Examples.CSharp.AdvancedUsage.ManagingMetadataForSpecificFormats.Document.Presentation
{
    using System;
    using Formats.Document;

    /// <summary>
    /// This example shows how to extract built-in metadata properties from a presentation.
    /// </summary>
    public static class PresentationReadBuiltInProperties
    {
        public static void Run()
        {
            using (Metadata metadata = new Metadata(Constants.InputPpt))
            {
                var root = metadata.GetRootPackage<PresentationRootPackage>();

                Console.WriteLine(root.DocumentProperties.Author);
                Console.WriteLine(root.DocumentProperties.CreatedTime);
                Console.WriteLine(root.DocumentProperties.Company);
                Console.WriteLine(root.DocumentProperties.Category);
                Console.WriteLine(root.DocumentProperties.Keywords);
                Console.WriteLine(root.DocumentProperties.LastPrintedDate);
                Console.WriteLine(root.DocumentProperties.NameOfApplication);

                // ... 
            }
        }
    }
}
