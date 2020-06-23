---
id: groupdocs-metadata-for-net-17-10-release-notes
url: metadata/net/groupdocs-metadata-for-net-17-10-release-notes
title: GroupDocs.Metadata for .NET 17.10 Release Notes
weight: 5
description: ""
keywords: 
productName: GroupDocs.Metadata for .NET
hideChildren: False
---
{{< alert style="info" >}}This page contains release notes for GroupDocs.Metadata for .NET 17.10.{{< /alert >}}

## Major Features

There are 2 new features and 3 fixes in this regular monthly release. The most notable are:

*   Ability to read metadata of ZIP format
*   Ability to read metadata of MOV format
*   File Size increased after Metadata removal
*   GPS related data is removed after we try to remove the metadata of the JPG file
*   Unable to update XMPBasic metadata when updating PdfMetadata at the same time

## Full List of Issues Covering all Changes in this Release

| Key | Summary | Category |
| --- | --- | --- |
| METADATANET-1927 | Ability to read metadata of ZIP format | New Feature |
| METADATANET-1567 | Implement ability to detect MOV video format | New Feature |
| METADATANET-1924 | File Size increased after Metadata removal | Bug |
| METADATANET-1935 | JPG - the GPS related data is removed after we try to remove the metadata of the JPG file | Bug |
| METADATANET-1940 | Unable to update XMPBasic metadata when updating PdfMetadata at the same time | Bug |

## Public API and Backward Incompatible Changes

{{< alert style="info" >}}This section lists public API changes that were introduced in GroupDocs.Metadata for .NET 17.10. It includes not only new and obsoleted public methods, but also a description of any changes in the behavior behind the scenes in GroupDocs.Metadata which may affect existing code. Any behavior introduced that could be seen as a regression and modifies existing behavior is especially important and is documented here.{{< /alert >}}

### Ability to Detect MOV Video Format

##### Description

Implement ability to detect MOV video format

##### Public API changes

Added **MovFormat** class into namespace **GroupDocs.Metadata.Formats.Video**



```csharp
MovFormat movFormat = new MovFormat(file);
```

### Ability to Detect ZIP Format

##### Description

Implement ability to read metadata of ZIP format

##### Public API changes

Added **ZipFormat** class into namespace **GroupDocs.Metadata.Formats.Archive**

##### Usecases

This example demonstrates how to read metadata of ZIP format



```csharp
 
string copy = GetFileCopy(path);

ZipFormat movFormat = new ZipFormat(copy);

ZipMetadata info = movFormat.ZipInfo;
 
```
