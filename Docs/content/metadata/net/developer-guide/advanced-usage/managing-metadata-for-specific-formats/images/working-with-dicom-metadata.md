---
id: working-with-dicom-metadata
url: metadata/net/working-with-dicom-metadata
title: Working with DICOM metadata
weight: 3
description: ""
keywords: 
productName: GroupDocs.Metadata for .NET
hideChildren: False
---
## Reading DICOM metadata properties

The GroupDocs.Metadata API supports extracting format-specific information from DICOM images.

The following are the steps to read the native DICOM metadata.

1.  [Load]({{< ref "metadata/net/developer-guide/advanced-usage/loading-files/_index.md" >}}) a DICOM image
2.  Get the root metadata package
3.  Extract  the native metadata package using [DicomRootPackage.DicomPackage](https://apireference.groupdocs.com/net/metadata/groupdocs.metadata.formats.image/dicomrootpackage/properties/dicompackage)
4.  Read the DICOM metadata properties

**AdvancedUsage.ManagingMetadataForSpecificFormats.Image.Dicom.DicomReadNativeMetadataProperties**

```csharp
using (Metadata metadata = new Metadata(Constants.InputDicom))
{
	var root = metadata.GetRootPackage<DicomRootPackage>();
	if (root.DicomPackage != null)
	{
		Console.WriteLine(root.DicomPackage.BitsAllocated);
		Console.WriteLine(root.DicomPackage.LengthValue);
		Console.WriteLine(root.DicomPackage.DicomFound);
		Console.WriteLine(root.DicomPackage.HeaderOffset);
		Console.WriteLine(root.DicomPackage.NumberOfFrames);

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