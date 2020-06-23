---
id: groupdocs-metadata-for-net-18-9-release-notes
url: metadata/net/groupdocs-metadata-for-net-18-9-release-notes
title: GroupDocs.Metadata for .NET 18.9 Release Notes
weight: 4
description: ""
keywords: 
productName: GroupDocs.Metadata for .NET
hideChildren: False
---
{{< alert style="info" >}}This page contains release notes for GroupDocs.Metadata for .NET 18.9.{{< /alert >}}

## Major Features

There are the following enhancements in this release:

*   Remove EpubFormat.GetImageCoverBytes method (obsolete code)
*   Remove GroupDocs.Metadata.Formats.Document.InspectionResult class (obsolete code)
*   Remove XlsMetadata.ContentProperties property (obsolete code)
*   Implement the ability to read and update common TIFF/EXIF tags in TIFF images
*   Reduce memory consumption of the GIF format

## All Changes

| Key | Summary | Category |
| --- | --- | --- |
| METADATANET-2320 | Remove EpubFormat.GetImageCoverBytes method (obsolete code) | Enhancement |
| METADATANET-2321 | Remove GroupDocs.Metadata.Formats.Document.InspectionResult class (obsolete code) | Enhancement |
| METADATANET-2322 | Remove XlsMetadata.ContentProperties property (obsolete code) | Enhancement |
| METADATANET-2446 | Implement the ability to read and update common TIFF/EXIF tags in TIFF images | Enhancement |
| METADATANET-2449 | Reduce memory consumption of the GIF format | Enhancement |
| METADATANET-2417 | Unable to add TiffTag to EXIF tags | Bug |
| METADATANET-2418 | Unable to remove Title, Subject, Authors, and Copyright fields in Tiff file | Bug |
| METADATANET-2420 | TIF file SetSubject() method updates Tags field instead of Subject | Bug |

## Public API and Backward Incompatible Changes

{{< alert style="info" >}}This section lists public API changes that were introduced in GroupDocs.Metadata for .NET 18.9. It includes not only new and obsoleted public methods, but also a description of any changes in the behaviour behind the scenes in GroupDocs.Metadata which may affect existing code. Any behaviour introduced that could be seen as a regression and modifies existing behaviour is especially important and is documented here.{{< /alert >}}

### Remove EpubFormat.GetImageCoverBytes method (obsolete code)

##### Description

This enhancement removes the *EpubFormat.GetImageCoverBytes* method from the public API (obsolete code). Please use the *EpubFormat.ReadThumbnail* method instead*.*

##### Public API changes

The *GetImageCoverBytes* method has been removed from the *EpubFormat *class

##### Usecases

Get the image cover data and MIME type



```csharp
using (EpubFormat epubFormat = new EpubFormat(@"D:\input.epub"))
{
    ThumbnailMetadata thumbnail = epubFormat.ReadThumbnail();
    if (thumbnail != null)
    {
        Console.WriteLine(thumbnail.ImageData.Length);
        Console.WriteLine(thumbnail.MimeType);
    }
}
```

### Remove GroupDocs.Metadata.Formats.Document.InspectionResult class (obsolete code)

##### Description

This enhancement removes the *GroupDocs.Metadata.Formats.Document.InspectionResult* class from the public API (obsolete code). Please use an appropriate implementation of the *IInspectorResult* interface instead*.*

##### Public API changes

The *InspectionResult* class has been removed from the *GroupDocs.Metadata.Formats.Document* namespace

##### Usecases

Inspect a document.



```csharp
using (DocFormat format = new DocFormat(@"D:\input.docx"))
{
    DocInspectionResult inspectionResult = format.InspectDocument();
    Console.WriteLine(inspectionResult.DigitalSignatures.Length);
    Console.WriteLine(inspectionResult.Comments.Length);
}
```

### Remove XlsMetadata.ContentProperties property (obsolete code)

##### Description

This enhancement removes the *XlsMetadata.ContentProperties* property from the public API (obsolete code). Please use the *XlsMetadata**.ContentTypeProperties* property instead*.*

##### Public API changes

The *ContentProperties* property has been removed from the *XlsMetadata*class

##### Usecases

Get the content type properties.



```csharp
using (XlsFormat format = new XlsFormat(@"D:\input.xlsx"))
{
    foreach (XlsContentProperty property in format.DocumentProperties.ContentTypeProperties)
    {
        Console.WriteLine(property.GetFormattedValue());
    }
}
```

### Implement the ability to read and update common TIFF/EXIF tags in TIFF images 

##### Description

This enhancement allows a user to read and update some common TIFF/EXIF metadata tags in TIFF images.

##### Public API changes

The *SubfileType* item has been added to the *TiffTagIdEnum* enum  
The *T4Options* item has been added to the *TiffTagIdEnum* enum  
The *T6Options* item has been added to the *TiffTagIdEnum* enum  
The *TransferFunction* item has been added to the *TiffTagIdEnum* enum  
The *WhitePoint* item has been added to the *TiffTagIdEnum* enum  
The *PrimaryChromaticities* item has been added to the *TiffTagIdEnum* enum  
The *HalftoneHints* item has been added to the *TiffTagIdEnum* enum  
The *InkNames* item has been added to the *TiffTagIdEnum* enum  
The *DotRange* item has been added to the *TiffTagIdEnum* enum  
The *SampleFormat* item has been added to the *TiffTagIdEnum* enum  
The *SMinSampleValue* item has been added to the *TiffTagIdEnum* enum  
The *SMaxSampleValue* item has been added to the *TiffTagIdEnum* enum  
The *TransferRange* item has been added to the *TiffTagIdEnum* enum  
The *JPEGProc* item has been added to the *TiffTagIdEnum* enum  
The *JPEGInterchangeFormat* item has been added to the *TiffTagIdEnum* enum  
The *JPEGInterchangeFormatLength* item has been added to the *TiffTagIdEnum* enum  
The *JPEGRestartInterval* item has been added to the *TiffTagIdEnum* enum  
The *JPEGLosslessPredictors* item has been added to the *TiffTagIdEnum* enum  
The *JPEGPointTransforms* item has been added to the *TiffTagIdEnum* enum  
The *JPEGQTables* item has been added to the *TiffTagIdEnum* enum  
The *JPEGDCTables* item has been added to the *TiffTagIdEnum* enum  
The *JPEGACTables* item has been added to the *TiffTagIdEnum* enum  
The *YCbCrCoefficients* item has been added to the *TiffTagIdEnum* enum  
The *YCbCrSubSampling* item has been added to the *TiffTagIdEnum* enum  
The *YCbCrPositioning* item has been added to the *TiffTagIdEnum* enum  
The *ReferenceBlackWhite* item has been added to the *TiffTagIdEnum* enum  
The *UserComment* item has been added to the *TiffTagIdEnum* enum  
The *ExifIfdInfo* class has been added to the *GroupDocs.Metadata.Formats.Image* namespace  
The *ExifIfdData* property has been added to the *ExifInfo* class  
The *Artist* property has been added to the *ExifInfo* class  
The *Copyright* property has been added to the *ExifInfo* class  
The *DateTime* property has been added to the *ExifInfo* class  
The *ImageDescription* property has been added to the *ExifInfo* class  
The *ImageLength* property has been added to the *ExifInfo* class  
The *ImageWidth* property has been added to the *ExifInfo* class  
The *Make* property has been added to the *ExifInfo* class  
The *Model* property has been added to the *ExifInfo* class  
The *Software* property has been added to the *ExifInfo* class  
The *JpegExifInfo* class has been marked as obsolete  
The *ExifInfo.BodySerialNumber* property has been marked as obsolete  
The *ExifInfo.CFAPattern* property has been marked as obsolete  
The *ExifInfo.CameraOwnerName* property has been marked as obsolete  
The *ExifInfo.UserComment* property has been marked as obsolete

##### Usecases

Update common EXIF/TIFF metadata tags by using the shortcut properties.



```csharp
using (TiffFormat format = new TiffFormat(@"D:\input.tif"))
{
    format.ExifValues.Artist = "GroupDocs";
    format.ExifValues.Software = "GroupDocs.Metadata";
 
    format.Save(@"D:\output.tif");
}
```

Update common EXIF/TIFF metadata tags by replacing the whole tag collection.



```csharp
using (TiffFormat format = new TiffFormat(@"D:\input.tif"))
{
    TiffTag[] tags = new TiffTag[]
    {
        new TiffAsciiTag(TiffTagIdEnum.Artist, "GroupDocs"),
        new TiffAsciiTag(TiffTagIdEnum.Copyright, "GroupDocs.Metadata"),
    };
    format.ExifValues.Tags = tags;
 
    format.Save(@"D:\output.tif");
}
```

{{< alert style="warning" >}}Users are not able to replace/remove all the EXIF/TIFF tags contained in the collection. Some of the tags are crucial to display the image properly, so they will not be affected during metadata saving.{{< /alert >}}

Update EXIF IFD tags by using the shortcut properties.



```csharp
using (TiffFormat format = new TiffFormat(@"D:\input.tif"))
{
    format.ExifValues.ExifIfdData.UserComment = "test comment";
    format.ExifValues.ExifIfdData.BodySerialNumber = "1010101010";
    format.Save(@"D:\output.tif");
}
```

Update EXIF IFD tags by replacing the whole tag collection.



```csharp
using (TiffFormat format = new TiffFormat(@"D:\input.tif"))
{
    TiffTag[] tags = new TiffTag[]
    {
            new TiffAsciiTag((TiffTagIdEnum)42032, "test camera owner"), // CameraOwnerName
            new TiffAsciiTag((TiffTagIdEnum)42033, "test body serial number"), // BodySerialNumber
    };
    format.ExifValues.ExifIfdData.Tags = tags;
    format.Save(@"D:\output.tif");
}
```

### Reduce memory consumption of the GIF format

##### Description

This enhancement allows working with gif images with less memory consumption.

##### Public API changes

None.

##### Usecases

Please note that the *GifFormat* class implements the *IDisposable* interface and it's necessary to call the *Dispose()* method when you're done working with its instance.



```csharp
using (GifFormat format = new GifFormat(@"d:\input.gif"))
{
    // Working with metadata
}
```

If you are loading a gif file from a stream, it's up to you to close the stream when the file is not needed anymore.



```csharp
using (Stream stream = File.Open(@"d:\input.gif", FileMode.Open, FileAccess.ReadWrite))
{
    using (GifFormat format = new GifFormat(stream))
    {
        // Working with metadata
    }
    // The stream is still open here
}
```

The same rule works if you are saving the output file into a stream.



```csharp
using (Stream stream = File.Open(@"d:\output.gif", FileMode.OpenOrCreate, FileAccess.ReadWrite))
{
    using (GifFormat format = new GifFormat(@"d:\input.gif"))
    {
        // Working with metadata
 
        format.Save(stream);
    }
    // The stream is still open here
}
```

### Unable to add TiffTag to EXIF tags

##### Description

When adding TiffTag to EXIF tags in a .tif file. The API saves the file without any exception, however, it doesn't add the tags. If we get TIFF tags using ExifInfo.Tags property from the saved file, the API returns no tags.

##### Public API changes

None.

##### Usecases



```csharp
using (TiffFormat tiffFormat = new TiffFormat(@"D:\input.tif"))
{
    // get existing EXIF or create new one
    ExifInfo exif = tiffFormat.GetExifInfo() ?? new ExifInfo();
 
    // define list of tags
    List<TiffTag> tags = new List<TiffTag>();
 
    // add specific tag
    tags.Add(new TiffAsciiTag(TiffTagIdEnum.Artist, "Rida"));
    tags.Add(new TiffAsciiTag(TiffTagIdEnum.Copyright, "copyright"));
 
    // and update tags
    exif.Tags = tags.ToArray();
 
    // update exif
    tiffFormat.UpdateExifInfo(exif);
 
    tiffFormat.Save(@"D:\output.tif");
}
```

### Unable to remove Title, Subject, Authors, and Copyright fields in TIFF file

##### Description

Unable to remove Title, Subject, Authors, and Copyright fields in a TIFF file.

##### Public API changes

None.

##### Usecases



```csharp
using (TiffFormat tiffFormat = new TiffFormat(@"D:\input.tif"))
{
    tiffFormat.CleanMetadata();
    tiffFormat.Save(@"D:\output.tif");
}
```

### TIFF file SetSubject() method updates Tags field instead of Subject

##### Description

While updating the subject field of the TIFF file, Tags field gets updated.

##### Public API changes

The *Subjects* property has been added to the *DublinCorePackage* class  
The *DublinCorePackage.Subject* property has been marked as obsolete  
The *DublinCorePackage.SetSubject(string\[\])* method has been marked as obsolete

##### Usecases

Set a single subject.



```csharp
using (TiffFormat format = new TiffFormat(@"D:\input.tif"))
{
    format.XmpValues.Schemes.DublinCore.SetSubject("test subject");
    format.Save(@"D:\output.tif");
}
```

Set multiple subjects.



```csharp
using (TiffFormat format = new TiffFormat(@"D:\input.tif"))
{
    format.XmpValues.Schemes.DublinCore.Subjects = new[] { "subject 1", "subject 2" };
    format.Save(@"D:\output.tif");
}
```
