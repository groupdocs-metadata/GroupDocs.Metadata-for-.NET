using GroupDocs.Metadata.Examples.Utilities.CSharp;
using GroupDocs.Metadata.Formats.Torrent;
using System;

namespace GroupDocs.Metadata.Examples.CSharp
{
    public static class Torrent
    {
        // initialize file path
        private const string filePath = "Torrent/Bit Torrent/sample.torrent";
        /// <summary>
        /// Get Metadata of Bit Torrent File Fomrat 
        /// </summary>
        public static class BitTorrent
        {
            /// <summary>
            /// Read BitTorrent File Metadata
            /// Feature is supported in version 18.4 or greater of the API
            /// </summary>
            public static void GetTorrentMetadata()
            {
                try
                {
                    using (TorrentFormat torrentFormat = new TorrentFormat(Common.MapDestinationFilePath(filePath)))
                    {
                        TorrentMetadata info = torrentFormat.TorrentInfo;
                        Console.WriteLine(info.Announce);
                        Console.WriteLine(info.CreatedBy);
                        Console.WriteLine(info.CreationDate);
                        Console.WriteLine(info.Comment);
                        Console.WriteLine(info.PieceLength);
                        Console.WriteLine(info.Pieces.Length);

                        foreach (TorrentFileInfo file in info.SharedFiles)
                        {
                            Console.WriteLine(file.Name);
                            Console.WriteLine(file.Length);
                        }
                    }

                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }
            }
            /// <summary>
            /// Update Bit Torrent File Metadata 
            /// Feature is supported in version 18.4 or greater of the API
            /// </summary>
            public static void UpdateTorrentMedata()
            {
                try
                {
                    using (TorrentFormat torrentFormat = new TorrentFormat(Common.MapSourceFilePath(filePath)))
                    {
                        TorrentMetadata info = torrentFormat.TorrentInfo;

                        info.Comment = "test comment";
                        info.CreatedBy = "test application";
                        info.CreationDate = DateTime.Now;

                        torrentFormat.Save(Common.MapDestinationFilePath(filePath));
                    }

                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}