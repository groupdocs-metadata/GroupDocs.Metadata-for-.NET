---
id: updating-metadata
url: metadata/net/updating-metadata
title: Updating metadata
weight: 4
description: ""
keywords: 
productName: GroupDocs.Metadata for .NET
hideChildren: False
---
The example below demonstrates how to update existing metadata properties using a combination of criteria. Please note that the [UpdateProperties](https://apireference.groupdocs.com/net/metadata/groupdocs.metadata/metadata/methods/updateproperties) method checks the type of all properties before applying any changes. If a property satisfies the predicate but has a type different from the passed value it won't be updated. The explicit type check in the example is performed since we use the existing value to filter metadata properties.

1.  [Open]({{< ref "metadata/net/developer-guide/advanced-usage/loading-files/_index.md" >}}) a file to be updated
2.  Specify a predicate that will be used to filter desired metadata properties
3.  Specify a value which you want to be assigned to the selected properties
4.  Pass the predicate and the new value to the [UpdateProperties](https://apireference.groupdocs.com/net/metadata/groupdocs.metadata/metadata/methods/updateproperties) method
5.  Check the actual number of updated properties
6.  [Save]({{< ref "metadata/net/developer-guide/advanced-usage/saving-files/_index.md" >}}) the changes
      
    

**AdvancedUsage.UpdatingMetadata**

```csharp
DateTime today = DateTime.Today;
DateTime threeDaysAgo = today.AddDays(-3);
foreach (string file in Directory.GetFiles(Constants.InputPath))
{
	using (Metadata metadata = new Metadata(file))
	{
		if (metadata.FileFormat != FileFormat.Unknown && !metadata.GetDocumentInfo().IsEncrypted)
		{
			Console.WriteLine();
			Console.WriteLine(file);

			// Update the file creation date/time if the existing value is older than 3 days
			var affected = metadata.UpdateProperties(p => p.Tags.Contains(Tags.Time.Created) &&
														  p.Value.Type == MetadataPropertyType.DateTime &&
														  p.Value.ToStruct<DateTime>() < threeDaysAgo, new PropertyValue(today));
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