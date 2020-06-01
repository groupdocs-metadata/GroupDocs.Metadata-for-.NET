// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2020 GroupDocs. All Rights Reserved.
// </copyright>

namespace GroupDocs.Metadata.Examples.CSharp.AdvancedUsage
{
    using System;
    using System.IO;
    using Common;
    using Tagging;

    /// <summary>
    /// This example demonstrates how to update existing metadata properties by various criteria regardless of the file format.
    /// </summary>
    public static class UpdatingMetadata
    {
        public static void Run()
        {
            DateTime today = DateTime.Today;
            DateTime threeDaysAgo = today.AddDays(-3);

            foreach (string file in Directory.GetFiles(Constants.InputPath))
            {
                using (Metadata metadata = new Metadata(file))
                {
                    if (metadata.FileFormat != FileFormat.Unknown && !metadata.GetDocumentInfo().IsEncrypted)
                    {
                        Console.WriteLine();
                        Console.WriteLine(file);

                        // Update the file creation date/time if the existing value is older than 3 days
                        var affected = metadata.UpdateProperties(p => p.Tags.Contains(Tags.Time.Created) &&
                                                                      p.Value.Type == MetadataPropertyType.DateTime &&
                                                                      p.Value.ToStruct<DateTime>() < threeDaysAgo, new PropertyValue(today));

                        Console.WriteLine("Affected properties: {0}", affected);

                        metadata.Save(Path.Combine(Constants.OutputPath, "output" + Path.GetExtension(file)));
                    }
                }
            }
        }
    }
}
