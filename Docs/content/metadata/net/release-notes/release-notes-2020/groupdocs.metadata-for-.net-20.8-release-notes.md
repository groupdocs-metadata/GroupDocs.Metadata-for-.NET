---
id: groupdocs-metadata-for-net-20-8-release-notes
url: metadata/net/groupdocs-metadata-for-net-20-8-release-notes
title: GroupDocs.Metadata for .NET 20.8 Release Notes
weight: 14
description: ""
keywords: 
productName: GroupDocs.Metadata for .NET
hideChildren: False
---
{{< alert style="info" >}}This page contains release notes for GroupDocs.Metadata for .NET 20.8{{< /alert >}}

## Major Features

  
There are the following features, enhancements and fixes in this release:

*   Implement the ability to add/update EXIF metadata properties of arbitrary types using the search API
*   Implement the ability to add/update XMP metadata properties of arbitrary types using the search API
*   "Compression is not supported" exception is thrown when reading BMP
*   Visio Document version is not supported
*   Exception is thrown when trying to access Inspection Package
*   "Already registered Parameter " exception when reading Presentation file
*   Incorrect image size

## Full List of Issues Covering all Changes in this Release

| Key | Summary | Category |
| --- | --- | --- |
| METADATANET-3432 | Implement the ability to add/update EXIF metadata properties of arbitrary types using the search API              | Improvement |
| METADATANET-3433 | Implement the ability to add/update XMP metadata properties of arbitrary types using the search API               | Improvement |
| METADATANET-3275 | "Compression is not supported" exception is thrown when reading BMP                                               | Bug         |
| METADATANET-3289 | Visio Document version is not supported                                                                           | Bug         |
| METADATANET-3291 | Exception is thrown when trying to access Inspection Package                                                      | Bug         |
| METADATANET-3294 | "Already registered Parameter " exception when reading Presentation file                                          | Bug         |
| METADATANET-3469 | Incorrect image size                                                                                              | Bug         |


## Public API and Backward Incompatible Changes

### Implement the ability to add/update EXIF metadata properties of arbitrary types using the search API

Starting from version 20.8 the GroupDocs.Metadata search engine supports adding and updating  EXIF properties of all types (In previous versions only ASCII properties were supported).

##### Public API changes 

The [ExifGpsPackage.Track](https://apireference.groupdocs.com/metadata/net/groupdocs.metadata.standards.exif/exifgpspackage/properties/track) property has been marked as obsolete. Please use the [GpsTrack](https://apireference.groupdocs.com/metadata/net/groupdocs.metadata.standards.exif/exifgpspackage/properties/gpstrack) property instead.

##### Use cases 

Set an EXIF property having an array type

```csharp
using (Metadata metadata = new Metadata(@"D:\input.tiff"))
{
    IExif root = metadata.GetRootPackage() as IExif;
    if (root != null)
    {
        // Set the EXIF package if it's missing
        if (root.ExifPackage == null)
        {
            root.ExifPackage = new ExifPackage();
        }
 
        // The latitude (as well as longitude) in EXIF is expressed as three rational values giving the degrees, minutes and seconds respectively
        // We set them as three double values
        var latitude = new double[] { 53, 21, 0.50 };
        var longitude = new double[] { 6, 15, 58.17 };
        root.ExifPackage.SetProperties(p => p is TiffTag && ((TiffTag)p).TagID == TiffTagID.GpsLatitude, new PropertyValue(latitude));
        root.ExifPackage.SetProperties(p => p is TiffTag && ((TiffTag)p).TagID == TiffTagID.GpsLongitude, new PropertyValue(longitude));
        metadata.Save(@"D:\output.tiff");
    }
}
 
// Check the output file
using (Metadata metadata = new Metadata(@"D:\output.tiff"))
{
    IExif root = metadata.GetRootPackage() as IExif;
    string format = "{0} deg {1} min {2} sec";
    // All the values are converted to human readable rationals
    Console.WriteLine(format, 
        root.ExifPackage.GpsPackage.Latitude[0],
        root.ExifPackage.GpsPackage.Latitude[1],
        root.ExifPackage.GpsPackage.Latitude[2]);
    Console.WriteLine(format, 
        root.ExifPackage.GpsPackage.Longitude[0],
        root.ExifPackage.GpsPackage.Longitude[1],
        root.ExifPackage.GpsPackage.Longitude[2]);
} 
```

### Implement the ability to add/update XMP metadata properties of arbitrary types using the search API

Starting from version 20.8 the GroupDocs.Metadata search engine supports adding and updating XMP properties of all types (In previous versions only certain scalar types were supported).

##### Public API changes 

None

##### Use cases 

Set an XMP property having an array type

```csharp
using (Metadata metadata = new Metadata(@"D:\input.gif"))
{
    IXmp root = metadata.GetRootPackage() as IXmp;
    if (root != null)
    {
        // add the package if it's missing
        if (root.XmpPackage == null)
        {
            root.XmpPackage = new XmpPacketWrapper();
        }
        // if there is no such scheme in the XMP package we should create it
        if (root.XmpPackage.Schemes.DublinCore == null)
        {
            root.XmpPackage.Schemes.DublinCore = new XmpDublinCorePackage();
        }
        var creators = new string[] { "creator1", "creator2", "creator3" };
        var date = DateTime.Now;
        root.XmpPackage.SetProperties(p => p.Tags.Contains(Tags.Person.Creator), new PropertyValue(creators));
        root.XmpPackage.SetProperties(p => p.Name == "dc:date", new PropertyValue(date));
 
        metadata.Save(@"D:\output.gif");
    }
}
 
// Check the output file
using (Metadata metadata = new Metadata(@"D:\output.gif"))
{
    IXmp root = metadata.GetRootPackage() as IXmp;
     
    foreach (var creator in root.XmpPackage.Schemes.DublinCore.Creators)
    {
        Console.WriteLine(creator);
    }
    foreach (var date in root.XmpPackage.Schemes.DublinCore.Dates)
    {
        Console.WriteLine(date);
    }
}
```
 
Set an XMP-specific value

```csharp
using (Metadata metadata = new Metadata(@"D:\input.gif"))
{
    IXmp root = metadata.GetRootPackage() as IXmp;
    if (root != null)
    {
        // add the package if it's missing
        if (root.XmpPackage == null)
        {
            root.XmpPackage = new XmpPacketWrapper();
        }
        // if there is no such scheme in the XMP package we should create it
        if (root.XmpPackage.Schemes.DublinCore == null)
        {
            root.XmpPackage.Schemes.DublinCore = new XmpDublinCorePackage();
        }
        // Set a lang alt value
        var rights = new XmpLangAlt("Copyright (C) 2011-2020 GroupDocs. All Rights Reserved.");
        root.XmpPackage.SetProperties(p => p.Tags.Contains(Tags.Legal.Copyright), rights);
 
        metadata.Save(@"D:\output.gif");
    }
}
 
// Check the output file
using (Metadata metadata = new Metadata(@"D:\output.gif"))
{
    IXmp root = metadata.GetRootPackage() as IXmp;
    foreach (var right in root.XmpPackage.Schemes.DublinCore.Rights.ToPlatformArray<string>())
    {
        Console.WriteLine(right);
    }
}
```

### Other API changes

The [DicomPackage.LengthValue](https://apireference.groupdocs.com/metadata/net/groupdocs.metadata.formats.image/dicompackage/properties/lengthvalue) property has been marked as obsolete

The [DicomPackage.DicomFound](https://apireference.groupdocs.com/metadata/net/groupdocs.metadata.formats.image/dicompackage/properties/dicomfound) property has been marked as obsolete

 

The support of these properties will be discontinued in future releases



