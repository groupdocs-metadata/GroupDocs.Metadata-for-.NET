// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2019 GroupDocs. All Rights Reserved.
// </copyright>

namespace GroupDocs.Metadata.Examples.CSharp.AdvancedUsage.ManagingMetadataForSpecificFormats.Document.Diagram
{
    using System;
    using Formats.Document;

    /// <summary>
    /// This code sample demonstrates how to extract built-in metadata properties from a diagram.
    /// </summary>
    public static class DiagramReadBuiltInProperties
    {
        public static void Run()
        {
            using (Metadata metadata = new Metadata(Constants.InputVsdx))
            {
                var root = metadata.GetRootPackage<DiagramRootPackage>();

                Console.WriteLine(root.DocumentProperties.Creator);
                Console.WriteLine(root.DocumentProperties.Company);
                Console.WriteLine(root.DocumentProperties.Keywords);
                Console.WriteLine(root.DocumentProperties.Language);
                Console.WriteLine(root.DocumentProperties.TimeCreated);
                Console.WriteLine(root.DocumentProperties.Category);

                // ... 
            }
        }
    }
}
