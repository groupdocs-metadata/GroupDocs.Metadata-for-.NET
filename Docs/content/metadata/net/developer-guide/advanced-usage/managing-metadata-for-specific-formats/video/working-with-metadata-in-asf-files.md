---
id: working-with-metadata-in-asf-files
url: metadata/net/working-with-metadata-in-asf-files
title: Working with Metadata in ASF Files
weight: 1
description: ""
keywords: 
productName: GroupDocs.Metadata for .NET
hideChildren: False
---
#  Working with metadata in ASF files

## Reading ASF format-specific properties

The GroupDocs.Metadata API supports extracting format-specific information from ASF files.

The following are the steps to read native ASF metadata.

1.  [Load]({{< ref "metadata/net/developer-guide/advanced-usage/loading-files/_index.md" >}}) an ASF video
2.  Get the root metadata package
3.  Extract  the native metadata package using [AsfRootPackage.AsfPackage](https://apireference.groupdocs.com/net/metadata/groupdocs.metadata.formats.video/asfrootpackage/properties/asfpackage)
4.  Read the ASF metadata properties

**AdvancedUsage.ManagingMetadataForSpecificFormats.<WBR>Video.Asf.AsfReadNativeMetadataProperties**

```csharp
using (Metadata metadata = new Metadata(Constants.InputAsf))
{
	var root = metadata.GetRootPackage<AsfRootPackage>();
	var package = root.AsfPackage;

	// Display basic properties
	Console.WriteLine("Creation date: {0}", package.CreationDate);
	Console.WriteLine("File id: {0}", package.FileID);
	Console.WriteLine("Flags: {0}", package.Flags);

	// Display Asf Codec Information
	foreach (var codecInfo in package.CodecInformation)
	{
		Console.WriteLine("Codec type: {0}", codecInfo.CodecType);
		Console.WriteLine("Description: {0}", codecInfo.Description);
		Console.WriteLine("Codec information: {0}", codecInfo.Information);
		Console.WriteLine(codecInfo.Name);
	}

	// Display metadata descriptors
	foreach (AsfBaseDescriptor descriptor in package.MetadataDescriptors)
	{
		Console.WriteLine("Name: {0}", descriptor.Name);
		Console.WriteLine("Value: {0}", descriptor.Value);
		Console.WriteLine("Content type: {0}", descriptor.AsfContentType);

		AsfMetadataDescriptor metadataDescriptor = descriptor as AsfMetadataDescriptor;
		if (metadataDescriptor != null)
		{
			Console.WriteLine("Language: {0}", metadataDescriptor.Language);
			Console.WriteLine("Stream number: {0}", metadataDescriptor.StreamNumber);
			Console.WriteLine("Original name: {0}", metadataDescriptor.OriginalName);
		}
	}

	//Display the base stream properties
	foreach (AsfBaseStreamProperty property in package.StreamProperties)
	{
		Console.WriteLine("Alternate bitrate: {0}", property.AlternateBitrate);
		Console.WriteLine("Average bitrate: {0}", property.AverageBitrate);
		Console.WriteLine("Average time per frame: {0}", property.AverageTimePerFrame);
		Console.WriteLine("Bitrate: {0}", property.Bitrate);
		Console.WriteLine("Stream end time: {0}", property.EndTime);
		Console.WriteLine("Stream flags: {0}", property.Flags);
		Console.WriteLine("Stream language: {0}", property.Language);
		Console.WriteLine("Stream start time: {0}", property.StartTime);
		Console.WriteLine("Stream number: {0}", property.StreamNumber);
		Console.WriteLine("Stream type: {0}", property.StreamType);

		//Display the audio stream properties
		AsfAudioStreamProperty audioStreamProperty = property as AsfAudioStreamProperty;
		if (audioStreamProperty != null)
		{
			Console.WriteLine("Audio bits per sample: {0}", audioStreamProperty.BitsPerSample);
			Console.WriteLine("Audio channels: {0}", audioStreamProperty.Channels);
			Console.WriteLine("Audio format tag: {0}", audioStreamProperty.FormatTag);
			Console.WriteLine("Audio samples per second: {0}", audioStreamProperty.SamplesPerSecond);
		}

		//Display the video stream properties
		AsfVideoStreamProperty videoStreamProperty = property as AsfVideoStreamProperty;
		if (videoStreamProperty != null)
		{
			Console.WriteLine("Video bits per pixels: {0}", videoStreamProperty.BitsPerPixels);
			Console.WriteLine("Compression: {0}", videoStreamProperty.Compression);
			Console.WriteLine("Image height: {0}", videoStreamProperty.ImageHeight);
			Console.WriteLine("Image width: {0}", videoStreamProperty.ImageWidth);
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