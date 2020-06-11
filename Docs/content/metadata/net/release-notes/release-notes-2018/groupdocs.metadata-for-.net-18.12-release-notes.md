---
id: groupdocs-metadata-for-net-18-12-release-notes
url: metadata/net/groupdocs-metadata-for-net-18-12-release-notes
title: GroupDocs.Metadata for .NET 18.12 Release Notes
weight: 1
description: ""
keywords: 
productName: GroupDocs.Metadata for .NET
hideChildren: False
---
{{< alert style="info" >}}This page contains release notes for GroupDocs.Metadata for .NET 18.12.{{< /alert >}}

## Major Features

There are the following features and enhancements in this release:

*   Add support for password-protected documents
*   Reduce memory consumption of supported Word formats
*   Reduce memory consumption of supported PowerPoint formats
*   Ability to update metadata keys in Doc/Docx file format
*   Remove obsolete members of the Mp3Format class
*   Remove the MppFormat.GetProperties method (obsolete code)

## All Changes

| Key | Summary | Category |
| --- | --- | --- |
| METADATANET-2462 | Add support for password-protected documents | New Feature |
| METADATANET-2489 | Reduce memory consumption of supported Word formats | Enhancement |
| METADATANET-2424 | Reduce memory consumption of supported PowerPoint formats | Enhancement |
| METADATANET-1436 | Ability to update metadata keys in Doc/Docx file format | Enhancement |
| METADATANET-1519 | Remove obsolete members of the Mp3Format class | Enhancement |
| METADATANET-2463 | Remove the MppFormat.GetProperties method (obsolete code) | Enhancement |
| METADATANET-1614 | Removing Author property from DOC/DOCX removes Content Type, Scale, Version and Language properties | Bug |

## Public API and Backward Incompatible Changes

{{< alert style="info" >}}This section lists public API changes that were introduced in GroupDocs.Metadata for .NET 18.12. It includes not only new and obsoleted public methods, but also a description of any changes in the behaviour behind the scenes in GroupDocs.Metadata which may affect existing code. Any behavior introduced that could be seen as a regression and modifies existing behavior is especially important and is documented here.{{< /alert >}}

### Support for password-protected documents

##### Description

This new feature allows a user to work with password-protected documents of some popular formats.

##### Public API changes

The *LoadOptions* class has been added to the *GroupDocs.Metadata* namespace.

The *DocFormat(string, LoadOptions)* constructor has been added to the *DocFormat* class.

The *DocFormat(Stream, LoadOptions)* constructor has been added to the *DocFormat* class.

The *PptFormat(string, LoadOptions)* constructor has been added to the *PptFormat* class.

The *PptFormat(Stream, LoadOptions)* constructor has been added to the *PptFormat* class.

The *XlsFormat(string, LoadOptions)* constructor has been added to the *XlsFormat *class.

The *XlsFormat**(Stream, LoadOptions)* constructor has been added to the *XlsFormat *class.

The *PdfFormat(string, LoadOptions)* constructor has been added to the *PdfFormat *class.

The *PdfFormat**(Stream, LoadOptions)* constructor has been added to the *PdfFormat *class.

##### Usecases

Load a password-protected PDF document.

**C#**

```csharp
LoadOptions loadOptions = new LoadOptions("password");
using (PdfFormat format = new PdfFormat(@"D:\protected\input.pdf", loadOptions))
{
    // Working with the password-protected document
    format.CleanMetadata();
    format.Save(@"D:\protected\output.pdf");
}
```

Load a password-protected Excel document.

**C#**

```csharp
LoadOptions loadOptions = new LoadOptions("password");
using (XlsFormat format = new XlsFormat(@"D:\protected\input.xlsx", loadOptions))
{
    // Working with the password-protected document
    format.CleanMetadata();
    format.Save(@"D:\protected\output.xlsx");
}
```

Load a password-protected PowerPoint document.

**C#**

```csharp
LoadOptions loadOptions = new LoadOptions("password");
using (PptFormat format = new PptFormat(@"D:\protected\input.pptx", loadOptions))
{
    // Working with the password-protected document
    format.CleanMetadata();
    format.Save(@"D:\protected\output.pptx");
}
```

Load a password-protected Word document.

**C#**

```csharp
LoadOptions loadOptions = new LoadOptions("password");
using (DocFormat format = new DocFormat(@"D:\protected\input.doc", loadOptions))
{
    // Working with the password-protected document
    format.CleanMetadata();
    format.Save(@"D:\protected\output.doc");
}
```

Check if a document is password-protected.

**C#**

```csharp
if (MetadataUtility.IsProtected(@"D:\protected\input.doc"))
{
    // Working with the password-protected document
}
```

### Reduced memory consumption of supported Word formats

##### Description

This enhancement allows working with Word documents with less memory consumption.

##### Public API changes

None.

##### Usecases

Please note that the *DocFormat* class implements the *IDisposable* interface and it's necessary to call the *Dispose()* method when you're done working with its instance.

**C#**

```csharp
using (DocFormat format = new DocFormat(@"d:\input.docx"))
{
    // Working with metadata
}
```

If you are loading a Word document from a stream, it's up to you to close the stream when the file is not needed anymore.

**C#**

```csharp
using (Stream stream = File.Open(@"d:\input.doc", FileMode.Open, FileAccess.ReadWrite))
{
    using (DocFormat format = new DocFormat(stream))
    {
        // Working with metadata
    }
    // The stream is still open here
}
```

The same rule works if you are saving the output file into a stream.

**C#**

```csharp
using (Stream stream = File.Open(@"d:\output.docx", FileMode.OpenOrCreate, FileAccess.ReadWrite))
{
    using (DocFormat format = new DocFormat(@"d:\input.docx"))
    {
        // Working with metadata
 
        format.Save(stream);
    }
    // The stream is still open here
}
```

### Reduced memory consumption of supported PowerPoint formats

##### Description

This enhancement allows working with PowerPoint documents with less memory consumption.

##### Public API changes

None.

##### Usecases

Please note that the *PptFormat* class implements the *IDisposable* interface and it's necessary to call the *Dispose()* method when you're done working with its instance.

**C#**

```csharp
using (PptFormat format = new PptFormat(@"d:\input.ppt"))
{
    // Working with metadata
}
```

If you are loading a Word document from a stream, it's up to you to close the stream when the file is not needed anymore.

**C#**

```csharp
using (Stream stream = File.Open(@"d:\input.pptx", FileMode.Open, FileAccess.ReadWrite))
{
    using (PptFormat format = new PptFormat(stream))
    {
        // Working with metadata
    }
    // The stream is still open here
}
```

The same rule works if you are saving the output file into a stream.

**C#**

```csharp
using (Stream stream = File.Open(@"d:\output.ppt", FileMode.OpenOrCreate, FileAccess.ReadWrite))
{
    using (PptFormat format = new PptFormat(@"d:\input.ppt"))
    {
        // Working with metadata
 
        format.Save(stream);
    }
    // The stream is still open here
}
```

### Ability to update metadata keys in Doc/Docx file format

##### Description

This enhancement allows updating *Words* and *Version* properties of Doc/Docx file formats.

##### Public API changes

None.

##### Usecases

Update the Words and Version metadata keys in doc/docx documents.

**C#**

```csharp
using (DocFormat docFormat = new DocFormat(@"D:\input.doc"))
{
    docFormat.DocumentProperties["Words"] = new PropertyValue(1);
    docFormat.DocumentProperties["Version"] = new PropertyValue(851968);
 
    docFormat.Save(@"D:\output.doc");
}
```

### Removed obsolete members of the Mp3Format class

##### Description

This enhancement removes some obsolete members of the *Mp3Format* class.

##### Public API changes

The *Id3v1* property has been removed from the *Mp3Format*class.

The *Id3v2* property has been removed from the *Mp3Format*class.

##### Usecases

Please use the *GetId3v1Tag* and *GetId3v2Tag* methods instead.

**C#**

```csharp
using (Mp3Format format = new Mp3Format(@"D:\input.mp3"))
{
    Id3v1Tag id3v1 = format.GetId3v1Tag();
    Console.WriteLine(id3v1.Album);
    Console.WriteLine(id3v1.Artist);
 
    Id3v2Tag id3v2 = format.GetId3v2Tag();
    Console.WriteLine(id3v2.Album);
    Console.WriteLine(id3v2.Artist);
}
```

### Removed the MppFormat.GetProperties method (obsolete code)

##### Description

This enhancement removes some obsolete members of the *MppFormat* class.

##### Public API changes

The *GetProperties *method has been removed from the *MppFormat* class.

##### Usecases

Please use the *MppFormat.ProjectInfo* property instead.

**C#**

```csharp
using (MppFormat format = new MppFormat(@"D:\input.mpp"))
{
    Console.WriteLine(format.ProjectInfo.Author);
    Console.WriteLine(format.ProjectInfo.LastAuthor);
    Console.WriteLine(format.ProjectInfo.Company);
}
```
