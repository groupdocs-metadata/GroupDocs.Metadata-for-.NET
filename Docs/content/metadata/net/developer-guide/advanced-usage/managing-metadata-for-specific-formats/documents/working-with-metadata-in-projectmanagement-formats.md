---
id: working-with-metadata-in-projectmanagement-formats
url: metadata/net/working-with-metadata-in-projectmanagement-formats
title: Working with metadata in ProjectManagement formats
weight: 6
description: ""
keywords: 
productName: GroupDocs.Metadata for .NET
hideChildren: False
---
GroupDocs.Metadata for .NET provides functionality that allows working with MPP files created by different versions of Microsoft Project. Please see the code samples below for more information.

## Reading built-In metadata properties

To access built-in metadata of a ProjectManagement document, please use the [DocumentProperties](https://apireference.groupdocs.com/net/metadata/groupdocs.metadata.formats.document.documentrootpackage/1/properties/documentproperties) property defined in the [DocumentRootPackage](https://apireference.groupdocs.com/net/metadata/groupdocs.metadata.formats.document.documentrootpackage/1) class.

The following code snippet extracts built-in metadata properties and displays them on the screen.

**AdvancedUsage.ManagingMetadataForSpecificFormats.<WBR>Document.ProjectManagement.<WBR>ProjectManagementReadBuiltInProperties**

```csharp
using (Metadata metadata = new Metadata(Constants.InputMpp))
{
	var root = metadata.GetRootPackage<ProjectManagementRootPackage>();

	Console.WriteLine(root.DocumentProperties.Author);
	Console.WriteLine(root.DocumentProperties.CreationDate);
	Console.WriteLine(root.DocumentProperties.Company);
	Console.WriteLine(root.DocumentProperties.Category);
	Console.WriteLine(root.DocumentProperties.Keywords);
	Console.WriteLine(root.DocumentProperties.Revision);
	Console.WriteLine(root.DocumentProperties.Subject);

	// ... 
}
```

## Reading custom metadata properties

If you need to extract custom metadata properties of a ProjectManagement document please follow the code sample below.
**AdvancedUsage.ManagingMetadataForSpecificFormats.<WBR>Document.ProjectManagement.<WBR>ProjectManagementReadCustomProperties**

```csharp
using (Metadata metadata = new Metadata(Constants.InputMpp))
{
    var root = metadata.GetRootPackage<ProjectManagementRootPackage>();
    var customProperties = root.DocumentProperties.FindProperties(p => !p.Tags.Contains(Tags.Document.BuiltIn));
    foreach (var property in customProperties)
    {
        Console.WriteLine("{0} = {1}", property.Name, property.Value);
    }
}
```

## Updating built-in metadata properties

Updating any built-in document properties is as simple as getting them. The following code sample demonstrates how to update built-in metadata properties in a ProjectManagement document.

**AdvancedUsage.ManagingMetadataForSpecificFormats.<WBR>Document.ProjectManagement.<WBR>ProjectManagementUpdateBuiltInProperties**

```csharp
using (Metadata metadata = new Metadata(Constants.InputMpp))
{
	var root = metadata.GetRootPackage<ProjectManagementRootPackage>();

	root.DocumentProperties.Author = "test author";
	root.DocumentProperties.CreationDate = DateTime.Now;
	root.DocumentProperties.Company = "GroupDocs";
	root.DocumentProperties.Comments = "test comment";
	root.DocumentProperties.Keywords = "metadata, built-in, update";

	// ... 

	metadata.Save(Constants.OutputMpp);
}
```

## Adding or updating custom metadata properties

The GroupDocs.Metadata API also allows adding and updating custom metadata properties in a ProjectManagement document. Please check the code sample below.

**AdvancedUsage.ManagingMetadataForSpecificFormats.<WBR>Document.ProjectManagement.<WBR>ProjectManagementUpdateCustomProperties**

```csharp
using (Metadata metadata = new Metadata(Constants.InputMpp))
{
    var root = metadata.GetRootPackage<ProjectManagementRootPackage>();
 
    root.DocumentProperties.Set("customProperty1", "some value");
    root.DocumentProperties.Set("customProperty2", 7);
    root.DocumentProperties.Set("customProperty3", true);
 
    // ...
 
    metadata.Save(Constants.OutputMpp);
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