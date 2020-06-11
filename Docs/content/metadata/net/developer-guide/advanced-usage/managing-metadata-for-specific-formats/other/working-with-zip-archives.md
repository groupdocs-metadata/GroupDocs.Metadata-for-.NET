---
id: working-with-zip-archives
url: metadata/net/working-with-zip-archives
title: Working with ZIP archives
weight: 1
description: ""
keywords: 
productName: GroupDocs.Metadata for .NET
hideChildren: False
---
## Get ZIP format metadata

The API allows detecting ZIP archives and reading format metadata. The following steps are needed to be followed:

*   [Load]({{< ref "metadata/net/developer-guide/advanced-usage/loading-files/_index.md" >}}) a ZIP archive
*   Get the root metadata package
*   Extract  the native metadata package using [ZipRootPackage.ZipPackage](https://apireference.groupdocs.com/net/metadata/groupdocs.metadata.formats.archive/ziprootpackage/properties/zippackage)
*   Read the ZIP archive properties
*   Loop through [ZipPackage.Files](https://apireference.groupdocs.com/net/metadata/groupdocs.metadata.formats.archive/zippackage/properties/files) to extract information about archived files 

The following code snippet shows how to get metadata from a ZIP archive.

**AdvancedUsage.ManagingMetadataForSpecificFormats.Archive.ZipReadNativeMetadataProperties**

```csharp
Encoding encoding = Encoding.GetEncoding(866);
using (Metadata metadata = new Metadata(Constants.InputZip))
{
	var root = metadata.GetRootPackage<ZipRootPackage>();

	Console.WriteLine(root.ZipPackage.Comment);
	Console.WriteLine(root.ZipPackage.TotalEntries);

	foreach (var file in root.ZipPackage.Files)
	{
		Console.WriteLine(file.Name);
		Console.WriteLine(file.CompressedSize);
		Console.WriteLine(file.CompressionMethod);
		Console.WriteLine(file.Flags);
		Console.WriteLine(file.ModificationDateTime);
		Console.WriteLine(file.UncompressedSize);

		// Use a specific encoding for the file names
		Console.WriteLine(encoding.GetString(file.RawName));
	}
}
```

## Updating the user comment

GroupDocs.Metadata for .NET allows you to update the user comment in a ZIP archive. The following steps are needed to be followed:

*   [Load]({{< ref "metadata/net/developer-guide/advanced-usage/loading-files/_index.md" >}}) a ZIP archive
*   Get the root metadata package
*   Update the comment using the [ZipPackage.Comment](https://apireference.groupdocs.com/net/metadata/groupdocs.metadata.formats.archive/zippackage/properties/comment) setter
*   Save the changes

The following code snippet demonstrates the usage of this feature.

**AdvancedUsage.ManagingMetadataForSpecificFormats.Archive.ZipUpdateArchiveComment**

```csharp
using (Metadata metadata = new Metadata(Constants.InputZip))
{
	var root = metadata.GetRootPackage<ZipRootPackage>();
	root.ZipPackage.Comment = "updated comment";

	metadata.Save(Constants.OutputZip);
}
```

## Removing the user comment

GroupDocs.Metadata for .NET allows you to remove the user comment associated with a ZIP archive. The following code snippet demonstrates the usage of this feature.

**AdvancedUsage.ManagingMetadataForSpecificFormats.Archive.ZipRemoveArchiveComment**

```csharp
using (Metadata metadata = new Metadata(Constants.InputZip))
{
	var root = metadata.GetRootPackage<ZipRootPackage>();
	root.ZipPackage.Comment = null;

	metadata.Save(Constants.OutputZip);
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
