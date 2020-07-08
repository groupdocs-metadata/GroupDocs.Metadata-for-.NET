---
id: groupdocs-metadata-for-net-20-3-release-notes
url: metadata/net/groupdocs-metadata-for-net-20-3-release-notes
title: GroupDocs.Metadata for .NET 20.3 Release Notes
weight: 4
description: ""
keywords: 
productName: GroupDocs.Metadata for .NET
hideChildren: False
---
{{< alert style="info" >}}This page contains release notes for GroupDocs.Metadata for .NET 20.3{{< /alert >}}

## Major Features

There are the following features, enhancements and fixes in this release:

*   Implement the ability to work with EXIF metadata in PSD images
*   Implement the ability to work with XMP metadata in WEBP images

## Full List of Issues Covering all Changes in this Release

| Key | Summary | Category |
| --- | --- | --- |
| METADATANET-2849 | Implement the ability to work with EXIF metadata in PSD images | New Feature |
| METADATANET-2850 | Implement the ability to work with XMP metadata in WEBP images | New Feature |

## Public API and Backward Incompatible Changes

{{< alert style="info" >}}This section lists public API changes that were introduced in GroupDocs.Metadata for .NET 20.3. It includes not only new and obsoleted public methods, but also a description of any changes in the behavior behind the scenes in GroupDocs.Metadata which may affect existing code. Any behavior introduced that could be seen as a regression and modifies existing behavior is especially important and is documented here.{{< /alert >}}

### Implement the ability to work with EXIF metadata in PSD images

This new feature allows the user to update (or remove) EXIF metadata in a PSD file.

##### Public API changes

A setter has been added to the [PsdRootPackage.ExifPackage](https://apireference.groupdocs.com/net/metadata/groupdocs.metadata.formats.image/psdrootpackage/properties/exifpackage) property

The [PsdRootPackage](https://apireference.groupdocs.com/net/metadata/groupdocs.metadata.formats.image/psdrootpackage) class now implements the [IExif](https://apireference.groupdocs.com/net/metadata/groupdocs.metadata.standards.exif/iexif) interface

##### Use cases

Update EXIF metadata properties in a PSD file



```csharp
using (Metadata metadata = new Metadata(@"D:\input.psd"))
{
	IExif root = (IExif)metadata.GetRootPackage();

	// Set the EXIF package if it's missing
	if (root.ExifPackage == null)
	{
		root.ExifPackage = new ExifPackage();
	}

	root.ExifPackage.Copyright = "Copyright (C) 2011-2019 GroupDocs. All Rights Reserved.";
	root.ExifPackage.ImageDescription = "test image";
	root.ExifPackage.Software = "GroupDocs.Metadata";

	// ...

	root.ExifPackage.ExifIfdPackage.BodySerialNumber = "test";
	root.ExifPackage.ExifIfdPackage.CameraOwnerName = "GroupDocs";
	root.ExifPackage.ExifIfdPackage.UserComment = "test comment";

	// ...

	metadata.Save(@"D:\output.psd");
}
```

### Implement the ability to work with XMP metadata in WEBP images

This new feature allows the user to work with XMP metadata in WEBP images.

##### Public API changes

The [XmpPackage](https://apireference.groupdocs.com/net/metadata/groupdocs.metadata.formats.image/webprootpackage/properties/xmppackage) property has been added to the [WebPRootPackage](https://apireference.groupdocs.com/net/metadata/groupdocs.metadata.formats.image/webprootpackage) class

The [WebPRootPackage](https://apireference.groupdocs.com/net/metadata/groupdocs.metadata.formats.image/webprootpackage) class now implements the [IXmp](https://apireference.groupdocs.com/net/metadata/groupdocs.metadata.standards.xmp/ixmp) interface

##### Use cases

Extract XMP metadata properties from a WEBP image



```csharp
using (Metadata metadata = new Metadata(@"D:\input.webp"))
{
	IXmp root = (IXmp)metadata.GetRootPackage();
	if (root.XmpPackage != null)
	{
		if (root.XmpPackage.Schemes.XmpBasic != null)
		{
			Console.WriteLine(root.XmpPackage.Schemes.XmpBasic.CreatorTool);
			Console.WriteLine(root.XmpPackage.Schemes.XmpBasic.CreateDate);
			Console.WriteLine(root.XmpPackage.Schemes.XmpBasic.ModifyDate);
			Console.WriteLine(root.XmpPackage.Schemes.XmpBasic.Label);
			Console.WriteLine(root.XmpPackage.Schemes.XmpBasic.Nickname);

			// ...
		}

		if (root.XmpPackage.Schemes.DublinCore != null)
		{
			Console.WriteLine(root.XmpPackage.Schemes.DublinCore.Format);
			Console.WriteLine(root.XmpPackage.Schemes.DublinCore.Coverage);
			Console.WriteLine(root.XmpPackage.Schemes.DublinCore.Identifier);
			Console.WriteLine(root.XmpPackage.Schemes.DublinCore.Source);

			// ...
		}

		if (root.XmpPackage.Schemes.Photoshop != null)
		{
			Console.WriteLine(root.XmpPackage.Schemes.Photoshop.ColorMode);
			Console.WriteLine(root.XmpPackage.Schemes.Photoshop.IccProfile);
			Console.WriteLine(root.XmpPackage.Schemes.Photoshop.Country);
			Console.WriteLine(root.XmpPackage.Schemes.Photoshop.City);
			Console.WriteLine(root.XmpPackage.Schemes.Photoshop.DateCreated);

			// ... 
		}

		// ...
	}
}
```
