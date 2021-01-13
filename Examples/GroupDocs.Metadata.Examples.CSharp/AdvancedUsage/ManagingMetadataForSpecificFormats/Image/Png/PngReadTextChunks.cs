// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2021 GroupDocs. All Rights Reserved.
// </copyright>

namespace GroupDocs.Metadata.Examples.CSharp.AdvancedUsage.ManagingMetadataForSpecificFormats.Image.Png
{
    using System;
    using Formats.Image;

    /// <summary>
    /// This code snippet shows how to extract chunks of textual metadata from a PNG image.
    /// </summary>
    public class PngReadTextChunks
    {
        public static void Run()
        {
            using (Metadata metadata = new Metadata(Constants.InputPng))
            {
                var root = metadata.GetRootPackage<PngRootPackage>();

                foreach (var chunk in root.PngPackage.TextChunks)
                {
                    Console.WriteLine(chunk.Keyword);
                    Console.WriteLine(chunk.Text);

                    var compressedChunk = chunk as PngCompressedTextChunk;
                    if (compressedChunk != null)
                    {
                        Console.WriteLine(compressedChunk.CompressionMethod);
                    }

                    var internationalChunk = chunk as PngInternationalTextChunk;
                    if (internationalChunk != null)
                    {
                        Console.WriteLine(internationalChunk.IsCompressed);
                        Console.WriteLine(internationalChunk.Language);
                        Console.WriteLine(internationalChunk.TranslatedKeyword);
                    }
                }
            }
        }
    }
}
