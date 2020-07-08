---
id: working-with-exif-metadata
url: metadata/net/working-with-exif-metadata
title: Working with EXIF metadata
weight: 1
description: ""
keywords: 
productName: GroupDocs.Metadata for .NET
hideChildren: False
---
## What is EXIF?

According to the [specification](https://www.exif.org/Exif2-2.PDF), EXIF (Exchangeable image file format) is a standard that specifies the formats to be used for images, sound and tags in digital still cameras and in other systems handling the image and sound files recorded by digital still cameras. Despite the confusing definition and name of the format, EXIF is just a metadata standard. In fact, it simply defines a way to store metadata properties in a variety of well-known image and audio formats. The EXIF tag structure is borrowed from TIFF files. The [specification](https://www.exif.org/Exif2-2.PDF) declares a set of tags intended to store technical details such as the geolocation of the place where a picture was taken, the name of the camera owner, camera settings, etc. 

{{< alert style="info" >}}Please refer to the following article to get more information on the standard.{{< /alert >}}

## Reading basic EXIF properties

To access EXIF metadata in a file of any supported format, GroupDocs.Metadata provides the [IExif.ExifPackage](https://apireference.groupdocs.com/net/metadata/groupdocs.metadata.standards.exif/iexif/properties/exifpackage) property. The following are the steps to read EXIF metadata:

1.  [Load]({{< ref "metadata/net/developer-guide/advanced-usage/loading-files/_index.md" >}}) a file that contains EXIF metadata
2.  Extract the EXIF metadata package using the [IExif.ExifPackage](https://apireference.groupdocs.com/net/metadata/groupdocs.metadata.standards.exif/iexif/properties/exifpackage) property

The following code snippet gets EXIF properties of a TIFF image and displays them on the screen. 

**AdvancedUsage.WorkingWithMetadataStandards.<WBR>Exif.ReadBasicExifProperties**

```csharp
using (Metadata metadata = new Metadata(Constants.TiffWithExif))
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

## Reading all EXIF tags

In some cases, it's necessary to read all EXIF properties from a file, including custom ones. To achieve this the GroupDocs.Metadata API provides direct access to the EXIF tags extracted from a file.

1.  [Load]({{< ref "metadata/net/developer-guide/advanced-usage/loading-files/_index.md" >}}) a file that contains EXIF metadata
2.  Extract the EXIF metadata package using the [IExif.ExifPackage](https://apireference.groupdocs.com/net/metadata/groupdocs.metadata.standards.exif/iexif/properties/exifpackage) property
3.  Iterate through all EXIF tags on different levels

**AdvancedUsage.WorkingWithMetadataStandards.<WBR>Exif.ReadExifTags**

```csharp
using (Metadata metadata = new Metadata(Constants.JpegWithExif))
{
	IExif root = metadata.GetRootPackage() as IExif;
	if (root != null && root.ExifPackage != null)
	{
		const string pattern = "{0} = {1}";

		foreach (TiffTag tag in root.ExifPackage.ToList())
		{
			Console.WriteLine(pattern, tag.TagID, tag.Value);
		}

		foreach (TiffTag tag in root.ExifPackage.ExifIfdPackage.ToList())
		{
			Console.WriteLine(pattern, tag.TagID, tag.Value);
		}

		foreach (TiffTag tag in root.ExifPackage.GpsPackage.ToList())
		{
			Console.WriteLine(pattern, tag.TagID, tag.Value);
		}
	}
}
```

## Reading a specific EXIF tag

The GroupDocs.Metadata API also supports reading specific EXIF tags using an indexer. Follow below-mentioned steps to read a specific EXIF tag.

1.  [Load]({{< ref "metadata/net/developer-guide/advanced-usage/loading-files/_index.md" >}}) a file that contains EXIF metadata
2.  Extract the EXIF metadata package using the [IExif.ExifPackage](https://apireference.groupdocs.com/net/metadata/groupdocs.metadata.standards.exif/iexif/properties/exifpackage) property
3.  Get a specific tag using the [ExifPackage](https://apireference.groupdocs.com/net/metadata/groupdocs.metadata.standards.exif/exifpackage) class [indexer](https://apireference.groupdocs.com/net/metadata/groupdocs.metadata.standards.exif/exifdictionarybasepackage/properties/item)

**AdvancedUsage.WorkingWithMetadataStandards.<WBR>Exif.ReadSpecificExifTag**

```csharp
using (Metadata metadata = new Metadata(Constants.TiffWithExif))
{
	IExif root = metadata.GetRootPackage() as IExif;
	if (root != null && root.ExifPackage != null)
	{
		TiffAsciiTag software = (TiffAsciiTag)root.ExifPackage[TiffTagID.Software];
		if (software != null)
		{
			Console.WriteLine("Software: {0}", software.Value);
		}
	}
}
```

## Updating EXIF properties

The GroupDocs.Metadata API facilitates the user to update EXIF metadata in a convenient way - using the [ExifPackage](https://apireference.groupdocs.com/net/metadata/groupdocs.metadata.standards.exif/exifpackage) class properties. Follow the below steps to update EXIF metadata in a file of any supported format.

1.  [Load]({{< ref "metadata/net/developer-guide/advanced-usage/loading-files/_index.md" >}}) a file that contains EXIF metadata
2.  Extract the EXIF metadata package using the [IExif.ExifPackage](https://apireference.groupdocs.com/net/metadata/groupdocs.metadata.standards.exif/iexif/properties/exifpackage) property
3.  Assign values to desired EXIF properties
4.  [Save]({{< ref "metadata/net/developer-guide/advanced-usage/saving-files/_index.md" >}}) the changes

**AdvancedUsage.WorkingWithMetadataStandards.<WBR>Exif.UpdateExifProperties**

```csharp
using (Metadata metadata = new Metadata(Constants.InputJpeg))
{
	IExif root = metadata.GetRootPackage() as IExif;
	if (root != null)
	{
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

		metadata.Save(Constants.OutputJpeg);
	}
}
```

## Adding or updating custom EXIF tags

The GroupDocs.Metadata API allows adding or updating custom tags in an EXIF package.

1.  [Load]({{< ref "metadata/net/developer-guide/advanced-usage/loading-files/_index.md" >}}) a file that contains EXIF metadata
2.  Extract the EXIF metadata package using the [IExif.ExifPackage](https://apireference.groupdocs.com/net/metadata/groupdocs.metadata.standards.exif/iexif/properties/exifpackage) property
3.  Set the EXIF package if it's missing
4.  Add any number of custom tags to the package
5.  [Save]({{< ref "metadata/net/developer-guide/advanced-usage/saving-files/_index.md" >}}) the changes

**AdvancedUsage.WorkingWithMetadataStandards.<WBR>Exif.SetCustomExifTag**

```csharp
using (Metadata metadata = new Metadata(Constants.TiffWithExif))
{
	IExif root = metadata.GetRootPackage() as IExif;
	if (root != null)
	{
		// Set the EXIF package if it's missing
		if (root.ExifPackage == null)
		{
			root.ExifPackage = new ExifPackage();
		}

		// Add a known property
		root.ExifPackage.Set(new TiffAsciiTag(TiffTagID.Artist, "test artist"));

		// Add a fully custom property (which is not described in the EXIF specification).
		// Please note that the chosen ID may intersect with the IDs used by some third party tools.
		root.ExifPackage.Set(new TiffAsciiTag((TiffTagID)65523, "custom"));

		metadata.Save(Constants.OutputTiff);
	}
}
```

Here is a full list of tags that can be added to an EXIF package:

*   [TiffAsciiTag](https://apireference.groupdocs.com/net/metadata/groupdocs.metadata.formats.image/tiffasciitag)
*   [TiffByteTag](https://apireference.groupdocs.com/net/metadata/groupdocs.metadata.formats.image/tiffbytetag)
*   [TiffDoubleTag](https://apireference.groupdocs.com/net/metadata/groupdocs.metadata.formats.image/tiffdoubletag)
*   [TiffFloatTag](https://apireference.groupdocs.com/net/metadata/groupdocs.metadata.formats.image/tifffloattag)
*   [TiffLongTag](https://apireference.groupdocs.com/net/metadata/groupdocs.metadata.formats.image/tifflongtag)
*   [TiffRationalTag](https://apireference.groupdocs.com/net/metadata/groupdocs.metadata.formats.image/tiffrationaltag)
*   [TiffSByteTag](https://apireference.groupdocs.com/net/metadata/groupdocs.metadata.formats.image/tiffsbytetag)
*   [TiffShortTag](https://apireference.groupdocs.com/net/metadata/groupdocs.metadata.formats.image/tiffshorttag)
*   [TiffSLongTag](https://apireference.groupdocs.com/net/metadata/groupdocs.metadata.formats.image/tiffslongtag)
*   [TiffSRationalTag](https://apireference.groupdocs.com/net/metadata/groupdocs.metadata.formats.image/tiffsrationaltag)
*   [TiffSShortTag](https://apireference.groupdocs.com/net/metadata/groupdocs.metadata.formats.image/tiffsshorttag)
*   [TiffUndefinedTag](https://apireference.groupdocs.com/net/metadata/groupdocs.metadata.formats.image/tiffundefinedtag)

## Removing EXIF metadata

To remove the EXIF package from a file just assign null to the [IExif.ExifPackage](https://apireference.groupdocs.com/net/metadata/groupdocs.metadata.standards.exif/iexif/properties/exifpackage) property. The code sample below shows how to remove EXIF metadata from a file.

**AdvancedUsage.WorkingWithMetadataStandards.<WBR>Exif.RemoveExifMetadata**

```csharp
using (Metadata metadata = new Metadata(Constants.JpegWithExif))
{
	IExif root = metadata.GetRootPackage() as IExif;
	if (root != null)
	{
		root.ExifPackage = null;
		metadata.Save(Constants.OutputJpeg);
	}
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