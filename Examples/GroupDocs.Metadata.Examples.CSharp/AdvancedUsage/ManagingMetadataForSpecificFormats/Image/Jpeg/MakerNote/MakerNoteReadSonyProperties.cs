// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2024 GroupDocs. All Rights Reserved.
// </copyright>

namespace GroupDocs.Metadata.Examples.CSharp.AdvancedUsage.ManagingMetadataForSpecificFormats.Image.Jpeg.MakerNote
{
    using System;
    using Formats.Image;
    using Standards.Exif.MakerNote;

    /// <summary>
    /// This code sample shows how to extract Sony MakerNote properties.
    /// </summary>
    public class MakerNoteReadSonyProperties
    {
        public static void Run()
        {
            Console.WriteLine("\n--------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("[Example Advanced Usage] # MakerNoteReadSonyProperties : How to extract Sony MakerNote properties.\n");
            using (Metadata metadata = new Metadata(Constants.SonyJpeg))
            {
                var root = metadata.GetRootPackage<JpegRootPackage>();

                var makerNote = (SonyMakerNotePackage)root.MakerNotePackage;
                if (makerNote != null)
                {
                    Console.WriteLine(makerNote.CreativeStyle);
                    Console.WriteLine(makerNote.ColorMode);
                    Console.WriteLine(makerNote.JpegQuality);
                    Console.WriteLine(makerNote.Brightness);
                    Console.WriteLine(makerNote.Sharpness);

                    // ...
                }
            }
        }
    }
}
