// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2020 GroupDocs. All Rights Reserved.
// </copyright>

namespace GroupDocs.Metadata.Examples.CSharp.AdvancedUsage.WorkingWithMetadataStandards.Xmp
{
    using Standards.Xmp;

    /// <summary>
    /// This code sample shows how to remove XMP metadata from a file.
    /// </summary>
    public static class RemoveXmpMetadata
    {
        public static void Run()
        {
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
