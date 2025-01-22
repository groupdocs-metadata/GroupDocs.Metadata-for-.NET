// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2025 GroupDocs. All Rights Reserved.
// </copyright>

namespace GroupDocs.Metadata.Examples.CSharp.AdvancedUsage.WorkingWithMetadataStandards.Xmp
{
    using System;
    using Standards.Xmp;

    /// <summary>
    /// This example demonstrates how to add a custom XMP package to a file of any supported format.
    /// </summary>
    public static class AddCustomXmpPackage
    {
        public static void Run()
        {
            Console.WriteLine("\n--------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("[Example Advanced Usage] # AddCustomXmpPackage : How to add a custom XMP package to a file of any supported format.\n");
            using (Metadata metadata = new Metadata(Constants.InputJpeg))
            {
                IXmp root = metadata.GetRootPackage() as IXmp;
                if (root != null)
                {
                    var packet = new XmpPacketWrapper();
                    
                    var custom = new XmpPackage("gd", "https://groupdocs.com");
                    custom.Set("gd:Copyright", "Copyright (C) 2011-2025 GroupDocs. All Rights Reserved.");
                    custom.Set("gd:CreationDate", DateTime.Today);
                    custom.Set("gd:Company", XmpArray.From(new [] { "Aspose", "GroupDocs" }, XmpArrayType.Ordered));

                    packet.AddPackage(custom);
                    root.XmpPackage = packet;

                    metadata.Save(Constants.OutputJpeg);
                }
            }
        }
    }
}
