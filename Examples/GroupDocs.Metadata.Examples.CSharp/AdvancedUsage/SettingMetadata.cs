// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2023 GroupDocs. All Rights Reserved.
// </copyright>

namespace GroupDocs.Metadata.Examples.CSharp.AdvancedUsage
{
    using System;
    using System.IO;
    using Common;
    using Tagging;

    /// <summary>
    /// This example demonstrates how to set metadata properties by various criteria regardless of the file format. 
    /// </summary>
    public static class SettingMetadata
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

                        // This operation is a combination of the AddProperties and UpdateProperties methods.
                        // If an existing property satisfies the predicate its value is updated.
                        // If there is a known property missing in the package that satisfies the predicate it is added to the package.

                        // Set the copyright notice
                        var affected = metadata.SetProperties(
                            p => p.Tags.Contains(Tags.Legal.Copyright), 
                            new PropertyValue("Copyright (C) 2011-2023 GroupDocs. All Rights Reserved."));

                        Console.WriteLine("Affected properties: {0}", affected);

                        metadata.Save(Path.Combine(Constants.OutputPath, "output" + Path.GetExtension(file)));
                    }
                }
            }
        }
    }
}
