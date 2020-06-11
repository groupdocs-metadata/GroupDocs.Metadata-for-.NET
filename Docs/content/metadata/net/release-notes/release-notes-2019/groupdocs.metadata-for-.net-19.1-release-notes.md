---
id: groupdocs-metadata-for-net-19-1-release-notes
url: metadata/net/groupdocs-metadata-for-net-19-1-release-notes
title: GroupDocs.Metadata for .NET 19.1 Release Notes
weight: 7
description: ""
keywords: 
productName: GroupDocs.Metadata for .NET
hideChildren: False
---
{{< alert style="info" >}}This page contains release notes for GroupDocs.Metadata for .NET 19.1.{{< /alert >}}

## Major Features

There are the following features and enhancements in this release:

*   Add support for the Matroska multimedia container
*   Add support for password-protected OneNote documents
*   Reduce memory consumption of supported Visio formats
*   Reduce memory consumption of supported OneNote formats
*   Reduce memory consumption of supported CAD formats
*   Reduce memory consumption of supported Email formats
*   Reduce memory consumption of the MOV format
*   Remove the obsolete code related to the TIFF/EXIF functionality
*   Remove obsolete members of the DublinCorePackage class

## All Changes

| Key | Summary | Category |
| --- | --- | --- |
| METADATANET-519 | Add support for the Matroska multimedia container | New Feature |
| METADATANET-2556 | Add support for password-protected OneNote documents | New Feature |
| METADATANET-2513 | Reduce memory consumption of supported Visio formats | Enhancement |
| METADATANET-2517 | Reduce memory consumption of supported OneNote formats | Enhancement |
| METADATANET-2538 | Reduce memory consumption of supported CAD formats | Enhancement |
| METADATANET-2539 | Reduce memory consumption of supported Email formats | Enhancement |
| METADATANET-2544 | Reduce memory consumption of the MOV format | Enhancement |
| METADATANET-1565 | Remove the obsolete code related to the TIFF/EXIF functionality | Enhancement |
| METADATANET-1577 | Remove obsolete members of the DublinCorePackage class | Enhancement |

## Public API and Backward Incompatible Changes

{{< alert style="info" >}}This section lists public API changes that were introduced in GroupDocs.Metadata for .NET 19.1. It includes not only new and obsoleted public methods, but also a description of any changes in the behavior behind the scenes in GroupDocs.Metadata which may affect existing code. Any behavior introduced that could be seen as regression and modifies existing behavior is especially important and is documented here.{{< /alert >}}

### Add support for the Matroska multimedia container

##### Description

This new feature allows a user to work with multimedia files encoded with the Matroska container.

##### Public API changes

The *MatroskaFormat* class has been added to the *GroupDocs.Metadata.Formats.Video* namespace

The *MatroskaSegmentInfoMetadata* class has been added to the *GroupDocs.Metadata.Formats.Video* namespace

The *MatroskaSimpleTagMetadata* class has been added to the *GroupDocs.Metadata.Formats.Video* namespace

The *MatroskaTagMetadata* class has been added to the *GroupDocs.Metadata.Formats.Video* namespace

The *MatroskaTargetTypeValue *enum has been added to the *GroupDocs.Metadata.Formats.Video* namespace

The *MatroskaTrackMetadata *class has been added to the *GroupDocs.Metadata.Formats.Video* namespace

The *MatroskaTrackType* enum has been added to the *GroupDocs.Metadata.Formats.Video* namespace

The *MatroskaVideoDisplayUnit* enum has been added to the *GroupDocs.Metadata.Formats.Video* namespace

The *MatroskaVideoFieldOrder* enum has been added to the *GroupDocs.Metadata.Formats.Video* namespace

The *MatroskaVideoFlagInterlaced *enum has been added to the *GroupDocs.Metadata.Formats.Video* namespace

The *MatroskaVideoStereoMode *enum has been added to the *GroupDocs.Metadata.Formats.Video* namespace

The *MatroskaVideoTrackMetadata *class has been added to the *GroupDocs.Metadata.Formats.Video* namespace

##### Usecases

Read MKV video metadata.

**C#**

```csharp
using (MatroskaFormat format = new MatroskaFormat(@"D:\input.mkv"))
{
    Console.WriteLine(format.EbmlHeader.DocType);
    Console.WriteLine(format.EbmlHeader.DocTypeReadVersion);
    Console.WriteLine(format.EbmlHeader.DocTypeVersion);
    Console.WriteLine(format.EbmlHeader.ReadVersion);
    Console.WriteLine(format.EbmlHeader.Version);
    foreach (MatroskaSegmentInfoMetadata segment in format.Segments)
    {
        Console.WriteLine(segment.DateUtc);
        Console.WriteLine(segment.Duration);
        Console.WriteLine(segment.MuxingApp);
        Console.WriteLine(segment.SegmentFilename);
        Console.WriteLine(segment.SegmentUid);
        Console.WriteLine(segment.TimecodeScale);
        Console.WriteLine(segment.Title);
        Console.WriteLine(segment.WritingApp);
    }
    foreach (MatroskaTagMetadata tag in format.Tags)
    {
        Console.WriteLine(tag.TargetType);
        Console.WriteLine(tag.TargetTypeValue);
        Console.WriteLine(tag.TagTrackUid);
        foreach (MetadataProperty simpleTag in tag.SimpleTags)
        {
            Console.WriteLine(simpleTag.GetFormattedValue());
        }
    }
    foreach (MatroskaTrackMetadata track in format.Tracks)
    {
        Console.WriteLine(track.CodecId);
        Console.WriteLine(track.CodecName);
        Console.WriteLine(track.DefaultDuration);
        Console.WriteLine(track.FlagEnabled);
        Console.WriteLine(track.Language);
        Console.WriteLine(track.LanguageIetf);
        Console.WriteLine(track.Name);
        Console.WriteLine(track.TrackNumber);
        Console.WriteLine(track.TrackType);
        Console.WriteLine(track.TrackUid);
        MatroskaAudioTrackMetadata audioTrack = track as MatroskaAudioTrackMetadata;
        if (audioTrack != null)
        {
            Console.WriteLine(audioTrack.SamplingFrequency);
            Console.WriteLine(audioTrack.OutputSamplingFrequency);
            Console.WriteLine(audioTrack.Channels);
            Console.WriteLine(audioTrack.BitDepth);
        }
        MatroskaVideoTrackMetadata videoTrack = track as MatroskaVideoTrackMetadata;
        if (videoTrack != null)
        {
            Console.WriteLine(videoTrack.FlagInterlaced);
            Console.WriteLine(videoTrack.FieldOrder);
            Console.WriteLine(videoTrack.StereoMode);
            Console.WriteLine(videoTrack.AlphaMode);
            Console.WriteLine(videoTrack.PixelWidth);
            Console.WriteLine(videoTrack.PixelHeight);
            Console.WriteLine(videoTrack.PixelCropBottom);
            Console.WriteLine(videoTrack.PixelCropTop);
            Console.WriteLine(videoTrack.PixelCropLeft);
            Console.WriteLine(videoTrack.PixelCropRight);
            Console.WriteLine(videoTrack.DisplayWidth);
            Console.WriteLine(videoTrack.DisplayHeight);
            Console.WriteLine(videoTrack.DisplayUnit);
        }
    }
} 
```

### Add support for password-protected OneNote documents

##### Description

This new feature allows a user to work with password-protected OneNote documents.

##### Public API changes

The *OneNoteFormat(string, LoadOptions)* constructor has been added to the *OneNoteFormat *class

The *OneNoteFormat**(Stream, LoadOptions)* constructor has been added to the *OneNoteFormat *class

##### Usecases

Load a password-protected *OneNote* document.

**C#**

```csharp
LoadOptions loadOptions = new LoadOptions("password");
using (OneNoteFormat format = new OneNoteFormat(@"D:\protected\input.one", loadOptions))
{
    // Working with the password-protected document
}
```

Check if a document is password-protected.

**C#**

```csharp
if (MetadataUtility.IsProtected(@"D:\protected\input.one"))
{
    // Working with the password-protected document
}
```

### Reduced memory consumption of supported Visio formats

##### Description

This enhancement allows working with Visio documents with less memory consumption.

##### Public API changes

None.

##### Usecases

Please note that the *VisioFormat *class implements the *IDisposable* interface and it's necessary to call the *Dispose()* method when you're done working with its instance.

**C#**

```csharp
using (VisioFormat format = new VisioFormat(@"d:\input.vsdx"))
{
    // Working with metadata
}
```

If you are loading a Visio document from a stream, it's up to you to close the stream when the file is not needed anymore.

**C#**

```csharp
using (Stream stream = File.Open(@"d:\input.vsdx", FileMode.Open, FileAccess.ReadWrite))
{
    using (VisioFormat format = new VisioFormat(stream))
    {
        // Working with metadata
    }
    // The stream is still open here
}
```

The same rule works if you are saving the output file into a stream.

**C#**

```csharp
using (Stream stream = File.Open(@"d:\output.vsdx", FileMode.OpenOrCreate, FileAccess.ReadWrite))
{
    using (VisioFormat format = new VisioFormat(@"d:\input.vsdx"))
    {
        // Working with metadata
 
        format.Save(stream);
    }
    // The stream is still open here
}
```

### Reduced memory consumption of supported OneNote formats

##### Description

This enhancement allows working with OneNote documents with less memory consumption.

##### Public API changes

None.

##### Usecases

Please note that the *OneNoteFormat* class implements the *IDisposable* interface and it's necessary to call the *Dispose()* method when you're done working with its instance.

**C#**

```csharp
using (OneNoteFormat format = new OneNoteFormat(@"d:\input.one"))
{
    // Working with metadata
}
```

If you are loading a OneNote document from a stream, it's up to you to close the stream when the file is not needed anymore.

**C#**

```csharp
using (Stream stream = File.Open(@"d:\input.one", FileMode.Open, FileAccess.ReadWrite))
{
    using (OneNoteFormat format = new OneNoteFormat(stream))
    {
        // Working with metadata
    }
    // The stream is still open here
}
```

The same rule works if you are saving the output file into a stream.

**C#**

```csharp
using (Stream stream = File.Open(@"d:\output.one", FileMode.OpenOrCreate, FileAccess.ReadWrite))
{
    using (OneNoteFormat format = new OneNoteFormat(@"d:\input.one"))
    {
        // Working with metadata
 
        format.Save(stream);
    }
    // The stream is still open here
}
```

### Reduced memory consumption of supported CAD formats

##### Description

This enhancement allows working with supported CAD formats with less memory consumption.

##### Public API changes

None.

##### Usecases

Please note that the *DwgFormat* and *DxfFormat* classes implement the *IDisposable* interface and it's necessary to call the *Dispose()* method when you're done working with the instance.

**C#**

```csharp
using (DxfFormat format = new DxfFormat(@"d:\input.dxf"))
{
    // Working with metadata
}
```

If you are loading a CAD drawing from a stream, it's up to you to close the stream when the file is not needed anymore.

**C#**

```csharp
using (Stream stream = File.Open(@"d:\input.dwg", FileMode.Open, FileAccess.ReadWrite))
{
    using (DwgFormat format = new DwgFormat(stream))
    {
        // Working with metadata
    }
    // The stream is still open here
}
```

The same rule works if you are saving the output file into a stream.

**C#**

```csharp
using (Stream stream = File.Open(@"d:\output.dxf", FileMode.OpenOrCreate, FileAccess.ReadWrite))
{
    using (DxfFormat format = new DxfFormat(@"d:\input.dxf"))
    {
        // Working with metadata
 
        format.Save(stream);
    }
    // The stream is still open here
}
```

### Reduced memory consumption of supported Email formats

##### Description

This enhancement allows working with saved email messages with less memory consumption.

##### Public API changes

None.

##### Usecases

Please note that the *EmlFormat* and *OutlookMessage* classes implement the *IDisposable* interface and it's necessary to call the *Dispose()* method when you're done working with the instance.

**C#**

```csharp
using (EmlFormat format = new EmlFormat(@"d:\input.eml"))
{
    // Working with metadata
}
```

If you are loading an email message from a stream, it's up to you to close the stream when the file is not needed anymore.

**C#**

```csharp
using (Stream stream = File.Open(@"d:\input.msg", FileMode.Open, FileAccess.ReadWrite))
{
    using (OutlookMessage format = new OutlookMessage(stream))
    {
        // Working with metadata
    }
    // The stream is still open here
}
```

The same rule works if you are saving the output file into a stream.

**C#**

```csharp
using (Stream stream = File.Open(@"d:\output.eml", FileMode.OpenOrCreate, FileAccess.ReadWrite))
{
    using (EmlFormat format = new EmlFormat(@"d:\input.eml"))
    {
        // Working with metadata
 
        format.Save(stream);
    }
    // The stream is still open here
}
```

### Reduced memory consumption of supported MOV formats

##### Description

This enhancement allows working with MOV videos with less memory consumption.

##### Public API changes

The *QuickTimeAtom.Data* property has been marked as obsolete

The *DataOffset* property has been added to the *QuickTimeAtom* class

The *DataSize* property has been added to the *QuickTimeAtom* class

##### Usecases

Please note that the *MovFormat* class implements the *IDisposable* interface and it's necessary to call the *Dispose()* method when you're done working with its instance.

**C#**

```csharp
using (MovFormat format = new MovFormat(@"d:\input.mov"))
{
    // Working with metadata
}
```

If you are loading a MOV video from a stream, it's up to you to close the stream when the file is not needed anymore.

**C#**

```csharp
using (Stream stream = File.Open(@"d:\input.mov", FileMode.Open, FileAccess.ReadWrite))
{
    using (MovFormat format = new MovFormat(stream))
    {
        // Working with metadata
    }
    // The stream is still open here
}
```

The same rule works if you are saving the output file into a stream.

**C#**

```csharp
using (Stream stream = File.Open(@"d:\output.mov", FileMode.OpenOrCreate, FileAccess.ReadWrite))
{
    using (MovFormat format = new MovFormat(@"d:\input.mov"))
    {
        // Working with metadata
 
        format.Save(stream);
    }
    // The stream is still open here
}
```

### Remove the obsolete code related to the TIFF/EXIF functionality

##### Description

This enhancement removes some obsolete classes, enums and members connected with the TIFF/EXIF functionality.

##### Public API changes

The *ExifProperty* class has been removed from the *GroupDocs.Metadata.Formats.Image* namespace

The *ExifPropertyType* enum has been removed from the *GroupDocs.Metadata.Formats.Image* namespace

The *Value* property has been removed from the *TiffAsciiTag* class

The *Value* property has been removed from the *TiffByteTag* class

The *Value* property has been removed from the *TiffLongTag* class

The *Value* property has been removed from the *TiffRationalTag* class

The *Value* property has been removed from the *TiffSByteTag* class

The *Value* property has been removed from the *TiffSLongTag* class

The *Value* property has been removed from the *TiffSRationalTag* class

The *Value* property has been removed from the *TiffSShortTag* class

The *Value* property has been removed from the *TiffShortTag* class

The *TiffLongTag(TiffTagIdEnum,Int32)* constructor has been removed from the *TiffLongTag* class

The *TiffRationalTag(TiffTagIdEnum,Rational)* constructor has been removed from the *TiffRationalTag *class

The *TiffSByteTag(TiffTagIdEnum,Int32)* constructor has been removed from the *TiffSByteTag*class

The *TiffSLongTag(TiffTagIdEnum,Int32)* constructor has been removed from the *TiffSLongTag*class

The *TiffSRationalTag(TiffTagIdEnum,SRational)* constructor has been removed from the *TiffSRationalTag *class

The *TiffSShortTag(TiffTagIdEnum,Int16)* constructor has been removed from the *TiffSShortTag*class

The *TiffShortTag(TiffTagIdEnum,Int16)* constructor has been removed from the *TiffShortTag *class

The *CompareExif(String,String,ComparerSearchType)* method has been removed from the *ComparisonFacade *class

The *CompareExif(Stream,Stream,ComparerSearchType)* method has been removed from the *ComparisonFacade *class

The *ScanExif(String,String,SearchCondition)* method has been removed from the *SearchFacade *class

The *ScanExif(String,String)* method has been removed from the *SearchFacade *class

The *ScanExif(Stream,String,SearchCondition)* method has been removed from the *SearchFacade *class

The *ScanExif(Stream,String)* method has been removed from the *SearchFacade *class

The *ScanExif(String,Regex)* method has been removed from the *SearchFacade *class

The *ScanExif(Stream,Regex)* method has been removed from the *SearchFacade *class

##### Usecases

Compare EXIF properties of two different documents.

**C#**

```csharp
TiffTag[] result = ComparisonFacade.CompareExifTags(@"D:\input1.jpg", @"D:\input2.jpg", ComparerSearchType.Intersection);
```

Search for EXIF tags using the *SearchFacade* class.

**C#**

```csharp
TiffTag[] result = SearchFacade.ScanExifTags(@"D:\input.jpg", "james");
```

Work with EXIF tags using alternative properties and constructors.

**C#**

```csharp
TiffLongTag width = new TiffLongTag(TiffTagIdEnum.ImageWidth, new uint[] { 123 });
TiffLongTag length = new TiffLongTag(TiffTagIdEnum.ImageLength, new uint[] { 123 });
using (JpegFormat format = new JpegFormat(@"D:\input.jpg"))
{
    format.ExifValues.Tags = new TiffTag[] { width, length };
    format.Save(@"D:\output.jpg");
}
Console.WriteLine(width.TagValue[0]);
Console.WriteLine(length.TagValue[0]);
```

### Remove obsolete members of the DublinCorePackage class

##### Description

This enhancement removes some obsolete members of the *DublinCorePackage* class

##### Public API changes

The *Subject* property has been removed from the *DublinCorePackage* class

The *SetSubject(String\[\])* method has been removed from the *DublinCorePackage* class

##### Usecases

Please use the *Subjects* property instead.

**C#**

```csharp
using (JpegFormat format = new JpegFormat(@"D:\input.jpg"))
{
    DublinCorePackage dublinCore = format.XmpValues.Schemes.DublinCore;
    foreach (string subject in dublinCore.Subjects)
    {
        Console.WriteLine(subject);
    }
}
```

**C#**

```csharp
using (JpegFormat format = new JpegFormat(@"D:\input.jpg"))
{
    DublinCorePackage dublinCore = format.XmpValues.Schemes.DublinCore;
    dublinCore.Subjects = new[] {"test subject"};
    format.Save(@"D:\output.jpg");
}
```
