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
    /// This example demonstrates how to add some missing metadata properties to a file regardless of its format. 
    /// </summary>
    public static class AddingMetadata
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

                        // Add a property containing the file last printing date if it's missing
                        // Note that the property will be added to metadata packages that satisfy the following criteria:
                        // 1) Only existing metadata packages will be affected. No new packages are added during this operation
                        // 2) There should be a known metadata property in the package structure that fits the search condition but is actually missing in the package.
                        // All properties supported by a certain package are usually defined in the specification of a particular metadata standard
                        var affected = metadata.AddProperties(p => p.Tags.Contains(Tags.Time.Printed), new PropertyValue(DateTime.Now));

                        Console.WriteLine("Affected properties: {0}", affected);

                        metadata.Save(Path.Combine(Constants.OutputPath, "output" + Path.GetExtension(file)));
                    }
                }
            }
        }
    }
}
