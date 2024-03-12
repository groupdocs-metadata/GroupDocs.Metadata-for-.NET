// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2024 GroupDocs. All Rights Reserved.
// </copyright>

namespace GroupDocs.Metadata.Examples.CSharp.AdvancedUsage
{
    using Common;
    using System;
    using System.IO;

    /// <summary>
    /// This example demonstrates how to use interpreted property values.
    /// </summary>
    public class WorkingWithInterpretedValues
    {
        public static void Run()
        {
            Console.WriteLine("\n--------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("[Example Advanced Usage] # WorkingWithInterpretedValues : How to use interpreted property values.\n");
            foreach (string file in Directory.GetFiles(Constants.InputPath))
            {
                using (Metadata metadata = new Metadata(file))
                {
                    if (metadata.FileFormat != FileFormat.Unknown && !metadata.GetDocumentInfo().IsEncrypted)
                    {
                        Console.WriteLine();
                        Console.WriteLine(file);

                        var properties = metadata.FindProperties(p => p.InterpretedValue != null);

                        foreach (var property in properties)
                        {
                            Console.WriteLine(property.Name);
                            Console.WriteLine(property.Value.RawValue);
                            Console.WriteLine(property.InterpretedValue.RawValue);
                        }
                    }
                }
            }
        }
    }
}
