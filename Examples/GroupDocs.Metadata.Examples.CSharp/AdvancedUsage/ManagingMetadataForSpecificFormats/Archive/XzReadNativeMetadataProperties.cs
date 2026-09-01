// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2026 GroupDocs. All Rights Reserved.
// </copyright>

namespace GroupDocs.Metadata.Examples.CSharp.AdvancedUsage.ManagingMetadataForSpecificFormats.Archive
{
    using Formats.Archive;
    using System;

    /// <summary>
    /// The following code snippet shows how to get metadata from an XZ archive.
    /// </summary>
    public static class XzReadNativeMetadataProperties
    {
        public static void Run()
        {
            Console.WriteLine("\n--------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("[Example Advanced Usage] # XzReadNativeMetadataProperties : How to get metadata from an XZ archive.\n");

            using (Metadata metadata = new Metadata(Constants.InputXz))
            {
                var root = metadata.GetRootPackage<XzRootPackage>();
                var package = root.XzPackage;

                Console.WriteLine(package.TotalEntries);
                Console.WriteLine(package.Name);
                Console.WriteLine(package.Size);
            }
        }
    }
}
