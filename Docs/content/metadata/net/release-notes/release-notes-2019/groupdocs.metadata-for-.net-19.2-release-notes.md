---
id: groupdocs-metadata-for-net-19-2-release-notes
url: metadata/net/groupdocs-metadata-for-net-19-2-release-notes
title: GroupDocs.Metadata for .NET 19.2 Release Notes
weight: 6
description: ""
keywords: 
productName: GroupDocs.Metadata for .NET
hideChildren: False
---
{{< alert style="info" >}}This page contains release notes for GroupDocs.Metadata for .NET 19.2.{{< /alert >}}

## Major Features

There are the following features and enhancements in this release:

*   Implement support for the ASF format
*   Implement the ability to render image previews for supported document types
*   Refactor base metadata classes to add support for hierarchical metadata structures
*   Remove obsolete EXIF APIs
*   Remove Mp3Format obsolete members

## All Changes

| Key | Summary | Category |
| --- | --- | --- |
| METADATANET-1635 | Implement support for the ASF format | New Feature |
| METADATANET-2441 | Implement the ability to render image previews for supported document types | New Feature |
| METADATANET-1369 | Refactor base metadata classes to add support for hierarchical metadata structures | Enhancement |
| METADATANET-2636 | Remove obsolete EXIF APIs | Enhancement |
| METADATANET-1636 | Remove Mp3Format obsolete members | Enhancement |

## Public API and Backward Incompatible Changes

{{< alert style="info" >}}This section lists public API changes that were introduced in GroupDocs.Metadata for .NET 19.2. It includes not only new and obsoleted public methods, but also a description of any changes in the behavior behind the scenes in GroupDocs.Metadata which may affect existing code. Any behavior introduced that could be seen as regression and modifies existing behavior is especially important and is documented here.{{< /alert >}}

### Implement support for the ASF format

This new feature allows a user to work with multimedia files encoded with the ASF container

**Public API changes**

The *AsfAudioStreamProperty* class has been added to the *GroupDocs.Metadata.Formats.Video* namespace

The *AsfBaseDescriptor *class has been added to the *GroupDocs.Metadata.Formats.Video* namespace

The *AsfBaseStreamProperty *class has been added to the *GroupDocs.Metadata.Formats.Video* namespace

The *AsfCodecInfo *class has been added to the *GroupDocs.Metadata.Formats.Video* namespace

The *AsfContentDescriptor *class has been added to the *GroupDocs.Metadata.Formats.Video* namespace

The *AsfFormat *class has been added to the *GroupDocs.Metadata.Formats.Video* namespace

The *AsfMetadata *class has been added to the *GroupDocs.Metadata.Formats.Video* namespace

The *AsfMetadataDescriptor *class has been added to the *GroupDocs.Metadata.Formats.Video* namespace

The *AsfVideoStreamProperty *class has been added to the *GroupDocs.Metadata.Formats.Video* namespace

The *AsfCodecType *enum has been added to the *GroupDocs.Metadata.Formats.Video* namespace

The *AsfDescriptorType *enum has been added to the *GroupDocs.Metadata.Formats.Video* namespace

The *AsfExtendedStreamPropertiesFlags *enum has been added to the *GroupDocs.Metadata.Formats.Video* namespace

The *AsfFilePropertiesFlag *enum has been added to the *GroupDocs.Metadata.Formats.Video* namespace

The *AsfStreamType *enum has been added to the *GroupDocs.Metadata.Formats.Video* namespace

The *Asf* item has been added to the *MetadataType* enum

The *Asf* item has been added to the *DocumentType* enum

Use case to read ASF video native metadata

**C#**

```csharp
using (AsfFormat format = new AsfFormat(@"D:\input.asf"))
{
    AsfMetadata metadata = format.AsfInfo;
    Console.WriteLine(metadata.CreationDate);
    Console.WriteLine(metadata.FileId);
    Console.WriteLine(metadata.Flags);

    foreach (AsfCodecInfo codecInfo in metadata.CodecInformation)
    {
        Console.WriteLine(codecInfo.CodecType);
        Console.WriteLine(codecInfo.Description);
        Console.WriteLine(codecInfo.Information);
        Console.WriteLine(codecInfo.Name);
    }

    foreach (AsfBaseDescriptor descriptor in metadata.MetadataDescriptors)
    {
        Console.WriteLine(descriptor.Name);
        Console.WriteLine(descriptor.GetFormattedValue());
        AsfMetadataDescriptor metadataDescriptor = descriptor as AsfMetadataDescriptor;
        if (metadataDescriptor != null)
        {
            Console.WriteLine(metadataDescriptor.Language);
            Console.WriteLine(metadataDescriptor.StreamNumber);
            Console.WriteLine(metadataDescriptor.OriginalName);
        }
    }

    foreach (AsfBaseStreamProperty property in metadata.StreamProperties)
    {
        Console.WriteLine(property.AlternateBitrate);
        Console.WriteLine(property.AverageBitrate);
        Console.WriteLine(property.AverageTimePerFrame);
        Console.WriteLine(property.Bitrate);
        Console.WriteLine(property.EndTime);
        Console.WriteLine(property.Flags);
        Console.WriteLine(property.Language);
        Console.WriteLine(property.StartTime);
        Console.WriteLine(property.StreamNumber);
        Console.WriteLine(property.StreamType);

        AsfAudioStreamProperty audioStreamProperty = property as AsfAudioStreamProperty;
        if (audioStreamProperty != null)
        {
            Console.WriteLine(audioStreamProperty.BitsPerSample);
            Console.WriteLine(audioStreamProperty.Channels);
            Console.WriteLine(audioStreamProperty.FormatTag);
            Console.WriteLine(audioStreamProperty.SamplesPerSecond);
        }

        AsfVideoStreamProperty videoStreamProperty = property as AsfVideoStreamProperty;
        if (videoStreamProperty != null)
        {
            Console.WriteLine(videoStreamProperty.BitsPerPixels);
            Console.WriteLine(videoStreamProperty.Compression);
            Console.WriteLine(videoStreamProperty.ImageHeight);
            Console.WriteLine(videoStreamProperty.ImageWidth);
        }
    }
}
```

Use case to read and write XMP metadata

**C#**

```csharp
using (AsfFormat format = new AsfFormat(@"D:\input.asf"))
{
    Console.WriteLine(format.XmpValues.Schemes.XmpBasic.CreateDate);
    Console.WriteLine(format.XmpValues.Schemes.XmpBasic.Label);
    Console.WriteLine(format.XmpValues.Schemes.DublinCore.Format);

    format.XmpValues.Schemes.XmpBasic.CreateDate = DateTime.Now;
    format.XmpValues.Schemes.XmpBasic.Label = "Test";
    format.XmpValues.Schemes.DublinCore.Format = "ASF Video";

    format.Save(@"D:\output.asf");
} 
```

Use case to remove XMP metadata

**C#**

```csharp
using (AsfFormat format = new AsfFormat(@"D:\input.asf"))
{
    format.RemoveXmpData();
    format.Save(@"D:\output.asf");
}
```

### Implement the ability to render image previews for supported document types

This new feature allows a user to render image previews for documents of some popular formats supported by GroupDocs.Metadata for .Net. It can be used for creating demo applications

**Public API changes**

The *PreviewFactory *class has been added to the *GroupDocs.Metadata.Preview *namespace

The *PreviewHandler *class has been added to the *GroupDocs.Metadata.Preview *namespace

The *PreviewImageData *class has been added to the *GroupDocs.Metadata.Preview *namespace

The *PreviewInvalidPasswordException *class has been added to the *GroupDocs.Metadata.Preview *namespace

The *PreviewNotSupportedException *class has been added to the *GroupDocs.Metadata.Preview *namespace

The *PreviewPage *class has been added to the *GroupDocs.Metadata.Preview *namespace

The *PreviewUnitOfMeasurement *enum has been added to the *GroupDocs.Metadata.Preview *namespace

The *ProtectableDocumentPreviewHandler *class has been added to the *GroupDocs.Metadata.Preview *namespace

The *CellsPreviewHandler *class has been added to the *GroupDocs.Metadata.Preview.Formats *namespace

The *DiagramPreviewHandler *class has been added to the *GroupDocs.Metadata.Preview.Formats *namespace

The *DjvuImagePreviewHandler *class has been added to the *GroupDocs.Metadata.Preview.Formats *namespace

The *GifImagePreviewHandler *class has been added to the *GroupDocs.Metadata.Preview.Formats *namespace

The *ImagePreviewHandler *class has been added to the *GroupDocs.Metadata.Preview.Formats *namespace

The *NotesPreviewHandler *class has been added to the *GroupDocs.Metadata.Preview.Formats *namespace

The *PdfPreviewHandler *class has been added to the *GroupDocs.Metadata.Preview.Formats *namespace

The *SlidesPreviewHandler *class has been added to the *GroupDocs.Metadata.Preview.Formats *namespace

The *TiffImagePreviewHandler *class has been added to the *GroupDocs.Metadata.Preview.Formats *namespace

The *WordsPreviewHandler *class has been added to the *GroupDocs.Metadata.Preview.Formats *namespace

Use case to create preview images for all document pages

**C#**

```csharp
using (PreviewHandler handler = PreviewFactory.Load(@"D:\input.docx"))
{
    for (int i = 0; i < handler.Pages.Length; i++)
    {
        PreviewImageData[] pagePreviews = handler.GetPageImage(i);
        for (int j = 0; j < pagePreviews.Length; j++)
        {
            File.WriteAllBytes(string.Format(@"D:\preview\{0}-{1}.png", i, j), pagePreviews[j].Contents);
        }
    }
} 
```

### Refactor base metadata classes to add support for hierarchical metadata structures

This enhancement is necessary to introduce metadata types with hierarchical structure

**Public API changes**

The *ReadPropertyValue* method has been added to the *DocumentMetadata* class

The *SetValueByKey* method has been added to the *DocumentMetadata* class

The *ToPropertyArray* method has been added to the *IptcDataSet* class

The *IptcDataSetCollection()* constructor has been added to the *IptcDataSetCollection* class

The *IptcDataSetCollection(IptcProperty\[\])* constructor has been added to the *IptcDataSetCollection* class

The *this\[int\]* indexer has been added to the *IptcDataSetCollection* class

The *this\[int,int\]* indexer has been added to the *IptcDataSetCollection* class

The *AddOrUpdate(IptcProperty)* method has been added to the *IptcDataSetCollection* class

The *AddOrUpdate(IptcDataSet)* method has been added to the *IptcDataSetCollection* class

The *Remove(int)* method has been added to the *IptcDataSetCollection* class

The *Remove(int,int)* method has been added to the *IptcDataSetCollection* class

The *Clear* method has been added to the *IptcDataSetCollection* class

The *ToPropertyArray* method has been added to the *IptcDataSetCollection* class

The *IptcProperty(int,int,string)* constructor has been added to the *IptcProperty* class

The *IptcProperty(int,int,int)* constructor has been added to the *IptcProperty* class

The *IptcProperty(int,int,DateTime)* constructor has been added to the *IptcProperty* class

The *AlternativeName* property has been added to the *IptcProperty* class

The *IptcValues* property has been added to the *JpegFormat* class

The *IptcValues* property has been added to the *PsdFormat* class

The *IptcValues* property has been added to the *TiffFormat* class

The *TiffTag *class is now inherited from the *MetadataProperty *class

The *IptcValues* property has been added to the *IIptc* interface

The *MetadataProperty(string,PropertyValue)* constructor has been added to the *MetadataProperty* class

The *DoubleArray* item has been added to the *MetadataPropertyType* enum

The *IntegerArray* item has been added to the *MetadataPropertyType* enum

The *LongArray* item has been added to the *MetadataPropertyType* enum

The *Metadata* item has been added to the *MetadataPropertyType* enum

The *MetadataArray* item has been added to the *MetadataPropertyType* enum

The *ToDoubleArray* method has been added to the *PropertyValue* class

The *ToIntegerArray* method has been added to the *PropertyValue* class

The *ToLongArray* method has been added to the *PropertyValue* class

The *ToMetadataArray* method has been added to the *PropertyValue* class

The *ToMetadata* method has been added to the *PropertyValue* class

The *IptcProperty *class is now inherited form the *MetadataProperty* class

The *IptcDataSetCollection.IptcDataSetCollection(IptcCollection)* constructor has been marked as obsolete

The *DocumentMetadata.this\[string\]* indexer has been marked as obsolete

The *JpegFormat.HasIptc* property has been marked as obsolete

The *JpegFormat.GetIptc* method has been marked as obsolete

The *JpegFormat.UpdateIptc* method has been marked as obsolete

The *JpegFormat.RemoveIptc* method has been marked as obsolete

The *PsdFormat.HasIptc* property has been marked as obsolete

The *PsdFormat.GetIptc* method has been marked as obsolete

The *PsdFormat.UpdateIptc* method has been marked as obsolete

The *PsdFormat.RemoveIptc* method has been marked as obsolete

The *TiffFormat.HasIptc* property has been marked as obsolete

The *TiffFormat.GetIptc* method has been marked as obsolete

The *IIptc.HasIptc* property has been marked as obsolete

The *IIptc**.GetIptc* method has been marked as obsolete

The *IIptc**.UpdateIptc* method has been marked as obsolete

The *IIptc**.RemoveIptc* method has been marked as obsolete

The *MetadataProperty.MetadataProperty()* constructor has been marked as obsolete

The *MetadataProperty.Name* property setter has been marked as obsolete

The *MetadataProperty.Value* property setter has been marked as obsolete

The *MetadataProperty.Equals(*MetadataProperty,bool*)* method has been marked as obsolete

The *PropertyValue.Equals(*PropertyValue**,bool*)* method has been marked as obsolete

The *ExifMetadata* class has been marked as obsolete

The *IptcCollection* class has been marked as obsolete

The *IptcMetadata* class has been marked as obsolete

The *IptcProperty**.IptcProperty(int,string,int,string)* constructor has been marked as obsolete

The *IptcProperty**.IptcProperty(int,string,int,DateTime)* constructor has been marked as obsolete

The *IptcProperty**.IptcProperty(int,string,int,int)* constructor has been marked as obsolete

The *IptcProperty**.PropertyType* property has been marked as obsolete

The *IptcProperty**.ToByteArray* method has been marked as obsolete

The *IptcProperty**.ToInt* method has been marked as obsolete

The *IptcProperty**.ToDate* method has been marked as obsolete

The *IptcProperty**Type* enum has been marked as obsolete

Use case to display the whole metadata tree of a file

**C#**

```csharp
static void Main(string[] args)
{
    License l = new License();
    l.SetLicense(@"D:\GroupDocs.Metadata.lic");

    using (FormatBase format = FormatFactory.RecognizeFormat(@"D:\input.asf"))
    {
        DisplayMetadataTree(format.GetMetadata(), 0);
    }

    Console.ReadKey();
}
private static void DisplayMetadataTree(Metadata metadata, int indent)
{
    if (metadata != null)
    {
        var stringMetadataType = metadata.MetadataType.ToString();
        Console.WriteLine(stringMetadataType.PadLeft(stringMetadataType.Length + indent));
        foreach (MetadataProperty property in metadata)
        {
            string stringPropertyRepresentation = string.Format("Name: {0}, Value: {1}", property.Name, property.GetFormattedValue());
            Console.WriteLine(stringPropertyRepresentation.PadLeft(stringPropertyRepresentation.Length + indent + 1));
            if (property.Value != null)
            {
                switch (property.Value.Type)
                {
                    case MetadataPropertyType.Metadata:
                        DisplayMetadataTree(property.Value.ToMetadata(), indent + 2);
                        break;
                    case MetadataPropertyType.MetadataArray:
                        DisplayMetadataTree(property.Value.ToMetadataArray(), indent + 2);
                        break;
                }
            }
        }
    }
}
private static void DisplayMetadataTree(Metadata[] metadataArray, int indent)
{
    if (metadataArray != null)
    {
        foreach (Metadata metadata in metadataArray)
        {
            DisplayMetadataTree(metadata, indent);
        }
    }
}
```

### Remove obsolete EXIF APIs

This enhancement removes some obsolete members and classes that were used to work with EXIF metadata.

**Public API changes**

The *CameraOwnerName* property has been removed from the *ExifInfo* class

The *BodySerialNumber *property has been removed from the *ExifInfo* class

The *CFAPattern* property has been removed from the *ExifInfo* class

The *UserComment* property has been removed from the *ExifInfo* class

The *JpegExifInfo* class has been removed form the *GroupDocs.Metadata.Formats.Image namespace*

##### Use cases

Please use the appropriate properties of the *ExifIfdInfo *class instead

**C#**

```csharp
using (JpegFormat format = new JpegFormat(@"D:\input.jpg"))
{
    format.ExifValues.ExifIfdData.CameraOwnerName = "test owner";
    format.ExifValues.ExifIfdData.BodySerialNumber = "body-123";
    format.ExifValues.ExifIfdData.CFAPattern = new byte[] { 1, 2, 3 };
    format.ExifValues.ExifIfdData.UserComment = "test comment";

    format.Save(@"D:\output.jpg");
}
```

The *JpegExifInfo* class is no longer needed since you can use an instance of *ExifInfo* instead

**C#**

```csharp
ExifInfo exif = new ExifInfo();
exif.Artist = "test artist";
exif.Copyright = "(C)";
exif.ExifIfdData.CameraOwnerName = "test owner";
exif.ExifIfdData.BodySerialNumber = "body-123";
exif.ExifIfdData.CFAPattern = new byte[] { 1, 2, 3 };
exif.ExifIfdData.UserComment = "test comment";

using (JpegFormat format = new JpegFormat(@"D:\input.jpg"))
{
    format.UpdateExifInfo(exif);
    format.Save(@"D:\output.jpg");
}
```

### Remove Mp3Format obsolete members

This enhancement removes some obsolete members of the *Mp3Format* class.

**Public API changes**

The *Lyrics3v2* property has been removed from the *Mp3Format* class

Please use the *GetLyrics3Tag* method instead

**C#**

```csharp
using (Mp3Format format = new Mp3Format(@"D:\input.mp3"))
{
    Lyrics3Tag lyricsTag = format.GetLyrics3Tag();
    if (lyricsTag != null)
    {
        // ...
    }
}
```
