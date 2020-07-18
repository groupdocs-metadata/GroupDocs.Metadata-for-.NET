---
id: groupdocs-metadata-for-net-17-06-release-notes
url: metadata/net/groupdocs-metadata-for-net-17-06-release-notes
title: GroupDocs.Metadata for .NET 17.06 Release Notes
weight: 8
description: ""
keywords: 
productName: GroupDocs.Metadata for .NET
hideChildren: False
---
{{< alert style="info" >}}
This page contains release notes for [GroupDocs.Metadata for .NET 17.06.0](https://downloads.groupdocs.com/metadata/net/new-releases/groupdocs.metadata-for-.net-17.6.0/)
{{< /alert >}}

## Major Features

There are 4 new features and 1 fix in this regular monthly release. The most notable are:

*   Ability to read and write XMP metadata in AVI format
*   Ability to read SONY maker notes in JPEG image
*   Ability to read NIKON maker notes in JPEG image
*   Ability to parse additional IFD tags like SByte, SShort, SRational and SLong
*   Cannot Update IPTC tags in Jpeg

## All Changes

| Key | Summary | Category |
| --- | --- | --- |
| METADATANET-1470 | Ability to read and write XMP metadata in AVI format | New Feature |
| METADATANET-1730 | Ability to read SONY maker notes in JPEG image | New Feature |
| METADATANET-1732 | Ability to read SONY maker notes in JPEG image | New Feature |
| METADATANET-1733 | Ability to parse additional IFD tags like SByte, SShort, SRational and SLong | New Feature |
| METADATANET-1724 | Cannot Update IPTC tags in Jpeg | Bug |

## Public API and Backward Incompatible Changes

{{< alert style="info" >}}This section lists public API changes that were introduced in GroupDocs.Metadata for .NET 17.06.0 It includes not only new and obsoleted public methods, but also a description of any changes in the behavior behind the scenes in GroupDocs.Metadata which may affect existing code. Any behavior introduced that could be seen as a regression and modifies existing behavior is especially important and is documented here.{{< /alert >}}

#### Ability to read and write XMP metadata in AVI format

This feature allows to read, update and remove XMP metadata in AVI format.

##### Public API changes

Implement **IXmp interface** in class **GroupDocs.Metadata.Formats.Video.AviFormat**

Given below example demonstrates how to update XMP in AVI format



```csharp
// path to the AVI
const string file = @"C:\\download files\tutorial1.avi";

// initialize AviFormat
AviFormat aviFormat = new AviFormat(file);

// get XMP
var xmpMetadata = aviFormat.GetXmpData();

// create XMP if absent
if (xmpMetadata == null)
{
 xmpMetadata = new XmpPacketWrapper();
}

// setup properties
xmpMetadata.Schemes.DublinCore.Format = "avi";
xmpMetadata.Schemes.XmpBasic.CreateDate = DateTime.UtcNow;
xmpMetadata.Schemes.XmpBasic.CreatorTool = "GroupDocs.Metadata";

// update xmp
aviFormat.SetXmpData(xmpMetadata);

// and commit changes
aviFormat.Save();

```

#### Ability to read SONY maker notes in JPEG image

This feature allows to read SONY maker notes in JPEG image

##### Public API changes

Added **SonyMakerNotes** class into namespace **GroupDocs.Metadata.Formats.Image**

This example demonstrates how to get SONY makernotes.



```csharp
// path to the jpg file
string path = @"C:\\example.jpg";

// initialize JpegFormat
JpegFormat jpegFormat = new JpegFormat(path);

// get makernotes
var makernotes = jpegFormat.GetMakernotes();

if (makernotes != null)
{
  // try cast to SonyMakerNotes
  SonyMakerNotes sonyMakerNotes = makernotes as SonyMakerNotes;
  if (sonyMakerNotes != null)
  {
   // get color mode
   int? colorMode = sonyMakerNotes.ColorMode;

   // get JPEG quality
   int? jpegQuality = sonyMakerNotes.JPEGQuality;
  }
}

```

#### Ability to read NIKON maker notes in JPEG image

This feature allows to read NIKON maker notes in JPEG image.

##### Public API changes

Added **NikonMakerNotes** class into namespace **GroupDocs.Metadata.Formats.Image**

This example demonstrates how to get NIKON maker notes.



```csharp
// path to the jpg file
string path = @"C:\\example.jpg";

// initialize JpegFormat
JpegFormat jpegFormat = new JpegFormat(path);

// get makernotes
var makernotes = jpegFormat.GetMakernotes();

if (makernotes != null)
{
 // try cast to NikonMakerNotes
 NikonMakerNotes nikonMakerNotes = makernotes as NikonMakerNotes;

 if (nikonMakerNotes != null)
 {
  // get quality string
  string quality = nikonMakerNotes.Quality;

  // get version
  byte[] version = nikonMakerNotes.MakerNoteVersion;
 }
}

```

#### Ability to parse additional IFD tags like SByte, SShort and SLong

This feature allows to parse additional IFD tags like SByte, SShort, SRational and SLong.

##### Public API changes

Added **TiffSShortTag** class into namespace **GroupDocs.Metadata.Formats.Image**  
Added **TiffSLongTag** class into namespace **GroupDocs.Metadata.Formats.Image**  
Added **TiffSByteTag** class into namespace **GroupDocs.Metadata.Formats.Image**

This example demonstrates how to read SLong tags from makernotes data in JPEG format.



```csharp
// path to the jpg file
string path = @"C:\\example.jpg";

// initialize JpegFormat
JpegFormat jpegFormat = new JpegFormat(path);

JpegExifInfo exif = jpegFormat.GetExifInfo() as JpegExifInfo;

if (exif == null)
{
 // nothing to process
 return;
}


// get makernotes
var makernotes = jpegFormat.GetMakernotes();

if (exif.Make == "NIKON")
{
 // try cast to NikonMakerNotes
 NikonMakerNotes nikonMakerNotes = makernotes as NikonMakerNotes;

 // get tags
var tags = nikonMakerNotes.Tags;

foreach (TiffTag tag in tags)
{
 if (tag.TagType == TiffTagType.SLong)
 {
  // cast to SLong type
  TiffSLongTag tiffSLong = tag as TiffSLongTag;

  // and display value
  Console.WriteLine("Tag: {0}, value: {1}",tiffSLong.TagId, tiffSLong.Value);
  }
 }
}

```

#### Cannot Update IPTC tags in Jpeg  

The bug related to updating IPTC tags in JPEG image has been resolved.

##### Public API changes

None

This example demonstrates how to update IPTC tags



```csharp
JpegFormat jpegFormat = new JpegFormat(copy);
IptcCollection iptc = jpegFormat.GetIptc();
if (iptc == null)
{
 iptc = new IptcCollection();
}

iptc.Add(new IptcProperty(2, "urgency", 10, 5));

jpegFormat.UpdateIptc(iptc);
jpegFormat.Save();

```
