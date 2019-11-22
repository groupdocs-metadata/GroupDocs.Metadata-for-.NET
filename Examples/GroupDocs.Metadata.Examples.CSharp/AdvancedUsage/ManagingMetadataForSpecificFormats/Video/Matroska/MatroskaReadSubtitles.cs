// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2019 GroupDocs. All Rights Reserved.
// </copyright>

namespace GroupDocs.Metadata.Examples.CSharp.AdvancedUsage.ManagingMetadataForSpecificFormats.Video.Matroska
{
    using System;
    using Formats.Video;

    /// <summary>
    /// This example demonstrates how to extract subtitles from an MKV video.
    /// </summary>
    public static class MatroskaReadSubtitles
    {
        public static void Run()
        {
            using (Metadata metadata = new Metadata(Constants.MkvWithSubtitles))
            {
                var root = metadata.GetRootPackage<MatroskaRootPackage>();

                foreach (var subtitleTrack in root.MatroskaPackage.SubtitleTracks)
                {
                    Console.WriteLine(subtitleTrack.LanguageIetf ?? subtitleTrack.Language);
                    foreach (MatroskaSubtitle subtitle in subtitleTrack.Subtitles)
                    {
                        Console.WriteLine("Timecode={0}, Duration={1}", subtitle.Timecode, subtitle.Duration);
                        Console.WriteLine(subtitle.Text);
                    }
                }
            }
        }
    }
}
