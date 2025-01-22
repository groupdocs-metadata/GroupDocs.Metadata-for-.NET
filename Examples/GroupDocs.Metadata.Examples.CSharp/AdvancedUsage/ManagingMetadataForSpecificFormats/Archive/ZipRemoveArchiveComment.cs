// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2025 GroupDocs. All Rights Reserved.
// </copyright>

namespace GroupDocs.Metadata.Examples.CSharp.AdvancedUsage.ManagingMetadataForSpecificFormats.Archive
{
    using Formats.Archive;
    using System;

    /// <summary>
    /// The following code snippet shows how to remove the user comment from a ZIP archive.
    /// </summary>
    public static class ZipRemoveArchiveComment
    {
        public static void Run()
        {
            Console.WriteLine("\n--------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("[Example Advanced Usage] # ZipRemoveArchiveComment : How to remove the user comment from a ZIP archive.\n");
            using (Metadata metadata = new Metadata(Constants.InputZip))
            {
                var root = metadata.GetRootPackage<ZipRootPackage>();

                root.ZipPackage.Comment = null;

                metadata.Save(Constants.OutputZip);
            }
        }
    }
}
