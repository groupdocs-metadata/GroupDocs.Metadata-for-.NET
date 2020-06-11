---
id: working-with-metadata-in-psd-images
url: metadata/net/working-with-metadata-in-psd-images
title: Working with metadata in PSD images
weight: 8
description: ""
keywords: 
productName: GroupDocs.Metadata for .NET
hideChildren: False
---
## Reading Photoshop Metadata properties

The GroupDocs Metadata API allows the user to read Adobe Photoshop metadata associated with a PSD image. For more information on the Photoshop file format and metadata blocks please refer to the specification: [https://www.adobe.com/devnet-apps/photoshop/fileformatashtml/](https://www.adobe.com/devnet-apps/photoshop/fileformatashtml/).

The code sample below demonstrates how to extract image resource blocks (building blocks of the Photoshop file format) from a PSD image.

1.  [Load]({{< ref "metadata/net/developer-guide/advanced-usage/loading-files/_index.md" >}}) a PSD file
2.  Get the root metadata package
3.  Extract the [ImageResourcePackage](https://apireference.groupdocs.com/net/metadata/groupdocs.metadata.formats.image/imageresourcepackage) instance and obtain a list of [ImageResourceBlock](https://apireference.groupdocs.com/net/metadata/groupdocs.metadata.formats.image/imageresourceblock) objects
4.  Iterate trough the collection of resource blocks

**AdvancedUsage.ManagingMetadataForSpecificFormats.Image.Psd.PsdReadImageResourceBlocks**

```csharp
using (Metadata metadata = new Metadata(Constants.PsdWithIrb))
{
	var root = metadata.GetRootPackage<PsdRootPackage>();
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

## Reading the image header and information about PSD layers

The GroupDocs.Metadata API also supports extracting some other format-specific information from PSD images.

The following are the steps to read the header of a PSD file and extract information about the PSD layers.

1.  [Load]({{< ref "metadata/net/developer-guide/advanced-usage/loading-files/_index.md" >}}) a PSD image
2.  Get the root metadata package
3.  Extract  the native metadata package using the [PsdRootPackage.PsdPackage](https://apireference.groupdocs.com/net/metadata/groupdocs.metadata.formats.image/psdrootpackage/properties/psdpackage) property
4.  Read the PSD header and layer information

**AdvancedUsage.ManagingMetadataForSpecificFormats.Image.Psd.PsdReadNativeMetadataProperties**

```csharp
using (Metadata metadata = new Metadata(Constants.PsdWithIptc))
{
	var root = metadata.GetRootPackage<PsdRootPackage>();

	Console.WriteLine(root.PsdPackage.ChannelCount);
	Console.WriteLine(root.PsdPackage.ColorMode);
	Console.WriteLine(root.PsdPackage.Compression);
	Console.WriteLine(root.PsdPackage.PhotoshopVersion);

	foreach (var layer in root.PsdPackage.Layers)
	{
		Console.WriteLine(layer.Name);
		Console.WriteLine(layer.BitsPerPixel);
		Console.WriteLine(layer.ChannelCount);
		Console.WriteLine(layer.Flags);
		Console.WriteLine(layer.Height);
		Console.WriteLine(layer.Width);

		// ...
	}

	// ...
}
```

## Working with XMP metadata

GroupDocs.Metadata for .NET allows managing XMP metadata in PSD images. For more details please refer to the following guide: [Working with XMP metadata]({{< ref "metadata/net/developer-guide/advanced-usage/working-with-metadata-standards/working-with-xmp-metadata.md" >}}).

## Working with EXIF metadata

The GroupDocs.Metadata API supports handling EXIF metadata in PSD images. Please find appropriate code samples in the [Working with EXIF metadata]({{< ref "metadata/net/developer-guide/advanced-usage/working-with-metadata-standards/working-with-exif-metadata.md" >}}) section.

## Working with IPTC metadata

GroupDocs.Metadata for .NET is also able to work with IPTC metadata in PSD images. Please find more information in the [Working with IPTC IIM metadata]({{< ref "metadata/net/developer-guide/advanced-usage/working-with-metadata-standards/working-with-iptc-iim-metadata.md" >}}) section.

## More resources

### GitHub examples

You may easily run the code above and see the feature in action in our GitHub examples:

*   [GroupDocs.Metadata for .NET examples](https://github.com/groupdocs-metadata/GroupDocs.Metadata-for-.NET)
    
*   [GroupDocs.Metadata for Java examples](https://github.com/groupdocs-metadata/GroupDocs.Metadata-for-Java)
    

### Free online document metadata management App

Along with full featured .NET library we provide simple, but powerful free Apps.

You are welcome to view and edit metadata of PDF, DOC, DOCX, PPT, PPTX, XLS, XLSX, emails, images and more with our free online [Free Online Document Metadata Viewing and Editing App](https://products.groupdocs.app/metadata).
