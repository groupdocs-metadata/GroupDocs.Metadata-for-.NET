// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2020 GroupDocs. All Rights Reserved.
// </copyright>

namespace GroupDocs.Metadata.Examples.CSharp.AdvancedUsage.ManagingMetadataForSpecificFormats.Archive
{
    using Formats.Archive;

    /// <summary>
    /// The following code snippet shows how to update the user comment in a ZIP archive.
    /// </summary>
    public static class ZipUpdateArchiveComment
    {
        public static void Run()
        {
            using (Metadata metadata = new Metadata(Constants.InputZip))
            {
                var root = metadata.GetRootPackage<ZipRootPackage>();

                root.ZipPackage.Comment = "updated comment";

                metadata.Save(Constants.OutputZip);
            }
        }
    }
}
