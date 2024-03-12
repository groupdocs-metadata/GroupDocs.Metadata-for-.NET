// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2019 GroupDocs. All Rights Reserved.
// </copyright>

namespace GroupDocs.Metadata.Examples.CSharp.AdvancedUsage.WorkingWithMetadataStandards.Iptc
{
    using System;
    using Standards.Iptc;

    /// <summary>
    /// This code sample shows how to update basic IPTC metadata properties.
    /// </summary>
    public static class UpdateIptcProperties
    {
        public static void Run()
        {
            Console.WriteLine("\n--------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("[Example Advanced Usage] # UpdateIptcProperties : How to update basic IPTC metadata properties.\n");
            using (Metadata metadata = new Metadata(Constants.InputJpeg))
            {
                IIptc root = metadata.GetRootPackage() as IIptc;
                if (root != null)
                {
                    // Set the IPTC package if it's missing
                    if (root.IptcPackage == null)
                    {
                        root.IptcPackage = new IptcRecordSet();
                    }

                    if (root.IptcPackage.EnvelopeRecord == null)
                    {
                        root.IptcPackage.EnvelopeRecord = new IptcEnvelopeRecord();
                    }

                    root.IptcPackage.EnvelopeRecord.DateSent = DateTime.Now;
                    root.IptcPackage.EnvelopeRecord.ProductID = Guid.NewGuid().ToString();

                    // ...

                    if (root.IptcPackage.ApplicationRecord == null)
                    {
                        root.IptcPackage.ApplicationRecord = new IptcApplicationRecord();
                    }

                    root.IptcPackage.ApplicationRecord.ByLine = "GroupDocs";
                    root.IptcPackage.ApplicationRecord.Headline = "test";
                    root.IptcPackage.ApplicationRecord.ByLineTitle = "code sample";
                    root.IptcPackage.ApplicationRecord.ReleaseDate = DateTime.Today;

                    // ...

                    metadata.Save(Constants.OutputJpeg);
                }
            }
        }
    }
}
