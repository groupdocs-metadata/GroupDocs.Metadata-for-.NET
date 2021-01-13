// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2021 GroupDocs. All Rights Reserved.
// </copyright>

namespace GroupDocs.Metadata.Examples.CSharp.AdvancedUsage.ManagingMetadataForSpecificFormats.Document.Diagram
{
    using System;
    using Formats.Document;

    /// <summary>
    /// The following code sample demonstrates how to update built-in metadata properties in a diagram document.
    /// </summary>
    public static class DiagramUpdateBuiltInProperties
    {
        public static void Run()
        {
            using (Metadata metadata = new Metadata(Constants.InputVdx))
            {
                var root = metadata.GetRootPackage<DiagramRootPackage>();

                root.DocumentProperties.Creator = "test author";
                root.DocumentProperties.TimeCreated = DateTime.Now;
                root.DocumentProperties.Company = "GroupDocs";
                root.DocumentProperties.Category = "test category";
                root.DocumentProperties.Keywords = "metadata, built-in, update";

                // ... 

                metadata.Save(Constants.OutputVdx);
            }
        }
    }
}
