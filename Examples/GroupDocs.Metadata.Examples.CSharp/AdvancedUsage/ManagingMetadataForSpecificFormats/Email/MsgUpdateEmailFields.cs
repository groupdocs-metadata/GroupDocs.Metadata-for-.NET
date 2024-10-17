// <copyright company="Aspose Pty Ltd">
//  Copyright (C) 2011-2024 GroupDocs. All Rights Reserved.
// </copyright>

namespace GroupDocs.Metadata.Examples.CSharp.AdvancedUsage.ManagingMetadataForSpecificFormats.Email
{
    using Formats.Email;
    using GroupDocs.Metadata.Common;
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

            var sender = "sender@sender.com";
            var deliveryTime = DateTime.Now;
            var headerName = "X-Custom-Header";
            var headerValue = "Custom Value";

            var headerNameChange = "X-MS-Exchange-Transport-EndToEndLatency";
            var headerValueChange = "Custom Value";

            var headerSIDName = "X-SID-Result";
            var headerSIDValue = "PASS";

            using (Metadata metadata = new Metadata(Constants.InputMsg))
            {
                var root = metadata.GetRootPackage<MsgRootPackage>();

                Console.WriteLine("Sender before: {0}", root.EmailPackage.Sender);

                root.EmailPackage.Sender = sender;

                Console.WriteLine("Delivery Time before: {0}", root.EmailPackage.DeliveryTime);

                root.EmailPackage.DeliveryTime = deliveryTime;

                foreach (var header in root.EmailPackage.Headers)
                {
                    Console.WriteLine("Header before: name - {0}, value = {1}", header.Name, header.InterpretedValue.ToString());
                }

                root.EmailPackage.Headers.Set(headerName, new PropertyValue(headerValue));
                root.EmailPackage.Headers.Set(headerNameChange, new PropertyValue(headerValueChange));
                root.EmailPackage.Headers.Set(headerSIDName, new PropertyValue(headerSIDValue));

                metadata.Save(Constants.OutputMsg);
            }

            using (Metadata metadata = new Metadata(Constants.OutputMsg))
            {
                var root = metadata.GetRootPackage<MsgRootPackage>();

                Console.WriteLine("Sender after: {0}", root.EmailPackage.Sender);

                Console.WriteLine("Delivery Time after: {0}", root.EmailPackage.DeliveryTime);

                foreach (var header in root.EmailPackage.Headers)
                {
                    Console.WriteLine("Header after: name - {0}, value = {1}", header.Name, header.Value.RawValue.ToString());
                }
            }
        }
    }
}
