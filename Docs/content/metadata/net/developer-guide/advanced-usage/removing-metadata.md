---
id: removing-metadata
url: metadata/net/removing-metadata
title: Removing metadata
weight: 3
description: ""
keywords: 
productName: GroupDocs.Metadata for .NET
hideChildren: False
---
Not all metadata properties extracted from a file are marked with tags. Some file formats and metadata standards allow adding fully custom properties that can't be properly tagged by the library since their purpose is not clearly defined in the appropriate format/standard specification. In such cases, you can use the name of the property to locate and remove it. The following example demonstrates some advanced usage scenarios of the GroupDocs.Metadata search engine allowing to remove metadata properties.

1.  [Load]({{< ref "metadata/net/developer-guide/advanced-usage/loading-files/_index.md" >}}) a file to be modified
2.  Pass a search predicate to the [RemoveProperties](https://apireference.groupdocs.com/net/metadata/groupdocs.metadata/metadata/methods/removeproperties) method.
3.  Check the number of properties that were actually removed
4.  [Save]({{< ref "metadata/net/developer-guide/advanced-usage/saving-files/_index.md" >}}) the changes

**AdvancedUsage.RemovingMetadata**

```csharp
foreach (string file in Directory.GetFiles(Constants.InputPath))
{
	using (Metadata metadata = new Metadata(file))
	{
		if (metadata.FileFormat != FileFormat.Unknown && !metadata.GetDocumentInfo().IsEncrypted)
		{
			Console.WriteLine();
			Console.WriteLine(file);

			// Remove all mentions of any people contributed in file creation
			// Remove all properties with the specified name
			var affected = metadata.RemoveProperties(p => p.Tags.Any(t => t.Category == Tags.Person) || p.Name == "CustomProperty");

			Console.WriteLine("Affected properties: {0}", affected);

			metadata.Save(Path.Combine(Constants.OutputPath, "output" + Path.GetExtension(file)));
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