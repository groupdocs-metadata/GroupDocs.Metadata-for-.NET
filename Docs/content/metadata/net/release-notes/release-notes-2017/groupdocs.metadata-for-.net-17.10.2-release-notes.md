---
id: groupdocs-metadata-for-net-17-10-2-release-notes
url: metadata/net/groupdocs-metadata-for-net-17-10-2-release-notes
title: GroupDocs.Metadata for .NET 17.10.2 Release Notes
weight: 3
description: ""
keywords: 
productName: GroupDocs.Metadata for .NET
hideChildren: False
---
{{< alert style="info" >}}This page contains release notes for GroupDocs.Metadata for .NET 17.10.2{{< /alert >}}

## Major Features

There is one bug fix in this hotfix monthly release. 

*   TIF - Bit Depth is affected when removing metadata

## All Changes

| Key | Summary | Category |
| --- | --- | --- |
| METADATANET-1931 | TIF - Bit Depth is affected when removing metadata | Bug |

## Public API and Backward Incompatible Changes

{{< alert style="info" >}}This section lists public API changes that were introduced in GroupDocs.Metadata for .NET 17.10.2 It includes not only new and obsoleted public methods, but also a description of any changes in the behavior behind the scenes in GroupDocs.Metadata which may affect existing code. Any behavior introduced that could be seen as a regression and modifies existing behavior is especially important and is documented here.{{< /alert >}}

#### TIF - Bit Depth will be affected when removing metadata

The bug related to Bit Depth while removing metadata has been resolved.

##### Public API changes

None

This example demonstrates how to remove metadata without affecting Bit Depth.



```csharp
// open TIFF            
TiffFormat format = new TiffFormat(sourcePath);

// remove XMP metadata
format.RemoveXmpData();

// and save file to another
format.Save(destinationPath);
```
