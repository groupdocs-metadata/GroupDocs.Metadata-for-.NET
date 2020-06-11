---
id: groupdocs-metadata-for-net-17-09-release-notes
url: metadata/net/groupdocs-metadata-for-net-17-09-release-notes
title: GroupDocs.Metadata for .NET 17.09 Release Notes
weight: 6
description: ""
keywords: 
productName: GroupDocs.Metadata for .NET
hideChildren: False
---
{{< alert style="info" >}}This page contains release notes for GroupDocs.Metadata for .NET 17.09.0{{< /alert >}}

## Major Features

There are 4 new features, 1 enhancement and 1 fix in this regular monthly release. The most notable are:

*   Ability to read APEv2 metadata in MP3 format 
*   Ability to read and update metadata of ODS format 
*   Ability to read SRational TIFF tag in JPEG and TIFF image formats 
*   Ability to add or update TIFF tags in EXIF

## All Changes

| Key | Summary | Category |
| --- | --- | --- |
| METADATANET-1214 | Ability to read APEv2 metadata in MP3 format | New Feature |
| METADATANET-1329 | Ability to read and update metadata of ODS format | New Feature |
| METADATANET-1872 | Ability to read SRational TIFF tag in JPEG and TIFF image formats | New Feature |
| METADATANET-1883 | Ability to add or update TIFF tags in EXIF | New Feature |
| METADATANET-1878 | Several TIFF tags are lost after changing EXIF properties | Bug |
| METADATANET-1891 | Prevent to crash export process in case of converting large objects to csv | Enhancement |

## Public API and Backward Incompatible Changes

{{< alert style="info" >}}This section lists public API changes that were introduced in GroupDocs.Metadata for .NET 17.09.0 It includes not only new and obsoleted public methods, but also a description of any changes in the behavior behind the scenes in GroupDocs.Metadata which may affect existing code. Any behavior introduced that could be seen as a regression and modifies existing behavior is especially important and is documented here.{{< /alert >}}

#### Several TIFF tags are lost after changing EXIF properties

Several EXIF tags not found after updating EXIF property. This bug has now been fixed.

##### Public API changes

None

Usecase.

**C#**

```csharp
string spath = @"C:\Users\User\Desktop\source.jpg";
JpegFormat jpegFormat = new JpegFormat(spath);

JpegExifInfo exif = (JpegExifInfo)jpegFormat.ExifValues;
exif.Artist = string.Empty;

string fpath = @"C:\Users\User\Desktop\Change.jpg";
jpegFormat.Save(fpath);
```

#### Prevent to crash export process in case of converting large objects to Excel or CSV

In several cases metadata value of the specific key may be too large (more than 32 KBytes). Previous versions did not handle such case so user may get exception. 

##### Public API changes

None

Usecase.

**C#**

```csharp
 
 // path to the target file
 const string path = @"C:\summer_2017_2.jpg";

 // path to the output file
 const string outputPath = @"C:\metadata.xlsx";

 // export to excel
 byte[] content = ExportFacade.ExportToExcel(path);

 // write data to the file
 File.WriteAllBytes(outputPath, content);
 
```

#### Ability to read APEv2 metadata in MP3 format

This feature allows to read [APEv2 ](https://en.wikipedia.org/wiki/APE_tag#APEv2)metadata in MP3 format.

##### Public API changes

Added **Apev2Metadata** class into **GroupDocs.Metadata.Formats.Audio** namespace

This example demonstrates how to read APEv2 tag in MP3 format.

**C#**

```csharp
// path to the input directory
string dir = @"C:\\download files";

// get all files inside directory
string[] files = Directory.GetFiles(dir, "*.mp3");

foreach (string file in files)
{
    // initialize Mp3Format. If file is not Mp3 then appropriate exception will throw.
    Mp3Format mp3Format = new Mp3Format(file);

    // get APEv2 tag
    Apev2Metadata apev2 = mp3Format.APEv2;

    //NOTE: please remember you may use different approaches to getting metadata                

    // second approach
    //apev2 = (Apev2Metadata)MetadataUtility.ExtractSpecificMetadata(file, MetadataType.APEv2);

    // check if APEv2 tag is presented
    if (apev2 != null)
    {                                        
        // Display tag properties
        Console.WriteLine("Album: {0}", apev2.Album);
        Console.WriteLine("Artist: {0}", apev2.Artist);
        Console.WriteLine("Comment: {0}", apev2.Comment);
        Console.WriteLine("Genre: {0}", apev2.Genre);
        Console.WriteLine("Title: {0}", apev2.Title);
        Console.WriteLine("Track: {0}", apev2.Track);
    }
}
 
```

#### Ability to read and update metadata of ODS format

This feature allows to read [OpenDocument Spreadsheet](https://en.wikipedia.org/wiki/OpenDocument) (ODS) format

##### Public API changes

None.

This example demonstrates how to read document properties in ODS format.

**C#**

```csharp
// path to the ODS file
string path = @"C:\\example.ods";

// initialize XlsFormat
XlsFormat xlsFormat = new XlsFormat(path);

// get document properties
XlsMetadata properties = xlsFormat.DocumentProperties;

// get author
string author = properties.Author;

// get company
string company = properties.Company;

// get created date of the document
DateTime createdDate = properties.CreatedTime;
 
```

#### Ability to read SRational TIFF tag in JPEG and TIFF image formats

This feature allows to SRational TIFF tag in JPEG/TIFF image formats.

##### Public API changes

Added **SRational** class into namespace **GroupDocs.Metadata.Formats.Image**

Usecase.

**C#**

```csharp
// init JpegFormat
JpegFormat jpegFormat = new JpegFormat(file);

// get exif info
ExifInfo exifInfo = jpegFormat.GetExifInfo();


if (exifInfo != null)
{

    // all tags are available in licensed mode only
    TiffTag[] allTags = exifInfo.Tags;

    foreach (TiffTag tag in allTags)
    {
        switch (tag.TagType)
        {
                      
            case TiffTagType.SRational:
            TiffSRationalTag srationalTag = tag as TiffSRationalTag;                            
            Console.WriteLine("Tag: {0}, value: {1}", srationalTag.DefinedTag, srationalTag.Value);
            break;
        }
    }
}
```

#### Ability to add or update TIFF tags in EXIF

This feature allows to add or update custom TIFF tags to EXIF segment in JPEG or TIFF formats.

##### Public API changes

None.

This example demonstrates how to specify 'artist' using TiffAsciiTag tag.

**C#**

```csharp
// path to the image
const string file = @"C:\\image.jpeg";

// init JpegFormat
JpegFormat jpegFormat = new JpegFormat(file);           

// get existing EXIF or create new one
ExifInfo exif = jpegFormat.GetExifInfo() ?? new ExifInfo();            

// define list of tags
List<TiffTag> tags = new List<TiffTag>();

// add specific tag
tags.Add(new TiffAsciiTag(TiffTagIdEnum.Artist, "Jack"));

// and update tags
exif.Tags = tags.ToArray();            

// update exif
jpegFormat.UpdateExifInfo(exif);

// and commit changes
jpegFormat.Save();
```
