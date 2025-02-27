// <copyright company="Aspose Pty Ltd">
//  Copyright (C) 2011-2025 GroupDocs. All Rights Reserved.
// </copyright>

namespace GroupDocs.Metadata.Examples.CSharp.AdvancedUsage.ManagingMetadataForSpecificFormats.Email
{
    using Formats.Email;
    using GroupDocs.Metadata.Common;
    using System;
    using System.IO;

    /// <summary>
    /// This code sample shows how to update fields of an email message.
    /// </summary>
    public static class MsgUpdateEmailFields
    {
        public static void Run()
        {
            Console.WriteLine("\n--------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("[Example Advanced Usage] # MsgUpdateEmailFields : How to update fields of an email message.\n");

            var senderEmail = "sender@sender.com";
            var deliveryTime = DateTime.Now;
            var headerName = "X-Custom-Header";
            var headerValue = "Custom Value";

            var headerNameChange = "X-MS-Exchange-Transport-EndToEndLatency";
            var headerValueChange = "Custom Value";

            var headerSIDName = "X-SID-Result";
            var headerSIDValue = "PASS";

            var body = "text";
            var senderName = "sender";

            var categories = new string[] {"test1", "test2"};

            var name = "tree.jpg";
            var attachmentPath = Constants.AttachmentJpg;
            byte[] bytes;

            

            using (Metadata metadata = new Metadata(Constants.InputMsg))
            {
                var root = metadata.GetRootPackage<MsgRootPackage>();

                Console.WriteLine("SenderEmailAddress before: {0}", root.EmailPackage.SenderEmailAddress);

                root.EmailPackage.SenderEmailAddress = senderEmail;

                Console.WriteLine("SenderName before: {0}", root.EmailPackage.SenderName);

                root.EmailPackage.SenderName = senderName;

                Console.WriteLine("Delivery Time before: {0}", root.EmailPackage.DeliveryTime);

                root.EmailPackage.DeliveryTime = deliveryTime;

                foreach (var header in root.EmailPackage.Headers)
                {
                    Console.WriteLine("Header before: name - {0}, value = {1}", header.Name, header.InterpretedValue.ToString());
                }

                if (root.EmailPackage.Categories != null) 
                    foreach (var category in root.EmailPackage.Categories)
                    {
                        Console.WriteLine("Category before: {0}", category);
                    }

                foreach (var att in root.EmailPackage.Attachments)
                {
                    Console.WriteLine("Attachment before: name - {0}, length = {1}", att.Name, att.Content.Length);
                }

                root.EmailPackage.Categories = categories;

                root.EmailPackage.Headers.Set(headerName, new PropertyValue(headerValue));
                root.EmailPackage.Headers.Set(headerNameChange, new PropertyValue(headerValueChange));
                root.EmailPackage.Headers.Set(headerSIDName, new PropertyValue(headerSIDValue));

                Console.WriteLine("Body before: {0}", root.EmailPackage.Body);

                root.EmailPackage.Body = body;

                using (FileStream fsSource = new FileStream(attachmentPath,
                           FileMode.Open, FileAccess.Read))
                {
                    bytes = new byte[fsSource.Length];
                    var attachments = new MsgAttachmentPackage[1];
                    attachments[0] = new MsgAttachmentPackage(name, bytes);
                    root.EmailPackage.Attachments = attachments;
                }

                metadata.Save(Constants.OutputMsg);
            }

            using (Metadata metadata = new Metadata(Constants.OutputMsg))
            {
                var root = metadata.GetRootPackage<MsgRootPackage>();

                Console.WriteLine("SenderEmailAddress after: {0}", root.EmailPackage.SenderEmailAddress);

                Console.WriteLine("SenderName after: {0}", root.EmailPackage.SenderName);

                Console.WriteLine("Delivery Time after: {0}", root.EmailPackage.DeliveryTime);

                Console.WriteLine("Body after: {0}", root.EmailPackage.Body);

                foreach (var header in root.EmailPackage.Headers)
                {
                    Console.WriteLine("Header after: name - {0}, value = {1}", header.Name, header.Value.RawValue.ToString());
                }

                if (root.EmailPackage.Categories != null) 
                    foreach (var category in root.EmailPackage.Categories)
                    {
                        Console.WriteLine("Category after: {0}", category);
                    }

                foreach (var att in root.EmailPackage.Attachments)
                {
                    Console.WriteLine("Attachment after: name - {0}, length = {1}", att.Name, att.Content.Length);
                }
            }
        }
    }
}
