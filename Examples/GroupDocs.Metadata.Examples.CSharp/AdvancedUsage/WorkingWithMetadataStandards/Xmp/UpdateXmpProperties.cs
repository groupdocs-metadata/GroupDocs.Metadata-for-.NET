// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2020 GroupDocs. All Rights Reserved.
// </copyright>

namespace GroupDocs.Metadata.Examples.CSharp.AdvancedUsage.WorkingWithMetadataStandards.Xmp
{
    using System;
    using Standards.Xmp;
    using Standards.Xmp.Schemes;

    /// <summary>
    /// This example shows how to update XMP metadata properties.
    /// </summary>
    public static class UpdateXmpProperties
    {
        public static void Run()
        {
            using (Metadata metadata = new Metadata(Constants.GifWithXmp))
            {
                IXmp root = metadata.GetRootPackage() as IXmp;
                if (root != null && root.XmpPackage != null)
                {
                    // if there is no such scheme in the XMP package we should create it
                    if (root.XmpPackage.Schemes.DublinCore == null)
                    {
                        root.XmpPackage.Schemes.DublinCore = new XmpDublinCorePackage();
                    }
                    root.XmpPackage.Schemes.DublinCore.Format = "image/gif";
                    root.XmpPackage.Schemes.DublinCore.SetRights("Copyright (C) 2011-2019 GroupDocs. All Rights Reserved");
                    root.XmpPackage.Schemes.DublinCore.SetSubject("test");

                    if (root.XmpPackage.Schemes.CameraRaw == null)
                    {
                        root.XmpPackage.Schemes.CameraRaw = new XmpCameraRawPackage();
                    }
                    root.XmpPackage.Schemes.CameraRaw.Shadows = 50;
                    root.XmpPackage.Schemes.CameraRaw.AutoBrightness = true;
                    root.XmpPackage.Schemes.CameraRaw.AutoExposure = true;
                    root.XmpPackage.Schemes.CameraRaw.CameraProfile = "test";
                    root.XmpPackage.Schemes.CameraRaw.Exposure = 0.0001;

                    // If you don't want to keep the old values just replace the whole scheme
                    root.XmpPackage.Schemes.XmpBasic = new XmpBasicPackage();
                    root.XmpPackage.Schemes.XmpBasic.CreateDate = DateTime.Today;
                    root.XmpPackage.Schemes.XmpBasic.BaseUrl = "https://groupdocs.com";
                    root.XmpPackage.Schemes.XmpBasic.Rating = 5;

                    root.XmpPackage.Schemes.BasicJobTicket = new XmpBasicJobTicketPackage();

                    // Set a complex type property
                    root.XmpPackage.Schemes.BasicJobTicket.Jobs = new[]
                    {
                        new XmpJob
                        {
                            ID = "1",
                            Name = "test job",
                            Url = "https://groupdocs.com"
                        },
                    };

                    // ... 

                    metadata.Save(Constants.OutputGif);
                }
            }
        }
    }
}
