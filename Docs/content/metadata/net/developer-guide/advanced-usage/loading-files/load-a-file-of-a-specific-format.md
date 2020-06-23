---
id: load-a-file-of-a-specific-format
url: metadata/net/load-a-file-of-a-specific-format
title: Load a file of a specific format
weight: 3
description: ""
keywords: 
productName: GroupDocs.Metadata for .NET
hideChildren: False
---
This example demonstrates how to load a file of some particular format.

**AdvancedUsage.LoadingFiles.LoadingFileOfSpecificFormat**

```csharp
// Explicitly specifying the format of a file to load you can spare some time on detecting the format
var loadOptions = new LoadOptions(FileFormat.Spreadsheet);

// Constants.InputXls is an absolute or relative path to your document. Ex: @"C:\Docs\source.xls"
using (Metadata metadata = new Metadata(Constants.InputXls, loadOptions))
{
	var root = metadata.GetRootPackage<SpreadsheetRootPackage>();

	// Use format-specific properties to extract or edit metadata
	Console.WriteLine(root.DocumentProperties.Author);

	// ...
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
