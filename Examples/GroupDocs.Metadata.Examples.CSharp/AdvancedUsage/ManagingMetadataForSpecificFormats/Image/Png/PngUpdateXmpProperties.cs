// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2026 GroupDocs. All Rights Reserved.
// </copyright>

namespace GroupDocs.Metadata.Examples.CSharp.AdvancedUsage.ManagingMetadataForSpecificFormats.Image.Png
{
    using System;
    using Standards.Xmp;
    using Standards.Xmp.Schemes;

    /// <summary>
    /// This code sample shows how to update XMP metadata properties in a PNG image.
    /// </summary>
    public static class PngUpdateXmpProperties
    {
        public static void Run()
        {
            Console.WriteLine("\n--------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("[Example Advanced Usage] # PngUpdateXmpProperties : How to update XMP metadata properties in a PNG image.\n");
            using (Metadata metadata = new Metadata(Constants.PngWithXmp))
            {
                IXmp root = metadata.GetRootPackage() as IXmp;
                if (root != null)
                {
                    if (root.XmpPackage == null)
                    {
                        root.XmpPackage = new XmpPacketWrapper();
                    }

                    if (root.XmpPackage.Schemes.DublinCore == null)
                    {
                        root.XmpPackage.Schemes.DublinCore = new XmpDublinCorePackage();
                    }

                    root.XmpPackage.Schemes.DublinCore.Format = "image/png";
                    root.XmpPackage.Schemes.DublinCore.SetRights("Copyright (C) 2011-2026 GroupDocs. All Rights Reserved.");
                    root.XmpPackage.Schemes.DublinCore.SetSubject("test");

                    if (root.XmpPackage.Schemes.XmpBasic == null)
                    {
                        root.XmpPackage.Schemes.XmpBasic = new XmpBasicPackage();
                    }

                    root.XmpPackage.Schemes.XmpBasic.CreateDate = DateTime.Today;
                    root.XmpPackage.Schemes.XmpBasic.Label = "GroupDocs";
                    root.XmpPackage.Schemes.XmpBasic.Rating = 5;
                    root.XmpPackage.Schemes.XmpBasic.CreatorTool = "GroupDocs.Metadata";

                    // ...

                    metadata.Save(Constants.OutputPng);
                }
            }
        }
    }
}
