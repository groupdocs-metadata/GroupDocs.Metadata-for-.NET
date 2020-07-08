---
id: handling-the-apev2-tag
url: metadata/net/handling-the-apev2-tag
title: Handling the APEv2 tag
weight: 4
description: ""
keywords: 
productName: GroupDocs.Metadata for .NET
hideChildren: False
---
## What is APEv2?

The APE tag is a standard used to add metadata, such as the title, artist, or track number, to digital audio files. The APEv1 tag was designed for the Monkey's Audio format. In MP3 files, the APE tag was originally stored at the very end of the file, with no inline declaration in the body of the file. But later the standard was extended to add a header, allowing APE tags to be at the beginning of files and allowing metadata values to be Unicode rather than simply ASCII. The improved standard is called APEv2. 

{{< alert style="info" >}}Please find more information at https://en.wikipedia.org/wiki/APE_tag{{< /alert >}}

## Reading an APEv2 tag

The GroupDocs.Metadata API allows reading the APEv2 tag in an MP3 audio.

The following steps show how to read the APEv2 tag in an MP3 file.

1.  [Load]({{< ref "metadata/net/developer-guide/advanced-usage/loading-files/_index.md" >}}) an MP3 file
2.  Extract the root metadata package
3.  Get the APEv2 tag by using the [MP3RootPackage.ApeV2](https://apireference.groupdocs.com/net/metadata/groupdocs.metadata.formats.audio/mp3rootpackage/properties/apev2)property
4.  If the APEv2 tag is not null then check for all of its properties

**AdvancedUsage.ManagingMetadataForSpecificFormats.<WBR>Audio.MP3.MP3ReadApeTag**

```csharp
using (Metadata metadata = new Metadata(Constants.MP3WithApe))
{
	var root = metadata.GetRootPackage<MP3RootPackage>();

	if (root.ApeV2 != null)
	{
		Console.WriteLine(root.ApeV2.Album);
		Console.WriteLine(root.ApeV2.Title);
		Console.WriteLine(root.ApeV2.Artist);
		Console.WriteLine(root.ApeV2.Composer);
		Console.WriteLine(root.ApeV2.Copyright);
		Console.WriteLine(root.ApeV2.Genre);
		Console.WriteLine(root.ApeV2.Language);

		// ...
	}
}
```

## Removing an APEv2 tag

The GroupDocs.Metadata API supports removing the APEv2 tag from an MP3 audio.

The following are the steps to remove the APEv2 tag from an MP3 file.

1.  [Load]({{< ref "metadata/net/developer-guide/advanced-usage/loading-files/_index.md" >}}) an MP3 file
2.  Get the root metadata package
3.  Remove the tag by calling the [RemoveApeV2](https://apireference.groupdocs.com/net/metadata/groupdocs.metadata.formats.audio/mp3rootpackage/methods/removeapev2) method
4.  [Save]({{< ref "metadata/net/developer-guide/advanced-usage/saving-files/_index.md" >}}) the changes

**AdvancedUsage.ManagingMetadataForSpecificFormats.<WBR>Audio.MP3.MP3RemoveApeTag**

```csharp
using (Metadata metadata = new Metadata(Constants.MP3WithApe))
{
	var root = metadata.GetRootPackage<MP3RootPackage>();

	root.RemoveApeV2();

	metadata.Save(Constants.OutputMp3);
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
