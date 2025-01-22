// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2025 GroupDocs. All Rights Reserved.
// </copyright>

using System;
using GroupDocs.Metadata.Formats.Image.Dng;

namespace GroupDocs.Metadata.Examples.CSharp.AdvancedUsage.ManagingMetadataForSpecificFormats.Image.Dng
{
    /// <summary>
    /// This code snippet shows how to detect the version of a loaded DNG image and extract some additional file format information.
    /// </summary>
    public static class DngReadFileFormatProperties
    {
        public static void Run()
        {
            Console.WriteLine("\n--------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("[Example Advanced Usage] # DngReadFileFormatProperties : How to detect the version of a loaded DNG image and extract some additional file format information.\n");
            using (Metadata metadata = new Metadata(Constants.InputDng))
            {
                var root = metadata.GetRootPackage<DngRootPackage>();

                Console.WriteLine(root.FileType.FileFormat);
                Console.WriteLine(root.FileType.ByteOrder);
                Console.WriteLine(root.FileType.MimeType);
                Console.WriteLine(root.FileType.Extension);
                Console.WriteLine(root.FileType.Width);
                Console.WriteLine(root.FileType.Height);
                Console.WriteLine(root.DngPackage.Artist);
                Console.WriteLine(root.DngPackage.Description);
            }
        }
    }
}
