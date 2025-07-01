// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2025 GroupDocs. All Rights Reserved.
// </copyright>

using GroupDocs.Metadata.Formats.ThreeD.Gltf;

namespace GroupDocs.Metadata.Examples.CSharp.AdvancedUsage.ManagingMetadataForSpecificFormats.ThreeD
{
    using System;

    /// <summary>
    /// The following code snippet shows how to get metadata from a Gltf file.
    /// </summary>
    public static class GltfReadNativeMetadataProperties
    {
        public static void Run()
        {
            Console.WriteLine("\n--------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("[Example Advanced Usage] #GltfReadNativeMetadataProperties : How to get metadata from a Gltf file.\n");
            using (Metadata metadata = new Metadata(Constants.InputGltf))
            {
                var root = metadata.GetRootPackage<GltfRootPackage>();
                foreach (var table in root.GltfPackage.PropertyTables)
                {
                    Console.WriteLine(table.PropertyTableName);
                    if (table.Properties != null)
                    {
                        foreach (var prop in table.Properties)
                        {
                            Console.WriteLine(prop.PropertyName);
                            Console.WriteLine(prop.PropertyType);
                            Console.WriteLine(prop.PropertyValue);
                        }
                    }
                }
            }
        }
    }
}
