// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2020 GroupDocs. All Rights Reserved.
// </copyright>

namespace GroupDocs.Metadata.Examples.CSharp.AdvancedUsage.ManagingMetadataForSpecificFormats.Video.Avi
{
    using System;
    using Formats.Video;

    /// <summary>
    /// This code snippet shows how to read AVI header properties.
    /// </summary>
    public static class AviReadHeaderProperties
    {
        public static void Run()
        {
            using (Metadata metadata = new Metadata(Constants.InputAvi))
            {
                var root = metadata.GetRootPackage<AviRootPackage>();

                Console.WriteLine(root.Header.AviHeaderFlags);
                Console.WriteLine(root.Header.Height);
                Console.WriteLine(root.Header.Width);
                Console.WriteLine(root.Header.TotalFrames);
                Console.WriteLine(root.Header.InitialFrames);
                Console.WriteLine(root.Header.MaxBytesPerSec);
                Console.WriteLine(root.Header.PaddingGranularity);
                Console.WriteLine(root.Header.Streams);

                // ...
            }
        }
    }
}
