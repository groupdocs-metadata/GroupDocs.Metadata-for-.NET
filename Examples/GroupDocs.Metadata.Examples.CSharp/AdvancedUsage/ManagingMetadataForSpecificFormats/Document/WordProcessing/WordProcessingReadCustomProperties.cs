// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2023 GroupDocs. All Rights Reserved.
// </copyright>

namespace GroupDocs.Metadata.Examples.CSharp.AdvancedUsage.ManagingMetadataForSpecificFormats.Document.WordProcessing
{
    using System;
    using Formats.Document;
    using Tagging;

    /// <summary>
    /// This example demonstrates how to read custom metadata properties of a WordProcessing document.
    /// </summary>
    public static class WordProcessingReadCustomProperties
    {
        public static void Run()
        {
            using (Metadata metadata = new Metadata(Constants.InputDoc))
            {
                var root = metadata.GetRootPackage<WordProcessingRootPackage>();

                var customProperties = root.DocumentProperties.FindProperties(p => !p.Tags.Contains(Tags.Document.BuiltIn));

                foreach (var property in customProperties)
                {
                    Console.WriteLine("{0} = {1}", property.Name, property.Value);
                }
            }
        }
    }
}
