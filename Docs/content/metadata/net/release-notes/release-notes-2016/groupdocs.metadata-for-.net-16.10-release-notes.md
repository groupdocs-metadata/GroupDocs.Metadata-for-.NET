---
id: groupdocs-metadata-for-net-16-10-release-notes
url: metadata/net/groupdocs-metadata-for-net-16-10-release-notes
title: GroupDocs.Metadata for .NET 16.10 Release Notes
weight: 3
description: ""
keywords: 
productName: GroupDocs.Metadata for .NET
hideChildren: False
---
{{< alert style="info" >}}
This page contains release notes for [GroupDocs.Metadata for .NET 16.10.0](http://downloads.groupdocs.com/metadata/net/new-releases/groupdocs.metadata-for-.net-16.10.0/)
{{< /alert >}}

## Major Features

There are 8 features and 1 enhancement in this regular monthly release. The most notable are:

*   Implement wav audio format. Ability to read WAV audio details
*   Ability to read IPTC metadata in TIFF format
*   Ability to read IPTC metadata in PSD format
*   Ability to read Lyrics3 tag in Mp3 format
*   Ability to update ID3v1 tag in Mp3 format
*   Ability to read Image Resource Blocks (native PSD metadata) in Photoshop format
*   Ability to remove Photoshop metadata in Jpeg format
*   Ability to read Image Resource Blocks (native PSD metadata) in Jpeg format
*   IPTC reader improvements - scan all image resource blocks to find IPTC metadata in JPEG format

## All Changes

| Key | Summary | Category |
| --- | --- | --- |
| METADATANET-1172 | IPTC reader improvements - scan all image resource blocks to find IPTC metadata in JPEG format | Enhancement |
| METADATANET-691 | Implement wav audio format. Ability to read WAV audio details | New feature |
| METADATANET-1043 | Ability to read IPTC metadata in TIFF format | New feature |
| METADATANET-1044 | Ability to read IPTC metadata in PSD format | New feature |
| METADATANET-1116 | Ability to read Lyrics3 tag in Mp3 format | New feature |
| METADATANET-1118 | Ability to update ID3v1 tag in Mp3 format | New feature |
| METADATANET-1170 | Ability to read Image Resource Blocks (native PSD metadata) in Photoshop format | New feature |
| METADATANET-1171 | Ability to remove Photoshop metadata in Jpeg format | New feature |
| METADATANET-1174 | Ability to read Image Resource Blocks (native PSD metadata) in Jpeg format | New feature |

## Public API and Backward Incompatible Changes

{{< alert style="info" >}}This section lists public API changes that were introduced in GroupDocs.Metadata for .NET 16.10.0. It includes not only new and obsoleted public methods, but also a description of any changes in the behavior behind the scenes in GroupDocs.Metadata which may affect existing code. Any behavior introduced that could be seen as a regression and modifies existing behavior is especially important and is documented here.{{< /alert >}}

#### Working with WAV Format

Detect WAV Fromat



```csharp
 // path to the input directory
string dir = @"C:\\download files";

// get all files inside directory
string[] files = Directory.GetFiles(dir);

foreach (string path in files)
{
 // detect format
 FormatBase format = GroupDocs.Metadata.Tools.FormatFactory.RecognizeFormat(path);

 if (format == null)
 {
  // skip unsupported format
  continue;
 }

  if (format.Type == DocumentType.Wav)
  {
    Console.WriteLine("File {0} has WAV format", Path.GetFileName(path));
  }
}


```

Read Audio Details in WAV Format

```csharp
const string filePath = @"C:\download files\sample.wav";

// init WavFormat class
WavFormat wavFormat = new WavFormat(filePath);

// get audio info
WavAudioInfo audioInfo = wavFormat.AudioInfo;

// display bits per sample
Console.WriteLine("Bits per sample: {0}", audioInfo.BitsPerSample);

// display audio format version
Console.WriteLine("Audio format: {0}", audioInfo.AudioFormat);

// display number of channels
Console.WriteLine("Number of channels: {0}", audioInfo.NumberOfChannels);

// display sample rate
Console.WriteLine("Sample rate: {0}", audioInfo.SampleRate);


```

#### Read IPTC Metadata in TIFF Format



```csharp
 // path to the tiff file
string path = @"C:\\example.tif";

// initialize TiffFormat
TiffFormat tiffFormat = new TiffFormat(path);

// check if TIFF contains IPTC metadata
if (tiffFormat.HasIptc)
{
 // get iptc collection
 IptcCollection iptc = tiffFormat.GetIptc();

 // and display it
 foreach (IptcProperty iptcProperty in iptc)
 {
  Console.Write("Tag id: {0}, name: {1}", iptcProperty.TagId, iptcProperty.Name);
 }
}


```

#### Read IPTC Metadata in PSD Format



```csharp
// path to the tiff file
string path = @"C:\\example.tif";

// initialize PsdFormat
PsdFormat psdFormat = new PsdFormat(path);

// check if PSD contains IPTC metadata
if (psdFormat.HasIptc)
{
 // get iptc collection
 IptcCollection iptc = psdFormat.GetIptc();

 // and display it
 foreach (IptcProperty iptcProperty in iptc)
 {
  Console.Write("Tag id: {0}, name: {1}", iptcProperty.TagId, iptcProperty.Name);
 }
}


```

#### Read Lyrics3 Tag in Mp3 Format



```csharp
// path to the input directory
string dir = @"C:\\download files";

// get all files inside directory
string[] files = Directory.GetFiles(dir, "*.mp3");

foreach (string file in files)
{
 // initialize Mp3Format. If file is not Mp3 then appropriate exception will throw.
 Mp3Format mp3Format = new Mp3Format(file);

 // get Lyrics3 v2.00 tag
 Lyrics3Tag lyrics3Tag = mp3Format.Lyrics3v2;

 // check if Lyrics3 is presented. It could be absent.
 if (lyrics3Tag != null)
 {
   // Display defined tag values
   Console.WriteLine("Album: {0}", lyrics3Tag.Album);
   Console.WriteLine("Artist: {0}", lyrics3Tag.Artist);
   Console.WriteLine("Track: {0}", lyrics3Tag.Track);

   // get all fields presented in Lyrics3Tag
   Lyrics3Field[] allFields = lyrics3Tag.Fields;

   foreach (Lyrics3Field lyrics3Field in allFields)
   {
     Console.WriteLine("Name: {0}, value: {1}", lyrics3Field.Name, lyrics3Field.Value);

    }
  }
}


```

#### Update ID3v1 Tag in Mp3 Format



```csharp
const string filePath = @"C:\download files\a-ha - Take On Me.mp3";

// init Mp3Format class
Mp3Format mp3Format = new Mp3Format(filePath);

// create id3v1 tag
Id3v1Tag id3Tag = new Id3v1Tag();

// set artist
id3Tag.Artist = "A-ha";

// set title
id3Tag.Title = "Take on me";

// update ID3v1 tag
mp3Format.UpdateId3v1(id3Tag);

// and commit changes
mp3Format.Save();


```

#### Read Image Resource Blocks (native PSD metadata) in Photoshop Format



```csharp
// path to the Photoshop file
string path = @"C:\\example.psd";

// initialize PsdFormat
PsdFormat psdFormat = new PsdFormat(path);

// check if JPEG contain photoshop metadata
if (psdFormat.HasImageResourceBlocks)
{
 // get native photoshop metadata
 ImageResourceMetadata imageResource = psdFormat.GetImageResourceBlocks();

 // display all blocks
 foreach (ImageResourceBlock imageResourceBlock in imageResource.Blocks)
 {
   Console.WriteLine("Id: {0}, size: {1}", imageResourceBlock.DefinedId, imageResourceBlock.DataSize);

   // create your own logic to parse image resource block
   byte[] data = imageResourceBlock.Data;
 }
}


```

#### Remove Photoshop Metadata in Jpeg Format



```csharp
// path to the jpg file
string path = @"C:\\example.jpg";

// initialize JpegFormat
JpegFormat jpegFormat = new JpegFormat(path);

// check if JPEG contain photoshop metadata
if (jpegFormat.HasImageResourceBlocks)
{
  // remove photshop Image Resource blocks
  jpegFormat.RemovePhotoshopData();

  // and commit changes
  jpegFormat.Save();
}


```

#### Read Image Resource Blocks (native PSD metadata) in Jpeg Format



```csharp
// path to the jpg file
string path = @"C:\\example.jpg";

// initialize JpegFormat
JpegFormat jpegFormat = new JpegFormat(path);

// check if JPEG contain photoshop metadata
if (jpegFormat.HasImageResourceBlocks)
{

 // get native photoshop metadata
 ImageResourceMetadata imageResource = jpegFormat.GetImageResourceBlocks();

 // display all blocks
 foreach (ImageResourceBlock imageResourceBlock in imageResource.Blocks)
 {
  Console.WriteLine("Id: {0}, size: {1}", imageResourceBlock.DefinedId, imageResourceBlock.DataSize);

  // create your own logic to parse image resource block
  byte[] data = imageResourceBlock.Data;
  }
}


```
