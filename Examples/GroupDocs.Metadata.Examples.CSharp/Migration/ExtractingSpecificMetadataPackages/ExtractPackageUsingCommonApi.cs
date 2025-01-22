// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2025 GroupDocs. All Rights Reserved.
// </copyright>

namespace GroupDocs.Metadata.Examples.CSharp.Migration.ExtractingSpecificMetadataPackages
{
    using System;
    using System.Linq;
    using Standards.DublinCore;

    /// <summary>
    /// This example demonstrates how to extract Dublin Core metadata regardless of the file format.
    /// </summary>
    public class ExtractPackageUsingCommonApi
    {
        public static void Run()
        {
            Console.WriteLine("\n--------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("[Example Migration] # ExtractPackageUsingCommonApi : How to extract Dublin Core metadata regardless of the file format.\n");
            using (Metadata metadata = new Metadata(Constants.InputDocx))
            {
                var property = metadata.FindProperties(p => p.Value.RawValue is DublinCorePackage).FirstOrDefault();

                if (property != null)
                {
                    var package = property.Value.ToClass<DublinCorePackage>();

                    Console.WriteLine(package.Format);
                    Console.WriteLine(package.Contributor);
                    Console.WriteLine(package.Coverage);
                    Console.WriteLine(package.Creator);
                    Console.WriteLine(package.Source);
                    Console.WriteLine(package.Description);

                    // ...
                }
            }
        }
    }
}
