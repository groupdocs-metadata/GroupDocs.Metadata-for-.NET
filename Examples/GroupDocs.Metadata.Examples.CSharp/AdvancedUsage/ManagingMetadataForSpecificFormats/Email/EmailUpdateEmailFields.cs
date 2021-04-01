// <copyright company="Aspose Pty Ltd">
//  Copyright (C) 2011-2021 GroupDocs. All Rights Reserved.
// </copyright>

namespace GroupDocs.Metadata.Examples.CSharp.AdvancedUsage.ManagingMetadataForSpecificFormats.Email
{
    using Formats.Email;

    /// <summary>
    /// This code sample shows how to update fields of an email message.
    /// </summary>
    public static class EmailUpdateEmailFields
    {
        public static void Run()
        {
            using (Metadata metadata = new Metadata(Constants.InputEml))
            {
                var root = metadata.GetRootPackage<EmailRootPackage>();

                root.EmailPackage.Recipients = new string[] { "sample@aspose.com" };
                root.EmailPackage.CarbonCopyRecipients = new string[] { "sample@groupdocs.com" };
                root.EmailPackage.Subject = "RE: test subject";

                metadata.Save(Constants.OutputEml);
            }
        }
    }
}
