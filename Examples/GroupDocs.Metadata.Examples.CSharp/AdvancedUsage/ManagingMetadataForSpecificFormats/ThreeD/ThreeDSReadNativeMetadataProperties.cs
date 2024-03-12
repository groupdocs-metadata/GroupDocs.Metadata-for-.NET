// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2024 GroupDocs. All Rights Reserved.
// </copyright>

using GroupDocs.Metadata.Formats.ThreeD.ThreeDS;

namespace GroupDocs.Metadata.Examples.CSharp.AdvancedUsage.ManagingMetadataForSpecificFormats.ThreeD
{
    using System;

    /// <summary>
    /// The following code snippet shows how to get metadata from a ThreeDS file.
    /// </summary>
    public static class ThreeDSReadNativeMetadataProperties
    {
        public static void Run()
        {
            Console.WriteLine("\n--------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("[Example Advanced Usage] # ThreeDSReadNativeMetadataProperties : How to get metadata from a ThreeDS file.\n");
            using (Metadata metadata = new Metadata(Constants.Input3ds))
            {
                var root = metadata.GetRootPackage<ThreeDSRootPackage>();
                foreach (var material in root.ThreeDSPackage.Materials)
                {
                    Console.WriteLine(material);
                }
                foreach (var node in root.ThreeDSPackage.Nodes)
                {
                    Console.WriteLine(node.Name);
                    foreach (var material in node.Materials)
                    {
                        Console.WriteLine(material);
                    }
                }
            }
        }
    }
}
