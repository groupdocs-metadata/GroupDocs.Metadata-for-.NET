using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GroupDocs.Metadata.Formats.Email;
using GroupDocs.Metadata.Examples.Utilities.CSharp;

namespace GroupDocs.Metadata.Examples.CSharp
{
    public static class Emails
    {
        public static class OutLook
        {
            // initialize files path
            //ExStart:SourceOutlookFilePath
            private const string filePath = "Emails/Outlook/sample.msg";
            //ExEnd:SourceOutlookFilePath

            /// <summary>
            /// Gets Outlook email file's metadata
            /// </summary>
            public static void GetOutlookEmailMetadata()
            {
                try
                {
                    //ExStart:GetOutlookEmailMessageMetadata
                    // initialize outlookFormat
                    using (OutlookMessage msgFormat = new OutlookMessage(Common.MapSourceFilePath(filePath)))
                    {
                        // get metadata
                        OutlookMessageMetadata metadata = msgFormat.GetMsgInfo();

                        // display metadata
                        Console.WriteLine("Body: " + metadata.Body);
                        Console.WriteLine("DeliveryTime: " + metadata.DeliveryTime);
                        Console.WriteLine("Recipients: " + metadata.Recipients[0]);
                        Console.WriteLine("Subject: " + metadata.Subject);
                        Console.WriteLine("Attachments: " + metadata.Attachments[0]); 
                    }
                    //ExEnd:GetOutlookEmailMessageMetadata
                }
                catch (Exception exp)
                {
                    Console.WriteLine(exp.Message);
                }
            }

            /// <summary>
            /// Removes Outlook email attachments
            /// </summary>
            public static void RemoveOutlookEmailAttachments()
            {
                try
                {
                    //ExStart:RemoveOutlookEmailAttachments
                    // initialize outlookFormat 
                    using (OutlookMessage outlookFormat = new OutlookMessage(Common.MapSourceFilePath(filePath)))
                    {
                        // remove attachments
                        outlookFormat.RemoveAttachments();

                        // commit changes
                        outlookFormat.Save(Common.MapDestinationFilePath(filePath)); 
                    }
                    //ExEnd:RemoveOutlookEmailAttachments
                }
                catch (Exception exp)
                {
                    Console.WriteLine(exp.Message);
                }
            }

            /// <summary>
            /// Removes email metadata
            /// </summary>
            public static void RemoveOutlookEmailMetadata()
            {
                try
                {
                    //ExStart:RemoveOutlookEmailMetadata
                    // initialize outlookFormat 
                    using (OutlookMessage outlookFormat = new OutlookMessage(Common.MapSourceFilePath(filePath)))
                    {
                        // remove metadata
                        outlookFormat.CleanMetadata();

                        // commit changes
                        outlookFormat.Save(Common.MapDestinationFilePath(filePath)); 
                    }
                    //ExEnd:RemoveOutlookEmailMetadata
                }
                catch (Exception exp)
                {
                    Console.WriteLine(exp.Message);
                }
            }
        }

        public static class Eml
        {
            // initialize files path
            //ExStart:SourceEmailFilePath 
            private const string filePath = "Emails/Eml/sample.eml";
            //ExEnd:SourceEmailFilePath

            /// <summary>
            /// Gets email file's metadata
            /// </summary>
            public static void GetEmailMetadata()
            {
                try
                {
                    //ExStart:GetEmailMessageMetadata
                    // initialize EmlFormat 
                    using (EmlFormat emlFormat = new EmlFormat(Common.MapSourceFilePath(filePath)))
                    {
                        // get metadata
                        EmlMetadata metadata = emlFormat.GetEmlInfo();

                        // display metadata
                        Console.WriteLine("CC: " + metadata.CC);
                        Console.WriteLine("Mail Address From: " + metadata.MailAddressFrom);
                        Console.WriteLine("Subject: " + metadata.Subject);
                        Console.WriteLine("Attachments: " + metadata.Attachments[0]); 
                    }
                    //ExEnd:GetEmailMessageMetadata
                }
                catch (Exception exp)
                {
                    Console.WriteLine(exp.Message);
                }
            }
            /// <summary>
            /// Removes email attachments
            /// </summary>
            public static void RemoveEmailAttachments()
            {
                try
                {
                    //ExStart:RemoveEmailAttachments
                    // initialize emlFormat 
                    using (EmlFormat emlFormat = new EmlFormat(Common.MapSourceFilePath(filePath)))
                    {

                        // remove attachments
                        emlFormat.RemoveAttachments();

                        // commit changes
                        emlFormat.Save(Common.MapDestinationFilePath(filePath)); 
                    }
                    //ExEnd:RemoveEmailAttachments
                }
                catch (Exception exp)
                {
                    Console.WriteLine(exp.Message);
                }
            }
            /// <summary>
            /// Removes email metadata
            /// </summary>
            public static void RemoveEmailMetadata()
            {
                try
                {
                    //ExStart:RemoveEmailMetadata
                    // initialize emlFormat 
                    using (EmlFormat emlFormat = new EmlFormat(Common.MapSourceFilePath(filePath)))
                    {
                        // remove metadata
                        emlFormat.CleanMetadata();

                        // commit changes
                        emlFormat.Save(Common.MapDestinationFilePath(filePath)); 
                    }
                    //ExEnd:RemoveEmailMetadata
                }
                catch (Exception exp)
                {
                    Console.WriteLine(exp.Message);
                }
            }
        }
    }
}
