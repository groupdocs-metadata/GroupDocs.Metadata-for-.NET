// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2021 GroupDocs. All Rights Reserved.
// </copyright>

namespace GroupDocs.Metadata.Examples.CSharp.AdvancedUsage.WorkingWithMetadataStandards.Exif
{
    using Formats.Image;
    using Standards.Exif;

    public static class SetCustomExifTag
    {
        /// <summary>
        /// This code sample demonstrates how to add a custom tag to an EXIF package.
        /// </summary>
        public static void Run()
        {
            using (Metadata metadata = new Metadata(Constants.TiffWithExif))
            {
                IExif root = metadata.GetRootPackage() as IExif;
                if (root != null)
                {
                    // Set the EXIF package if it's missing
                    if (root.ExifPackage == null)
                    {
                        root.ExifPackage = new ExifPackage();
                    }

                    // Add a known property
                    root.ExifPackage.Set(new TiffAsciiTag(TiffTagID.Artist, "test artist"));

                    // Add a fully custom property (which is not described in the EXIF specification).
                    // Please note that the chosen ID may intersect with the IDs used by some third party tools.
                    root.ExifPackage.Set(new TiffAsciiTag((TiffTagID)65523, "custom"));

                    metadata.Save(Constants.OutputTiff);
                }
            }
        }
    }
}
