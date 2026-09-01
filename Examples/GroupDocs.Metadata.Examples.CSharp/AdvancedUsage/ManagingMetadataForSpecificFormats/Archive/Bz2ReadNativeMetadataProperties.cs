// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2026 GroupDocs. All Rights Reserved.
// </copyright>

namespace GroupDocs.Metadata.Examples.CSharp.AdvancedUsage.ManagingMetadataForSpecificFormats.Archive
{
    using Formats.Archive;
    using System;

    /// <summary>
    /// The following code snippet shows how to get metadata from a BZ2 archive.
    /// </summary>
    public static class Bz2ReadNativeMetadataProperties
    {
        public static void Run()
        {
            Console.WriteLine("\n--------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("[Example Advanced Usage] # Bz2ReadNativeMetadataProperties : How to get metadata from a BZ2 archive.\n");

            using (Metadata metadata = new Metadata(Constants.InputBz2))
            {
                var root = metadata.GetRootPackage<Bz2RootPackage>();
                var package = root.Bz2Package;

                Console.WriteLine(package.TotalEntries);
                Console.WriteLine(package.Name);
                Console.WriteLine(package.Size);
            }
        }
    }
}
