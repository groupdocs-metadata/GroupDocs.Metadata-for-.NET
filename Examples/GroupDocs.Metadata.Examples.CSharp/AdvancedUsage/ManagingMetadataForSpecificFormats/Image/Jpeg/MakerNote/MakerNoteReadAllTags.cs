// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2025 GroupDocs. All Rights Reserved.
// </copyright>

namespace GroupDocs.Metadata.Examples.CSharp.AdvancedUsage.ManagingMetadataForSpecificFormats.Image.Jpeg.MakerNote
{
    using System;
    using Formats.Image;

    /// <summary>
    /// This code sample shows how to extract all detected MakerNote properties in the form of TIFF/EXIF tags.
    /// </summary>
    public class MakerNoteReadAllTags
    {
        public static void Run()
        {
            Console.WriteLine("\n--------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("[Example Advanced Usage] # MakerNoteReadAllTags : How to extract all detected MakerNote properties in the form of TIFF/EXIF tags.\n");
            using (Metadata metadata = new Metadata(Constants.CanonJpeg))
            {
                var root = metadata.GetRootPackage<JpegRootPackage>();
                if (root.MakerNotePackage != null)
                {
                    foreach (var tag in root.MakerNotePackage.ToList())
                    {
                        // Please note that tag ids used by camera manufacturers may intersect with the ids defined in the TIFF/EXIF specification
                        Console.WriteLine("{0} = {1}", (int) tag.TagID, tag.Value);
                    }
                }
            }
        }
    }
}
