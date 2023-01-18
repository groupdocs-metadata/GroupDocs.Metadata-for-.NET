// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2023 GroupDocs. All Rights Reserved.
// </copyright> 

namespace GroupDocs.Metadata.Examples.CSharp.AdvancedUsage.ManagingMetadataForSpecificFormats.Audio.MP3
{
    using Formats.Audio;

    /// <summary>
    /// This code sample shows how to remove the ID3v1 tag from an MP3 file.
    /// </summary>
    public static class MP3RemoveID3V1Tag
    {
        public static void Run()
        {
            using (Metadata metadata = new Metadata(Constants.MP3WithID3V1))
            {
                var root = metadata.GetRootPackage<MP3RootPackage>();

                root.ID3V1 = null;

                metadata.Save(Constants.OutputMp3);
            }
        }
    }
}
