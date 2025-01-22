// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2025 GroupDocs. All Rights Reserved.
// </copyright>

using System;

namespace GroupDocs.Metadata.Examples.CSharp.AdvancedUsage.SavingFiles
{
    /// <summary>
    /// This example shows how to save a document to the specified location.
    /// </summary>
    public static class SaveFileToSpecifiedLocation
    {
        public static void Run()
        {
            Console.WriteLine("\n--------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("[Example Advanced Usage] # SaveFileToSpecifiedLocation : How to save a document to the specified location.\n");
            // Constants.InputJpeg is an absolute or relative path to your document. Ex: @"C:\Docs\test.jpg"
            using (Metadata metadata = new Metadata(Constants.InputJpeg))
            {
                // Edit or remove metadata here

                metadata.Save(Constants.OutputJpeg);
            }
        }
    }
}
