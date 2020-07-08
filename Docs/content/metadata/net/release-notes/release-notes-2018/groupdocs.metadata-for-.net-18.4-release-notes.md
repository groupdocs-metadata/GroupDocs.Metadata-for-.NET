---
id: groupdocs-metadata-for-net-18-4-release-notes
url: metadata/net/groupdocs-metadata-for-net-18-4-release-notes
title: GroupDocs.Metadata for .NET 18.4 Release Notes
weight: 9
description: ""
keywords: 
productName: GroupDocs.Metadata for .NET
hideChildren: False
---
{{< alert style="info" >}}This page contains release notes for GroupDocs.Metadata for .NET 18.4{{< /alert >}}

## Major Features

There are the following features and fixes in this release:

*   BitTorrent format support
*   Implement unified DublinCore metadata reader for EPUB, DOCX, PDF
*   Implement unified approach of getting image cover across all formats (EPUB, MP3, Word, Excel)

## All Changes

| Key | Summary | Category |
| --- | --- | --- |
| METADATANET-592 | Implement BitTorrent format support  | New Feature |
| METADATANET-2101   | Implement unified DublinCore metadata reader for EPUB, DOCX, PDF   | New Feature  |
| METADATANET-2221 | Implement unified approach of getting image cover across all formats (EPUB, MP3, Word, Excel)  | New Feature |
| METADATANET-2293 | Move GroupDocsException class to GroupDocs.Shared.Exceptions namespace  | Enhancement  |
| METADATANET-1976 | GIF and PNG file's size increases after removing metadata  | Bug |
| METADATANET-2169 | The JpegFormat() method in GroupDocs.Metadata.dll isn't safe on MTA  | Bug |

## Public API and Backward Incompatible Changes

{{< alert style="info" >}}This section lists public API changes that were introduced in GroupDocs.Metadata for .NET 18.4. It includes not only new and obsoleted public methods, but also a description of any changes in the behaviour behind the scenes in GroupDocs.Metadata which may affect existing code. Any behaviour introduced that could be seen as a regression and modifies existing behaviour is especially important and is documented here.{{< /alert >}}

#### Implement BitTorrent format support 

##### Description

Implement ability to read and write metadata of torrent files.

##### Public API changes

*TorrentFormat* class has been added to *GroupDocs.Metadata.Formats.Torrent* namespace.  
*TorrentMetadata* class has been added to *GroupDocs.Metadata.Formats.Torrent* namespace.  
*TorrentFileInfo* class has been added to *GroupDocs.Metadata.Formats.Torrent* namespace.  
*Torrent* item has been added to *GroupDocs.Metadata.DocumentType* enum.  
*Torrent* item has been added to *GroupDocs.Metadata.MetadataType* enum.

##### Usecases

Read metadata of a torrent file.



```csharp
using (TorrentFormat torrentFormat = new TorrentFormat(@"D:\input.torrent"))
{
    TorrentMetadata info = torrentFormat.TorrentInfo;
    Console.WriteLine(info.Announce);
    Console.WriteLine(info.CreatedBy);
    Console.WriteLine(info.CreationDate);
    Console.WriteLine(info.Comment);
    Console.WriteLine(info.PieceLength);
    Console.WriteLine(info.Pieces.Length);

    foreach (TorrentFileInfo file in info.SharedFiles)
    {
        Console.WriteLine(file.Name);
        Console.WriteLine(file.Length);
    }
}
```

Set some properties of torrent file metadata.



```csharp
using (TorrentFormat torrentFormat = new TorrentFormat(@"D:\input.torrent"))
{
    TorrentMetadata info = torrentFormat.TorrentInfo;

    info.Comment = "test comment";
    info.CreatedBy = "test application";
    info.CreationDate = DateTime.Now;

    torrentFormat.Save(@"D:\output.torrent");
}
```

#### Implement unified DublinCore metadata reader for EPUB, DOCX, PDF 

##### Description

Implement ability to read DublinCore metadata from EPUB, DOCX and PDF files in a unified manner.

##### Public API changes

None.

##### Usecases

Read DublinCore metadata using MetadataUtility class.



```csharp
DublinCoreMetadata dublinCoreMetadata = (DublinCoreMetadata)MetadataUtility.ExtractSpecificMetadata(@"D:\input.docx", MetadataType.DublinCore);
```

### Implement unified approach of getting image cover across all formats (EPUB, MP3, Word, Excel) 

##### Description

Implement ability to read thumbnail (image cover) from EPUB, MP3, Word and Excel files in a unified manner.

##### Public API changes

*Thumbnail* item has been added to *GroupDocs.Metadata.MetadataType* enum.  
*ThumbnailMetadata* class has been added to *GroupDocs.Metadata* namespace.

##### Usecases

Read Thumbnail metadata using MetadataUtility class.



```csharp
ThumbnailMetadata thumbnailMetadata = (ThumbnailMetadata)MetadataUtility.ExtractSpecificMetadata(@"D:\input.docx", MetadataType.Thumbnail);

Console.WriteLine(thumbnailMetadata.MimeType);
Console.WriteLine(thumbnailMetadata.ImageData.Length);
```

### GIF and PNG file's size increases after removing metadata   

##### Description

After removing metadata from Gif and PNG file formats, file size increases.

##### Public API changes

None.

##### Usecases

In some cases, it is necessary to remove some specific values from XMP metadata package associated with GIF or PNG images. In previous versions of GroupDocs.Metadata this might cause unexpected increasing of the file size. Starting from version 18.4 please use the following code snippet to avoid the issue.



```csharp
using (GifFormat format = new GifFormat(@"D:\input.gif"))
{
    XmpEditableCollection xmpEditableCollection = format.XmpValues;
    XmpSchemes schemes = xmpEditableCollection.Schemes;

    schemes.DublinCore.Source = null;
    schemes.DublinCore.Subject = null;

    schemes.Pdf.Keywords = null;
    schemes.Pdf.Producer = null;

    schemes.Photoshop.City = null;
    schemes.Photoshop.Country = null;

    schemes.XmpBasic.BaseUrl = null;
    schemes.XmpBasic.Nickname = null;

    format.Save(@"D:\output.gif");
}
```

Please note that it's necessary to use null values (not empty strings) to completely remove appropriate XMP fields from the package.

### The JpegFormat() method in GroupDocs.Metadata.dll isn't safe on MTA 

##### Description

Creating instances of JpegFormat class is now safe when running in multiple threads. Please note that you still can't process single JPEG file using different instances of JpegFormat at the same time.

##### Public API changes

None.

##### Usecases

None.

### Move GroupDocsException class to GroupDocs.Shared.Exceptions namespace 

##### Description

Move GroupDocsException class to GroupDocs.Shared.Exceptions namespace.

##### Public API changes

*GroupDocsException* class has been moved from *GroupDocs.Metadata.Exceptions* to *GroupDocs.Shared.Exceptions* namespace.

##### Usecases

None.
