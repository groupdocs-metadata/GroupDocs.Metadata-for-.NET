---
id: working-with-metadata-in-mov-files
url: metadata/net/working-with-metadata-in-mov-files
title: Working with metadata in MOV Files
weight: 5
description: ""
keywords: 
productName: GroupDocs.Metadata for .NET
hideChildren: False
---
## Reading MOV format-specific properties

The GroupDocs.Metadata API supports extracting QuickTime atoms from a MOV video. The atom is the basic data unit in any QuickTime file. Please find more information on QuickTime atoms in the official specification: [https://developer.apple.com/library/archive/documentation/QuickTime/QTFF/QTFFPreface/qtffPreface.html](https://developer.apple.com/library/archive/documentation/QuickTime/QTFF/QTFFPreface/qtffPreface.html)

The following are the steps to extract QuickTime atoms from a MOV video.

1.  [Load]({{< ref "metadata/net/developer-guide/advanced-usage/loading-files/_index.md" >}}) a MOV video
2.  Get the root metadata package
3.  Extract  the native metadata package using [MovRootPackage.MovPackage](https://apireference.groupdocs.com/net/metadata/groupdocs.metadata.formats.video/movrootpackage/properties/movpackage)
4.  Read the QuickTime atoms

**AdvancedUsage.ManagingMetadataForSpecificFormats.Video.Mov.MovReadQuickTimeAtoms**

```csharp
using (Metadata metadata = new Metadata(Constants.InputMov))
{
	var root = metadata.GetRootPackage<MovRootPackage>();
	foreach (var atom in root.MovPackage.Atoms)
	{
		Console.WriteLine(atom.Type);
		Console.WriteLine(atom.Offset);
		Console.WriteLine(atom.Size);

		// ...
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
