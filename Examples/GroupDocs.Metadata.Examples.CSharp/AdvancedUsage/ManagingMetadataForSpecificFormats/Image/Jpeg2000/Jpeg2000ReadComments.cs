// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2019 GroupDocs. All Rights Reserved.
// </copyright>

namespace GroupDocs.Metadata.Examples.CSharp.AdvancedUsage.ManagingMetadataForSpecificFormats.Image.Jpeg2000
{
    using System;
    using Formats.Image;

    /// <summary>
    /// This code snippet demonstrates how to read JPEG2000 image comments.
    /// </summary>
    public static class Jpeg2000ReadComments
    {
        public static void Run()
        {
            using (Metadata metadata = new Metadata(Constants.InputJpeg2000))
            {
                var root = metadata.GetRootPackage<Jpeg2000RootPackage>();

                if (root.Jpeg2000Package.Comments != null)
                {
                    foreach (var comment in root.Jpeg2000Package.Comments)
                    {
                        Console.WriteLine(comment);
                    }
                }
            }
        }
    }
}

