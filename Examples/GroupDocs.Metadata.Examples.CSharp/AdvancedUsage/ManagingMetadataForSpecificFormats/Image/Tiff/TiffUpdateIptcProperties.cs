// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2026 GroupDocs. All Rights Reserved.
// </copyright>

namespace GroupDocs.Metadata.Examples.CSharp.AdvancedUsage.ManagingMetadataForSpecificFormats.Image.Tiff
{
    using System;
    using Standards.Iptc;

    /// <summary>
    /// This code sample demonstrates how to update IPTC metadata properties in a TIFF image.
    /// </summary>
    public static class TiffUpdateIptcProperties
    {
        public static void Run()
        {
            Console.WriteLine("\n--------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("[Example Advanced Usage] # TiffUpdateIptcProperties : How to update IPTC metadata properties in a TIFF image.\n");
            using (Metadata metadata = new Metadata(Constants.TiffWithIptc))
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
                    root.IptcPackage.ApplicationRecord.Headline = "test headline";
                    root.IptcPackage.ApplicationRecord.ByLineTitle = "code sample";
                    root.IptcPackage.ApplicationRecord.ReleaseDate = DateTime.Today;
                    root.IptcPackage.ApplicationRecord.City = "New York";
                    root.IptcPackage.ApplicationRecord.CaptionAbstract = "test caption";

                    // ...

                    metadata.Save(Constants.OutputTiff);
                }
            }
        }
    }
}
