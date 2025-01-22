// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2025 GroupDocs. All Rights Reserved.
// </copyright>

namespace GroupDocs.Metadata.Examples.CSharp.BasicUsage
{
    using System;
    using Common;
    using Tagging;

    /// <summary>
    /// This example demonstrates how to set specific metadata properties using different criteria.
    /// </summary>
    public static class SetMetadataProperties
    {
        public static void Run()
        {
            Console.WriteLine("\n--------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("[Example Basic Usage] # SetMetadataProperties : How to set specific metadata properties using different criteria.\n");
            // Constants.InputVsdx is an absolute or relative path to your document. Ex: @"C:\Docs\source.vsdx"
            using (Metadata metadata = new Metadata(Constants.InputVsdx))
            {
                // Set the value of each property that satisfies the predicate:
                // property contains the date/time the document was created OR modified
                var affected = metadata.SetProperties(
                    p => p.Tags.Contains(Tags.Time.Created) || p.Tags.Contains(Tags.Time.Modified),
                    new PropertyValue(DateTime.Now));

                Console.WriteLine("Properties set: {0}", affected);

                metadata.Save(Constants.OutputVsdx);
            }
        }
    }
}
