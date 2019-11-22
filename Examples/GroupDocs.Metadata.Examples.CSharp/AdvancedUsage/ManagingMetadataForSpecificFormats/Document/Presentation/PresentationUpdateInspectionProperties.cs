// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2019 GroupDocs. All Rights Reserved.
// </copyright>

namespace GroupDocs.Metadata.Examples.CSharp.AdvancedUsage.ManagingMetadataForSpecificFormats.Document.Presentation
{
    using Formats.Document;

    public static class PresentationUpdateInspectionProperties
    {
        public static void Run()
        {
            using (Metadata metadata = new Metadata(Constants.InputPpt))
            {
                var root = metadata.GetRootPackage<PresentationRootPackage>();

                root.InspectionPackage.ClearComments();
                root.InspectionPackage.ClearHiddenSlides();

                metadata.Save(Constants.OutputPpt);
            }
        }
    }
}
