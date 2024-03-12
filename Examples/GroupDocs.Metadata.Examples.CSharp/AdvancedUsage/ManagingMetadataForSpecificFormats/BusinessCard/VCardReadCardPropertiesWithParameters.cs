// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2024 GroupDocs. All Rights Reserved.
// </copyright>

namespace GroupDocs.Metadata.Examples.CSharp.AdvancedUsage.ManagingMetadataForSpecificFormats.BusinessCard
{
    using System;
    using Formats.BusinessCard;

    /// <summary>
    /// This code sample demonstrates how to extract vCard fields along with descriptive parameters.
    /// </summary>
    public static class VCardReadCardPropertiesWithParameters
    {
        public static void Run()
        {
            Console.WriteLine("\n--------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("[Example Advanced Usage] # VCardReadCardPropertiesWithParameters : How to extract vCard fields along with descriptive parameters.\n");
            using (Metadata metadata = new Metadata(Constants.InputVcf))
            {
                var root = metadata.GetRootPackage<VCardRootPackage>();

                foreach (var vCard in root.VCardPackage.Cards)
                {
                    if (vCard.IdentificationRecordset.PhotoUriRecords != null)
                    {
                        // Iterate all photos represented by URIs
                        foreach (var photoUriRecord in vCard.IdentificationRecordset.PhotoUriRecords)
                        {
                            // Print the property value
                            Console.WriteLine(photoUriRecord.Value);

                            // Print some additional parameters of the property
                            Console.WriteLine(photoUriRecord.ContentType);
                            Console.WriteLine(photoUriRecord.MediaTypeParameter);
                            if (photoUriRecord.TypeParameters != null)
                            {
                                foreach (string parameter in photoUriRecord.TypeParameters)
                                {
                                    Console.WriteLine(parameter);
                                }
                            }
                            Console.WriteLine(photoUriRecord.PrefParameter);
                        }
                    }
                }
            }
        }
    }
}
