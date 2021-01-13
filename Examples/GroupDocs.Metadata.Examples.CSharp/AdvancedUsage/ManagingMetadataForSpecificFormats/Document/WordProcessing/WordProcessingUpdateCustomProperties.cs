// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2021 GroupDocs. All Rights Reserved.
// </copyright>

namespace GroupDocs.Metadata.Examples.CSharp.AdvancedUsage.ManagingMetadataForSpecificFormats.Document.WordProcessing
{
    using Formats.Document;

    /// <summary>
    /// This code sample shows how to update custom metadata properties in a WordProcessing document.
    /// </summary>
    public static class WordProcessingUpdateCustomProperties
    {
        public static void Run()
        {
            using (Metadata metadata = new Metadata(Constants.InputDocx))
            {
                var root = metadata.GetRootPackage<WordProcessingRootPackage>();

                root.DocumentProperties.Set("customProperty1", "some value");
                root.DocumentProperties.Set("customProperty2", 7);

                metadata.Save(Constants.OutputDocx);
            }
        }
    }
}
