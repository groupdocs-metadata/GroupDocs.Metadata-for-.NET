// <copyright company="Aspose Pty Ltd">
//  Copyright (C) 2011-2025 GroupDocs. All Rights Reserved.
// </copyright>

namespace GroupDocs.Metadata.Examples.CSharp.AdvancedUsage.ManagingMetadataForSpecificFormats.Email
{
    using Formats.Email;
    using System;

    /// <summary>
    /// This example demonstrates how to remove all attachments from an email.
    /// </summary>
    public static class EmailRemoveAttachments
    {
        public static void Run()
        {
            Console.WriteLine("\n--------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("[Example Advanced Usage] # EmailRemoveAttachments : How to remove all attachments from an email.\n");
            using (Metadata metadata = new Metadata(Constants.InputEml))
            {
                var root = metadata.GetRootPackage<EmailRootPackage>();

                root.ClearAttachments();

                metadata.Save(Constants.OutputEml);
            }
        }
    }
}
