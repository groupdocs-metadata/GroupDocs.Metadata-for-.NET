// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2021 GroupDocs. All Rights Reserved.
// </copyright>

namespace GroupDocs.Metadata.Examples.CSharp.AdvancedUsage.ManagingMetadataForSpecificFormats.BusinessCard
{
    using System;
    using Formats.BusinessCard;

    /// <summary>
    /// This code sample demonstrates how to read metadata properties of a vCard file.
    /// </summary>
    public static class VCardReadCardProperties
    {
        public static void Run()
        {
            using (Metadata metadata = new Metadata(Constants.InputVcf))
            {
                var root = metadata.GetRootPackage<VCardRootPackage>();

                foreach (var vCard in root.VCardPackage.Cards)
                {
                    Console.WriteLine(vCard.IdentificationRecordset.Name);
                    PrintArray(vCard.IdentificationRecordset.FormattedNames);
                    PrintArray(vCard.CommunicationRecordset.Emails);
                    PrintArray(vCard.CommunicationRecordset.Telephones);
                    PrintArray(vCard.DeliveryAddressingRecordset.Addresses);

                    // ...
                }
            }
        }

        private static void PrintArray(string[] values)
        {
            if (values != null)
            {
                foreach (string value in values)
                {
                    Console.WriteLine(value);
                }
            }
        }
    }
}
