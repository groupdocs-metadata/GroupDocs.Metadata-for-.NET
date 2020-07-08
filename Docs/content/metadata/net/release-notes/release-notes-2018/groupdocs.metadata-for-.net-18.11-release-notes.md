---
id: groupdocs-metadata-for-net-18-11-release-notes
url: metadata/net/groupdocs-metadata-for-net-18-11-release-notes
title: GroupDocs.Metadata for .NET 18.11 Release Notes
weight: 2
description: ""
keywords: 
productName: GroupDocs.Metadata for .NET
hideChildren: False
---
{{< alert style="info" >}}This page contains release notes for GroupDocs.Metadata for .NET 18.11.{{< /alert >}}

## Major Features

There are the following features and enhancements in this release:

*   Reduce memory consumption of the PDF format
*   Reduce memory consumption of supported Excel formats
*   XlsFormat: Add support for missing metadata properties
*   Implement the ability to work with metadata stored in FLV files

## All Changes

| Key | Summary | Category |
| --- | --- | --- |
| METADATANET-1640 | Reduce memory consumption of the PDF format | Enhancement |
| METADATANET-2422 | Reduce memory consumption of supported Excel formats | Enhancement |
| METADATANET-2436 | XlsFormat: Add support for missing metadata properties | Enhancement |
| METADATANET-470 | Implement the ability to work with metadata stored in FLV files | New Feature |

## Public API and Backward Incompatible Changes

{{< alert style="info" >}}This section lists public API changes that were introduced in GroupDocs.Metadata for .NET 18.11. It includes not only new and obsoleted public methods, but also a description of any changes in the behaviour behind the scenes in GroupDocs.Metadata which may affect existing code. Any behaviour introduced that could be seen as a regression and modifies existing behaviour is especially important and is documented here.{{< /alert >}}

### Reduce memory consumption of the PDF format

##### Description

This enhancement allows working with PDF documents with less memory consumption.

##### Public API changes

None.

##### Usecases

Please note that the *PdfFormat* class implements the *IDisposable* interface and it's necessary to call the *Dispose()* method when you're done working with its instance.



```csharp
using (PdfFormat format = new PdfFormat(@"d:\input.pdf"))
{
    // Working with metadata
}
```

If you are loading a PDF file from a stream, it's up to you to close the stream when the file is not needed anymore.



```csharp
using (Stream stream = File.Open(@"d:\input.pdf", FileMode.Open, FileAccess.ReadWrite))
{
    using (PdfFormat format = new PdfFormat(stream))
    {
        // Working with metadata
    }
    // The stream is still open here
}
```

The same rule works if you are saving the output file into a stream.



```csharp
using (Stream stream = File.Open(@"d:\output.pdf", FileMode.OpenOrCreate, FileAccess.ReadWrite))
{
    using (PdfFormat format = new PdfFormat(@"d:\input.pdf"))
    {
        // Working with metadata
 
        format.Save(stream);
    }
    // The stream is still open here
}
```

### Reduce memory consumption of the Excel formats

##### Description

This enhancement allows working with Excel documents with less memory consumption.

##### Public API changes

None.

##### Usecases

Please note that the *XlsFormat* class implements the *IDisposable* interface and it's necessary to call the *Dispose()* method when you're done working with its instance.



```csharp
using (XlsFormat format = new XlsFormat(@"d:\input.xlsx"))
{
    // Working with metadata
}
```

If you are loading an Excel document from a stream, it's up to you to close the stream when the file is not needed anymore.



```csharp
using (Stream stream = File.Open(@"d:\input.xls", FileMode.Open, FileAccess.ReadWrite))
{
    using (XlsFormat format = new XlsFormat(stream))
    {
        // Working with metadata
    }
    // The stream is still open here
}
```

The same rule works if you are saving the output file into a stream.



```csharp
using (Stream stream = File.Open(@"d:\output.xlsx", FileMode.OpenOrCreate, FileAccess.ReadWrite))
{
    using (XlsFormat format = new XlsFormat(@"d:\input.xlsx"))
    {
        // Working with metadata
 
        format.Save(stream);
    }
    // The stream is still open here
}
```

### Add support for missing properties in XlsFormat format

##### Description

This enhancement adds some new metadata properties to the XlsMetadata class.

##### Public API changes

The *Language* property has been added to the *XlsMetadata* class

The setter has been added to the *XlsMetadata.ContentStatus* property

The setter has been added to the *XlsMetadata.ContentType* property

The setter has been added to the *XlsMetadata.CreatedTime* property

The *TotalEditingTime* property has been added to the *XlsMetadata* class

The *LastSavedTime* property has been added to the *XlsMetadata* class

The setter has been added to the *XlsMetadata.LastPrintedDate* property

The setter has been added to the *XlsMetadata.LastSavedBy* property

The *XlsMetadata.**RevisionNumber *property has been marked as obsolete

The *Revision* property has been added to the *XlsMetadata* class

The setter has been added to the *XlsMetadata.Version* property

##### Usecases

Get and set Excel metadata properties



```csharp
using (XlsFormat format = new XlsFormat(@"D:\input.xlsx"))
{
    // Get the current values
    Console.WriteLine(format.DocumentProperties.Language);
    Console.WriteLine(format.DocumentProperties.ContentStatus);
    Console.WriteLine(format.DocumentProperties.ContentType);
    Console.WriteLine(format.DocumentProperties.CreatedTime);
    Console.WriteLine(format.DocumentProperties.TotalEditingTime);
    Console.WriteLine(format.DocumentProperties.LastSavedTime);
    Console.WriteLine(format.DocumentProperties.LastPrintedDate);
    Console.WriteLine(format.DocumentProperties.LastSavedBy);
    Console.WriteLine(format.DocumentProperties.Revision);
    Console.WriteLine(format.DocumentProperties.Version);
 
    // Update the metadata properties
    format.DocumentProperties.Language = "test language";
    format.DocumentProperties.ContentStatus = "test content status";
    format.DocumentProperties.ContentType = "test content type";
    format.DocumentProperties.CreatedTime = DateTime.Now;
    format.DocumentProperties.TotalEditingTime = 100;
    format.DocumentProperties.LastSavedTime = DateTime.Now;
    format.DocumentProperties.LastPrintedDate = DateTime.Now;
    format.DocumentProperties.LastSavedBy = "test last saved by";
    format.DocumentProperties.Revision = "test revision";
    format.DocumentProperties.Version = "12.1111";
 
    format.Save(@"D:\output.xlsx");
}
```

### Implement the ability to work with metadata stored in FLV files

##### Description

This new feature allows a user to work with metadata stored in FLV files.

##### Public API changes

The *FlvFormat* class has been added to the *GroupDocs.Metadata.Formats.Video* namespace

The *FlvHeader* class has been added to the *GroupDocs.Metadata.Formats.Video* namespace

The *Flv* item has been added to the *DocumentType* enum

The *Flv* item has been added to the *MetadataType* enum

##### Usecases

Check whether a file is an FLV video.



```csharp
using (FileFormatChecker checker = new FileFormatChecker(@"D:\input.unknown"))
{
    if (checker.GetDocumentType() == DocumentType.Flv)
    {
        // The file is an FLV video
    }
}
```

Read and write XMP metadata.



```csharp
using (FlvFormat format = new FlvFormat(@"D:\input.flv"))
{
    Console.WriteLine(format.XmpValues.Schemes.XmpBasic.CreateDate);
    Console.WriteLine(format.XmpValues.Schemes.XmpBasic.Label);
    Console.WriteLine(format.XmpValues.Schemes.DublinCore.Source);
    Console.WriteLine(format.XmpValues.Schemes.DublinCore.Format);
 
    format.XmpValues.Schemes.XmpBasic.CreateDate = DateTime.Now;
    format.XmpValues.Schemes.XmpBasic.Label = "Test";
    format.XmpValues.Schemes.DublinCore.Source = "http://groupdocs.com";
    format.XmpValues.Schemes.DublinCore.Format = "FLV Video";
 
    format.Save(@"D:\output.flv");
}
```

Remove XMP metadata.



```csharp
using (FlvFormat format = new FlvFormat(@"D:\input.flv"))
{
    format.RemoveXmpData();
    format.Save(@"D:\output.flv");
}
```

Read FLV header metadata.



```csharp
using (FlvFormat format = new FlvFormat(@"D:\input.flv"))
{
    Console.WriteLine(format.Header.Version);
    Console.WriteLine(format.Header.HasVideoTags);
    Console.WriteLine(format.Header.HasAudioTags);
    Console.WriteLine(Convert.ToString(format.Header.TypeFlags, 2).PadLeft(8, '0'));
}
```
