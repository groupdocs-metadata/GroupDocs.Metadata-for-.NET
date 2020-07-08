---
id: working-with-metadata-in-note-formats
url: metadata/net/working-with-metadata-in-note-formats
title: Working with metadata in Note formats
weight: 7
description: ""
keywords: 
productName: GroupDocs.Metadata for .NET
hideChildren: False
---
GroupDocs.Metadata for .NET provides functionality that allows working with ONE files created by different versions of Microsoft OneNote. Please see the code samples below for more information.

## Inspecting Note documents

The inspection feature that is introduced in this section doesn't work with metadata directly but extracts some useful pieces of information that can be considered as metadata under some circumstances. For example, you may want to obtain information about pages in a note document. Please follow the example below to learn how to do that.

1.  [Load]({{< ref "metadata/net/developer-guide/advanced-usage/loading-files/_index.md" >}}) a Note document
2.  Extract the root metadata package
3.  Use the [InspectionPackage](https://apireference.groupdocs.com/net/metadata/groupdocs.metadata.formats.document/noterootpackage/properties/inspectionpackage) property to inspect the document

**AdvancedUsage.ManagingMetadataForSpecificFormats.<WBR>Document.Note.<WBR>NoteReadInspectionProperties**

```csharp
using (Metadata metadata = new Metadata(Constants.InputOne))
{
	var root = metadata.GetRootPackage<NoteRootPackage>();

	if (root.InspectionPackage.Pages != null)
	{
		foreach (var page in root.InspectionPackage.Pages)
		{
			Console.WriteLine(page.Title);
			Console.WriteLine(page.Author);
			Console.WriteLine(page.CreationTime);
			Console.WriteLine(page.LastModificationTime);
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