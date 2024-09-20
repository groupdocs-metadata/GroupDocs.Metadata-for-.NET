// <copyright company="Aspose Pty Ltd">
//  Copyright (C) 2011-2024 GroupDocs. All Rights Reserved.
// </copyright>

namespace GroupDocs.Metadata.Examples.CSharp.AdvancedUsage.ManagingMetadataForSpecificFormats.Email
{
    using Formats.Email;
    using System;

    /// <summary>
    /// This code sample shows how to update fields of an email message.
    /// </summary>
    public static class MsgUpdateEmailFields
    {
        public static void Run()
        {
            Console.WriteLine("\n--------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("[Example Advanced Usage] # MsgUpdateEmailFields : How to update fields of an email message.\n");
            using (Metadata metadata = new Metadata(Constants.InputMsg))
            {
                var root = metadata.GetRootPackage<MsgRootPackage>();

                Console.WriteLine("Sender before: {0}", root.EmailPackage.Sender);

                root.EmailPackage.Sender = "sample@aspose.com";

                metadata.Save(Constants.OutputMsg);
            }

            using (Metadata metadata = new Metadata(Constants.OutputMsg))
            {
                var root = metadata.GetRootPackage<MsgRootPackage>();

                Console.WriteLine("Sender after: {0}", root.EmailPackage.Sender);
            }
        }
    }
}
