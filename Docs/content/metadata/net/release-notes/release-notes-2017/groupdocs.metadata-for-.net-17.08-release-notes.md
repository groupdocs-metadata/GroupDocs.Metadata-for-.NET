---
id: groupdocs-metadata-for-net-17-08-release-notes
url: metadata/net/groupdocs-metadata-for-net-17-08-release-notes
title: GroupDocs.Metadata for .NET 17.08 Release Notes
weight: 7
description: ""
keywords: 
productName: GroupDocs.Metadata for .NET
hideChildren: False
---
{{< alert style="info" >}}This page contains release notes for GroupDocs.Metadata for .NET 17.08.0{{< /alert >}}

## Major Features

There are 2 new features, 2 ehnancements and 1 fix in this regular monthly release. The most notable are:

*   Ability to read CANON maker notes in JPEG image
*   Ability to read Panasonic maker notes in JPEG image
*   Ability to read EXIF maker-notes from Nikon D models (D300, D500, D600, D5100 etc)
*   Ability to read EXIF maker-notes from Sony xperia, cybershot models
*   Xmp metadata is absent after removing EXIF geo-location

## All Changes

| Key | Summary | Category |
| --- | --- | --- |
| METADATANET-1845 | Ability to read EXIF maker-notes from Nikon D models (D300, D500, D600, D5100 etc) | Enhancement |
| METADATANET-1846 | Ability to read EXIF maker-notes from Sony xperia, cybershot models | Enhancement  
 |
| METADATANET-1731 | Ability to read CANON maker notes in JPEG image | New Feature |
| METADATANET-1803 | Ability to read Panasonic maker notes in JPEG image | New Feature |
| METADATANET-1836 | Xmp metadata is absent after removing EXIF geo-location | Bug |

## Public API and Backward Incompatible Changes

{{< alert style="info" >}}This section lists public API changes that were introduced in GroupDocs.Metadata for .NET 17.08.0 It includes not only new and obsoleted public methods, but also a description of any changes in the behavior behind the scenes in GroupDocs.Metadata which may affect existing code. Any behavior introduced that could be seen as a regression and modifies existing behavior is especially important and is documented here.{{< /alert >}}

#### Ability to read EXIF maker-notes from Nikon D models (D300, D500, D600, D5100 etc)

This feature allows to read EXIF maker-notes from Nikon D models (D300, D500, D600, D5100 etc).

##### Public API changes

None

This example demonstrates how to get NIKON makernotes.



```csharp
// path to the jpg file
string path = @"C:\\example.jpg";

// initialize JpegFormat
JpegFormat jpegFormat = new JpegFormat(path);                   
            
// get makernotes
var makernotes = jpegFormat.GetMakernotes();

if (makernotes != null)
{
    // try cast to NikonMakerNotes
    NikonMakerNotes nikonMakerNotes = makernotes as NikonMakerNotes;                
    if (nikonMakerNotes != null)
    {
        // get quality string
        string quality = nikonMakerNotes.Quality;

        // get version
        byte[] version = nikonMakerNotes.MakerNoteVersion;
    }
}

```

#### Ability to read EXIF maker-notes from Sony xperia, cybershot models

This feature allows to read EXIF maker-notes from Sony xperia, cybershot models.

##### Public API changes

None

This example demonstrates how to get SONY makernotes.



```csharp
// path to the jpg file
string path = @"C:\\example.jpg";

// initialize JpegFormat
JpegFormat jpegFormat = new JpegFormat(path);

// get makernotes
var makernotes = jpegFormat.GetMakernotes();

if (makernotes != null)
{
    // try cast to SonyMakerNotes
    SonyMakerNotes sonyMakerNotes = makernotes as SonyMakerNotes;
    if (sonyMakerNotes != null)
    {
        // get color mode
        int? colorMode = sonyMakerNotes.ColorMode;

        // get JPEG quality
        int? jpegQuality = sonyMakerNotes.JPEGQuality;
    }
}


```

#### Ability to read CANON maker notes in JPEG image

This feature allows to read CANON maker notes in JPEG image.

##### Public API changes

Added **CanonMakerNotes** class into namespace **GroupDocs.Metadata.Formats.Image**  
Added **CanonCameraSettings** class into namespace **GroupDocs.Metadata.Formats.Image**

This example demonstrates how to get CANON maker-notes.



```csharp
// path to the jpg file
string path = @"C:\\example.jpg";

// initialize JpegFormat
JpegFormat jpegFormat = new JpegFormat(path);

// get makernotes
var makernotes = jpegFormat.GetMakernotes();

if (makernotes != null)
{
    // try cast to CanonMakerNotes
    CanonMakerNotes canonMakerNotes = makernotes as CanonMakerNotes;
    if (canonMakerNotes != null)
    {
        // get cammera settings
        CanonCameraSettings cameraSettings = canonMakerNotes.CameraSettings;
        if (cameraSettings != null)
        {
            // get lens type
            int lensType = cameraSettings.LensType;

            // get quality
            int quality = cameraSettings.Quality;

            // get all values
            int[] allValues = cameraSettings.Values;
        }

        // get firmware version
        string firmwareVersion = canonMakerNotes.CanonFirmwareVersion;
    }
}

```

#### Ability to read Panasonic maker notes in JPEG image

This feature allows to read Panasonic maker notes in JPEG image.

##### Public API changes

Added **PanasonicMakerNotes** class into namespace **GroupDocs.Metadata.Formats.Image**

This example demonstrates how to get Panasonic makernotes.



```csharp
// path to the jpg file
string path = @"C:\\example.jpg";

// initialize JpegFormat
JpegFormat jpegFormat = new JpegFormat(path);

// get makernotes
var makernotes = jpegFormat.GetMakernotes();

if (makernotes != null)
{
    // try cast to PanasonicMakerNotes
    PanasonicMakerNotes panasonicMakerNotes = makernotes as PanasonicMakerNotes;
    if (panasonicMakerNotes != null)
    {
        // get firmware version
        string firmwareVersion = panasonicMakerNotes.FirmwareVersion;

        // get image quality
        int? imageQuality = panasonicMakerNotes.ImageQuality;

        // get lens type
        string lensType = panasonicMakerNotes.LensType;
    }
}

```

#### Xmp metadata is absent after removing EXIF geo-location

The bug related to absence of XMP metadata after removing EXIF geo-location has been resolved.

##### Public API changes

None

This example demonstrates how to remove EXIF geo-location.



```csharp
// path to the jpg file
string path = @"C:\\example.jpg";

// initialize JpegFormat
JpegFormat jpegFormat = new JpegFormat(path);

// check if JPEG contains XMP metadata
if (jpegFormat.HasXmp)
{
 // remove GPS location
 jpegFormat.RemoveGpsLocation();

 // update Dublin Core format in XMP
 jpegFormat.XmpValues.Schemes.DublinCore.Format = "image/jpeg";

 // and commit changes
 jpegFormat.Save();
}

```
