// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2025 GroupDocs. All Rights Reserved.
// </copyright>

namespace GroupDocs.Metadata.Examples.CSharp.AdvancedUsage.WorkingWithMetadataStandards.Xmp
{
    using Standards.Xmp;
    using System;

    /// <summary>
    /// This code sample shows how to remove XMP metadata from a file.
    /// </summary>
    public static class RemoveXmpMetadata
    {
        public static void Run()
        {
            Console.WriteLine("\n--------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("[Example Advanced Usage] # RemoveXmpMetadata : How to remove XMP metadata from a file.\n");
            using (Metadata metadata = new Metadata(Constants.JpegWithXmp))
            {
                IXmp root = metadata.GetRootPackage() as IXmp;
                if (root != null)
                {
                    root.XmpPackage = null;
                    metadata.Save(Constants.OutputJpeg);
                }
            }
        }
    }
}
