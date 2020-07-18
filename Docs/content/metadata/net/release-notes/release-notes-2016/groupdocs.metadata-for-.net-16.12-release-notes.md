---
id: groupdocs-metadata-for-net-16-12-release-notes
url: metadata/net/groupdocs-metadata-for-net-16-12-release-notes
title: GroupDocs.Metadata for .NET 16.12 Release Notes
weight: 1
description: ""
keywords: 
productName: GroupDocs.Metadata for .NET
hideChildren: False
---
{{< alert style="info" >}}
This page contains release notes for [GroupDocs.Metadata for .NET 16.12.0](http://downloads.groupdocs.com/metadata/net/new-releases/groupdocs.metadata-for-.net-16.12.0/)
{{< /alert >}}

## Major Features

There are 5 features and 2 enhancements in this regular monthly release. The most notable are:

*   Ability to read all available keys of the specific metadata
*   Ability to enumerate any type of metadata
*   Ability to read and write metadata of Open Document Format (ODF)
*   Implement DjVu format
*   Implement BMP image format
*   Implement ability to read header of BMP image
*   Ability to read metadata property by defined key for any supported format

## All Changes

| Key | Summary | Category |
| --- | --- | --- |
| METADATANET-1333 | Ability to read all available keys of the specific metadata |  Enhancement |
| METADATANET-1335 | Ability to enumerate any type of metadata | Enhancement |
| METADATANET-961 | Ability to read and write metadata of Open Document Format (ODF) |  New Feature |
| METADATANET-964 | Implement DjVu format | New Feature |
| METADATANET-1271 | Implement BMP image format | New Feature |
| METADATANET-1323 | Implement ability to read header of BMP image | New Feature |
| METADATANET-1340 | Ability to read metadata property by defined key for any supported format | New Feature |

## Public API and Backward Incompatible Changes

{{< alert style="info" >}}This section lists public API changes that were introduced in GroupDocs.Metadata for .NET 16.12.0. It includes not only new and obsoleted public methods, but also a description of any changes in the behavior behind the scenes in GroupDocs.Metadata which may affect existing code. Any behavior introduced that could be seen as a regression and modifies existing behavior is especially important and is documented here.{{< /alert >}}

#### Ability to read all available keys of the specific metadata

This example demonstrates how to read all metadata keys of the Word document



```csharp
// path to the directory
string dir = @"c:\download files\";

// get all Word documents inside directory
string[] files = Directory.GetFiles(dir, "*.docx");

foreach (string path in files)
{
 Console.WriteLine("Document: {0}", Path.GetFileName(path));

 // open Word document
 using (DocFormat doc = new DocFormat(path))
 {
   // get metadata
   Metadata metadata = doc.DocumentProperties;

   // print all metadata keys presented in DocumentProperties
   foreach (string key in metadata.Keys)
   {
    Console.WriteLine(key);
   }
  }
}

```

This example demonstrates how to retrieve all XMP keys from PDF document



```csharp
// path to the directory with pdf
const string dir = @"c:\download files\";

// get PDF files only
string[] files = Directory.GetFiles(dir, "*.pdf");

foreach (string path in files)
{
 // try to get XMP metadata
 Metadata metadata = MetadataUtility.ExtractSpecificMetadata(path, MetadataType.XMP);

 // skip if file does not contain XMP metadata
 if (metadata == null)
 {
  continue;
 }

 // cast to XmpMetadata
 XmpMetadata xmpMetadata = metadata as XmpMetadata;

 // and display all xmp keys
 foreach (string key in xmpMetadata.Keys)
 {
  Console.WriteLine(key);
 }
}

```

#### Ability to enumerate any type of metadata

This example demonstrates how to display all metadata properties of any metadata using foreach statement



```csharp
// path to the directory
string path = @"C:\\download files\\";

// get all files
string[] files = Directory.GetFiles(path);

foreach (string file in files)
{
  FormatBase format;
  try
  {
   // try to recognize file
   format = FormatFactory.RecognizeFormat(file);
  }
  catch (InvalidFormatException)
  {
    // skip unsupported formats
    continue;
  }
  catch (DocumentProtectedException)
  {
   // skip password protected documents
   continue;
  }

  if (format == null)
  {
   // skip unsupported formats
   continue;
  }

  // get all metadata presented in file
  Metadata[] metadataArray = format.GetMetadata();

  // go through metadata array
  foreach (Metadata metadata in metadataArray)
  {
   // and display all metadata items
   Console.WriteLine("Metadata type: {0}", metadata.MetadataType);

   // use foreach statement for Metadata class to evaluate all metadata properties
   foreach (MetadataProperty property in metadata)
   {
    Console.WriteLine(property);
   }
 }
}

```

#### Ability to read and write metadata of Open Document Format (ODF)

This feature allows to read/update metadata of Open Document Format (ODT).

This example demonstrates how to read metadata properties of the specific .odt file



```csharp
// path to the ODT file
string path = @"C:\\example.odt";

// initialize DocFormat
DocFormat docFormat = new DocFormat(path);

// read all metadata properties
Metadata metadata = docFormat.DocumentProperties;

// and display them
foreach (MetadataProperty property in metadata)
{
 Console.WriteLine(property);
}

```

#### Implement DjVu format

This feature allows to detect and read dimensions of DjVu image format.

This sample demonstrates how to get dimensions of Djvu image



```csharp
const string file = @"C:\\download files\image.djvu";

// initialize DjvuFormat
DjvuFormat wmfFormat = new DjvuFormat(file);

// get width
int width = wmfFormat.Width;

// get height
int height = wmfFormat.Height;

Console.WriteLine("Width: {0}, height: {1}", width, height);

```

#### Implement BMP image format

This feature allows to detect and read dimensions of BMP image format.

This sample demonstrates how to get dimensions of BMP image



```csharp
const string file = @"C:\\download files\image.bmp";

// initialize BmpFormat
BmpFormat bmpFormat = new BmpFormat(file);

// get width
int width = bmpFormat.Width;

// get height
int height = bmpFormat.Height;

Console.WriteLine("Width: {0}, height: {1}", width, height);

```

#### Implement ability to read header of BMP image

This feature allows to read header of BMP image format.

This sample demonstrates how to read header of BMP image



```csharp
// path to the BMP image
const string file = @"C:\\download files\image.bmp";

// initialize BmpFormat
BmpFormat bmpFormat = new BmpFormat(file);

// get BMP header
BmpHeader header = bmpFormat.HeaderInfo;

// display bits per pixel
Console.WriteLine("Bits per pixel: {0}", header.BitsPerPixel);

// display header size
Console.WriteLine("Header size: {0}", header.HeaderSize);

// display image size
Console.WriteLine("Image size: {0}", header.ImageSize);

```

#### Ability to read metadata property by defined key for any supported format

In some cases need to retrieve metadata property by specific key like 'author', 'rating' or 'modified date'. This feature allows to read specific metadata property by known key.

This example demonstrates how read known metadata properties of specific format directly



```csharp
string dir = @"c:\download files\";

// get all files inside 'Download Files' directory
string[] files = Directory.GetFiles(dir);

// recognize first file
FormatBase format = FormatFactory.RecognizeFormat(files[0]);

// try get EXIF artist
var exifArtist = format[MetadataKey.EXIF.Artist];
Console.WriteLine(exifArtist);

// try get dc:creator XMP value
var creator = format[MetadataKey.XMP.DublinCore.Creator];
Console.WriteLine(creator);

// try get xmp:creatorTool
var creatorTool = format[MetadataKey.XMP.BaseSchema.CreatorTool];
Console.WriteLine(creatorTool);

// try get IPTC Application Record keywords
var iptcKeywords = format[MetadataKey.IPTC.ApplicationRecord.Keywords];
Console.WriteLine(iptcKeywords);

```
