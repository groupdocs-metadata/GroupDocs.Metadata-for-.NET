// <copyright company="Aspose Pty Ltd">
//  Copyright (C) 2011-2024 GroupDocs. All Rights Reserved.
// </copyright>

namespace GroupDocs.Metadata.Examples.CSharp.AdvancedUsage.ManagingMetadataForSpecificFormats.Font
{
    using System;
    using Formats.Font;

    /// <summary>
    /// This example shows how to read OpenType font metadata.
    /// </summary>
    public static class OpenTypeReadNativeMetadataProperties
    {
        public static void Run()
        {
            Console.WriteLine("\n--------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("[Example Advanced Usage] # OpenTypeReadNativeMetadataProperties : How to read OpenType font metadata.\n");
            using (Metadata metadata = new Metadata(Constants.InputTtf))
            {
                var root = metadata.GetRootPackage<OpenTypeRootPackage>();

                // Read the OpenType font metadata
                foreach (var metadataEntry in root.OpenTypePackage.Fonts)
                {
                    // Display the values of some metadata properties
                    Console.WriteLine(metadataEntry.Created);
                    Console.WriteLine(metadataEntry.DirectionHint);
                    Console.WriteLine(metadataEntry.EmbeddingLicensingRights);
                    Console.WriteLine(metadataEntry.Flags);
                    Console.WriteLine(metadataEntry.FontFamilyName);
                    Console.WriteLine(metadataEntry.FontRevision);
                    Console.WriteLine(metadataEntry.FontSubfamilyName);
                    Console.WriteLine(metadataEntry.FullFontName);
                    Console.WriteLine(metadataEntry.GlyphBounds);
                    Console.WriteLine(metadataEntry.MajorVersion);
                    Console.WriteLine(metadataEntry.MinorVersion);
                    Console.WriteLine(metadataEntry.Modified);
                    Console.WriteLine(metadataEntry.SfntVersion);
                    Console.WriteLine(metadataEntry.Style);
                    Console.WriteLine(metadataEntry.TypographicFamily);
                    Console.WriteLine(metadataEntry.TypographicSubfamily);
                    Console.WriteLine(metadataEntry.Weight);
                    Console.WriteLine(metadataEntry.Width);
                    foreach (OpenTypeBaseNameRecord nameRecord in metadataEntry.Names)
                    {
                        Console.WriteLine(nameRecord.NameID);
                        Console.WriteLine(nameRecord.Platform);
                        Console.WriteLine(nameRecord.Value);
                        OpenTypeMacintoshNameRecord macintoshNameRecord = nameRecord as OpenTypeMacintoshNameRecord;
                        if (macintoshNameRecord != null)
                        {
                            Console.WriteLine(macintoshNameRecord.Encoding);
                            Console.WriteLine(macintoshNameRecord.Language);
                        }
                        else
                        {
                            OpenTypeUnicodeNameRecord unicodeNameRecord = nameRecord as OpenTypeUnicodeNameRecord;
                            if (unicodeNameRecord != null)
                            {
                                Console.WriteLine(unicodeNameRecord.Encoding);
                            }
                            else
                            {
                                OpenTypeWindowsNameRecord windowsNameRecord = nameRecord as OpenTypeWindowsNameRecord;
                                if (windowsNameRecord != null)
                                {
                                    Console.WriteLine(windowsNameRecord.Encoding);
                                    Console.WriteLine(windowsNameRecord.Language);
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
