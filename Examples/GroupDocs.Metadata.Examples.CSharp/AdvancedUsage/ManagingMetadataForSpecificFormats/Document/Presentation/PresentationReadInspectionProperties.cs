// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2019 GroupDocs. All Rights Reserved.
// </copyright>

namespace GroupDocs.Metadata.Examples.CSharp.AdvancedUsage.ManagingMetadataForSpecificFormats.Document.Presentation
{
    using System;
    using Formats.Document;

    /// <summary>
    /// This code sample demonstrates how to inspect a presentation.
    /// </summary>
    public static class PresentationReadInspectionProperties
    {
        public static void Run()
        {
            using (Metadata metadata = new Metadata(Constants.InputPpt))
            {
                var root = metadata.GetRootPackage<PresentationRootPackage>();

                if (root.InspectionPackage.Comments != null)
                {
                    foreach (var comment in root.InspectionPackage.Comments)
                    {
                        Console.WriteLine(comment.Author);
                        Console.WriteLine(comment.Text);
                        Console.WriteLine(comment.CreatedTime);
                        Console.WriteLine(comment.SlideNumber);
                    }
                }

                if (root.InspectionPackage.HiddenSlides != null)
                {
                    foreach (var slide in root.InspectionPackage.HiddenSlides)
                    {
                        Console.WriteLine(slide.Name);
                        Console.WriteLine(slide.Number);
                        Console.WriteLine(slide.SlideId);
                    }
                }
            }
        }
    }
}
