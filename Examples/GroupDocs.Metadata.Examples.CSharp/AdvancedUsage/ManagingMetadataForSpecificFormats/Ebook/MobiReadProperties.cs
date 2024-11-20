// <copyright company="Aspose Pty Ltd">
//  Copyright (C) 2011-2024 GroupDocs. All Rights Reserved.
// </copyright>

using GroupDocs.Metadata.Formats.Ebook.Mobi;

namespace GroupDocs.Metadata.Examples.CSharp.AdvancedUsage.ManagingMetadataForSpecificFormats.Ebook
{
    using System;
    using Formats.Ebook;

    /// <summary>
    /// This example shows how to extract metadata from an Mobi file.
    /// </summary>
    public static class MobiReadProperties
    {
        public static void Run()
        {
            Console.WriteLine("\n--------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("[Example Advanced Usage] # MobiReadProperties : How to extract metadata from an Mobi file.\n");
            using (Metadata metadata = new Metadata(Constants.InputMobi))
            {
                var root = metadata.GetRootPackage<MobiRootPackage>();

                Console.WriteLine(root.MobiPackage.PDBHeader.Name);
                Console.WriteLine(root.MobiPackage.PDBHeader.Creator);
                Console.WriteLine(root.MobiPackage.MobiHeader.FullName);
                Console.WriteLine(root.MobiPackage.MobiHeader.MobiType);

                // ...
            }
        }
    }
}
