---
id: groupdocs-metadata-for-net-17-10-1-release-notes
url: metadata/net/groupdocs-metadata-for-net-17-10-1-release-notes
title: GroupDocs.Metadata for .NET 17.10.1 Release Notes
weight: 4
description: ""
keywords: 
productName: GroupDocs.Metadata for .NET
hideChildren: False
---
{{< alert style="info" >}}This page contains release notes for GroupDocs.Metadata for .NET 17.10.1{{< /alert >}}

## Major Features

There are 4 fixes in this hotfix monthly release. The most notable are:  

*   Presentation format field displays Russian text after removing the metadata
*   GroupDocs.Metadata cannot remove personal data of a TIF file
*   TIF - Bit Depth will be affected when removing metadata
*   TIF file gets damaged with getting info of XmpSchemes  
      
    

## All Changes

| Key | Summary | Category |
| --- | --- | --- |
| METADATANET-1923 | Presentation format field displays Russian text after removing the metadata | Bug |
| METADATANET-1925 | GroupDocs.Metadata cannot remove personal data of a TIF file | Bug |
| METADATANET-1931 | TIF - Bit Depth will be affected when removing metadata | Bug |
| METADATANET-1932 | TIF file gets damaged with getting info of XmpSchemes | Bug |

## Public API and Backward Incompatible Changes

{{< alert style="info" >}}This section lists public API changes that were introduced in GroupDocs.Metadata for .NET 17.10.1 It includes not only new and obsoleted public methods, but also a description of any changes in the behavior behind the scenes in GroupDocs.Metadata which may affect existing code. Any behavior introduced that could be seen as a regression and modifies existing behavior is especially important and is documented here.{{< /alert >}}

#### Presentation format field displays Russian text after removing the metadata

The bug that displayed Russian text after removing metadata has been resolved.

##### Public API changes

None

This example demonstrates how to remove metadata.

**C#**

```csharp
try
{
    // open PPT/PPTX
    PptFormat pptFormat = new PptFormat(file);
    // clean metatadata
    pptFormat.CleanMetadata();
    // commit changes
    pptFormat.Save();
    // and close stream
    pptFormat.Dispose();
}

```

#### GroupDocs.Metadata cannot remove personal data of a TIF file

The bug related to removing personal data from TIF file has been resolved.

##### Public API changes

None

This example demonstrates how to remove personal metadata from TIF file.

**C#**

```csharp
// open TIFF
TiffFormat tiffFormat = new TiffFormat(file);
// clean metadata
tiffFormat.CleanMetadata();
// save changes to another file
tiffFormat.Save(outPath);
// and close initial file
tiffFormat.Dispose();
```

#### TIF - Bit Depth will be affected when removing metadata

The bug related to Bit Depth while removing metadata has been resolved.

##### Public API changes

None

This example demonstrates how to remove metadata with affecting Bit Depth.

**C#**

```csharp
TiffFormat format = new TiffFormat(sourcePath);
if (format == null)
{
    return;
}
ExifInfo exifInfo = format.ExifValues;
format.UpdateExifInfo(exifInfo);
format.Save(destinationPath);
```

#### TIF file gets damaged with getting info of XmpSchemes

The bug that damages file while getting XmpSchemes has been resolved.

##### Public API changes

None

This example demonstrates how to get XmpSchmes without damaging file.

**C#**

```csharp
TiffFormat format = new TiffFormat(file);
if (format == null)
{
    return;
}
XmpSchemes schemes = format.XmpValues.Schemes;
if (schemes == null)
{
    return;
}
if (schemes.DublinCore.Source != null)
{
    string str = schemes.DublinCore.Source;
}
format.Save(destinationPath);
```
