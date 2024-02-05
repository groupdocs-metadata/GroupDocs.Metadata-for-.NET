// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2023 GroupDocs. All Rights Reserved.
// </copyright>

using GroupDocs.Metadata.Formats.ThreeD.Fbx;

namespace GroupDocs.Metadata.Examples.CSharp.AdvancedUsage.ManagingMetadataForSpecificFormats.ThreeD
{
    using System;

    /// <summary>
    /// The following code snippet shows how to get metadata from a Fbx file.
    /// </summary>
    public static class FbxReadNativeMetadataProperties
    {
        public static void Run()
        {
            using (Metadata metadata = new Metadata(Constants.InputFbx))
            {
                var root = metadata.GetRootPackage<FbxRootPackage>();
                Console.WriteLine(root.FbxPackage.Author);
                Console.WriteLine(root.FbxPackage.Comment);
                Console.WriteLine(root.FbxPackage.ApplicationName);
                Console.WriteLine(root.FbxPackage.ApplicationVendor);
                Console.WriteLine(root.FbxPackage.Name);
                Console.WriteLine(root.FbxPackage.ApplicationVersion);
                Console.WriteLine(root.FbxPackage.Url);
                foreach (var node in root.FbxPackage.Nodes)
                {
                    Console.WriteLine(node.Name);
                }
            }
        }
    }
}
