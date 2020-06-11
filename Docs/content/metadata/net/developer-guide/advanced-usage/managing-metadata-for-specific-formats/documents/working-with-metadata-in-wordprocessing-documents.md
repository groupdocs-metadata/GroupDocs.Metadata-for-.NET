---
id: working-with-metadata-in-wordprocessing-documents
url: metadata/net/working-with-metadata-in-wordprocessing-documents
title: Working with metadata in WordProcessing documents
weight: 1
description: ""
keywords: 
productName: GroupDocs.Metadata for .NET
hideChildren: False
---
GroupDocs.Metadata for .NET provides functionality that allows working with different kinds of WordProcessing documents such as DOC, DOCX, ODT, etc. For the full list of supported document formats please refer to [Supported Document Formats]({{< ref "metadata/net/getting-started/supported-document-formats.md" >}}).

## Detecting the exact type of a document

The following sample of code will help you to detect the exact type of a loaded document and extract some additional file format information.

1.  [Load]({{< ref "metadata/net/developer-guide/advanced-usage/loading-files/_index.md" >}}) a WordProcessing document
2.  Extract the root metadata package
3.  Use the [FileType](https://apireference.groupdocs.com/net/metadata/groupdocs.metadata.formats.document/wordprocessingrootpackage/properties/filetype) property to obtain file format information

**AdvancedUsage.ManagingMetadataForSpecificFormats.Document.WordProcessing.WordProcessingReadFileFormatProperties**

```csharp
using (Metadata metadata = new Metadata(Constants.InputDoc))
{
	var root = metadata.GetRootPackage<WordProcessingRootPackage>();

	Console.WriteLine(root.FileType.FileFormat);
	Console.WriteLine(root.FileType.WordProcessingFormat);
	Console.WriteLine(root.FileType.MimeType);
	Console.WriteLine(root.FileType.Extension);
}
```

## Reading built-in metadata properties

To access built-in metadata of a WordProcessing document, please use the [DocumentProperties](https://apireference.groupdocs.com/net/metadata/groupdocs.metadata.formats.document.documentrootpackage/1/properties/documentproperties) property defined in the [DocumentRootPackage](https://apireference.groupdocs.com/net/metadata/groupdocs.metadata.formats.document.documentrootpackage/1) class.

The following code snippet extracts built-in metadata properties and displays them on the screen.

**AdvancedUsage.ManagingMetadataForSpecificFormats.Document.WordProcessing.WordProcessingReadBuiltInProperties**

```csharp
using (Metadata metadata = new Metadata(Constants.InputDocx))
{
	var root = metadata.GetRootPackage<WordProcessingRootPackage>();

	Console.WriteLine(root.DocumentProperties.Author);
	Console.WriteLine(root.DocumentProperties.CreatedTime);
	Console.WriteLine(root.DocumentProperties.Company);
	Console.WriteLine(root.DocumentProperties.Category);
	Console.WriteLine(root.DocumentProperties.Keywords);

	// ... 
}
```

## Reading custom metadata properties

If you need to extract custom metadata properties of a WordProcessing document please follow the code sample below.

**AdvancedUsage.ManagingMetadataForSpecificFormats.Document.WordProcessing.WordProcessingReadCustomProperties**

```csharp
using (Metadata metadata = new Metadata(Constants.InputDoc))
{
	var root = metadata.GetRootPackage<WordProcessingRootPackage>();
	var customProperties = root.DocumentProperties.FindProperties(p => !p.Tags.Contains(Tags.Document.BuiltIn));

	foreach (var property in customProperties)
	{
		Console.WriteLine("{0} = {1}", property.Name, property.Value);
	}
}
```

As you can see the code sample uses the GroupDocs.Metadata search engine to retrieve all properties that are not marked with the BuiltIn tag. Since we call the [FindProperties](https://apireference.groupdocs.com/net/metadata/groupdocs.metadata.common/metadatapackage/methods/findproperties) method for a certain metadata package (instance of the [WordProcessingPackage](https://apireference.groupdocs.com/net/metadata/groupdocs.metadata.formats.document/wordprocessingpackage) class), the search result will contain only metadata properties that are specific for WordProcessing documents. 

## Inspecting WordProcessing documents

The inspection feature that is introduced in this section doesn't work with metadata directly but extracts some useful pieces of information that can be considered as metadata under some circumstances. For example, you may want to obtain information about digital signatures associated with a document, extract user comments from the document content, obtain pieces of hidden text, work with document revisions, etc. Please follow the example below to learn how to do that.

1.  [Load]({{< ref "metadata/net/developer-guide/advanced-usage/loading-files/_index.md" >}}) a WordProcessing document
2.  Extract the root metadata package
3.  Use the [InspectionPackage](https://apireference.groupdocs.com/net/metadata/groupdocs.metadata.formats.document/wordprocessingrootpackage/properties/inspectionpackage) property to inspect the document

**AdvancedUsage.ManagingMetadataForSpecificFormats.Document.WordProcessing.WordProcessingReadInspectionProperties**

```csharp
using (Metadata metadata = new Metadata(Constants.InputDocx))
{
	var root = metadata.GetRootPackage<WordProcessingRootPackage>();
	if (root.InspectionPackage.Comments != null)
	{
		foreach (var comment in root.InspectionPackage.Comments)
		{
			Console.WriteLine(comment.Author);
			Console.WriteLine(comment.CreatedDate);
			Console.WriteLine(comment.Text);
			// ... 
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

	if (root.InspectionPackage.Fields != null)
	{
		foreach (var field in root.InspectionPackage.Fields)
		{
			Console.WriteLine(field.Code);
			Console.WriteLine(field.Result);
		}
	}

	if (root.InspectionPackage.HiddenText != null)
	{
		foreach (var textFragment in root.InspectionPackage.HiddenText)
		{
			Console.WriteLine(textFragment);
		}
	}

	if (root.InspectionPackage.Revisions != null)
	{
		foreach (var revision in root.InspectionPackage.Revisions)
		{
			Console.WriteLine(revision.Author);
			Console.WriteLine(revision.DateTime);
			Console.WriteLine(revision.RevisionType);
		}
	}
}
```

## Reading document statistics

Most office applications are able to display simple text statistics for loaded documents. It can be an estimated word count, page count, character count, etc. The GroupDocs.Metadata API provides similar functionality for some document formats. The following code sample demonstrates how to obtain the text statistics for a WordProcessing document.

**AdvancedUsage.ManagingMetadataForSpecificFormats.Document.WordProcessing.WordProcessingReadDocumentStatistics**

```csharp
using (Metadata metadata = new Metadata(Constants.InputDocx))
{
	var root = metadata.GetRootPackage<WordProcessingRootPackage>();

	Console.WriteLine(root.DocumentStatistics.CharacterCount);
	Console.WriteLine(root.DocumentStatistics.PageCount);
	Console.WriteLine(root.DocumentStatistics.WordCount);
}
```

## Reading dublin core metadata

Dublin Core metadata is a set of certain metadata properties that are intended to describe various digital resources. Please find more information on the Dublin Core standard at [https://en.wikipedia.org/wiki/Dublin\_Core](https://en.wikipedia.org/wiki/Dublin_Core). The code sample below shows how to extract Dublin Core metadata from a WordProcessing document using the GroupDocs.Metadata API.

**AdvancedUsage.ManagingMetadataForSpecificFormats.Document.WordProcessing.WordProcessingReadDublinCoreProperties**

```csharp
using (Metadata metadata = new Metadata(Constants.InputDocx))
{
	var root = metadata.GetRootPackage<WordProcessingRootPackage>();

	if (root.DublinCorePackage != null)
	{
		Console.WriteLine(root.DublinCorePackage.Format);
		Console.WriteLine(root.DublinCorePackage.Contributor);
		Console.WriteLine(root.DublinCorePackage.Coverage);
		Console.WriteLine(root.DublinCorePackage.Creator);
		Console.WriteLine(root.DublinCorePackage.Source);
		Console.WriteLine(root.DublinCorePackage.Description);

		// ...
	}
}
```

Please see the the [DublinCorePackage](https://apireference.groupdocs.com/net/metadata/groupdocs.metadata.standards.dublincore/dublincorepackage) class to get more information on supported Dublin Core metadata properties.

## Updating built-in metadata properties

Updating any built-in document properties is as simple as getting them. The following code sample demonstrates how to update built-in metadata properties in a WordProcessing document.

**AdvancedUsage.ManagingMetadataForSpecificFormats.Document.WordProcessing.WordProcessingUpdateBuiltInProperties**

```csharp
using (Metadata metadata = new Metadata(Constants.InputDoc))
{
	var root = metadata.GetRootPackage<WordProcessingRootPackage>();

	root.DocumentProperties.Author = "test author";
	root.DocumentProperties.CreatedTime = DateTime.Now;
	root.DocumentProperties.Company = "GroupDocs";
	root.DocumentProperties.Category = "test category";
	root.DocumentProperties.Keywords = "metadata, built-in, update";

	// ... 

	metadata.Save(Constants.OutputDoc);
}
```

## Adding or updating custom metadata properties

The GroupDocs.Metadata API also allows adding and updating custom metadata properties in a WordProcessing document. Please check the code sample below.

**AdvancedUsage.ManagingMetadataForSpecificFormats.Document.WordProcessing.WordProcessingUpdateCustomProperties**

```csharp
using (Metadata metadata = new Metadata(Constants.InputDocx))
{
	var root = metadata.GetRootPackage<WordProcessingRootPackage>();

	root.DocumentProperties.Set("customProperty1", "some value");
	root.DocumentProperties.Set("customProperty2", 7);

	metadata.Save(Constants.OutputDocx);
}
```

## Updating inspection properties

When you inspect a document GroupDocs.Metadata for .NET forms a metadata package containing the extracted information. The package class also provides some basic methods that allow updating (or removing) the extracted properties. The following code sample demonstrates how to remove/update the inspection properties in a WordProcessing document.

**AdvancedUsage.ManagingMetadataForSpecificFormats.Document.WordProcessing.WordProcessingUpdateInspectionProperties**

```csharp
using (Metadata metadata = new Metadata(Constants.InputDoc))
{
	var root = metadata.GetRootPackage<WordProcessingRootPackage>();

	root.InspectionPackage.ClearComments();
	root.InspectionPackage.AcceptAllRevisions();
	root.InspectionPackage.ClearFields();
	root.InspectionPackage.ClearHiddenText();

	metadata.Save(Constants.OutputDoc);
}
```

## Updating document statistics

The document statistics described in [this section]({{< ref "metadata/net/developer-guide/advanced-usage/managing-metadata-for-specific-formats/documents/working-with-metadata-in-wordprocessing-documents.md" >}}) are not only calculated for WordProcessing documents, they can also be saved in the native metadata package with regular metadata properties. The following code sample demonstrates how to achieve this.

**AdvancedUsage.ManagingMetadataForSpecificFormats.Document.WordProcessing.WordProcessingUpdateDocumentStatistics**

```csharp
using (Metadata metadata = new Metadata(Constants.InputDoc))
{
	var root = metadata.GetRootPackage<WordProcessingRootPackage>();

	root.UpdateDocumentStatistics();

	metadata.Save(Constants.OutputDoc);
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
