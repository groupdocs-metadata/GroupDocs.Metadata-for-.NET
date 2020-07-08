---
id: set-metadata-properties
url: metadata/net/set-metadata-properties
title: Set metadata properties
weight: 4
description: ""
keywords: 
productName: GroupDocs.Metadata for .NET
hideChildren: False
---
## Add or update metadata properties satisfying a predicate

The [SetProperties](https://apireference.groupdocs.com/net/metadata/groupdocs.metadata/metadata/methods/setproperties) method used in this code sample actually combines two operations: add and update. If an existing property satisfies the specified predicate its value is updated. If there is a known property missing in a metadata package that satisfies the predicate it is added to the appropriate package.

The code snippet below demonstrates a basic usage scenario of the [SetProperties](https://apireference.groupdocs.com/net/metadata/groupdocs.metadata/metadata/methods/setproperties) method.

1.  [Open]({{< ref "metadata/net/developer-guide/basic-usage/set-metadata-properties.md" >}}) a file to update
2.  Specify a predicate that will be used to add/update metadata properties
3.  Specify a value you would like to add to existing metadata packages in the file
4.  Check the actual number of added/updated properties
5.  [Save]({{< ref "metadata/net/developer-guide/basic-usage/set-metadata-properties.md" >}}) the changes

**BasicUsage.SetMetadataProperties**

```csharp
// Constants.InputVsdx is an absolute or relative path to your document. Ex: @"C:\Docs\source.vsdx"
using (Metadata metadata = new Metadata(Constants.InputVsdx))
{
	// Set the value of each property that satisfies the predicate:
	// property contains the date/time the document was created OR modified
	var affected = metadata.SetProperties(
		p => p.Tags.Contains(Tags.Time.Created) || p.Tags.Contains(Tags.Time.Modified),
		new PropertyValue(DateTime.Now));
	Console.WriteLine("Properties set: {0}", affected);
	metadata.Save(Constants.OutputVsdx);
}
```

As a result, we update all existing metadata properties containing the date the document was created/updated. If a metadata package doesn't contain such properties but they are meant to be in its structure they are added.

For more information on supported features of the GroupDocs.Metadata search engine please refer to the following articles:

*   [Set metadata properties]({{< ref "metadata/net/developer-guide/basic-usage/set-metadata-properties.md" >}})
*   [Set metadata properties]({{< ref "metadata/net/developer-guide/basic-usage/set-metadata-properties.md" >}})
*   [Set metadata properties]({{< ref "metadata/net/developer-guide/basic-usage/set-metadata-properties.md" >}})
*   [Set metadata properties]({{< ref "metadata/net/developer-guide/basic-usage/set-metadata-properties.md" >}})

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
