﻿// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2025 GroupDocs. All Rights Reserved.
// </copyright>

namespace GroupDocs.Metadata.Examples.CSharp.AdvancedUsage.ManagingMetadataForSpecificFormats.Document.Note
{
    using System;
    using Formats.Document;

    /// <summary>
    /// This code sample shows how to obtain simple text statistics for a Note document.
    /// </summary>
    public static class NoteReadDocumentStatistics
    {
        public static void Run()
        {
            Console.WriteLine("\n--------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("[Example Advanced Usage] # NoteReadDocumentStatistics : How to obtain simple text statistics for a Note document.\n");
            using (Metadata metadata = new Metadata(Constants.InputOne))
            {
                var root = metadata.GetRootPackage<NoteRootPackage>();

                Console.WriteLine(root.DocumentStatistics.CharacterCount);
                Console.WriteLine(root.DocumentStatistics.PageCount);
                Console.WriteLine(root.DocumentStatistics.WordCount);
            }
        }
    }
}
