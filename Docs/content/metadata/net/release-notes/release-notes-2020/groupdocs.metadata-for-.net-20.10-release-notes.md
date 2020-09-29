---
id: groupdocs-metadata-for-net-20-10-release-notes
url: metadata/net/groupdocs-metadata-for-net-20-10-release-notes
title: GroupDocs.Metadata for .NET 20.10 Release Notes
weight: 12
description: ""
keywords: 
productName: GroupDocs.Metadata for .NET
hideChildren: False
---
{{< alert style="info" >}}This page contains release notes for GroupDocs.Metadata for .NET 20.10{{< /alert >}}

## Major Features

  
There are the following features, enhancements and fixes in this release:

*   Implement the ability to work with repeatable IPTC properties
*   Implement the ability to generate image previews for EPUB files
*   Implement the ability to generate image previews for supported CAD formats
*   Implement the ability to preview EML and MSG files
*   Exception: Could not read the PSD file

## Full List of Issues Covering all Changes in this Release

| Key | Summary | Category |
| --- | --- | --- |
| METADATANET-2639 | Implement the ability to work with repeatable IPTC properties                   | Improvement |
| METADATANET-3547 | Implement the ability to generate image previews for EPUB files                 | Improvement |
| METADATANET-3546 | Implement the ability to generate image previews for supported CAD formats      | Improvement |
| METADATANET-3553 | Implement the ability to preview EML and MSG files                              | Improvement |
| METADATANET-3280 | Exception: Could not read the PSD file                                          | Bug         |




## Public API and Backward Incompatible Changes

### Implement the ability to work with repeatable IPTC properties

This improvement allows the user to add multiple datasets with the same number to an IPTC record

##### Public API changes 

The [ByLines](https://apireference.groupdocs.com/metadata/net/groupdocs.metadata.standards.iptc/iptcapplicationrecord/properties/bylines) property has been added to the [IptcApplicationRecord](https://apireference.groupdocs.com/metadata/net/groupdocs.metadata.standards.iptc/iptcapplicationrecord) class

The [ByLineTitles](https://apireference.groupdocs.com/metadata/net/groupdocs.metadata.standards.iptc/iptcapplicationrecord/properties/bylinetitles) property has been added to the [IptcApplicationRecord](https://apireference.groupdocs.com/metadata/net/groupdocs.metadata.standards.iptc/iptcapplicationrecord) class

The [ContentLocationCodes](https://apireference.groupdocs.com/metadata/net/groupdocs.metadata.standards.iptc/iptcapplicationrecord/properties/contentlocationcodes) property has been added to the [IptcApplicationRecord](https://apireference.groupdocs.com/metadata/net/groupdocs.metadata.standards.iptc/iptcapplicationrecord) class

The [ContentLocationNames](https://apireference.groupdocs.com/metadata/net/groupdocs.metadata.standards.iptc/iptcapplicationrecord/properties/contentlocationnames) property has been added to the [IptcApplicationRecord](https://apireference.groupdocs.com/metadata/net/groupdocs.metadata.standards.iptc/iptcapplicationrecord) class

The [ReferenceDates](https://apireference.groupdocs.com/metadata/net/groupdocs.metadata.standards.iptc/iptcapplicationrecord/properties/referencedates) property has been added to the [IptcApplicationRecord](https://apireference.groupdocs.com/metadata/net/groupdocs.metadata.standards.iptc/iptcapplicationrecord) class

The [Contacts](https://apireference.groupdocs.com/metadata/net/groupdocs.metadata.standards.iptc/iptcapplicationrecord/properties/contacts) property has been added to the [IptcApplicationRecord](https://apireference.groupdocs.com/metadata/net/groupdocs.metadata.standards.iptc/iptcapplicationrecord) class

The [AllKeywords](https://apireference.groupdocs.com/metadata/net/groupdocs.metadata.standards.iptc/iptcapplicationrecord/properties/allkeywords) property has been added to the [IptcApplicationRecord](https://apireference.groupdocs.com/metadata/net/groupdocs.metadata.standards.iptc/iptcapplicationrecord) class

The [Destinations](https://apireference.groupdocs.com/metadata/net/groupdocs.metadata.standards.iptc/iptcenveloperecord/properties/destinations) property has been added to the [IptcEnvelopeRecord](https://apireference.groupdocs.com/metadata/net/groupdocs.metadata.standards.iptc/iptcenveloperecord) class

The [ProductIds](https://apireference.groupdocs.com/metadata/net/groupdocs.metadata.standards.iptc/iptcenveloperecord/properties/productids) property has been added to the [IptcEnvelopeRecord](https://apireference.groupdocs.com/metadata/net/groupdocs.metadata.standards.iptc/iptcenveloperecord) class

The [Add](https://apireference.groupdocs.com/metadata/net/groupdocs.metadata.standards.iptc/iptcrecordset/methods/add) method has been added to the [IptcRecordSet](https://apireference.groupdocs.com/metadata/net/groupdocs.metadata.standards.iptc/iptcrecordset) class

##### Use cases 

Read repeatable IPTC datasets

```csharp
using (Metadata metadata = new Metadata(@"D:\input.psd"))
{
    IIptc root = metadata.GetRootPackage() as IIptc;
    if (root != null && root.IptcPackage != null)
    {
        foreach (var dataSet in root.IptcPackage.ToDataSetList())
        {
            // Check if the dataset is repeatable
            if (dataSet.Value.Type == MetadataPropertyType.PropertyValueArray)
            {
                Console.WriteLine(dataSet.RecordNumber);
                Console.WriteLine(dataSet.DataSetNumber);
                Console.WriteLine(dataSet.AlternativeName);
                foreach (var value in dataSet.Value.ToArray<PropertyValue>())
                {
                    Console.Write("{0}, ", value);
                }
                Console.WriteLine();
            }
        }
    }
}
```

Add repeatable IPTC datasets

```csharp
using (Metadata metadata = new Metadata(@"D:\input.psd"))
{
    IIptc root = (IIptc)metadata.GetRootPackage();
    // Set the IPTC package if it's missing
    if (root.IptcPackage == null)
    {
        root.IptcPackage = new IptcRecordSet();
    }
 
    root.IptcPackage.Add(new IptcDataSet((byte)IptcRecordType.ApplicationRecord, (byte)IptcApplicationRecordDataSet.Keywords, "keyword 1"));
    root.IptcPackage.Add(new IptcDataSet((byte)IptcRecordType.ApplicationRecord, (byte)IptcApplicationRecordDataSet.Keywords, "keyword 2"));
    root.IptcPackage.Add(new IptcDataSet((byte)IptcRecordType.ApplicationRecord, (byte)IptcApplicationRecordDataSet.Keywords, "keyword 3"));
 
    metadata.Save(@"D:\output.psd");
}
 
// Check the output file
using (Metadata metadata = new Metadata(@"D:\output.psd"))
{
    IIptc root = (IIptc)metadata.GetRootPackage();
    var keywordsProperty = root.IptcPackage.ApplicationRecord[(byte)IptcApplicationRecordDataSet.Keywords];
    foreach (var value in keywordsProperty.Value.ToArray<PropertyValue>())
    {
        Console.WriteLine(value);
    }
} 
```

### Implement the ability to generate image previews for EPUB files

This improvement allows the user to generate image previews for EPUB files

##### Public API changes 

None

##### Use cases 

[Generate document preview]({{< ref "metadata/net/developer-guide/basic-usage/generate-document-preview.md" >}})

### Implement the ability to generate image previews for supported CAD formats

This improvement allows the user to generate image previews for DWG and DXF files

##### Public API changes 

None

##### Use cases 

[Generate document preview]({{< ref "metadata/net/developer-guide/basic-usage/generate-document-preview.md" >}})

### Implement the ability to preview EML and MSG files

This improvement allows the user to generate image previews for EML and MSG files

##### Public API changes 

None

##### Use cases 

[Generate document preview]({{< ref "metadata/net/developer-guide/basic-usage/generate-document-preview.md" >}})