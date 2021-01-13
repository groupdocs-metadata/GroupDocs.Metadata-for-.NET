// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2021 GroupDocs. All Rights Reserved.
// </copyright>

namespace GroupDocs.Metadata.Examples.CSharp.AdvancedUsage.ManagingMetadataForSpecificFormats.Document.ProjectManagement
{
    using System;
    using GroupDocs.Metadata.Formats.Document;
    using GroupDocs.Metadata.Tagging;

    /// <summary>
    /// This example demonstrates how to read custom metadata properties of a ProjectManagement document.
    /// </summary>
    public static class ProjectManagementReadCustomProperties
    {
        public static void Run()
        {
            using (Metadata metadata = new Metadata(Constants.InputMpp))
            {
                var root = metadata.GetRootPackage<ProjectManagementRootPackage>();

                var customProperties = root.DocumentProperties.FindProperties(p => !p.Tags.Contains(Tags.Document.BuiltIn));

                foreach (var property in customProperties)
                {
                    Console.WriteLine("{0} = {1}", property.Name, property.Value);
                }
            }
        }
    }
}
