// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2019 GroupDocs. All Rights Reserved.
// </copyright>

namespace GroupDocs.Metadata.Examples.CSharp.AdvancedUsage.ManagingMetadataForSpecificFormats.Archive
{
    using Formats.Archive;
    using System;
    using System.Text;

    /// <summary>
    /// The following code snippet shows how to get metadata from a ZIP archive.
    /// </summary>
    public static class ZipReadNativeMetadataProperties
    {
        public static void Run()
        {
            Encoding encoding = Encoding.GetEncoding(866);

            using (Metadata metadata = new Metadata(Constants.InputZip))
            {
                var root = metadata.GetRootPackage<ZipRootPackage>();

                Console.WriteLine(root.ZipPackage.Comment);
                Console.WriteLine(root.ZipPackage.TotalEntries);

                foreach (var file in root.ZipPackage.Files)
                {
                    Console.WriteLine(file.Name);
                    Console.WriteLine(file.CompressedSize);
                    Console.WriteLine(file.CompressionMethod);
                    Console.WriteLine(file.Flags);
                    Console.WriteLine(file.ModificationDateTime);
                    Console.WriteLine(file.UncompressedSize);

                    // Use a specific encoding for the file names
                    Console.WriteLine(encoding.GetString(file.RawName));
                }
            }
        }
    }
}
