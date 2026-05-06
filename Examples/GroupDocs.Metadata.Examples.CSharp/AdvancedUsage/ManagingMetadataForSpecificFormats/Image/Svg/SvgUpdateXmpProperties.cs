// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2026 GroupDocs. All Rights Reserved.
// </copyright>

using GroupDocs.Metadata.Formats.Image.Svg;

namespace GroupDocs.Metadata.Examples.CSharp.AdvancedUsage.ManagingMetadataForSpecificFormats.Image.Svg
{
    using System;
    using Formats.Image;
    using GroupDocs.Metadata.Standards.Xmp.Schemes;
    using GroupDocs.Metadata.Standards.Xmp;
    using Microsoft.SqlServer.Server;

    /// <summary>
    /// This code sample shows how to read the header of a BMP file.
    /// </summary>
    public static class SvgUpdateXmpProperties
    {
        public static void Run()
        {
            Console.WriteLine("\n--------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("[Example Advanced Usage] # SvgUpdateXmpProperties : How to update XMP properties of a SVG file.\n");
            using (Metadata metadata = new Metadata(Constants.InputSvg))
            {
                var root = metadata.GetRootPackage<SvgRootPackage>();
                Console.WriteLine("XmpBasic Label before: {0}", "");
                var xmpPacketWrapper = new XmpPacketWrapper();
                xmpPacketWrapper.Schemes.XmpBasic = new XmpBasicPackage();
                xmpPacketWrapper.Schemes.XmpBasic.Label = "test";
                root.XmpPackage = xmpPacketWrapper;
                metadata.Save(Constants.OutputSvg);

            }

            using (Metadata metadata = new Metadata(Constants.OutputSvg))
            {
                var root = metadata.GetRootPackage<SvgRootPackage>();
                Console.WriteLine("XmpBasic Label after: {0}", root.XmpPackage.Schemes.XmpBasic.Label);
            }
        }
    }
}
