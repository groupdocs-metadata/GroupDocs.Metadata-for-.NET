---
id: groupdocs-metadata-for-net-17-03-release-notes
url: metadata/net/groupdocs-metadata-for-net-17-03-release-notes
title: GroupDocs.Metadata for .NET 17.03 Release Notes
weight: 10
description: ""
keywords: 
productName: GroupDocs.Metadata for .NET
hideChildren: False
---
{{< alert style="info" >}}
This page contains release notes for [GroupDocs.Metadata for .NET 17.03.0](https://downloads.groupdocs.com/metadata/net/new-releases/groupdocs.metadata-for-.net-17.3.0/)
{{< /alert >}}

## Major Features

There are 4 enhancements and 1 new feature in this regular monthly release. The most notable are:

*   Ability to read thumbnail in document formats
*   Load DocumentInfo property using lazy loading pattern in document formats
*   Load only existing metadata keys into PdfMetadata class
*   Faster deleting of EXIF metadata
*   Faster updating of EXIF metadata

## All Changes

| Key | Summary | Category |
| --- | --- | --- |
| METADATANET-1519 | Load DocumentInfo property using lazy loading pattern in document formats | Enhancement |
| METADATANET-1525 | Load only existing metadata keys into PdfMetadata class | Enhancement |
| METADATANET-1533 | Faster deleting of EXIF metadata | Enhancement |
| METADATANET-1534 | Faster updating of EXIF metadata | Enhancement |
| METADATANET-1463 | Ability to read thumbnail in document formats | New Feature |

## Public API and Backward Incompatible Changes

{{< alert style="info" >}}This section lists public API changes that were introduced in GroupDocs.Metadata for .NET 17.03.0 It includes not only new and obsoleted public methods, but also a description of any changes in the behavior behind the scenes in GroupDocs.Metadata which may affect existing code. Any behavior introduced that could be seen as a regression and modifies existing behavior is especially important and is documented here.{{< /alert >}}

#### Load DocumentInfo Property Using Lazy Loading pattern in Document Formats

This enhancement loads DocumentInfo property in DocumentFormat using lazy loading pattern.

Given below is an example related to this enhancement



```csharp
// path to the MS Word file
string path = @"C:\download files\10_page.doc";

// initialize DocFormat
DocFormat docFormat = new DocFormat(path);

// get document info
DocumentInfo documentInfo = docFormat.DocumentInfo;

// next call returns previous documentInfo object
DocumentInfo next = docFormat.DocumentInfo;

```

#### Load Only Existing Metadata Keys into PdfMetadata Class

PDF format may contain regular keys like 'Author', 'Title', 'Creator' etc. But for some reasons they may be absent. In this case PdfMetadata.Keys property should not contain these absent properties.

Given below is an example related to this enhancement



```csharp
// path to the PDF file
string path = @"C:\\example.pdf";

// initialize PdfFormat
PdfFormat pdfFormat = new PdfFormat(path);

// get pdf properties
PdfMetadata properties = pdfFormat.DocumentProperties;

// go through Keys property and display related PDF properties
foreach (string key in properties.Keys)
{
 Console.WriteLine("[{0}]={1}", key, properties[key]);
}

```

#### Faster Deleting of EXIF Metadata

Faster deleting of EXIF metadata

Given below is an example related to this enhancement



```csharp
// path to the jpg file
string path = @"C:\\example.jpg";

// initialize JpegFormat
JpegFormat jpegFormat = new JpegFormat(path);

// reset all exif properties
jpegFormat.RemoveExifInfo();

// and commit changes
jpegFormat.Save(@"C:\\result.jpg");
```

#### Faster Updating of EXIF Metadata

Faster updating of EXIF metadata

Given below is an example related to this enhancement



```csharp
// path to the jpg file
string path = @"C:\\example.jpg";

// initialize JpegFormat
JpegFormat jpegFormat = new JpegFormat(path);

// get EXIF data
JpegExifInfo exif = (JpegExifInfo)jpegFormat.GetExifInfo();

if (exif == null)
{
 // initialize EXIF data if null
 exif = new JpegExifInfo();
}

// set artist
exif.Artist = "test artist";

// set the name of the camera's owner
exif.CameraOwnerName = "camera owner's name";

// set description
exif.ImageDescription = "test description";

// update EXIF data
jpegFormat.SetExifInfo(exif);

// and commit changes
jpegFormat.Save(@"C:\\result.jpg");

```

#### Ability to Read Thumbnail in Document Formats

This feature allows to read thumbnail of first page in Word, Pdf and Excel formats. Feature is available only in licensed mode  
**Public API changes**  
Added **Thumbnail** property into class **GroupDocs.Metadata.Formats.Document.DocumentFormat**

This example demonstrates how to read thumbnail in Word document:



```csharp
// path to the MS Word file
string path = @"c:\download files\About_the_job.docx";

// initialize DocFormat
DocFormat docFormat = new DocFormat(path);

// get thumbnail
byte[] thumbnailData = docFormat.Thumbnail;

// write thumbnail to PNG image since it has png format
File.WriteAllBytes("C:\\changes.png", thumbnailData);

```

In case of using Excel format document may be empty. In this case need to check if thumbnail is not empty



```csharp
// path to the MS Excel file
string path = @"c:\work.xlsx";

// initialize XlsFormat
XlsFormat docFormat = new XlsFormat(path);

// get thumbnail
byte[] thumbnailData = docFormat.Thumbnail;

// check if first sheet is empty
if (thumbnailData.Length == 0)
{
 Console.WriteLine("Excel sheet is empty and does not contain data");
}
else
{
 // write thumbnail to PNG image since it has png format
 File.WriteAllBytes("C:\\changes.png", thumbnailData);
}

```
