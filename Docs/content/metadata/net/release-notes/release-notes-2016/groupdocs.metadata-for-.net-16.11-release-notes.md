---
id: groupdocs-metadata-for-net-16-11-release-notes
url: metadata/net/groupdocs-metadata-for-net-16-11-release-notes
title: GroupDocs.Metadata for .NET 16.11 Release Notes
weight: 2
description: ""
keywords: 
productName: GroupDocs.Metadata for .NET
hideChildren: False
---
{{< alert style="info" >}}This page contains release notes for GroupDocs.Metadata for .NET 16.11.0{{< /alert >}}

## Major Features

There are 7 features and 4 enhancements in this regular monthly release. The most notable are:

*   Add support of xlsm, xlt, xltx, xltm Excel documents 
*   Add support of pot, potx PowerPoint documents 
*   Read additional properties of MPEG audio header like HeaderPosition, Bitrate, ChannelMode, Copyright etc 
*   Ability to read and write common values like Artist, Album, Title, TrackNumber, Year etc in ID3v2 tag 
*   Ability to detect WMF image format 
*   Ability to detect WebP image format 
*   Ability to remove ID3v2 tag in Mp3 format 
*   Ability to detect MIME type of the specific file 
*   Ability to detect EMF image format 
*   Ability to read content type properties in Excel document 
*   Ability to retrieve image size

## All Changes

| Key | Summary | Category |
| --- | --- | --- |
| METADATANET-1197 | Add support of xlsm, xlt, xltx, xltm Excel documents |  Enhancement |
| METADATANET-1199 | Add support of pot, potx PowerPoint documents | Enhancement |
| METADATANET-1253 | Read additional properties of MPEG audio header like HeaderPosition, Bitrate, ChannelMode, Copyright etc | Enhancement |
| METADATANET-1258 | Ability to read and write common values like Artist, Album, Title, TrackNumber, Year etc in ID3v2 tag | Enhancement |
| METADATANET-712 | Ability to detect WMF image format |  New Feature |
| METADATANET-960 | Ability to detect WebP image format | New Feature |
| METADATANET-1244 | Ability to remove ID3v2 tag in Mp3 format | New Feature |
| METADATANET-1249 | Ability to detect MIME type of the specific file | New Feature |
| METADATANET-1266 | Ability to detect EMF image format | New Feature |
| METADATANET-1276 | Ability to read content type properties in Excel document | New Feature |
| METADATANET-1278 | Ability to retrieve image size | New Feature |

## Public API and Backward Incompatible Changes

{{< alert style="info" >}}This section lists public API changes that were introduced in GroupDocs.Metadata for .NET 16.11.0. It includes not only new and obsoleted public methods, but also a description of any changes in the behavior behind the scenes in GroupDocs.Metadata which may affect existing code. Any behavior introduced that could be seen as a regression and modifies existing behavior is especially important and is documented here.{{< /alert >}}

#### Ability to Read MPEG Audio Details

Ability to read MPEG audio details like bitrate, channel mode, frequency and other flags according to the MPEG specification.



```csharp
const string filePath = @"C:\download files\Kalimba.mp3";

// get MPEG audio info
MpegAudio audioInfo = (MpegAudio) MetadataUtility.ExtractSpecificMetadata(filePath, MetadataType.MpegAudio);

// another approach is to use Mp3Format directly:

// init Mp3Format class
// Mp3Format mp3Format = new Mp3Format(filePath);

// get MPEG audio info
// MpegAudio audioInfo = mp3Format.AudioDetails;

// display MPEG audio version
Console.WriteLine("MPEG audio version: {0}", audioInfo.MpegAudioVersion);

// display layer version
Console.WriteLine("Layer version: {0}", audioInfo.LayerVersion);

// display header offset
Console.WriteLine("Header offset: {0}", audioInfo.HeaderPosition);

// display bitrate
Console.WriteLine("Bitrate: {0}", audioInfo.Bitrate);

// display frequency
Console.WriteLine("Frequency: {0}", audioInfo.Frequency);

// display channel mode
Console.WriteLine("Channel mode: {0}", audioInfo.ChannelMode);

// display original bit
Console.WriteLine("Is original: {0}", audioInfo.IsOriginal);

// display protected bit
Console.WriteLine("Is protected: {0}", audioInfo.IsProtected);

```

#### Ability to Read/Write Common ID3v2 Tags

This enhancement allows to read/write common ID3v2 tags like artist, album, title etc.



```csharp
const string filePath = @"C:\download files\a-ha - Take On Me.mp3";

// init Mp3Format class
Mp3Format mp3Format = new Mp3Format(filePath);

// get id3v2 tag
Id3v2Tag id3Tag = mp3Format.Id3v2 ?? new Id3v2Tag();

// set artist
id3Tag.Artist = "A-ha";

// set title
id3Tag.Title = "Take on me";

// set band
id3Tag.Band = "A-ha";

// set comment
id3Tag.Comment = "GroupDocs.Metadata creator";

// set track number
id3Tag.TrackNumber = "5";

// set year
id3Tag.Year = "1986";

// update ID3v2 tag
mp3Format.UpdateId3v2(id3Tag);

// and commit changes
mp3Format.Save();

```

#### Ability to Detect WMF Image Format

This feature allows to detect and read dimensions of WMF image format.



```csharp
const string file = @"C:\\download files\image.wmf";

// initialize WmfFormat
WmfFormat wmfFormat = new WmfFormat(file);

// get width
int width = wmfFormat.Width;

// get height
int height = wmfFormat.Height;

```

#### Ability to Detect WebP Image Format

This feature allows to detect and read dimensions of WebP image format.



```csharp
const string file = @"C:\\download files\sky.webp";

// initialize WebPFormat
WebPFormat webpFormat = new WebPFormat(file);

// get width
int width = webpFormat.Width;

// get height
int height = webpFormat.Height;

```

#### Ability to Remove ID3v2 Tag in Mp3 Format

This feature allows to remove ID3 v2.\* tag in Mp3 format.



```csharp
const string filePath = @"C:\download files\a-ha - Take On Me.mp3";

// init Mp3Format class
Mp3Format mp3Format = new Mp3Format(filePath);

// remove ID3v2 tag
mp3Format.RemoveId3v2();

// and commit changes
mp3Format.Save();

```

#### Ability to Detect MIME Type of the Specific File

This feature allows to retrieve MIME type of the specific file or file stream.



```csharp
// path to the input directory
string dir = @"C:\\download files";

// get all files inside directory
string[] files = Directory.GetFiles(dir);

foreach (string path in files)
{
 // get MIME type string
 string mimeType = MetadataUtility.GetMimeType(path);

 Console.WriteLine("File: {0}, MIME type: {1}", Path.GetFileName(path), mimeType);
}


```

Another approach is to use MIMEType property in FormatBase class or it's children.

```csharp
const string file = @"C:\\download files\\sample.docx";

// recognize format
FormatBase format = FormatFactory.RecognizeFormat(file);

// and get MIME type
string mimeType = format.MIMEType;


```

#### Ability to Detect EMF Image Format

This feature allows to detect and read dimensions of EMF image format.



```csharp
const string file = @"C:\\download files\image.emf";

// initialize EmfFormat
EmfFormat emfFormat = new EmfFormat(file);

// get width
int width = emfFormat.Width;

// get height
int height = emfFormat.Height;

```

#### Ability to Read Content Type Properties in Excel Document

This feature allows to read content properties in Xls format.



```csharp
// path to the XLS file
string path = @"C:\\example.xlsx";

// initialize XlsFormat
XlsFormat xlsFormat = new XlsFormat(path);

// get xls properties
XlsMetadata xlsProperties = xlsFormat.DocumentProperties;

// get content properties
XlsContentProperty[] contentProperties = xlsProperties.ContentProperties;

foreach (XlsContentProperty property in contentProperties)
{
  Console.WriteLine("Property: {0}, value: {1}, type: {2}", property.Name, property.Value, property.PropertyType);
}


```

#### Ability to Retrieve Image Size

This feature allows to retrieve width and height properties for all image formats.



```csharp
// path to the input directory
string dir = @"C:\\download files";

// get all files inside directory
string[] files = Directory.GetFiles(dir);

foreach (string path in files)
{
 // recognize format
 FormatBase format = FormatFactory.RecognizeFormat(path);

 // try to parse image
 ImageFormat imageFormat = format as ImageFormat;

 // skip non-image file
 if (imageFormat == null)
 {
  continue;
 }

 // get width
 int width = imageFormat.Width;

 // get height
 int height = imageFormat.Height;

 Console.WriteLine("File: {0}, width {1}, height: {2}", Path.GetFileName(path), width, height);

}


```
