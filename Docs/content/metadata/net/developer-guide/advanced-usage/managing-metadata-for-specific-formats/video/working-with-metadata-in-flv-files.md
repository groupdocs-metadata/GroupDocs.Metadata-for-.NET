---
id: working-with-metadata-in-flv-files
url: metadata/net/working-with-metadata-in-flv-files
title: Working with metadata in FLV files
weight: 3
description: ""
keywords: 
productName: GroupDocs.Metadata for .NET
hideChildren: False
---
## Reading FLV header properties

The GroupDocs.Metadata API supports extracting format-specific information from the FLV file header.

The following are the steps to read the header of an FLV file.

1.  [Load]({{< ref "metadata/net/developer-guide/advanced-usage/loading-files/_index.md" >}}) an FLV video
2.  Get the root metadata package
3.  Extract  the native metadata package using [FlvRootPackage.Header](https://apireference.groupdocs.com/net/metadata/groupdocs.metadata.formats.video/flvrootpackage/properties/header)
4.  Read the FLV header properties

**AdvancedUsage.ManagingMetadataForSpecificFormats.<WBR>Video.Flv.FlvReadHeaderProperties**

```csharp
using (Metadata metadata = new Metadata(Constants.InputFlv))
{
	var root = metadata.GetRootPackage<FlvRootPackage>();

	Console.WriteLine(root.Header.Version);
	Console.WriteLine(root.Header.HasAudioTags);
	Console.WriteLine(root.Header.HasVideoTags);
	Console.WriteLine(root.Header.TypeFlags);
}
```

## Working with XMP metadata

GroupDocs.Metadata for .NET allows managing XMP metadata in FLV files. For more details please refer to the following guide: [Working with XMP metadata]({{< ref "metadata/net/developer-guide/advanced-usage/working-with-metadata-standards/working-with-xmp-metadata.md" >}}).

## More resources
### GitHub examples
You may easily run the code above and see the feature in action in our GitHub examples:
*   [GroupDocs.Metadata for .NET examples](https://github.com/groupdocs-metadata/GroupDocs.Metadata-for-.NET)    
*   [GroupDocs.Metadata for Java examples](https://github.com/groupdocs-metadata/GroupDocs.Metadata-for-Java)    

### Free online document metadata management App
Along with full featured .NET library we provide simple, but powerful free Apps.
You are welcome to view and edit metadata of PDF, DOC, DOCX, PPT, PPTX, XLS, XLSX, emails, images and more with our free online [Free Online Document Metadata Viewing and Editing App](https://products.groupdocs.app/metadata).