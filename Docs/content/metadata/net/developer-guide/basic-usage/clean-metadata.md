---
id: clean-metadata
url: metadata/net/clean-metadata
title: Clean metadata
weight: 5
description: ""
keywords: 
productName: GroupDocs.Metadata for .NET
hideChildren: False
---
## Remove all recognized metadata properties from a file

Sometimes you may need to just remove all metadata properties without applying any filters. The best way to do this is to use the [Sanitize](https://apireference.groupdocs.com/net/metadata/groupdocs.metadata/metadata/methods/sanitize) method.

This example demonstrates how to remove all detected metadata packages/properties.

1.  [Load]({{< ref "metadata/net/developer-guide/basic-usage/clean-metadata.md" >}}) a file to clean
2.  Call the [Sanitize](https://apireference.groupdocs.com/net/metadata/groupdocs.metadata/metadata/methods/sanitize) method
3.  Check the actual number of removed packages/properties
4.  [Save]({{< ref "metadata/net/developer-guide/basic-usage/clean-metadata.md" >}}) the changes

**BasicUsage.CleanMetadata**

```csharp
using (Metadata metadata = new Metadata(Constants.InputPdf))
{
	// Remove detected metadata packages
	var affected = metadata.Sanitize();
	Console.WriteLine("Properties removed: {0}", affected);

	metadata.Save(Constants.OutputPdf);
}
```

As a result, we get a sanitized version of the original file.

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
