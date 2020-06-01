// <copyright company="Aspose Pty Ltd">
//  Copyright (C) 2011-2020 GroupDocs. All Rights Reserved.
// </copyright>

namespace GroupDocs.Metadata.Examples.CSharp.AdvancedUsage.ManagingMetadataForSpecificFormats.Email
{
    using System;
    using Formats.Email;

    /// <summary>
    /// This code sample shows how to extract metadata from an MSG message.
    /// </summary>
    public static class MsgReadNativeMetadataProperties
    {
        public static void Run()
        {
            using (Metadata metadata = new Metadata(Constants.InputMsg))
            {
                var root = metadata.GetRootPackage<MsgRootPackage>();

                Console.WriteLine(root.EmailPackage.Sender);
                Console.WriteLine(root.EmailPackage.Subject);
                foreach (string recipient in root.EmailPackage.Recipients)
                {
                    Console.WriteLine(recipient);
                }

                foreach (var attachedFileName in root.EmailPackage.AttachedFileNames)
                {
                    Console.WriteLine(attachedFileName);
                }

                foreach (var header in root.EmailPackage.Headers)
                {
                    Console.WriteLine("{0} = {1}", header.Name, header.Value);
                }

                Console.WriteLine(root.EmailPackage.Body);
                Console.WriteLine(root.EmailPackage.DeliveryTime);

                // ...
            }
        }
    }
}
