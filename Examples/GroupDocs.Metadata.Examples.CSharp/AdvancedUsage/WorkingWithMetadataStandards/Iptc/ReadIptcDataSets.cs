// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2020 GroupDocs. All Rights Reserved.
// </copyright>

namespace GroupDocs.Metadata.Examples.CSharp.AdvancedUsage.WorkingWithMetadataStandards.Iptc
{
    using System;
    using Standards.Iptc;

    /// <summary>
    /// This example demonstrates how to read IPTC IIM datasets from an IPTC metadata package.
    /// </summary>
    public static class ReadIptcDataSets
    {
        public static void Run()
        {
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
                        Console.WriteLine(dataSet.Value);
                    }
                }
            }
        }
    }
}
