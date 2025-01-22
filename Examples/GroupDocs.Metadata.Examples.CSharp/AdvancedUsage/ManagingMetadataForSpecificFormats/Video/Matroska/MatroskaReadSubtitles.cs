// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2025 GroupDocs. All Rights Reserved.
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
            Console.WriteLine("\n--------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("[Example Advanced Usage] # MatroskaReadSubtitles : How to extract subtitles from an MKV video.\n");
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
