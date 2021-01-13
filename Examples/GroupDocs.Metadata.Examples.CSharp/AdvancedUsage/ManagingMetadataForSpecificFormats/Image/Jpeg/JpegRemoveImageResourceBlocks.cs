// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2021 GroupDocs. All Rights Reserved.
// </copyright>

namespace GroupDocs.Metadata.Examples.CSharp.AdvancedUsage.ManagingMetadataForSpecificFormats.Image.Jpeg
{
    using Formats.Image;

    /// <summary>
    /// This code snippet demonstrates how to remove Photoshop metadata from a JPEG image.
    /// </summary>
    public static class JpegRemoveImageResourceBlocks
    {
        public static void Run()
        {
            using (Metadata metadata = new Metadata(Constants.JpegWithIrb))
            {
                var root = metadata.GetRootPackage<JpegRootPackage>();
                root.RemoveImageResourcePackage();

                metadata.Save(Constants.OutputJpeg);
            }
        }
    }
}
