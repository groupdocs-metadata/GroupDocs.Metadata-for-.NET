﻿// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2025 GroupDocs. All Rights Reserved.
// </copyright>

namespace GroupDocs.Metadata.Examples.CSharp.AdvancedUsage.ManagingMetadataForSpecificFormats.Document.Diagram
{
    using System;
    using Formats.Document;

    /// <summary>
    /// The following code sample demonstrates how to obtain the text statistics for a diagram.
    /// </summary>
    public static class DiagramReadDocumentStatistics
    {
        public static void Run()
        {
            Console.WriteLine("\n--------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("[Example Advanced Usage] # DiagramReadDocumentStatistics : How to obtain the text statistics for a diagram.\n");
            using (Metadata metadata = new Metadata(Constants.InputVdx))
            {
                var root = metadata.GetRootPackage<DiagramRootPackage>();
                Console.WriteLine(root.DocumentStatistics.PageCount);
            }
        }
    }
}
