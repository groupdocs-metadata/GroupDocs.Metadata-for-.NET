---
id: remove-metadata-properties
url: metadata/net/remove-metadata-properties
title: Remove metadata properties
weight: 3
description: ""
keywords: 
productName: GroupDocs.Metadata for .NET
hideChildren: False
---
## Remove metadata properties using various criteria

The easiest way to remove certain metadata properties from a file is to use corresponding tags that allow you to locate the desired properties across all metadata packages. But sometimes it's necessary to remove metadata entries having a particular value. Using the GroupDocs.Metadata search engine you can find and remove properties satisfying a predicate that can be as complex as you need. Just work with metadata trees using lambda expressions as you usually do with regular .NET collections through LINQ.

The following example demonstrates how to remove specific metadata properties using a combination of criteria.

1.  [Load]({{< ref "metadata/net/developer-guide/basic-usage/remove-metadata-properties.md" >}}) a file to update
2.  Use a predicate to find and remove any desired metadata properties
3.  Check the number of properties that were actually removed (please see the return value of the [RemoveProperties](https://apireference.groupdocs.com/net/metadata/groupdocs.metadata/metadata/methods/removeproperties) method)
4.  [Save]({{< ref "metadata/net/developer-guide/basic-usage/remove-metadata-properties.md" >}}) the changes

**BasicUsage.RemoveMetadataProperties**

```csharp
// Constants.InputDocx is an absolute or relative path to your document. Ex: @"C:\Docs\source.docx"
using (Metadata metadata = new Metadata(Constants.InputDocx))
{
	// Remove all the properties satisfying the predicate:
	// property contains the name of the document author OR
	// it refers to the last editor OR
	// the property value is a string that contains the substring "John" (to remove any mentions of John from the detected metadata)
	var affected = metadata.RemoveProperties(
		p => p.Tags.Contains(Tags.Person.Creator) ||
			 p.Tags.Contains(Tags.Person.Editor) ||
			 p.Value.Type == MetadataPropertyType.String && p.Value.ToString().Contains("John"));
	Console.WriteLine("Properties removed: {0}", affected);

	metadata.Save(Constants.OutputDocx);
}
```

As a result of execution of the code snippet above, we remove all mentions of the document author/editor and all other string metadata properties containing the name John.

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
