---
id: working-with-metadata-in-diagrams
url: metadata/net/working-with-metadata-in-diagrams
title: Working with metadata in Diagrams
weight: 4
description: ""
keywords: 
productName: GroupDocs.Metadata for .NET
hideChildren: False
---
GroupDocs.Metadata for .NET provides functionality that allows working with different kinds of diagrams such as VDX, VSDX, VSX, etc. For the full list of supported document formats please refer to [Supported Document Formats]({{< ref "metadata/net/getting-started/supported-document-formats.md" >}}).

## Detecting the exact type of a document

The following sample of code will help you to detect the exact type of a loaded diagram and extract some additional file format information.

1.  [Load]({{< ref "metadata/net/developer-guide/advanced-usage/loading-files/_index.md" >}}) a PDF document
2.  Extract the root metadata package
3.  Use the [FileType](https://apireference.groupdocs.com/net/metadata/groupdocs.metadata.formats.document/diagramrootpackage/properties/filetype) property to obtain file format information

**AdvancedUsage.ManagingMetadataForSpecificFormats.Document.Diagram.DiagramReadFileFormatProperties**

```csharp
using (Metadata metadata = new Metadata(Constants.InputVdx))
{
	var root = metadata.GetRootPackage<DiagramRootPackage>();

	Console.WriteLine(root.FileType.FileFormat);
	Console.WriteLine(root.FileType.DiagramFormat);
	Console.WriteLine(root.FileType.MimeType);
	Console.WriteLine(root.FileType.Extension);
}
```

## Reading built-In metadata properties

To access built-in metadata of a diagram, please use the [DocumentProperties](https://apireference.groupdocs.com/net/metadata/groupdocs.metadata.formats.document.documentrootpackage/1/properties/documentproperties) property defined in the [DocumentRootPackage](https://apireference.groupdocs.com/net/metadata/groupdocs.metadata.formats.document.documentrootpackage/1) class.

The following code snippet extracts built-in metadata properties and displays them on the screen.

**AdvancedUsage.ManagingMetadataForSpecificFormats.Document.Diagram.DiagramReadBuiltInProperties**

```csharp
using (Metadata metadata = new Metadata(Constants.InputVsdx))
{
	var root = metadata.GetRootPackage<DiagramRootPackage>();

	Console.WriteLine(root.DocumentProperties.Creator);
	Console.WriteLine(root.DocumentProperties.Company);
	Console.WriteLine(root.DocumentProperties.Keywords);
	Console.WriteLine(root.DocumentProperties.Language);
	Console.WriteLine(root.DocumentProperties.TimeCreated);
	Console.WriteLine(root.DocumentProperties.Category);

	// ... 
}
```

## Reading custom metadata properties

If you need to extract custom metadata properties of a diagram please follow the code sample below.

**AdvancedUsage.ManagingMetadataForSpecificFormats.Document.Diagram.DiagramReadCustomProperties**

```csharp
using (Metadata metadata = new Metadata(Constants.InputVsdx))
{
	var root = metadata.GetRootPackage<DiagramRootPackage>();

	var customProperties = root.DocumentProperties.FindProperties(p => !p.Tags.Contains(Tags.Document.BuiltIn));
	foreach (var property in customProperties)
	{
		Console.WriteLine("{0} = {1}", property.Name, property.Value);
	}
}
```

As you can see the code sample uses the GroupDocs.Metadata search engine to retrieve all properties that are not marked with the BuiltIn tag. Since we call the [FindProperties](https://apireference.groupdocs.com/net/metadata/groupdocs.metadata.common/metadatapackage/methods/findproperties) method for a certain metadata package (instance of the [DiagramPackage](https://apireference.groupdocs.com/net/metadata/groupdocs.metadata.formats.document/diagrampackage) class), the search result will contain only metadata properties that are specific for diagram documents. 

## Reading document statistics

Most office applications are able to display simple text statistics for loaded documents. It can be an estimated word count, page count, character count, etc. The GroupDocs.Metadata API provides similar functionality for some document formats. The following code sample demonstrates how to obtain the text statistics for a diagram (only the page count statistic is available at the moment).

**AdvancedUsage.ManagingMetadataForSpecificFormats.Document.Diagram.DiagramReadDocumentStatistics**

```csharp
using (Metadata metadata = new Metadata(Constants.InputVdx))
{
	var root = metadata.GetRootPackage<DiagramRootPackage>();
	
	Console.WriteLine(root.DocumentStatistics.PageCount);
}
```

## Updating built-In metadata properties

Updating any built-in document properties is as simple as getting them. The following code sample demonstrates how to update built-in metadata properties in a diagram document.

**AdvancedUsage.ManagingMetadataForSpecificFormats.Document.Diagram.DiagramUpdateBuiltInProperties**

```csharp
using (Metadata metadata = new Metadata(Constants.InputVdx))
{
	var root = metadata.GetRootPackage<DiagramRootPackage>();

	root.DocumentProperties.Creator = "test author";
	root.DocumentProperties.TimeCreated = DateTime.Now;
	root.DocumentProperties.Company = "GroupDocs";
	root.DocumentProperties.Category = "test category";
	root.DocumentProperties.Keywords = "metadata, built-in, update";

	// ... 

	metadata.Save(Constants.OutputVdx);
}
```

## Adding or updating custom metadata properties

The GroupDocs.Metadata API also allows adding and updating custom metadata properties in a diagram document. Please check the code sample below.

**AdvancedUsage.ManagingMetadataForSpecificFormats.Document.Diagram.DiagramUpdateCustomProperties**

```csharp
using (Metadata metadata = new Metadata(Constants.InputVsdx))
{
	var root = metadata.GetRootPackage<DiagramRootPackage>();

	root.DocumentProperties.Set("customProperty1", "some value");
	root.DocumentProperties.Set("customProperty2", true);

	metadata.Save(Constants.OutputVsdx);
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