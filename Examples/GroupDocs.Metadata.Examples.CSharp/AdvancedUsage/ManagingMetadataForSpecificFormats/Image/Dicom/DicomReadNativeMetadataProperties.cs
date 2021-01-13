// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2021 GroupDocs. All Rights Reserved.
// </copyright>

namespace GroupDocs.Metadata.Examples.CSharp.AdvancedUsage.ManagingMetadataForSpecificFormats.Image.Dicom
{
    using System;
    using Formats.Image;

    /// <summary>
    /// This example demonstrates how to read DICOM format-specific metadata properties.
    /// </summary>
    public static class DicomReadNativeMetadataProperties
    {
        public static void Run()
        {
            using (Metadata metadata = new Metadata(Constants.InputDicom))
            {
                var root = metadata.GetRootPackage<DicomRootPackage>();
                if (root.DicomPackage != null)
                {
                    Console.WriteLine(root.DicomPackage.BitsAllocated);
                    Console.WriteLine(root.DicomPackage.HeaderOffset);
                    Console.WriteLine(root.DicomPackage.NumberOfFrames);

                    // ...
                }
            }
        }
    }
}
