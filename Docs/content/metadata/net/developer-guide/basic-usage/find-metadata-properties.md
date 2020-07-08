---
id: find-metadata-properties
url: metadata/net/find-metadata-properties
title: Find metadata properties
weight: 2
description: ""
keywords: 
productName: GroupDocs.Metadata for .NET
hideChildren: False
---
Using the GroupDocs.Metadata for .NET you can easily find and extract desired metadata properties from PDF, DOCX, PPTX, XLSX, images, audio, video and many other files of different types in your .NET solution.

GroupDocs.Metadata for .NET supports many file formats. See full list at [supported file formats]({{< ref "metadata/net/getting-started/supported-document-formats.md" >}}) article.

## Use tags to find most common metadata properties

To make manipulating metadata in your code easier we attach specific tags to the most commonly used metadata properties extracted from a file. Some metadata standards can have quite a complex structure. Moreover, in most cases, an image, video or document contains more than one metadata packages. Using tags you can search for desirable properties with a few lines of code without even knowing the exact format of the loaded file.

In this article we will demonstrate how to search and extract metadata from PPTX Microsoft PowerPoint presentation. Using the same code, you can easily search matadata properties of any supported file formats.

The following steps and C# code sample below show **how to search for specific metadata properties using tags in .NET solution**:

1.  [Load]({{< ref "metadata/net/developer-guide/advanced-usage/loading-files/_index.md" >}}) a file to examine.
2.  Make up a predicate checking that a specific tag is assigned to a property (alternatively you can use a combination of tags)
3.  Pass the predicate to the [FindProperties](https://apireference.groupdocs.com/net/metadata/groupdocs.metadata/metadata/methods/findproperties) method
4.  Iterate through the found properties

**BasicUsage.FindMetadataProperties**

```csharp
// Constants.InputPptx is an absolute or relative path to your document. Ex: @"C:\Docs\source.pptx"
using (Metadata metadata = new Metadata(Constants.InputPptx))
{
	// Fetch all the properties satisfying the predicate:
	// property contains the name of the last document editor OR the date/time the document was last modified
	var properties = metadata.FindProperties(p => p.Tags.Contains(Tags.Person.Editor) || p.Tags.Contains(Tags.Time.Modified));

	foreach (var property in properties)
	{
		Console.WriteLine("Property name: {0}, Property value: {1}", property.Name, property.Value);
	}
}
```

As a result, we obtain all metadata properties containing the name of the person last edited the document and all properties that store the date/time the document was last edited.

For more information on supported features of the GroupDocs.Metadata search engine please refer to the following articles:

*   [Extracting metadata]({{< ref "metadata/net/developer-guide/advanced-usage/extracting-metadata.md" >}})
*   [Removing metadata]({{< ref "metadata/net/developer-guide/advanced-usage/removing-metadata.md" >}})
*   [Updating metadata]({{< ref "metadata/net/developer-guide/advanced-usage/updating-metadata.md" >}})
*   [Adding metadata]({{< ref "metadata/net/developer-guide/advanced-usage/adding-metadata.md" >}})

## More resources
### Advanced usage topics
To learn more about document watermarking features and get familiar how to manage watermarks and more, please refer to the [advanced usage section]({{< ref "metadata/net/developer-guide/advanced-usage/_index.md" >}}).

### GitHub examples
You may easily run the code above and see the feature in action in our GitHub examples:
*   [GroupDocs.Metadata for .NET examples](https://github.com/groupdocs-metadata/GroupDocs.Metadata-for-.NET)    
*   [GroupDocs.Metadata for Java examples](https://github.com/groupdocs-metadata/GroupDocs.Metadata-for-Java)    

### Free online document metadata management App
Along with full featured .NET library we provide simple, but powerful free Apps.
You are welcome to view and edit metadata of PDF, DOC, DOCX, PPT, PPTX, XLS, XLSX, emails, images and more with our free online [Free Online Document Metadata Viewing and Editing App](https://products.groupdocs.app/metadata).
