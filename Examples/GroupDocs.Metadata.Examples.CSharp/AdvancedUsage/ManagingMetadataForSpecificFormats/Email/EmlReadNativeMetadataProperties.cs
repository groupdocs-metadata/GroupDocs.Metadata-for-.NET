﻿// <copyright company="Aspose Pty Ltd">
//  Copyright (C) 2011-2025 GroupDocs. All Rights Reserved.
// </copyright>

namespace GroupDocs.Metadata.Examples.CSharp.AdvancedUsage.ManagingMetadataForSpecificFormats.Email
{
    using System;
    using Formats.Email;

    /// <summary>
    /// This code sample shows how to extract metadata from an EML message.
    /// </summary>
    public static class EmlReadNativeMetadataProperties
    {
        public static void Run()
        {
            Console.WriteLine("\n--------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("[Example Advanced Usage] # EmlReadNativeMetadataProperties : How to extract metadata from an EML message.\n");
            using (Metadata metadata = new Metadata(Constants.InputEml))
            {
                var root = metadata.GetRootPackage<EmlRootPackage>();

                Console.WriteLine(root.EmailPackage.SenderEmailAddress);
                Console.WriteLine(root.EmailPackage.Subject);
                foreach (string recipient in root.EmailPackage.Recipients)
                {
                    Console.WriteLine(recipient);
                }

                foreach (var attachment in root.EmailPackage.Attachments)
                {
                    Console.WriteLine(attachment.Name);
                }

                foreach (var header in root.EmailPackage.Headers)
                {
                    Console.WriteLine("{0} = {1}", header.Name, header.Value);
                }

                // ...
            }
        }
    }
}
