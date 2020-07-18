---
id: groupdocs-metadata-for-net-17-02-release-notes
url: metadata/net/groupdocs-metadata-for-net-17-02-release-notes
title: GroupDocs.Metadata for .NET 17.02 Release Notes
weight: 11
description: ""
keywords: 
productName: GroupDocs.Metadata for .NET
hideChildren: False
---
{{< alert style="info" >}}
This page contains release notes for [GroupDocs.Metadata for .NET 17.02.0](https://downloads.groupdocs.com/metadata/net/new-releases/groupdocs.metadata-for-.net-17.2.0/)
{{< /alert >}}

## Major Features

There are 9 features and 2 enhancements in this regular monthly release. The most notable are:

*   Ability to use Dynabic.Metered account
*   Ability to detect AVI video format
*   Ability to read header of AVI video format
*   Ability to read Photoshop layers of PSD format
*   Ability to detect DICOM format
*   Ability to read metadata of DICOM format
*   Ability to read ByteOrder (little-endian, big-endian) for image formats
*   Ability to process Excel content type properties using XlsMetadata class (add, remove, clear operations)
*   Ability to export DICOM metadata to csv, excel file
*   Ability to export Excel content type properties to csv, excel
*   Ability to export metadata of AVI format to csv, excel

## All Changes

| Key | Summary | Category |
| --- | --- | --- |
| METADATANET-1455 |  Ability to export Excel content type properties to csv, excel |  Enhancement |
| METADATANET-1456 |  Ability to process Excel content type properties using XlsMetadata class (add, remove, clear operations) |  Enhancement |
| METADATANET-1475 |  Ability to export metadata of AVI format to csv, excel |  New Feature |
| METADATANET-247 |  Ability to read header of AVI video format |  New Feature |
| METADATANET-1232 |  Ability to read Photoshop layers of PSD format |  New Feature |
| METADATANET-1256 |  Ability to use Dynabic.Metered account |  New Feature |
| METADATANET-1264 |  Ability to detect DICOM format |  New Feature |
| METADATANET-1436 |  Ability to read metadata of DICOM format |  New Feature |
| METADATANET-1439 |  Ability to export DICOM metadata to csv, excel file |  New Feature |
| METADATANET-1453 |  Ability to read ByteOrder (little-endian, big-endian) for image formats |  New Feature |
| METADATANET-1473 |  Ability to detect AVI video format |  New Feature |

## Public API and Backward Incompatible Changes

{{< alert style="info" >}}This section lists public API changes that were introduced in GroupDocs.Metadata for .NET 17.02.0 It includes not only new and obsoleted public methods, but also a description of any changes in the behavior behind the scenes in GroupDocs.Metadata which may affect existing code. Any behavior introduced that could be seen as a regression and modifies existing behavior is especially important and is documented here.{{< /alert >}}

#### Ability to export Excel content type properties to csv, excel

Enhancement allows to export content type properties to csv/excel

This example demonstrates how to export content type properties to excel. All content type properties will be displayed under "Document properties" sheet



```csharp
// path to the target file
const string path = @"C:\sample.xlsx";

// path to the output file
const string outputPath = @"C:\metadata.xlsx";

// export to excel
byte[] content = ExportFacade.ExportToExcel(path);

// write data to the file
File.WriteAllBytes(outputPath, content);

```

#### Ability to process Excel content type properties using XlsMetadata class (add, remove, clear operations)

This enhancement allows to process content type properties in Excel document using XlsMetadata

**Public API Changes:**  
Added **ClearContentTypeProperties** method into class **XlsMetadata** of namespace **GroupDocs.Metadata.Formats.Document**  
Added **AddContentTypeProperty** methods (3 overloads) into class **XlsMetadata** of namespace **GroupDocs.Metadata.Formats.Document**  
Added **RemoveContentTypeProperty** method into class **XlsMetadata** of namespace **GroupDocs.Metadata.Formats.Document**  
Added **ContentTypeProperties** property into class **XlsMetadata** of namespace **GroupDocs.Metadata.Formats.Document**

This example demonstrates how to add content type property



```csharp
// path to the XLS file
string path = @"C:\\example.xlsx";

// initialize XlsFormat
XlsFormat xlsFormat = new XlsFormat(path);

// get all xls properties
XlsMetadata xlsProperties = xlsFormat.DocumentProperties;

// if Excel contains content type properties
if (xlsProperties.ContentTypeProperties.Length > 0)
{
 // than remove all content type properties
  xlsProperties.ClearContentTypeProperties();
}

// set hidden field
xlsProperties.AddContentTypeProperty("user hidden id", "asdk12dkvjdjh3");

// and commit changes
xlsFormat.Save(@"C:\\document_with_hidden_data.xlsx");

```

#### Ability to read header of AVI video format

This feature allows to read AVIMAINHEADER of AVI format

**Public API changes**  
Added **AviFormat** class into namespace **GroupDocs.Metadata.Formats.Video**  
Added **AviHeader** class into namespace **GroupDocs.Metadata.Formats.Video**

This example demonstrates how to read AVIMAINHEADER of AVI format



```csharp
// path to the AVI
const string file = @"C:\\download files\tutorial1.avi";

// initialize AviFormat
AviFormat aviFormat = new AviFormat(file);

// get AVI header
AviHeader header = aviFormat.Header;

// display video width
Console.WriteLine("Video width: {0}", header.Width);

// display video height
Console.WriteLine("Video height: {0}", header.Height);

// display total frames
Console.WriteLine("Total frames: {0}", header.TotalFrames);

// display number of streams in file
Console.WriteLine("Number of streams: {0}", header.Streams);

// display suggested buffer size for reading the file
Console.WriteLine("Suggested buffer size: {0}", header.SuggestedBufferSize);

```

#### Ability to read Photoshop layers of PSD format

This feature allows to read layers of PSD format  
**Public API changes**  
Added **PsdLayer** class into namespace **GroupDocs.Metadata.Formats.Image**

This example demonstrates how to read layers in Photoshop



```csharp
// path to the Photoshop file
string path = @"C:\\website-design-01.psd";

// initialize PsdFormat
PsdFormat psdFormat = new PsdFormat(path);

// get all layers
PsdLayer[] layers = psdFormat.Layers;

foreach (PsdLayer layer in layers)
{
 // display layer short info
 Console.WriteLine("Name: {0}, channels count: {1}", layer.Name, layer.ChannelsCount);
}

```

#### Ability to use Dynabic.Metered account

This enhancement allows to use Dynabic.Metered account to run library in licensed mode. It works only with enabled internet connection.  
**Public API changes**  
Added **Metered** class into namespace **GroupDocs.Metadata**

This example demonstrates how to use library in licensed mode using Dynabic.Metered account



```csharp
const string publicKey = "[Your Dynabic.Metered public key]";
const string privateKey = "[Your Dynabic.Metered private key]";

// initialize Metered API
GroupDocs.Metadata.Metered metered = new Metered();

// set-up credentials
metered.SetMeteredKey(publicKey, privateKey);

// do some work:

// Open Word document
DocFormat docFormat = new DocFormat(@"C:\cv.docx");

// remove hidden metadata
docFormat.RemoveHiddenData(new DocInspectionOptions(DocInspectorOptionsEnum.All));

// and get consumption quantity
decimal consumptionQuantity = GroupDocs.Metadata.Metered.GetConsumptionQuantity();

```

#### Ability to detect DICOM format

This feature allows to detect DICOM image format  
**Public API changes**  
Added class **DICOMFormat** into namespace **GroupDocs.Metadata.Formats.Image.ImageFormat**

This example is shown how to detect DICOM format



```csharp
// path to the file
const string path = @"C:\\sample.dicom";

// recognize format
FormatBase format = FormatFactory.RecognizeFormat(path);

// check format type
if (format.Type == DocumentType.DICOM)
{
 // cast it to DICOMFormat
 DICOMFormat dicom = format as DICOMFormat;
}

```

#### Ability to read metadata of DICOM format

This feature allows to read metadata of DICOM image format  
**Public API changes**  
Added class **DICOMFormat** into namespace **GroupDocs.Metadata.Formats.Image.ImageFormat**  
Added class **DicomMetadata** into namespace **GroupDocs.Metadata.Formats.Image.ImageFormat**

This example is shown how to detect DICOM format



```csharp
// path to the DICOM
const string path = @"C:\\sample.dicom";

// initialize DICOMFormat
DICOMFormat dicom = new DICOMFormat(path);

// get DICOM metadata
DicomMetadata header = dicom.Info;

// display header offset
Console.WriteLine("Header offset: {0}", header.HeaderOffset);

// display number of frames
Console.WriteLine("Number of frames: {0}", header.NumberOfFrames);

```

#### Ability to export DICOM metadata to csv, excel file

This feature allows to export DICOM metadata to csv/excel  
This example demonstrates how to export DICOM metadata to excel.



```csharp
// path to the target file
const string path = @"C:\sample.dicom";

// path to the output file
const string outputPath = @"C:\metadata.xlsx";

// export to excel
byte[] content = ExportFacade.ExportToExcel(path);

// write data to the file
File.WriteAllBytes(outputPath, content);

```

#### Ability to read ByteOrder (little-endian, big-endian) for image formats

This feature allows to read endianness value in image formats. See more [https://en.wikipedia.org/wiki/Endianness](https://en.wikipedia.org/wiki/Endianness).  
**Public API changes**  
Added **ByteOrder** enum into namespace **GroupDocs.Metadata**  
Added **ByteOrder** property into class **ImageFormat** of namespace **GroupDocs.Metadata.Formats.Image**

This example demonstrates how to read ByteOrder value in image format.



```csharp
// get all images from the specific folder
string[] images = Directory.GetFiles(@"C:\donwload files");

foreach (string path in images)
{
 // detect image
 ImageFormat image = ImageFormat.FromFile(path);

 // and display byte-order value
 Console.WriteLine(image.ByteOrder);
}

```

#### Ability to detect AVI video format

This feature allows to detect AVI video format  
**Public API changes**  
Extended enum **DocumentType**: added **DocumentType.AVI** value

This example is shown how to detect AVI format via FormatFactory



```csharp
// path to the file
const string path = @"C:\\download files\tutorial1.avi";

// recognize format
FormatBase format = FormatFactory.RecognizeFormat(path);

// check format type
if (format.Type == DocumentType.AVI)
{
 // cast it to AviFormat
 AviFormat aviFormat = format as AviFormat;

 // and get it MIME type
 string mimeType = aviFormat.MIMEType;
}

```

#### Ability to export metadata of AVI format to csv, excel

This feature allows to export AVI header to csv/Excel  
**Public API changes**  
Added **AviHeader** class into namespace **GroupDocs.Metadata.Formats.Video**

This example demonstrates how to export AVI metadata to Excel document



```csharp
// path to the file
// path to the target file
const string path = @"C:\tralers.AVI";

// path to the output file
const string outputPath = @"C:\metadata.xlsx";

// export to excel
byte[] content = ExportFacade.ExportToExcel(path);

// write data to the file
File.WriteAllBytes(outputPath, content);

```
