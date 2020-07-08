---
id: groupdocs-metadata-for-net-18-8-release-notes
url: metadata/net/groupdocs-metadata-for-net-18-8-release-notes
title: GroupDocs.Metadata for .NET 18.8 Release Notes
weight: 5
description: ""
keywords: 
productName: GroupDocs.Metadata for .NET
hideChildren: False
---
{{< alert style="info" >}}This page contains release notes for GroupDocs.Metadata for .NET 18.8.{{< /alert >}}

## Major Features

There are the following features and enhancements in this release:

*   Refactor the classes representing TIFF tags to bring them in accordance with the tiff specification
*   Reduce memory consumption of the JPEG format
*   Reduce memory consumption of the TIFF format
*   Implement the ability to read EXIF metadata in the PSD format

## All Changes

| Key | Summary | Category |
| --- | --- | --- |
| METADATANET-2319 | Refactor the classes representing TIFF tags to bring them in accordance with the TIFF specification  | Enhancement  |
| METADATANET-2382 | Reduce memory consumption of the JPEG format  | Enhancement  |
| METADATANET-2403 | Reduce memory consumption of the TIFF format  | Enhancement  |
| METADATANET-1045 | Implement the ability to read EXIF metadata in the PSD format  | New Feature  |

## Public API and Backward Incompatible Changes

{{< alert style="info" >}}This section lists public API changes that were introduced in GroupDocs.Metadata for .NET 18.8. It includes not only new and obsoleted public methods, but also a description of any changes in the behaviour behind the scenes in GroupDocs.Metadata which may affect existing code. Any behaviour introduced that could be seen as a regression and modifies existing behaviour is especially important and is documented here.{{< /alert >}}

### Refactor the classes representing TIFF tags to bring them in accordance with the TIFF specification

##### Description

This enhancement affects the classes representing different types of TIFF tags and brings them in accordance with [the TIFF specification](https://www.itu.int/itudoc/itu-t/com16/tiff-fx/docs/tiff6.pdf).

##### Public API changes

*TiffArrayTag* class has been added to *GroupDocs.Metadata.Formats.Image* namespace  
*TiffAsciiTag.Value* property has been marked as obsolete  
*TagValue* property has been added to *TiffAsciiTag* class  
*TiffByteTag.Value* property has been marked as obsolete  
*TiffByteTag* class is now inherited from *TiffArrayTag* class  
*TiffLongTag.Value* property has been marked as obsolete  
*TiffLongTag* class is now inherited from *TiffArrayTag* class  
*TiffLongTag.TiffLongTag(TiffTagIdEnum, int)* constructor has been marked as obsolete  
*TiffRationalTag.Value* property has been marked as obsolete  
*TiffRationalTag* class is now inherited from *TiffArrayTag* class  
*TiffRationalTag.TiffRationalTag(TiffTagIdEnum, Rational)* constructor has been marked as obsolete  
*TiffSByteTag.Value* property has been marked as obsolete  
*TiffSByteTag* class is now inherited from *TiffArrayTag* class  
*TiffSByteTag.TiffSByteTag(TiffTagIdEnum, int)* constructor has been marked as obsolete  
*TiffShortTag.Value* property has been marked as obsolete  
*TiffShortTag* class is now inherited from *TiffArrayTag* class  
*TiffShortTag.TiffShortTag(TiffTagIdEnum, short)* constructor has been marked as obsolete  
*TiffSLongTag.Value* property has been marked as obsolete  
*TiffSLongTag* class is now inherited from *TiffArrayTag* class  
*TiffSLongTag.TiffSLongTag(TiffTagIdEnum, int)* constructor has been marked as obsolete  
*TiffSRationalTag.Value* property has been marked as obsolete  
*TiffSRationalTag* class is now inherited from *TiffArrayTag* class  
*TiffSRationalTag.TiffSRationalTag(TiffTagIdEnum, SRational)* constructor has been marked as obsolete  
*TiffSShortTag.Value* property has been marked as obsolete  
*TiffSShortTag* class is now inherited from *TiffArrayTag* class  
*TiffSShortTag.TiffSShortTag(TiffTagIdEnum, short)* constructor has been marked as obsolete  
*TiffDoubleTag* class has been added to *GroupDocs.Metadata.Formats.Image* namespace  
*TiffFloatTag* class has been added to *GroupDocs.Metadata.Formats.Image* namespace  
*TiffUndefinedTag* class has been added to *GroupDocs.Metadata.Formats.Image* namespace  
*TiffRationalArrayTag* class has been marked as obsolete  
*ExifProperty* class has been marked as obsolete  
*CompareExifTags(string, string, ComparerSearchType)* method has been added to *ComparisonFacade* class  
*CompareExifTags(Stream, Stream, ComparerSearchType)* method has been added to *ComparisonFacade* class  
*ScanExifTags(string, string, SearchCondition)* method has been added to *SearchFacade* class  
*ScanExifTags(string, string)* method has been added to *SearchFacade* class  
*ScanExifTags(string, Regex)* method has been added to *SearchFacade* class  
*ScanExifTags(Stream, string, SearchCondition)* method has been added to *SearchFacade* class  
*ScanExifTags(Stream, string)* method has been added to *SearchFacade* class  
*ScanExifTags(Stream, Regex)* method has been added to *SearchFacade* class  
*ComparisonFacade.CompareExif(string, string, ComparerSearchType)* method has been marked as obsolete  
*ComparisonFacade.CompareExif(Stream, Stream, ComparerSearchType)* method has been marked as obsolete  
*SearchFacade.ScanExif(string, string, SearchCondition)* method has been marked as obsolete  
*SearchFacade.ScanExif(string, string)* method has been marked as obsolete  
*SearchFacade.ScanExif(string, Regex)* method has been marked as obsolete  
*SearchFacade.ScanExif(Stream, string, SearchCondition)* method has been marked as obsolete  
*SearchFacade.ScanExif(Stream, string)* method has been marked as obsolete  
*SearchFacade.ScanExif(Stream, Regex)* method has been marked as obsolete

##### Usecases

Extract values of certain TIFF tags.



```csharp
using (TiffFormat format = new TiffFormat(@"D:\input.tif"))
{
    TiffTag[] tags = format.GetTags(format.ImageFileDirectories[0]);

    foreach (TiffTag tag in tags)
    {
        if (tag.DefinedTag == TiffTagIdEnum.XResolution || tag.DefinedTag == TiffTagIdEnum.YResolution)
        {
            Console.WriteLine("{0} = {1}", tag.DefinedTag, ((TiffRationalTag)tag).TagValue[0].Value);
        }
    }
}
```

Since the EXIF metadata standard is based on the TIFF format specification, the classes representing TIFF tags can be used to obtain particular EXIF properties as well.



```csharp
using (JpegFormat format = new JpegFormat(@"D:\input.jpg"))
{
    ExifInfo exif = format.GetExifInfo();

    if (exif != null)
    {
        foreach (TiffTag tag in exif.Tags)
        {
            if (tag.DefinedTag == TiffTagIdEnum.XResolution || tag.DefinedTag == TiffTagIdEnum.YResolution)
            {
                Console.WriteLine("{0} = {1}", tag.DefinedTag, ((TiffRationalTag) tag).TagValue[0].Value);
            }
        }
    }
}
```

The *ExifProperty* class had been duplicating the functionality of TIFF tags and having almost the same purpose, so it was marked as obsolete. Please use the new utility methods returning instances of the *TiffTag* descendants instead.



```csharp
TiffTag[] resolutionTags = SearchFacade.ScanExifTags(@"D:\input.jpg", new Regex("^(XResolution|YResolution)$"));

foreach (TiffTag resolutionTag in resolutionTags)
{
    Console.WriteLine("{0} - {1}", resolutionTag.DefinedTag, ((TiffRationalTag)resolutionTag).TagValue[0].Value);
}
```



```csharp
TiffTag[] intersection = ComparisonFacade.CompareExifTags(@"D:\input1.jpg", @"D:\input2.jpg", ComparerSearchType.Intersection);

foreach (TiffTag tag in intersection)
{
    Console.WriteLine(tag.DefinedTag);
    Console.WriteLine(tag.TagType);
    Console.WriteLine(tag.GetFormattedValue());
}
```

### Reduce memory consumption of the JPEG format 

##### Description

This enhancement allows working with jpeg images with less memory consumption.

##### Public API changes

None.

##### Usecases

Please note that the *JpegFormat* class implements the *IDisposable* interface and it's necessary to call the *Dispose()* method when you're done working with its instance.



```csharp
using (JpegFormat format = new JpegFormat(@"d:\input.jpg"))
{
    // Working with metadata
}
```

If you are loading a jpeg file from a stream, it's up to you to close the stream when the file is not needed anymore.



```csharp
using (Stream stream = File.Open(@"d:\input.jpg", FileMode.Open, FileAccess.ReadWrite))
{
    using (JpegFormat format = new JpegFormat(stream))
    {
        // Working with metadata
    }
    // The stream is still open here
}
```

The same rule works if you are saving the output file into a stream.



```csharp
using (Stream stream = File.Open(@"d:\output.jpg", FileMode.OpenOrCreate, FileAccess.ReadWrite))
{
    using (JpegFormat format = new JpegFormat(@"d:\input.jpg"))
    {
        // Working with metadata

        format.Save(stream);
    }
    // The stream is still open here
}
```

### Reduce memory consumption of the TIFF format 

##### Description

This enhancement allows working with tiff images with less memory consumption.

##### Public API changes

None.

##### Usecases

Please note that the *TiffFormat* class implements the *IDisposable* interface and it's necessary to call the *Dispose()* method when you're done working with its instance.



```csharp
using (TiffFormat format = new TiffFormat(@"d:\input.tiff"))
{
    // Working with metadata
}
```

If you are loading a tiff file from a stream, it's up to you to close the stream when the file is not needed anymore.



```csharp
using (Stream stream = File.Open(@"d:\input.tiff", FileMode.Open, FileAccess.ReadWrite))
{
    using (TiffFormat format = new TiffFormat(stream))
    {
        // Working with metadata
    }
    // The stream is still open here
}
```

The same rule works if you are saving the output file into a stream.



```csharp
using (Stream stream = File.Open(@"d:\output.tiff", FileMode.OpenOrCreate, FileAccess.ReadWrite))
{
    using (TiffFormat format = new TiffFormat(@"d:\input.tiff"))
    {
        // Working with metadata

        format.Save(stream);
    }
    // The stream is still open here
}
```

### Implement the ability to read EXIF metadata in the PSD format  

##### Description

This new feature allows a user to obtain EXIF metadata contained in PSD files.

##### Public API changes

*GetExifInfo* method has been added to *PsdFormat* class

##### Usecases

Read EXIF metadata of a PSD file



```csharp
using (PsdFormat format = new PsdFormat(@"D:\input.psd"))
{
    ExifInfo exif = format.GetExifInfo();
    if (exif != null)
    {
        foreach (TiffTag tag in exif.Tags)
        {
            Console.WriteLine(tag.DefinedTag);
            Console.WriteLine(tag.TagType);
            Console.WriteLine(tag.GetFormattedValue());
        }
    }
}
```
