---
id: working-with-metadata-in-avi-files
url: metadata/net/working-with-metadata-in-avi-files
title: Working with metadata in AVI files
weight: 2
description: ""
keywords: 
productName: GroupDocs.Metadata for .NET
hideChildren: False
---
## Reading AVI header properties

The GroupDocs.Metadata API supports extracting format-specific information from AVI file headers.

The following are the steps to read the header of an AVI file.

1.  [Load]({{< ref "metadata/net/developer-guide/advanced-usage/loading-files/_index.md" >}}) an AVI video
2.  Get the root metadata package
3.  Extract  the native metadata package using [AviRootPackage.Header](https://apireference.groupdocs.com/net/metadata/groupdocs.metadata.formats.video/avirootpackage/properties/header)
4.  Read the AVI header properties

**AdvancedUsage.ManagingMetadataForSpecificFormats.<WBR>Video.Avi.AviReadHeaderProperties**

```csharp
using (Metadata metadata = new Metadata(Constants.InputAvi))
{
	var root = metadata.GetRootPackage<AviRootPackage>();

	Console.WriteLine(root.Header.AviHeaderFlags);
	Console.WriteLine(root.Header.Height);
	Console.WriteLine(root.Header.Width);
	Console.WriteLine(root.Header.TotalFrames);
	Console.WriteLine(root.Header.InitialFrames);
	Console.WriteLine(root.Header.MaxBytesPerSec);
	Console.WriteLine(root.Header.PaddingGranularity);
	Console.WriteLine(root.Header.Streams);

	// ...
}
```

## Extract RIFF INFO chunk metadata

The AVI format is derived from the RIFF container which acts as a wrapper for various audio and video coding formats. As a derivative of RIFF, AVI files can be tagged with metadata in the INFO chunk. The chunk may include information such as the title of the work, the author, the creation date, and copyright information. Here is an example of how the RIFF INFO metadata can be extracted:

**AdvancedUsage.ManagingMetadataForSpecificFormats.<WBR>Video.Avi.AviReadInfoMetadata**

```csharp
using (Metadata metadata = new Metadata(Constants.InputAvi))
{
    var root = metadata.GetRootPackage<AviRootPackage>();
    if (root.RiffInfoPackage != null)
    {
        Console.WriteLine(root.RiffInfoPackage.Artist);
        Console.WriteLine(root.RiffInfoPackage.Comment);
        Console.WriteLine(root.RiffInfoPackage.Copyright);
        Console.WriteLine(root.RiffInfoPackage.CreationDate);
        Console.WriteLine(root.RiffInfoPackage.Software);
        Console.WriteLine(root.RiffInfoPackage.Engineer);
        Console.WriteLine(root.RiffInfoPackage.Genre);
 
        // ...
    }
}
```

## Working with XMP metadata

GroupDocs.Metadata for .NET allows managing XMP metadata in AVI files. For more details please refer to the following guide: [Working with XMP metadata]({{< ref "metadata/net/developer-guide/advanced-usage/working-with-metadata-standards/working-with-xmp-metadata.md" >}}).

## More resources
### GitHub examples
You may easily run the code above and see the feature in action in our GitHub examples:
*   [GroupDocs.Metadata for .NET examples](https://github.com/groupdocs-metadata/GroupDocs.Metadata-for-.NET)    
*   [GroupDocs.Metadata for Java examples](https://github.com/groupdocs-metadata/GroupDocs.Metadata-for-Java)    

### Free online document metadata management App
Along with full featured .NET library we provide simple, but powerful free Apps.
You are welcome to view and edit metadata of PDF, DOC, DOCX, PPT, PPTX, XLS, XLSX, emails, images and more with our free online [Free Online Document Metadata Viewing and Editing App](https://products.groupdocs.app/metadata).