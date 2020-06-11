---
id: groupdocs-metadata-for-net-18-5-release-notes
url: metadata/net/groupdocs-metadata-for-net-18-5-release-notes
title: GroupDocs.Metadata for .NET 18.5 Release Notes
weight: 8
description: ""
keywords: 
productName: GroupDocs.Metadata for .NET
hideChildren: False
---
{{< alert style="info" >}}This page contains release notes for GroupDocs.Metadata for .NET 18.5{{< /alert >}}

## Major Features

There are the following enhancements in this release:

*   Implement the ability to search and replace metadata using regular expressions
*   Implement unified DublinCore metadata reader for all formats that support XMP
*   Reduce memory consumption of zip format metadata loading and saving
*   Implement the ability to edit the zip archive comment
*   Reduce memory consumption of epub format metadata loading
*   Reduce memory consumption of torrent format metadata loading and saving

## All Changes

| Key | Summary | Category |
| --- | --- | --- |
| METADATANET-566 | Implement the ability to search and replace metadata using regular expressions | Enhancement  |
| METADATANET-2238  | Implement unified DublinCore metadata reader for all formats that support XMP | Enhancement  |
| METADATANET-2246 | Reduce memory consumption of zip format metadata loading and saving   | Enhancement   |
| METADATANET-2288 | Implement the ability to edit the zip archive comment  | Enhancement  |
| METADATANET-2290 | Reduce memory consumption of epub format metadata loading  | Enhancement  |
| METADATANET-2291 | Reduce memory consumption of torrent format metadata loading and saving | Enhancement  |

## Public API and Backward Incompatible Changes

{{< alert style="info" >}}This section lists public API changes that were introduced in GroupDocs.Metadata for .NET 18.5. It includes not only new and obsoleted public methods, but also a description of any changes in the behaviour behind the scenes in GroupDocs.Metadata which may affect existing code. Any behaviour introduced that could be seen as a regression and modifies existing behaviour is especially important and is documented here.{{< /alert >}}

### Implement the ability to search and replace metadata using regular expressions

##### Description

This enhancement allows a user to search and replace metadata by using regular expressions

##### Public API changes

*ScanDocument(string,Regex)* method has been added to *SearchFacade* class  
*ScanDocument(Stream,Regex)* method has been added to *SearchFacade* class  
*ScanXmp(string,Regex)* method has been added to *SearchFacade* class  
*ScanXmp(Stream,Regex)* method has been added to *SearchFacade* class  
*ScanExif(string,Regex)* method has been added to *SearchFacade* class  
*ScanExif(Stream,Regex)* method has been added to *SearchFacade* class  
*ReplaceInDocument(string,Regex,string,string)* method has been added to *SearchFacade* class  
*ReplaceInDocument(Stream,Regex,string,string)* method has been added to *SearchFacade* class  
*ReplaceInXmp(string,Regex,string,string)* method has been added to *SearchFacade* class  
*ReplaceInXmp(Stream,Regex,string,string)* method has been added to *SearchFacade* class  
*ReplaceInExif(string,Regex,string,string)* method has been added to *SearchFacade* class  
*ReplaceInExif(Stream,Regex,string,string)* method has been added to *SearchFacade* class

##### Usecases

Find metadata in a document.

**C#**

```csharp
string testFile = @"D:\test.docx";
Regex pattern = new Regex("author|company", RegexOptions.IgnoreCase);
MetadataPropertyCollection properties = SearchFacade.ScanDocument(testFile, pattern);
for (int i = 0; i < properties.Count; i++)
{
    Console.WriteLine(properties[i]);
}
```

Replace metadata in a document.

**C#**

```csharp
string inputFile = @"D:\input.xlsx";
string outputFile = @"D:\output.xlsx";
Regex pattern = new Regex("^author|company$", RegexOptions.IgnoreCase);
string replaceValue = "Aspose";
SearchFacade.ReplaceInDocument(inputFile, pattern, replaceValue, outputFile);
```

Find XMP metadata.

**C#**

```csharp
string testFile = @"D:\xmp.gif";
Regex pattern = new Regex("^.*description$", RegexOptions.IgnoreCase);
XmpNodeView[] properties = SearchFacade.ScanXmp(testFile, pattern);
for (int i = 0; i < properties.Length; i++)
{
    Console.WriteLine(properties[i]);
}
```

Replace XMP metadata.

**C#**

```csharp
string inputFile = @"D:\input.gif";
string outputFile = @"D:\output.gif";
Regex pattern = new Regex("^.*description$", RegexOptions.IgnoreCase);
string replaceValue = "Test file";
SearchFacade.ReplaceInXmp(inputFile, pattern, replaceValue, outputFile);
```

Find EXIF metadata.

**C#**

```csharp
string testFile = @"D:\exif.jpg";
Regex pattern = new Regex(".*");
ExifProperty[] properties = SearchFacade.ScanExif(testFile, pattern);
for (int i = 0; i < properties.Length; i++)
{
    Console.WriteLine(properties[i]);
}
```

Replace EXIF metadata.

**C#**

```csharp
string inputFile = @"D:\input.jpg";
string outputFile = @"D:\output.jpg";
Regex pattern = new Regex("James", RegexOptions.IgnoreCase);
string replaceValue = "John";
SearchFacade.ReplaceInExif(inputFile, pattern, replaceValue, outputFile);
```

### Implement unified DublinCore metadata reader for all formats that support XMP

##### Description

This enhancement allows a user to obtain Dublin Core metadata using the unified approach.

##### Public API changes

*IDublinCore* interface has been added to *GroupDocs.Metadata* namespace  
*IXmp* interface is now inherited from *IDublinCore* interface  
*DocFormat* class now implements *IDublinCore* interface  
*PdfFormat* class now implements *IDublinCore* interface  
*EpubFormat* class now implements *IDublinCore* interface  
*GifFormat* class now implements *IDublinCore* interface  
*Jp2Format* class now implements *IDublinCore* interface  
*JpegFormat* class now implements *IDublinCore* interface  
*PngFormat* class now implements *IDublinCore* interface  
*PsdFormat* class now implements *IDublinCore* interface  
*TiffFormat* class now implements *IDublinCore* interface  
*AviFormat* class now implements *IDublinCore* interface  
*Rights* property has been added to *DublinCoreMetadata* class  
*Identifier* property has been added to *DublinCoreMetadata* class

##### Usecases

Get Dublin Core metadata using *MetadataUtility* class.

**C#**

```csharp
string[] files = Directory.GetFiles(@"D:\test");
foreach (string file in files)
{
    try
    {
        DublinCoreMetadata dublinCoreMetadata = (DublinCoreMetadata)MetadataUtility.ExtractSpecificMetadata(file, MetadataType.DublinCore);
        if (dublinCoreMetadata != null)
        {
            Console.WriteLine(dublinCoreMetadata.Creator);
            Console.WriteLine(dublinCoreMetadata.Format);
            Console.WriteLine(dublinCoreMetadata.Subject);
        }
    }
    catch
    {
        Console.WriteLine("Could not load {0}", file);
    }
}
```

Get Dublin Core metadata using *IDublinCore* interface.

**C#**

```csharp
string[] files = Directory.GetFiles(@"D:\test");
foreach (string file in files)
{
    try
    {
        using (FormatBase format = FormatFactory.RecognizeFormat(file))
        {
            IDublinCore dublinCoreContainer = format as IDublinCore;
            if (dublinCoreContainer != null)
            {
                DublinCoreMetadata dublinCoreMetadata = dublinCoreContainer.GetDublinCore();
                if (dublinCoreMetadata != null)
                {
                    Console.WriteLine(dublinCoreMetadata.Creator);
                    Console.WriteLine(dublinCoreMetadata.Format);
                    Console.WriteLine(dublinCoreMetadata.Subject);
                }
            }
        }
    }
    catch
    {
        Console.WriteLine("Could not load {0}", file);
    }
}
```

### Reduce memory consumption of zip format metadata loading and saving 

##### Description

This enhancement allows working with zip archives with less memory consumption.

##### Public API changes

None.

##### Usecases

Please note that *ZipFormat* class implements *IDisposable* interface and it's necessary to call *Dispose()* method when you're done working with its instance.

**C#**

```csharp
using (ZipFormat format = new ZipFormat(@"d:\input.zip"))
{
    // Working with the zip archive metadata
}
```

If you are loading a zip file from a stream, it's up to you to close the stream when the archive is not needed anymore.

**C#**

```csharp
using (Stream stream = File.Open(@"d:\input.zip", FileMode.Open, FileAccess.ReadWrite))
{
    using (ZipFormat format = new ZipFormat(stream))
    {
        // Working with the zip archive metadata
    }
    // The stream is still open here
}
```

The same rule works if you are saving the output file into a stream.

**C#**

```csharp
using (Stream stream = File.Open(@"d:\output.zip", FileMode.OpenOrCreate, FileAccess.ReadWrite))
{
    using (ZipFormat format = new ZipFormat(@"d:\input.zip"))
    {
        // Working with the zip archive metadata

        format.Save(stream);
    }
    // The stream is still open here
}
```

### Implement the ability to edit the zip archive comment   

##### Description

This enhancement allows a user to edit the zip archive comment.

##### Public API changes

A setter has been added to *ZipMetadata.Comment* property  
A setter has been added to *ZipFormat.ZipFileComment* property

##### Usecases

Change the comment of a zip archive.

**C#**

```csharp
using (ZipFormat format = new ZipFormat(@"d:\input.zip"))
{
    format.ZipInfo.Comment = "test comment";
    format.Save(@"d:\output.zip");
}
```

Or alternatively, you can use *ZipFormat.ZipFileComment* property.

**C#**

```csharp
using (ZipFormat format = new ZipFormat(@"d:\input.zip"))
{
    format.ZipFileComment = "test comment";
    format.Save(@"d:\output.zip");
}
```

### Reduce memory consumption of epub format metadata loading

##### Description

This enhancement allows working with epub books with less memory consumption.

##### Public API changes

None.

##### Usecases

Please note that *EpubFormat* class implements *IDisposable* interface and it's necessary to call *Dispose()* method when you're done working with its instance.

**C#**

```csharp
using (EpubFormat format = new EpubFormat(@"d:\input.epub"))
{
    // Working with the epub book metadata
}
```

If you are loading an epub file from a stream, it's up to you to close the stream when the file is not needed anymore.

**C#**

```csharp
using (Stream stream = File.Open(@"d:\input.epub", FileMode.Open, FileAccess.ReadWrite))
{
    using (EpubFormat format = new EpubFormat(stream))
    {
        // Working with the epub book metadata
    }
    // The stream is still open here
}
```

The same rule works if you are saving the output file into a stream.

**C#**

```csharp
using (Stream stream = File.Open(@"d:\output.epub", FileMode.OpenOrCreate, FileAccess.ReadWrite))
{
    using (EpubFormat format = new EpubFormat(@"d:\input.epub"))
    {
        // Working with the epub book metadata

        format.Save(stream);
    }
    // The stream is still open here
}
```

### Reduce memory consumption of torrent format metadata loading and saving

##### Description

This enhancement allows working with torrent files with less memory consumption.

##### Public API changes

None.

##### Usecases

Please note that *TorrentFormat* class implements *IDisposable* interface and it's necessary to call *Dispose()* method when you're done working with its instance.

**C#**

```csharp
using (TorrentFormat format = new TorrentFormat(@"d:\input.torrent"))
{
    // Working with the torrent file metadata
}
```

If you are loading an epub file from a stream, it's up to you to close the stream when the file is not needed anymore.

**C#**

```csharp
using (Stream stream = File.Open(@"d:\input.torrent", FileMode.Open, FileAccess.ReadWrite))
{
    using (TorrentFormat format = new TorrentFormat(stream))
    {
        // Working with the torrent file metadata
    }
    // The stream is still open here
}
```

The same rule works if you are saving the output file into a stream.

**C#**

```csharp
using (Stream stream = File.Open(@"d:\output.torrent", FileMode.OpenOrCreate, FileAccess.ReadWrite))
{
    using (TorrentFormat format = new TorrentFormat(@"d:\input.torrent"))
    {
        // Working with the torrent file metadata

        format.Save(stream);
    }
    // The stream is still open here
}
```
