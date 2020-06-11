---
id: groupdocs-metadata-for-net-17-12-release-notes
url: metadata/net/groupdocs-metadata-for-net-17-12-release-notes
title: GroupDocs.Metadata for .NET 17.12 Release Notes
weight: 1
description: ""
keywords: 
productName: GroupDocs.Metadata for .NET
hideChildren: False
---
{{< alert style="info" >}}This page contains release notes for GroupDocs.Metadata for .NET 17.12.{{< /alert >}}

## Major Features

There are 2 new features in this regular monthly release. The most notable are:

*   Ability to remove comment in ZIP format
*   Ability to read thumbnail of EXIF format

## All Changes

| Key | Summary | Category |
| --- | --- | --- |
| METADATANET-2015 | Ability to remove comment of ZIP format | New Feature |
| METADATANET-2016   | Ability to read thumbnail of JPEG format from EXIF segment | New Feature  |

## Public API and Backward Incompatible Changes

{{< alert style="info" >}}This section lists public API changes that were introduced in GroupDocs.Metadata for .NET 17.12. It includes not only new and obsoleted public methods, but also a description of any changes in the behavior behind the scenes in GroupDocs.Metadata which may affect existing code. Any behavior introduced that could be seen as a regression and modifies existing behavior is especially important and is documented here.{{< /alert >}}

#### Ability to remove comment of ZIP format

##### Description

This feature allows removing user comment in ZIP format.

##### Public API changes

Added **RemoveFileComment** method to class **GroupDocs.Metadata.Formats.Archive.ZipFormat**.

##### Usecases

This example demonstrates how to remove user comment in ZIP format.

**C#**

```csharp
string path = "..";

// open zip
ZipFormat zipFormat = new ZipFormat(path);

// remove user comment
zipFormat.RemoveFileComment();

// and commit changes
zipFormat.Save();
```

#### Ability to read thumbnail of JPEG format from EXIF segment

##### Description

This feature allows reading thumbnail of JPEG format from EXIF segment. It's very useful for large images.

##### Public API changes

Added **Thumbnail** property to class **GroupDocs.Metadata.Formats.Image.ExifInfo**.

##### Usecases

This example demonstrates how to read thumbnail of JPEG format from EXIF segment and store it to a file.

**C#**

```csharp
// init jpeg
JpegFormat jpeg = new JpegFormat(path);

// get exif data
var exifData = jpeg.GetExifInfo();
if (exifData != null)
{
     // get thumbnail
     byte[] thumbnail = exifData.Thumbnail;

     // if exist then store to the file
     if (thumbnail.Length > 0)
     {
           File.WriteAllBytes("C:\\1.jpeg", thumbnail);
     }
}
```
