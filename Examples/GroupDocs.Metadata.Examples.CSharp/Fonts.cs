using GroupDocs.Metadata.Examples.Utilities.CSharp;
using GroupDocs.Metadata.Formats;
using GroupDocs.Metadata.Formats.Archive;
using GroupDocs.Metadata.Formats.Cryptography;
using GroupDocs.Metadata.Formats.Font;
using GroupDocs.Metadata.Tools;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace GroupDocs.Metadata.Examples.CSharp
{
    public static class Fonts
    {
        public static class OpenType
        {
            // initialize file path
            //ExStart:SourceDocFilePath
            private const string filePath = "Fonts/OpenType/sample.otf";
            //ExEnd:SourceDocFilePath


            /// <summary>
            /// Simply read Metadata from OpenType Font files
            /// </summary>
            public static void ReadOpenTypeMetadata()
            {
                //ExStart:ReadOpenTypeMetadata_19.3
               
                using (OpenTypeFormat format = new OpenTypeFormat(Common.MapSourceFilePath(filePath)))
                {

                    // Read the OpenType font metadata
                    foreach (OpenTypeMetadata metadataEntry in format.FontInfo)
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
                            Console.WriteLine(nameRecord.NameId);
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
                //ExEnd:ReadOpenTypeMetadata_19.3
            }
            /// <summary>
            /// Read the digital signature metadata
            /// </summary>
            public static void ReadDigitalSignatureMetadata()
            {
                using (OpenTypeFormat format = new OpenTypeFormat(Common.MapSourceFilePath(filePath)))
                {
                    
                    if (format.HasDigitalSignatures)
                    {
                        Console.WriteLine(format.DigitalSignatureFlags);
                        foreach (Cms signature in format.DigitalSignatures)
                        {
                            Console.WriteLine(signature.SignTime);
                            if (signature.DigestAlgorithms != null)
                            {
                                foreach (Oid signatureDigestAlgorithm in signature.DigestAlgorithms)
                                {
                                    PrintOid(signatureDigestAlgorithm);
                                }
                            }
                            if (signature.EncapsulatedContentInfo != null)
                            {
                                PrintOid(signature.EncapsulatedContentInfo.ContentType);
                                Console.WriteLine(signature.EncapsulatedContentInfo.ContentRawData.Length);
                            }
                            if (signature.Certificates != null)
                            {
                                foreach (CmsCertificate certificate in signature.Certificates)
                                {
                                    Console.WriteLine(certificate.NotAfter);
                                    Console.WriteLine(certificate.NotBefore);
                                    Console.WriteLine(certificate.RawData.Length);
                                }
                            }
                            if (signature.SignerInfoEntries != null)
                            {
                                foreach (CmsSignerInfo signerInfoEntry in signature.SignerInfoEntries)
                                {
                                    Console.WriteLine(signerInfoEntry.SignatureValue);
                                    PrintOid(signerInfoEntry.DigestAlgorithm);
                                    PrintOid(signerInfoEntry.SignatureAlgorithm);
                                    Console.WriteLine(signerInfoEntry.SigningTime);
                                    PrintAttributes(signerInfoEntry.SignedAttributes);
                                    PrintAttributes(signerInfoEntry.UnsignedAttributes);
                                }
                            }
                        }
                    }
                    
                }

            }
                       
            
            public static void PrintOid(Oid oid)
            {
                // Display the property name and value of OID
                if (oid != null)
                {
                    Console.WriteLine(oid.FriendlyName);
                    Console.WriteLine(oid.Value);
                }
            }

            public static void PrintAttributes(CmsAttribute[] attributes)
            {
                //Display the CmsAttributes of an OID
                if (attributes != null)
                {
                    foreach (CmsAttribute attribute in attributes)
                    {
                        PrintOid(attribute.Oid);
                        Console.WriteLine(attribute.Value);
                    }
                }
            }

            /// <summary>
            /// Display Metadata Tree
            /// </summary>
            public static void DisplayMetadataTree()
            {
                using (FormatBase format = FormatFactory.RecognizeFormat(Common.MapSourceFilePath(filePath)))
                {

                    MetadataTree(format.GetMetadata(), 0);
                }

            }

            /// <summary>
            /// Building the whole metadata tree in a unified way
            /// </summary>

            private static void MetadataTree(Metadata metadata, int indent)
            {
                if (metadata != null)
                {
                    var stringMetadataType = metadata.MetadataType.ToString();
                    Console.WriteLine(stringMetadataType.PadLeft(stringMetadataType.Length + indent));
                    foreach (MetadataProperty property in metadata)
                    {
                        string stringPropertyRepresentation = string.Format("Name: {0}, Value: {1}", property.Name, property.GetFormattedValue());
                        Console.WriteLine(stringPropertyRepresentation.PadLeft(stringPropertyRepresentation.Length + indent + 1));
                        if (property.Value != null)
                        {
                            switch (property.Value.Type)
                            {
                                case MetadataPropertyType.Metadata:
                                    MetadataTree(property.Value.ToMetadata(), indent + 2);
                                    break;
                                case MetadataPropertyType.MetadataArray:
                                    MetadataTree(property.Value.ToMetadataArray(), indent + 2);
                                    break;
                            }
                        }
                    }
                }
            }

            private static void MetadataTree(Metadata[] metadataArray, int indent)
            {
                if (metadataArray != null)
                {
                    foreach (Metadata metadata in metadataArray)
                    {
                        MetadataTree(metadata, indent);
                    }
                }
            }

        }
        
     }
 }


