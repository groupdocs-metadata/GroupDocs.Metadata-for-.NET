// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2025 GroupDocs. All Rights Reserved.
// </copyright>

namespace GroupDocs.Metadata.Examples.CSharp.AdvancedUsage.ManagingMetadataForSpecificFormats.Video.Flv
{
    using System;
    using Formats.Video;

    /// <summary>
    /// This example shows how to read FLV header properties.
    /// </summary>
    public static class FlvReadHeaderProperties
    {
        public static void Run()
        {
            Console.WriteLine("\n--------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("[Example Advanced Usage] # FlvReadHeaderProperties : How to read FLV header properties.\n");
            using (Metadata metadata = new Metadata(Constants.InputFlv))
            {
                var root = metadata.GetRootPackage<FlvRootPackage>();

                Console.WriteLine(root.Header.Version);
                Console.WriteLine(root.Header.HasAudioTags);
                Console.WriteLine(root.Header.HasVideoTags);
                Console.WriteLine(root.Header.TypeFlags);
            }
        }
    }
}
