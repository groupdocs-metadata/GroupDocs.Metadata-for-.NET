// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2025 GroupDocs. All Rights Reserved.
// </copyright>

namespace GroupDocs.Metadata.Examples.CSharp.AdvancedUsage
{
    using System;
    using Formats.Document;

    /// <summary>
    /// This code snippet demonstrates how to extract information about known properties that can be encountered in a particular package.
    /// </summary>
    public class GettingKnownPropertyDescriptors
    {
        public static void Run()
        {
            Console.WriteLine("\n--------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("[Example Advanced Usage] # GettingKnownPropertyDescriptors : How to extract information about known properties that can be encountered in a particular package.\n");
            using (Metadata metadata = new Metadata(Constants.InputDoc))
            {
                var root = metadata.GetRootPackage<WordProcessingRootPackage>();
                foreach (var descriptor in root.DocumentProperties.PropertyDescriptors)
                {
                    Console.WriteLine(descriptor.Name);
                    Console.WriteLine(descriptor.Type);
                    Console.WriteLine(descriptor.AccessLevel);

                    foreach (var tag in descriptor.Tags)
                    {
                        Console.WriteLine(tag);
                    }

                    Console.WriteLine();
                }
            }
        }
    }
}
