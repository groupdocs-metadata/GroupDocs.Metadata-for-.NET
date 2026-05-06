// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2026 GroupDocs. All Rights Reserved.
// </copyright>

namespace GroupDocs.Metadata.Examples.CSharp.AdvancedUsage.ManagingMetadataForSpecificFormats.Image.Tiff
{
    using System;
    using Standards.Exif;

    /// <summary>
    /// This code sample demonstrates how to update EXIF metadata properties in a TIFF image.
    /// </summary>
    public static class TiffUpdateExifProperties
    {
        public static void Run()
        {
            Console.WriteLine("\n--------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("[Example Advanced Usage] # TiffUpdateExifProperties : How to update EXIF metadata properties in a TIFF image.\n");
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

                    root.ExifPackage.Copyright = "Copyright (C) 2011-2026 GroupDocs. All Rights Reserved.";
                    root.ExifPackage.ImageDescription = "test TIFF image";
                    root.ExifPackage.Software = "GroupDocs.Metadata";
                    root.ExifPackage.Artist = "GroupDocs";

                    // ...

                    root.ExifPackage.ExifIfdPackage.BodySerialNumber = "test";
                    root.ExifPackage.ExifIfdPackage.CameraOwnerName = "GroupDocs";
                    root.ExifPackage.ExifIfdPackage.UserComment = "test comment";

                    // ...

                    metadata.Save(Constants.OutputTiff);
                }
            }
        }
    }
}
