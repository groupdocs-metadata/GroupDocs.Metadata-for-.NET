// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2019 GroupDocs. All Rights Reserved.
// </copyright>

namespace GroupDocs.Metadata.Examples.CSharp.AdvancedUsage.ManagingMetadataForSpecificFormats.Document.Presentation
{
    using System;
    using Formats.Document;
    using Tagging;

    /// <summary>
    /// This example shows how to extract custom metadata properties from a presentation.
    /// </summary>
    public static class PresentationReadCustomProperties
    {
        public static void Run()
        {
            using (Metadata metadata = new Metadata(Constants.InputPptx))
            {
                var root = metadata.GetRootPackage<PresentationRootPackage>();

                var customProperties = root.DocumentProperties.FindProperties(p => !p.Tags.Contains(Tags.Document.BuiltIn));

                foreach (var property in customProperties)
                {
                    Console.WriteLine("{0} = {1}", property.Name, property.Value);
                }
            }
        }
    }
}
