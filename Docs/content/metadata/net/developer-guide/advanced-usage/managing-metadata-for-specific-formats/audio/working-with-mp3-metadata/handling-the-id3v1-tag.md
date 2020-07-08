---
id: handling-the-id3v1-tag
url: metadata/net/handling-the-id3v1-tag
title: Handling the ID3v1 tag
weight: 1
description: ""
keywords: 
productName: GroupDocs.Metadata for .NET
hideChildren: False
---
## What is ID3v1?

ID3v1 is a metadata tag that is usually used with MP3 audio files. The whole tag occupies 128 bytes and allows adding metadata properties such as title, artist, album, track number, etc.The ID3v1 standard was introduced in 1996 but it's still widely supported by various audio players and decoders. To get more information about ID3v1 tags please visit [http://id3.org/ID3v1](http://id3.org/ID3v1).

## Reading an ID3v1 tag

The following steps show how to read the ID3v1 tag in an MP3 file.

1.  [Load]({{< ref "metadata/net/developer-guide/advanced-usage/loading-files/_index.md" >}}) an MP3 file
2.  Extract the root metadata package
3.  Get the ID3v1 tag by using the [Mp3RootPackage.ID3V1](https://apireference.groupdocs.com/net/metadata/groupdocs.metadata.formats.audio/mp3rootpackage/properties/id3v1) property
4.  If the ID3v1 tag is not null then check for all of its properties

**AdvancedUsage.ManagingMetadataForSpecificFormats.<WBR>Audio.MP3.MP3ReadID3V1Tag**

```csharp
using (Metadata metadata = new Metadata(Constants.MP3WithID3V1))
{
	var root = metadata.GetRootPackage<MP3RootPackage>();
	if (root.ID3V1 != null)
	{
		Console.WriteLine(root.ID3V1.Album);
		Console.WriteLine(root.ID3V1.Artist);
		Console.WriteLine(root.ID3V1.Title);
		Console.WriteLine(root.ID3V1.Version);
		Console.WriteLine(root.ID3V1.Comment);

		// ...
	}
}
```

## Updating an ID3v1 tag

The following are the steps to update the ID3v1 tag in an MP3 file.

1.  [Load]({{< ref "metadata/net/developer-guide/advanced-usage/loading-files/_index.md" >}}) an MP3 file
2.  Extract the root metadata package
3.  Create the ID3v1 tag if it's missing
4.  Update ID3v1 fields using the [Mp3RootPackage.ID3V1](https://apireference.groupdocs.com/net/metadata/groupdocs.metadata.formats.audio/mp3rootpackage/properties/id3v1) property
5.  [Save]({{< ref "metadata/net/developer-guide/advanced-usage/saving-files/_index.md" >}}) the changes

The following code snippet shows how to update the ID3v1 tag in an MP3 file.

**AdvancedUsage.ManagingMetadataForSpecificFormats.<WBR>Audio.MP3.MP3UpdateID3V1Tag**

```csharp
using (Metadata metadata = new Metadata(Constants.MP3WithID3V1))
{
	var root = metadata.GetRootPackage<MP3RootPackage>();
	if (root.ID3V1 == null)
	{
		root.ID3V1 = new ID3V1Tag();
	}
	root.ID3V1.Album = "test album";
	root.ID3V1.Artist = "test artist";
	root.ID3V1.Title = "test title";
	root.ID3V1.Comment = "test comment";
	root.ID3V1.Year = "2019";

	// ...

	metadata.Save(Constants.OutputMp3);
}
```

## Removing an ID3v1 tag

To remove the ID3v1 tag from an MP3 audio just assign null to the [Mp3RootPackage.ID3V1](https://apireference.groupdocs.com/net/metadata/groupdocs.metadata.formats.audio/mp3rootpackage/properties/id3v1) property. The code sample below shows how to remove the ID3v1 tag from an MP3 file.

**AdvancedUsage.ManagingMetadataForSpecificFormats.<WBR>Audio.MP3.MP3RemoveID3V1Tag**

```csharp
using (Metadata metadata = new Metadata(Constants.MP3WithID3V1))
{
	var root = metadata.GetRootPackage<MP3RootPackage>();
	root.ID3V1 = null;
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
