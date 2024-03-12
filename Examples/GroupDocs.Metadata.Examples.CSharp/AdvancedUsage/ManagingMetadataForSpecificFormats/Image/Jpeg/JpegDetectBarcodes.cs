// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2024 GroupDocs. All Rights Reserved.
// </copyright>

namespace GroupDocs.Metadata.Examples.CSharp.AdvancedUsage.ManagingMetadataForSpecificFormats.Image.Jpeg
{
    using Formats.Image;
    using System;

    /// <summary>
    /// This code snippet demonstrates how to detect barcodes in a JPEG image.
    /// </summary>
    public class JpegDetectBarcodes
    {
        public static void Run()
        {
            Console.WriteLine("\n--------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("[Example Advanced Usage] # JpegDetectBarcodes : How to detect barcodes in a JPEG image.\n");
            using (Metadata metadata = new Metadata(Constants.JpegWithBarcodes))
            {
                var root = metadata.GetRootPackage<JpegRootPackage>();

                var barcodeTypes = root.DetectBarcodeTypes();

                foreach (var barcodeType in barcodeTypes)
                {
                    Console.WriteLine(barcodeType);
                }
            }
        }
    }
}
