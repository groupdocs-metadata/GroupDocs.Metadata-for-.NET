---
id: working-with-metadata-in-jpeg2000-images
url: metadata/net/working-with-metadata-in-jpeg2000-images
title: Working with metadata in JPEG2000 images
weight: 5
description: ""
keywords: 
productName: GroupDocs.Metadata for .NET
hideChildren: False
---
## Reading JPEG2000 comments

The GroupDocs.Metadata API supports extracting format-specific information from JPEG2000 images.

The following are the steps to read the JPEG2000 comments (pieces of metadata represented as strings with the length up to 64 kbytes).

1.  [Load]({{< ref "metadata/net/developer-guide/advanced-usage/loading-files/_index.md" >}}) a JPEG2000 image
2.  Get the root metadata package
3.  Extract  the native metadata package using [Jpeg2000RootPackage.Jpeg2000Package](https://apireference.groupdocs.com/net/metadata/groupdocs.metadata.formats.image/jpeg2000rootpackage/properties/jpeg2000package)
4.  Read the JPEG2000 comments

**AdvancedUsage.ManagingMetadataForSpecificFormats.Image.Jpeg2000.Jpeg2000ReadComments**

```csharp
using (Metadata metadata = new Metadata(Constants.InputJpeg2000))
{
	var root = metadata.GetRootPackage<Jpeg2000RootPackage>();
	if (root.Jpeg2000Package.Comments != null)
	{
		foreach (var comment in root.Jpeg2000Package.Comments)
		{
			Console.WriteLine(comment);
		}
	}
}
```

## Working with XMP metadata

GroupDocs.Metadata for .NET also allows managing XMP metadata in JPEG2000 images. For more details please refer to the following guide: [Working with XMP metadata]({{< ref "metadata/net/developer-guide/advanced-usage/working-with-metadata-standards/working-with-xmp-metadata.md" >}}).

## More resources
### GitHub examples
You may easily run the code above and see the feature in action in our GitHub examples:
*   [GroupDocs.Metadata for .NET examples](https://github.com/groupdocs-metadata/GroupDocs.Metadata-for-.NET)    
*   [GroupDocs.Metadata for Java examples](https://github.com/groupdocs-metadata/GroupDocs.Metadata-for-Java)    

### Free online document metadata management App
Along with full featured .NET library we provide simple, but powerful free Apps.
You are welcome to view and edit metadata of PDF, DOC, DOCX, PPT, PPTX, XLS, XLSX, emails, images and more with our free online [Free Online Document Metadata Viewing and Editing App](https://products.groupdocs.app/metadata).