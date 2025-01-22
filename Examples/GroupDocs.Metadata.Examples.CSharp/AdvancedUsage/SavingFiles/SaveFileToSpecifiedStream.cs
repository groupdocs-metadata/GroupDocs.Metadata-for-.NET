// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2025 GroupDocs. All Rights Reserved.
// </copyright>

namespace GroupDocs.Metadata.Examples.CSharp.AdvancedUsage.SavingFiles
{
    using System;
    using System.IO;

    /// <summary>
    /// This example shows how to save a document to the specified stream.
    /// </summary>
    public static class SaveFileToSpecifiedStream
    {
        public static void Run()
        {
            Console.WriteLine("\n--------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("[Example Advanced Usage] # SaveFileToSpecifiedStream : How to save a document to the specified stream.\n");
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
