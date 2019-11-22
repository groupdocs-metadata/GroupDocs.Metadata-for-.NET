// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2019 GroupDocs. All Rights Reserved.
// </copyright>

namespace GroupDocs.Metadata.Examples.CSharp.Migration.ComparingMetadataProperties
{
    using System;
    using System.Linq;
    using Common;
    using Tagging;

    /// <summary>
    /// This code snippet demonstrates how to get the difference of two collections of properties extracted from different files.
    /// </summary>
    public class GetDifferenceOfDocumentProperties
    {
        public static void Run()
        {
            // The predicate to extract metadata properties we want to compare
            // In this code sample we retrieve built-in document properties
            Common.Func<MetadataProperty, bool> predicate = p => p.Tags.Contains(Tags.Document.BuiltIn);
            using (Metadata metadata1 = new Metadata(Constants.InputDoc))
            using (Metadata metadata2 = new Metadata(Constants.InputDocx))
            {
                // You can implement your own equality comparer for metadata properties
                // In this code sample, we just use the old one that worked in previous versions of GroupDocs.Metadata
                var difference = metadata1.FindProperties(predicate).Except(metadata2.FindProperties(predicate), new MetadataPropertyEqualityComparer());
                foreach (var property in difference)
                {
                    Console.WriteLine("{0} = {1}", property.Name, property.Value);
                }
            }
        }
    }
}
