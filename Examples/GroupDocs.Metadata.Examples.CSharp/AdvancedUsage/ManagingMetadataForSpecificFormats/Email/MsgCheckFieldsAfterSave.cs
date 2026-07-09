// <copyright company="Aspose Pty Ltd">
//  Copyright (C) 2011-2026 GroupDocs. All Rights Reserved.
// </copyright>

using GroupDocs.Metadata.Formats.Email.Msg;

namespace GroupDocs.Metadata.Examples.CSharp.AdvancedUsage.ManagingMetadataForSpecificFormats.Email
{
    using Formats.Email;
    using GroupDocs.Metadata.Common;
    using System;
    using System.Diagnostics;
    using System.IO;

    /// <summary>
    /// This code sample shows how to update fields of an email message.
    /// </summary>
    public static class MsgCheckFieldsAfterSave
    {
        public static void Run()
        {
            string destFile = @"C:\Download\msg-comparison-tool\msg-comparison-tool\bin\Debug\net8.0\example.msg";

            // The third parameter 'true' allows overwriting the file if it already exists
            //File.Copy(Constants.InputMsg, destFile, true);
            using (Metadata metadata = new Metadata(@"C:\Work\git\git.saltov.dynabic.com\groupdocs\bravo\metadata\GroupDocs.Metadata.Net\test-out\GroupDocs.Metadata.Temp\test.msg"))
            {
                var root = metadata.GetRootPackage<MsgRootPackage>();
                MsgPackage msg = root.EmailPackage;
                metadata.Save();

            }
        }
    }
}
