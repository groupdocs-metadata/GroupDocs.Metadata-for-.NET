// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2023 GroupDocs. All Rights Reserved.
// </copyright>

namespace GroupDocs.Metadata.Examples.CSharp.AdvancedUsage.ManagingMetadataForSpecificFormats.Document.ProjectManagement
{
    using System;
    using Formats.Document;

    /// <summary>
    /// This code sample demonstrates how to update built-in properties in a ProjectManagement document.
    /// </summary>
    public static class ProjectManagementUpdateBuiltInProperties
    {
        public static void Run()
        {
            using (Metadata metadata = new Metadata(Constants.InputMpp))
            {
                var root = metadata.GetRootPackage<ProjectManagementRootPackage>();

                root.DocumentProperties.Author = "test author";
                root.DocumentProperties.CreationDate = DateTime.Now;
                root.DocumentProperties.Company = "GroupDocs";
                root.DocumentProperties.Comments = "test comment";
                root.DocumentProperties.Keywords = "metadata, built-in, update";

                // ... 

                metadata.Save(Constants.OutputMpp);
            }
        }
    }
}
