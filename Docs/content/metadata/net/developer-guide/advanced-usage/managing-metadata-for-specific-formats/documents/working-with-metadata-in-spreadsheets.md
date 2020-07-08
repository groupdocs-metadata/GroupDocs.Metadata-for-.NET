---
id: working-with-metadata-in-spreadsheets
url: metadata/net/working-with-metadata-in-spreadsheets
title: Working with metadata in Spreadsheets
weight: 2
description: ""
keywords: 
productName: GroupDocs.Metadata for .NET
hideChildren: False
---
GroupDocs.Metadata for .NET provides functionality that allows working with different kinds of spreadsheet formats such as XLS, XLSX, ODS, etc. For the full list of supported document formats please refer to [Supported Document Formats]({{< ref "metadata/net/getting-started/supported-document-formats.md" >}}).

## Detecting the exact type of a document

The following sample of code will help you to detect the exact type of a loaded spreadsheet and extract some additional file format information.

1.  [Load]({{< ref "metadata/net/developer-guide/advanced-usage/loading-files/_index.md" >}}) a Spreadsheet document
2.  Extract the root metadata package
3.  Use the [FileType](https://apireference.groupdocs.com/net/metadata/groupdocs.metadata.formats.document/spreadsheetrootpackage/properties/filetype) property to obtain file format information

**AdvancedUsage.ManagingMetadataForSpecificFormats.<WBR>Document.Spreadsheet.<WBR>SpreadsheetReadFileFormatProperties**

```csharp
using (Metadata metadata = new Metadata(Constants.InputXlsx))
{
	var root = metadata.GetRootPackage<SpreadsheetRootPackage>();

	Console.WriteLine(root.FileType.FileFormat);
	Console.WriteLine(root.FileType.SpreadsheetFormat);
	Console.WriteLine(root.FileType.MimeType);
	Console.WriteLine(root.FileType.Extension);
}
```

## Reading built-in metadata properties

To access built-in metadata of a spreadsheet, please use the [DocumentProperties](https://apireference.groupdocs.com/net/metadata/groupdocs.metadata.formats.document.documentrootpackage/1/properties/documentproperties) property defined in the [DocumentRootPackage](https://apireference.groupdocs.com/net/metadata/groupdocs.metadata.formats.document.documentrootpackage/1) class.

The following code snippet extracts built-in metadata properties and displays them on the screen.

**AdvancedUsage.ManagingMetadataForSpecificFormats.<WBR>Document.Spreadsheet.<WBR>SpreadsheetReadBuiltInProperties**

```csharp
using (Metadata metadata = new Metadata(Constants.InputXlsx))
{
	var root = metadata.GetRootPackage<SpreadsheetRootPackage>();

	Console.WriteLine(root.DocumentProperties.Author);
	Console.WriteLine(root.DocumentProperties.CreatedTime);
	Console.WriteLine(root.DocumentProperties.Company);
	Console.WriteLine(root.DocumentProperties.Category);
	Console.WriteLine(root.DocumentProperties.Keywords);
	Console.WriteLine(root.DocumentProperties.Language);
	Console.WriteLine(root.DocumentProperties.ContentType);

	// ... 
}
```

## Reading custom metadata properties

If you need to extract custom metadata properties of a spreadsheet please follow the code sample below.

**AdvancedUsage.ManagingMetadataForSpecificFormats.<WBR>Document.Spreadsheet.<WBR>SpreadsheetReadCustomProperties**

```csharp
using (Metadata metadata = new Metadata(Constants.InputXls))
{
	var root = metadata.GetRootPackage<SpreadsheetRootPackage>();

	var customProperties = root.DocumentProperties.FindProperties(p => !p.Tags.Contains(Tags.Document.BuiltIn));
	foreach (var property in customProperties)
	{
		Console.WriteLine("{0} = {1}", property.Name, property.Value);
	}

	// Extract only content type properties if required
	foreach (var contentTypeProperty in root.DocumentProperties.ContentTypeProperties.ToList())
	{
		Console.WriteLine("{0}, {1} = {2}", contentTypeProperty.SpreadsheetPropertyType, contentTypeProperty.Name, contentTypeProperty.SpreadsheetPropertyValue);
	}
}
```

As you can see the code sample uses the GroupDocs.Metadata search engine to retrieve all properties that are not marked with the BuiltIn tag. Since we call the [FindProperties](https://apireference.groupdocs.com/net/metadata/groupdocs.metadata.common/metadatapackage/methods/findproperties) method for a certain metadata package (instance of the [SpreadsheetPackage](https://apireference.groupdocs.com/net/metadata/groupdocs.metadata.formats.document/spreadsheetpackage) class), the search result will contain only metadata properties that are specific for spreadsheets. 

## Inspecting spreadsheets

The inspection feature that is introduced in this section doesn't work with metadata directly but extracts some useful pieces of information that can be considered as metadata under some circumstances. For example, you may want to obtain information about digital signatures associated with a spreadsheet, extract user comments from the spreadsheet content, obtain hidden sheets, etc. Please follow the example below to learn how to do that.

1.  [Load]({{< ref "metadata/net/developer-guide/advanced-usage/loading-files/_index.md" >}}) a Spreadsheet document
2.  Extract the root metadata package
3.  Use the [InspectionPackage](https://apireference.groupdocs.com/net/metadata/groupdocs.metadata.formats.document/spreadsheetrootpackage/properties/inspectionpackage) property to inspect the document

**AdvancedUsage.ManagingMetadataForSpecificFormats.<WBR>Document.Spreadsheet.<WBR>SpreadsheetReadInspectionProperties**

```csharp
using (Metadata metadata = new Metadata(Constants.InputXls))
{
	var root = metadata.GetRootPackage<SpreadsheetRootPackage>();
	if (root.InspectionPackage.Comments != null)
	{
		foreach (var comment in root.InspectionPackage.Comments)
		{
			Console.WriteLine(comment.Author);
			Console.WriteLine(comment.Text);
			Console.WriteLine(comment.SheetNumber);
			Console.WriteLine(comment.Row);
			Console.WriteLine(comment.Column);
		}
	}

	if (root.InspectionPackage.DigitalSignatures != null)
	{
		foreach (var signature in root.InspectionPackage.DigitalSignatures)
		{
			Console.WriteLine(signature.CertificateSubject);
			Console.WriteLine(signature.Comments);
			Console.WriteLine(signature.SignTime);

			// ...
		}
	}

	if (root.InspectionPackage.HiddenSheets != null)
	{
		foreach (var sheet in root.InspectionPackage.HiddenSheets)
		{
			Console.WriteLine(sheet.Name);
			Console.WriteLine(sheet.Number);
		}
	}
}
```

## Updating built-in metadata properties

Updating any built-in document properties is as simple as getting them. The following code sample demonstrates how to update built-in metadata properties in a spreadsheet.

**AdvancedUsage.ManagingMetadataForSpecificFormats.<WBR>Document.Spreadsheet.<WBR>SpreadsheetUpdateBuiltInProperties**

```csharp
using (Metadata metadata = new Metadata(Constants.InputXlsx))
{
	var root = metadata.GetRootPackage<SpreadsheetRootPackage>();

	root.DocumentProperties.Author = "test author";
	root.DocumentProperties.CreatedTime = DateTime.Now;
	root.DocumentProperties.Company = "GroupDocs";
	root.DocumentProperties.Category = "test category";
	root.DocumentProperties.Keywords = "metadata, built-in, update";

	// ... 

	metadata.Save(Constants.OutputXlsx);
}
```

## Adding or updating custom metadata properties

The GroupDocs.Metadata API also allows adding and updating custom metadata properties (including content type properties) in a spreadsheet. Please check the code sample below.

**AdvancedUsage.ManagingMetadataForSpecificFormats.<WBR>Document.Spreadsheet.<WBR>SpreadsheetUpdateCustomProperties**

```csharp
using (Metadata metadata = new Metadata(Constants.InputXls))
{
	var root = metadata.GetRootPackage<SpreadsheetRootPackage>();

	root.DocumentProperties.Set("customProperty1", "some value");
	root.DocumentProperties.Set("customProperty2", 7);

	// Set a content type property
	root.DocumentProperties.ContentTypeProperties.Set("customContentTypeProperty", "custom value");

	metadata.Save(Constants.OutputXls);
}
```

## Updating inspection properties

When you inspect a spreadsheet GroupDocs.Metadata for .NET forms a metadata package containing the extracted information. The package class also provides some basic methods that allow removing the extracted properties. The following code sample demonstrates how to remove the inspection properties in a spreadsheet.

**AdvancedUsage.ManagingMetadataForSpecificFormats.<WBR>Document.Spreadsheet.<WBR>SpreadsheetUpdateInspectionProperties**

```csharp
using (Metadata metadata = new Metadata(Constants.InputXlsx))
{
	var root = metadata.GetRootPackage<SpreadsheetRootPackage>();

	root.InspectionPackage.ClearComments();
	root.InspectionPackage.ClearDigitalSignatures();
	root.InspectionPackage.ClearHiddenSheets();

	metadata.Save(Constants.OutputXlsx);
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
