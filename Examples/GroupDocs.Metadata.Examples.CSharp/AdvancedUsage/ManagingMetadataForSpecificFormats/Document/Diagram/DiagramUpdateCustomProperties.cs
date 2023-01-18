// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2023 GroupDocs. All Rights Reserved.
// </copyright>

namespace GroupDocs.Metadata.Examples.CSharp.AdvancedUsage.ManagingMetadataForSpecificFormats.Document.Diagram
{
    using Formats.Document;

    /// <summary>
    /// The following code sample demonstrates how to update custom metadata properties in a diagram document.
    /// </summary>
    public static class DiagramUpdateCustomProperties
    {
        public static void Run()
        {
            using (Metadata metadata = new Metadata(Constants.InputVsdx))
            {
                var root = metadata.GetRootPackage<DiagramRootPackage>();

                root.DocumentProperties.Set("customProperty1", "some value");
                root.DocumentProperties.Set("customProperty2", true);

                metadata.Save(Constants.OutputVsdx);
            }
        }
    }
}
