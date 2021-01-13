// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2021 GroupDocs. All Rights Reserved.
// </copyright>

namespace GroupDocs.Metadata.Examples.CSharp.AdvancedUsage.ManagingMetadataForSpecificFormats.Image.Psd
{
    using System;
    using Formats.Image;

    /// <summary>
    /// This code sample demonstrates how to extract basic EXIF metadata properties from a PSD image.
    /// </summary>
    public class PsdReadBasicExifProperties
    {
        public static void Run()
        {
            using (Metadata metadata = new Metadata(Constants.PsdWithExif))
            {
                var root = metadata.GetRootPackage<PsdRootPackage>();
                if (root.ExifPackage != null)
                {
                    Console.WriteLine(root.ExifPackage.Artist);
                    Console.WriteLine(root.ExifPackage.Copyright);
                    Console.WriteLine(root.ExifPackage.ImageDescription);
                    Console.WriteLine(root.ExifPackage.Make);
                    Console.WriteLine(root.ExifPackage.Model);
                    Console.WriteLine(root.ExifPackage.Software);
                    Console.WriteLine(root.ExifPackage.ImageWidth);
                    Console.WriteLine(root.ExifPackage.ImageLength);

                    // ...

                    Console.WriteLine(root.ExifPackage.ExifIfdPackage.BodySerialNumber);
                    Console.WriteLine(root.ExifPackage.ExifIfdPackage.CameraOwnerName);
                    Console.WriteLine(root.ExifPackage.ExifIfdPackage.UserComment);

                    // ...

                    Console.WriteLine(root.ExifPackage.GpsPackage.Altitude);
                    Console.WriteLine(root.ExifPackage.GpsPackage.LatitudeRef);
                    Console.WriteLine(root.ExifPackage.GpsPackage.LongitudeRef);

                    // ...
                }
            }
        }
    }
}
