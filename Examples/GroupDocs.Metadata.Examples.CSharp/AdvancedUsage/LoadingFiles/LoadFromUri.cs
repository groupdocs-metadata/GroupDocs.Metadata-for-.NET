// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2025 GroupDocs. All Rights Reserved.
// </copyright>

namespace GroupDocs.Metadata.Examples.CSharp.AdvancedUsage
{
    using System;
    using Formats.Image;

    /// <summary>
    /// This example demonstrates load metadata from uri. 
    /// </summary>
    public static class LoadFromUri
    {
        public static void Run()
        {
            Console.WriteLine("\n--------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("[Example Advanced Usage] # LoadFromUri : This example demonstrates load metadata from uri.\n");

            var uri = new Uri("https://raw.githubusercontent.com/groupdocs-metadata/GroupDocs.Metadata-for-.NET/refs/heads/master/Examples/GroupDocs.Metadata.Examples.CSharp/Resources/SampleFiles/exif.jpg");

            using (Metadata metadata = new Metadata(uri))
            {
                var jpeg = metadata.GetRootPackage<JpegRootPackage>();
                Console.WriteLine(jpeg);
            }
        }
    }
}
