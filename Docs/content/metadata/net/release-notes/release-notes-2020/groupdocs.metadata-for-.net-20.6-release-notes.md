---
id: groupdocs-metadata-for-net-20-6-release-notes
url: metadata/net/groupdocs-metadata-for-net-20-6-release-notes
title: GroupDocs.Metadata for .NET 20.6 Release Notes
weight: 1
description: ""
keywords: 
productName: GroupDocs.Metadata for .NET
hideChildren: False
---
{{< alert style="info" >}}This page contains release notes for GroupDocs.Metadata for .NET 20.6{{< /alert >}}

## Major Features
  
There are the following features, enhancements and fixes in this release:

*   Implement the ability to add, update and remove IPTC metadata in TIFF images
*   Implement the ability to export metadata properties to an xls/xlsx worksheet
*   Exception: Could not read MPP format

## Full List of Issues Covering all Changes in this Release

| Key | Summary | Category |
| --- | --- | --- |
| METADATANET-2495 | Implement the ability to add, update and remove IPTC metadata in TIFF images | New Feature |
| METADATANET-3332 | Implement the ability to export metadata properties to an xls/xlsx worksheet | Improvement |
| METADATANET-3338 | Exception: Could not read MPP format | Bug |

## Public API and Backward Incompatible Changes

{{< alert style="info" >}}This section lists public API changes that were introduced in GroupDocs.Metadata for .NET 20.6. It includes not only new and obsoleted public methods, but also a description of any changes in the behavior behind the scenes in GroupDocs.Metadata which may affect existing code. Any behavior introduced that could be seen as a regression and modifies existing behavior is especially important and is documented here.{{< /alert >}}

### Implement the ability to add, update and remove IPTC metadata in TIFF images

This new feature allows the user to add, update and remove IPTC metadata packages in TIFF images.

##### Public API changes

The [TiffRootPackage](https://apireference.groupdocs.com/metadata/net/groupdocs.metadata.formats.image/tiffrootpackage) class now implements the [IIptc](https://apireference.groupdocs.com/metadata/net/groupdocs.metadata.standards.iptc/iiptc) interface

The setter has bee added to the [TiffRootPackage.IptcPackage](https://apireference.groupdocs.com/metadata/net/groupdocs.metadata.formats.image/tiffrootpackage/properties/iptcpackage) property

##### Use cases

Add or update IPTC metadata in a TIFF image



```csharp
using (Metadata metadata = new Metadata(@"D:\input.tif"))
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

		metadata.Save(@"d:\output.tif");
	}
} 
```

### Implement the ability to export metadata properties to an xls/xlsx worksheet

This improvement allows the user to export an arbitrary set of metadata properties to an Excel workbook.

##### Public API changes

The [GroupDocs.Metadata.Export](https://apireference.groupdocs.com/metadata/net/groupdocs.metadata.export) namespace has been introduced

The [ExportFormat](https://apireference.groupdocs.com/metadata/net/groupdocs.metadata.export/exportformat) enum has been added to the [GroupDocs.Metadata.Export](https://apireference.groupdocs.com/metadata/net/groupdocs.metadata.export) namespace

The [ExportManager](https://apireference.groupdocs.com/metadata/net/groupdocs.metadata.export/exportmanager) class has been added to the [GroupDocs.Metadata.Export](https://apireference.groupdocs.com/metadata/net/groupdocs.metadata.export) namespace

##### Use cases

Export the whole metadata tree to an Excel workbook



```csharp
using (Metadata metadata = new Metadata(@"D:\input.doc"))
{
	RootMetadataPackage root = metadata.GetRootPackage();
	if (root != null)
	{
		// Initialize the export manager with the root metadata package to export the whole metadata tree
		ExportManager manager = new ExportManager(root);
		manager.Export(@"D:\export.xls", ExportFormat.Xls);
	}
} 
```

###
