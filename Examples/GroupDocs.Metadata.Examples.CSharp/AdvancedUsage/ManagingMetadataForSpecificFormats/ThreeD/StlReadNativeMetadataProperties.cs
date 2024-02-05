// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2023 GroupDocs. All Rights Reserved.
// </copyright>

using GroupDocs.Metadata.Formats.ThreeD.Stl;

namespace GroupDocs.Metadata.Examples.CSharp.AdvancedUsage.ManagingMetadataForSpecificFormats.ThreeD
{
    using System;

    /// <summary>
    /// The following code snippet shows how to get metadata from a Stl file.
    /// </summary>
    public static class StlReadNativeMetadataProperties
    {
        public static void Run()
        {
            using (Metadata metadata = new Metadata(Constants.InputStl))
            {
                var root = metadata.GetRootPackage<StlRootPackage>();
                foreach (var node in root.StlPackage.Nodes)
                {
                    Console.WriteLine(node.Name);
                }
            }
        }
    }
}
