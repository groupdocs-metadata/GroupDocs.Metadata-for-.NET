// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2025 GroupDocs. All Rights Reserved.
// </copyright>

namespace GroupDocs.Metadata.Examples.CSharp.AdvancedUsage.ManagingMetadataForSpecificFormats.Archive
{
    using Formats.Archive;
    using System;
    using System.Text;

    /// <summary>
    /// The following code snippet shows how to get metadata from a Tar archive.
    /// </summary>
    public static class TarReadNativeMetadataProperties
    {
        public static void Run()
        {
            Console.WriteLine("\n--------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("[Example Advanced Usage] # TarReadNativeMetadataProperties : How to get metadata from a Tar archive.\n");
            using (Metadata metadata = new Metadata(Constants.InputTar))
            {
                var root = metadata.GetRootPackage<TarRootPackage>();

                Console.WriteLine(root.TarPackage.TotalEntries);

                foreach (var file in root.TarPackage.Files)
                {
                    Console.WriteLine(file.Name);
                    Console.WriteLine(file.Size);

                }
            }
        }
    }
}
