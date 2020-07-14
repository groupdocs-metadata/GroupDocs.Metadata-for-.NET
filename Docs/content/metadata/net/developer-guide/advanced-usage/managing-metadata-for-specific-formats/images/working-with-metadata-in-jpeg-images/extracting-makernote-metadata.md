---
id: extracting-makernote-metadata
url: metadata/net/extracting-makernote-metadata
title: Extracting MakerNote Metadata
weight: 1
description: ""
keywords: 
productName: GroupDocs.Metadata for .NET
hideChildren: False
---
### What is MakerNote?

MakerNote metadata refers to image information that is written by digital cameras of different manufacturers. Usually, MakerNote metadata properties contain camera settings and some other conditions under which the shot was taken. Most manufacturers store MakerNote properties in a proprietary binary format derived from EXIF. GroupDocs.Metadata allows extracting MakerNote metadata saved by the following manufacturers:

*   Canon
*   Nikon
*   Panasonic
*   Sony

### Read all MakerNote Properties in the Form of TIFF/EXIF Tags

Utilizing the GroupDocs.Metadata API the user is able to read all metadata properties regardless of the exact MakerNote format.

1.  [Load]({{< ref "metadata/net/developer-guide/advanced-usage/loading-files/_index.md" >}}) a raw image file that contains MakerNote metadata
2.  Extract the MakerNote package using the [MakerNotePackage](https://apireference.groupdocs.com/net/metadata/groupdocs.metadata.formats.image/jpegrootpackage/properties/makernotepackage) property
3.  Iterate through the EXIF tags 

**AdvancedUsage.ManagingMetadataForSpecificFormats.<WBR>Image.Jpeg.MakerNote.MakerNoteReadAllTags**

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

To help you with interpreting extracted tags we implemented classes representing specific MakerNote metadata packages. Please cast the return value of the [MakerNotePackage](https://apireference.groupdocs.com/net/metadata/groupdocs.metadata.formats.image/jpegrootpackage/properties/makernotepackage) property to one of the classes listed below to get more format-specific capabilities:

*   [CanonMakerNotePackage](https://apireference.groupdocs.com/net/metadata/groupdocs.metadata.standards.exif.makernote/canonmakernotepackage)
*   [NikonMakerNotePackage](https://apireference.groupdocs.com/net/metadata/groupdocs.metadata.standards.exif.makernote/nikonmakernotepackage)
*   [PanasonicMakerNotePackage](https://apireference.groupdocs.com/net/metadata/groupdocs.metadata.standards.exif.makernote/panasonicmakernotepackage)
*   [SonyMakerNotePackage](https://apireference.groupdocs.com/net/metadata/groupdocs.metadata.standards.exif.makernote/sonymakernotepackage)

### Read Canon MakerNote Properties

**AdvancedUsage.ManagingMetadataForSpecificFormats.<WBR>Image.Jpeg.MakerNote.MakerNoteReadCanonProperties**

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

### Read Nikon MakerNote Properties

**AdvancedUsage.ManagingMetadataForSpecificFormats.<WBR>Image.Jpeg.MakerNote.MakerNoteReadNikonProperties**

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

### Read Panasonic MakerNote Properties

**AdvancedUsage.ManagingMetadataForSpecificFormats.<WBR>Image.Jpeg.MakerNote.MakerNote.MakerNoteReadPanasonicProperties**

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

### Read Sony MakerNote Properties

**AdvancedUsage.ManagingMetadataForSpecificFormats.<WBR>Image.Jpeg.MakerNote.MakerNote.MakerNote.MakerNoteReadSonyProperties**

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
