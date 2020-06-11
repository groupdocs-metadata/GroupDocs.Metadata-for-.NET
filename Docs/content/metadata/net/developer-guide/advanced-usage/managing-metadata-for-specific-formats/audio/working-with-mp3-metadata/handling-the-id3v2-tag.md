---
id: handling-the-id3v2-tag
url: metadata/net/handling-the-id3v2-tag
title: Handling the ID3v2 tag
weight: 2
description: ""
keywords: 
productName: GroupDocs.Metadata for .NET
hideChildren: False
---
## Waht is ID3v2?

ID3v2 is a metadata standard that is primarily used with mp3 files. Although it bears the name ID3, its structure is very different from [ID3v1]({{< ref "metadata/net/developer-guide/advanced-usage/managing-metadata-for-specific-formats/audio/working-with-mp3-metadata/handling-the-id3v2-tag.md" >}}). ID3v2 tags consist of a number of frames, each of which contains a piece of metadata.

{{< alert style="info" >}}For more information on the ID3v2 standard visit http://id3.org/id3v2.3.0. Please note there are three versions of ID3v2: ID3v2.2, ID3v2.3, ID3v2.4.{{< /alert >}}

## Reading an ID3v2 tag

The GroupDocs.Metadata API allows reading the ID3v2 tag in an MP3 audio. To get more information about ID3 tags, visit: [https://en.wikipedia.org/wiki/ID3](https://en.wikipedia.org/wiki/ID3)

The following steps show how to read the ID3v2 tag in an MP3 file.

1.  [Load]({{< ref "metadata/net/developer-guide/advanced-usage/loading-files/_index.md" >}}) an MP3 file
2.  Extract the root metadata package
3.  Get the ID3v2 tag by using the [Mp3RootPackage.ID3V2](https://apireference.groupdocs.com/net/metadata/groupdocs.metadata.formats.audio/mp3rootpackage/properties/id3v2)property
4.  If the ID3v2 tag is not null then check for all of its properties

**AdvancedUsage.ManagingMetadataForSpecificFormats.Audio.MP3.MP3ReadID3V2Tag**

```csharp
using (Metadata metadata = new Metadata(Constants.MP3WithID3V2))
{
	var root = metadata.GetRootPackage<MP3RootPackage>();
	if (root.ID3V2 != null)
	{
		Console.WriteLine(root.ID3V2.Album);
		Console.WriteLine(root.ID3V2.Artist);
		Console.WriteLine(root.ID3V2.Band);
		Console.WriteLine(root.ID3V2.Title);
		Console.WriteLine(root.ID3V2.Composers);
		Console.WriteLine(root.ID3V2.Copyright);
		Console.WriteLine(root.ID3V2.Publisher);
		Console.WriteLine(root.ID3V2.OriginalAlbum);
		Console.WriteLine(root.ID3V2.MusicalKey);

		if (root.ID3V2.AttachedPictures != null)
		{
			foreach (var attachedPicture in root.ID3V2.AttachedPictures)
			{
				Console.WriteLine(attachedPicture.AttachedPictureType);
				Console.WriteLine(attachedPicture.MimeType);
				Console.WriteLine(attachedPicture.Description);

				// ...
			}
		}

		// ...
	}
}
```

## Updating an ID3v2 tag

The GroupDocs.Metadata API supports updating the ID3v2 tag in an MP3 audio file.

The following are the steps to update the ID3v2 tag in an MP3 file.

1.  [Load]({{< ref "metadata/net/developer-guide/advanced-usage/loading-files/_index.md" >}}) an MP3 file
2.  Extract the root metadata package
3.  Create the ID3v2 tag if it's missing
4.  Update ID3v2 fields using the [Mp3RootPackage.ID3V2](https://apireference.groupdocs.com/net/metadata/groupdocs.metadata.formats.audio/mp3rootpackage/properties/id3v2) property
5.  [Save]({{< ref "metadata/net/developer-guide/advanced-usage/saving-files/_index.md" >}}) the changes

The following code snippet shows how to update the ID3v2 tag in an MP3 file.

**AdvancedUsage.ManagingMetadataForSpecificFormats.Audio.MP3.MP3UpdateID3V2Tag**

```csharp
using (Metadata metadata = new Metadata(Constants.MP3WithID3V2))
{
	var root = metadata.GetRootPackage<MP3RootPackage>();
	if (root.ID3V2 == null)
	{
		root.ID3V2 = new ID3V2Tag();
	}

	root.ID3V2.Album = "test album";
	root.ID3V2.Artist = "test artist";
	root.ID3V2.Band = "test band";
	root.ID3V2.TrackNumber = "1";
	root.ID3V2.MusicalKey = "C#";
	root.ID3V2.Title = "code sample";
	root.ID3V2.Date = "2019";

	// ...
	metadata.Save(Constants.OutputMp3);
}
```

## Removing an ID3v2 tag

To remove the ID3v2 tag from an MP3 audio just assign null to the [Mp3RootPackage.ID3V2](https://apireference.groupdocs.com/net/metadata/groupdocs.metadata.formats.audio/mp3rootpackage/properties/id3v2) property. The code sample below shows how to remove the ID3v2 tag from an MP3 file.

**AdvancedUsage.ManagingMetadataForSpecificFormats.Audio.MP3.MP3RemoveID3V2Tag**

```csharp
using (Metadata metadata = new Metadata(Constants.MP3WithID3V2))
{
	var root = metadata.GetRootPackage<MP3RootPackage>();
	root.ID3V2 = null;
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
