// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2023 GroupDocs. All Rights Reserved.
// </copyright>

namespace GroupDocs.Metadata.Examples.CSharp.AdvancedUsage.SavingFiles
{
    using System.IO;

    /// <summary>
    /// This example shows how to save the modified content to the underlying source.
    /// </summary>
    public static class SaveFileToOriginalSource
    {
        public static void Run()
        {
            // Constants.InputPpt is an absolute or relative path to your document. Ex: @"C:\Docs\test.ppt"
            File.Delete(Constants.OutputPpt);
            File.Copy(Constants.InputPpt, Constants.OutputPpt);
            using (Metadata metadata = new Metadata(Constants.OutputPpt))
            {
                // Edit or remove metadata here

                // Saves the document to the underlying source (stream or file)
                metadata.Save();
            }
        }
    }
}
