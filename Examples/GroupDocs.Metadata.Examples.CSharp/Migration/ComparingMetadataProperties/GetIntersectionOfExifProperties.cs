// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2020 GroupDocs. All Rights Reserved.
// </copyright>

namespace GroupDocs.Metadata.Examples.CSharp.Migration.ComparingMetadataProperties
{
    using System;
    using System.Linq;
    using Common;
    using Formats.Image;

    /// <summary>
    /// This code snippet demonstrates how to get the intersection of two collections of properties extracted from different files.
    /// </summary>
    public class GetIntersectionOfExifProperties
    {
        public static void Run()
        {
            // The predicate to extract metadata properties we want to compare
            // In this code sample we retrieve TIFF/EXIF tags
            Common.Func<MetadataProperty, bool> predicate = p => p is TiffTag;
            using (Metadata metadata1 = new Metadata(Constants.JpegWithExif))
            using (Metadata metadata2 = new Metadata(Constants.TiffWithExif))
            {
                // You can implement your own equality comparer for metadata properties
                // In this code sample, we just use the old one that worked in previous versions of GroupDocs.Metadata
                var intersection = metadata1.FindProperties(predicate).Intersect(metadata2.FindProperties(predicate), new MetadataPropertyEqualityComparer());
                foreach (var property in intersection)
                {
                    Console.WriteLine("{0} = {1}", property.Name, property.Value);
                }
            }
        }
    }
}
