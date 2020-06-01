// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2020 GroupDocs. All Rights Reserved.
// </copyright>

namespace GroupDocs.Metadata.Examples.CSharp.AdvancedUsage
{
    using System;
    using System.IO;
    using System.Linq;
    using Common;
    using Tagging;

    /// <summary>
    /// This example demonstrates how to remove metadata properties by various criteria regardless of the file format.
    /// </summary>
    public static class RemovingMetadata
    {
        public static void Run()
        {
            foreach (string file in Directory.GetFiles(Constants.InputPath))
            {
                using (Metadata metadata = new Metadata(file))
                {
                    if (metadata.FileFormat != FileFormat.Unknown && !metadata.GetDocumentInfo().IsEncrypted)
                    {
                        Console.WriteLine();
                        Console.WriteLine(file);

                        // Remove all mentions of any people contributed in file creation
                        // Remove a custom property with the specified name
                        var affected = metadata.RemoveProperties(p => p.Tags.Any(t => t.Category == Tags.Person) || p.Name == "CustomProperty");

                        Console.WriteLine("Affected properties: {0}", affected);

                        metadata.Save(Path.Combine(Constants.OutputPath, "output" + Path.GetExtension(file)));
                    }
                }
            }
        }
    }
}
