// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2024 GroupDocs. All Rights Reserved.
// </copyright>

namespace GroupDocs.Metadata.Examples.CSharp.BasicUsage
{
    using System;
    using System.IO;
    using Options;

    /// <summary>
    /// This code snippet demonstrates how to create image previews for document pages.
    /// </summary>
    public class GenerateFilePreview
    {
        public static void Run()
        {
            Console.WriteLine("\n--------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("[Example Basic Usage] # GenerateFilePreview : How to create image previews for document pages.\n");
            using (Metadata metadata = new Metadata(Constants.InputDocx))
            {
                PreviewOptions previewOptions = new PreviewOptions(pageNumber => File.Create($"{Constants.OutputPath}\\result_{pageNumber}.png"));
                previewOptions.PreviewFormat = PreviewOptions.PreviewFormats.PNG;
                previewOptions.PageNumbers = new int[] { 1 };
                metadata.GeneratePreview(previewOptions);
            }
        }
    }
}
