// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2025 GroupDocs. All Rights Reserved.
// </copyright>

namespace GroupDocs.Metadata.Examples.CSharp.AdvancedUsage.LoadingFiles
{
    using System;
    using System.IO;

    /// <summary>
    /// This example demonstrates how to load a file from a stream.
    /// </summary>
    public static class LoadFromStream
    {
        public static void Run()
        {
            Console.WriteLine("\n--------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("[Example Advanced Usage] # LoadFromStream : How to load a file from a stream\n");
            // Constants.InputDoc is an absolute or relative path to your document. Ex: @"C:\Docs\source.doc"
            using (Stream stream = File.Open(Constants.InputDoc, FileMode.Open, FileAccess.ReadWrite))
            using (Metadata metadata = new Metadata(stream))
            {
                // Extract, edit or remove metadata here
            }
        }
    }
}
