---
id: working-with-metadata-in-jpeg-images
url: metadata/net/working-with-metadata-in-jpeg-images
title: Working with metadata in JPEG images
weight: 6
description: ""
keywords: 
productName: GroupDocs.Metadata for .NET
hideChildren: False
---
## Reading Photoshop metadata properties

The GroupDocs Metadata API allows the user to read Adobe Photoshop metadata associated with a JPEG image. For more information on the Photoshop file format and metadata blocks that can be attached to images of different formats please refer to the specification: [https://www.adobe.com/devnet-apps/photoshop/fileformatashtml/](https://www.adobe.com/devnet-apps/photoshop/fileformatashtml/).

The code sample below demonstrates how to extract image resource blocks (building blocks of the Photoshop file format) from a JPEG image.

1.  [Load]({{< ref "metadata/net/developer-guide/advanced-usage/loading-files/_index.md" >}}) a JPEG image
2.  Get the root metadata package
3.  Extract the [ImageResourcePackage](https://apireference.groupdocs.com/net/metadata/groupdocs.metadata.formats.image/imageresourcepackage) instance and obtain a list of [ImageResourceBlock](https://apireference.groupdocs.com/net/metadata/groupdocs.metadata.formats.image/imageresourceblock) objects
4.  Iterate trough the collection of resource blocks

**AdvancedUsage.ManagingMetadataForSpecificFormats.Image.Jpeg.JpegReadImageResourceBlocks**

```csharp
using (Metadata metadata = new Metadata(Constants.JpegWithIrb))
{
	var root = metadata.GetRootPackage<JpegRootPackage>();

	if (root.ImageResourcePackage != null)
	{
		foreach (var block in root.ImageResourcePackage.ToList())
		{
			Console.WriteLine(block.Signature);
			Console.WriteLine(block.ID);
			Console.WriteLine(block.Name);
			Console.WriteLine(block.Data);
		}
	}
}
```

## Removing Photoshop metadata properties

GroupDocs.Metadata for .NET also supports removing Photoshop metadata blocks from a JPEG image. Please see the code sample below that demonstrates how to remove the whole Photoshop metadata package from a JPEG image.

**AdvancedUsage.ManagingMetadataForSpecificFormats.Image.Jpeg.JpegRemoveImageResourceBlocks**

```csharp
using (Metadata metadata = new Metadata(Constants.JpegWithIrb))
{
	var root = metadata.GetRootPackage<JpegRootPackage>();

	root.RemoveImageResourcePackage();

	metadata.Save(Constants.OutputJpeg);
}
```

## Detecting barcodes in a JPEG image

This feature allows you to detect barcodes of different types in a JPEG image. The following code snippet detects all barcodes in a JPEG and return their types.

**AdvancedUsage.ManagingMetadataForSpecificFormats.Image.Jpeg.JpegDetectBarcodes**

```csharp
using (Metadata metadata = new Metadata(Constants.JpegWithBarcodes))
{
	var root = metadata.GetRootPackage<JpegRootPackage>();

	var barcodeTypes = root.DetectBarcodeTypes();
	foreach (var barcodeType in barcodeTypes)
	{
		Console.WriteLine(barcodeType);
	}
}
```

## Extracting MakerNote metadata

The GroupDocs.Metadata API allows users to read MakerNote properties stored by various camera manufacturers. Please visit the following documentation section for more information: [Extracting MakerNote metadata]({{< ref "metadata/net/developer-guide/advanced-usage/managing-metadata-for-specific-formats/images/working-with-metadata-in-jpeg-images/extracting-makernote-metadata.md" >}})

## Working with XMP metadata

GroupDocs.Metadata for .NET allows managing XMP metadata in JPEG images. For more details please refer to the following guide: [Working with XMP metadata]({{< ref "metadata/net/developer-guide/advanced-usage/working-with-metadata-standards/working-with-xmp-metadata.md" >}}).

## Working with EXIF metadata

The GroupDocs.Metadata API supports handling EXIF metadata in JPEG images. Please find appropriate code samples in the [Working with EXIF metadata]({{< ref "metadata/net/developer-guide/advanced-usage/working-with-metadata-standards/working-with-exif-metadata.md" >}}) section.

## Working with IPTC metadata

GroupDocs.Metadata for .NET is also able to work with IPTC metadata in JPEG images. Please find more information in the [Working with IPTC IIM metadata]({{< ref "metadata/net/developer-guide/advanced-usage/working-with-metadata-standards/working-with-iptc-iim-metadata.md" >}}) section.

## More resources

### GitHub examples

You may easily run the code above and see the feature in action in our GitHub examples:

*   [GroupDocs.Metadata for .NET examples](https://github.com/groupdocs-metadata/GroupDocs.Metadata-for-.NET)
    
*   [GroupDocs.Metadata for Java examples](https://github.com/groupdocs-metadata/GroupDocs.Metadata-for-Java)
    

### Free online document metadata management App

Along with full featured .NET library we provide simple, but powerful free Apps.

You are welcome to view and edit metadata of PDF, DOC, DOCX, PPT, PPTX, XLS, XLSX, emails, images and more with our free online [Free Online Document Metadata Viewing and Editing App](https://products.groupdocs.app/metadata).
