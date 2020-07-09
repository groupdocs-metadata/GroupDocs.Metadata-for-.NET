# Metadata Viewer & Editing API

[GroupDocs.Metadata for .NET](https://products.groupdocs.com/metadata/net) provides easy ways to manage metadata of various document formats. It enables the user to read, write, update and remove metadata of Word, Excel,  PowerPoint & PDF documents as well as images, videos, audios, emails, fonts, diagrams and many other popular file formats.

<p align="center">

  <a title="Download complete GroupDocs.Metadata for .NET source code" href="https://github.com/groupdocs-metadata/GroupDocs.Metadata-for-.NET/archive/master.zip">
	<img src="https://raw.github.com/AsposeExamples/java-examples-dashboard/master/images/downloadZip-Button-Large.png" />
  </a>
</p>

Directory | Description
--------- | -----------
[Docs](https://docs.groupdocs.com/metadata/net/)  | Product documentation containing Developer's Guide, Release Notes & more.
[Examples](https://github.com/groupdocs-metadata/GroupDocs.Metadata-for-.NET/tree/master/Examples)  | C# examples and sample files in order to quickly get started with Metadata API.
[Plugins](https://github.com/groupdocs-metadata/GroupDocs.Metadata-for-.NET/tree/master/Plugins) | Visual Studio plugins related to GroupDocs.Metadata.
[Showcases](https://github.com/groupdocs-metadata/GroupDocs.Metadata-for-.NET/tree/master/Showcases) | Open-source front-end applications demonstrating some of use cases.

## Document Metadata Processing Features

- Read, update and remove metadata from [60+ file formats] (https://docs.groupdocs.com/metadata/net/supported-document-formats/).
- Search, update and remove particular metadata properties as per specified creteria.
- Use tags to easily manipulate most common metadata properties in a unified manner.
- Load password-protected documents.
- Extract information about hidden document pages, digital signatures, user comments, revisions, etc.
- Supports many popular metadata standards, such as, IPTC, XMP, EXIF, Image Resources.
- Manipulate native metadata properties in various formats.
- Extract technical information from images, audio and video files.
- Calculate common document statistics (word count, character count, etc.).
- Detect the format and MIME type of a file by its internal structure.
- Work with various audio tags (ID3, Lyrics, APE).
- Traverse metadata tree.
- Work with the APEv2, ID3v1, ID3v2, Lyrics & other tags of MP3 metadata.

## Read & Write Metadata

**Microsoft Word:** DOC, DOT, DOCX, DOCM, DOTX\
**Microsoft Excel:** XLSX, XLSM, XLTM, XLS\
**Microsoft PowerPoint:** PPTX, PPTM, PPSX, PPSM, POTX, POTM, PPT, PPS\
**Microsoft Visio:** VSD, VDX, VSDX, VSS, VSX\
**Microsoft OneNote:** ONE\
**Microsoft Project:** MPP\
**OpenOffice:** ODS, ODT, OTF, OTC\
**Audio:** MP3, WAV\
**Video:** AVI, MOV / QT, ASF, FLV\
**Email:** EML, MSG, VCF, VCR\
**Image:** BMP, GIF, JPG, JPEG, JPE, JP2, PNG, TIFF, DICOM, WEBP\
**Archive:** ZIP\
**Font:** TTF, TTC\
**Metafile:** EMF, WMF\
**Adobe Photoshop:** PSD\
**AutoCAD:** DWG, DXF\
**Portable:** PDF\
**eBook:** EPUB, DJVU, DJV\
**Other:** TORRENT\

## Develop & Deploy GroupDocs.Metadata Anywhere

**Microsoft Windows:** Windows Desktop & Server (x86, x64), Windows Azure\
**macOS:** Mac OS X\
**Linux:** Ubuntu, OpenSUSE, CentOS, and others\
**Development Environments:** Microsoft Visual Studio, Xamarin.Android, Xamarin.IOS, Xamarin.Mac, MonoDevelop 2.4 and later\
**Supported Frameworks:** .NET Framework 2.0 or higher, .NET Standard 2.0, .NET Core 2.1 & 2.0, Mono Framework 1.2 or higher

## Getting Started with GroupDocs.Metadata for .NET

Are you ready to give GroupDocs.Metadata for .NET a try? Simply execute `Install-Package GroupDocs.Metadata` from Package Manager Console in Visual Studio to fetch & reference GroupDocs.Metadata assembly in your project. If you already have GroupDocs.Metadata for .NET and want to upgrade it, please execute `Update-Package GroupDocs.Metadata` to get the latest version.

## Remove All Metadata Properties from a PDF

```csharp
using (Metadata metadata = new Metadata(Constants.InputPdf))
{
    // Remove detected metadata packages
    var affected = metadata.Sanitize();
    Console.WriteLine("Properties removed: {0}", affected);

    metadata.Save(Constants.OutputPdf);
}
```

## Extract Metadata from Various Files

```csharp
foreach (string file in Directory.GetFiles(Constants.InputPath))
{
    using (Metadata metadata = new Metadata(file))
    {
        if (metadata.FileFormat != FileFormat.Unknown && !metadata.GetDocumentInfo().IsEncrypted)
        {
            Console.WriteLine();
            Console.WriteLine(file);

            // fetch all metadata properties that fall into a particular category
            var properties = metadata.FindProperties(p => p.Tags.Any(t => t.Category == Tags.Content));
            Console.WriteLine("The metadata properties describing some characteristics of the file content: title, keywords, language, etc.");
            foreach (var property in properties)
            {
                Console.WriteLine("{0} = {1}", property.Name, property.Value);
            }

            // fetch all properties having a specific type and value
            var year = DateTime.Today.Year;
            properties = metadata.FindProperties(p => p.Value.Type == MetadataPropertyType.DateTime &&
                                                     p.Value.ToStruct(DateTime.MinValue).Year == year);

            Console.WriteLine("All datetime properties with the year value equal to the current year");
            foreach (var property in properties)
            {
                Console.WriteLine("{0} = {1}", property.Name, property.Value);
            }
        }
    }
}
```

[Product Page](https://products.groupdocs.com/metadata/net) | [Documentation](https://docs.groupdocs.com/metadata/net/) | [Demo](https://products.groupdocs.app/metadata/family) | [API Reference](https://apireference.groupdocs.com/net/metadata) | [Examples](https://github.com/groupdocs-metadata/GroupDocs.Metadata-for-.NET) | [Blog](https://blog.groupdocs.com/category/metadata/) | [Free Support](https://forum.groupdocs.com/c/metadata) | [Temporary License](https://purchase.groupdocs.com/temporary-license)
