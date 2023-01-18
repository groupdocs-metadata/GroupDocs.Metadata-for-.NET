// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2023 GroupDocs. All Rights Reserved.
// </copyright>

namespace GroupDocs.Metadata.Examples.CSharp.AdvancedUsage.ManagingMetadataForSpecificFormats.Peer2Peer
{
    using System;
    using Formats.Peer2Peer;

    /// <summary>
    /// This code sample shows how to update metadata in a TORRENT file.
    /// </summary>
    public static class TorrentUpdateNativeMetadataProperties
    {
        public static void Run()
        {
            using (Metadata metadata = new Metadata(Constants.InputTorrent))
            {
                var root = metadata.GetRootPackage<TorrentRootPackage>();

                root.TorrentPackage.Comment = "test comment";
                root.TorrentPackage.CreatedBy = "GroupDocs.Metadata";
                root.TorrentPackage.CreationDate = DateTime.Today;

                metadata.Save(Constants.OutputTorrent);
            }
        }
    }
}
