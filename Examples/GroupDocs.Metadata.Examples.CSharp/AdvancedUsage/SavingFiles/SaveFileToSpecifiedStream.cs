// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2019 GroupDocs. All Rights Reserved.
// </copyright>

namespace GroupDocs.Metadata.Examples.CSharp.AdvancedUsage.SavingFiles
{
    using System.IO;

    /// <summary>
    /// This example shows how to save a document to the specified stream.
    /// </summary>
    public static class SaveFileToSpecifiedStream
    {
        public static void Run()
        {
            using (MemoryStream stream = new MemoryStream())
            {
                // Constants.InputPng is an absolute or relative path to your document. Ex: @"C:\Docs\test.png"
                using (Metadata metadata = new Metadata(Constants.InputPng))
                {
                    // Edit or remove metadata here

                    metadata.Save(stream);
                }
            }
        }
    }
}
