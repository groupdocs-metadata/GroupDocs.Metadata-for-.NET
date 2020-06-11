---
id: working-with-metadata-in-matroska-(mkv)-files
url: metadata/net/working-with-metadata-in-matroska-(mkv)-files
title: Working with metadata in Matroska (MKV) files
weight: 4
description: ""
keywords: 
productName: GroupDocs.Metadata for .NET
hideChildren: False
---
## Reading matroska format-specific properties

The GroupDocs.Metadata API supports extracting format-specific information from MKV files.

The following are the steps to read native MKV metadata.

1.  [Load]({{< ref "metadata/net/developer-guide/advanced-usage/loading-files/_index.md" >}}) an MKV video
2.  Get the root metadata package
3.  Extract  the native metadata package using [MatroskaRootPackage.MatroskaPackage](https://apireference.groupdocs.com/net/metadata/groupdocs.metadata.formats.video/matroskarootpackage/properties/matroskapackage)
4.  Read the Matroska metadata properties on different levels of the format structure

**AdvancedUsage.ManagingMetadataForSpecificFormats.Video.Matroska.MatroskaReadNativeMetadataProperties**

```csharp
using (Metadata metadata = new Metadata(Constants.InputMkv))
{
	var root = metadata.GetRootPackage<MatroskaRootPackage>();

	// Read the EBML header
	Console.WriteLine("DocType: {0}", root.MatroskaPackage.EbmlHeader.DocType);
	Console.WriteLine("DocTypeReadVersion: {0}", root.MatroskaPackage.EbmlHeader.DocTypeReadVersion);
	Console.WriteLine("DocTypeVersion: {0}", root.MatroskaPackage.EbmlHeader.DocTypeVersion);
	Console.WriteLine("ReadVersion: {0}", root.MatroskaPackage.EbmlHeader.ReadVersion);
	Console.WriteLine("Version: {0}", root.MatroskaPackage.EbmlHeader.Version);

	// Read Matroska segment information
	foreach (var segment in root.MatroskaPackage.Segments)
	{
		Console.WriteLine("DateUtc: {0}", segment.DateUtc);
		Console.WriteLine("Duration: {0}", segment.Duration);
		Console.WriteLine("MuxingApp: {0}", segment.MuxingApp);
		Console.WriteLine("SegmentFilename: {0}", segment.SegmentFilename);
		Console.WriteLine("SegmentUid: {0}", segment.SegmentUid);
		Console.WriteLine("TimecodeScale: {0}", segment.TimecodeScale);
		Console.WriteLine("Title: {0}", segment.Title);
		Console.WriteLine("WritingApp: {0}", segment.WritingApp);
	}

	// Read Matroska tag metadata
	foreach (var tag in root.MatroskaPackage.Tags)
	{
		Console.WriteLine("TargetType: {0}", tag.TargetType);
		Console.WriteLine("TargetTypeValue: {0}", tag.TargetTypeValue);
		Console.WriteLine("TagTrackUid: {0}", tag.TagTrackUid);
		foreach (var simpleTag in tag.SimpleTags)
		{
			Console.WriteLine("Name: {0}", simpleTag.Name);
			Console.WriteLine("Value: {0}", simpleTag.Value);
		}
	}

	// Read Matroska track metadata
	foreach (var track in root.MatroskaPackage.Tracks)
	{
		Console.WriteLine("CodecId: {0}", track.CodecID);
		Console.WriteLine("CodecName: {0}", track.CodecName);
		Console.WriteLine("DefaultDuration: {0}", track.DefaultDuration);
		Console.WriteLine("FlagEnabled: {0}", track.FlagEnabled);
		Console.WriteLine("Language: {0}", track.Language);
		Console.WriteLine("LanguageIetf: {0}", track.LanguageIetf);
		Console.WriteLine("Name: {0}", track.Name);
		Console.WriteLine("TrackNumber: {0}", track.TrackNumber);
		Console.WriteLine("TrackType: {0}", track.TrackType);
		Console.WriteLine("TrackUid: {0}", track.TrackUid);

		var audioTrack = track as MatroskaAudioTrack;
		if (audioTrack != null)
		{
			Console.WriteLine("SamplingFrequency: {0}", audioTrack.SamplingFrequency);
			Console.WriteLine("OutputSamplingFrequency: {0}", audioTrack.OutputSamplingFrequency);
			Console.WriteLine("Channels: {0}", audioTrack.Channels);
			Console.WriteLine("BitDepth: {0}", audioTrack.BitDepth);
		}

		var videoTrack = track as MatroskaVideoTrack;
		if (videoTrack != null)
		{
			Console.WriteLine("FlagInterlaced: {0}", videoTrack.FlagInterlaced);
			Console.WriteLine("FieldOrder: {0}", videoTrack.FieldOrder);
			Console.WriteLine("StereoMode: {0}", videoTrack.StereoMode);
			Console.WriteLine("AlphaMode: {0}", videoTrack.AlphaMode);
			Console.WriteLine("PixelWidth: {0}", videoTrack.PixelWidth);
			Console.WriteLine("PixelHeight: {0}", videoTrack.PixelHeight);
			Console.WriteLine("PixelCropBottom: {0}", videoTrack.PixelCropBottom);
			Console.WriteLine("PixelCropTop: {0}", videoTrack.PixelCropTop);
			Console.WriteLine("PixelCropLeft: {0}", videoTrack.PixelCropLeft);
			Console.WriteLine("PixelCropRight: {0}", videoTrack.PixelCropRight);
			Console.WriteLine("DisplayWidth: {0}", videoTrack.DisplayWidth);
			Console.WriteLine("DisplayHeight: {0}", videoTrack.DisplayHeight);
			Console.WriteLine("DisplayUnit: {0}", videoTrack.DisplayUnit);
		}
	}
}
```

## Extracting subtitles from a Matroska video

The GroupDocs.Metadata API also provides a convenient way of extracting subtitles attached to a Matroska video. The code sample below demonstrates how to extract multilingual subtitles from an MKV file.

1.  [Load]({{< ref "metadata/net/developer-guide/advanced-usage/loading-files/_index.md" >}}) an MKV video
2.  Get the root metadata package
3.  Use the [MatroskaPackage.SubtitleTracks](https://apireference.groupdocs.com/net/metadata/groupdocs.metadata.formats.video/matroskapackage/properties/subtitletracks) property to extract sets of subtitles in different languages

**AdvancedUsage.ManagingMetadataForSpecificFormats.Video.Matroska.MatroskaReadSubtitles**

```csharp
using (Metadata metadata = new Metadata(Constants.MkvWithSubtitles))
{
	var root = metadata.GetRootPackage<MatroskaRootPackage>();

	foreach (var subtitleTrack in root.MatroskaPackage.SubtitleTracks)
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

## More resources

### GitHub examples

You may easily run the code above and see the feature in action in our GitHub examples:

*   [GroupDocs.Metadata for .NET examples](https://github.com/groupdocs-metadata/GroupDocs.Metadata-for-.NET)
    
*   [GroupDocs.Metadata for Java examples](https://github.com/groupdocs-metadata/GroupDocs.Metadata-for-Java)
    

### Free online document metadata management App

Along with full featured .NET library we provide simple, but powerful free Apps.

You are welcome to view and edit metadata of PDF, DOC, DOCX, PPT, PPTX, XLS, XLSX, emails, images and more with our free online [Free Online Document Metadata Viewing and Editing App](https://products.groupdocs.app/metadata).
