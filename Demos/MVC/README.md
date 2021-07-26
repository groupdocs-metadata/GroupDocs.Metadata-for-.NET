![Alt text](https://groupdocs-metadata.github.io/resources/image/banner.png "GroupDocs.Metadata")
# GroupDocs.Metadata for .NET MVC Example

[![Build status](https://ci.appveyor.com/api/projects/status/t40gr8bgr1msty7c/branch/master?svg=true)](https://ci.appveyor.com/project/bobkovalex/groupdocs-metadata-for-net-mvc/branch/master)
[![Codacy Badge](https://api.codacy.com/project/badge/Grade/91132beed1914c699aea25281659efbc)](https://www.codacy.com/gh/groupdocs-metadata/GroupDocs.Metadata-for-.NET-MVC?utm_source=github.com&amp;utm_medium=referral&amp;utm_content=groupdocs-metadata/GroupDocs.Metadata-for-.NET-MVC&amp;utm_campaign=Badge_Grade)
[![GitHub license](https://img.shields.io/github/license/groupdocs-metadata/GroupDocs.Metadata-for-.NET-MVC.svg)](https://github.com/groupdocs-metadata/GroupDocs.Metadata-for-.NET-MVC/blob/master/LICENSE)

## System Requirements
- .NET Framework 4.5
- Visual Studio 2015

## Document Metadata API for .NET MVC
[GroupDocs.Metadata for .NET](https://products.groupdocs.com/metadata/net) API allows you to add, edit, update or delete metadata in Office Documents (such as MS Word, MS Excel, MS Powerpoint), video files, audio files and much more! Over 80 file formats are supported.

**Note:** without a license application will run in trial mode, purchase [GroupDocs.Metadata for .NET license](https://purchase.groupdocs.com/order-online-step-1-of-8.aspx) or request [GroupDocs.Metadata for .NET temporary license](https://purchase.groupdocs.com/temporary-license).

## Supported document Formats

| Family                      | Formats                                                                                                                            |
| --------------------------- |:---------------------------------------------------------------------------------------------------------------------------------- |
| Portable Document Format    | `PDF`                                                                                                                              |
| Microsoft Word              | `DOC`, `DOCM` , `DOCX`, `DOT`, `DOTM`, `DOTX`                                                                                      |
| Microsoft Excel             | `XLS`, `XLSB`, `XLSM`, `XLSX`, `XLT`, `XLTM`, `XLTX`                                                                               |
| Microsoft PowerPoint        | `PPT`, `POT`, `POTM`, `POTX`, `PPS`, `PPSM`, `PPSX`, `PPTM`, `PPTX`                                                                |
| Microsoft Visio             | `VSD`, `VDW`, `VDX`, `VSDX`, `VSS`, `VST`, `VSX`, `VTX`                                                                            |
| Microsoft Project           | `MPP`                                                                                                                       |
| Microsoft Outlook           | `EML`, `EMLX`, `MSG`                                                                                                               |
| Microsoft OneNote           | `ONE`                                                                                                               |
| OpenDocument Formats        | `ODT`, `ODP`, `ODS`, `OTT`                                                                                                         |
| Photoshop                   | `PSD`                                                                                                                              |
| Metafiles                   | `EMF`, `WMF`                                                                                                                              |
| vCard                       | `VCF`, `VCR`                                                                                                      |
| AutoCAD Drawing File Format | `DGN`, `DWG`, `DXF`                                                                                                                |
| Image files                 | `BMP`, `CAL`, `DCX`, `DIB`, `EMF`, `GIF`, `JP2`, `JPG`, `MIL`, `MIL`, `PCD`, `PCT`, `PCX`, `PNG`, `PSD`, `RAS`, `TGA`,`TIFF`,`WMF` |
| Electronic publication      | `EPUB`                                                                                                                             |
| OpenType Fonts              | `OTF`, `OTC`, `TTF`, `TTC`                                                                                                                              |
| Audio                       | `MP3`, `WAV`                                                                                                                              | 
| Video                       | `AVI`, `MOV`, `QT`, `FLV`                                                                                                                              | 
| Matroska Media Container    | `MKV`, `MKA`, `MK3D`, `WEBM`                                                                                                                              |
| Other                       | `EPUB`, `ZIP`, `TORRENT`, `ASF`, `DJVU`                                                                                                                              | 

## Demo Video
Comming Soon

## Features
- Add Metadata to Office Documents
- Edit or update Metadata in Office Documents
- Remove Metadata from Office Documents
- Clean, modern and intuitive design
- Easily switchable colour theme (create your own colour theme in 5 minutes)
- Responsive design
- Mobile support (open application on any mobile device)
- Support over 50 documents and image formats
- Fully customizable navigation panel
- Open password protected documents
- Download documents
- Upload documents
- Print document
- Smooth document scrolling
- Multi-language support for displaying errors
- Cross-browser support (Safari, Chrome, Opera, Firefox)
- Cross-platform support (Windows, Linux, MacOS)

## How to run

You can run this sample by one of following methods

#### Build from source

Download [source code](https://github.com/groupdocs-metadata/GroupDocs.Metadata-for-.NET-MVC/archive/master.zip) from github or clone this repository.

```bash
git clone https://github.com/groupdocs-metadata/GroupDocs.Metadata-for-.NET-MVC
```

Open solution in the VisualStudio.
Update common parameters in `web.config` and example related properties in the `configuration.yml` to meet your requirements.

Open http://localhost:8080/Metadata in your favorite browser

#### Docker image
Comming Soon

### Configuration
For all methods above you can adjust settings in `configuration.yml`. By default in this sample will lookup for license file in `./Licenses` folder, so you can simply put your license file in that folder or specify relative/absolute path by setting `licensePath` value in `configuration.yml`.

#### Metadata configuration options

| Option                 | Type    |   Default value   | Description                                                                                                                                  |
| ---------------------- | ------- |:-----------------:|:-------------------------------------------------------------------------------------------------------------------------------------------- |
| **`filesDirectory`**   | String  | `DocumentSamples` | Files directory path. Indicates where uploaded and predefined files are stored. It can be absolute or relative path                          |
| **`defaultDocument`**  | String  |                   | Absolute path to default document that will be loaded automaticaly.                                                                          |
| **`preloadPageCount`** | Integer |        `0`        | Indicate how many pages from a document should be loaded, remaining pages will be loaded on page scrolling.Set `0` to load all pages at once |
| **`cache`**            | Boolean |      `true`       | Set true to enable cache                                                                                                                     |

## Troubleshooting
### How to set custom baseURL
BaseURL is fetched from address bar however you can set custom baseURL by adding *forRoot* parameter at [app.module.ts](https://github.com/groupdocs-metadata/GroupDocs.Metadata-for-.NET-MVC/blob/master/src/client/apps/metadata/src/app/app.module.ts#L10)

**Example:**
```js
ViewerModule.forRoot("http://localhost:8080")
```

## License
The MIT License (MIT). 

Please have a look at the LICENSE.md for more details

## GroupDocs Document Viewer on other platforms/frameworks

- JAVA DropWizard (Comming Soon)
- JAVA Spring Boot (Comming Soon)
- .NET WebForms [Metadata](https://github.com/groupdocs-metadata/GroupDocs.Metadata-for-.NET-WebForms)

## Resources
- **Website:** [www.groupdocs.com](http://www.groupdocs.com)
- **Product Home:** [GroupDocs.Metadata for .NET](https://products.groupdocs.com/metadata/net)
- **Product API References:** [GroupDocs.Metadata for .NET API](https://apireference.groupdocs.com/net/metadata)
- **Download:** [Download GroupDocs.Metadata for .NET](http://downloads.groupdocs.com/metadata/net)
- **Documentation:** [GroupDocs.Metadata for .NET Documentation](https://docs.groupdocs.com/display/metadatanet/Home)
- **Free Support Forum:** [GroupDocs.Metadata for .NET Free Support Forum](https://forum.groupdocs.com/c/metadata)
- **Paid Support Helpdesk:** [GroupDocs.Metadata for .NET Paid Support Helpdesk](https://helpdesk.groupdocs.com)
- **Blog:** [GroupDocs.Metadata for .NET Blog](https://blog.groupdocs.com/category/groupdocs-metadata-product-family/)
- **Search:** [GroupDocs.Metadata for .NET Search](https://search.groupdocs.com/)
