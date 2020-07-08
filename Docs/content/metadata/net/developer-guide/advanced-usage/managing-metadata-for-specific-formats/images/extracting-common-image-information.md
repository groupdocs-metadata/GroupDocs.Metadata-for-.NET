---
id: extracting-common-image-information
url: metadata/net/extracting-common-image-information
title: Extracting Common Image Information
weight: 1
description: ""
keywords: 
productName: GroupDocs.Metadata for .NET
hideChildren: False
---
For all supported image formats the GroupDocs.Metadata API allows extracting common image properties such as width and height, MIME type, byte order, etc. Please see the code snippet below for more information on the feature.

1.  [Load]({{< ref "metadata/net/developer-guide/advanced-usage/loading-files/_index.md" >}}) an image
2.  Extract the root metadata package
3.  Use the [FileType](https://apireference.groupdocs.com/net/metadata/groupdocs.metadata.formats.image/imagerootpackage/properties/filetype) property to obtain file format information

**AdvancedUsage.ManagingMetadataForSpecificFormats.<WBR>Image.ImageReadFileFormatProperties**

```csharp
using (Metadata metadata = new Metadata(Constants.InputPng))
{
	var root = metadata.GetRootPackage<ImageRootPackage>();

	Console.WriteLine(root.FileType.FileFormat);
	Console.WriteLine(root.FileType.ByteOrder);
	Console.WriteLine(root.FileType.MimeType);
	Console.WriteLine(root.FileType.Extension);
	Console.WriteLine(root.FileType.Width);
	Console.WriteLine(root.FileType.Height);
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
