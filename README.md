## GroupDocs.Metadata for .NET



[Product Page](https://products.groupdocs.com/metadata/net) | [Docs](https://docs.groupdocs.com/metadata/net/) | [Demos](https://products.groupdocs.com/metadata/net/demos) | [API Reference](https://reference.groupdocs.com/metadata/net/) | [Examples](https://github.com/groupdocs-metadata/GroupDocs.Metadata-for-.NET) | [Blog](https://blog.groupdocs.com/categories/groupdocs.metadata-product-family/) | [Releases](https://releases.groupdocs.com/metadata/net/) | [Free Support](https://forum.groupdocs.com/c/metadata/) | [Temporary License](https://purchase.groupdocs.com/temp-license)



GroupDocs.Metadata for .NET is a full-featured .NET class library enabling developers to read, edit, and remove metadata from over 110 document, image, audio, video, and other file formats—including Word, Excel, PowerPoint, PDF, images like JPEG, PNG, TIFF, HEIF, and AVIF, audio and video formats, emails, CAD, fonts, and more—while supporting major metadata standards such as XMP, EXIF, IPTC, ID3, and format-specific properties.

### Features

- Read, update and remove metadata from [115+ file formats](https://docs.groupdocs.com/metadata/net/supported-document-formats/).
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
- **Archives**: ZIP, RAR, 7Z, TAR, AAR, BZ2
- **Fonts**: OTF, TTF, TTC, OTC
- **CAD**: DWG, DXF
- **3D**: FBX, STL, 3DS, DAE, GLTF
- **Visio**: VSD, VSDX, VDX, VSS, VSX, VTX
- **OneNote**: ONE
- **GIS**: KML, GPX, GEOJSON, GML, OSM, SHP
- **Other formats**: MPP, MPT, TORRENT, VCF, VCR

Supports **115+ formats**. See the [supported file formats](https://docs.groupdocs.com/metadata/net/supported-document-formats/) table for the complete list.

### Supported Frameworks

**Supported Frameworks:** .NET Framework 4.7.2 or higher, .NET 6.0 or higher, .NET 8.0 or higher

### Getting Started


To get started with `GroupDocs.Metadata` install the package using the command at the top of this NuGet page, or run:

```powershell
dotnet add package GroupDocs.Metadata
```

You can run the following C# samples to see how the library works. Also check the [Examples](https://github.com/groupdocs-metadata/GroupDocs.Metadata-for-.NET) repository for other common use cases.

#### Remove all recognized metadata properties from a file

Sometimes you may need to just remove all or clean metadata properties without applying any filters.

```csharp
using (Metadata metadata = new Metadata("input.pdf"))
{
	// Remove detected metadata packages
	var affected = metadata.Sanitize();
	Console.WriteLine("Properties removed: {0}", affected);

	metadata.Save("output.pdf");
}
```

#### Use tags to find most common metadata properties

To make manipulating metadata in your code easier we attach specific tags to the most commonly used metadata properties extracted from a file.

```csharp
// "input.pptx" is an absolute or relative path to your document. Ex: @"C:\Docs\source.pptx"
using (Metadata metadata = new Metadata("input.pptx"))
{
	// Fetch all the properties satisfying the predicate:
	// property contains the name of the last document editor OR the date/time the document was last modified
	var properties = metadata.FindProperties(p => p.Tags.Contains(Tags.Person.Editor) || p.Tags.Contains(Tags.Time.Modified));

	foreach (var property in properties)
	{
		Console.WriteLine("Property name: {0}, Property value: {1}", property.Name, property.Value);
	}
}
```

#### Generate Document Preview

If you need to implement a UI for your application it can be useful to generate image previews for a document the users are going to work with.

```csharp
using (Metadata metadata = new Metadata("input.docx"))
{
	PreviewOptions previewOptions = new PreviewOptions(pageNumber => File.Create($"output\\result_{pageNumber}.png"));
	previewOptions.PreviewFormat = PreviewOptions.PreviewFormats.PNG;
	previewOptions.PageNumbers = new int[] { 1 };
	metadata.GeneratePreview(previewOptions);
}
```

#### Get Document Info

GroupDocs.Metadata allows users to get meta information of a document which includes.

```csharp
// "input.xlsx" is an absolute or relative path to your document. Ex: @"C:\Docs\source.xlsx"
using (Metadata metadata = new Metadata("input.xlsx"))
{
	if (metadata.FileFormat != FileFormat.Unknown)
	{
		IDocumentInfo info = metadata.GetDocumentInfo();
		Console.WriteLine("File format: {0}", info.FileType.FileFormat);
		Console.WriteLine("File extension: {0}", info.FileType.Extension);
		Console.WriteLine("MIME Type: {0}", info.FileType.MimeType);
		Console.WriteLine("Number of pages: {0}", info.PageCount);
		Console.WriteLine("Document size: {0} bytes", info.Size);
		Console.WriteLine("Is document encrypted: {0}", info.IsEncrypted);
	}
}
```



Explore the sample projects in this repository or open [documentation](https://docs.groupdocs.com/metadata/net/) for more topics.

### Support

Our technical support is available to all users, including those evaluating our product. We offer assistance through our [Free Support Forum](https://forum.groupdocs.com/c/metadata/) and [Paid Support Helpdesk](https://helpdesk.groupdocs.com/). Let us know if you have any questions or issues, and we'll do our best to help you.

[Product Page](https://products.groupdocs.com/metadata/net) | [Docs](https://docs.groupdocs.com/metadata/net/) | [Demos](https://products.groupdocs.com/metadata/net/demos) | [API Reference](https://reference.groupdocs.com/metadata/net/) | [Examples](https://github.com/groupdocs-metadata/GroupDocs.Metadata-for-.NET) | [Blog](https://blog.groupdocs.com/categories/groupdocs.metadata-product-family/) | [Releases](https://releases.groupdocs.com/metadata/net/) | [Free Support](https://forum.groupdocs.com/c/metadata/) | [Temporary License](https://purchase.groupdocs.com/temp-license)
