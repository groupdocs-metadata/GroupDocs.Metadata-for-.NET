---
id: working-with-xmp-metadata
url: metadata/net/working-with-xmp-metadata
title: Working with XMP metadata
weight: 3
description: ""
keywords: 
productName: GroupDocs.Metadata for .NET
hideChildren: False
---
## What is XMP?

The Extensible Metadata Platform (XMP) is an XML-based ISO metadata standard, originally created by Adobe Systems Inc. It defines a data structure, serialization model and basic metadata properties intended to form a unified metadata package that can be embedded into different media formats. The defined XMP data model can be used to store any set of metadata properties. These can be simple name/value pairs, structured values or lists of values. The data can be nested as well.

{{< alert style="info" >}}Please find more information on the XMP standard at https://en.wikipedia.org/wiki/Extensible_Metadata_Platform{{< /alert >}}

## Reading XMP properties

To access XMP metadata in a file of any supported format, GroupDocs.Metadata provides the [IXmp.XmpPackage](https://apireference.groupdocs.com/net/metadata/groupdocs.metadata.standards.xmp/ixmp/properties/xmppackage) property. The following are the steps to read XMP metadata:

1.  [Load]({{< ref "metadata/net/developer-guide/advanced-usage/loading-files/_index.md" >}}) a file that contains XMP metadata
2.  Extract the XMP metadata package using the [IXmp.XmpPackage](https://apireference.groupdocs.com/net/metadata/groupdocs.metadata.standards.xmp/ixmp/properties/xmppackage) property

The following code snippet gets XMP properties of a PNG image and displays them on the screen. 

**AdvancedUsage.WorkingWithMetadataStandards.<WBR>Xmp.ReadXmpProperties**

```csharp
using (Metadata metadata = new Metadata(Constants.PngWithXmp))
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

Here is a full list of supported XMP schemes:

*   [XmpBasicJobTicketPackage](https://apireference.groupdocs.com/net/metadata/groupdocs.metadata.standards.xmp.schemes/xmpbasicjobticketpackage)
*   [XmpBasicPackage](https://apireference.groupdocs.com/net/metadata/groupdocs.metadata.standards.xmp.schemes/xmpbasicpackage)
*   [XmpCameraRawPackage](https://apireference.groupdocs.com/net/metadata/groupdocs.metadata.standards.xmp.schemes/xmpcamerarawpackage)
*   [XmpDublinCorePackage](https://apireference.groupdocs.com/net/metadata/groupdocs.metadata.standards.xmp.schemes/xmpdublincorepackage)
*   [XmpDynamicMediaPackage](https://apireference.groupdocs.com/net/metadata/groupdocs.metadata.standards.xmp.schemes/xmpdynamicmediapackage)
*   [XmpIptcCorePackage](https://apireference.groupdocs.com/net/metadata/groupdocs.metadata.standards.xmp.schemes/xmpiptccorepackage)
*   [XmpIptcExtensionPackage](https://apireference.groupdocs.com/net/metadata/groupdocs.metadata.standards.xmp.schemes/xmpiptcextensionpackage)
*   [XmpIptcIimPackage](https://apireference.groupdocs.com/net/metadata/groupdocs.metadata.standards.xmp.schemes/xmpiptciimpackage)
*   [XmpMediaManagementPackage](https://apireference.groupdocs.com/net/metadata/groupdocs.metadata.standards.xmp.schemes/xmpmediamanagementpackage)
*   [XmpPagedTextPackage](https://apireference.groupdocs.com/net/metadata/groupdocs.metadata.standards.xmp.schemes/xmppagedtextpackage)
*   [XmpPdfPackage](https://apireference.groupdocs.com/net/metadata/groupdocs.metadata.standards.xmp.schemes/xmppdfpackage)
*   [XmpPhotoshopPackage](https://apireference.groupdocs.com/net/metadata/groupdocs.metadata.standards.xmp.schemes/xmpphotoshoppackage)
*   [XmpRightsManagementPackage](https://apireference.groupdocs.com/net/metadata/groupdocs.metadata.standards.xmp.schemes/xmprightsmanagementpackage)

{{< alert style="info" >}}GroupDocs.Metadata also provides an API allowing users to work with fully custom XMP schemes/packages. Please refer to this code snippet to learn more.{{< /alert >}}

## Updating XMP properties

The GroupDocs.Metadata API facilitates the user to update XMP metadata in a convenient way - using the [XmpPacketWrapper](https://apireference.groupdocs.com/net/metadata/groupdocs.metadata.standards.xmp/xmppacketwrapper) class properties. Follow the below steps to update XMP metadata in a file of any supported format.

1.  [Load]({{< ref "metadata/net/developer-guide/advanced-usage/loading-files/_index.md" >}}) a file that contains XMP metadata
2.  Extract the XMP metadata package using the [IXmp.XmpPackage](https://apireference.groupdocs.com/net/metadata/groupdocs.metadata.standards.xmp/ixmp/properties/xmppackage) property
3.  Assign values to desired XMP properties
4.  [Save]({{< ref "metadata/net/developer-guide/advanced-usage/saving-files/_index.md" >}}) the changes

**AdvancedUsage.WorkingWithMetadataStandards.<WBR>Xmp.UpdateXmpProperties**

```csharp
using (Metadata metadata = new Metadata(Constants.GifWithXmp))
{
	IXmp root = metadata.GetRootPackage() as IXmp;
	if (root != null && root.XmpPackage != null)
	{
		// if there is no such scheme in the XMP package we should create it
		if (root.XmpPackage.Schemes.DublinCore == null)
		{
			root.XmpPackage.Schemes.DublinCore = new XmpDublinCorePackage();
		}
		root.XmpPackage.Schemes.DublinCore.Format = "image/gif";
		root.XmpPackage.Schemes.DublinCore.SetRights("Copyright (C) 2011-2019 GroupDocs. All Rights Reserved");
		root.XmpPackage.Schemes.DublinCore.SetSubject("test");

		if (root.XmpPackage.Schemes.CameraRaw == null)
		{
			root.XmpPackage.Schemes.CameraRaw = new XmpCameraRawPackage();
		}
		root.XmpPackage.Schemes.CameraRaw.Shadows = 50;
		root.XmpPackage.Schemes.CameraRaw.AutoBrightness = true;
		root.XmpPackage.Schemes.CameraRaw.AutoExposure = true;
		root.XmpPackage.Schemes.CameraRaw.CameraProfile = "test";
		root.XmpPackage.Schemes.CameraRaw.Exposure = 0.0001;

		// If you don't want to keep the old values just replace the whole scheme
		root.XmpPackage.Schemes.XmpBasic = new XmpBasicPackage();
		root.XmpPackage.Schemes.XmpBasic.CreateDate = DateTime.Today;
		root.XmpPackage.Schemes.XmpBasic.BaseUrl = "https://groupdocs.com";
		root.XmpPackage.Schemes.XmpBasic.Rating = 5;
		root.XmpPackage.Schemes.BasicJobTicket = new XmpBasicJobTicketPackage();

		// Set a complex type property
		root.XmpPackage.Schemes.BasicJobTicket.Jobs = new[]
		{
			new XmpJob
			{
				ID = "1",
				Name = "test job",
				Url = "https://groupdocs.com"
			},
		};

		// ... 

		metadata.Save(Constants.OutputGif);
	}
}
```

## Adding a custom XMP package

The GroupDocs.Metadata API provides access to a number of commonly used XMP schemes. But it also allows you to create fully custom XMP packages containing user-defined properties. The example below demonstrates how to create and add a custom XMP package to a file.

**AdvancedUsage.WorkingWithMetadataStandards.<WBR>Xmp.AddCustomXmpPackage**

```csharp
using (Metadata metadata = new Metadata(Constants.InputJpeg))
{
	IXmp root = metadata.GetRootPackage() as IXmp;
	if (root != null)
	{
		var packet = new XmpPacketWrapper();
		
		var custom = new XmpPackage("gd", "https://groupdocs.com");
		custom.Set("gd:Copyright", "Copyright (C) 2011-2019 GroupDocs. All Rights Reserved.");
		custom.Set("gd:CreationDate", DateTime.Today);
		custom.Set("gd:Company", XmpArray.From(new [] { "Aspose", "GroupDocs" }, XmpArrayType.Ordered));
		packet.AddPackage(custom);

		root.XmpPackage = packet;

		metadata.Save(Constants.OutputJpeg);
	}
}
```

## Removing XMP metadata

To remove the XMP package from a file just assign null to the [IXmp.XmpPackage](https://apireference.groupdocs.com/net/metadata/groupdocs.metadata.standards.xmp/ixmp/properties/xmppackage) property. The code sample below shows how to remove XMP metadata from a file.

**AdvancedUsage.WorkingWithMetadataStandards.<WBR>Xmp.AddCustomXmpPackage**

```csharp
using (Metadata metadata = new Metadata(Constants.JpegWithXmp))
{
	IXmp root = metadata.GetRootPackage() as IXmp;
	if (root != null)
	{
		root.XmpPackage = null;

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