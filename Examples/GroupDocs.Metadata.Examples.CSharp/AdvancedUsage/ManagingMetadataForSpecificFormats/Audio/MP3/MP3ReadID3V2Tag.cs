// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2019 GroupDocs. All Rights Reserved.
// </copyright> 

namespace GroupDocs.Metadata.Examples.CSharp.AdvancedUsage.ManagingMetadataForSpecificFormats.Audio.MP3
{
    using System;
    using Formats.Audio;

    /// <summary>
    ///  This example shows how to read the ID3v2 tag in an MP3 file.
    /// </summary>
    public static class MP3ReadID3V2Tag
    {
        public static void Run()
        {
            using (Metadata metadata = new Metadata(Constants.MP3WithID3V2))
            {
                var root = metadata.GetRootPackage<MP3RootPackage>();

                if (root.ID3V2 != null)
                {
                    Console.WriteLine(root.ID3V2.Album);
                    Console.WriteLine(root.ID3V2.Artist);
                    Console.WriteLine(root.ID3V2.Band);
                    Console.WriteLine(root.ID3V2.Title);
                    Console.WriteLine(root.ID3V2.Composers);
                    Console.WriteLine(root.ID3V2.Copyright);
                    Console.WriteLine(root.ID3V2.Publisher);
                    Console.WriteLine(root.ID3V2.OriginalAlbum);
                    Console.WriteLine(root.ID3V2.MusicalKey);

                    if (root.ID3V2.AttachedPictures != null)
                    {
                        foreach (var attachedPicture in root.ID3V2.AttachedPictures)
                        {
                            Console.WriteLine(attachedPicture.AttachedPictureType);
                            Console.WriteLine(attachedPicture.MimeType);
                            Console.WriteLine(attachedPicture.Description);

                            // ...
                        }
                    }

                    // ...
                }
            }
        }
    }
}
