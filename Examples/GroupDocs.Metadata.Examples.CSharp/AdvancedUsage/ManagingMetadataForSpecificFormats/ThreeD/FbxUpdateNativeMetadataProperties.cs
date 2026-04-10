// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2026 GroupDocs. All Rights Reserved.
// </copyright>

using GroupDocs.Metadata.Formats.ThreeD.Fbx;

namespace GroupDocs.Metadata.Examples.CSharp.AdvancedUsage.ManagingMetadataForSpecificFormats.ThreeD
{
    using System;

    /// <summary>
    /// The following code snippet shows how to update metadata in a FBX file.
    /// </summary>
    public static class FbxUpdateNativeMetadataProperties
    {
        public static void Run()
        {
            Console.WriteLine("\n--------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("[Example Advanced Usage] # FbxUpdateNativeMetadataProperties : How to update metadata in a FBX file.\n");
            using (Metadata metadata = new Metadata(Constants.InputFbx))
            {
                var root = metadata.GetRootPackage<FbxRootPackage>();

                root.FbxPackage.Author = "GroupDocs";
                root.FbxPackage.Comment = "Updated by GroupDocs.Metadata";
                root.FbxPackage.Url = "https://www.groupdocs.com";
                root.FbxPackage.ApplicationName = "GroupDocs.Metadata";
                root.FbxPackage.ApplicationVendor = "GroupDocs";
                root.FbxPackage.ApplicationVersion = "26.3";

                // ...

                metadata.Save(Constants.OutputFbx);
            }
        }
    }
}
