---
id: get-document-info
url: metadata/net/get-document-info
title: Get document info
weight: 1
description: ""
keywords: 
productName: GroupDocs.Metadata for .NET
hideChildren: False
---
GroupDocs.Metadata allows users to get document information which includes:

*   [File format](https://apireference.groupdocs.com/net/metadata/groupdocs.metadata.common/filetypepackage/properties/fileformat) (detected by the internal structure)
*   [File extension](https://apireference.groupdocs.com/net/metadata/groupdocs.metadata.common/filetypepackage/properties/extension)
*   [MIME type](https://apireference.groupdocs.com/net/metadata/groupdocs.metadata.common/filetypepackage/properties/mimetype)
*   [Number of pages](https://apireference.groupdocs.com/net/metadata/groupdocs.metadata.common/idocumentinfo/properties/pagecount)
*   [File size](https://apireference.groupdocs.com/net/metadata/groupdocs.metadata.common/idocumentinfo/properties/size)
*   A [value](https://apireference.groupdocs.com/net/metadata/groupdocs.metadata.common/idocumentinfo/properties/isencrypted) indicating whether a file is encrypted

The following code sample demonstrates how to extract basic format information from a file.

**BasicUsage.GetDocumentInfo**

```csharp
// Constants.InputXlsx is an absolute or relative path to your document. Ex: @"C:\Docs\source.xlsx"
using (Metadata metadata = new Metadata(Constants.InputXlsx))
{
	if (metadata.FileFormat != FileFormat.Unknown)
	{
		IDocumentInfo info = metadata.GetDocumentInfo();
		Console.WriteLine("File format: {0}", info.FileType.FileFormat);
		Console.WriteLine("File extension: {0}", info.FileType.Extension);
		Console.WriteLine("MIME Type: {0}", info.FileType.MimeType);
		Console.WriteLine("Number of pages: {0}", info.PageCount);
		Console.WriteLine("Document size: {0} bytes", info.Size);
		Console.WriteLine("Is document encrypted: {0}", info.IsEncrypted);
	}
}
```

## More resources

### Advanced usage topics

To learn more about document watermarking features and get familiar how to manage watermarks and more, please refer to the [advanced usage section]({{< ref "metadata/net/developer-guide/advanced-usage/_index.md" >}}).

### GitHub examples

You may easily run the code above and see the feature in action in our GitHub examples:

*   [GroupDocs.Metadata for .NET examples](https://github.com/groupdocs-metadata/GroupDocs.Metadata-for-.NET)
    
*   [GroupDocs.Metadata for Java examples](https://github.com/groupdocs-metadata/GroupDocs.Metadata-for-Java)
    

### Free online document metadata management App

Along with full featured .NET library we provide simple, but powerful free Apps.

You are welcome to view and edit metadata of PDF, DOC, DOCX, PPT, PPTX, XLS, XLSX, emails, images and more with our free online [Free Online Document Metadata Viewing and Editing App](https://products.groupdocs.app/metadata).
