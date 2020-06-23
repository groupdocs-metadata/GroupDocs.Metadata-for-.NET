---
id: working-with-vcard-metadata
url: metadata/net/working-with-vcard-metadata
title: Working with vCard metadata
weight: 3
description: ""
keywords: 
productName: GroupDocs.Metadata for .NET
hideChildren: False
---
## What is vCard?

vCard, also known as VCF (Virtual Contact File), is a file format standard for electronic business cards. vCards are often attached to e-mail messages, but can be exchanged in other ways. They can contain name and address information, telephone numbers, e-mail addresses, URLs, logos, photographs, and even audio clips.

{{< alert style="info" >}}For more information on the format please see https://en.wikipedia.org/wiki/VCard{{< /alert >}}

## Getting Simple vCard metadata

To access Metadata in a vCard, GroupDocs.Metadata API provides the [VCardRootPackage.VCardPackage](https://apireference.groupdocs.com/net/metadata/groupdocs.metadata.formats.businesscard/vcardrootpackage/properties/vcardpackage)property which contains the information extracted from a file. The following are the steps to access metadata in a vCard:

1.  [Load]({{< ref "metadata/net/developer-guide/advanced-usage/loading-files/_index.md" >}}) a vCard file
2.  Get the root metadata package
3.  Extract  the native metadata package using [VCardRootPackage.VCardPackage](https://apireference.groupdocs.com/net/metadata/groupdocs.metadata.formats.businesscard/vcardrootpackage/properties/vcardpackage)
4.  Read the extracted vCard properties

The following code snippet gets metadata of a vCard file.

**AdvancedUsage.ManagingMetadataForSpecificFormats.BusinessCard.VCardReadCardProperties**

```csharp
public static void Run()
{
	using (Metadata metadata = new Metadata(Constants.InputVcf))
	{
		var root = metadata.GetRootPackage<VCardRootPackage>();

		foreach (var vCard in root.VCardPackage.Cards)
		{
			Console.WriteLine(vCard.IdentificationRecordset.Name);
			PrintArray(vCard.IdentificationRecordset.FormattedNames);
			PrintArray(vCard.CommunicationRecordset.Emails);
			PrintArray(vCard.CommunicationRecordset.Telephones);
			PrintArray(vCard.DeliveryAddressingRecordset.Addresses);

			// ...
		}
	}
}

private static void PrintArray(string[] values)
{
	if (values != null)
	{
		foreach (string value in values)
		{
			Console.WriteLine(value);
		}
	}
}
```

## Getting Metadata with descriptive parameters

The GroupDocs.Metadata API also provides a way to get Metadata from vCards with descriptive parameters.The steps are given below:

1.  [Load]({{< ref "metadata/net/developer-guide/advanced-usage/loading-files/_index.md" >}}) a vCard file
2.  Get the root metadata package
3.  Extract  the native metadata package using [VCardRootPackage.VCardPackage](https://apireference.groupdocs.com/net/metadata/groupdocs.metadata.formats.businesscard/vcardrootpackage/properties/vcardpackage)
4.  Use properties with the Record(s) postfix to get vCard fields along with descriptive parameters

The following code snippet shows how to extract vCard fields along with descriptive parameters.

**AdvancedUsage.ManagingMetadataForSpecificFormats.BusinessCard.VCardReadCardPropertiesWithParameters**

```csharp
using (Metadata metadata = new Metadata(Constants.InputVcf))
{
	var root = metadata.GetRootPackage<VCardRootPackage>();
	foreach (var vCard in root.VCardPackage.Cards)
	{
		if (vCard.IdentificationRecordset.PhotoUriRecords != null)
		{
			// Iterate all photos represented by URIs
			foreach (var photoUriRecord in vCard.IdentificationRecordset.PhotoUriRecords)
			{
				// Print the property value
				Console.WriteLine(photoUriRecord.Value);

				// Print some additional parameters of the property
				Console.WriteLine(photoUriRecord.ContentType);

				Console.WriteLine(photoUriRecord.MediaTypeParameter);
				if (photoUriRecord.TypeParameters != null)
				{
					foreach (string parameter in photoUriRecord.TypeParameters)
					{
						Console.WriteLine(parameter);
					}
				}

				Console.WriteLine(photoUriRecord.PrefParameter);
			}
		}
	}
}
```

## Filtering vCard properties

The GroupDocs.Metadata API provides the ability to filter vCard properties in order to make finding desired information easier. The code sample below demonstrates hot to use the filtering feature.

**AdvancedUsage.ManagingMetadataForSpecificFormats.BusinessCard.VCardFilterCardProperties**

```csharp
public static void Run()
{
	using (Metadata metadata = new Metadata(Constants.InputVcf))
	{
		var root = metadata.GetRootPackage<VCardRootPackage>();
		foreach (var vCard in root.VCardPackage.Cards)
		{
			// Print most preferred work phone numbers and work emails
			var filtered = vCard.FilterWorkTags().FilterPreferred();

			PrintArray(filtered.CommunicationRecordset.Telephones);
			PrintArray(filtered.CommunicationRecordset.Emails);
		}
	}
}

private static void PrintArray(string[] values)
{
	if (values != null)
	{
		foreach (string value in values)
		{
			Console.WriteLine(value);
		}
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