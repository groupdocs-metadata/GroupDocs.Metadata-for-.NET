---
id: exporting-metadata-properties
url: metadata/net/exporting-metadata-properties
title: Exporting metadata properties
weight: 1
description: ""
keywords: 
productName: GroupDocs.Metadata for .NET
hideChildren: False
---
This example demonstrates how to export metadata properties to an Excel workbook. For more information please refer to the [ExportManager](https://apireference.groupdocs.com/metadata/net/groupdocs.metadata.export/exportmanager) class.

**AdvancedUsage.ExportingMetadataProperties**

```csharp
using (Metadata metadata = new Metadata(@"D:\input.doc"))
{
	RootMetadataPackage root = metadata.GetRootPackage();
	if (root != null)
	{
		// Initialize the export manager with the root metadata package to export the whole metadata tree
		ExportManager manager = new ExportManager(root);
		manager.Export(@"D:\export.xls", ExportFormat.Xls);
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