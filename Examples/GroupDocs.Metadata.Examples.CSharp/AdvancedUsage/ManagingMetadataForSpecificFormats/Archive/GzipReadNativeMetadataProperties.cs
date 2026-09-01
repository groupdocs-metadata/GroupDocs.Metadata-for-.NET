// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2026 GroupDocs. All Rights Reserved.
// </copyright>

namespace GroupDocs.Metadata.Examples.CSharp.AdvancedUsage.ManagingMetadataForSpecificFormats.Archive
{
    using Formats.Archive;
    using System;

    /// <summary>
    /// The following code snippet shows how to get metadata from a GZIP archive.
    /// </summary>
    public static class GzipReadNativeMetadataProperties
    {
        public static void Run()
        {
            Console.WriteLine("\n--------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("[Example Advanced Usage] # GzipReadNativeMetadataProperties : How to get metadata from a GZIP archive.\n");

            using (Metadata metadata = new Metadata(Constants.InputGzip))
            {
                var root = metadata.GetRootPackage<GzipRootPackage>();
                var package = root.GzipPackage;

                Console.WriteLine(package.TotalEntries);
                Console.WriteLine(package.Name);
                Console.WriteLine(package.UncompressedSize);
                Console.WriteLine(package.Size);
            }
        }
    }
}
