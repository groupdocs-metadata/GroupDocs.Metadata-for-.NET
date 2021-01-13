// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2021 GroupDocs. All Rights Reserved.
// </copyright>

namespace GroupDocs.Metadata.Examples.CSharp.AdvancedUsage.ManagingMetadataForSpecificFormats.Document.Note
{
    using System;
    using Formats.Document;

    /// <summary>
    /// This code sample demonstrates how to inspect a note document.
    /// </summary>
    public static class NoteReadInspectionProperties
    {
        public static void Run()
        {
            using (Metadata metadata = new Metadata(Constants.InputOne))
            {
                var root = metadata.GetRootPackage<NoteRootPackage>();

                if (root.InspectionPackage.Pages != null)
                {
                    foreach (var page in root.InspectionPackage.Pages)
                    {
                        Console.WriteLine(page.Title);
                        Console.WriteLine(page.Author);
                        Console.WriteLine(page.CreationTime);
                        Console.WriteLine(page.LastModificationTime);
                    }
                }
            }
        }
    }
}
