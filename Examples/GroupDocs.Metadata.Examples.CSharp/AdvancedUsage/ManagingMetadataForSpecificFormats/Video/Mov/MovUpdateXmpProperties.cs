// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2026 GroupDocs. All Rights Reserved.
// </copyright>

namespace GroupDocs.Metadata.Examples.CSharp.AdvancedUsage.ManagingMetadataForSpecificFormats.Video.Mov
{
    using System;
    using Standards.Xmp;
    using Standards.Xmp.Schemes;

    /// <summary>
    /// This example shows how to update XMP metadata properties in a MOV video file.
    /// </summary>
    public static class MovUpdateXmpProperties
    {
        public static void Run()
        {
            Console.WriteLine("\n--------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("[Example Advanced Usage] # MovUpdateXmpProperties : How to update XMP metadata properties in a MOV video file.\n");
            using (Metadata metadata = new Metadata(Constants.InputMov))
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

                    root.XmpPackage.Schemes.DublinCore.Format = "video/quicktime";
                    root.XmpPackage.Schemes.DublinCore.SetRights("Copyright (C) 2011-2026 GroupDocs. All Rights Reserved.");
                    root.XmpPackage.Schemes.DublinCore.SetSubject("test");

                    if (root.XmpPackage.Schemes.XmpBasic == null)
                    {
                        root.XmpPackage.Schemes.XmpBasic = new XmpBasicPackage();
                    }

                    root.XmpPackage.Schemes.XmpBasic.CreateDate = DateTime.Today;
                    root.XmpPackage.Schemes.XmpBasic.Label = "GroupDocs";
                    root.XmpPackage.Schemes.XmpBasic.Rating = 5;

                    // ...

                    metadata.Save(Constants.OutputMov);
                }
            }
        }
    }
}
