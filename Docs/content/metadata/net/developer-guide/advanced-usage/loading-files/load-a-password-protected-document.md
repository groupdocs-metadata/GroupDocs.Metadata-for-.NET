---
id: load-a-password-protected-document
url: metadata/net/load-a-password-protected-document
title: Load a password-protected document
weight: 4
description: ""
keywords: 
productName: GroupDocs.Metadata for .NET
hideChildren: False
---
This example demonstrates how to load a password-protected document.

**AdvancedUsage.LoadingFiles.LoadPasswordProtectedDocument**

```csharp
// Specify the password
var loadOptions = new LoadOptions
{
	Password = "123"
};

// Constants.ProtectedDocx is an absolute or relative path to your document. Ex: @"C:\Docs\source.docx"
using (var metadata = new Metadata(Constants.ProtectedDocx, loadOptions))
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