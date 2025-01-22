// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2025 GroupDocs. All Rights Reserved.
// </copyright>

namespace GroupDocs.Metadata.Examples.CSharp.AdvancedUsage.ManagingMetadataForSpecificFormats.Image.Gif
{
    using System;
    using Formats.Image;

    /// <summary>
    /// This code snippet shows how to detect the version of a loaded GIF image and extract some additional file format information.
    /// </summary>
    public static class GifReadFileFormatProperties
    {
        public static void Run()
        {
            Console.WriteLine("\n--------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("[Example Advanced Usage] # GifReadFileFormatProperties : How to detect the version of a loaded GIF image and extract some additional file format information.\n");
            using (Metadata metadata = new Metadata(Constants.InputGif))
            {
                var root = metadata.GetRootPackage<GifRootPackage>();

                Console.WriteLine(root.FileType.FileFormat);
                Console.WriteLine(root.FileType.Version);
                Console.WriteLine(root.FileType.ByteOrder);
                Console.WriteLine(root.FileType.MimeType);
                Console.WriteLine(root.FileType.Extension);
                Console.WriteLine(root.FileType.Width);
                Console.WriteLine(root.FileType.Height);
            }
        }
    }
}
