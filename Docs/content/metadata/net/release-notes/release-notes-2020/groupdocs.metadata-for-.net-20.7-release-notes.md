---
id: groupdocs-metadata-for-net-20-7-release-notes
url: metadata/net/groupdocs-metadata-for-net-20-7-release-notes
title: GroupDocs.Metadata for .NET 20.7 Release Notes
weight: 1
description: ""
keywords: 
productName: GroupDocs.Metadata for .NET
hideChildren: False
---
{{< alert style="info" >}}This page contains release notes for GroupDocs.Metadata for .NET 20.7{{< /alert >}}

## Major Features

  
There are the following features, enhancements and fixes in this release:

*   Implement the ability to work with EXIF metadata in JPEG2000 images
*   Add support for the HEIF/HEIC format
*   Implement the ability to extract metadata from encrypted MS Project files
*   Implement the ability to manage custom properties in Project files. Add support for additional built-in properties

## Full List of Issues Covering all Changes in this Release

| Key | Summary | Category |
| --- | --- | --- |
| METADATANET-2845 | Implement the ability to work with EXIF metadata in JPEG2000 images	                                           | New Feature |
| METADATANET-3387 | Add support for the HEIF/HEIC format	                                                                           | New Feature |
| METADATANET-2843 | Implement the ability to extract metadata from encrypted MS Project files	                                       | Improvement |
| METADATANET-1479 | Implement the ability to manage custom properties in Project files. Add support for additional built-in properties| Improvement |


## Public API and Backward Incompatible Changes

### Implement the ability to work with EXIF metadata in JPEG2000 images 

This new feature allows the user to add, update and remove EXIF metadata
packages in JPEG2000 images.

##### Public API changes 

The
[Jpeg2000RootPackage](https://apireference.groupdocs.com/metadata/net/groupdocs.metadata.formats.image/jpeg2000rootpackage)
class now implements the
[IExif](https://apireference.groupdocs.com/metadata/net/groupdocs.metadata.standards.exif/iexif)
interface

The [ExifPackage](https://apireference.groupdocs.com/metadata/net/groupdocs.metadata.formats.image/jpeg2000rootpackage/properties/exifpackage)
property has been added to
the [Jpeg2000RootPackage](https://apireference.groupdocs.com/metadata/net/groupdocs.metadata.formats.image/jpeg2000rootpackage) class

##### Use cases 

Read EXIF metadata properties from a JPEG2000 image


```csharp
using (Metadata metadata = new Metadata(@"D:\exif.jp2"))
{
    IExif root = metadata.GetRootPackage() as IExif;
    if (root != null && root.ExifPackage != null)
    {
        Console.WriteLine(root.ExifPackage.Artist);
        Console.WriteLine(root.ExifPackage.Copyright);
        Console.WriteLine(root.ExifPackage.ImageDescription);
        Console.WriteLine(root.ExifPackage.Make);
        Console.WriteLine(root.ExifPackage.Model);
        Console.WriteLine(root.ExifPackage.Software);
        Console.WriteLine(root.ExifPackage.ImageWidth);
        Console.WriteLine(root.ExifPackage.ImageLength);

        // ...

        Console.WriteLine(root.ExifPackage.ExifIfdPackage.BodySerialNumber);
        Console.WriteLine(root.ExifPackage.ExifIfdPackage.CameraOwnerName);
        Console.WriteLine(root.ExifPackage.ExifIfdPackage.UserComment);

        // ...

        Console.WriteLine(root.ExifPackage.GpsPackage.Altitude);
        Console.WriteLine(root.ExifPackage.GpsPackage.LatitudeRef);
        Console.WriteLine(root.ExifPackage.GpsPackage.LongitudeRef);

        // ...
    }
}
```

### Add support for the HEIF/HEIC format 

This new feature allows the user to work with HEIF/HEIC images.

##### Public API changes 

The [HeifRootPackage](https://apireference.groupdocs.com/metadata/net/groupdocs.metadata.formats.image/heifrootpackage)
class has been added to
the [GroupDocs.Metadata.Formats.Image](https://apireference.groupdocs.com/metadata/net/groupdocs.metadata.formats.image)
namespace

The Heif item has been added to the
[FileFormat](https://apireference.groupdocs.com/metadata/net/groupdocs.metadata.common/fileformat)
enum

##### Use cases 

Read XMP metadata properties from a HEIC image


```csharp
using (Metadata metadata = new Metadata(@"D:\xmp.heic"))
{
    IXmp root = metadata.GetRootPackage() as IXmp;
    if (root != null && root.XmpPackage != null)
    {
        if (root.XmpPackage.Schemes.XmpBasic != null)
        {
            Console.WriteLine(root.XmpPackage.Schemes.XmpBasic.CreatorTool);
            Console.WriteLine(root.XmpPackage.Schemes.XmpBasic.CreateDate);
            Console.WriteLine(root.XmpPackage.Schemes.XmpBasic.ModifyDate);
            Console.WriteLine(root.XmpPackage.Schemes.XmpBasic.Label);
            Console.WriteLine(root.XmpPackage.Schemes.XmpBasic.Nickname);
            // ...
        }
        if (root.XmpPackage.Schemes.DublinCore != null)
        {
            Console.WriteLine(root.XmpPackage.Schemes.DublinCore.Format);
            Console.WriteLine(root.XmpPackage.Schemes.DublinCore.Coverage);
            Console.WriteLine(root.XmpPackage.Schemes.DublinCore.Identifier);
            Console.WriteLine(root.XmpPackage.Schemes.DublinCore.Source);
            // ...
        }
        if (root.XmpPackage.Schemes.Photoshop != null)
        {
            Console.WriteLine(root.XmpPackage.Schemes.Photoshop.ColorMode);
            Console.WriteLine(root.XmpPackage.Schemes.Photoshop.IccProfile);
            Console.WriteLine(root.XmpPackage.Schemes.Photoshop.Country);
            Console.WriteLine(root.XmpPackage.Schemes.Photoshop.City);
            Console.WriteLine(root.XmpPackage.Schemes.Photoshop.DateCreated);
            // ... 
        }
        // ...
    }
}
```
 

Read EXIF Tags from a HEIC image


```csharp
using (Metadata metadata = new Metadata(@"D:\exif.heic"))
{
    IExif root = metadata.GetRootPackage() as IExif;
    if (root != null && root.ExifPackage != null)
    {
        const string pattern = "{0} = {1}";

        foreach (TiffTag tag in root.ExifPackage.ToList())
        {
            Console.WriteLine(pattern, tag.TagID, tag.Value);
        }

        foreach (TiffTag tag in root.ExifPackage.ExifIfdPackage.ToList())
        {
            Console.WriteLine(pattern, tag.TagID, tag.Value);
        }

        foreach (TiffTag tag in root.ExifPackage.GpsPackage.ToList())
        {
            Console.WriteLine(pattern, tag.TagID, tag.Value);
        }
    }
} 
```


### Implement the ability to extract metadata from encrypted MS Project files 

This improvement allows the user to read password-protected MS Project
files.

##### Public API changes 

None

##### Use cases 

Load a password-protected document


``` csharp
// Specify the password
var loadOptions = new LoadOptions
{
    Password = "123"
};
using (var metadata = new Metadata(@"D:\test.mpp", loadOptions))
{
    // Extract, edit or remove metadata here
} 
```

Please note, the ability to save password-protected MS Project documents
is not implemented yet

### Implement the ability to manage custom properties in Project files. Add support for additional built-in properties 

This improvement extends the list of metadata properties that are
available for reading/updating in MS Project documents.

##### Public API changes 

The
[Manager](https://apireference.groupdocs.com/metadata/net/groupdocs.metadata.formats.document/projectmanagementpackage/properties/manager)
property has been added to the
[ProjectManagementPackage](https://apireference.groupdocs.com/metadata/net/groupdocs.metadata.formats.document/projectmanagementpackage)
class

The
[LastSaved](https://apireference.groupdocs.com/metadata/net/groupdocs.metadata.formats.document/projectmanagementpackage/properties/lastsaved)
property has been added to
the [ProjectManagementPackage](https://apireference.groupdocs.com/metadata/net/groupdocs.metadata.formats.document/projectmanagementpackage)
class

The
[SaveVersion](https://apireference.groupdocs.com/metadata/net/groupdocs.metadata.formats.document/projectmanagementpackage/properties/saveversion)
property has been added to
the [ProjectManagementPackage](https://apireference.groupdocs.com/metadata/net/groupdocs.metadata.formats.document/projectmanagementpackage)
class

The
[LastPrinted](https://apireference.groupdocs.com/metadata/net/groupdocs.metadata.formats.document/projectmanagementpackage/properties/lastprinted)
property has been added to
the [ProjectManagementPackage](https://apireference.groupdocs.com/metadata/net/groupdocs.metadata.formats.document/projectmanagementpackage)
class

The
[Guid](https://apireference.groupdocs.com/metadata/net/groupdocs.metadata.formats.document/projectmanagementpackage/properties/guid)
property has been added to
the [ProjectManagementPackage](https://apireference.groupdocs.com/metadata/net/groupdocs.metadata.formats.document/projectmanagementpackage)
class

The
[Set(string,string)](https://apireference.groupdocs.com/metadata/net/groupdocs.metadata.formats.document.projectmanagementpackage/set/methods/4)
method has been added to
the [ProjectManagementPackage](https://apireference.groupdocs.com/metadata/net/groupdocs.metadata.formats.document/projectmanagementpackage) class

The
[Set(string,double)](https://apireference.groupdocs.com/metadata/net/groupdocs.metadata.formats.document.projectmanagementpackage/set/methods/2)
method has been added to
the [ProjectManagementPackage](https://apireference.groupdocs.com/metadata/net/groupdocs.metadata.formats.document/projectmanagementpackage) class

The
[Set(string,bool)](https://apireference.groupdocs.com/metadata/net/groupdocs.metadata.formats.document/projectmanagementpackage/methods/set)
method has been added to
the [ProjectManagementPackage](https://apireference.groupdocs.com/metadata/net/groupdocs.metadata.formats.document/projectmanagementpackage) class

The
[Set(string,DateTime)](https://apireference.groupdocs.com/metadata/net/groupdocs.metadata.formats.document.projectmanagementpackage/set/methods/1)
method has been added to
the [ProjectManagementPackage](https://apireference.groupdocs.com/metadata/net/groupdocs.metadata.formats.document/projectmanagementpackage) class

The
[Set(string,int)](https://apireference.groupdocs.com/metadata/net/groupdocs.metadata.formats.document.projectmanagementpackage/set/methods/3)
method has been added to
the [ProjectManagementPackage](https://apireference.groupdocs.com/metadata/net/groupdocs.metadata.formats.document/projectmanagementpackage) class

##### Use cases

Read project properties


```csharp
using (Metadata metadata = new Metadata(@"D:\test.mpp"))
{
    var root = metadata.GetRootPackage<ProjectManagementRootPackage>();

    Console.WriteLine(root.DocumentProperties.Manager);
    Console.WriteLine(root.DocumentProperties.LastSaved);
    Console.WriteLine(root.DocumentProperties.SaveVersion);
    Console.WriteLine(root.DocumentProperties.LastPrinted);
    Console.WriteLine(root.DocumentProperties.Guid);

    // ... 
} 
```

 

Read custom metadata properties



``` csharp
using (Metadata metadata = new Metadata(@"D:\test.mpp"))
{
    var root = metadata.GetRootPackage<ProjectManagementRootPackage>();
    var customProperties = root.DocumentProperties.FindProperties(p => !p.Tags.Contains(Tags.Document.BuiltIn));
    foreach (var property in customProperties)
    {
        Console.WriteLine("{0} = {1}", property.Name, property.Value);
    }
}
```


Read even more metadata properties iterating the package as a collection



``` csharp
using (Metadata metadata = new Metadata(@"D:\test.mpp"))
{
    var root = metadata.GetRootPackage<ProjectManagementRootPackage>();

    foreach (var property in root.DocumentProperties)
    {
        Console.WriteLine("{0} = {1}", property.Name, property.Value);
    }
} 
```

 

Update metadata properties


``` csharp
using (Metadata metadata = new Metadata(@"D:\input.mpp"))
{
    var root = metadata.GetRootPackage<ProjectManagementRootPackage>();

    root.DocumentProperties.Set("customProperty1", "some value");
    root.DocumentProperties.Set("customProperty2", 7);
    root.DocumentProperties.Set("customProperty3", true);

    // ...

    metadata.Save(@"D:\output.mpp");
}
```

