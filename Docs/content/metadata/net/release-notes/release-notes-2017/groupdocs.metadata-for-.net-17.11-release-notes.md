---
id: groupdocs-metadata-for-net-17-11-release-notes
url: metadata/net/groupdocs-metadata-for-net-17-11-release-notes
title: GroupDocs.Metadata for .NET 17.11 Release Notes
weight: 2
description: ""
keywords: 
productName: GroupDocs.Metadata for .NET
hideChildren: False
---
{{< alert style="info" >}}This page contains release notes for GroupDocs.Metadata for .NET 17.11{{< /alert >}}

## Major Features

There are 4 new features in this regular monthly release. The most notable are:

*   Ability to remove Lyrics3 v2.0 tag in MP3 format
    
*   Ability to clean metadata in MP3 format
    
*   Ability to remove APEv2 audio tag in MP3 format
    
*   Ability to clean metadata in AVI format
    

## All Changes

| Key | Summary | Category |
| --- | --- | --- |
| METADATANET-1338 | Ability to remove Lyrics3 v2.0 tag in MP3 format | New Feature |
| METADATANET-2008 | Ability to clean metadata in MP3 format | New Feature |
| METADATANET-2011 | Ability to remove APEv2 audio tag in MP3 format | New Feature |
| METADATANET-2013 | Ability to clean metadata in AVI format | New Feature |

## Public API and Backward Incompatible Changes

{{< alert style="info" >}}This section lists public API changes that were introduced in GroupDocs.Metadata for .NET 17.11. It includes not only new and obsoleted public methods, but also a description of any changes in the behavior behind the scenes in GroupDocs.Metadata which may affect existing code. Any behavior introduced that could be seen as a regression and modifies existing behavior is especially important and is documented here.{{< /alert >}}

#### **Ability to remove Lyrics3 v2.0 tag in MP3 format**

This feature allows user to remove Lyrics3 v2.0 audio tag MP3 format

##### Public API changes

Added **RemoveLyrics3v2** method into class **GroupDocs.Metadata.Formats.Audio.Mp3Format**

This example demonstrates how to remove Lyrics3 2.0 tag in Mp3 format.

**C#**

```csharp
// init Mp3Format class
Mp3Format mp3Format = new Mp3Format(filePath);

// remove Lyrics3 tag
mp3Format.RemoveLyrics3v2();

// and commit changes
mp3Format.Save();
```

#### Ability to clean metadata in MP3 format

This feature allows a user to clean metadata in MP3 format. The clean operation removes following metadata:

*   Id3v1 tag
*   Id3v2 tag
*   APEv2 tag
*   Lyrics3v2 tag

##### Public API changes

None

This example demonstrates how to remove all metadata in MP3 format.

**C#**

```csharp
// path to the MP3 file
string path = @"C:\\example.mp3";

// init Mp3Format class
Mp3Format mp3Format = new Mp3Format(path);

// removes id3/lyrics/ape tags
mp3Format.CleanMetadata();

// commit changes
mp3Format.Save();
```

#### Ability to remove APEv2 audio tag in MP3 format

Ability to remove APEv2 audio tag in MP3 format

##### Public API changes

Added method **RemoveAPEv2** into **GroupDocs.Metadata.Formats.Audio.Mp3Format** class

This example demonstrates how to remove APEv2 tag in MP3 format.

**C#**

```csharp
// init Mp3Format class
Mp3Format mp3Format = new Mp3Format(filePath);

// remove APE v2.0 tag
mp3Format.RemoveAPEv2();

// and commit changes
mp3Format.Save();
```

#### Ability to clean metadata in AVI format

his feature allows a user to clean metadata in AVI format.

##### Public API changes

None

This example demonstrates how to remove all metadata in AVI format.

**C#**

```csharp
// initialize AviFormat
AviFormat aviFormat = new AviFormat(file);

// removes all metadata
aviFormat.CleanMetadata();

// commit changes
aviFormat.Save();
```
