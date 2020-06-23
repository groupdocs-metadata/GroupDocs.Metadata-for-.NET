---
id: load-from-a-stream
url: metadata/net/load-from-a-stream
title: Load from a stream
weight: 2
description: ""
keywords: 
productName: GroupDocs.Metadata for .NET
hideChildren: False
---
This example demonstrates how to load a file from a stream.

**AdvancedUsage.LoadingFiles.LoadFromStream**

```csharp
// Constants.InputDoc is an absolute or relative path to your document. Ex: @"C:\Docs\source.doc"
using (Stream stream = File.Open(Constants.InputDoc, FileMode.Open, FileAccess.ReadWrite))
using (Metadata metadata = new Metadata(stream))
{
	// Extract, edit or remove metadata here
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