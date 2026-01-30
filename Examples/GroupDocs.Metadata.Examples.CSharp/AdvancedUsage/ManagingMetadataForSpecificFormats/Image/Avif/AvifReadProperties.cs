// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2025 GroupDocs. All Rights Reserved.
// </copyright>



namespace GroupDocs.Metadata.Examples.CSharp.AdvancedUsage.ManagingMetadataForSpecificFormats.Image.Avif
{
    using System;
    using GroupDocs.Metadata.Common;
    using GroupDocs.Metadata.Formats.Image.Avif;

    /// <summary>
    /// This code sample shows how to read the header of a AVIF file.
    /// </summary>
    public static class AvifReadProperties
    {
        public static void Run()
        {
            Console.WriteLine("\n--------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("[Example Advanced Usage] # AvifReadProperties : How to read properties of a AVIF file.\n");
            using (Metadata metadata = new Metadata(Constants.InputAvif))
            {
                var root = metadata.GetRootPackage<AvifRootPackage>();
                Console.WriteLine("XmpDynamicMedia Artist: {0}", root.XmpPackage.Schemes.XmpDynamicMedia.Artist);
                Console.WriteLine("ExifPackage Artist: {0}", root.ExifPackage.Artist);
            }
        }
    }
}
