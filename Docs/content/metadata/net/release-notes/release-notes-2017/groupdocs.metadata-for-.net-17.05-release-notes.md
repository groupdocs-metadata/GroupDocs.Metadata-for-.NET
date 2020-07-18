---
id: groupdocs-metadata-for-net-17-05-release-notes
url: metadata/net/groupdocs-metadata-for-net-17-05-release-notes
title: GroupDocs.Metadata for .NET 17.05 Release Notes
weight: 9
description: ""
keywords: 
productName: GroupDocs.Metadata for .NET
hideChildren: False
---
{{< alert style="info" >}}
This page contains release notes for [GroupDocs.Metadata for .NET 17.05.0](https://downloads.groupdocs.com/metadata/net/new-releases/groupdocs.metadata-for-.net-17.5.0/)
{{< /alert >}}

## Major Features

There are 2 new features in this regular monthly release. The most notable are:

*   Ability to read all revisions in Word format
*   Ability to accept or reject revisions in Word format

## All Changes

| Key | Summary | Category |
| --- | --- | --- |
| METADATANET-1570 | Ability to read all revisions in Word format | New Feature |
| METADATANET-1722 | Ability to accept or reject revisions in Word format | New Feature |

## Public API and Backward Incompatible Changes

{{< alert style="info" >}}This section lists public API changes that were introduced in GroupDocs.Metadata for .NET 17.05.0 It includes not only new and obsoleted public methods, but also a description of any changes in the behavior behind the scenes in GroupDocs.Metadata which may affect existing code. Any behavior introduced that could be seen as a regression and modifies existing behavior is especially important and is documented here.{{< /alert >}}

#### Ability to read all revisions in Word format

This feature allows to read all track changes(revisions) in Word document.

##### Public API changes

Added **RevisionType** enum into namespace **GroupDocs.Metadata.Formats.Document**  
Added **Revision** class into namespace **GroupDocs.Metadata.Formats.Document**  
Added **RevisionCollection** class into namespace **GroupDocs.Metadata.Formats.Document**

Given below example demonstrates how to read track changes (revisions) in Word document



```csharp
// path to the MS Word file
string path = @"c:\download files\CV.docx";

// initialize DocFormat
DocFormat docFormat = new DocFormat(path);

// get revisions
RevisionCollection revisionCollection = docFormat.Revisions;

// get revisions count
Console.WriteLine("Revisions: {0}", revisionCollection.Count);

foreach (Revision revision in revisionCollection)
{
  // display revision type
  Console.WriteLine("Revision -  type: {0}, ", revision.RevisionType);

  // display revision author
  Console.Write("author: {0}, ", revision.Author);

  // display revision date
  Console.Write("date: {0}", revision.DateTime);
}

```

#### Ability to accept or reject revisions in Word format

This feature allows to accept or reject track changes (revisions) in Word document.

##### Public API changes

Added **RevisionType** enum into namespace **GroupDocs.Metadata.Formats.Document**  
Added **Revision** class into namespace **GroupDocs.Metadata.Formats.Document**  
Added **RevisionCollection** class into namespace **GroupDocs.Metadata.Formats.Document**

This example demonstrates how to accept all changes in Word document.



```csharp
// path to the MS Word file
string path = @"c:\download files\CV.docx";

// initialize DocFormat
DocFormat docFormat = new DocFormat(path);

// get revisions
RevisionCollection revisionCollection = docFormat.Revisions;

// accept all revisions
revisionCollection.AcceptAll();

// and commit changes
docFormat.Save();

```

This example demonstrates how to reject all changes in Word document.



```csharp
// path to the MS Word file
string path = @"c:\download files\CV.docx";

// initialize DocFormat
DocFormat docFormat = new DocFormat(path);

// get revisions
RevisionCollection revisionCollection = docFormat.Revisions;

// reject all revisions
revisionCollection.RejectAll();

// and commit changes
docFormat.Save();

```
