---
id: working-with-metadata-in-epub-e-books
url: metadata/net/working-with-metadata-in-epub-e-books
title: Working with metadata in EPUB E-Books
weight: 4
description: ""
keywords: 
productName: GroupDocs.Metadata for .NET
hideChildren: False
---
## What is EPUB?

EPUB is an e-book file format that uses the ".epub" file extension. EPUB is supported by many e-readers, and compatible software is available for most smartphones, tablets, and computers. 

{{< alert style="info" >}}Please find more information on the format at https://en.wikipedia.org/wiki/EPUB{{< /alert >}}

## Reading EPUB format-specific properties

The GroupDocs.Metadata API supports extracting format-specific information from EPUB files.

The following are the steps to read native EPUB metadata.

1.  [Load]({{< ref "metadata/net/developer-guide/advanced-usage/loading-files/_index.md" >}}) an EPUB file
2.  Get the root metadata package
3.  Extract  the native metadata package using [EpubRootPackage.EpubPackage](https://apireference.groupdocs.com/net/metadata/groupdocs.metadata.formats.ebook/epubrootpackage/properties/epubpackage)
4.  Read the EPUB metadata properties

**AdvancedUsage.ManagingMetadataForSpecificFormats.<WBR>Ebook.EpubReadNativeMetadataProperties**

```csharp
using (Metadata metadata = new Metadata(Constants.InputEpub))
{
	var root = metadata.GetRootPackage<EpubRootPackage>();

	Console.WriteLine(root.EpubPackage.Version);
	Console.WriteLine(root.EpubPackage.UniqueIdentifier);
	Console.WriteLine(root.EpubPackage.ImageCover != null ? root.EpubPackage.ImageCover.Length : 0);
	Console.WriteLine(root.EpubPackage.Description);
	Console.WriteLine(root.EpubPackage.Title);

	// ...
}
```

## Updating EPUB format-specific properties

The GroupDocs.Metadata API also supports updating some metadata properties of an EPUB file. Please see the code snippet below to learn how to do that.

```csharp
using (Metadata metadata = new Metadata(Constants.InputEpub))
{
    var root = metadata.GetRootPackage<EpubRootPackage>();
    root.EpubPackage.Creator = "GroupDocs";
    root.EpubPackage.Description = "test e-book";
    root.EpubPackage.Format = "EPUB";
    root.EpubPackage.Date = DateTime.Now.ToString();
 
    // ...
 
    metadata.Save(Constants.OutputEpub);
}
```

## Reading Dublin Core Metadata

Dublin Core metadata is a set of certain metadata properties that are intended to describe various digital resources. Please find more information on the Dublin Core standard at [https://en.wikipedia.org/wiki/Dublin\_Core](https://en.wikipedia.org/wiki/Dublin_Core). The code sample below shows how to extract Dublin Core metadata from a EPUB e-book using the GroupDocs.Metadata API.

**AdvancedUsage.ManagingMetadataForSpecificFormats.<WBR>Ebook.EpubReadDublinCoreProperties**

```csharp
using (Metadata metadata = new Metadata(Constants.InputEpub))
{
	var root = metadata.GetRootPackage<EpubRootPackage>();

	Console.WriteLine(root.DublinCorePackage.Rights);
	Console.WriteLine(root.DublinCorePackage.Publisher);
	Console.WriteLine(root.DublinCorePackage.Title);
	Console.WriteLine(root.DublinCorePackage.Creator);
	Console.WriteLine(root.DublinCorePackage.Language);
	Console.WriteLine(root.DublinCorePackage.Date);

	// ...
}
```

## Updating Dublin Core Metadata

The GroupDocs.Metadata API also allows updating DublinCore metadata properties in an EPUB file. Please check the code sample below.

```csharp
using (Metadata metadata = new Metadata(Constants.InputEpub))
{
    var root = metadata.GetRootPackage<EpubRootPackage>();
    root.DublinCorePackage.SetProperties(p => p.Name == "dc:creator", new PropertyValue("GroupDocs"));
    root.DublinCorePackage.SetProperties(p => p.Name == "dc:description", new PropertyValue("test e-book"));
    root.DublinCorePackage.SetProperties(p => p.Name == "dc:title", new PropertyValue("test EPUB"));
    root.DublinCorePackage.SetProperties(p => p.Name == "dc:date", new PropertyValue(DateTime.Now.ToString()));
  
    // ...
  
    metadata.Save(Constants.OutputEpub);
}
```

Please see the the [DublinCorePackage](https://apireference.groupdocs.com/net/metadata/groupdocs.metadata.standards.dublincore/dublincorepackage) class to get more information on supported Dublin Core metadata properties.

## More resources
### GitHub examples
You may easily run the code above and see the feature in action in our GitHub examples:
*   [GroupDocs.Metadata for .NET examples](https://github.com/groupdocs-metadata/GroupDocs.Metadata-for-.NET)    
*   [GroupDocs.Metadata for Java examples](https://github.com/groupdocs-metadata/GroupDocs.Metadata-for-Java)    

### Free online document metadata management App
Along with full featured .NET library we provide simple, but powerful free Apps.
You are welcome to view and edit metadata of PDF, DOC, DOCX, PPT, PPTX, XLS, XLSX, emails, images and more with our free online [Free Online Document Metadata Viewing and Editing App](https://products.groupdocs.app/metadata).