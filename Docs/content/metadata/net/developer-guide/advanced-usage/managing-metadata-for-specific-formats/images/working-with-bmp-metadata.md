---
id: working-with-bmp-metadata
url: metadata/net/working-with-bmp-metadata
title: Working with BMP metadata
weight: 2
description: ""
keywords: 
productName: GroupDocs.Metadata for .NET
hideChildren: False
---
## Reading BMP header properties

The GroupDocs.Metadata API supports extracting format-specific information from BMP file headers.

The following are the steps to read the header of a BMP file.

1.  [Load]({{< ref "metadata/net/developer-guide/advanced-usage/loading-files/_index.md" >}}) a BMP image
2.  Get the root metadata package
3.  Extract  the native metadata package using [BmpRootPackage.BmpHeader](https://apireference.groupdocs.com/net/metadata/groupdocs.metadata.formats.image/bmprootpackage/properties/bmpheader)
4.  Read the BMP header properties

**AdvancedUsage.ManagingMetadataForSpecificFormats.Image.Bmp.BmpReadHeaderProperties**

```csharp
using (Metadata metadata = new Metadata(Constants.InputBmp))
{
	var root = metadata.GetRootPackage<BmpRootPackage>();

	Console.WriteLine(root.BmpHeader.BitsPerPixel);
	Console.WriteLine(root.BmpHeader.ColorsImportant);
	Console.WriteLine(root.BmpHeader.HeaderSize);
	Console.WriteLine(root.BmpHeader.ImageSize);
	Console.WriteLine(root.BmpHeader.Planes);
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
