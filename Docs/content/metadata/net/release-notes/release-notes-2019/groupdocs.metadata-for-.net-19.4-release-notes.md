---
id: groupdocs-metadata-for-net-19-4-release-notes
url: metadata/net/groupdocs-metadata-for-net-19-4-release-notes
title: GroupDocs.Metadata for .NET 19.4 Release Notes
weight: 4
description: ""
keywords: 
productName: GroupDocs.Metadata for .NET
hideChildren: False
---
  
  

{{< alert style="info" >}}This page contains release notes for GroupDocs.Metadata for .NET 19.4{{< /alert >}}

## Major Features

There are the following features and enhancements in this release:

*   Implement the ability to read Matroska subtitles
*   Implement the ability to read original encoded names of ZIP archive entries

## Full List of Issues Covering all Changes in this Release

| Key | Summary | Category |
| --- | --- | --- |
| METADATANET-2698 | Implement the ability to read Matroska subtitles | New Feature |
| METADATANET-2761 | Implement the ability to read original encoded names of ZIP archive entries | Enhancement |

## Public API and Backward Incompatible Changes

{{< alert style="info" >}}This section lists public API changes that were introduced in GroupDocs.Metadata for .NET 19.4. It includes not only new and obsoleted public methods, but also a description of any changes in the behavior behind the scenes in GroupDocs.Metadata which may affect existing code. Any behavior introduced that could be seen as regression and modifies existing behavior is especially important and is documented here.{{< /alert >}}

### Implement the ability to read Matroska subtitles

This new feature allows a user to read subtitles built in a video file encoded with the Matroska media container

**Public API changes**

The *SubtitleTracks* property has been added to the *GroupDocs.Metadata.Formats.Video.MatroskaFormat *class

The *ScaledDuration* property has been added to the *GroupDocs.Metadata.Formats.Video.MatroskaSegmentInfoMetadata *class

The *MatroskaSubtitle* class has been added to the *GroupDocs.Metadata.Formats.Video *namespace

The *Timecode* property has been added to the *GroupDocs.Metadata.Formats.Video.MatroskaSubtitle *class

The *Duration* property has been added to the *GroupDocs.Metadata.Formats.Video.MatroskaSubtitle *class

The *Text* property has been added to the *GroupDocs.Metadata.Formats.Video.MatroskaSubtitle *class

The *MatroskaSubtitleTrackMetadata* class has been added to the *GroupDocs.Metadata.Formats.Video *namespace

The *Subtitles* property has been added to the *GroupDocs.Metadata.Formats.Video.MatroskaSubtitleTrackMetadata *class

The *Undefined* item has been added to the *GroupDocs.Metadata.Formats.Video.MatroskaTrackType *enum

The *GroupDocs.Metadata.Formats.Video.MatroskaTrackType.Unefined* enum item has been marked as obsolete

##### Use case

Read all subtitles stored in an MKV video

**C#**

```csharp
using (MatroskaFormat format = new MatroskaFormat(@"D:\input.mkv"))
{
	foreach (MatroskaSubtitleTrackMetadata subtitleTrack in format.SubtitleTracks)
	{
		Console.WriteLine(subtitleTrack.LanguageIetf ?? subtitleTrack.Language);
		foreach (MatroskaSubtitle subtitle in subtitleTrack.Subtitles)
		{
			Console.WriteLine("Timecode={0}, Duration={1}", subtitle.Timecode, subtitle.Duration);
			Console.WriteLine(subtitle.Text);
		}
	}
}
```

### Implement the ability to read original encoded names of ZIP archive entries

All filenames are stored in a ZIP archive as sequences of bytes and it’s up to the file archiver which encoding is used for interpreting and persisting the names. If you use GroupDocs.Metadata to extract information about archived files having non-ASCII characters in their names you may find that sometimes they are interpreted incorrectly. If you are aware of the exact encoding used to store the filenames, you can read them properly using a new property introduced in this enhancement.

##### Public API changes

The *RawName* property has been added to the *GroupDocs.Metadata.Formats.Archive.ZipFileInfo* class

##### Use cases

Read all entries of a ZIP archive using a specific encoding

**C#**

```csharp
// Use a specific encoding for filenames
Encoding encoding = Encoding.GetEncoding(866);
using (ZipFormat format = new ZipFormat(@"D:\input.zip"))
{
	foreach (ZipFileInfo file in format.ZipInfo.Files)
	{
		// Use the RawName property to get the sequence of bytes representing the filename
		Console.WriteLine(encoding.GetString(file.RawName));
	}
}
```
