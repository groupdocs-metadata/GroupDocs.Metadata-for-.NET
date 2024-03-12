// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2019 GroupDocs. All Rights Reserved.
// </copyright>

namespace GroupDocs.Metadata.Examples.CSharp.AdvancedUsage
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Text.RegularExpressions;
    using Common;
    using Tagging;

    /// <summary>
    /// This example demonstrates how to extract metadata properties by various criteria regardless of the file format.
    /// </summary>
    public static class ExtractingMetadata
    {
        public static void Run()
        {
            Console.WriteLine("\n--------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("[Example Advanced Usage] # ExtractingMetadata : How to extract metadata properties by various criteria regardless of the file format.\n");
            foreach (string file in Directory.GetFiles(Constants.InputPath))
            {
                using (Metadata metadata = new Metadata(file))
                {
                    if (metadata.FileFormat != FileFormat.Unknown && !metadata.GetDocumentInfo().IsEncrypted)
                    {
                        Console.WriteLine();
                        Console.WriteLine(file);

                        // Fetch all metadata properties that fall into a particular category
                        var properties = metadata.FindProperties(p => p.Tags.Any(t => t.Category == Tags.Content));
                        Console.WriteLine("The metadata properties describing some characteristics of the file content: title, keywords, language, etc.");
                        foreach (var property in properties)
                        {
                            Console.WriteLine("{0} = {1}", property.Name, property.Value);
                        }

                        // Fetch all properties having a specific type and value
                        var year = DateTime.Today.Year;
                        properties = metadata.FindProperties(p => p.Value.Type == MetadataPropertyType.DateTime &&
                                                                 p.Value.ToStruct(DateTime.MinValue).Year == year);
                        Console.WriteLine("All datetime properties with the year value equal to the current year");
                        foreach (var property in properties)
                        {
                            Console.WriteLine("{0} = {1}", property.Name, property.Value);
                        }

                        // Fetch all properties whose names match the specified regex
                        const string pattern = "^author|company|(.+date.*)$";
                        Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);
                        properties = metadata.FindProperties(p => regex.IsMatch(p.Name));

                        Console.WriteLine("All properties whose names match the following regex: {0}", pattern);
                        foreach (var property in properties)
                        {
                            Console.WriteLine("{0} = {1}", property.Name, property.Value);
                        }

                    }
                }
            }
        }
    }
}
