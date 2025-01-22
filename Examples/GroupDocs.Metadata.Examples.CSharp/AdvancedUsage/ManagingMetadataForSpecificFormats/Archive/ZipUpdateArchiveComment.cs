// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2025 GroupDocs. All Rights Reserved.
// </copyright>

namespace GroupDocs.Metadata.Examples.CSharp.AdvancedUsage.ManagingMetadataForSpecificFormats.Archive
{
    using Formats.Archive;
    using System;

    /// <summary>
    /// The following code snippet shows how to update the user comment in a ZIP archive.
    /// </summary>
    public static class ZipUpdateArchiveComment
    {
        public static void Run()
        {
            Console.WriteLine("\n--------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("[Example Advanced Usage] # ZipUpdateArchiveComment : How to update the user comment in a ZIP archive.\n");
            using (Metadata metadata = new Metadata(Constants.InputZip))
            {
                var root = metadata.GetRootPackage<ZipRootPackage>();

                root.ZipPackage.Comment = "updated comment";

                metadata.Save(Constants.OutputZip);
            }
        }
    }
}
