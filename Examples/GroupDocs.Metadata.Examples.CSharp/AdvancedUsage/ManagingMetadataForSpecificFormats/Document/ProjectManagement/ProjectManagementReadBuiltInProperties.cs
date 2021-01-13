// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2021 GroupDocs. All Rights Reserved.
// </copyright>

namespace GroupDocs.Metadata.Examples.CSharp.AdvancedUsage.ManagingMetadataForSpecificFormats.Document.ProjectManagement
{
    using System;
    using Formats.Document;

    /// <summary>
    /// This code sample demonstrates how to extract built-in properties of a ProjectManagement document.
    /// </summary>
    public static class ProjectManagementReadBuiltInProperties
    {
        public static void Run()
        {
            using (Metadata metadata = new Metadata(Constants.InputMpp))
            {
                var root = metadata.GetRootPackage<ProjectManagementRootPackage>();

                Console.WriteLine(root.DocumentProperties.Author);
                Console.WriteLine(root.DocumentProperties.CreationDate);
                Console.WriteLine(root.DocumentProperties.Company);
                Console.WriteLine(root.DocumentProperties.Category);
                Console.WriteLine(root.DocumentProperties.Keywords);
                Console.WriteLine(root.DocumentProperties.Revision);
                Console.WriteLine(root.DocumentProperties.Subject);

                // ... 
            }
        }
    }
}
