// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2021 GroupDocs. All Rights Reserved.
// </copyright>

namespace GroupDocs.Metadata.Examples.CSharp.AdvancedUsage.WorkingWithMetadataStandards.Iptc
{
    using Standards.Iptc;

    /// <summary>
    /// This example shows how to add or update custom IPTC datasets in a file.
    /// </summary>
    public static class SetCustomIptcDataSet
    {
        public static void Run()
        {
            using (Metadata metadata = new Metadata(Constants.PsdWithIptc))
            {
                IIptc root = metadata.GetRootPackage() as IIptc;
                if (root != null)
                {
                    // Set the IPTC package if it's missing
                    if (root.IptcPackage == null)
                    {
                        root.IptcPackage = new IptcRecordSet();
                    }

                    // Add a know property using the DataSet API
                    root.IptcPackage.Set(new IptcDataSet((byte)IptcRecordType.ApplicationRecord, (byte)IptcApplicationRecordDataSet.BylineTitle, "test code sample"));

                    // Add a custom IPTC DataSet
                    root.IptcPackage.Set(new IptcDataSet(255, 255, new byte[] { 1, 2, 3 }));

                    metadata.Save(Constants.OutputPsd);
                }
            }
        }
    }
}
