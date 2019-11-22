// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2019 GroupDocs. All Rights Reserved.
// </copyright>

namespace GroupDocs.Metadata.Examples.CSharp.AdvancedUsage.ManagingMetadataForSpecificFormats.Document.Presentation
{
    using Formats.Document;

    /// <summary>
    /// This code sample demonstrates how to add or update custom metadata properties in a presentation.
    /// </summary>
    public static class PresentationUpdateCustomProperties
    {
        public static void Run()
        {
            using (Metadata metadata = new Metadata(Constants.InputPpt))
            {
                var root = metadata.GetRootPackage<PresentationRootPackage>();

                root.DocumentProperties.Set("customProperty1", "some value");
                root.DocumentProperties.Set("customProperty2", 123.1);

                metadata.Save(Constants.OutputPpt);
            }
        }
    }
}
