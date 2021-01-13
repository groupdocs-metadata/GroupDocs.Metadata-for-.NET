// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2021 GroupDocs. All Rights Reserved.
// </copyright>

namespace GroupDocs.Metadata.Examples.CSharp.AdvancedUsage.WorkingWithMetadataStandards.Iptc
{
    using Standards.Iptc;

    /// <summary>
    /// This code sample shows how to remove IPTC metadata from a file.
    /// </summary>
    public static class RemoveIptcMetadata
    {
        public static void Run()
        {
            using (Metadata metadata = new Metadata(Constants.JpegWithIptc))
            {
                IIptc root = metadata.GetRootPackage() as IIptc;
                if (root != null)
                {
                    root.IptcPackage = null;

                    metadata.Save(Constants.OutputJpeg);
                }
            }
        }
    }
}
