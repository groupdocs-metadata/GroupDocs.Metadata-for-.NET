// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2021 GroupDocs. All Rights Reserved.
// </copyright>

namespace GroupDocs.Metadata.Examples.CSharp.BasicUsage
{
    using System;
    using Common;

    /// <summary>
    /// This example demonstrates how to extract basic format information from a file.
    /// </summary>
    public static class GetDocumentInfo
    {
        public static void Run()
        {
            // Constants.InputXlsx is an absolute or relative path to your document. Ex: @"C:\Docs\source.xlsx"
            using (Metadata metadata = new Metadata(Constants.InputXlsx))
            {
                if (metadata.FileFormat != FileFormat.Unknown)
                {
                    IDocumentInfo info = metadata.GetDocumentInfo();
                    Console.WriteLine("File format: {0}", info.FileType.FileFormat);
                    Console.WriteLine("File extension: {0}", info.FileType.Extension);
                    Console.WriteLine("MIME Type: {0}", info.FileType.MimeType);
                    Console.WriteLine("Number of pages: {0}", info.PageCount);
                    Console.WriteLine("Document size: {0} bytes", info.Size);
                    Console.WriteLine("Is document encrypted: {0}", info.IsEncrypted);
                }
            }
        }
    }
}
