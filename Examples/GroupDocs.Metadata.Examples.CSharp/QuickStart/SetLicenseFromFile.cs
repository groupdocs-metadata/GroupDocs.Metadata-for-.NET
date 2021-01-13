﻿// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2021 GroupDocs. All Rights Reserved.
// </copyright>

namespace GroupDocs.Metadata.Examples.CSharp.QuickStart
{
    using System;
    using System.IO;

    /// <summary>
    ///     This example demonstrates how to set license from file.
    /// </summary>
    /// <remarks>
    ///     The SetLicense method attempts to set a license from several locations relative to the executable
    ///     and GroupDocs.Watermark.dll. You can also use the additional overload to load a license from a stream,
    ///     this is useful for instance when the License is stored as an embedded resource.
    /// </remarks>
    public static class SetLicenseFromFile
    {
        public static void Run()
        {
            if (File.Exists(Constants.LicenseFilePath))
            {
                License license = new License();
                license.SetLicense(Constants.LicenseFilePath);

                Console.WriteLine("License set successfully.");
            }
            else
            {
                Console.WriteLine("\nWe do not ship any license with this example. " +
                                  "\nVisit the GroupDocs site to obtain either a temporary or permanent license. " +
                                  "\nLearn more about licensing at https://purchase.groupdocs.com/faqs/licensing. " +
                                  "\nLear how to request temporary license at https://purchase.groupdocs.com/temporary-license.");
            }
        }
    }
}
