---
id: groupdocs-metadata-for-net-18-10-release-notes
url: metadata/net/groupdocs-metadata-for-net-18-10-release-notes
title: GroupDocs.Metadata for .NET 18.10 Release Notes
weight: 3
description: ""
keywords: 
productName: GroupDocs.Metadata for .NET
hideChildren: False
---
{{< alert style="info" >}}This page contains release notes for GroupDocs.Metadata for .NET 18.10.{{< /alert >}}

## Major Features

There are the following features and enhancements in this release:

*   Implement the ability to update Lyrics3 tags
*   Remove MetadataUtility obsolete methods
*   Reduce memory consumption of the PNG format
*   Reduce memory consumption of the JPEG2000 format
*   Reduce memory consumption of the BMP, DICOM, DJVU, EMF, WEBP and WMF formats

## All Changes

| Key | Summary | Category |
| --- | --- | --- |
| METADATANET-383 | Implement the ability to update Lyrics3 tags | New Feature |
| METADATANET-1466 | Remove MetadataUtility obsolete methods | Enhancement |
| METADATANET-1608 | Reduce memory consumption of the PNG format | Enhancement |
| METADATANET-1632 | Reduce memory consumption of the JPEG2000 format | Enhancement |
| METADATANET-1633 | Reduce memory consumption of the BMP, DICOM, DJVU, EMF, WEBP and WMF formats | Enhancement |
| METADATANET-1045 | Exception when cleaning/updating metadata of Strict Open XML Presentation (.pptx) | Bug |

## Public API and Backward Incompatible Changes

{{< alert style="info" >}}This section lists public API changes that were introduced in GroupDocs.Metadata for .NET 18.10. It includes not only new and obsoleted public methods, but also a description of any changes in the behaviour behind the scenes in GroupDocs.Metadata which may affect existing code. Any behaviour introduced that could be seen as a regression and modifies existing behaviour is especially important and is documented here.{{< /alert >}}

### Implement the ability to update Lyrics3 tags

##### Description

This new feature allows a user to update Lyrics3v2 metadata in Mp3 files.

##### Public API changes

A public constructor has been added to the *Lyrics3Field* class

The *Lyrics3v2Properties* property has been added to the *Mp3Format* class

The *Mp3Format*.*Lyrics3v2* property has been marked as obsolete

The *UpdateLyrics3v2(Lyrics3Tag)* method has been added to the *Mp3Format* class

##### Usecases

Update Lyrics3v2 metadata using the shortcut properties.



```csharp
using (Mp3Format format = new Mp3Format(@"D:\input.mp3"))
{
    format.Lyrics3v2Properties.Album = "test album";
    format.Lyrics3v2Properties.Artist = "test artist";
    format.Lyrics3v2Properties.AdditionalInfo = "test info";
    format.Lyrics3v2Properties.Lyrics = "[00:01] test lyrics";
 
    format.Save(@"D:\output.mp3");
}
```

Update Lyrics3v2 metadata by replacing the whole field collection.



```csharp
using (Mp3Format format = new Mp3Format(@"D:\input.mp3"))
{
    Lyrics3Field[] fields = new Lyrics3Field[]
    {
        new Lyrics3Field("EAL", "test album"),
        new Lyrics3Field("EAR", "test artist"),
        new Lyrics3Field("INF", "test info"),
        new Lyrics3Field("LYR", "[00:01] test lyrics"),
    };
    format.Lyrics3v2Properties.Fields = fields;
 
    format.Save(@"D:\output.mp3");
}
```

Update Lyrics3v2 metadata by replacing the whole tag.



```csharp
using (Mp3Format format = new Mp3Format(@"D:\input.mp3"))
{
    Lyrics3Tag tag = new Lyrics3Tag();
    tag.Fields = new Lyrics3Field[]
    {
        new Lyrics3Field("EAL", "test album"),
        new Lyrics3Field("EAR", "test artist"),
        new Lyrics3Field("INF", "test info"),
        new Lyrics3Field("LYR", "[00:01] test lyrics"),
    };
    format.UpdateLyrics3v2(tag);
    format.Save(@"D:\output.mp3");
}
```

### Remove MetadataUtility obsolete methods

##### Description

This enhancement removes some obsolete members of the *MetadataUtility* class.

##### Public API changes

The *CompareDoc* method has been removed form the *MetadataUtility *class

The *ComparePdf *method has been removed form the *MetadataUtility *class

The *ComparePpt *method has been removed form the *MetadataUtility *class

The *CompareXls *method has been removed form the *MetadataUtility *class

##### Usecases

Please use the *ComparisonFacade.CompareDocuments* (*ComparisonFacade.compareDocuments *in Java) method instead.



```csharp
MetadataPropertyCollection diff = ComparisonFacade.CompareDocuments(@"D:\input1.pptx", @"D:\input2.pptx", ComparerSearchType.Difference);
foreach (MetadataProperty property in diff)
{
    Console.WriteLine("Property name: {0}, value: {1}", property.Name, property.Value);
}
```

### Reduce memory consumption of the PNG format

##### Description

This enhancement allows working with PNG images with less memory consumption.

##### Public API changes

None.

##### Usecases

Please note that the *PngFormat* class implements the *IDisposable* interface and it's necessary to call the *Dispose()* method when you're done working with its instance.



```csharp
using (PngFormat format = new PngFormat(@"d:\input.png"))
{
    // Working with metadata
}
```

If you are loading a PNG file from a stream, it's up to you to close the stream when the file is not needed anymore.



```csharp
using (Stream stream = File.Open(@"d:\input.png", FileMode.Open, FileAccess.ReadWrite))
{
    using (PngFormat format = new PngFormat(stream))
    {
        // Working with metadata
    }
    // The stream is still open here
}
```

The same rule works if you are saving the output file into a stream.



```csharp
using (Stream stream = File.Open(@"d:\output.png", FileMode.OpenOrCreate, FileAccess.ReadWrite))
{
    using (PngFormat format = new PngFormat(@"d:\input.png"))
    {
        // Working with metadata
 
        format.Save(stream);
    }
    // The stream is still open here
}
```

### Reduce memory consumption of the JPEG2000 format

##### Description

This enhancement allows working with JPEG2000 images with less memory consumption.

##### Public API changes

None.

##### Usecases

Please note that the *Jp2Format* class implements the *IDisposable* interface and it's necessary to call the *Dispose()* method when you're done working with its instance.



```csharp
using (Jp2Format format = new Jp2Format(@"d:\input.jp2"))
{
    // Working with metadata
}
```

If you are loading a JPEG2000 file from a stream, it's up to you to close the stream when the file is not needed anymore.



```csharp
using (Stream stream = File.Open(@"d:\input.jp2", FileMode.Open, FileAccess.ReadWrite))
{
    using (Jp2Format format = new Jp2Format(stream))
    {
        // Working with metadata
    }
    // The stream is still open here
}
```

The same rule works if you are saving the output file into a stream.



```csharp
using (Stream stream = File.Open(@"d:\output.jp2", FileMode.OpenOrCreate, FileAccess.ReadWrite))
{
    using (Jp2Format format = new Jp2Format(@"d:\input.jp2"))
    {
        // Working with metadata
 
        format.Save(stream);
    }
    // The stream is still open here
}
```

### Reduce memory consumption of the  BMP, DICOM, DJVU, EMF, WEBP and WMF formats

##### Description

This enhancement allows working with BMP, DICOM, DJVU, EMF, WEBP and WMF images with less memory consumption

##### Public API changes

None.

##### Usecases

Please note that all classes representing the mentioned formats implement the *IDisposable* interface and it's necessary to call the *Dispose()* method when you're done working with its instance.



```csharp
using (BmpFormat format = new BmpFormat(@"d:\input.bmp"))
{
    // Working with metadata
}
```

If you are loading an image file of the appropriate format from a stream, it's up to you to close the stream when the file is not needed anymore.



```csharp
using (Stream stream = File.Open(@"d:\input.djvu", FileMode.Open, FileAccess.ReadWrite))
{
    using (DjvuFormat format = new DjvuFormat(stream))
    {
        // Working with metadata
    }
    // The stream is still open here
}
```

The same rule works if you are saving the output file into a stream.



```csharp
using (Stream stream = File.Open(@"d:\output.webp", FileMode.OpenOrCreate, FileAccess.ReadWrite))
{
    using (WebPFormat format = new WebPFormat(@"d:\input.webp"))
    {
        // Working with metadata
 
        format.Save(stream);
    }
    // The stream is still open here
}
```

### Exception when cleaning/updating metadata of Strict Open XML Presentation (.pptx)

##### Description

This enhancement allows cleaning/updating metadata of Strict Open XML Presentation(.pptx) document.

##### Public API changes

None.

##### Usecases

Clean metadata of a strict open XML presentation.



```csharp
using (PptFormat pptFormat = new PptFormat(@"D:\SOXmlPresentation.pptx"))
{
    pptFormat.CleanMetadata();
    pptFormat.Save(@"D:\SOXmlPresentation_output.pptx");
}
```

Update metadata of a strict open XML presentation.



```csharp
using (PptFormat pptFormat = new PptFormat(@"D:\SOXmlPresentation.pptx"))
{
    PptMetadata pptMetadata = pptFormat.DocumentProperties;
    pptMetadata.Title = "usman";
    pptFormat.Save(@"D:\SOXmlPresentation_output.pptx");
}
```
