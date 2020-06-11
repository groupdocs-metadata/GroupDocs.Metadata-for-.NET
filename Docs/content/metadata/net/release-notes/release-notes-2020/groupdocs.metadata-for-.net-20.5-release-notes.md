---
id: groupdocs-metadata-for-net-20-5-release-notes
url: metadata/net/groupdocs-metadata-for-net-20-5-release-notes
title: GroupDocs.Metadata for .NET 20.5 Release Notes
weight: 2
description: ""
keywords: 
productName: GroupDocs.Metadata for .NET
hideChildren: False
---
{{< alert style="info" >}}This page contains release notes for GroupDocs.Metadata for .NET 20.5{{< /alert >}}

#   
Major Features

{{< alert style="danger" >}}In version 20.5 the legacy API has been removed (all types from the GroupDocs.Metadata.Legacy namespace were removed).{{< /alert >}}

  
There are the following features, enhancements and fixes in this release:

*   Remove obsolete API (Legacy namespace)
*   Implement the ability to work with EXIF metadata in WEBP images
*   Implement the ability to work with XMP metadata in MOV files  
      
    

## Full List of Issues Covering all Changes in this Release

| Key | Summary | Category |
| --- | --- | --- |
| METADATANET-3293 | Remove obsolete API (Legacy namespace) | Improvement |
| METADATANET-2851 | Implement the ability to work with EXIF metadata in WEBP images | New Feature |
| METADATANET-2854 | Implement the ability to work with XMP metadata in MOV files | New Feature |
| METADATANET-3177 | An exception is thrown when trying to extract PDF properties | Bug |
| METADATANET-3270 | Operation is not valid due to the current state of the object | Bug |
| METADATANET-3273 | Could not parse RDF description | Bug |
| METADATANET-3276 | "Could not unzip EPUB stream" exception when reading EPUB file | Bug |
| METADATANET-3278 | "Date has invalid format:7/24/2003 16:17:18" exception when reading PDF | Bug |
| METADATANET-3279 | Invalid data descriptor header exception is thrown when reading ZIP file | Bug |
| METADATANET-3282 | "Invalid Epub package" exception when reading EPUB file | Bug |
| METADATANET-3285 | An exception is thrown when trying to loading WebP file | Bug |
| METADATANET-3290 | Exception is thrown when loading EPUB file | Bug |

## Public API and Backward Incompatible Changes

{{< alert style="info" >}}This section lists public API changes that were introduced in GroupDocs.Metadata for .NET 20.5. It includes not only new and obsoleted public methods, but also a description of any changes in the behavior behind the scenes in GroupDocs.Metadata which may affect existing code. Any behavior introduced that could be seen as a regression and modifies existing behavior is especially important and is documented here.{{< /alert >}}

### Remove obsolete API (Legacy namespace)

All types from the GroupDocs.Metadata.Legacy namespace were removed**.**

##### Public API changes

All types from the GroupDocs.Metadata.Legacy namespace were removed

##### Use cases

See the [migration notes]({{< ref "metadata/net/developer-guide/migration-notes.md" >}}) for brief comparison of the old and new API

### Implement the ability to work with EXIF metadata in WEBP images

This new feature allows the user to read, update and remove EXIF metadata in WEBP images.

##### Public API changes

The [ExifPackage](https://apireference.groupdocs.com/net/metadata/groupdocs.metadata.formats.image/webprootpackage/properties/exifpackage) property has been added to the [WebPRootPackage](https://apireference.groupdocs.com/net/metadata/groupdocs.metadata.formats.image/webprootpackage) class

The [WebPRootPackage](https://apireference.groupdocs.com/net/metadata/groupdocs.metadata.formats.image/webprootpackage) class now implements the [IExif](https://apireference.groupdocs.com/net/metadata/groupdocs.metadata.standards.exif/iexif) interface

##### Use cases

Read EXIF metadata properties in a WEBP image

**C#**

```csharp
using (Metadata metadata = new Metadata(@"D:\exif.webp"))
{
	IExif root = metadata.GetRootPackage() as IExif;
	if (root != null && root.ExifPackage != null)
	{
		Console.WriteLine(root.ExifPackage.Artist);
		Console.WriteLine(root.ExifPackage.Copyright);
		Console.WriteLine(root.ExifPackage.ImageDescription);
		Console.WriteLine(root.ExifPackage.Make);
		Console.WriteLine(root.ExifPackage.Model);
		Console.WriteLine(root.ExifPackage.Software);
		Console.WriteLine(root.ExifPackage.ImageWidth);
		Console.WriteLine(root.ExifPackage.ImageLength);
		// ...
		Console.WriteLine(root.ExifPackage.ExifIfdPackage.BodySerialNumber);
		Console.WriteLine(root.ExifPackage.ExifIfdPackage.CameraOwnerName);
		Console.WriteLine(root.ExifPackage.ExifIfdPackage.UserComment);
		// ...
		Console.WriteLine(root.ExifPackage.GpsPackage.Altitude);
		Console.WriteLine(root.ExifPackage.GpsPackage.LatitudeRef);
		Console.WriteLine(root.ExifPackage.GpsPackage.LongitudeRef);
		// ...
	}
}
```

### Implement the ability to work with XMP metadata in MOV files

This new feature allows the user to read, update and remove XMP metadata in MOV video files.

##### Public API changes

The [XmpPackage](https://apireference.groupdocs.com/metadata/net/groupdocs.metadata.formats.video/movrootpackage/properties/xmppackage) property has been added to the [MovRootPackage](https://apireference.groupdocs.com/net/metadata/groupdocs.metadata.formats.video/movrootpackage) class

The [MovRootPackage](https://apireference.groupdocs.com/net/metadata/groupdocs.metadata.formats.video/movrootpackage) class now implements the [IXmp](https://apireference.groupdocs.com/net/metadata/groupdocs.metadata.standards.xmp/ixmp) interface

##### Use cases

Read XMP metadata properties in a MOV video

**C#**

```csharp
using (Metadata metadata = new Metadata(@"D:\xmp.mov"))
{
	IXmp root = metadata.GetRootPackage() as IXmp;
	if (root != null && root.XmpPackage != null)
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
