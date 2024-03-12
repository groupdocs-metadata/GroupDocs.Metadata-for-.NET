// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2024 GroupDocs. All Rights Reserved.
// </copyright>

using GroupDocs.Metadata.Common;
using GroupDocs.Metadata.Options;

namespace GroupDocs.Metadata.Examples.CSharp.AdvancedUsage.ManagingMetadataForSpecificFormats.Archive
{
    using Formats.Archive;
    using System;
    using System.Text;

    /// <summary>
    /// The following code snippet shows how to get metadata from a SevenZip archive.
    /// </summary>
    public static class SevenZipReadNativeMetadataProperties
    {
        public static void Run()
        {
            Console.WriteLine("\n--------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("[Example Advanced Usage] # SevenZipReadNativeMetadataProperties : How to get metadata from a SevenZip archive.\n");
            using (Metadata metadata = new Metadata(Constants.InputSevenZip))
            {
                var root = metadata.GetRootPackage<SevenZipRootPackage>();
                Console.WriteLine(root.SevenZipPackage.TotalEntries);

                foreach (var file in root.SevenZipPackage.Files)
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
