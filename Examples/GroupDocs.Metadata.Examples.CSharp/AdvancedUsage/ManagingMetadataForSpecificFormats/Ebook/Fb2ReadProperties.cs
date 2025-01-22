// <copyright company="Aspose Pty Ltd">
//  Copyright (C) 2011-2025 GroupDocs. All Rights Reserved.
// </copyright>

namespace GroupDocs.Metadata.Examples.CSharp.AdvancedUsage.ManagingMetadataForSpecificFormats.Ebook
{
    using System;
    using Formats.Ebook;

    /// <summary>
    /// This example shows how to extract metadata from an FB2 file.
    /// </summary>
    public static class Fb2ReadProperties
    {
        public static void Run()
        {
            Console.WriteLine("\n--------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("[Example Advanced Usage] # Fb2ReadProperties : How to extract metadata from an FB2 file.\n");
            using (Metadata metadata = new Metadata(Constants.InputFb2))
            {
                var root = metadata.GetRootPackage<Fb2RootPackage>();

                Console.WriteLine(root.Fb2Package.TitleInfo.BookTitle);
                Console.WriteLine(root.Fb2Package.TitleInfo.Lang);
                Console.WriteLine(root.Fb2Package.TitleInfo.SrcLang);
                Console.WriteLine(root.Fb2Package.DocumentInfo.ProgramUsed);

                // ...
            }
        }
    }
}
