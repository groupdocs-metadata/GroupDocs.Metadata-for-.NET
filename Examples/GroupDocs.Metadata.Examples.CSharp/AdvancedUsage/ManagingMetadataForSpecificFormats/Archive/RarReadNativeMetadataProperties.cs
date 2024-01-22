// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2023 GroupDocs. All Rights Reserved.
// </copyright>

namespace GroupDocs.Metadata.Examples.CSharp.AdvancedUsage.ManagingMetadataForSpecificFormats.Archive
{
    using Formats.Archive;
    using System;
    using System.Text;

    /// <summary>
    /// The following code snippet shows how to get metadata from a Rar archive.
    /// </summary>
    public static class RarReadNativeMetadataProperties
    {
        public static void Run()
        {
            using (Metadata metadata = new Metadata(Constants.InputRar))
            {
                var root = metadata.GetRootPackage<RarRootPackage>();
                Console.WriteLine(root.RarPackage.TotalEntries);

                foreach (var file in root.RarPackage.Files)
                {
                    Console.WriteLine(file.Name);
                    Console.WriteLine(file.CompressedSize);
                    Console.WriteLine(file.ModificationDateTime);
                    Console.WriteLine(file.UncompressedSize);
                }
            }
        }
    }
}
