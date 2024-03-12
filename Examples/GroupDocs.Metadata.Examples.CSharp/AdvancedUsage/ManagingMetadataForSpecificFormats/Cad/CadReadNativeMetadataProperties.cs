// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2024 GroupDocs. All Rights Reserved.
// </copyright>

namespace GroupDocs.Metadata.Examples.CSharp.AdvancedUsage.ManagingMetadataForSpecificFormats.Cad
{
    using System;
    using Formats.Cad;

    /// <summary>
    /// This code sample shows how to read metadata of a CAD drawing.
    /// </summary>
    public static class CadReadNativeMetadataProperties
    {
        public static void Run()
        {
            Console.WriteLine("\n--------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("[Example Advanced Usage] # CadReadNativeMetadataProperties : How to read metadata of a CAD drawing.\n");
            using (Metadata metadata = new Metadata(Constants.InputDxf))
            {
                var root = metadata.GetRootPackage<CadRootPackage>();

                Console.WriteLine(root.CadPackage.AcadVersion);
                Console.WriteLine(root.CadPackage.Author);
                Console.WriteLine(root.CadPackage.Comments);
                Console.WriteLine(root.CadPackage.CreatedDateTime);
                Console.WriteLine(root.CadPackage.HyperlinkBase);
                Console.WriteLine(root.CadPackage.Keywords);
                Console.WriteLine(root.CadPackage.LastSavedBy);
                Console.WriteLine(root.CadPackage.Title);

                // ...
            }
        }
    }
}
