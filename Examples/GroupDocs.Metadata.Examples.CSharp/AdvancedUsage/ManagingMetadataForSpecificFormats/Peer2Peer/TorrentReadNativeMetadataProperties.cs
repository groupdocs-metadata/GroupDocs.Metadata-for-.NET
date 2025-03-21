﻿// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2025 GroupDocs. All Rights Reserved.
// </copyright>

namespace GroupDocs.Metadata.Examples.CSharp.AdvancedUsage.ManagingMetadataForSpecificFormats.Peer2Peer
{
    using System;
    using Formats.Peer2Peer;


    /// <summary>
    /// This code sample shows how to read metadata of a TORRENT file.
    /// </summary>
    public static class TorrentReadNativeMetadataProperties
    {
        public static void Run()
        {
            Console.WriteLine("\n--------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("[Example Advanced Usage] # TorrentReadNativeMetadataProperties : How to read metadata of a TORRENT file.\n");
            using (Metadata metadata = new Metadata(Constants.InputTorrent))
            {
                var root = metadata.GetRootPackage<TorrentRootPackage>();

                Console.WriteLine(root.TorrentPackage.Announce);
                Console.WriteLine(root.TorrentPackage.Comment);
                Console.WriteLine(root.TorrentPackage.CreatedBy);
                Console.WriteLine(root.TorrentPackage.CreationDate);
                foreach (var file in root.TorrentPackage.SharedFiles)
                {
                    Console.WriteLine(file.Name);
                    Console.WriteLine(file.Length);
                }

                // ...
            }
        }
    }
}
