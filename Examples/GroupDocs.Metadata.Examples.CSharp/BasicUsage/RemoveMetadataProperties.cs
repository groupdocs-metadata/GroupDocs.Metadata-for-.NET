// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2024 GroupDocs. All Rights Reserved.
// </copyright>

namespace GroupDocs.Metadata.Examples.CSharp.BasicUsage
{
    using System;
    using Common;
    using Tagging;

    /// <summary>
    /// This example demonstrates how to remove specific metadata properties using various criteria.
    /// </summary>
    public static class RemoveMetadataProperties
    {
        public static void Run()
        {
            Console.WriteLine("\n--------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("[Example Basic Usage] # RemoveMetadataProperties : How to remove specific metadata properties using various criteria.\n");
            // Constants.InputDocx is an absolute or relative path to your document. Ex: @"C:\Docs\source.docx"
            using (Metadata metadata = new Metadata(Constants.InputDocx))
            {
                // Remove all the properties satisfying the predicate:
                // property contains the name of the document author OR
                // it refers to the last editor OR
                // the property value is a string that contains the substring "John" (to remove any mentions of John from the detected metadata)
                var affected = metadata.RemoveProperties(
                    p => p.Tags.Contains(Tags.Person.Creator) ||
                         p.Tags.Contains(Tags.Person.Editor) ||
                         p.Value.Type == MetadataPropertyType.String && p.Value.ToString().Contains("John"));

                Console.WriteLine("Properties removed: {0}", affected);

                metadata.Save(Constants.OutputDocx);
            }
        }
    }
}
