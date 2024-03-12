// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2024 GroupDocs. All Rights Reserved.
// </copyright>

namespace GroupDocs.Metadata.Examples.CSharp.AdvancedUsage.ManagingMetadataForSpecificFormats.Image
{
    using System;
    using Formats.Image;

    /// <summary>
    /// This code sample demonstrates how to extract common image properties such as width and height, MIME type, byte order, etc.
    /// </summary>
    public static class ImageReadFileFormatProperties
    {
        public static void Run()
        {
            Console.WriteLine("\n--------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("[Example Advanced Usage] # ImageReadFileFormatProperties : How to extract common image properties such as width and height, MIME type, byte order, etc.\n");
            using (Metadata metadata = new Metadata(Constants.InputPng))
            {
                var root = metadata.GetRootPackage<ImageRootPackage>();

                Console.WriteLine(root.FileType.FileFormat);
                Console.WriteLine(root.FileType.ByteOrder);
                Console.WriteLine(root.FileType.MimeType);
                Console.WriteLine(root.FileType.Extension);
                Console.WriteLine(root.FileType.Width);
                Console.WriteLine(root.FileType.Height);
            }
        }
    }
}
