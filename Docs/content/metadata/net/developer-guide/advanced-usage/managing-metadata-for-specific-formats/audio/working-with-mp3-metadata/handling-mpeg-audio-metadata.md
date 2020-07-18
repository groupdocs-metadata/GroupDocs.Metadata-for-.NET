---
id: handling-mpeg-audio-metadata
url: metadata/net/handling-mpeg-audio-metadata
title: Handling MPEG audio metadata
weight: 5
description: ""
keywords: 
productName: GroupDocs.Metadata for .NET
hideChildren: False
---
## Reading MPEG audio metadata

  
MP3 (formally MPEG-1 Audio Layer III or MPEG-2 Audio Layer III) is a coding format for digital audio. Originally defined as the third audio format of the MPEG-1 standard, it was retained and further extended — defining additional bitrates and support for more audio channels — as the third audio format of the subsequent MPEG-2 standard. The GroupDocs.Metadata API allows reading some common MPEG audio properties from MP3 files.

{{< alert style="info" >}}
For more information on the MP3 and MPEG standards please check the following articles:
* [https://en.wikipedia.org/wiki/MP3](https://en.wikipedia.org/wiki/MP3)
* [https://en.wikipedia.org/wiki/Moving\_Picture\_Experts\_Group](https://en.wikipedia.org/wiki/Moving_Picture_Experts_Group)
{{< /alert >}}

  

The following steps demonstrate how to read MPEG audio metadata from an MP3 file.

1.  [Load]({{< ref "metadata/net/developer-guide/advanced-usage/loading-files/_index.md" >}}) an MP3 file
2.  Get the root metadata package
3.  Use the [MP3RootPackage.MpegAudioPackage](https://apireference.groupdocs.com/net/metadata/groupdocs.metadata.formats.audio/mp3rootpackage/properties/mpegaudiopackage)property to read the metadata values

**AdvancedUsage.ManagingMetadataForSpecificFormats.<WBR>Audio.MP3.MP3ReadMpegAudioMetadata**

```csharp
using (Metadata metadata = new Metadata(Constants.MP3WithID3V2))
{
	var root = metadata.GetRootPackage<MP3RootPackage>();

	Console.WriteLine(root.MpegAudioPackage.Bitrate);
	Console.WriteLine(root.MpegAudioPackage.ChannelMode);
	Console.WriteLine(root.MpegAudioPackage.Emphasis);
	Console.WriteLine(root.MpegAudioPackage.Frequency);
	Console.WriteLine(root.MpegAudioPackage.HeaderPosition);
	Console.WriteLine(root.MpegAudioPackage.Layer);

	// ...
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
