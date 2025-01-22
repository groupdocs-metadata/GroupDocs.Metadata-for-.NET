// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2025 GroupDocs. All Rights Reserved.
// </copyright>


namespace GroupDocs.Metadata.Examples.CSharp.AdvancedUsage.WorkingWithMetadataStandards.Xmp
{
    using System;
    using Standards.Xmp;

    /// <summary>
    /// This example demonstrates how to extract XMP metadata from a file.
    /// </summary>
    public static class ReadXmpProperties
    {
        public static void Run()
        {
            Console.WriteLine("\n--------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("[Example Advanced Usage] # ReadXmpProperties : How to extract XMP metadata from a file.\n");
            using (Metadata metadata = new Metadata(Constants.PngWithXmp))
            {
                IXmp root = metadata.GetRootPackage() as IXmp;
                if (root != null && root.XmpPackage != null)
                {
                    if (root.XmpPackage.Schemes.XmpBasic != null)
                    {
                        Console.WriteLine(root.XmpPackage.Schemes.XmpBasic.CreatorTool);
                        Console.WriteLine(root.XmpPackage.Schemes.XmpBasic.CreateDate);
                        Console.WriteLine(root.XmpPackage.Schemes.XmpBasic.ModifyDate);
                        Console.WriteLine(root.XmpPackage.Schemes.XmpBasic.Label);
                        Console.WriteLine(root.XmpPackage.Schemes.XmpBasic.Nickname);

                        // ...
                    }

                    if (root.XmpPackage.Schemes.DublinCore != null)
                    {
                        Console.WriteLine(root.XmpPackage.Schemes.DublinCore.Format);
                        Console.WriteLine(root.XmpPackage.Schemes.DublinCore.Coverage);
                        Console.WriteLine(root.XmpPackage.Schemes.DublinCore.Identifier);
                        Console.WriteLine(root.XmpPackage.Schemes.DublinCore.Source);

                        // ...
                    }

                    if (root.XmpPackage.Schemes.Photoshop != null)
                    {
                        Console.WriteLine(root.XmpPackage.Schemes.Photoshop.ColorMode);
                        Console.WriteLine(root.XmpPackage.Schemes.Photoshop.IccProfile);
                        Console.WriteLine(root.XmpPackage.Schemes.Photoshop.Country);
                        Console.WriteLine(root.XmpPackage.Schemes.Photoshop.City);
                        Console.WriteLine(root.XmpPackage.Schemes.Photoshop.DateCreated);

                        // ... 
                    }

                    // ...
                }
            }
        }
    }
}
