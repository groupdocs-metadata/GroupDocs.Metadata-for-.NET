﻿// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2025 GroupDocs. All Rights Reserved.
// </copyright>

namespace GroupDocs.Metadata.Examples.CSharp.AdvancedUsage.WorkingWithMetadataStandards.Exif
{
    using System;
    using Formats.Image;
    using Standards.Exif;

    /// <summary>
    /// This example demonstrates how to read all EXIF tags extracted from a file.
    /// </summary>
    public static class ReadExifTags
    {
        public static void Run()
        {
            Console.WriteLine("\n--------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("[Example Advanced Usage] # ReadExifTags : How to read all EXIF tags extracted from a file.\n");
            using (Metadata metadata = new Metadata(Constants.JpegWithExif))
            {
                IExif root = metadata.GetRootPackage() as IExif;
                if (root != null && root.ExifPackage != null)
                {
                    const string pattern = "{0} = {1}";

                    foreach (TiffTag tag in root.ExifPackage.ToList())
                    {
                        Console.WriteLine(pattern, tag.TagID, tag.Value);
                    }

                    foreach (TiffTag tag in root.ExifPackage.ExifIfdPackage.ToList())
                    {
                        Console.WriteLine(pattern, tag.TagID, tag.Value);
                    }

                    foreach (TiffTag tag in root.ExifPackage.GpsPackage.ToList())
                    {
                        Console.WriteLine(pattern, tag.TagID, tag.Value);
                    }
                }
            }
        }
    }
}
