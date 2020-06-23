---
id: working-with-torrent-files
url: metadata/net/working-with-torrent-files
title: Working with TORRENT files
weight: 7
description: ""
keywords: 
productName: GroupDocs.Metadata for .NET
hideChildren: False
---
In the BitTorrent file distribution system, a torrent file or METAINFO is a computer file that contains metadata about files and folders to be distributed, and usually also a list of the network locations of trackers, which are computers that help participants in the system find each other and form efficient distribution groups called swarms. A torrent file does not contain the content to be distributed; it only contains information about those files, such as their names, sizes, folder structure, and cryptographic hash values for verifying file integrity. 

{{< alert style="info" >}}For more information on torrent files please refer to this article: https://en.wikipedia.org/wiki/Torrent_file{{< /alert >}}

## Reading TORRENT file metadata

To get TORRENT file metadata, the following steps are needed to be followed:

1.  [Load]({{< ref "metadata/net/developer-guide/advanced-usage/loading-files/_index.md" >}}) a TORRENT file
2.  Get the root metadata package
3.  Extract  the native metadata package using [TorrentRootPackage.TorrentPackage](https://apireference.groupdocs.com/net/metadata/groupdocs.metadata.formats.peer2peer/torrentrootpackage/properties/torrentpackage)
4.  Read the TORRENT file properties

**AdvancedUsage.ManagingMetadataForSpecificFormats.Peer2Peer.TorrentReadNativeMetadataProperties**

```csharp
using (Metadata metadata = new Metadata(Constants.InputTorrent))
{
	var root = metadata.GetRootPackage<TorrentRootPackage>();

	Console.WriteLine(root.TorrentPackage.Announce);
	Console.WriteLine(root.TorrentPackage.Comment);
	Console.WriteLine(root.TorrentPackage.CreatedBy);
	Console.WriteLine(root.TorrentPackage.CreationDate);

	foreach (var file in root.TorrentPackage.SharedFiles)
	{
		Console.WriteLine(file.Name);
		Console.WriteLine(file.Length);
	}

	// ...
}
```

## Updating TORRENT file metadata

The GroupDocs.Metadata API also supports updating some metadata properties of a TORRENT file. Please see the code snippet below to learn how to do that.

**AdvancedUsage.ManagingMetadataForSpecificFormats.Peer2Peer.TorrentReadNativeMetadataProperties**

```csharp
using (Metadata metadata = new Metadata(Constants.InputTorrent))
{
	var root = metadata.GetRootPackage<TorrentRootPackage>();
	Console.WriteLine(root.TorrentPackage.Announce);
	Console.WriteLine(root.TorrentPackage.Comment);
	Console.WriteLine(root.TorrentPackage.CreatedBy);
	Console.WriteLine(root.TorrentPackage.CreationDate);

	foreach (var file in root.TorrentPackage.SharedFiles)
	{
		Console.WriteLine(file.Name);
		Console.WriteLine(file.Length);
	}

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