// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2025 GroupDocs. All Rights Reserved.
// </copyright>

namespace GroupDocs.Metadata.Examples.CSharp.AdvancedUsage.WorkingWithMetadataStandards.Exif
{
    using Standards.Exif;
    using System;

    /// <summary>
    /// This code sample demonstrates how to update common EXIF properties.
    /// </summary>
    public static class UpdateExifProperties
    {
        public static void Run()
        {
            Console.WriteLine("\n--------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("[Example Advanced Usage] # UpdateExifProperties : How to update common EXIF properties.\n");
            using (Metadata metadata = new Metadata(Constants.InputJpeg))
            {
                IExif root = metadata.GetRootPackage() as IExif;
                if (root != null)
                {
                    // Set the EXIF package if it's missing
                    if (root.ExifPackage == null)
                    {
                        root.ExifPackage = new ExifPackage();
                    }

                    root.ExifPackage.Copyright = "Copyright (C) 2011-2025 GroupDocs. All Rights Reserved.";
                    root.ExifPackage.ImageDescription = "test image";
                    root.ExifPackage.Software = "GroupDocs.Metadata";

                    // ...

                    root.ExifPackage.ExifIfdPackage.BodySerialNumber = "test";
                    root.ExifPackage.ExifIfdPackage.CameraOwnerName = "GroupDocs";
                    root.ExifPackage.ExifIfdPackage.UserComment = "test comment";

                    // ...

                    metadata.Save(Constants.OutputJpeg);
                }
            }
        }
    }
}
