// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2025 GroupDocs. All Rights Reserved.
// </copyright>

namespace GroupDocs.Metadata.Examples.CSharp.AdvancedUsage.ManagingMetadataForSpecificFormats.Document.Diagram
{
    using Formats.Document;
    using System;

    /// <summary>
    /// The following code sample demonstrates how to update custom metadata properties in a diagram document.
    /// </summary>
    public static class DiagramUpdateCustomProperties
    {
        public static void Run()
        {
            Console.WriteLine("\n--------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("[Example Advanced Usage] # DiagramUpdateCustomProperties : How to update custom metadata properties in a diagram document.\n");
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
