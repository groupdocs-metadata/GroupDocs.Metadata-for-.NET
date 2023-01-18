// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2023 GroupDocs. All Rights Reserved.
// </copyright>

namespace GroupDocs.Metadata.Examples.CSharp.BasicUsage
{
    using System;
    using Tagging;

    /// <summary>
    /// This example demonstrates how to search for specific metadata properties using tags.
    /// </summary>
    public static class FindMetadataProperties
    {
        public static void Run()
        {
            // Constants.InputPptx is an absolute or relative path to your document. Ex: @"C:\Docs\source.pptx"
            using (Metadata metadata = new Metadata(Constants.InputPptx))
            {
                // Fetch all the properties satisfying the predicate:
                // property contains the name of the last document editor OR the date/time the document was last modified
                var properties = metadata.FindProperties(p => p.Tags.Contains(Tags.Person.Editor) || p.Tags.Contains(Tags.Time.Modified));
                foreach (var property in properties)
                {
                    Console.WriteLine("Property name: {0}, Property value: {1}", property.Name, property.Value);
                }
            }
        }
    }
}
