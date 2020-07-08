---
id: adding-metadata
url: metadata/net/adding-metadata
title: Adding metadata
weight: 5
description: ""
keywords: 
productName: GroupDocs.Metadata for .NET
hideChildren: False
---
Adding metadata properties is the most sophisticated feature of the GroupDocs.Metadata search engine. When you call the [AddProperties](https://apireference.groupdocs.com/net/metadata/groupdocs.metadata/metadata/methods/addproperties) method it examines all available metadata packages and tries to pick up a known property that would satisfy the specified predicate. Note that the property will be added to metadata packages that fit the following criteria: 

1.  Only existing metadata packages will be affected. No new packages are added during this operation
2.  There should be a known metadata property in the package structure that fits the search condition but is actually missing in the package. All properties supported by a certain package are usually defined in the specification of a particular metadata standard

**AdvancedUsage.AddingMetadata**

```csharp
foreach (string file in Directory.GetFiles(Constants.InputPath))
{
	using (Metadata metadata = new Metadata(file))
	{
		if (metadata.FileFormat != FileFormat.Unknown && !metadata.GetDocumentInfo().IsEncrypted)
		{
			Console.WriteLine();
			Console.WriteLine(file);

			// Add a property containing the file last printing date
			var affected = metadata.AddProperties(p => p.Tags.Contains(Tags.Time.Printed), new PropertyValue(DateTime.Now));
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