---
id: groupdocs-metadata-for-net-18-1-release-notes
url: metadata/net/groupdocs-metadata-for-net-18-1-release-notes
title: GroupDocs.Metadata for .NET 18.1 Release Notes
weight: 11
description: ""
keywords: 
productName: GroupDocs.Metadata for .NET
hideChildren: False
---
{{< alert style="info" >}}This page contains release notes for GroupDocs.Metadata for .NET 18.1.{{< /alert >}}

## Major Features

There are 3 new features in this regular monthly release. The most notable are:

*   Implement ability to read metadata of EPUB format
*   Implement ability to detect EPUB e-book format
*   Implement ability to read DublinCore metadata in EPUB format

## All Changes

| Key | Summary | Category |
| --- | --- | --- |
| METADATANET-717 | Implement ability to read metadata of EPUB format | New Feature |
| METADATANET-2133   | Implement ability to detect EPUB e-book format | New Feature  |
| METADATANET-2134 | Implement ability to read DublinCore metadata in EPUB format | New Feature  |

## Public API and Backward Incompatible Changes

{{< alert style="info" >}}This section lists public API changes that were introduced in GroupDocs.Metadata for .NET 18.1. It includes not only new and obsoleted public methods, but also a description of any changes in the behavior behind the scenes in GroupDocs.Metadata which may affect existing code. Any behavior introduced that could be seen as a regression and modifies existing behavior is especially important and is documented here.{{< /alert >}}

#### Implement ability to read metadata of EPUB format

##### Description

Implement ability to read metadata of EPUB e-book format

##### Public API changes

Added **EpubFormat** class into namespace **GroupDocs.Metadata.Formats.Ebook**  
Added **EpubMetadata** class into namespace **GroupDocs.Metadata.Formats.Ebook**

##### Usecases

This example demonstrates how to read metadata of EPUB e-book format



```csharp
// path to the EPUB file
const string file = @"C:\Jack_London_Biography.epub";

// open EPUB file
EpubFormat epub = new EpubFormat(file);

// read EPUB metadata
EpubMetadata metadata = epub.GetEpubMetadata();

// get keys
string[] keys = metadata.Keys;

foreach (string key in keys)
{
 // get next metadata property
 MetadataProperty property = metadata[key];

 // and print it
 Console.WriteLine(property);
}
```

#### Implement ability to detect EPUB e-book format

##### Description

Implement ability to detect EPUB e-book format

##### Public API changes

Added **EpubFormat** class into namespace **GroupDocs.Metadata.Formats.Ebook**

##### Usecases

This example demonstrates how to detect EPUB e-book format



```csharp
// just try to open
EpubFormat epubFormat = new EpubFormat(file);

// or
//using FormatFactory
EpubFormat epubFormat = (EpubFormat) FormatFactory.RecognizeFormat(file);
```

### Implement ability to read DublinCore metadata in EPUB format

##### Description

Implement ability to read DublinCore metadata of EPUB e-book format

##### Public API changes

Added **DublinCoreMetadata** class into namespace **GroupDocs.Metadata**

##### Usecases

This example demonstrates how to read DublinCore metadata of EPUB e-book format



```csharp
// path to the EPUB file
const string file = @"C:\Jack_London_Biography.epub";

// open EPUB file
EpubFormat epub = new EpubFormat(file);

// read dublin-core metadata
DublinCoreMetadata dublinCore = epub.GetDublinCore();

// get creator
string creator = dublinCore.Creator;

// get publisher
string publisher = dublinCore.Publisher;

// get contributor
string contributor = dublinCore.Contributor;
```
