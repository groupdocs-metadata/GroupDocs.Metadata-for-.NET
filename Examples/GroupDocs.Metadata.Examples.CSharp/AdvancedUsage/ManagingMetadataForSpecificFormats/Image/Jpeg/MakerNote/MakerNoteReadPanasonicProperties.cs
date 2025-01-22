// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2025 GroupDocs. All Rights Reserved.
// </copyright>

namespace GroupDocs.Metadata.Examples.CSharp.AdvancedUsage.ManagingMetadataForSpecificFormats.Image.Jpeg.MakerNote
{
    using Formats.Image;
    using Standards.Exif.MakerNote;
    using System;

    /// <summary>
    /// This code sample shows how to extract Panasonic MakerNote properties.
    /// </summary>
    public class MakerNoteReadPanasonicProperties
    {
        public static void Run()
        {
            Console.WriteLine("\n--------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("[Example Advanced Usage] # MakerNoteReadPanasonicProperties : How to extract Panasonic MakerNote properties.\n");
            using (Metadata metadata = new Metadata(Constants.PanasonicJpeg))
            {
                var root = metadata.GetRootPackage<JpegRootPackage>();

                var makerNote = (PanasonicMakerNotePackage)root.MakerNotePackage;
                if (makerNote != null)
                {
                    Console.WriteLine(makerNote.AccessorySerialNumber);
                    Console.WriteLine(makerNote.AccessoryType);
                    Console.WriteLine(makerNote.MacroMode);
                    Console.WriteLine(makerNote.LensSerialNumber);
                    Console.WriteLine(makerNote.LensType);

                    // ...
                }
            }
        }
    }
}
