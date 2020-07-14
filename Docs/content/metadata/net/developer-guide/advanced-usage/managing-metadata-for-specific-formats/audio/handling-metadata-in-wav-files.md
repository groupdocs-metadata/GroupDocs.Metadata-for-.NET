---
id: handling-metadata-in-wav-files
url: metadata/net/handling-metadata-in-wav-files
title: Handling metadata in WAV files
weight: 2
description: ""
keywords: 
productName: GroupDocs.Metadata for .NET
hideChildren: False
---
## Reading audio details

The GroupDocs.Metadata API supports extracting technical audio information from WAV files.

The following are the steps to read audio details.

1.  [Load]({{< ref "metadata/net/developer-guide/advanced-usage/loading-files/_index.md" >}}) a WAV audio
2.  Get the root metadata package
3.  Extract  the native metadata package using the [WavRootPackage.WavPackage](https://apireference.groupdocs.com/net/metadata/groupdocs.metadata.formats.audio/wavrootpackage/properties/wavpackage) property
4.  Read the WAV audio properties

**AdvancedUsage.ManagingMetadataForSpecificFormats.<WBR>Audio.Wav.WavReadNativeMetadataProperties**

```csharp
using (Metadata metadata = new Metadata(Constants.InputWav))
{
	var root = metadata.GetRootPackage<WavRootPackage>();
	if (root.WavPackage != null)
	{
		Console.WriteLine(root.WavPackage.AudioFormat);
		Console.WriteLine(root.WavPackage.BitsPerSample);
		Console.WriteLine(root.WavPackage.BlockAlign);
		Console.WriteLine(root.WavPackage.ByteRate);
		Console.WriteLine(root.WavPackage.NumberOfChannels);
		Console.WriteLine(root.WavPackage.SampleRate);
	}
}
```

## Working with XMP metadata

GroupDocs.Metadata for .NET also allows managing XMP metadata in WAV files. For more details please refer to the following guide: [Handling metadata in WAV files]({{< ref "metadata/net/developer-guide/advanced-usage/managing-metadata-for-specific-formats/audio/handling-metadata-in-wav-files.md" >}})

## More resources
### GitHub examples
You may easily run the code above and see the feature in action in our GitHub examples:
*   [GroupDocs.Metadata for .NET examples](https://github.com/groupdocs-metadata/GroupDocs.Metadata-for-.NET)    
*   [GroupDocs.Metadata for Java examples](https://github.com/groupdocs-metadata/GroupDocs.Metadata-for-Java)    

### Free online document metadata management App
Along with full featured .NET library we provide simple, but powerful free Apps.
You are welcome to view and edit metadata of PDF, DOC, DOCX, PPT, PPTX, XLS, XLSX, emails, images and more with our free online [Free Online Document Metadata Viewing and Editing App](https://products.groupdocs.app/metadata).