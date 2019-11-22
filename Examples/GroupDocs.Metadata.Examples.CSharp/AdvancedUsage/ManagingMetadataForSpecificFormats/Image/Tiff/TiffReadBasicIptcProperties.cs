// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2019 GroupDocs. All Rights Reserved.
// </copyright>

namespace GroupDocs.Metadata.Examples.CSharp.AdvancedUsage.ManagingMetadataForSpecificFormats.Image.Tiff
{
    using System;
    using Formats.Image;

    /// <summary>
    /// This example shows how to extract basic IPTC metadata properties from a TIFF image.
    /// </summary>
    public class TiffReadBasicIptcProperties
    {
        public static void Run()
        {
            using (Metadata metadata = new Metadata(Constants.TiffWithIptc))
            {
                var root = metadata.GetRootPackage<TiffRootPackage>();
                if (root.IptcPackage != null)
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
