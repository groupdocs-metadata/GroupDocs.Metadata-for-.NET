// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2023 GroupDocs. All Rights Reserved.
// </copyright>

namespace GroupDocs.Metadata.Examples.CSharp.AdvancedUsage.ManagingMetadataForSpecificFormats.Document.Presentation
{
    using System;
    using Formats.Document;

    /// <summary>
    /// This code sample demonstrates how to obtain simple text statistics for a presentation.
    /// </summary>
    public static class PresentationReadDocumentStatistics
    {
        public static void Run()
        {
            using (Metadata metadata = new Metadata(Constants.InputPpt))
            {
                var root = metadata.GetRootPackage<PresentationRootPackage>();

                Console.WriteLine(root.DocumentStatistics.CharacterCount);
                Console.WriteLine(root.DocumentStatistics.PageCount);
                Console.WriteLine(root.DocumentStatistics.WordCount);
            }
        }
    }
}
