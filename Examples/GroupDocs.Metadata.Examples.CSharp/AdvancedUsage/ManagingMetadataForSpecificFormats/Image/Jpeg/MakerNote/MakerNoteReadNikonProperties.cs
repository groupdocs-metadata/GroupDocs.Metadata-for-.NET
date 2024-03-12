// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2024 GroupDocs. All Rights Reserved.
// </copyright>

namespace GroupDocs.Metadata.Examples.CSharp.AdvancedUsage.ManagingMetadataForSpecificFormats.Image.Jpeg.MakerNote
{
    using Formats.Image;
    using Standards.Exif.MakerNote;
    using System;

    /// <summary>
    /// This code sample shows how to extract Nikon MakerNote properties.
    /// </summary>
    public class MakerNoteReadNikonProperties
    {
        public static void Run()
        {
            Console.WriteLine("\n--------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("[Example Advanced Usage] # MakerNoteReadNikonProperties : How to extract Nikon MakerNote properties.\n");
            using (Metadata metadata = new Metadata(Constants.NikonJpeg))
            {
                var root = metadata.GetRootPackage<JpegRootPackage>();

                var makerNote = (NikonMakerNotePackage)root.MakerNotePackage;
                if (makerNote != null)
                {
                    Console.WriteLine(makerNote.ColorMode);
                    Console.WriteLine(makerNote.FlashSetting);
                    Console.WriteLine(makerNote.FlashType);
                    Console.WriteLine(makerNote.FocusMode);
                    Console.WriteLine(makerNote.Quality);
                    Console.WriteLine(makerNote.Sharpness);

                    // ...
                }
            }
        }
    }
}
