---
id: groupdocs-metadata-for-net-21-4-release-notes
url: metadata/net/groupdocs-metadata-for-net-21-4-release-notes
title: GroupDocs.Metadata for .NET 21.4 Release Notes
weight: 9
description: ""
keywords: 
productName: GroupDocs.Metadata for .NET
hideChildren: False
---
{{< alert style="info" >}}This page contains release notes for GroupDocs.Metadata for .NET 21.4{{< /alert >}}

## Major Features

  
There are the following features, enhancements and fixes in this release:

*   Implement metadata property interpreters
*   Implement the ability to edit email fields
*	Image export failed.

## Full List of Issues Covering all Changes in this Release

| Key | Summary | Category |
| --- | --- | --- |
| METADATANET-3752 | Implement metadata property interpreters                                                | New Feature         |
| METADATANET-3758 | Implement the ability to edit email fields                                            	 | Improvement         |
| METADATANET-3751 | Image export failed                              	                                   	 | Bug                 |



## Public API and Backward Incompatible Changes

### Implement metadata property interpreters

This new feature allows the user to get a user-friendly interpretation of a metadata property value. Please refer to [this article]({{< ref "metadata/net/developer-guide/advanced-usage/working-with-interpreted-values.md" >}}) for more information.

##### Public API changes 

The [ValueInterpreter](https://apireference.groupdocs.com/metadata/net/groupdocs.metadata.common/valueinterpreter) class has been added to the [GroupDocs.Metadata.Common](https://apireference.groupdocs.com/metadata/net/groupdocs.metadata.common) namespace

The [IEnumValueInterpreter](https://apireference.groupdocs.com/metadata/net/groupdocs.metadata.common/ienumvalueinterpreter) interface has been added to the [GroupDocs.Metadata.Common](https://apireference.groupdocs.com/metadata/net/groupdocs.metadata.common) namespace

The [InterpretedValue](https://apireference.groupdocs.com/metadata/net/groupdocs.metadata.common/metadataproperty/properties/interpretedvalue) property has been added to the [MetadataProperty](https://apireference.groupdocs.com/metadata/net/groupdocs.metadata.common/metadataproperty) class

The [Descriptor](https://apireference.groupdocs.com/metadata/net/groupdocs.metadata.common/metadataproperty/properties/descriptor) property has been added to the [MetadataProperty](https://apireference.groupdocs.com/metadata/net/groupdocs.metadata.common/metadataproperty) class

The [Interpreter](https://apireference.groupdocs.com/metadata/net/groupdocs.metadata.common/propertydescriptor/properties/interpreter) property has been added to the [PropertyDescriptor](https://apireference.groupdocs.com/metadata/net/groupdocs.metadata.common/propertydescriptor) class

##### Use cases 

Obtain a full list of properties that provide an interpreted value

```csharp
foreach (string file in Directory.GetFiles(Constants.InputPath))
{
    using (Metadata metadata = new Metadata(file))
    {
        if (metadata.FileFormat != FileFormat.Unknown && !metadata.GetDocumentInfo().IsEncrypted)
        {
            Console.WriteLine();
            Console.WriteLine(file);
            var properties = metadata.FindProperties(p => p.InterpretedValue != null);
            foreach (var property in properties)
            {
                Console.WriteLine(property.Name);
                Console.WriteLine(property.Value.RawValue);
                Console.WriteLine(property.InterpretedValue.RawValue);
            }
        }
    }
}
```

### Implement the ability to edit email fields

This improvement allows the user to update some common email fields.

##### Public API changes 

A setter has been added to the [EmailPackage.Subject](https://apireference.groupdocs.com/metadata/net/groupdocs.metadata.formats.email/emailpackage/properties/subject) property

A setter has been added to the [EmailPackage.Recipients](https://apireference.groupdocs.com/metadata/net/groupdocs.metadata.formats.email/emailpackage/properties/recipients) property

A setter has been added to the [EmailPackage.CarbonCopyRecipients](https://apireference.groupdocs.com/metadata/net/groupdocs.metadata.formats.email/emailpackage/properties/carboncopyrecipients) property

A setter has been added to the [EmailPackage.BlindCarbonCopyRecipients](https://apireference.groupdocs.com/metadata/net/groupdocs.metadata.formats.email/emailpackage/properties/blindcarboncopyrecipients) property

##### Use cases 

Update the email subject and recipients

```csharp
using (Metadata metadata = new Metadata(Constants.InputEml))
{
    var root = metadata.GetRootPackage<EmailRootPackage>();
    root.EmailPackage.Recipients = new string[] { "sample@aspose.com" };
    root.EmailPackage.CarbonCopyRecipients = new string[] { "sample@groupdocs.com" };
    root.EmailPackage.Subject = "RE: test subject";
    metadata.Save(Constants.OutputEml);
}
```

### Other API changes

The [KnowPropertyDescriptors](https://apireference.groupdocs.com/metadata/net/groupdocs.metadata.common/metadatapackage/properties/knowpropertydescriptors) property has been marked as obsolete. Please use the [PropertyDescriptors](https://apireference.groupdocs.com/metadata/net/groupdocs.metadata.common/metadatapackage/properties/propertydescriptors) property instead.
