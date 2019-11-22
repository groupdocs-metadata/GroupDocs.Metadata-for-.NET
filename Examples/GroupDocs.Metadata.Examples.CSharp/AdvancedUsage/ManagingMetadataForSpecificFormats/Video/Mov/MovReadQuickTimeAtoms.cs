// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2019 GroupDocs. All Rights Reserved.
// </copyright>

namespace GroupDocs.Metadata.Examples.CSharp.AdvancedUsage.ManagingMetadataForSpecificFormats.Video.Mov
{
    using System;
    using Formats.Video;

    /// <summary>
    /// This example shows how to read QuickTime atoms in a MOV video.
    /// </summary>
    public static class MovReadQuickTimeAtoms
    {
        public static void Run()
        {
            using (Metadata metadata = new Metadata(Constants.InputMov))
            {
                var root = metadata.GetRootPackage<MovRootPackage>();

                foreach (var atom in root.MovPackage.Atoms)
                {
                    Console.WriteLine(atom.Type);
                    Console.WriteLine(atom.Offset);
                    Console.WriteLine(atom.Size);

                    // ...
                }
            }
        }
    }
}
