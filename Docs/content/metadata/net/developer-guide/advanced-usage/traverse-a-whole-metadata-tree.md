---
id: traverse-a-whole-metadata-tree
url: metadata/net/traverse-a-whole-metadata-tree
title: Traverse a whole metadata tree
weight: 6
description: ""
keywords: 
productName: GroupDocs.Metadata for .NET
hideChildren: False
---
In some cases, it's required to get access to all properties extracted from a document, video, image, etc. GroupDocs.Metadata represents any loaded file as a tree consisting of metadata properties and nested metadata packages. You can easily iterate through the metadata tree using the code snippet below:

1.  [Load]({{< ref "metadata/net/developer-guide/advanced-usage/loading-files/_index.md" >}}) a file to examine
2.  Obtain the [RootMetadataPackage](https://apireference.groupdocs.com/net/metadata/groupdocs.metadata.common/rootmetadatapackage) instance which is the root of the whole metadata tree extracted from the file
3.  Use any algorithm of your choice to traverse the tree.

**AdvancedUsage.TraverseWholeMetadataTree**

```csharp
public static void Run()
{
	using (Metadata metadata = new Metadata(Constants.JpegWithXmp))
	{
		DisplayMetadataTree(metadata.GetRootPackage(), 0);
	}
}

private static void DisplayMetadataTree(MetadataPackage package, int indent)
{
	if (package != null)
	{
		var stringMetadataType = package.MetadataType.ToString();
		Console.WriteLine(stringMetadataType.PadLeft(stringMetadataType.Length + indent));
		foreach (MetadataProperty property in package)
		{
			string stringPropertyRepresentation = string.Format("Name: {0}, Value: {1}", property.Name, property.Value);
			Console.WriteLine(stringPropertyRepresentation.PadLeft(stringPropertyRepresentation.Length + indent + 1));
			if (property.Value != null)
			{
				switch (property.Value.Type)
				{
					case MetadataPropertyType.Metadata:
						DisplayMetadataTree(property.Value.ToClass<MetadataPackage>(), indent + 2);
						break;
					case MetadataPropertyType.MetadataArray:
						DisplayMetadataTree(property.Value.ToArray<MetadataPackage>(), indent + 2);
						break;
				}
			}
		}
	}
}

private static void DisplayMetadataTree(MetadataPackage[] packages, int indent)
{
	if (packages != null)
	{
		foreach (var package in packages)
		{
			DisplayMetadataTree(package, indent);
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
