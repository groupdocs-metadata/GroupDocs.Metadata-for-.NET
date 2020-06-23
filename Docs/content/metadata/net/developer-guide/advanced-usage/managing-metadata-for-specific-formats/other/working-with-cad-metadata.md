---
id: working-with-cad-metadata
url: metadata/net/working-with-cad-metadata
title: Working with CAD metadata
weight: 2
description: ""
keywords: 
productName: GroupDocs.Metadata for .NET
hideChildren: False
---
The GroupDocs Metadata API provides the feature to read basic metadata in CAD files. The supported CAD formats are:

*   DWG
*   DXF

## Reading CAD metadata

To access metadata in a CAD drawing, the GroupDocs.Metadata API provides the [CadRootPackage.CadPackage](https://apireference.groupdocs.com/net/metadata/groupdocs.metadata.formats.cad/cadrootpackage/properties/cadpackage) property.

The following code snippet reads metadata associated with a CAD file.

**AdvancedUsage.ManagingMetadataForSpecificFormats.Cad.CadReadNativeMetadataProperties**

```csharp
using (Metadata metadata = new Metadata(Constants.InputDxf))
{
	var root = metadata.GetRootPackage<CadRootPackage>();

	Console.WriteLine(root.CadPackage.AcadVersion);
	Console.WriteLine(root.CadPackage.Author);
	Console.WriteLine(root.CadPackage.Comments);
	Console.WriteLine(root.CadPackage.CreatedDateTime);
	Console.WriteLine(root.CadPackage.HyperlinkBase);
	Console.WriteLine(root.CadPackage.Keywords);
	Console.WriteLine(root.CadPackage.LastSavedBy);
	Console.WriteLine(root.CadPackage.Title);

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