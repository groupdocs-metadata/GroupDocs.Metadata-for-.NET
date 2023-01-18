// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2023 GroupDocs. All Rights Reserved.
// </copyright>

namespace GroupDocs.Metadata.Examples.CSharp.AdvancedUsage.ManagingMetadataForSpecificFormats.Audio.Wav
{
    using System;
    using Formats.Audio;

    /// <summary>
    /// This code sample shows how to extract INFO chunk metadata from a WAV file.
    /// </summary>
    public static class WavReadInfoMetadata
    {
        public static void Run()
        {
            using (Metadata metadata = new Metadata(Constants.InputWav))
            {
                var root = metadata.GetRootPackage<WavRootPackage>();
                if (root.RiffInfoPackage != null)
                {
                    Console.WriteLine(root.RiffInfoPackage.Artist);
                    Console.WriteLine(root.RiffInfoPackage.Comment);
                    Console.WriteLine(root.RiffInfoPackage.Copyright);
                    Console.WriteLine(root.RiffInfoPackage.CreationDate);
                    Console.WriteLine(root.RiffInfoPackage.Software);
                    Console.WriteLine(root.RiffInfoPackage.Engineer);
                    Console.WriteLine(root.RiffInfoPackage.Genre);

                    // ...
                }
            }
        }
    }
}
