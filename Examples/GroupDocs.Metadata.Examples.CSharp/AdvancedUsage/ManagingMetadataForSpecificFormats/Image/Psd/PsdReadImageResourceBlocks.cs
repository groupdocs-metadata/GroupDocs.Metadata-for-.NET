// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2024 GroupDocs. All Rights Reserved.
// </copyright>

namespace GroupDocs.Metadata.Examples.CSharp.AdvancedUsage.ManagingMetadataForSpecificFormats.Image.Psd
{
    using System;
    using Formats.Image;

    /// <summary>
    /// The code sample below demonstrates how to extract image resource blocks (building blocks of the Photoshop file format) from a PSD image.
    /// </summary>
    public static class PsdReadImageResourceBlocks
    {
        public static void Run()
        {
            Console.WriteLine("\n--------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("[Example Advanced Usage] # PsdReadImageResourceBlocks : How to extract image resource blocks (building blocks of the Photoshop file format) from a PSD image.\n");
            using (Metadata metadata = new Metadata(Constants.PsdWithIrb))
            {
                var root = metadata.GetRootPackage<PsdRootPackage>();

                if (root.ImageResourcePackage != null)
                {
                    foreach (var block in root.ImageResourcePackage.ToList())
                    {
                        Console.WriteLine(block.Signature);
                        Console.WriteLine(block.ID);
                        Console.WriteLine(block.Name);
                        Console.WriteLine(block.Data);
                    }
                }
            }
        }
    }
}
