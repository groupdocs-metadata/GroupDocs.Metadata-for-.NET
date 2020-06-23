---
id: groupdocs-metadata-for-net-20-4-release-notes
url: metadata/net/groupdocs-metadata-for-net-20-4-release-notes
title: GroupDocs.Metadata for .NET 20.4 Release Notes
weight: 3
description: ""
keywords: 
productName: GroupDocs.Metadata for .NET
hideChildren: False
---
{{< alert style="info" >}}This page contains release notes for GroupDocs.Metadata for .NET 20.4{{< /alert >}}

## Major Features

There are the following features, enhancements and fixes in this release:

*   Implement the ability to work with EXIF metadata in PNG images
*   Implement the ability to work with XMP metadata in MP3 files
*   Implement the ability to parse most common EXIF Makernote metadata formats using the new API

## Full List of Issues Covering all Changes in this Release

| Key | Summary | Category |
| --- | --- | --- |
| METADATANET-2847 | Implement the ability to work with EXIF metadata in PNG images | New Feature |
| METADATANET-2852 | Implement the ability to work with XMP metadata in MP3 files | New Feature |
| METADATANET-3185 | Implement the ability to parse most common EXIF Makernote metadata formats using the new API | Enhancement |

## Public API and Backward Incompatible Changes

{{< alert style="info" >}}This section lists public API changes that were introduced in GroupDocs.Metadata for .NET 20.4. It includes not only new and obsoleted public methods, but also a description of any changes in the behavior behind the scenes in GroupDocs.Metadata which may affect existing code. Any behavior introduced that could be seen as a regression and modifies existing behavior is especially important and is documented here.{{< /alert >}}

### Implement the ability to work with EXIF metadata in PNG images

This new feature allows the user to read, update and remove EXIF metadata in PNG images.

##### Public API changes

The [ExifPackage](https://apireference.groupdocs.com/net/metadata/groupdocs.metadata.formats.image/pngrootpackage/properties/exifpackage) property has been added to the [PngRootPackage](https://apireference.groupdocs.com/net/metadata/groupdocs.metadata.formats.image/pngrootpackage) class

The [PngRootPackage](https://apireference.groupdocs.com/net/metadata/groupdocs.metadata.formats.image/pngrootpackage) class now implements the [IExif](https://apireference.groupdocs.com/net/metadata/groupdocs.metadata.standards.exif/iexif) interface

##### Use cases

Read EXIF metadata properties in a PNG  image



```csharp
using (Metadata metadata = new Metadata(@"D:\exif.png"))
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

### Implement the ability to work with XMP metadata in MP3 files

This new feature allows the user to read, update and remove XMP metadata in MP3 audio files.

##### Public API changes

The [XmpPackage](https://apireference.groupdocs.com/net/metadata/groupdocs.metadata.formats.audio/mp3rootpackage/properties/xmppackage) property has been added to the [MP3RootPackage](https://apireference.groupdocs.com/net/metadata/groupdocs.metadata.formats.audio/mp3rootpackage) class

The [MP3RootPackage](https://apireference.groupdocs.com/net/metadata/groupdocs.metadata.formats.audio/mp3rootpackage) class now implements the [IXmp](https://apireference.groupdocs.com/net/metadata/groupdocs.metadata.standards.xmp/ixmp) interface

##### Use cases

Read XMP metadata properties in an MP3 audio



```csharp
using (Metadata metadata = new Metadata(@"D:\xmp.mp3"))
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

### Implement the ability to parse most common EXIF Makernote metadata formats using the new API

This enhancement allows the user to read MakerNote metadata packages stored by various camera manufacturers. Currently, this feature is available for JPEG images only.

##### Public API changes

The [MakerNotePackage](https://apireference.groupdocs.com/net/metadata/groupdocs.metadata.formats.image/jpegrootpackage/properties/makernotepackage) property has been added to the [JpegRootPackage](https://apireference.groupdocs.com/net/metadata/groupdocs.metadata.formats.image/jpegrootpackage) class

The [GroupDocs.Metadata.Standards.Exif.MakerNote](https://apireference.groupdocs.com/net/metadata/groupdocs.metadata.standards.exif.makernote) namespace has been introduced

The following classes have been added to the [GroupDocs.Metadata.Standards.Exif.MakerNote](https://apireference.groupdocs.com/net/metadata/groupdocs.metadata.standards.exif.makernote/) namespace

*   [CanonCameraSettingsPackage](https://apireference.groupdocs.com/net/metadata/groupdocs.metadata.standards.exif.makernote/canoncamerasettingspackage)
*   [CanonMakerNotePackage](https://apireference.groupdocs.com/net/metadata/groupdocs.metadata.standards.exif.makernote/canonmakernotepackage)
*   [MakerNotePackage](https://apireference.groupdocs.com/net/metadata/groupdocs.metadata.standards.exif.makernote/makernotepackage)
*   [NikonMakerNotePackage](https://apireference.groupdocs.com/net/metadata/groupdocs.metadata.standards.exif.makernote/nikonmakernotepackage)
*   [PanasonicMakerNotePackage](https://apireference.groupdocs.com/net/metadata/groupdocs.metadata.standards.exif.makernote/panasonicmakernotepackage)
*   [SonyMakerNotePackage](https://apireference.groupdocs.com/net/metadata/groupdocs.metadata.standards.exif.makernote/sonymakernotepackage)

##### Use cases

Read all MakerNote properties in the form of TIFF/EXIF tags



```csharp
using (Metadata metadata = new Metadata(Constants.CanonJpeg))
{
	var root = metadata.GetRootPackage<JpegRootPackage>();
	if (root.MakerNotePackage != null)
	{
		foreach (var tag in root.MakerNotePackage.ToList())
		{
			// Please note that tag ids used by camera manufacturers may intersect with the ids defined in the TIFF/EXIF specification
			Console.WriteLine("{0} = {1}", (int) tag.TagID, tag.Value);
		}
	}
}
```

Read Canon MakerNote properties



```csharp
using (Metadata metadata = new Metadata(Constants.CanonJpeg))
{
	var root = metadata.GetRootPackage<JpegRootPackage>();
	var makerNote = (CanonMakerNotePackage)root.MakerNotePackage;
	if (makerNote != null)
	{
		Console.WriteLine(makerNote.CanonFirmwareVersion);
		Console.WriteLine(makerNote.CanonImageType);
		Console.WriteLine(makerNote.OwnerName);
		Console.WriteLine(makerNote.CanonModelID);

		// ...

		if (makerNote.CameraSettings != null)
		{
			Console.WriteLine(makerNote.CameraSettings.AFPoint);
			Console.WriteLine(makerNote.CameraSettings.CameraIso);
			Console.WriteLine(makerNote.CameraSettings.Contrast);
			Console.WriteLine(makerNote.CameraSettings.DigitalZoom);

			// ...
		}
	}
}
```

Read Nikon MakerNote properties



```csharp
using (Metadata metadata = new Metadata(Constants.NikonJpeg))
{
	var root = metadata.GetRootPackage<JpegRootPackage>();
	var makerNote = (NikonMakerNotePackage) root.MakerNotePackage;
	if (makerNote != null)
	{
		Console.WriteLine(makerNote.ColorMode);
		Console.WriteLine(makerNote.FlashSetting);
		Console.WriteLine(makerNote.FlashType);
		Console.WriteLine(makerNote.FocusMode);
		Console.WriteLine(makerNote.Quality);
		Console.WriteLine(makerNote.Sharpness);

		// ...
	}
}
```

Read Panasonic MakerNote properties



```csharp
using (Metadata metadata = new Metadata(Constants.PanasonicJpeg))
{
	var root = metadata.GetRootPackage<JpegRootPackage>();
	var makerNote = (PanasonicMakerNotePackage) root.MakerNotePackage;

	if (makerNote != null)
	{
		Console.WriteLine(makerNote.AccessorySerialNumber);
		Console.WriteLine(makerNote.AccessoryType);
		Console.WriteLine(makerNote.MacroMode);
		Console.WriteLine(makerNote.LensSerialNumber);
		Console.WriteLine(makerNote.LensType);

		// ...
	}
}
```

Read Sony MakerNote properties



```csharp
using (Metadata metadata = new Metadata(Constants.SonyJpeg))
{
	var root = metadata.GetRootPackage<JpegRootPackage>();
	var makerNote = (SonyMakerNotePackage)root.MakerNotePackage;
	if (makerNote != null)
	{
		Console.WriteLine(makerNote.CreativeStyle);
		Console.WriteLine(makerNote.ColorMode);
		Console.WriteLine(makerNote.JpegQuality);
		Console.WriteLine(makerNote.Brightness);
		Console.WriteLine(makerNote.Sharpness);

		// ...
	}
}
```
