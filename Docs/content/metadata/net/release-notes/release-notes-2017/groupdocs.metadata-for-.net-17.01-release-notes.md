---
id: groupdocs-metadata-for-net-17-01-release-notes
url: metadata/net/groupdocs-metadata-for-net-17-01-release-notes
title: GroupDocs.Metadata for .NET 17.01 Release Notes
weight: 12
description: ""
keywords: 
productName: GroupDocs.Metadata for .NET
hideChildren: False
---
{{< alert style="info" >}}
This page contains release notes for [GroupDocs.Metadata for .NET 17.01.0](http://downloads.groupdocs.com/metadata/net/new-releases/groupdocs.metadata-for-.net-17.1.0/)
{{< /alert >}}

## Major Features

There are 4 features and 3 enhancements in this regular monthly release. The most notable are:

*   Ability to update ContentType, ContentStatus, HyperlinkBase SharedDoc properties in PPTX format
*   Load metadata without loading whole PowerPoint document
*   Ability to read ID3 metadata directly in Mp3 format
*   Ability to read page count, characters count, words count, page size in document formats
*   Ability to recognize file type of the document format (DOCX, DOC, DOT etc)
*   Ability to detect digital signature in document formats
*   Ability to remove all digital signatures in document formats

## All Changes

| Key | Summary | Category |
| --- | --- | --- |
| METADATANET-1332 | Ability to read page count, characters count, words count, page size in document formats | New feature |
| METADATANET-1385 | Ability to recognize file type of the document format (DOCX, DOC, DOT etc) | New feature |
| METADATANET-1391 | Ability to detect digital signature in document formats | New feature |
| METADATANET-1392 | Ability to remove all digital signatures in document formats | New feature |
| METADATANET-417 | Ability to update ContentType, ContentStatus, HyperlinkBase SharedDoc properties in PPTX format | Enhancement |
| METADATANET-1041 | Load metadata without loading whole PowerPoint document | Enhancement |
| METADATANET-1401 | Ability to read ID3 metadata directly in Mp3 format | Enhancement |

## Public API and Backward Incompatible Changes

{{< alert style="info" >}}This section lists public API changes that were introduced in GroupDocs.Metadata for .NET 17.01.0 It includes not only new and obsoleted public methods, but also a description of any changes in the behavior behind the scenes in GroupDocs.Metadata which may affect existing code. Any behavior introduced that could be seen as a regression and modifies existing behavior is especially important and is documented here.{{< /alert >}}

#### Ability to update ContentType, ContentStatus, HyperlinkBase SharedDoc properties in PPTX format

This example demonstrates how to update several properties in PPTX format



```csharp
// path to the ppt file
string path = @"C:\download files\Northwind_Products.pptx";

// initialize PptFormat
PptFormat pptFormat = new PptFormat(path);

// get document properties
PptMetadata metadata = pptFormat.DocumentProperties;

// set content type
metadata.ContentType = "content type";

// set hyperlink base
metadata.HyperlinkBase = "http://groupdocs.com";

// mark as shared
metadata.SharedDoc = true;

// and commit changes
pptFormat.Save();

```

#### Improve performance of PowerPoint metadata reading

This enhancement allows to read metadata faster



```csharp
PptFormat ppt = new PptFormat(path);

var properties = ppt.DocumentProperties;

```

#### Ability to read ID3 metadata directly in Mp3 format

This enhancement allows to read ID3 metadata in MP3 format directly using indexer. It provides easy access to known ID3 properties such as Title, Author etc.

**Public API Changes:**

*   Added **MetadataKey.Id3v1** nested class into namespace **GroupDocs.Metadata**
*   Added **MetadataKey.Id3v2** nested class into namespace **GroupDocs.Metadata**

This example demonstrates how to read Id3 metadata directly in MP3 format



```csharp
const string filePath = @"C:\download files\Kalimba.mp3";

// init Mp3Format class
Mp3Format mp3Format = new Mp3Format(filePath);

// read album in ID3 v1
MetadataProperty album = mp3Format[MetadataKey.Id3v1.Album];
Console.WriteLine(album);

// read title in ID3 v2
MetadataProperty title = mp3Format[MetadataKey.Id3v2.Title];
Console.WriteLine(title);

// create custom ID3v2 key
// TCOP is used for 'Copyright' property according to the ID3 specification
MetadataKey copyrightKey = new MetadataKey(MetadataType.Id3v2, "TCOP");

// read copyright property
MetadataProperty copyright = mp3Format[copyrightKey];
Console.WriteLine(copyright);

```

#### Ability to read page count, characters count, words count, page size in document formats

This feature allows to calculate words count, page count, page's size in document formats such as Word, Excel, PowerPoint and PDF.  
Feature is not supported in trial mode.

**Public API Changes:**

*   Added **DocumentInfo** class into namespace **GroupDocs.Metadata**

This example demonstrates how to read calculated document info for MS Word format



```csharp
// path to the MS Word file
string path = @"C:\download files\cv.doc";

// initialize DocFormat
DocFormat docFormat = new DocFormat(path);

// get document info
DocumentInfo documentInfo = docFormat.DocumentInfo;

// display characters count
long charactersCount = documentInfo.CharactersCount;
Console.WriteLine("Characters count: {0}", charactersCount);

// display pages count
int pagesCount = documentInfo.PagesCount;
Console.WriteLine("Pages count: {0}", pagesCount);

```

#### Ability to recognize file type of the document format (DOCX, DOC, DOT etc)

It's very important to know file type when working with document format such as MS Word, MS Excel etc.  
This feature allows to detect file type of the document formats based on it's internal structure.  
Feature is supported for Word, Excel, PowerPoint and MS Visio formats.

**Public API Changes:**  
Added \*FileType\* enumeration into namespace \*GroupDocs.Metadata\*  
This example demonstrates how to display file type of the Word document



```csharp
// path to the MS Word file
string path = @"C:\\example.doc";

// initialize DocFormat
DocFormat docFormat = new DocFormat(path);

// display file type
switch (docFormat.FileType)
{
  case FileType.Doc:
   Console.WriteLine("Old binary document");
   break;

  case FileType.Docx:
   Console.WriteLine("XML-based document");
   break;
}

```

#### Ability to detect digital signature in document formats

Implement ability to detect digital signature in document formats such as Word, Excel and PDF

**Public API Changes:**

*   Added **DigitalSignature** value into enumeration **MetadataType** of **GroupDocs.Metadata** namespace
*   Added **DigitalSignatures** value into enumeration **DocInspectorOptionsEnum** of **GroupDocs.Metadata.Formats.Document** namespace
*   Added **DigitalSignatures** value into enumeration **PdfInspectorOptionsEnum** of **GroupDocs.Metadata.Formats.Document** namespace
*   Added **DigitalSignatures** value into enumeration **XlsInspectorOptionsEnum** of **GroupDocs.Metadata.Formats.Document** namespace
*   Added **DigitalSignature** class into namespace **GroupDocs.Metadata**

This example demonstrates how to read digital signature in MS Word document



```csharp
// path to the MS Word file
string path = @"C:\\example.docx";

// initialize DocFormat
DocFormat docFormat = new DocFormat(path);

// if document contains digital signatures
if (docFormat.HasDigitalSignatures)
{
  // then inspect it
  var inspectionResult = docFormat.InspectDocument();

  // and get digital signatures
  DigitalSignature[] signatures = inspectionResult.DigitalSignatures;

  foreach (DigitalSignature signature in signatures)
  {
   // get certificate subject
   Console.WriteLine("Certificate subject: {0}", signature.CertificateSubject);

   // get certificate sign time
   Console.WriteLine("Signed time: {0}", signature.SignTime);
   }
}


```

#### Ability to remove all digital signatures in document formats

This feature allows to remove digital signature(s) in document formats such as Word, Excel and PDF

**Public API Changes:**

*   Added **DigitalSignatures** value into enumeration **DocInspectorOptionsEnum** of **GroupDocs.Metadata.Formats.Document** namespace
*   Added **DigitalSignatures** value into enumeration **PdfInspectorOptionsEnum** of **GroupDocs.Metadata.Formats.Document** namespace
*   Added **DigitalSignatures** value into enumeration **XlsInspectorOptionsEnum** of **GroupDocs.Metadata.Formats.Document** namespace

This example demonstrates how to remove all digital signatures in MS Word document



```csharp
// path to the MS Word file
string path = @"C:\\example.doc";

// initialize DocFormat
DocFormat docFormat = new DocFormat(path);

// if document contains digital signatures
if (docFormat.HasDigitalSignatures)
{
  // then remove them
  docFormat.RemoveHiddenData(new DocInspectionOptions(DocInspectorOptionsEnum.DigitalSignatures));

  // and commit changes
  docFormat.Save();
}

```
