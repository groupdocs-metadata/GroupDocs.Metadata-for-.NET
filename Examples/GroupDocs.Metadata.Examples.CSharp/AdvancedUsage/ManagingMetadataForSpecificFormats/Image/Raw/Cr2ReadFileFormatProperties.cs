// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2024 GroupDocs. All Rights Reserved.
// </copyright>

namespace GroupDocs.Metadata.Examples.CSharp.AdvancedUsage.ManagingMetadataForSpecificFormats.Image.Raw
{
    using System;
    using GroupDocs.Metadata.Formats.Raw.Cr2;
    using GroupDocs.Metadata.Formats.Raw.Tag;
    /// <summary>
    /// This code sample demonstrates how to get metadata from a Cr2 file.
    /// </summary>
    public static class Cr2ReadFileFormatProperties
    {
        public static void Run()
        {
            Console.WriteLine("\n--------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("[Example Advanced Usage] # Cr2ReadFileFormatProperties : How to get metadata from a Cr2 file.\n");
            using (Metadata metadata = new Metadata(Constants.InputCr2))
            {
                var root = metadata.GetRootPackage<Cr2RootPackage>();

                Console.WriteLine(root.FileType.FileFormat);
                Console.WriteLine(root.Cr2Package.RawTiffTagPackage.Artist);
                Console.WriteLine(root.Cr2Package.RawTiffTagPackage.Copyright);
                Console.WriteLine(root.Cr2Package.RawTiffTagPackage.RawExifTagPackage.BodySerialNumber);
                Cr2MakerNotePackage cr2MakerNotePackage =
                    (Cr2MakerNotePackage) root.Cr2Package.RawTiffTagPackage.RawExifTagPackage.RawMakerNotePackage;
                Console.WriteLine(cr2MakerNotePackage.Cr2CameraSettingsPackage.LensType);
                Console.WriteLine(cr2MakerNotePackage.Cr2CameraSettingsPackage.MacroMode);

                var propertyMacroMode = cr2MakerNotePackage.Cr2CameraSettingsPackage[(uint)Cr2CameraSettingsIndex.MacroMode] as RawShortTag;
                Console.WriteLine(propertyMacroMode.InterpretedValue);
            }
        }
    }
}
