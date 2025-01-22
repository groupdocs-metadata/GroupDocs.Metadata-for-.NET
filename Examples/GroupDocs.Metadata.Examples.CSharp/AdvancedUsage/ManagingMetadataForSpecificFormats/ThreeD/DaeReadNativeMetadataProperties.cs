// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2025 GroupDocs. All Rights Reserved.
// </copyright>

using GroupDocs.Metadata.Formats.ThreeD.Dae;

namespace GroupDocs.Metadata.Examples.CSharp.AdvancedUsage.ManagingMetadataForSpecificFormats.ThreeD
{
    using System;

    /// <summary>
    /// The following code snippet shows how to get metadata from a Dae file.
    /// </summary>
    public static class DaeReadNativeMetadataProperties
    {
        public static void Run()
        {
            Console.WriteLine("\n--------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("[Example Advanced Usage] # DaeReadNativeMetadataProperties : How to get metadata from a Dae file.\n");
            using (Metadata metadata = new Metadata(Constants.InputDae))
            {
                var root = metadata.GetRootPackage<DaeRootPackage>();
                Console.WriteLine(root.DaePackage.Author);
                Console.WriteLine(root.DaePackage.Comment);
                Console.WriteLine(root.DaePackage.CreationTime);
                Console.WriteLine(root.DaePackage.ModificationTime);
                Console.WriteLine(root.DaePackage.Name);
                Console.WriteLine(root.DaePackage.Title);
                foreach (var node in root.DaePackage.Nodes)
                {
                    Console.WriteLine(node.Name);
                }
            }
        }
    }
}
