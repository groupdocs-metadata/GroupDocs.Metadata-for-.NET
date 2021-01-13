// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2021 GroupDocs. All Rights Reserved.
// </copyright>

namespace GroupDocs.Metadata.Examples.CSharp.AdvancedUsage.ManagingMetadataForSpecificFormats.Document.ProjectManagement
{
    using GroupDocs.Metadata.Formats.Document;
    using System;

    /// <summary>
    /// This code sample shows how to update custom metadata properties in a ProjectManagement document.
    /// </summary>
    public static class ProjectManagementUpdateCustomProperties
    {
        public static void Run()
        {
            using (Metadata metadata = new Metadata(Constants.InputMpp))
            {
                var root = metadata.GetRootPackage<ProjectManagementRootPackage>();

                root.DocumentProperties.Set("customProperty1", "some value");
                root.DocumentProperties.Set("customProperty2", 7);
                root.DocumentProperties.Set("customProperty3", true);

                // ...

                metadata.Save(Constants.OutputMpp);
            }
        }
    }
}
