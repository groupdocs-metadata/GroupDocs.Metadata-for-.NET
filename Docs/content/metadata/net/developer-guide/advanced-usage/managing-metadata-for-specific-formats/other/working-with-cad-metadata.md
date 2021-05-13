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

**AdvancedUsage.ManagingMetadataForSpecificFormats.<WBR>Cad.CadReadNativeMetadataProperties**

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

## Updating DXF metadata

The GroupDocs.Metadata API also allows updating metadata properties in a DXF drawing. Please check the code sample below.

```csharp
using (Metadata metadata = new Metadata(Constants.InputDxf))
{
    var root = metadata.GetRootPackage<CadRootPackage>();
 
    root.CadPackage.SetProperties(p => p.Name == "Author", new PropertyValue("GroupDocs"));
    root.CadPackage.SetProperties(p => p.Name == "Comments", new PropertyValue("test comment"));
    root.CadPackage.SetProperties(p => p.Name == "HyperlinkBase", new PropertyValue("test hyperlink base"));
    root.CadPackage.SetProperties(p => p.Name == "Keywords", new PropertyValue("test keywords"));
    root.CadPackage.SetProperties(p => p.Name == "LastSavedBy", new PropertyValue("test editor"));
    root.CadPackage.SetProperties(p => p.Name == "RevisionNumber", new PropertyValue("test revision number"));
    root.CadPackage.SetProperties(p => p.Name == "Subject", new PropertyValue("test subject"));
    root.CadPackage.SetProperties(p => p.Name == "Title", new PropertyValue("test title"));
    root.CadPackage.SetProperties(p => p.Name == "CreatedDateTime", new PropertyValue(DateTime.Now.AddDays(-1)));
    root.CadPackage.SetProperties(p => p.Name == "ModifiedDateTime", new PropertyValue(DateTime.Now));
 
    metadata.Save(Constants.OutputDxf);
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