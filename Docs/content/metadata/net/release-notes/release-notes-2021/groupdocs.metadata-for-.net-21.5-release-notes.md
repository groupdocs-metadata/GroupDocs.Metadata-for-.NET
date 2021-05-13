---
id: groupdocs-metadata-for-net-21-5-release-notes
url: metadata/net/groupdocs-metadata-for-net-21-5-release-notes
title: GroupDocs.Metadata for .NET 21.5 Release Notes
weight: 8
description: ""
keywords: 
productName: GroupDocs.Metadata for .NET
hideChildren: False
---
{{< alert style="info" >}}This page contains release notes for GroupDocs.Metadata for .NET 21.5{{< /alert >}}

## Major Features

  
There are the following features, enhancements and fixes in this release:

*   Implement the ability to edit EPUB properties
*   Implement the ability to edit DublinCore metadata properties in EPUB
*	Implement the ability to edit DXF metadata properties
*	Reduce the amount of resources consumed by EPUB rendering process

## Full List of Issues Covering all Changes in this Release

| Key | Summary | Category |
| --- | --- | --- |
| METADATANET-3780 | Implement the ability to edit EPUB properties                                                | Improvement         |
| METADATANET-3800 | Implement the ability to edit DublinCore metadata properties in EPUB                         | Improvement         |
| METADATANET-3801 | Implement the ability to edit DXF metadata properties                                        | Improvement         |
| METADATANET-3803 | Reduce the amount of resources consumed by EPUB rendering process                            | Bug                 |



## Public API and Backward Incompatible Changes

### Implement the ability to edit EPUB properties

This improvement allows the user to update and remove EPUB metadata properties.

##### Public API changes 

The [Abstract](https://apireference.groupdocs.com/metadata/net/groupdocs.metadata.formats.ebook/epubpackage/properties/abstract) property has been added to the [EpubPackage](https://apireference.groupdocs.com/metadata/net/groupdocs.metadata.formats.ebook/epubpackage) class

The [AccessRights](https://apireference.groupdocs.com/metadata/net/groupdocs.metadata.formats.ebook/epubpackage/properties/accessRights) property has been added to the [EpubPackage](https://apireference.groupdocs.com/metadata/net/groupdocs.metadata.formats.ebook/epubpackage) class

The [AccrualMethod](https://apireference.groupdocs.com/metadata/net/groupdocs.metadata.formats.ebook/epubpackage/properties/accrualMethod) property has been added to the [EpubPackage](https://apireference.groupdocs.com/metadata/net/groupdocs.metadata.formats.ebook/epubpackage) class

The [AccrualPeriodicity](https://apireference.groupdocs.com/metadata/net/groupdocs.metadata.formats.ebook/epubpackage/properties/accrualPeriodicity) property has been added to the [EpubPackage](https://apireference.groupdocs.com/metadata/net/groupdocs.metadata.formats.ebook/epubpackage) class

The [AccrualPolicy](https://apireference.groupdocs.com/metadata/net/groupdocs.metadata.formats.ebook/epubpackage/properties/accrualPolicy) property has been added to the [EpubPackage](https://apireference.groupdocs.com/metadata/net/groupdocs.metadata.formats.ebook/epubpackage) class

The [Alternative](https://apireference.groupdocs.com/metadata/net/groupdocs.metadata.formats.ebook/epubpackage/properties/alternative) property has been added to the [EpubPackage](https://apireference.groupdocs.com/metadata/net/groupdocs.metadata.formats.ebook/epubpackage) class

The [Audience](https://apireference.groupdocs.com/metadata/net/groupdocs.metadata.formats.ebook/epubpackage/properties/audience) property has been added to the [EpubPackage](https://apireference.groupdocs.com/metadata/net/groupdocs.metadata.formats.ebook/epubpackage) class

The [Available](https://apireference.groupdocs.com/metadata/net/groupdocs.metadata.formats.ebook/epubpackage/properties/available) property has been added to the [EpubPackage](https://apireference.groupdocs.com/metadata/net/groupdocs.metadata.formats.ebook/epubpackage) class

The [BibliographicCitation](https://apireference.groupdocs.com/metadata/net/groupdocs.metadata.formats.ebook/epubpackage/properties/bibliographicCitation) property has been added to the [EpubPackage](https://apireference.groupdocs.com/metadata/net/groupdocs.metadata.formats.ebook/epubpackage) class

The [ConformsTo](https://apireference.groupdocs.com/metadata/net/groupdocs.metadata.formats.ebook/epubpackage/properties/conformsTo) property has been added to the [EpubPackage](https://apireference.groupdocs.com/metadata/net/groupdocs.metadata.formats.ebook/epubpackage) class

The [Contributor](https://apireference.groupdocs.com/metadata/net/groupdocs.metadata.formats.ebook/epubpackage/properties/contributor) property has been added to the [EpubPackage](https://apireference.groupdocs.com/metadata/net/groupdocs.metadata.formats.ebook/epubpackage) class

The [Coverage](https://apireference.groupdocs.com/metadata/net/groupdocs.metadata.formats.ebook/epubpackage/properties/coverage) property has been added to the [EpubPackage](https://apireference.groupdocs.com/metadata/net/groupdocs.metadata.formats.ebook/epubpackage) class

The [Created](https://apireference.groupdocs.com/metadata/net/groupdocs.metadata.formats.ebook/epubpackage/properties/created) property has been added to the [EpubPackage](https://apireference.groupdocs.com/metadata/net/groupdocs.metadata.formats.ebook/epubpackage) class

The [Creator](https://apireference.groupdocs.com/metadata/net/groupdocs.metadata.formats.ebook/epubpackage/properties/creator) property has been added to the [EpubPackage](https://apireference.groupdocs.com/metadata/net/groupdocs.metadata.formats.ebook/epubpackage) class

The [Date](https://apireference.groupdocs.com/metadata/net/groupdocs.metadata.formats.ebook/epubpackage/properties/date) property has been added to the [EpubPackage](https://apireference.groupdocs.com/metadata/net/groupdocs.metadata.formats.ebook/epubpackage) class

The [DateAccepted](https://apireference.groupdocs.com/metadata/net/groupdocs.metadata.formats.ebook/epubpackage/properties/dateAccepted) property has been added to the [EpubPackage](https://apireference.groupdocs.com/metadata/net/groupdocs.metadata.formats.ebook/epubpackage) class

The [DateCopyrighted](https://apireference.groupdocs.com/metadata/net/groupdocs.metadata.formats.ebook/epubpackage/properties/dateCopyrighted) property has been added to the [EpubPackage](https://apireference.groupdocs.com/metadata/net/groupdocs.metadata.formats.ebook/epubpackage) class

The [DateSubmitted](https://apireference.groupdocs.com/metadata/net/groupdocs.metadata.formats.ebook/epubpackage/properties/dateSubmitted) property has been added to the [EpubPackage](https://apireference.groupdocs.com/metadata/net/groupdocs.metadata.formats.ebook/epubpackage) class

The [Description](https://apireference.groupdocs.com/metadata/net/groupdocs.metadata.formats.ebook/epubpackage/properties/description) property has been added to the [EpubPackage](https://apireference.groupdocs.com/metadata/net/groupdocs.metadata.formats.ebook/epubpackage) class

The [EducationLevel](https://apireference.groupdocs.com/metadata/net/groupdocs.metadata.formats.ebook/epubpackage/properties/educationLevel) property has been added to the [EpubPackage](https://apireference.groupdocs.com/metadata/net/groupdocs.metadata.formats.ebook/epubpackage) class

The [Extent](https://apireference.groupdocs.com/metadata/net/groupdocs.metadata.formats.ebook/epubpackage/properties/extent) property has been added to the [EpubPackage](https://apireference.groupdocs.com/metadata/net/groupdocs.metadata.formats.ebook/epubpackage) class

The [Format](https://apireference.groupdocs.com/metadata/net/groupdocs.metadata.formats.ebook/epubpackage/properties/format) property has been added to the [EpubPackage](https://apireference.groupdocs.com/metadata/net/groupdocs.metadata.formats.ebook/epubpackage) class

The [HasFormat](https://apireference.groupdocs.com/metadata/net/groupdocs.metadata.formats.ebook/epubpackage/properties/hasFormat) property has been added to the [EpubPackage](https://apireference.groupdocs.com/metadata/net/groupdocs.metadata.formats.ebook/epubpackage) class

The [HasPart](https://apireference.groupdocs.com/metadata/net/groupdocs.metadata.formats.ebook/epubpackage/properties/hasPart) property has been added to the [EpubPackage](https://apireference.groupdocs.com/metadata/net/groupdocs.metadata.formats.ebook/epubpackage) class

The [HasVersion](https://apireference.groupdocs.com/metadata/net/groupdocs.metadata.formats.ebook/epubpackage/properties/hasVersion) property has been added to the [EpubPackage](https://apireference.groupdocs.com/metadata/net/groupdocs.metadata.formats.ebook/epubpackage) class

The [Identifier](https://apireference.groupdocs.com/metadata/net/groupdocs.metadata.formats.ebook/epubpackage/properties/identifier) property has been added to the [EpubPackage](https://apireference.groupdocs.com/metadata/net/groupdocs.metadata.formats.ebook/epubpackage) class

The [InstructionalMethod](https://apireference.groupdocs.com/metadata/net/groupdocs.metadata.formats.ebook/epubpackage/properties/instructionalMethod) property has been added to the [EpubPackage](https://apireference.groupdocs.com/metadata/net/groupdocs.metadata.formats.ebook/epubpackage) class

The [IsFormatOf](https://apireference.groupdocs.com/metadata/net/groupdocs.metadata.formats.ebook/epubpackage/properties/isFormatOf) property has been added to the [EpubPackage](https://apireference.groupdocs.com/metadata/net/groupdocs.metadata.formats.ebook/epubpackage) class

The [IsPartOf](https://apireference.groupdocs.com/metadata/net/groupdocs.metadata.formats.ebook/epubpackage/properties/isPartOf) property has been added to the [EpubPackage](https://apireference.groupdocs.com/metadata/net/groupdocs.metadata.formats.ebook/epubpackage) class

The [IsReferencedBy](https://apireference.groupdocs.com/metadata/net/groupdocs.metadata.formats.ebook/epubpackage/properties/isReferencedBy) property has been added to the [EpubPackage](https://apireference.groupdocs.com/metadata/net/groupdocs.metadata.formats.ebook/epubpackage) class

The [IsReplacedBy](https://apireference.groupdocs.com/metadata/net/groupdocs.metadata.formats.ebook/epubpackage/properties/isReplacedBy) property has been added to the [EpubPackage](https://apireference.groupdocs.com/metadata/net/groupdocs.metadata.formats.ebook/epubpackage) class

The [IsRequiredBy](https://apireference.groupdocs.com/metadata/net/groupdocs.metadata.formats.ebook/epubpackage/properties/isRequiredBy) property has been added to the [EpubPackage](https://apireference.groupdocs.com/metadata/net/groupdocs.metadata.formats.ebook/epubpackage) class

The [Issued](https://apireference.groupdocs.com/metadata/net/groupdocs.metadata.formats.ebook/epubpackage/properties/issued) property has been added to the [EpubPackage](https://apireference.groupdocs.com/metadata/net/groupdocs.metadata.formats.ebook/epubpackage) class

The [IsVersionOf](https://apireference.groupdocs.com/metadata/net/groupdocs.metadata.formats.ebook/epubpackage/properties/isVersionOf) property has been added to the [EpubPackage](https://apireference.groupdocs.com/metadata/net/groupdocs.metadata.formats.ebook/epubpackage) class

The [Language](https://apireference.groupdocs.com/metadata/net/groupdocs.metadata.formats.ebook/epubpackage/properties/language) property has been added to the [EpubPackage](https://apireference.groupdocs.com/metadata/net/groupdocs.metadata.formats.ebook/epubpackage) class

The [License](https://apireference.groupdocs.com/metadata/net/groupdocs.metadata.formats.ebook/epubpackage/properties/license) property has been added to the [EpubPackage](https://apireference.groupdocs.com/metadata/net/groupdocs.metadata.formats.ebook/epubpackage) class

The [Mediator](https://apireference.groupdocs.com/metadata/net/groupdocs.metadata.formats.ebook/epubpackage/properties/mediator) property has been added to the [EpubPackage](https://apireference.groupdocs.com/metadata/net/groupdocs.metadata.formats.ebook/epubpackage) class

The [Medium](https://apireference.groupdocs.com/metadata/net/groupdocs.metadata.formats.ebook/epubpackage/properties/medium) property has been added to the [EpubPackage](https://apireference.groupdocs.com/metadata/net/groupdocs.metadata.formats.ebook/epubpackage) class

The [Modified](https://apireference.groupdocs.com/metadata/net/groupdocs.metadata.formats.ebook/epubpackage/properties/modified) property has been added to the [EpubPackage](https://apireference.groupdocs.com/metadata/net/groupdocs.metadata.formats.ebook/epubpackage) class

The [Provenance](https://apireference.groupdocs.com/metadata/net/groupdocs.metadata.formats.ebook/epubpackage/properties/provenance) property has been added to the [EpubPackage](https://apireference.groupdocs.com/metadata/net/groupdocs.metadata.formats.ebook/epubpackage) class

The [Publisher](https://apireference.groupdocs.com/metadata/net/groupdocs.metadata.formats.ebook/epubpackage/properties/publisher) property has been added to the [EpubPackage](https://apireference.groupdocs.com/metadata/net/groupdocs.metadata.formats.ebook/epubpackage) class

The [References](https://apireference.groupdocs.com/metadata/net/groupdocs.metadata.formats.ebook/epubpackage/properties/references) property has been added to the [EpubPackage](https://apireference.groupdocs.com/metadata/net/groupdocs.metadata.formats.ebook/epubpackage) class

The [Relation](https://apireference.groupdocs.com/metadata/net/groupdocs.metadata.formats.ebook/epubpackage/properties/relation) property has been added to the [EpubPackage](https://apireference.groupdocs.com/metadata/net/groupdocs.metadata.formats.ebook/epubpackage) class

The [Replaces](https://apireference.groupdocs.com/metadata/net/groupdocs.metadata.formats.ebook/epubpackage/properties/replaces) property has been added to the [EpubPackage](https://apireference.groupdocs.com/metadata/net/groupdocs.metadata.formats.ebook/epubpackage) class

The [Requires](https://apireference.groupdocs.com/metadata/net/groupdocs.metadata.formats.ebook/epubpackage/properties/requires) property has been added to the [EpubPackage](https://apireference.groupdocs.com/metadata/net/groupdocs.metadata.formats.ebook/epubpackage) class

The [Rights](https://apireference.groupdocs.com/metadata/net/groupdocs.metadata.formats.ebook/epubpackage/properties/rights) property has been added to the [EpubPackage](https://apireference.groupdocs.com/metadata/net/groupdocs.metadata.formats.ebook/epubpackage) class

The [RightsHolder](https://apireference.groupdocs.com/metadata/net/groupdocs.metadata.formats.ebook/epubpackage/properties/rightsHolder) property has been added to the [EpubPackage](https://apireference.groupdocs.com/metadata/net/groupdocs.metadata.formats.ebook/epubpackage) class

The [Source](https://apireference.groupdocs.com/metadata/net/groupdocs.metadata.formats.ebook/epubpackage/properties/source) property has been added to the [EpubPackage](https://apireference.groupdocs.com/metadata/net/groupdocs.metadata.formats.ebook/epubpackage) class

The [Spatial](https://apireference.groupdocs.com/metadata/net/groupdocs.metadata.formats.ebook/epubpackage/properties/spatial) property has been added to the [EpubPackage](https://apireference.groupdocs.com/metadata/net/groupdocs.metadata.formats.ebook/epubpackage) class

The [Subject](https://apireference.groupdocs.com/metadata/net/groupdocs.metadata.formats.ebook/epubpackage/properties/subject) property has been added to the [EpubPackage](https://apireference.groupdocs.com/metadata/net/groupdocs.metadata.formats.ebook/epubpackage) class

The [TableOfContents](https://apireference.groupdocs.com/metadata/net/groupdocs.metadata.formats.ebook/epubpackage/properties/tableOfContents) property has been added to the [EpubPackage](https://apireference.groupdocs.com/metadata/net/groupdocs.metadata.formats.ebook/epubpackage) class

The [Temporal](https://apireference.groupdocs.com/metadata/net/groupdocs.metadata.formats.ebook/epubpackage/properties/temporal) property has been added to the [EpubPackage](https://apireference.groupdocs.com/metadata/net/groupdocs.metadata.formats.ebook/epubpackage) class

The [Title](https://apireference.groupdocs.com/metadata/net/groupdocs.metadata.formats.ebook/epubpackage/properties/title) property has been added to the [EpubPackage](https://apireference.groupdocs.com/metadata/net/groupdocs.metadata.formats.ebook/epubpackage) class

The [Type](https://apireference.groupdocs.com/metadata/net/groupdocs.metadata.formats.ebook/epubpackage/properties/type) property has been added to the [EpubPackage](https://apireference.groupdocs.com/metadata/net/groupdocs.metadata.formats.ebook/epubpackage) class

The [Valid](https://apireference.groupdocs.com/metadata/net/groupdocs.metadata.formats.ebook/epubpackage/properties/valid) property has been added to the [EpubPackage](https://apireference.groupdocs.com/metadata/net/groupdocs.metadata.formats.ebook/epubpackage) class


##### Use cases 

Update EPUB metadata properties

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

### Implement the ability to edit DublinCore metadata properties in EPUB

This improvement allows the user to edit DublinCore metadata properties stored in an EPUB file.

##### Public API changes 

None

##### Use cases 

Update DublinCore metadata properties stored in an EPUB file

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

### Implement the ability to edit DXF metadata properties

This improvement allows the user to edit metadata properties stored in a DXF file.

##### Public API changes 

None

##### Use cases 

Update DXF metadata properties

```csharp
using (Metadata metadata = new Metadata(Constants.InputDxf))
{
    var root = metadata.GetRootPackage<CadRootPackage>();
 
    root.CadPackage.SetProperties(p => p.Name == "Author", new PropertyValue("GroupDocs"));
    root.CadPackage.SetProperties(p => p.Name == "Comments", new PropertyValue("test comment"));
    root.CadPackage.SetProperties(p => p.Name == "HyperlinkBase", new PropertyValue("test hyperlink base"));
    root.CadPackage.SetProperties(p => p.Name == "Keywords", new PropertyValue("test keywords"));
    root.CadPackage.SetProperties(p => p.Name == "LastSavedBy", new PropertyValue("test editor"));
    root.CadPackage.SetProperties(p => p.Name == "RevisionNumber", new PropertyValue("test revision number"));
    root.CadPackage.SetProperties(p => p.Name == "Subject", new PropertyValue("test subject"));
    root.CadPackage.SetProperties(p => p.Name == "Title", new PropertyValue("test title"));
    root.CadPackage.SetProperties(p => p.Name == "CreatedDateTime", new PropertyValue(DateTime.Now.AddDays(-1)));
    root.CadPackage.SetProperties(p => p.Name == "ModifiedDateTime", new PropertyValue(DateTime.Now));
 
    metadata.Save(Constants.OutputDxf);
}
```
