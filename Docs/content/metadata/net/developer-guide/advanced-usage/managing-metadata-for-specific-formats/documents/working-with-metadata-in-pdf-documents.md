---
id: working-with-metadata-in-pdf-documents
url: metadata/net/working-with-metadata-in-pdf-documents
title: Working with metadata in PDF documents
weight: 5
description: ""
keywords: 
productName: GroupDocs.Metadata for .NET
hideChildren: False
---
## Detecting the version of a PDF document

The following sample of code will help you to detect the PDF version a loaded document and extract some additional file format information.

1.  [Load]({{< ref "metadata/net/developer-guide/advanced-usage/loading-files/_index.md" >}}) a PDF document
2.  Extract the root metadata package
3.  Use the [FileType](https://apireference.groupdocs.com/net/metadata/groupdocs.metadata.formats.document/pdfrootpackage/properties/filetype) property to obtain file format information

**AdvancedUsage.ManagingMetadataForSpecificFormats.Document.Pdf.PdfReadFileFormatProperties**

```csharp
using (Metadata metadata = new Metadata(Constants.InputPdf))
{
	var root = metadata.GetRootPackage<PdfRootPackage>();

	Console.WriteLine(root.FileType.FileFormat);
	Console.WriteLine(root.FileType.Version);
	Console.WriteLine(root.FileType.MimeType);
	Console.WriteLine(root.FileType.Extension);
}
```

## Reading built-in metadata properties

To access built-in metadata of a PDF document, please use the [DocumentProperties](https://apireference.groupdocs.com/net/metadata/groupdocs.metadata.formats.document.documentrootpackage/1/properties/documentproperties) property defined in the [DocumentRootPackage](https://apireference.groupdocs.com/net/metadata/groupdocs.metadata.formats.document.documentrootpackage/1) class.

The following code snippet extracts built-in metadata properties and displays them on the screen.

**AdvancedUsage.ManagingMetadataForSpecificFormats.Document.Pdf.PdfReadBuiltInProperties**

```csharp
using (Metadata metadata = new Metadata(Constants.InputPdf))
{
	var root = metadata.GetRootPackage<PdfRootPackage>();

	Console.WriteLine(root.DocumentProperties.Author);
	Console.WriteLine(root.DocumentProperties.CreatedDate);
	Console.WriteLine(root.DocumentProperties.Subject);
	Console.WriteLine(root.DocumentProperties.Producer);
	Console.WriteLine(root.DocumentProperties.Keywords);

	// ... 
}
```

## Reading custom metadata properties

If you need to extract custom metadata properties of a PDF document please follow the code sample below.

**AdvancedUsage.ManagingMetadataForSpecificFormats.Document.Pdf.PdfReadCustomProperties**

```csharp
using (Metadata metadata = new Metadata(Constants.InputPdf))
{
	var root = metadata.GetRootPackage<PdfRootPackage>();

	var customProperties = root.DocumentProperties.FindProperties(p => !p.Tags.Contains(Tags.Document.BuiltIn));
	foreach (var property in customProperties)
	{
		Console.WriteLine("{0} = {1}", property.Name, property.Value);
	}
}
```

As you can see the code sample uses the GroupDocs.Metadata search engine to retrieve all properties that are not marked with the BuiltIn tag. Since we call the [FindProperties](https://apireference.groupdocs.com/net/metadata/groupdocs.metadata.common/metadatapackage/methods/findproperties) method for a certain metadata package (instance of the [PdfPackage](https://apireference.groupdocs.com/net/metadata/groupdocs.metadata.formats.document/pdfpackage) class), the search result will contain only metadata properties that are specific for PDF documents. 

## Inspecting PDF documents

The inspection feature that is introduced in this section doesn't work with metadata directly but extracts some useful pieces of information that can be considered as metadata under some circumstances. For example, you may want to obtain information about digital signatures associated with a document, extract form fields, attachments, bookmarks, etc. Please follow the example below to learn how to do that.

1.  [Load]({{< ref "metadata/net/developer-guide/advanced-usage/loading-files/_index.md" >}}) a PDF document
2.  Extract the root metadata package
3.  Use the [InspectionPackage](https://apireference.groupdocs.com/net/metadata/groupdocs.metadata.formats.document/pdfrootpackage/properties/inspectionpackage) property to inspect the document

**AdvancedUsage.ManagingMetadataForSpecificFormats.Document.Pdf.PdfReadInspectionProperties**

```csharp
using (Metadata metadata = new Metadata(Constants.SignedPdf))
{
	var root = metadata.GetRootPackage<PdfRootPackage>();
	if (root.InspectionPackage.Annotations != null)
	{
		foreach (var annotation in root.InspectionPackage.Annotations)
		{
			Console.WriteLine(annotation.Name);
			Console.WriteLine(annotation.Text);
			Console.WriteLine(annotation.PageNumber);
		}
	}

	if (root.InspectionPackage.Attachments != null)
	{
		foreach (var attachment in root.InspectionPackage.Attachments)
		{
			Console.WriteLine(attachment.Name);
			Console.WriteLine(attachment.MimeType);
			Console.WriteLine(attachment.Description);
		}
	}

	if (root.InspectionPackage.Bookmarks != null)
	{
		foreach (var bookmark in root.InspectionPackage.Bookmarks)
		{
			Console.WriteLine(bookmark.Title);
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
			Console.WriteLine(field.Name);
			Console.WriteLine(field.Value);

			// ...
		}
	}
}
```

## Reading document statistics

Most office applications are able to display simple text statistics for loaded documents. It can be an estimated word count, page count, character count, etc. The GroupDocs.Metadata API provides similar functionality for some document formats. The following code sample demonstrates how to obtain the text statistics for a PDF document.

**AdvancedUsage.ManagingMetadataForSpecificFormats.Document.Pdf.PdfReadDocumentStatistics**

```csharp
using (Metadata metadata = new Metadata(Constants.InputPdf))
{
	var root = metadata.GetRootPackage<PdfRootPackage>();

	Console.WriteLine(root.DocumentStatistics.CharacterCount);
	Console.WriteLine(root.DocumentStatistics.PageCount);
	Console.WriteLine(root.DocumentStatistics.WordCount);
}
```

## Updating built-In metadata properties

Updating any built-in document properties is as simple as getting them. The following code sample demonstrates how to update built-in metadata properties in a PDF document.

**AdvancedUsage.ManagingMetadataForSpecificFormats.Document.Pdf.PdfUpdateBuiltInProperties**

```csharp
using (Metadata metadata = new Metadata(Constants.InputPdf))
{
	var root = metadata.GetRootPackage<PdfRootPackage>();

	root.DocumentProperties.Author = "test author";
	root.DocumentProperties.CreatedDate = DateTime.Now;
	root.DocumentProperties.Title = "test title";
	root.DocumentProperties.Keywords = "metadata, built-in, update";

	// ... 

	metadata.Save(Constants.OutputPdf);
}
```

## Adding or updating custom metadata properties

The GroupDocs.Metadata API also allows adding and updating custom metadata properties in a PDF document. Please check the code sample below.

**AdvancedUsage.ManagingMetadataForSpecificFormats.Document.Pdf.PdfUpdateCustomProperties**

```csharp
using (Metadata metadata = new Metadata(Constants.InputPdf))
{
	var root = metadata.GetRootPackage<PdfRootPackage>();

	root.DocumentProperties.Set("customProperty1", "some value");

	metadata.Save(Constants.OutputPdf);
}
```

## Updating inspection properties

When you inspect a document GroupDocs.Metadata for .NET forms a metadata package containing the extracted information. The package class also provides some basic methods that allow removing the extracted properties. The following code sample demonstrates how to remove the inspection properties from a PDF document.

**AdvancedUsage.ManagingMetadataForSpecificFormats.Document.Pdf.PdfUpdateInspectionProperties**

```csharp
using (Metadata metadata = new Metadata(Constants.SignedPdf))
{
	var root = metadata.GetRootPackage<PdfRootPackage>();

	root.InspectionPackage.ClearAnnotations();
	root.InspectionPackage.ClearAttachments();
	root.InspectionPackage.ClearFields();
	root.InspectionPackage.ClearBookmarks();
	root.InspectionPackage.ClearDigitalSignatures();

	metadata.Save(Constants.OutputPdf);
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
