// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2020 GroupDocs. All Rights Reserved.
// </copyright>

namespace GroupDocs.Metadata.Examples.CSharp.AdvancedUsage.ManagingMetadataForSpecificFormats.Document.WordProcessing
{
    using System;
    using Formats.Document;

    /// <summary>
    /// This code sample shows how to inspect a WordProcessing document.
    /// </summary>
    public static class WordProcessingReadInspectionProperties
    {
        public static void Run()
        {
            using (Metadata metadata = new Metadata(Constants.InputDocx))
            {
                var root = metadata.GetRootPackage<WordProcessingRootPackage>();

                if (root.InspectionPackage.Comments != null)
                {
                    foreach (var comment in root.InspectionPackage.Comments)
                    {
                        Console.WriteLine(comment.Author);
                        Console.WriteLine(comment.CreatedDate);
                        Console.WriteLine(comment.Text);

                        // ... 

                    }
                }

                if (root.InspectionPackage.DigitalSignatures != null)
                {
                    foreach (var signature in root.InspectionPackage.DigitalSignatures)
                    {
                        Console.WriteLine(signature.CertificateSubject);
                        Console.WriteLine(signature.Comments);
                        Console.WriteLine(signature.SignTime);

                        // ...
                    }
                }

                if (root.InspectionPackage.Fields != null)
                {
                    foreach (var field in root.InspectionPackage.Fields)
                    {
                        Console.WriteLine(field.Code);
                        Console.WriteLine(field.Result);
                    }
                }

                if (root.InspectionPackage.HiddenText != null)
                {
                    foreach (var textFragment in root.InspectionPackage.HiddenText)
                    {
                        Console.WriteLine(textFragment);
                    }
                }

                if (root.InspectionPackage.Revisions != null)
                {
                    foreach (var revision in root.InspectionPackage.Revisions)
                    {
                        Console.WriteLine(revision.Author);
                        Console.WriteLine(revision.DateTime);
                        Console.WriteLine(revision.RevisionType);
                    }
                }
            }
        }
    }
}
