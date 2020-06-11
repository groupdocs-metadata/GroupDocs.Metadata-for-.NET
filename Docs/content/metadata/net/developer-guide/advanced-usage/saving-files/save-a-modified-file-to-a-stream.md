---
id: save-a-modified-file-to-a-stream
url: metadata/net/save-a-modified-file-to-a-stream
title: Save a modified file to a stream
weight: 3
description: ""
keywords: 
productName: GroupDocs.Metadata for .NET
hideChildren: False
---
This example shows how to save a file to the specified stream.

**AdvancedUsage.SavingFiles.SaveFileToSpecifiedStream**

```csharp
using (MemoryStream stream = new MemoryStream())
{
	// Constants.InputPng is an absolute or relative path to your document. Ex: @"C:\Docs\test.png"
	using (Metadata metadata = new Metadata(Constants.InputPng))
	{
		// Edit or remove metadata here
        // ...

		metadata.Save(stream);
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
