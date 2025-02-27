﻿// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2025 GroupDocs. All Rights Reserved.
// </copyright>

namespace GroupDocs.Metadata.Examples.CSharp.AdvancedUsage.ManagingMetadataForSpecificFormats.Image.Bmp
{
    using System;
    using Formats.Image;

    /// <summary>
    /// This code sample shows how to read the header of a BMP file.
    /// </summary>
    public static class BmpReadHeaderProperties
    {
        public static void Run()
        {
            Console.WriteLine("\n--------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("[Example Advanced Usage] # BmpReadHeaderProperties : How to read the header of a BMP file.\n");
            using (Metadata metadata = new Metadata(Constants.InputBmp))
            {
                var root = metadata.GetRootPackage<BmpRootPackage>();

                Console.WriteLine(root.BmpHeader.BitsPerPixel);
                Console.WriteLine(root.BmpHeader.ColorsImportant);
                Console.WriteLine(root.BmpHeader.HeaderSize);
                Console.WriteLine(root.BmpHeader.ImageSize);
                Console.WriteLine(root.BmpHeader.Planes);
            }
        }
    }
}
