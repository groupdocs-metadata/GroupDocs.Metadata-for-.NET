using System;
using System.Collections.Generic;
using System.Text;
using GroupDocs.Metadata.Formats.Raw.Cr2;
using GroupDocs.Metadata.Formats.Raw.Tag;

namespace GroupDocs.Metadata.Examples.CSharp.AdvancedUsage.ManagingMetadataForSpecificFormats.Image.Raw
{
    internal class Cr2ReadFileFormatProperties
    {
        public static void Run()
        {
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
