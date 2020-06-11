---
id: handling-the-lyrics-tag
url: metadata/net/handling-the-lyrics-tag
title: Handling the Lyrics tag
weight: 3
description: ""
keywords: 
productName: GroupDocs.Metadata for .NET
hideChildren: False
---
## What is Lyrics tag?

Lyrics3 Tag is a chunk of data which begins with "LYRICSBEGIN", ends with "LYRICSEND" and has the lyrics between these keywords. This data block is then saved in the audio file between the audio and the ID3 tag. If no ID3 tag is present one must be attached.

{{< alert style="info" >}}For more information, please visit: http://id3.org/Lyrics3{{< /alert >}}

## Reading a Lyrics tag

The GroupDocs.Metadata API allows reading the Lyrics3 tag in an MP3 file.

1.  [Load]({{< ref "metadata/net/developer-guide/advanced-usage/loading-files/_index.md" >}}) an MP3 file
2.  Extract the root metadata package
3.  Get the Lyrics tag by using the [MP3RootPackage.Lyrics3V2](https://apireference.groupdocs.com/net/metadata/groupdocs.metadata.formats.audio/mp3rootpackage/properties/lyrics3v2)property
4.  If the Lyrics tag is not null then check for all of its properties

The following code snippet reads the Lyrics tag from an MP3 file.

**AdvancedUsage.ManagingMetadataForSpecificFormats.Audio.MP3.MP3ReadLyricsTag**

```csharp
using (Metadata metadata = new Metadata(Constants.MP3WithLyrics))
{
	var root = metadata.GetRootPackage<MP3RootPackage>();
	if (root.Lyrics3V2 != null)
	{
		Console.WriteLine(root.Lyrics3V2.Lyrics);
		Console.WriteLine(root.Lyrics3V2.Album);
		Console.WriteLine(root.Lyrics3V2.Artist);
		Console.WriteLine(root.Lyrics3V2.Track);

		// ...

		// Alternatively, you can loop through a full list of tag fields
		foreach (var field in root.Lyrics3V2.ToList())
		{
			Console.WriteLine("{0} = {1}", field.ID, field.Data);
		}
	}
}
```

## Updating a Lyrics tag

The GroupDocs.Metadata API supports updating the Lyrics tag in an MP3 audio file.

The following are the steps to update the Lyrics tag in an MP3 file.

1.  [Load]({{< ref "metadata/net/developer-guide/advanced-usage/loading-files/_index.md" >}}) an MP3 file
2.  Extract the root metadata package
3.  Create the Lyrics tag if it's missing
4.  Update Lyrics fields using the [MP3RootPackage.Lyrics3V2](https://apireference.groupdocs.com/net/metadata/groupdocs.metadata.formats.audio/mp3rootpackage/properties/lyrics3v2) property
5.  [Save]({{< ref "metadata/net/developer-guide/advanced-usage/saving-files/_index.md" >}}) the changes

The following code snippet shows how to update the Lyrics tag in an MP3 file.

**AdvancedUsage.ManagingMetadataForSpecificFormats.Audio.MP3.MP3UpdateLyricsTag**

```csharp
using (Metadata metadata = new Metadata(Constants.MP3WithLyrics))
{
	var root = metadata.GetRootPackage<MP3RootPackage>();
	if (root.Lyrics3V2 == null)
	{
		root.Lyrics3V2 = new LyricsTag();
	}
	root.Lyrics3V2.Lyrics = "[00:01]Test lyrics";
	root.Lyrics3V2.Artist = "test artist";
	root.Lyrics3V2.Album = "test album";
	root.Lyrics3V2.Track = "test track";

	// You can add a fully custom field to the tag
	root.Lyrics3V2.Set(new LyricsField("ABC", "custom value"));

	// ...

	metadata.Save(Constants.OutputMp3);
}
```

## Removing a Lyrics tag

To remove the Lyrics tag from an MP3 audio just assign null to the [MP3RootPackage.Lyrics3V2](https://apireference.groupdocs.com/net/metadata/groupdocs.metadata.formats.audio/mp3rootpackage/properties/lyrics3v2) property. The code sample below shows how to remove the Lyrics tag from an MP3 file.

**AdvancedUsage.ManagingMetadataForSpecificFormats.Audio.MP3.MP3RemoveLyricsTag**

```csharp
using (Metadata metadata = new Metadata(Constants.MP3WithLyrics))
{
	var root = metadata.GetRootPackage<MP3RootPackage>();
	root.Lyrics3V2 = null;

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
