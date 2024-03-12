// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2024 GroupDocs. All Rights Reserved.
// </copyright>

namespace GroupDocs.Metadata.Examples.CSharp.AdvancedUsage.ManagingMetadataForSpecificFormats.Image.Jpeg.MakerNote
{
    using System;
    using Formats.Image;
    using Standards.Exif.MakerNote;

    /// <summary>
    /// This code sample shows how to extract Canon MakerNote properties.
    /// </summary>
    public class MakerNoteReadCanonProperties
    {
        public static void Run()
        {
            Console.WriteLine("\n--------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("[Example Advanced Usage] # MakerNoteReadCanonProperties : How to extract Canon MakerNote properties.\n");
            using (Metadata metadata = new Metadata(Constants.CanonJpeg))
            {
                var root = metadata.GetRootPackage<JpegRootPackage>();

                var makerNote = (CanonMakerNotePackage)root.MakerNotePackage;
                if (makerNote != null)
                {
                    Console.WriteLine(makerNote.CanonFirmwareVersion);
                    Console.WriteLine(makerNote.CanonImageType);
                    Console.WriteLine(makerNote.OwnerName);
                    Console.WriteLine(makerNote.CanonModelID);

                    // ...

                    if (makerNote.CameraSettings != null)
                    {
                        Console.WriteLine(makerNote.CameraSettings.AFPoint);
                        Console.WriteLine(makerNote.CameraSettings.CameraIso);
                        Console.WriteLine(makerNote.CameraSettings.Contrast);
                        Console.WriteLine(makerNote.CameraSettings.DigitalZoom);

                        // ...
                    }
                }
            }
        }
    }
}
