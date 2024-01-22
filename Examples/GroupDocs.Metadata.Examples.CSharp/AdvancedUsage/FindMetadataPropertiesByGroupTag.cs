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
    public static class FindMetadataPropertiesByGroupTag
    {
        public static void Run()
        {
            using (Metadata metadata = new Metadata(Constants.InputVsdx))
            {
                var properties = metadata.FindProperties(p => p.Tags.Contains(Tags.Person));
                foreach (var property in properties)
                {
                    Console.WriteLine("Property name: {0}, Property value: {1}", property.Name, property.Value);
                }
            }
        }
    }
}
