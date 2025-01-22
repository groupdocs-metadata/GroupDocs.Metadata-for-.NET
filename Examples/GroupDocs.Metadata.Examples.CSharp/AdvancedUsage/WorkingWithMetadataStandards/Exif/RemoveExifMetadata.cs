// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2025 GroupDocs. All Rights Reserved.
// </copyright>

namespace GroupDocs.Metadata.Examples.CSharp.AdvancedUsage.WorkingWithMetadataStandards.Exif
{
    using Standards.Exif;
    using System;

    /// <summary>
    /// This code sample shows how to remove EXIF metadata from a file.
    /// </summary>
    public static class RemoveExifMetadata
    {
        public static void Run()
        {
            Console.WriteLine("\n--------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("[Example Advanced Usage] # RemoveExifMetadata : How to remove EXIF metadata from a file.\n");
            using (Metadata metadata = new Metadata(Constants.JpegWithExif))
            {
                IExif root = metadata.GetRootPackage() as IExif;
                if (root != null)
                {
                    root.ExifPackage = null;

                    metadata.Save(Constants.OutputJpeg);
                }
            }
        }
    }
}
