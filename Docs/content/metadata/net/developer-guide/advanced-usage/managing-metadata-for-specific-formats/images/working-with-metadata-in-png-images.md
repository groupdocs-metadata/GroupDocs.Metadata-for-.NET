---
id: working-with-metadata-in-png-images
url: metadata/net/working-with-metadata-in-png-images
title: Working with metadata in PNG images
weight: 7
description: ""
keywords: 
productName: GroupDocs.Metadata for .NET
hideChildren: False
---
## Reading PNG metadata properties

The GroupDocs.Metadata API supports extracting format-specific information from PNG images.

The following are the steps to read the native PNG metadata.

1.  [Load]({{< ref "metadata/net/developer-guide/advanced-usage/loading-files/_index.md" >}}) a PNG image
2.  Get the root metadata package
3.  Extract  the native metadata package using [PngRootPackage.PngPackage](https://apireference.groupdocs.com/metadata/net/groupdocs.metadata.formats.image/pngrootpackage/properties/pngpackage)
4.  Read the PNG metadata properties

**AdvancedUsage.ManagingMetadataForSpecificFormats.<WBR>Image.Png.PngReadTextChunks**

```csharp
using (Metadata metadata = new Metadata(Constants.InputPng))
{
    var root = metadata.GetRootPackage<PngRootPackage>();
    foreach (var chunk in root.PngPackage.TextChunks)
    {
        Console.WriteLine(chunk.Keyword);
        Console.WriteLine(chunk.Text);
        var compressedChunk = chunk as PngCompressedTextChunk;
        if (compressedChunk != null)
        {
            Console.WriteLine(compressedChunk.CompressionMethod);
        }
        var internationalChunk = chunk as PngInternationalTextChunk;
        if (internationalChunk != null)
        {
            Console.WriteLine(internationalChunk.IsCompressed);
            Console.WriteLine(internationalChunk.Language);
            Console.WriteLine(internationalChunk.TranslatedKeyword);
        }
    }
}
```

## Working with XMP metadata

GroupDocs.Metadata for .NET allows managing XMP metadata in PNG images. For more details please refer to the following guide: [Working with XMP metadata]({{< ref "metadata/net/developer-guide/advanced-usage/working-with-metadata-standards/working-with-xmp-metadata.md" >}}).

## Working with EXIF metadata

The GroupDocs.Metadata API supports handling EXIF metadata in PNG images. Please find appropriate code samples in the [Working with EXIF metadata]({{< ref "metadata/net/developer-guide/advanced-usage/working-with-metadata-standards/working-with-exif-metadata.md" >}}) section.

## More resources
### GitHub examples
You may easily run the code above and see the feature in action in our GitHub examples:
*   [GroupDocs.Metadata for .NET examples](https://github.com/groupdocs-metadata/GroupDocs.Metadata-for-.NET)    
*   [GroupDocs.Metadata for Java examples](https://github.com/groupdocs-metadata/GroupDocs.Metadata-for-Java)    

### Free online document metadata management App
Along with full featured .NET library we provide simple, but powerful free Apps.
You are welcome to view and edit metadata of PDF, DOC, DOCX, PPT, PPTX, XLS, XLSX, emails, images and more with our free online [Free Online Document Metadata Viewing and Editing App](https://products.groupdocs.app/metadata).