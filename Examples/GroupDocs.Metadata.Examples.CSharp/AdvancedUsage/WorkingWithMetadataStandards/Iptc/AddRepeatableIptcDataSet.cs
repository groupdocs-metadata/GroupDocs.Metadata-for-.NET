// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2025 GroupDocs. All Rights Reserved.
// </copyright>

using GroupDocs.Metadata.Common;
using GroupDocs.Metadata.Standards.Iptc;
using System;

namespace GroupDocs.Metadata.Examples.CSharp.AdvancedUsage.WorkingWithMetadataStandards.Iptc
{
    // <summary>
    /// This example demonstrates how to add a repeatable DataSet to an IPTC IIM record.
    /// </summary>
    public class AddRepeatableIptcDataSet
    {
        public static void Run()
        {
            Console.WriteLine("\n--------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("[Example Advanced Usage] # AddRepeatableIptcDataSet : How to add a repeatable DataSet to an IPTC IIM record.\n");
            using (Metadata metadata = new Metadata(Constants.PsdWithIptc))
            {
                IIptc root = (IIptc)metadata.GetRootPackage();

                // Set the IPTC package if it's missing
                if (root.IptcPackage == null)
                {
                    root.IptcPackage = new IptcRecordSet();
                }

                root.IptcPackage.Add(new IptcDataSet((byte)IptcRecordType.ApplicationRecord, (byte)IptcApplicationRecordDataSet.Keywords, "keyword 1"));
                root.IptcPackage.Add(new IptcDataSet((byte)IptcRecordType.ApplicationRecord, (byte)IptcApplicationRecordDataSet.Keywords, "keyword 2"));
                root.IptcPackage.Add(new IptcDataSet((byte)IptcRecordType.ApplicationRecord, (byte)IptcApplicationRecordDataSet.Keywords, "keyword 3"));

                metadata.Save(Constants.OutputPsd);
            }

            // Check the output file
            using (Metadata metadata = new Metadata(Constants.OutputPsd))
            {
                IIptc root = (IIptc)metadata.GetRootPackage();

                var keywordsProperty = root.IptcPackage.ApplicationRecord[(byte)IptcApplicationRecordDataSet.Keywords];

                foreach (var value in keywordsProperty.Value.ToArray<PropertyValue>())
                {
                    Console.WriteLine(value);
                }
            }
        }
    }
}
