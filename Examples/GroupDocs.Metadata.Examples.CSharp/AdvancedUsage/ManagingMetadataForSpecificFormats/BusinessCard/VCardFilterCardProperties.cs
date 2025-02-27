﻿// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2025 GroupDocs. All Rights Reserved.
// </copyright>

namespace GroupDocs.Metadata.Examples.CSharp.AdvancedUsage.ManagingMetadataForSpecificFormats.BusinessCard
{
    using System;
    using Formats.BusinessCard;

    /// <summary>
    /// This example shows how to use vCard property filters.
    /// </summary>
    public static class VCardFilterCardProperties
    {
        public static void Run()
        {
            Console.WriteLine("\n--------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("[Example Advanced Usage] # VCardFilterCardProperties : How to use vCard property filters.\n");
            using (Metadata metadata = new Metadata(Constants.InputVcf))
            {
                var root = metadata.GetRootPackage<VCardRootPackage>();

                foreach (var vCard in root.VCardPackage.Cards)
                {
                    // Print most preferred work phone numbers and work emails
                    var filtered = vCard.FilterWorkTags().FilterPreferred();
                    PrintArray(filtered.CommunicationRecordset.Telephones);
                    PrintArray(filtered.CommunicationRecordset.Emails);
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
