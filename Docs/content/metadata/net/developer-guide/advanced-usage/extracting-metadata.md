---
id: extracting-metadata
url: metadata/net/extracting-metadata
title: Extracting metadata
weight: 2
description: "This article shows how to extract metadata properties from your files in C# .NET solution programmatically with GroupDocs.Metadata for .NET"
keywords: C# .NET DOC DOCX PDF XLS XLSX PPT PPTX JPG TIFF PNG Metadata
productName: GroupDocs.Metadata for .NET
hideChildren: False
---
Using the GroupDocs.Metadata for .NET you can easily extract metadata from PDF, DOC, PPT, XLS and many other files of different types in your .NET solution.

GroupDocs.Metadata for .NET supports many file formats. See full list at [supported file formats]({{< ref "metadata/net/getting-started/supported-document-formats.md" >}}) article.

You don't need to worry about the exact file format and metadata standards it can deal with. The same code will work for all supported formats in the same way.

Most commonly used metadata properties are marked with tags that allow searching them across all supported files in various metadata packages. All tags defined in GroupDocs.Metadata are divided into categories that make it easier to find a required tag.

In this article we would like to demonstrate some advanced usage of tags, categories and other attributes of metadata properties.

The following steps and C# code sample below show **how to extract metadata properties from your files in .NET solution**:

1.  [Load]({{< ref "metadata/net/developer-guide/advanced-usage/loading-files/_index.md" >}}) a file to be searched for metadata properties
2.  Make up a predicate to examine all extracted metadata properties
3.  Pass the predicate to the [FindProperties](https://apireference.groupdocs.com/net/metadata/groupdocs.metadata/metadata/methods/findproperties) method
4.  Iterate through the found properties

**AdvancedUsage.ExtractingMetadata**

```csharp
foreach (string file in Directory.GetFiles(Constants.InputPath))
{
	using (Metadata metadata = new Metadata(file))
	{
		if (metadata.FileFormat != FileFormat.Unknown && !metadata.GetDocumentInfo().IsEncrypted)
		{
			Console.WriteLine();
			Console.WriteLine(file);

			// Fetch all metadata properties that fall into a particular category
			var properties = metadata.FindProperties(p => p.Tags.Any(t => t.Category == Tags.Content));
			Console.WriteLine("The metadata properties describing some characteristics of the file content: title, keywords, language, etc.");
			foreach (var property in properties)
			{
				Console.WriteLine("{0} = {1}", property.Name, property.Value);
			}

			// Fetch all properties having a specific type and value
			var year = DateTime.Today.Year;
			properties = metadata.FindProperties(p => p.Value.Type == MetadataPropertyType.DateTime &&
													 p.Value.ToStruct(DateTime.MinValue).Year == year);
			Console.WriteLine("All datetime properties with the year value equal to the current year");
			foreach (var property in properties)
			{
				Console.WriteLine("{0} = {1}", property.Name, property.Value);
			}

			// Fetch all properties whose names match the specified regex
			const string pattern = "^author|company|(.+date.*)$";
			Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);
			properties = metadata.FindProperties(p => regex.IsMatch(p.Name));
			Console.WriteLine("All properties whose names match the following regex: {0}", pattern);
			foreach (var property in properties)
			{
				Console.WriteLine("{0} = {1}", property.Name, property.Value);
			}
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