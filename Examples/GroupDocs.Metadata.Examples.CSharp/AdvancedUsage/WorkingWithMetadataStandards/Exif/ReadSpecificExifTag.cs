// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2023 GroupDocs. All Rights Reserved.
// </copyright>

namespace GroupDocs.Metadata.Examples.CSharp.AdvancedUsage.WorkingWithMetadataStandards.Exif
{
    using System;
    using Formats.Image;
    using Standards.Exif;

    /// <summary>
    /// This example demonstrates how to read a specific TIFF/EXIF tag by its identifier.
    /// </summary>
    public static class ReadSpecificExifTag
    {
        public static void Run()
        {
            using (Metadata metadata = new Metadata(Constants.TiffWithExif))
            {
                IExif root = metadata.GetRootPackage() as IExif;
                if (root != null && root.ExifPackage != null)
                {
                    TiffAsciiTag software = (TiffAsciiTag)root.ExifPackage[TiffTagID.Software];
                    if (software != null)
                    {
                        Console.WriteLine("Software: {0}", software.Value);
                    }

                    TiffUndefinedTag comment = (TiffUndefinedTag)root.ExifPackage.ExifIfdPackage[TiffTagID.UserComment];
                    if (comment != null)
                    {
                        Console.WriteLine("Comment: {0}", comment.InterpretedValue);
                    }
                }
            }
        }
    }
}
