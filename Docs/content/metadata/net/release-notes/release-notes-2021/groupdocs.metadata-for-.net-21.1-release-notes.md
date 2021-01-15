---
id: groupdocs-metadata-for-net-21-1-release-notes
url: metadata/net/groupdocs-metadata-for-net-21-1-release-notes
title: GroupDocs.Metadata for .NET 21.1 Release Notes
weight: 11
description: ""
keywords: 
productName: GroupDocs.Metadata for .NET
hideChildren: False
---
{{< alert style="info" >}}This page contains release notes for GroupDocs.Metadata for .NET 21.1{{< /alert >}}

## Major Features

  
There are the following features, enhancements and fixes in this release:

*   Implement the ability to extract content statistics from OneNote documents
*   Implement the ability to extract INFO chunk metadata from all formats derived from the RIFF container (AVI, WAV)
*   Attempted to divide by zero.
*   Input string was not in a correct format.

## Full List of Issues Covering all Changes in this Release

| Key | Summary | Category |
| --- | --- | --- |
| METADATANET-2841 | Implement the ability to extract content statistics from OneNote documents                                          | New Feature |
| METADATANET-2853 | Implement the ability to extract INFO chunk metadata from all formats derived from the RIFF container (AVI, WAV)	 | New Feature |
| METADATANET-3660 | Attempted to divide by zero.                                                                                        | Bug         |
| METADATANET-3661 | Input string was not in a correct format.                              	                                     	 | Bug         |




## Public API and Backward Incompatible Changes

### Implement the ability to extract content statistics from OneNote documents

This new feature allows the user to extract content statistics from OneNote documents

##### Public API changes 

The [DocumentStatistics](https://apireference.groupdocs.com/metadata/net/groupdocs.metadata.formats.document/noterootpackage/properties/documentstatistics) property has been added to the [NoteRootPackage](https://apireference.groupdocs.com/metadata/net/groupdocs.metadata.formats.document/noterootpackage) class

##### Use cases 

Extract document statistics from a OneNote document

```csharp
using (Metadata metadata = new Metadata(Constants.InputOne))
{
    var root = metadata.GetRootPackage<NoteRootPackage>();
    Console.WriteLine(root.DocumentStatistics.CharacterCount);
    Console.WriteLine(root.DocumentStatistics.PageCount);
    Console.WriteLine(root.DocumentStatistics.WordCount);
}
```

### Implement the ability to extract INFO chunk metadata from all formats derived from the RIFF container (AVI, WAV)

This new feature allows the user to extract INFO chunk metadata properties from all supported formats derived from the RIFF container (AVI, WAV)

##### Public API changes 

The [RiffInfoPackage](https://apireference.groupdocs.com/metadata/net/groupdocs.metadata.formats.riff/riffinfopackage) class has been added to the [GroupDocs.Metadata.Formats.Riff](https://apireference.groupdocs.com/metadata/net/groupdocs.metadata.formats.riff) namespace

The [RiffInfoPackage](https://apireference.groupdocs.com/metadata/net/groupdocs.metadata.formats.audio/wavrootpackage/properties/riffinfopackage) property has been added to the [WavRootPackage](https://apireference.groupdocs.com/metadata/net/groupdocs.metadata.formats.audio/wavrootpackage) class

The [RiffInfoPackage](https://apireference.groupdocs.com/metadata/net/groupdocs.metadata.formats.video/avirootpackage/properties/riffinfopackage) property has been added to the [AviRootPackage](https://apireference.groupdocs.com/metadata/net/groupdocs.metadata.formats.video/avirootpackage) class

##### Use cases 

Extract RIFF INFO properties from a WAV audio

```csharp
using (Metadata metadata = new Metadata(Constants.InputWav))
{
    // The same code snippet will work for AVI files as well. 
    // You just need to convert the metadata root package to the appropriate type (use AviRootPackage instead of WavRootPackage in the line below)
    var root = metadata.GetRootPackage<WavRootPackage>();
    if (root.RiffInfoPackage != null)
    {
        Console.WriteLine(root.RiffInfoPackage.Artist);
        Console.WriteLine(root.RiffInfoPackage.Comment);
        Console.WriteLine(root.RiffInfoPackage.Copyright);
        Console.WriteLine(root.RiffInfoPackage.CreationDate);
        Console.WriteLine(root.RiffInfoPackage.Software);
        Console.WriteLine(root.RiffInfoPackage.Engineer);
        Console.WriteLine(root.RiffInfoPackage.Genre);
  
        // ...
    }
}
```