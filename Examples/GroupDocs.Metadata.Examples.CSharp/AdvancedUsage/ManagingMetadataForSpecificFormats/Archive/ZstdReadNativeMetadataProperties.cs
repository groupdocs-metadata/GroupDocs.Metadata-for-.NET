// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2026 GroupDocs. All Rights Reserved.
// </copyright>

namespace GroupDocs.Metadata.Examples.CSharp.AdvancedUsage.ManagingMetadataForSpecificFormats.Archive
{
    using Formats.Archive;
    using System;

    /// <summary>
    /// The following code snippet shows how to get metadata from a ZSTD archive.
    /// </summary>
    public static class ZstdReadNativeMetadataProperties
    {
        public static void Run()
        {
            Console.WriteLine("\n--------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("[Example Advanced Usage] # ZstdReadNativeMetadataProperties : How to get metadata from a ZSTD archive.\n");

            using (Metadata metadata = new Metadata(Constants.InputZstd))
            {
                var root = metadata.GetRootPackage<ZstdRootPackage>();
                var package = root.ZstdPackage;

                Console.WriteLine(package.TotalEntries);
                Console.WriteLine(package.Name);
                Console.WriteLine(package.Size);
            }
        }
    }
}
