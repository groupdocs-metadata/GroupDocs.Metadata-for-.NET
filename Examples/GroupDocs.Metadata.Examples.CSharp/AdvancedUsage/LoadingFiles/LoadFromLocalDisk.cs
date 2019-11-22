// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2019 GroupDocs. All Rights Reserved.
// </copyright>

namespace GroupDocs.Metadata.Examples.CSharp.AdvancedUsage.LoadingFiles
{
    /// <summary>
    /// This example demonstrates how to load a file from a local disk.
    /// </summary>
    public static class LoadFromLocalDisk
    {
        public static void Run()
        {
            // Constants.InputOne is an absolute or relative path to your document. Ex: @"C:\Docs\source.one"
            using (Metadata metadata = new Metadata(Constants.InputOne))
            {
                // Extract, edit or remove metadata here
            }
        }
    }
}
