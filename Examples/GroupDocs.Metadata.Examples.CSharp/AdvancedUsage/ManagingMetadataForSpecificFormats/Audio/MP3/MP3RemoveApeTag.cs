// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2019 GroupDocs. All Rights Reserved.
// </copyright> 

namespace GroupDocs.Metadata.Examples.CSharp.AdvancedUsage.ManagingMetadataForSpecificFormats.Audio.MP3
{
    using Formats.Audio;

    /// <summary>
    /// This example shows how to remove the APEv2 tag from an MP3 file.
    /// </summary>
    public static class MP3RemoveApeTag
    {
        public static void Run()
        {
            using (Metadata metadata = new Metadata(Constants.MP3WithApe))
            {
                var root = metadata.GetRootPackage<MP3RootPackage>();

                root.RemoveApeV2();

                metadata.Save(Constants.OutputMp3);
            }
        }
    }
}
