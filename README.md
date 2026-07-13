## GroupDocs.Metadata for .NET



[Product Page](https://products.groupdocs.com/metadata/net) | [Docs](https://docs.groupdocs.com/metadata/net/) | [Demos](https://products.groupdocs.com/metadata/net/demos) | [API Reference](https://reference.groupdocs.com/metadata/net/) | [Examples](https://github.com/groupdocs-metadata/GroupDocs.Metadata-for-.NET) | [Blog](https://blog.groupdocs.com/categories/groupdocs.metadata-product-family/) | [Releases](https://releases.groupdocs.com/metadata/net/) | [Free Support](https://forum.groupdocs.com/c/metadata/) | [Temporary License](https://purchase.groupdocs.com/temp-license)



GroupDocs.Metadata for .NET is a full-featured .NET class library enabling developers to read, edit, and remove metadata from over 110 document, image, audio, video, and other file formats—including Word, Excel, PowerPoint, PDF, images like JPEG, PNG, TIFF, HEIF, and AVIF, audio and video formats, emails, CAD, fonts, and more—while supporting major metadata standards such as XMP, EXIF, IPTC, ID3, and format-specific properties.

### Features

- Read, update and remove metadata from [110+ file formats](https://docs.groupdocs.com/metadata/net/supported-document-formats/).
- Search, update and remove particular metadata properties as per specified criteria.
- Use tags to easily manipulate most common metadata properties in a unified manner.
- Load password-protected documents.
- Extract information about hidden document pages, digital signatures, user comments, revisions, etc.
- Supports many popular metadata standards, such as, IPTC, XMP, EXIF, Image Resources.
- Manipulate native metadata properties in various formats.
- Extract technical information from images, audio and video files.
- Calculate common document statistics (word count, character count, etc.).
- Auto-detect the format and MIME type of file by its internal structure.
- Work with various audio tags (ID3, Lyrics, APE).
- [Traverse a whole metadata tree](https://docs.groupdocs.com/metadata/net/traverse-a-whole-metadata-tree/).
- Work with the APEv2, ID3v1, ID3v2, Lyrics & other tags of MP3 metadata.

See the [Features overview](https://docs.groupdocs.com/metadata/net/features-overview/) documentation topic for more details.

### Supported formats

## Supported Formats (high level)

This API supports a broad set of document and media formats, including:

- **Word Processing**: DOC, DOCX, DOCM, ODT, DOT, DOTM
- **Spreadsheets**: XLS, XLSX, XLSM, ODS, XLSB, XLT
- **Presentations**: PPT, PPTX, PPS, PPSX, POT, POTM
- **PDF**: PDF
- **Images**: JPG, PNG, TIFF, BMP, GIF, PSD
- **Audio/Video**: MP3, WAV, OGG, AVI, MOV, MKV, ASF, FLV, MK3D
- **Email**: EML, MSG
- **eBook**: EPUB, MOBI, FB2
- **Archives**: ZIP, RAR, 7Z, TAR, CB7, CBR
- **Fonts**: OTF, TTF, TTC, OTC
- **CAD**: DWG, DXF
- **3D**: FBX, STL, 3DS, DAE, GLTF
- **Visio**: VSD, VSDX, VDX, VSS, VSX, VTX
- **OneNote**: ONE
- **GIS**: KML, GPX, GEOJSON, GML, OSM, SHP
- **Other formats**: MPP, MPT, TORRENT, VCF, VCR

Supports **110+ formats**. See the [supported file formats](https://docs.groupdocs.com/metadata/net/supported-document-formats/) table for the complete list.

### Supported Frameworks

**Supported Frameworks:** .NET Framework 4.7.2 or higher, .NET 6.0 or higher, .NET 8.0 or higher

### Getting Started


To get started with `GroupDocs.Metadata` install the package using the command at the top of this NuGet page, or run:

```powershell
dotnet add package GroupDocs.Metadata
```

You can run the following C# samples to see how the library works. Also check the [Examples](https://github.com/groupdocs-metadata/GroupDocs.Metadata-for-.NET) repository for other common use cases.

#### Remove All Metadata Properties from a PDF

```csharp
using (Metadata metadata = new Metadata("input.pdf"))
{
    // Remove detected metadata packages
    var affected = metadata.Sanitize();
    Console.WriteLine("Properties removed: {0}", affected);

    metadata.Save("output.pdf");
}
```

#### Extract Metadata from Various Files

```csharp
foreach (string file in Directory.GetFiles("input"))
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



Explore the sample projects in this repository or open [documentation](https://docs.groupdocs.com/metadata/net/) for more topics.

### Support

Our technical support is available to all users, including those evaluating our product. We offer assistance through our [Free Support Forum](https://forum.groupdocs.com/c/metadata/) and [Paid Support Helpdesk](https://helpdesk.groupdocs.com/). Let us know if you have any questions or issues, and we'll do our best to help you.

[Product Page](https://products.groupdocs.com/metadata/net) | [Docs](https://docs.groupdocs.com/metadata/net/) | [Demos](https://products.groupdocs.com/metadata/net/demos) | [API Reference](https://reference.groupdocs.com/metadata/net/) | [Examples](https://github.com/groupdocs-metadata/GroupDocs.Metadata-for-.NET) | [Blog](https://blog.groupdocs.com/categories/groupdocs.metadata-product-family/) | [Releases](https://releases.groupdocs.com/metadata/net/) | [Free Support](https://forum.groupdocs.com/c/metadata/) | [Temporary License](https://purchase.groupdocs.com/temp-license)
