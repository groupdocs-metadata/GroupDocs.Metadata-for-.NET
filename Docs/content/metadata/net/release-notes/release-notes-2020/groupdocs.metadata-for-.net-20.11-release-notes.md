---
id: groupdocs-metadata-for-net-20-11-release-notes
url: metadata/net/groupdocs-metadata-for-net-20-11-release-notes
title: GroupDocs.Metadata for .NET 20.11 Release Notes
weight: 11
description: ""
keywords: 
productName: GroupDocs.Metadata for .NET
hideChildren: False
---
{{< alert style="info" >}}This page contains release notes for GroupDocs.Metadata for .NET 20.11{{< /alert >}}

## Major Features

  
There are the following features, enhancements and fixes in this release:

*   Implement the ability to extract text data chunks from PNG images
*   "DXF version is not valid" exception when reading DXF file
*   Exception: Cannot process loading further due to incorrect file format structure
*   Exception: File is incompatible with exporter
*   Loading process freezes on a damaged file
*   Image loading failed

## Full List of Issues Covering all Changes in this Release

| Key | Summary | Category |
| --- | --- | --- |
| METADATANET-3473 | Implement the ability to extract text data chunks from PNG images                   | New Feature |
| METADATANET-3286 | "DXF version is not valid" exception when reading DXF file                 		 | Bug         |
| METADATANET-3313 | Exception: Cannot process loading further due to incorrect file format structure    | Bug         |
| METADATANET-3334 | Exception: File is incompatible with exporter                              		 | Bug         |
| METADATANET-3385 | Loading process freezes on a damaged file                                           | Bug         |
| METADATANET-3476 | Image loading failed                                          						 | Bug         |




## Public API and Backward Incompatible Changes

### Implement the ability to extract text data chunks from PNG images

This new feature allows the user to extract chunks of textual data from PNG images

##### Public API changes 

The [PngTextChunk](https://apireference.groupdocs.com/metadata/net/groupdocs.metadata.formats.image/pngtextchunk) class has been added to the [GroupDocs.Metadata.Formats.Image](https://apireference.groupdocs.com/metadata/net/groupdocs.metadata.formats.image) namespace

The [PngCompressedTextChunk](https://apireference.groupdocs.com/metadata/net/groupdocs.metadata.formats.image/pngcompressedtextchunk) class has been added to the [GroupDocs.Metadata.Formats.Image](https://apireference.groupdocs.com/metadata/net/groupdocs.metadata.formats.image) namespace

The [PngInternationalTextChunk](https://apireference.groupdocs.com/metadata/net/groupdocs.metadata.formats.image/pnginternationaltextchunk) class has been added to the [GroupDocs.Metadata.Formats.Image](https://apireference.groupdocs.com/metadata/net/groupdocs.metadata.formats.image) namespace

The [PngPackage](https://apireference.groupdocs.com/metadata/net/groupdocs.metadata.formats.image/pngpackage) class has been added to the [GroupDocs.Metadata.Formats.Image](https://apireference.groupdocs.com/metadata/net/groupdocs.metadata.formats.image) namespace

The [PngCompressionMethod](https://apireference.groupdocs.com/metadata/net/groupdocs.metadata.formats.image/pngcompressionmethod) enum has been added to the [GroupDocs.Metadata.Formats.Image](https://apireference.groupdocs.com/metadata/net/groupdocs.metadata.formats.image) namespace

The [PngPackage](https://apireference.groupdocs.com/metadata/net/groupdocs.metadata.formats.image/pngrootpackage/properties/pngpackage) property has been added to the [PngRootPackage](https://apireference.groupdocs.com/metadata/net/groupdocs.metadata.formats.image/pngrootpackage) class



##### Use cases 

Extract chunks of textual metadata from a PNG image

```csharp
using (Metadata metadata = new Metadata(@"D:\input.png"))
{
    var root = metadata.GetRootPackage<PngRootPackage>();
    foreach (var chunk in root.PngPackage.TextChunks)
    {
        Console.WriteLine(chunk.Keyword);
        Console.WriteLine(chunk.Text);
        var compressedChunk = chunk as PngCompressedTextChunk;
        if (compressedChunk != null)
        {
            Console.WriteLine(compressedChunk.CompressionMethod);
        }
        var internationalChunk = chunk as PngInternationalTextChunk;
        if (internationalChunk != null)
        {
            Console.WriteLine(internationalChunk.IsCompressed);
            Console.WriteLine(internationalChunk.Language);
            Console.WriteLine(internationalChunk.TranslatedKeyword);
        }
    }
}
```

### Other API changes

[DicomPackage.LengthValue](https://apireference.groupdocs.com/metadata/net/groupdocs.metadata.formats.image/dicompackage/properties/lengthvalue) property compilation has been set to fail

[DicomPackage.DicomFound](https://apireference.groupdocs.com/metadata/net/groupdocs.metadata.formats.image/dicompackage/properties/dicomfound) property compilation has been set to fail

[ExifGpsPackage.Track](https://apireference.groupdocs.com/metadata/net/groupdocs.metadata.standards.exif/exifgpspackage/properties/track) property compilation has been set to fail

 

The properties are no longer supported.