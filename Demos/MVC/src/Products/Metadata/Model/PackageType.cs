

namespace GroupDocs.Metadata.MVC.Products.Metadata.Model
{
    /// <summary>
    /// Specifies the type of a metadata package.
    /// </summary>
    public enum PackageType
    {
        /// <summary>
        /// The type of a metadata package is undefined.
        /// </summary>
        Undefined = 0,

        /// <summary>
        /// A root metadata package containing other format-specific packages.
        /// </summary>
        Root,

        /// <summary>
        /// An XMP metadata package.
        /// </summary>
        Xmp,

        /// <summary>
        /// An EXIF metadata package,
        /// </summary>
        Exif,

        /// <summary>
        /// An IPTC metadata package,
        /// </summary>
        Iptc,

        /// <summary>
        /// A Dublin Core metadata package.
        /// </summary>
        DublinCore,

        /// <summary>
        /// A Photoshop's native metadata package.
        /// </summary>
        ImageResourceBlock,

        /// <summary>
        /// A package containing information about the format of a loaded file.
        /// </summary>
        FileFormat,

        /// <summary>
        /// A package containing digital signature metadata.
        /// </summary>
        DigitalSignature,

        /// <summary>
        /// A presentation metadata package.
        /// </summary>
        Presentation,

        /// <summary>
        /// A spreadsheet metadata package.
        /// </summary>
        Spreadsheet,

        /// <summary>
        /// A word processing metadata package.
        /// </summary>
        WordProcessing,

        /// <summary>
        /// A diagram metadata package.
        /// </summary>
        Diagram,

        /// <summary>
        /// A metadata package containing information about an electronic note file.
        /// </summary>
        Note,

        /// <summary>
        /// A metadata package containing information about a project management file.
        /// </summary>
        ProjectManagement,

        /// <summary>
        /// A PDF metadata package.
        /// </summary>
        Pdf,

        /// <summary>
        /// A package containing document statistics.
        /// </summary>
        DocumentStatistics,

        /// <summary>
        /// A metadata package containing information about a Photoshop document.
        /// </summary>
        Psd,

        /// <summary>
        /// A JPEG2000 native metadata package.
        /// </summary>
        Jpeg2000,

        /// <summary>
        /// A DICOM native metadata package.
        /// </summary>
        Dicom,

        /// <summary>
        /// A BMP native metadata package.
        /// </summary>
        Bmp,

        /// <summary>
        /// A WAV native metadata package.
        /// </summary>
        Wav,

        /// <summary>
        /// An ID3V1 tag.
        /// </summary>
        ID3V1,

        /// <summary>
        /// An ID3V2 tag.
        /// </summary>
        ID3V2,

        /// <summary>
        /// An MPEG audio native metadata package.
        /// </summary>
        MpegAudio,

        /// <summary>
        /// A Lyrics3 metadata package.
        /// </summary>
        Lyrics3,

        /// <summary>
        /// An APEv2 metadata package.
        /// </summary>
        ApeV2,

        /// <summary>
        /// An AVI video native metadata package.
        /// </summary>
        Avi,

        /// <summary>
        /// An FLV video native metadata package.
        /// </summary>
        Flv,

        /// <summary>
        /// An ASF video native metadata package.
        /// </summary>
        Asf,

        /// <summary>
        /// A QuickTime video.
        /// </summary>
        Mov,

        /// <summary>
        /// A native metadata package extracted from a video encoded with the Matroska multimedia container.
        /// </summary>
        Matroska,

        /// <summary>
        /// A native metadata package of a ZIP archive.
        /// </summary>
        Zip,

        /// <summary>
        /// A native metadata package of a VCard.
        /// </summary>
        VCard,

        /// <summary>
        /// A native metadata package of a EPUB e-book.
        /// </summary>
        Epub,

        /// <summary>
        /// An OpenType font metadata package.
        /// </summary>
        OpenType,

        /// <summary>
        /// A metadata package extracted from a CAD drawing.
        /// </summary>
        Cad,

        /// <summary>
        /// An EML message metadata package.
        /// </summary>
        Eml,

        /// <summary>
        /// An MSG message metadata package.
        /// </summary>
        Msg,

        /// <summary>
        /// A torrent file metadata package.
        /// Please find more information at <a href="https://en.wikipedia.org/wiki/Torrent_file/">https://en.wikipedia.org/wiki/Torrent_file/</a>.
        /// </summary>
        Torrent,
    }
}