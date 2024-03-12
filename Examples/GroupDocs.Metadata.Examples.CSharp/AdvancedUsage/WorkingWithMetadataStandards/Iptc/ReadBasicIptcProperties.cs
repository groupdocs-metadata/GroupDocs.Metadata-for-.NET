// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2024 GroupDocs. All Rights Reserved.
// </copyright>

namespace GroupDocs.Metadata.Examples.CSharp.AdvancedUsage.WorkingWithMetadataStandards.Iptc
{
    using System;
    using Standards.Iptc;

    /// <summary>
    /// This example shows how to read basic IPTC metadata properties.
    /// </summary>
    public static class ReadBasicIptcProperties
    {
        public static void Run()
        {
            Console.WriteLine("\n--------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("[Example Advanced Usage] # ReadBasicIptcProperties : How to read basic IPTC metadata properties.\n");
            using (Metadata metadata = new Metadata(Constants.JpegWithIptc))
            {
                IIptc root = metadata.GetRootPackage() as IIptc;
                if (root != null && root.IptcPackage != null)
                {
                    if (root.IptcPackage.EnvelopeRecord != null)
                    {
                        Console.WriteLine(root.IptcPackage.EnvelopeRecord.DateSent);
                        Console.WriteLine(root.IptcPackage.EnvelopeRecord.Destination);
                        Console.WriteLine(root.IptcPackage.EnvelopeRecord.FileFormat);
                        Console.WriteLine(root.IptcPackage.EnvelopeRecord.FileFormatVersion);

                        // ...
                    }

                    if (root.IptcPackage.ApplicationRecord != null)
                    {
                        Console.WriteLine(root.IptcPackage.ApplicationRecord.Headline);
                        Console.WriteLine(root.IptcPackage.ApplicationRecord.ByLine);
                        Console.WriteLine(root.IptcPackage.ApplicationRecord.ByLineTitle);
                        Console.WriteLine(root.IptcPackage.ApplicationRecord.CaptionAbstract);
                        Console.WriteLine(root.IptcPackage.ApplicationRecord.City);
                        Console.WriteLine(root.IptcPackage.ApplicationRecord.DateCreated);
                        Console.WriteLine(root.IptcPackage.ApplicationRecord.ReleaseDate);

                        // ...
                    }
                }
            }
        }
    }
}
