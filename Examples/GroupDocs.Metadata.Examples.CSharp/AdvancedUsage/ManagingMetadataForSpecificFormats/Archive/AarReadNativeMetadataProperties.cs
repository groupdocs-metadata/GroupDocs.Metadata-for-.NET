// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2026 GroupDocs. All Rights Reserved.
// </copyright>

namespace GroupDocs.Metadata.Examples.CSharp.AdvancedUsage.ManagingMetadataForSpecificFormats.Archive
{
    using Formats.Archive;
    using System;

    /// <summary>
    /// The following code snippet shows how to get metadata from an Apple Archive (.aar) file.
    /// </summary>
    public static class AarReadNativeMetadataProperties
    {
        public static void Run()
        {
            Console.WriteLine("\n--------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("[Example Advanced Usage] # AarReadNativeMetadataProperties : How to get metadata from an Apple Archive.\n");

            using (Metadata metadata = new Metadata(Constants.InputAar))
            {
                var root = metadata.GetRootPackage<AarRootPackage>();
                var package = root.AarPackage;

                Console.WriteLine(package.TotalEntries);
                Console.WriteLine(package.IsSolid);

                foreach (var file in package.Files)
                {
                    Console.WriteLine(file.Name);
                    Console.WriteLine(file.Length);
                    Console.WriteLine(file.IsDirectory);
                }
            }
        }
    }
}
