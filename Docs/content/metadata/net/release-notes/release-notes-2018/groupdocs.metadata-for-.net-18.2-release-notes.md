---
id: groupdocs-metadata-for-net-18-2-release-notes
url: metadata/net/groupdocs-metadata-for-net-18-2-release-notes
title: GroupDocs.Metadata for .NET 18.2 Release Notes
weight: 10
description: ""
keywords: 
productName: GroupDocs.Metadata for .NET
hideChildren: False
---
{{< alert style="info" >}}This page contains release notes for GroupDocs.Metadata for .NET 18.2{{< /alert >}}

## Major Features

There are 3 enhancements and 6 new features in this regular monthly release. The most notable are:

*   Performance improvements - better speed of loading and saving EXIF metadata for JPEG and TIFF formats
*   Validate ID3 input metadata before saving in Mp3Format
*   Read additional properties from ID3v2 tag in Mp3Format
*   Ability to update ID3v2 tag using properties in Mp3Format
*   Ability to update ID3v1 tag using properties in Mp3Format
*   Ability to read image cover from EPUB e-book format
*   Ability to read version of EPUB format
*   Ability to read image cover from ID3 audio tag
*   Ability to update or remove image cover from ID3 audio tag in MP3 audio

## All Changes

| Key | Summary | Category |
| --- | --- | --- |
| METADATANET-2155 | Performance improvements - better speed of loading and saving EXIF metadata for JPEG and TIFF formats | Enhancement |
| METADATANET-2157   | Validate ID3 input metadata before saving in Mp3Format | Enhancement |
| METADATANET-2162 | Read additional properties from ID3v2 tag in Mp3Format | Enhancement |
| METADATANET-1230 | Ability to update ID3v2 tag using properties in Mp3Format | New Feature  |
| METADATANET-1231 | Ability to update ID3v1 tag using properties in Mp3Format | New Feature  |
| METADATANET-2119 | Ability to read image cover from EPUB e-book format | New Feature  |
| METADATANET-2147  | Ability to read version of EPUB package | New Feature  |
| METADATANET-2166 | Ability to read image cover from ID3 audio tag | New Feature  |
| METADATANET-2170 | Ability to update or remove image cover from ID3 audio tag in MP3 audio | New Feature  |

## Public API and Backward Incompatible Changes

{{< alert style="info" >}}This section lists public API changes that were introduced in GroupDocs.Metadata for .NET 18.2. It includes not only new and obsoleted public methods, but also a description of any changes in the behaviour behind the scenes in GroupDocs.Metadata which may affect existing code. Any behaviour introduced that could be seen as a regression and modifies existing behaviour is especially important and is documented here.{{< /alert >}}

#### Performance Improvements - Better speed of loading and saving EXIF metadata for JPEG and TIFF formats

##### Description

This enhancement loads and writes EXIF metadata more quickly than in previous versions.

##### Public API changes

None

##### Usecases

Next example just demonstrates how to use EXIF API, all necessary improvements are hidden under the hood.



```csharp
// path to the jpg file
string path = @"C:\\download files\\wallpaper.jpg";

// initialize JpegFormat
JpegFormat jpegFormat = new JpegFormat(path);

// get EXIF data
JpegExifInfo exif = (JpegExifInfo)jpegFormat.ExifValues;

// set artist
exif.Artist = "test artist";

// set the name of the camera's owner
exif.CameraOwnerName = "camera owner's name";

// set description
exif.ImageDescription = "test description";

// set software
exif.Software = "software...";

// commit changes
jpegFormat.Save(@"C:\\download files\\result.jpg");

// and free resources
jpegFormat.Dispose();
```

#### Validate ID3 input metadata before saving in Mp3Format

##### Description

This enhancement allows validating ID3(both v1 and v2) input metadata before saving. Validation prevents to pass invalid data and ensures that metadata will not be broken after saving. Validation API is executed before saving (see FormatBase.Save method) and causes GroupDocsException with appropriate details about invalid field(s).

##### Public API changes

None

##### Usecases

Next example demonstrates an unsuccessful attempt to save ID3 metadata with invalid 'album' and throws GroupDocsException with the message: 'Length could not be greater than 30'.



```csharp
const string filePath = @"C:\download files\Kalimba.mp3";

// init Mp3Format class
using (Mp3Format mp3Format = new Mp3Format(filePath))
{
 // set album but with invalid length
 mp3Format.Id3v1Properties.Album = "this is very looooooooong album name but must be less 30 characters";

 try
 {
  // and commit changes
  mp3Format.Save();
 }
 catch (GroupDocs.Metadata.Exceptions.GroupDocsException e)
 {
  //e.Message is "Property 'album': Length could not be grater then 30"
  Console.WriteLine(e);
 }
}




```

### Read additional properties from ID3v2 tag in Mp3Format

##### Description

This enhancement allows to read next properties from ID3v2 metadata:

*   Subtitle (TIT3 frame)
*   MusicalKey (TKEY frame)
*   LengthInMilliseconds (TLEN frame)
*   OriginalAlbum (TOAL frame)
*   SizeInBytes (TSIZ frame)
*   ISRC (TSRC frame)
*   SoftwareHardware (TSSE frame)
*   PlayCounter (PCNT frame)

##### Public API changes

Added new property **Subtitle** into class **GroupDocs.Metadata.Formats.Audio.Id3v2Tag**  
Added new property **MusicalKey** into class **GroupDocs.Metadata.Formats.Audio.Id3v2Tag**  
Added new property **LengthInMilliseconds** into class **GroupDocs.Metadata.Formats.Audio.Id3v2Tag**  
Added new property **OriginalAlbum** into class **GroupDocs.Metadata.Formats.Audio.Id3v2Tag**  
Added new property **SizeInBytes** into class **GroupDocs.Metadata.Formats.Audio.Id3v2Tag**  
Added new property **ISRC** into class **GroupDocs.Metadata.Formats.Audio.Id3v2Tag**  
Added new property **SoftwareHardware** into class **GroupDocs.Metadata.Formats.Audio.Id3v2Tag**  
Added new property **PlayCounter** into class **GroupDocs.Metadata.Formats.Audio.Id3v2Tag**

##### Usecases

Next example is shown how to read additional ID3v2 properties



```csharp
const string filePath = @"C:\download files\podcast_001.mp3";

// init Mp3Format class
Mp3Format mp3Format = new Mp3Format(filePath);

// get ID3 v2 tag
Id3v2Tag id3v2 = mp3Format.Id3v2;

if (id3v2 != null)
{
 // read sub-title
 Console.WriteLine("Subtitle: {0}", id3v2.Subtitle);

 // read musical key
 Console.WriteLine("Musical key: {0}", id3v2.MusicalKey);

 // read length in milliseconds
 Console.WriteLine("Length in milliseconds: {0}", id3v2.LengthInMilliseconds);

 // read original album
 Console.WriteLine("Original album: {0}", id3v2.OriginalAlbum);

 // read size in bytes. Please note that is present TSIZ tag and may be overrided by invalid value
 Console.WriteLine("Original album: {0}", id3v2.SizeInBytes);

 // read TSRC value
 Console.WriteLine("Original album: {0}", id3v2.ISRC);

 // read TSSE value
 Console.WriteLine("Original album: {0}", id3v2.SoftwareHardware);

 // read PCNT value
 Console.WriteLine("Original album: {0}", id3v2.PlayCounter);
 }

// and close input stream
mp3Format.Dispose();
```

### Ability to update ID3v2 tag using properties in Mp3Format 

##### Description

This feature provides an easy way to update ID3v2 metadata in Mp3Format. Library updates ID3v2 if specific properties were changed in user code. Otherwise - the update will not happen.

##### Public API changes

Added **Id3v2Properties** property into class **GroupDocs.Metadata.Formats.Audio.Mp3Format**

##### Usecases

This example demonstrates how to update ID3v2 metadata using properties



```csharp
const string filePath = @"C:\download files\podcast_001.mp3";

// init Mp3Format class
using (Mp3Format mp3Format = new Mp3Format(filePath))
{
 // get id3v2 tag. It creates new tag if metadata not exist so user does not need to check it by null.
 Id3v2Tag id3Tag = mp3Format.Id3v2Properties;

 // set artist
 id3Tag.Artist = "A-ha";

 // set title
 id3Tag.Title = "Take on me";

 // set band
 id3Tag.Band = "A-ha";

 // set comment
 id3Tag.Comment = "GroupDocs.Metadata creator";

 // set track number
 id3Tag.TrackNumber = "5";

 // set year
 id3Tag.Year = "1986";

 // and commit changes
 mp3Format.Save();
}
```

### Ability to update ID3v1 tag using properties in Mp3Format

##### Description

This feature provides an easy way to update ID3v1 metadata in Mp3Format. Library updates ID3v1 if specific properties were changed in user code. Otherwise - the update will not happen.

##### Public API changes

Added **Id3v1Properties** property into class **GroupDocs.Metadata.Formats.Audio.Mp3Format**

##### Usecases

This example demonstrates how to update ID3v1 metadata using properties



```csharp
const string filePath = @"C:\download files\podcast_001.mp3";

// init Mp3Format class
using (Mp3Format mp3Format = new Mp3Format(filePath))
{
 // get id3v1 tag
 Id3v1Tag id3Tag = mp3Format.Id3v1Properties;

 // set artist
 id3Tag.Artist = "A-ha";

 // set comment
 id3Tag.Comment = "By GroupDocs.Metadata";

 // set title
 id3Tag.Title = "Take on me";

 // set year
 id3Tag.Year = "1986";

 // and commit changes
 mp3Format.Save();
}
```

### Ability to read image cover from EPUB e-book format

##### Description

This feature allows reading image cover from EPUB format

##### Public API changes

Added **GetImageCoverBytes** method into class **GroupDocs.Metadata.Formats.Ebook.ImageFormat.EpubFormat**

##### Usecases

This example demonstrates how to read image cover data from EpubFormat



```csharp
// path to the EPUB file
const string file = @"C:\download files\Jack_London_Biography.epub";

// open EPUB file
using (EpubFormat epub = new EpubFormat(file))
{
 // read image cover as array of bytes
 byte[] imageCoverData = epub.GetImageCoverBytes();

 // check if cover is exist
 if (imageCoverData != null)
 {
  // create stream
  using (MemoryStream stream = new MemoryStream(imageCoverData))
  {
   // get image type
   ImageFormat image = ImageFormat.FromStream(stream);

   // display MIME type
   Console.WriteLine("Image type: {0}", image.MIMEType);

   // display dimensions
   Console.WriteLine("width: {0}, height: {1}", image.Width, image.Height);

   // and store it to the file system
   image.Save(string.Format(@"C:\download files\Jack_London_Biography_Cover.{0}", image.Type));
   }
 }
}
```

### Ability to read version of EPUB package

##### Description

This feature allows reading version of EPUB (2.1, 3.0, 3.1). Version is placed in 'version' attribute of the root of 'package' element

##### Public API changes

Added **Version** property to class **GroupDocs.Metadata.Formats.Ebook.EpubMetadata**

##### Usecases

This example demonstrates how to read version of EPUB format



```csharp
// path to the EPUB file
const string file = @"C:\download files\Jack_London_Biography.epub";

// open EPUB file
using (EpubFormat epub = new EpubFormat(file))
{
 // read EPUB metadata
 EpubMetadata metadata = epub.GetEpubMetadata();

 // and get version
 Console.WriteLine("Version = {0}", metadata.Version);
}
```

### Ability to read image cover from ID3 audio tag 

##### Description

This feature allows reading image cover data from ID3(v2) tag in Mp3Format

##### Public API changes

Added new property **ImageCover** into class **GroupDocs.Metadata.Formats.Audio.Id3v2Tag**

##### Usecases

This example demonstrates how to read image cover bytes from ID3(v2) tag in Mp3Format



```csharp
const string filePath = @"C:\download files\podcast_001.mp3";

// init Mp3Format class
using (Mp3Format mp3Format = new Mp3Format(filePath))
{
 // get id3v2
 var metadata = mp3Format.GetId3v2Tag();

 // check if ID3v2 is exist
 if (metadata == null)
 {
  return;
 }

 // read APIC frames
 var frames = metadata["APIC"];

 if (frames != null && frames.Length == 1)
 {
  // get AttachedPictureFrame
  AttachedPictureFrame picture = (AttachedPictureFrame)frames[0];

  // use 'jpeg' as default extension
  string extension = ".jpeg";
  string mimeType = picture.MIMEType;

  // try resolve extension from MIME
  if (mimeType != null)
  {
   if (mimeType.Contains("jpg"))
   {
     extension = ".jpeg";
   }
   else if (mimeType.Contains("bmp"))
   {
     extension = ".bmp";
   }
   else if (mimeType.Contains("png"))
   {
     extension = ".png";
   }
  }

  // prepare file name
  string file = string.Format(@"C:\download files\podcast_001_cover{0}", extension);

  // and store it to the file system
  System.IO.File.WriteAllBytes(file, picture.PictureData);
 }
}
```

### Ability to update or remove image cover from ID3 audio tag in MP3 audio

##### Description

This feature allows to update/remove image data from ID3(v2) tag in Mp3Format

##### Public API changes

Added **RemoveImageCover** method into **GroupDocs.Metadata.Formats.Audio.Id3v2Tag** class

##### Usecases

This example demonstrates how to remove image data from ID3(v2) tag in Mp3Format



```csharp
const string filePath = @"C:\download files\podcast_001.mp3";
const string outPath = @"C:\download files\podcast_001_nocover.mp3";

// init Mp3Format class
using (Mp3Format mp3Format = new Mp3Format(filePath))
{
 // get id3v2
 var metadata = mp3Format.GetId3v2Tag();

 if (metadata == null)
 {
  return;
 }

 // remove image cover
 metadata.RemoveImageCover();

 // update metadata
 mp3Format.UpdateId3v2(metadata);

 // and store to other file
 mp3Format.Save(outPath);
}
```
