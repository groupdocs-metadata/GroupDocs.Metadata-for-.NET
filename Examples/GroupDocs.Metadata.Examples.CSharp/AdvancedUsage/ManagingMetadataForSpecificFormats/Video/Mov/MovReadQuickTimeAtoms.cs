// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2025 GroupDocs. All Rights Reserved.
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
            Console.WriteLine("\n--------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("[Example Advanced Usage] # MovReadQuickTimeAtoms : How to read QuickTime atoms in a MOV video.\n");
            using (Metadata metadata = new Metadata(Constants.InputMov))
            {
                var root = metadata.GetRootPackage<MovRootPackage>();

                Console.WriteLine(root.MovPackage.Copyright);

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
