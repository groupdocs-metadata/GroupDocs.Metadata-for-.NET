---
id: working-with-metadata-in-presentations
url: metadata/net/working-with-metadata-in-presentations
title: Working with metadata in Presentations
weight: 3
description: ""
keywords: 
productName: GroupDocs.Metadata for .NET
hideChildren: False
---
GroupDocs.Metadata for .NET provides functionality that allows working with different kinds of presentations such as PPT, PPTX, POTM, POTX, etc. For the full list of supported presentation formats please refer to [Supported Document Formats]({{< ref "metadata/net/getting-started/supported-document-formats.md" >}}).

## Detecting the exact type of a presentation

The following sample of code will help you to detect the exact type of a loaded presentation and extract some additional file format information.

1.  [Load]({{< ref "metadata/net/developer-guide/advanced-usage/loading-files/_index.md" >}}) a presentation
2.  Extract the root metadata package
3.  Use the [FileType](https://apireference.groupdocs.com/net/metadata/groupdocs.metadata.formats.document/presentationrootpackage/properties/filetype) property to obtain file format information

**AdvancedUsage.ManagingMetadataForSpecificFormats.Document.Presentation.PresentationReadFileFormatProperties**

```csharp
using (Metadata metadata = new Metadata(Constants.InputPptx))
{
	var root = metadata.GetRootPackage<PresentationRootPackage>();

	Console.WriteLine(root.FileType.FileFormat);
	Console.WriteLine(root.FileType.PresentationFormat);
	Console.WriteLine(root.FileType.MimeType);
	Console.WriteLine(root.FileType.Extension);
}
```

## Reading built-In metadata properties

To access built-in metadata of a presentation, please use the [DocumentProperties](https://apireference.groupdocs.com/net/metadata/groupdocs.metadata.formats.document.documentrootpackage/1/properties/documentproperties) property defined in the [DocumentRootPackage](https://apireference.groupdocs.com/net/metadata/groupdocs.metadata.formats.document.documentrootpackage/1) class.

The following code snippet extracts built-in metadata properties and displays them on the screen.

**AdvancedUsage.ManagingMetadataForSpecificFormats.Document.Presentation.PresentationReadBuiltInProperties**

```csharp
using (Metadata metadata = new Metadata(Constants.InputPpt))
{
	var root = metadata.GetRootPackage<PresentationRootPackage>();

	Console.WriteLine(root.DocumentProperties.Author);
	Console.WriteLine(root.DocumentProperties.CreatedTime);
	Console.WriteLine(root.DocumentProperties.Company);
	Console.WriteLine(root.DocumentProperties.Category);
	Console.WriteLine(root.DocumentProperties.Keywords);
	Console.WriteLine(root.DocumentProperties.LastPrintedDate);
	Console.WriteLine(root.DocumentProperties.NameOfApplication);

	// ... 
}
```

## Reading custom metadata properties

If you need to extract custom metadata properties of a presentation please follow the code sample below.

**AdvancedUsage.ManagingMetadataForSpecificFormats.Document.Presentation.PresentationReadCustomProperties**

```csharp
using (Metadata metadata = new Metadata(Constants.InputPptx))
{
	var root = metadata.GetRootPackage<PresentationRootPackage>();
	var customProperties = root.DocumentProperties.FindProperties(p => !p.Tags.Contains(Tags.Document.BuiltIn));

	foreach (var property in customProperties)
	{
		Console.WriteLine("{0} = {1}", property.Name, property.Value);
	}
}
```

As you can see the code sample uses the GroupDocs.Metadata search engine to retrieve all properties that are not marked with the BuiltIn tag. Since we call the [FindProperties](https://apireference.groupdocs.com/net/metadata/groupdocs.metadata.common/metadatapackage/methods/findproperties) method for a certain metadata package (instance of the [PresentationPackage](https://apireference.groupdocs.com/net/metadata/groupdocs.metadata.formats.document/presentationpackage) class), the search result will contain only metadata properties that are specific for presentations. 

## Inspecting presentations

The inspection feature that is introduced in this section doesn't work with metadata directly but extracts some useful pieces of information that can be considered as metadata under some circumstances. For example, you may want to obtain information about hidden slides presented in a document or extract user comments from the document content. Please follow the example below to learn how to do that.

1.  [Load]({{< ref "metadata/net/developer-guide/advanced-usage/loading-files/_index.md" >}}) a Presentation document
2.  Extract the root metadata package
3.  Use the [InspectionPackage](https://apireference.groupdocs.com/net/metadata/groupdocs.metadata.formats.document/presentationrootpackage/properties/inspectionpackage) property to inspect the document

**AdvancedUsage.ManagingMetadataForSpecificFormats.Document.Presentation.PresentationReadInspectionProperties**

```csharp
using (Metadata metadata = new Metadata(Constants.InputPpt))
{
	var root = metadata.GetRootPackage<PresentationRootPackage>();

	if (root.InspectionPackage.Comments != null)
	{
		foreach (var comment in root.InspectionPackage.Comments)
		{
			Console.WriteLine(comment.Author);
			Console.WriteLine(comment.Text);
			Console.WriteLine(comment.CreatedTime);
			Console.WriteLine(comment.SlideNumber);
		}
	}

	if (root.InspectionPackage.HiddenSlides != null)
	{
		foreach (var slide in root.InspectionPackage.HiddenSlides)
		{
			Console.WriteLine(slide.Name);
			Console.WriteLine(slide.Number);
			Console.WriteLine(slide.SlideId);
		}
	}
}
```

## Reading document statistics

Most office applications are able to display simple text statistics for loaded documents. It can be an estimated word count, page count, character count, etc. The GroupDocs.Metadata API provides similar functionality for some document formats. The following code sample demonstrates how to obtain the text statistics for a presentation.

**AdvancedUsage.ManagingMetadataForSpecificFormats.Document.Presentation.PresentationReadDocumentStatistics**

```csharp
using (Metadata metadata = new Metadata(Constants.InputPpt))
{
	var root = metadata.GetRootPackage<PresentationRootPackage>();

	Console.WriteLine(root.DocumentStatistics.CharacterCount);
	Console.WriteLine(root.DocumentStatistics.PageCount);
	Console.WriteLine(root.DocumentStatistics.WordCount);
}
```

## Updating built-in metadata properties

Updating any built-in document properties is as simple as getting them. The following code sample demonstrates how to update built-in metadata properties in a presentation.

**AdvancedUsage.ManagingMetadataForSpecificFormats.Document.Presentation.PresentationUpdateBuiltInProperties**

```csharp
using (Metadata metadata = new Metadata(Constants.InputPptx))
{
	var root = metadata.GetRootPackage<PresentationRootPackage>();

	root.DocumentProperties.Author = "test author";
	root.DocumentProperties.CreatedTime = DateTime.Now;
	root.DocumentProperties.Company = "GroupDocs";
	root.DocumentProperties.Category = "test category";
	root.DocumentProperties.Keywords = "metadata, built-in, update";

	// ... 

	metadata.Save(Constants.OutputPptx);
}
```

## Adding or updating custom metadata properties

The GroupDocs.Metadata API also allows adding and updating custom metadata properties in a presentation. Please check the code sample below.

**AdvancedUsage.ManagingMetadataForSpecificFormats.Document.Presentation.PresentationUpdateCustomProperties**

```csharp
using (Metadata metadata = new Metadata(Constants.InputPpt))
{
	var root = metadata.GetRootPackage<PresentationRootPackage>();

	root.DocumentProperties.Set("customProperty1", "some value");
	root.DocumentProperties.Set("customProperty2", 123.1);

	metadata.Save(Constants.OutputPpt);
}
```

## Updatingj inspection properties

When you inspect a document GroupDocs.Metadata for .NET forms a metadata package containing the extracted information. The package class also provides some basic methods that allow updating (or removing) the extracted properties. The following code sample demonstrates how to remove the inspection properties from a presentation.

**AdvancedUsage.ManagingMetadataForSpecificFormats.Document.Presentation.PresentationUpdateInspectionProperties**

```csharp
using (Metadata metadata = new Metadata(Constants.InputPpt))
{
	var root = metadata.GetRootPackage<PresentationRootPackage>();

	root.InspectionPackage.ClearComments();
	root.InspectionPackage.ClearHiddenSlides();

	metadata.Save(Constants.OutputPpt);
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
