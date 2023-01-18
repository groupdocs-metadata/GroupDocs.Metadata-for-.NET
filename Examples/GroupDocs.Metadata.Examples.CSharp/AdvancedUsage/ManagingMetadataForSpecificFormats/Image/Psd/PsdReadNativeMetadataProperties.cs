// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2023 GroupDocs. All Rights Reserved.
// </copyright>

namespace GroupDocs.Metadata.Examples.CSharp.AdvancedUsage.ManagingMetadataForSpecificFormats.Image.Psd
{
    using System;
    using Formats.Image;

    /// <summary>
    /// This code sample demonstrates how to read the header of a PSD file and extract some information about the PSD layers.
    /// </summary>
    public static class PsdReadNativeMetadataProperties
    {
        public static void Run()
        {
            using (Metadata metadata = new Metadata(Constants.PsdWithIptc))
            {
                var root = metadata.GetRootPackage<PsdRootPackage>();

                Console.WriteLine(root.PsdPackage.ChannelCount);
                Console.WriteLine(root.PsdPackage.ColorMode);
                Console.WriteLine(root.PsdPackage.Compression);
                Console.WriteLine(root.PsdPackage.PhotoshopVersion);

                foreach (var layer in root.PsdPackage.Layers)
                {
                    Console.WriteLine(layer.Name);
                    Console.WriteLine(layer.BitsPerPixel);
                    Console.WriteLine(layer.ChannelCount);
                    Console.WriteLine(layer.Flags);
                    Console.WriteLine(layer.Height);
                    Console.WriteLine(layer.Width);

                    // ...
                }

                // ...
            }
        }
    }
}
