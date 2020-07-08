---
id: groupdocs-metadata-for-net-19-3-release-notes
url: metadata/net/groupdocs-metadata-for-net-19-3-release-notes
title: GroupDocs.Metadata for .NET 19.3 Release Notes
weight: 5
description: ""
keywords: 
productName: GroupDocs.Metadata for .NET
hideChildren: False
---
{{< alert style="info" >}}This page contains release notes for GroupDocs.Metadata for .NET 19.3.{{< /alert >}}

## Major Features

There are the following features and enhancements in this release:

*   Implement the ability to parse font files
*   Refactor the AVI, FLV, MOV, Matroska, BitTorrent, ZIP and EPUB formats according to the new concept of metadata arrangement

## Full List of Issues Covering all Changes in this Release

| Key | Summary | Category |
| --- | --- | --- |
| METADATANET-518 | Implement the ability to parse font files | New Feature |
| METADATANET-2696 | Refactor the AVI, FLV, MOV, Matroska, BitTorrent, ZIP and EPUB formats according to the new concept of metadata arrangement | Enhancement |

##   
Public API and Backward Incompatible Changes

{{< alert style="info" >}}This section lists public API changes that were introduced in GroupDocs.Metadata for .NET 19.3. It includes not only new and obsoleted public methods, but also a description of any changes in the behavior behind the scenes in GroupDocs.Metadata which may affect existing code. Any behavior introduced that could be seen as regression and modifies existing behavior is especially important and is documented here.{{< /alert >}}

### Implement the ability to parse font files

This new feature allows a user to read metadata of **OpenType** fonts

**Public API changes**

The *GroupDocs.Metadata.Formats.Cryptography* namespace has been introduced

The *Cms* class has been added to the *GroupDocs.Metadata.Formats.Cryptography* namespace

The *CmsAttribute* class has been added to the *GroupDocs.Metadata.Formats.Cryptography* namespace

The *CmsCertificate* class has been added to the *GroupDocs.Metadata.Formats.Cryptography* namespace

The *CmsEncapsulatedContentInfo* class has been added to the *GroupDocs.Metadata.Formats.Cryptography* namespace

The *CmsSignerInfo* class has been added to the *GroupDocs.Metadata.Formats.Cryptography* namespace

The *Oid* class has been added to the *GroupDocs.Metadata.Formats.Cryptography* namespace

The *GroupDocs.Metadata.Formats.Font* namespace has been introduced

The *OpenTypeBaseNameRecord* class has been added to the *GroupDocs.Metadata.Formats.Font *namespace

The *OpenTypeDigitalSignatureFlags* enum has been added to the *GroupDocs.Metadata.Formats.Font *namespace

The *OpenTypeDirectionHint* enum has been added to the *GroupDocs.Metadata.Formats.Font *namespace

The *OpenTypeFlags* enum has been added to the *GroupDocs.Metadata.Formats.Font *namespace

The *OpenTypeFormat* class has been added to the *GroupDocs.Metadata.Formats.Font *namespace

The *OpenTypeIsoEncoding* enum has been added to the *GroupDocs.Metadata.Formats.Font *namespace

The *OpenTypeLicensingRights* enum has been added to the *GroupDocs.Metadata.Formats.Font *namespace

The *OpenTypeMacintoshEncoding* enum has been added to the *GroupDocs.Metadata.Formats.Font *namespace

The *OpenTypeMacintoshLanguage* enum has been added to the *GroupDocs.Metadata.Formats.Font *namespace

The *OpenTypeMacintoshNameRecord* class has been added to the *GroupDocs.Metadata.Formats.Font *namespace

The *OpenTypeMetadata* class has been added to the *GroupDocs.Metadata.Formats.Font *namespace

The *OpenTypeName* class has been added to the *GroupDocs.Metadata.Formats.Font *namespace

The *OpenTypePlatform* enum has been added to the *GroupDocs.Metadata.Formats.Font *namespace

The *OpenTypeStyle* enum has been added to the *GroupDocs.Metadata.Formats.Font *namespace

The *OpenTypeUnicodeEncoding* enum has been added to the *GroupDocs.Metadata.Formats.Font *namespace

The *OpenTypeUnicodeNameRecord* class has been added to the *GroupDocs.Metadata.Formats.Font *namespace

The *OpenTypeVersion* enum has been added to the *GroupDocs.Metadata.Formats.Font *namespace

The *OpenTypeWeight* enum has been added to the *GroupDocs.Metadata.Formats.Font *namespace

The *OpenTypeWidth* enum has been added to the *GroupDocs.Metadata.Formats.Font *namespace

The *OpenTypeWindowsEncoding* enum has been added to the *GroupDocs.Metadata.Formats.Font *namespace

The *OpenTypeWindowsLanguage* enum has been added to the *GroupDocs.Metadata.Formats.Font *namespace

The *OpenTypeWindowsNameRecord* class has been added to the *GroupDocs.Metadata.Formats.Font *namespace

The *Rectangle* class has been added to the *GroupDocs.Metadata *namespace

The *OpenType* item has been added to the *MetadataType *enum

The *OpenType* item has been added to the *DocumentType *enum

Use case to read **OpenType** font metadata



```csharp
static void Main(string[] args)
{
    License license = new License();
    license.SetLicense(@"D:\GroupDocs.Metadata.lic");

    using (OpenTypeFormat format = new OpenTypeFormat(@"D:\input.ttf"))
    {
        // Read the OpenType font metadata
        foreach (OpenTypeMetadata metadataEntry in format.FontInfo)
        {
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

        // Read the digital signature metadata
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
    Console.ReadKey();
}

private static void PrintOid(Oid oid)
{
    if (oid != null)
    {
        Console.WriteLine(oid.FriendlyName);
        Console.WriteLine(oid.Value);
    }
}

private static void PrintAttributes(CmsAttribute[] attributes)
{
    if (attributes != null)
    {
        foreach (CmsAttribute attribute in attributes)
        {
            PrintOid(attribute.Oid);
            Console.WriteLine(attribute.Value);
        }
    }
} 
```

{{< alert style="info" >}}This format supports hierarchical metadata arrangement{{< /alert >}}

Use case to read the whole metadata tree in the unified way.



```csharp
static void Main(string[] args)
{
    License license = new License();
    license.SetLicense(@"D:\GroupDocs.Metadata.lic");

    using (FormatBase format = FormatFactory.RecognizeFormat(@"D:\input.ttf"))
    {
        DisplayMetadataTree(format.GetMetadata(), 0);
    }

    Console.ReadKey();
}

private static void DisplayMetadataTree(Metadata metadata, int indent)
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
                        DisplayMetadataTree(property.Value.ToMetadata(), indent + 2);
                        break;
                    case MetadataPropertyType.MetadataArray:
                        DisplayMetadataTree(property.Value.ToMetadataArray(), indent + 2);
                        break;
                }
            }
        }
    }
}

private static void DisplayMetadataTree(Metadata[] metadataArray, int indent)
{
    if (metadataArray != null)
    {
        foreach (Metadata metadata in metadataArray)
        {
            DisplayMetadataTree(metadata, indent);
        }
    }
}
```

  

### Refactor the AVI, FLV, MOV, Matroska, BitTorrent, ZIP and EPUB formats according to the new concept of metadata arrangement

The following formats now support hierarchical metadata arrangement:

**AVI, FLV, MOV, Matroska, BitTorrent, ZIP, EPUB**.

Use case to read the whole metadata tree in the unified way (regardless of the format).



```csharp
static void Main(string[] args)
{
    License license = new License();
    license.SetLicense(@"D:\GroupDocs.Metadata.lic");

    using (FormatBase format = FormatFactory.RecognizeFormat(@"D:\input.zip"))
    {
        DisplayMetadataTree(format.GetMetadata(), 0);
    }

    Console.ReadKey();
}

private static void DisplayMetadataTree(Metadata metadata, int indent)
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
                        DisplayMetadataTree(property.Value.ToMetadata(), indent + 2);
                        break;
                    case MetadataPropertyType.MetadataArray:
                        DisplayMetadataTree(property.Value.ToMetadataArray(), indent + 2);
                        break;
                }
            }
        }
    }
}

private static void DisplayMetadataTree(Metadata[] metadataArray, int indent)
{
    if (metadataArray != null)
    {
        foreach (Metadata metadata in metadataArray)
        {
            DisplayMetadataTree(metadata, indent);
        }
    }
}
```
