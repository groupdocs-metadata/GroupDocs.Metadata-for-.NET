---
id: working-with-iptc-iim-metadata
url: metadata/net/working-with-iptc-iim-metadata
title: Working with IPTC IIM metadata
weight: 2
description: ""
keywords: 
productName: GroupDocs.Metadata for .NET
hideChildren: False
---
## What is IPTC IIM?

The IPTC Information Interchange Model (IIM) is a set of metadata properties that can be applied to text, images, and other media types. The standard also defines a complex data structure that is utilized to store the properties. The IPTC IIM was developed by the International Press Telecommunications Council (IPTC) to expedite the international exchange of news among newspapers and news agencies. But nowadays it's commonly used by amateur and commercial photographers. The standard is supported by many image creation and manipulation programs. IPTC IIM metadata can be embedded into a variety of image formats such as JPEG, TIFF, etc.

{{< alert style="info" >}}For more information on the IPTC IIM standard please refer to https://www.iptc.org/std/IIM/4.2/specification/IIMV4.2.pdf.{{< /alert >}}

## Reading basic IPTC IIM properties

To access IPTC metadata in a file of any supported format, GroupDocs.Metadata provides the [IIptc.IptcPackage](https://apireference.groupdocs.com/net/metadata/groupdocs.metadata.standards.iptc/iiptc/properties/iptcpackage) property. The following are the steps to read IPTC metadata:

1.  [Load]({{< ref "metadata/net/developer-guide/advanced-usage/loading-files/_index.md" >}}) a file that contains IPTC metadata
2.  Extract the IPTC metadata package using the [IIptc.IptcPackage](https://apireference.groupdocs.com/net/metadata/groupdocs.metadata.standards.iptc/iiptc/properties/iptcpackage) property
3.  Read properties of the [IptcApplicationRecord](https://apireference.groupdocs.com/net/metadata/groupdocs.metadata.standards.iptc/iptcapplicationrecord) and [IptcEnvelopeRecord](https://apireference.groupdocs.com/net/metadata/groupdocs.metadata.standards.iptc/iptcenveloperecord) class instances

The following code snippet gets IPTC properties of a JPEG image and displays them on the screen. 

**AdvancedUsage.WorkingWithMetadataStandards.<WBR>Iptc.ReadBasicIptcProperties**

```csharp
using (Metadata metadata = new Metadata(Constants.JpegWithIptc))
{
	IIptc root = metadata.GetRootPackage() as IIptc;
	if (root != null && root.IptcPackage != null)
	{
		if (root.IptcPackage.EnvelopeRecord != null)
		{
			Console.WriteLine(root.IptcPackage.EnvelopeRecord.DateSent);
			Console.WriteLine(root.IptcPackage.EnvelopeRecord.Destination);
			Console.WriteLine(root.IptcPackage.EnvelopeRecord.FileFormat);
			Console.WriteLine(root.IptcPackage.EnvelopeRecord.FileFormatVersion);

			// ...
		}

		if (root.IptcPackage.ApplicationRecord != null)
		{
			Console.WriteLine(root.IptcPackage.ApplicationRecord.Headline);
			Console.WriteLine(root.IptcPackage.ApplicationRecord.ByLine);
			Console.WriteLine(root.IptcPackage.ApplicationRecord.ByLineTitle);
			Console.WriteLine(root.IptcPackage.ApplicationRecord.CaptionAbstract);
			Console.WriteLine(root.IptcPackage.ApplicationRecord.City);
			Console.WriteLine(root.IptcPackage.ApplicationRecord.DateCreated);
			Console.WriteLine(root.IptcPackage.ApplicationRecord.ReleaseDate);

			// ...
		}
	}
}
```

## Reading all IPTC IIM datasets

In some cases, it's necessary to read all IPTC datasets (metadata properties) from a file, including custom ones. To achieve this the GroupDocs.Metadata API provides direct access to the IPTC datasets extracted from a file.

1.  [Load]({{< ref "metadata/net/developer-guide/advanced-usage/loading-files/_index.md" >}}) a file that contains IPTC metadata
2.  Extract the IPTC metadata package using the [IIptc.IptcPackage](https://apireference.groupdocs.com/net/metadata/groupdocs.metadata.standards.iptc/iiptc/properties/iptcpackage) property
3.  Iterate through all IPTC datasets

**AdvancedUsage.WorkingWithMetadataStandards.<WBR>Iptc.ReadIptcDataSets**

```csharp
using (Metadata metadata = new Metadata(Constants.PsdWithIptc))
{
	IIptc root = metadata.GetRootPackage() as IIptc;
	if (root != null && root.IptcPackage != null)
	{
		foreach (var dataSet in root.IptcPackage.ToDataSetList())
		{
			Console.WriteLine(dataSet.RecordNumber);
			Console.WriteLine(dataSet.DataSetNumber);
			Console.WriteLine(dataSet.AlternativeName);
			Console.WriteLine(dataSet.Value);
		}
	}
}
```

## Updating IPTC IIM properties

The GroupDocs.Metadata API facilitates the user to update IPTC metadata in a convenient way - using the [IptcRecordSet](https://apireference.groupdocs.com/net/metadata/groupdocs.metadata.standards.iptc/iptcrecordset) class properties. Follow the below steps to update IPTC metadata in a file of any supported format.

1.  [Load]({{< ref "metadata/net/developer-guide/advanced-usage/loading-files/_index.md" >}}) a file that contains IPTC metadata
2.  Extract the IPTC metadata package using the [IIptc.IptcPackage](https://apireference.groupdocs.com/net/metadata/groupdocs.metadata.standards.iptc/iiptc/properties/iptcpackage) property
3.  Assign values to desired IPTC properties
4.  [Save]({{< ref "metadata/net/developer-guide/advanced-usage/saving-files/_index.md" >}}) the changes

**AdvancedUsage.WorkingWithMetadataStandards.<WBR>Iptc.UpdateIptcProperties**

```csharp
using (Metadata metadata = new Metadata(Constants.InputJpeg))
{
	IIptc root = metadata.GetRootPackage() as IIptc;
	if (root != null)
	{
		// Set the IPTC package if it's missing
		if (root.IptcPackage == null)
		{
			root.IptcPackage = new IptcRecordSet();
		}

		if (root.IptcPackage.EnvelopeRecord == null)
		{
			root.IptcPackage.EnvelopeRecord = new IptcEnvelopeRecord();
		}
		root.IptcPackage.EnvelopeRecord.DateSent = DateTime.Now;
		root.IptcPackage.EnvelopeRecord.ProductID = Guid.NewGuid().ToString();

		// ...

		if (root.IptcPackage.ApplicationRecord == null)
		{
			root.IptcPackage.ApplicationRecord = new IptcApplicationRecord();
		}
		root.IptcPackage.ApplicationRecord.ByLine = "GroupDocs";
		root.IptcPackage.ApplicationRecord.Headline = "test";
		root.IptcPackage.ApplicationRecord.ByLineTitle = "code sample";
		root.IptcPackage.ApplicationRecord.ReleaseDate = DateTime.Today;

		// ...

		metadata.Save(Constants.OutputJpeg);
	}
}
```

## Adding or updating custom IPTC IIM datasets

The GroupDocs.Metadata API allows adding or updating custom datasets in an IPTC package.

1.  [Load]({{< ref "metadata/net/developer-guide/advanced-usage/loading-files/_index.md" >}}) a file that contains IPTC metadata
2.  Extract the IPTC metadata package using the [IIptc.IptcPackage](https://apireference.groupdocs.com/net/metadata/groupdocs.metadata.standards.iptc/iiptc/properties/iptcpackage) property
3.  Set the IPTC package if it's missing
4.  Add any number of custom datasets to the package (Please see the [IptcDataSet](https://apireference.groupdocs.com/net/metadata/groupdocs.metadata.standards.iptc/iptcdataset) class for more information)
5.  [Save]({{< ref "metadata/net/developer-guide/advanced-usage/saving-files/_index.md" >}}) the changes

**AdvancedUsage.WorkingWithMetadataStandards.<WBR>Iptc.SetCustomIptcDataSet**

```csharp
using (Metadata metadata = new Metadata(Constants.PsdWithIptc))
{
	IIptc root = metadata.GetRootPackage() as IIptc;
	if (root != null)
	{
		// Set the IPTC package if it's missing
		if (root.IptcPackage == null)
		{
			root.IptcPackage = new IptcRecordSet();
		}

		// Add a know property using the DataSet API
		root.IptcPackage.Set(new IptcDataSet((byte)IptcRecordType.ApplicationRecord, (byte)IptcApplicationRecordDataSet.BylineTitle, "test code sample"));

		// Add a custom IPTC DataSet
		root.IptcPackage.Set(new IptcDataSet(255, 255, new byte[] { 1, 2, 3 }));

		metadata.Save(Constants.OutputPsd);
	}
}
```

## Removing IPTC IIM metadata

To remove the IPTC package from a file just assign null to the [IIptc.IptcPackage](https://apireference.groupdocs.com/net/metadata/groupdocs.metadata.standards.iptc/iiptc/properties/iptcpackage) property. The code sample below shows how to remove IPTC metadata from a file.

**AdvancedUsage.WorkingWithMetadataStandards.<WBR>Iptc.RemoveIptcMetadata**

```csharp
using (Metadata metadata = new Metadata(Constants.JpegWithIptc))
{
	IIptc root = metadata.GetRootPackage() as IIptc;
	if (root != null)
	{
		root.IptcPackage = null;
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