// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2023 GroupDocs. All Rights Reserved.
// </copyright>

namespace GroupDocs.Metadata.Examples.CSharp.AdvancedUsage.ManagingMetadataForSpecificFormats.Document.Diagram
{
    using System;
    using Formats.Document;
    using Tagging;

    /// <summary>
    /// This code sample demonstrates how to extract custom metadata properties from a diagram.
    /// </summary>
    public static class DiagramReadCustomProperties
    {
        public static void Run()
        {
            using (Metadata metadata = new Metadata(Constants.InputVsdx))
            {
                var root = metadata.GetRootPackage<DiagramRootPackage>();

                var customProperties = root.DocumentProperties.FindProperties(p => !p.Tags.Contains(Tags.Document.BuiltIn));

                foreach (var property in customProperties)
                {
                    Console.WriteLine("{0} = {1}", property.Name, property.Value);
                }
            }
        }
    }
}
