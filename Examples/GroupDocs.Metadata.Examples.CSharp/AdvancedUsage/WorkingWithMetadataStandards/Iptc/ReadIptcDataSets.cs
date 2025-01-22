// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2025 GroupDocs. All Rights Reserved.
// </copyright>

namespace GroupDocs.Metadata.Examples.CSharp.AdvancedUsage.WorkingWithMetadataStandards.Iptc
{
    using System;
    using Common;
    using Standards.Iptc;

    /// <summary>
    /// This example demonstrates how to read IPTC IIM datasets from an IPTC metadata package.
    /// </summary>
    public static class ReadIptcDataSets
    {
        public static void Run()
        {
            Console.WriteLine("\n--------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("[Example Advanced Usage] # ReadIptcDataSets : How to read IPTC IIM datasets from an IPTC metadata package.\n");
            using (Metadata metadata = new Metadata(Constants.PsdWithIptc))
            {
                IIptc root = metadata.GetRootPackage() as IIptc;
                if (root != null && root.IptcPackage != null)
                {
                    foreach (var dataSet in root.IptcPackage.ToDataSetList())
                    {
                        Console.WriteLine(dataSet.RecordNumber);
                        Console.WriteLine(dataSet.DataSetNumber);
                        Console.WriteLine(dataSet.AlternativeName);
                        if (dataSet.Value.Type == MetadataPropertyType.PropertyValueArray)
                        {
                            foreach (var value in dataSet.Value.ToArray<PropertyValue>())
                            {
                                Console.Write("{0}, ", value);
                            }
                            Console.WriteLine();
                        }
                        else
                        {
                            Console.WriteLine(dataSet.Value);
                        }
                    }
                }
            }
        }
    }
}
