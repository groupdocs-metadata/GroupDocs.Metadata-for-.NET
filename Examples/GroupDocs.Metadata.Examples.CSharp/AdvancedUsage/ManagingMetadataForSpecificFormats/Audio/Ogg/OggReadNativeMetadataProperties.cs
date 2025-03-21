// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2025 GroupDocs. All Rights Reserved.
// </copyright>

using GroupDocs.Metadata.Formats.Audio.Ogg;

namespace GroupDocs.Metadata.Examples.CSharp.AdvancedUsage.ManagingMetadataForSpecificFormats.Cad
{
    using System;

    /// <summary>
    /// This code sample shows how to read metadata of ogg file.
    /// </summary>
    public static class OggReadNativeMetadataProperties
    {
        public static void Run()
        {
            Console.WriteLine("\n--------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("[Example Advanced Usage] # OggReadNativeMetadataProperties : How to read metadata of ogg file.\n");
            using (Metadata metadata = new Metadata(Constants.InputOgg))
            {
                var root = metadata.GetRootPackage<OggRootPackage>();

                Console.WriteLine(root.OggPackage.Copyright);
                Console.WriteLine(root.OggPackage.Date);
                foreach (var comment in root.OggPackage.OggUserComments)
                {
                    Console.WriteLine(comment.Header);
                    Console.WriteLine(comment.Value);
                }
            }
        }
    }
}
