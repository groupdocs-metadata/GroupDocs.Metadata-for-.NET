using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GroupDocs.Metadata;
using GroupDocs.Metadata.Examples.Utilities.CSharp;
using GroupDocs.Metadata.Tools;
using GroupDocs.Metadata.Examples.CSharp.Utilities;
using System.IO;

namespace GroupDocs.Metadata.Examples.CSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            /* Apply product license
             * Uncomment following function if you have product license.
             */
            Common.ApplyLicense();

            #region using Dynabic.Metered Account
            //Common.UseDynabicMeteredAccount();
            #endregion

            #region Working with Documents

            #region Working with Doc Files

            //Get document properties of Doc file
            //Documents.Doc.GetDocumentProperties();

            //Update document properties of Doc file
            //Documents.Doc.UpdateDocumentProperties();

            //Remove document properties of Doc file
            //Documents.Doc.RemoveDocumentProperties();

            //Add custom property in Doc file
            ////Documents.Doc.AddCustomProperty();

            //Get custom properties in Doc file
            ////Documents.Doc.GetCustomProperties();

            //Get hidden fields, merge fields and comments in Doc file
            ////Documents.Doc.GetHiddenData();

            //Remove merge fields in Doc file
            ////Documents.Doc.RemoveMergeFields();

            //Remove custom property of Doc file
            ////Documents.Doc.RemoveCustomProperties();

            //Clear custom property of Doc file
            ////Documents.Doc.ClearCustomProperties();

            //Remove document comments
            ////Documents.Doc.RemoveComments();

            //Update document comments
            ////Documents.Doc.UpdateComments();

            //update metadata and save the original file
            ////Documents.Doc.SaveFileAfterMetadataUpdate();

            //Read all metadata Keys of word document
            //Documents.Doc.ReadMetadataUsingKeys("Different Formats");

            //Read Document info of a word document
            //Documents.Doc.ReadDocumentInfo();

            //Display file type of the word document
            //Documents.Doc.DisplayFileType();

            //Read Digital Signature from word document
            //Documents.Doc.ReadDigitalSignature();

            //Remove Digital Signature from word document
            //Documents.Doc.RemoveDigitalSignature();

            //Read all track changes in word document
            //Documents.Doc.ReadAllRevisions();

            //Accept all changes in a revision
            //Documents.Doc.AcceptAllChanges();

            //Reject all changes in a revision
            //Documents.Doc.RejectAllChanges();

            //Read DublinCore Metadata
            //Documents.Doc.ReadDublinCoreMetadata();

            //Read ImageCover using Metadata Utility
            //Documents.Doc.ReadImageCoverMetadataUtility();

            //Find Metadata Using Regex
            //Documents.Doc.FindMetadataUsingRegex();

            //Replace Metadata Using Regex
            //Documents.Doc.ReplaceMetadataUsingRegex();
            #endregion

            #region Working with Ppt Files

            //Get document properties of Ppt file
            //Documents.Ppt.GetDocumentProperties();

            //Update document properties of Ppt file
            //Documents.Ppt.UpdateDocumentProperties();

            //Remove document properties of Ppt file
            //Documents.Ppt.RemoveDocumentProperties();

            //Add custom property in Ppt file
            //Documents.Ppt.AddCustomProperty();

            //Get custom properties in Ppt file
            //Documents.Ppt.GetCustomProperties();

            //Remove custom property of Ppt file
            //Documents.Ppt.RemoveCustomProperties();

            //Gets Comments, and Hidden Slides of Ppt file
            //Documents.Ppt.GetHiddenData();

            //Removes Comments, and Hidden Slides of Ppt File
            //Documents.Ppt.RemoveHiddenData();

            //Reads document properties faster
            //Documents.Ppt.ImprovedMetadataReading();
            #endregion

            #region Working with Xls Files

            //Get document properties of Xls file
            //Documents.Xls.GetDocumentProperties();

            //Update document properties of Xls file
            //Documents.Xls.UpdateDocumentProperties();

            //Remove document properties of Xls file
            //Documents.Xls.RemoveDocumentProperties();

            //Add custom property in Xls file
            //Documents.Xls.AddCustomProperty();

            //Get custom properties in Xls file
            //Documents.Xls.GetCustomProperties();

            //Remove custom property of Xls file
            //Documents.Xls.RemoveCustomProperties();

            //Get Comments and Hidden Sheets in Xls file
            //Documents.Xls.GetHiddenData();

            //Remove HiddenSheets and Comments in Xls file
            //Documents.Xls.RemoveHiddenData();

            //Gets Content type document properties in Xls file
            //Documents.Xls.GetContentTypeDocumentProperties();

            //Export content type properties of Xls file to Csv/Xls
            //Documents.Xls.ContentTypePropertiesExport();

            //Add content type properties
            //Documents.Xls.AddContentTypeProperty();

            //Reads thumnail in excel file
            //Documents.Xls.ReadThumbnailXls();

            //Read ImageCover using MetadataUtility
            //Documents.Xls.ReadImageCoverMetadataUtility();

            #endregion

            #region Working with Pdf Files

            //Get document properties of Pdf file
            //Documents.Pdf.GetDocumentProperties();

            //Update document properties of Pdf file
            //Documents.Pdf.UpdateDocumentProperties();

            //Remove document properties of Pdf file
            //Documents.Pdf.RemoveDocumentProperties();

            //Add custom property in Pdf file
            //Documents.Pdf.AddCustomProperty();

            //Get custom properties in Pdf file
            //Documents.Pdf.GetCustomProperties();

            //Remove custom property of Pdf file
            //Documents.Pdf.RemoveCustomProperties();

            //Get XMP data in Pdf file
            //Documents.Pdf.GetXMPProperties();

            //Read all XMP Keys in Pdf file
            //Documents.Pdf.GetXMPPropertiesUsingKey("Different Formats");

            //Update XMP data in Pdf file
            //Documents.Pdf.UpdateXMPProperties();

            //Remove hidden data in Pdf file
            //Documents.Pdf.RemoveHiddenData();

            //Loads only existing metadata keys
            //Documents.Pdf.LoadExistingMetadataKeys();

            //Read DublinCore Metadata
            //Documents.Pdf.ReadDublinCoreMetadata();

            #endregion

            #region Working with OneNote Files

            //Get metadata of OneNote file
            //Documents.OneNote.GetMetadata();

            //Get Pages Info of OneNote file 
            //Documents.OneNote.GetPagesInfo();

            #endregion

            #region Working with MSVisio Files

            //Set metadata of MSVisio File
            //Documents.MSVisio.SetProperties();

            //Get metadata of MSVisio file
            //Documents.OneNote.GetMetadata();

            #endregion

            #region Working with Odt files
            //Read metadata of odt File
            //Documents.ODT.GetOdtMetadata();
            //Update metadata of odt file
            //Documents.ODT.UpdateOdtMetadata();
            #endregion

            #region Working with EPUB
            //Detects EPUB file format
            //Documents.EPUB.DetectEPUBFormat();
            //Read EPUB file format metadata
            //Documents.EPUB.ReadEPUBFormatMetadata();
            //Read Dublin Core Metadata
            //Documents.EPUB.ReadDublinCoreMetadata();
            //Read Image cover from EPUB Format 
            //Documents.EPUB.ReadImageCover();
            //Read Image Cover using Metadata Utility
            //Documents.EPUB.ReadImageCoverMetadataUtility();
            //Read version of EPUB Package
            //Documents.EPUB.ReadEPUBPackageVersion();
            //Read DublinCore Metadata using unified approach
            //Documents.EPUB.ReadDublinCoreMetadataUtility();
            //Get Torrent Metadata Using Stream
            //Documents.EPUB.GetMetadataUsingStream();

            #endregion

            #region Working with ODS files
            //Documents.ODS.ReadOdsMetadata();
            #endregion

            #region Working with MS Project files
            //Get MS Project Metadata 
            //Documents.MSProject.GetMetadata();
            //Update MS Project Metadata
            //Documents.MSProject.UpdateMetadata();
            //Clean MS Project Metadata
            //Documents.MSProject.CleanMetadata();     
            //Documents.MSProject.UpdateMetadataUsingStream();
            #endregion

            //Reads thumbnail in documents
            //Documents.ReadThumbnail("Documents/Doc/sample.docx");

            //Loads DocumentInfo property in DocumentFormat using lazy loading pattern
            //Documents.LazyLoadDocumentInfoProperty("Documents/Doc/sample2.doc");
            #endregion

            #region Working with Images

            #region Working with Jpeg2000

            //Get XMP properties of Jpeg2000 image
            //Images.JP2.GetXMPProperties();

            //Update XMP properties of Jpeg2000 image
            //Images.JP2.UpdateXMPProperties();

            //Read Metadata of JP2 Format
            //Images.JP2.ReadMetadataJP2();

            //Remove XMP properties of Jpeg2000 image
            //Images.JP2.RemoveXMPData();

            #endregion

            #region Working with Gif

            //Get XMP properties of Gif image
            //Images.Gif.GetXMPProperties();

            //Get XMP properties of Gif image using Stream
            //Images.Gif.GetXMPPropertiesUsingStream();

            //Update XMP properties of Gif image
            //Images.Gif.UpdateXMPProperties();

            //Update XMP properties of Gif image using Stream
            //Images.Gif.UpdateXMPPropertiesUsingStream();

            //Remove XMP properties of Gif image
            //Images.Gif.RemoveXMPProperties();

            //Remove Medatadata of Gif image 
            //Images.Gif.RemoveMetadata();

            //Find XMP Metadata Using Regex
            //Images.Gif.FindXmpMetadataUsingRegex();

            //Update XMP Metadata Using Regex
            //Images.Gif.ReplaceXmpMetadataUsingRegex();

            #endregion

            #region Working with Jpeg

            //Get XMP properties of Jpeg image
            //Images.Jpeg.GetXMPProperties();

            //Get XMP Properties using Stream
            //mages.Jpeg.GetXMPPropertiesUsingStream();

            //Update XMP properties of Jpeg image
            //Images.Jpeg.UpdateXMPProperties();

            //Update XMP properties of using Stream
            //Images.Jpeg.UpdateXMPPropertiesUsingStream();

            //Update Camera Raw XMP values of Jpeg image
            //Images.Jpeg.UpdateCameraRawXMPProperties();

            //Update Pagged Text XMP values of Jpeg image
            //Images.Jpeg.UpdatePagedTextXMPProperties();

            //Update Basic Job XMP properties of Jpeg image
            //Images.Jpeg.UpdateBasicJobXMPProperties();

            //Update thumbnail in XMP data of Jpeg image
            //Images.Jpeg.UpdateThumbnailInXMPData();

            //Remove XMP properties of Jpeg image
            //Images.Jpeg.RemoveXMPData();

            //Get Exif Info of Jpeg image
            //Images.Jpeg.GetExifInfo();

            //Update Exif Info of Jpeg image
            //Images.Jpeg.UpdateExifInfo();

            //Update Exif Info of Jpeg image using properties
            //Images.Jpeg.UpdateExifInfoUsingProperties();

            //Delete Exif data faster
            //Images.Jpeg.FastRemoveExifData();

            //Update Exif data faster
            //Images.Jpeg.FasterUpdateExifData();

            //Remove GPS Info of Jpeg image
            //Images.Jpeg.RemoveGPSData();

            //Remove Exif Info of Jpeg image
            //Images.Jpeg.RemoveExifInfo();

            //Read IPTC properties in Jpeg image
            //Images.Jpeg.GetIPTCMetadata();

            //Read IPTC XMP metadata in Jpeg image
            //Images.Jpeg.GetIPTCPhotoMetadataFromXMP();

            //Update IPTC XMP metadata in Jpeg image
            //Images.Jpeg.UpdateIPTCPhotoMetadataFromXMP();

            //Update IPTC metadata in Jpeg image
            //Images.Jpeg.UpdateIPTCMetadataOfJPEG();

            //Remove IPTC metadata in Jpeg image
            //Images.Jpeg.RemoveIPTCMetadataOfJPEG();

            //Detects Bar-Codes in teh Jpeg Image
            //Images.Jpeg.DetectBarcodeinJpeg();

            // Read Specific Exif tag
            //Images.Jpeg.ReadExifTag();

            // Read All Exif tags
            //Images.Jpeg.ReadAllExifTags();

            // Read Image Resource Blocks
            //Images.Jpeg.ReadImageResourceBlocks();

            // Remove Photoshop Metadata 
            //Images.Jpeg.RemovePhotoshopMetadata();

            //Read Sony maker notes
            //Images.Jpeg.ReadSonyMakerNotes();

            //Read Nikon maker notes
            //Images.Jpeg.ReadNikonMakerNotes();

            //Read Canon maker notes
            //Images.Jpeg.ReadCanonMakerNotes();

            //Read Panasonic maker notes
            //Images.Jpeg.ReadPanasonicMakerNotes();

            //Update additional IFD tags 
            //Images.Jpeg.UpdateIfdTags();

            //Add or update Tiff tags in exif in jpeg file
            //Images.Jpeg.AddUpdateTiffTagsInExif();

            //Reads SRational TIFF tag in JPEG and TIFF image formats
            //Images.Jpeg.ReadSRationalTifftag();

            //The method loads and save EXIF metadata with better speed
            //Images.Jpeg.EXIFMetadataWithBetterSpeed();

            //Find EXIF Metadata using regex
            //Images.Jpeg.FindEXIFMetadataUsingRegex();

            //Replace EXIF Metadata using regex
            //Images.Jpeg.ReplaceEXIFMetadataUsingRegex();

            //Get Tiff Tag using Exif Properties 
            //Images.Jpeg.GetTiffTagsUsingExifProperties();

            #endregion

            #region Working with Png

            //Get XMP properties of Png image
            //Images.Png.GetXMPProperties();

            //Update XMP properties of Png image
            //Images.Png.UpdateXMPData();

            //Update XMP values of Png image
            //Images.Png.UpdateXMPValues();

            //Update Camera Raw XMP values of Png image
            //Images.Png.UpdateCameraRawXMPProperties();

            //Update Pagged Text XMP values of Png image
            //Images.Png.UpdatePagedTextXMPProperties();

            //Remove XMP properties of Png image
            //Images.Png.RemoveXMPData();

            #endregion

            #region Working with Tiff

            //Get XMP properties of Tiff image
            //Images.Tiff.GetXMPProperties();

            //Get XMP properties of Tiff image using Stream
            //Images.Tiff.GetXMPPropertiesUsingStream();

            //Read File Directory Tags of Tiff Image
            //Images.Tiff.ReadTiffFileDirectoryTags();

            //Read Exif Info of Tiff image
            //Images.Tiff.GetExifInfo();

            //Update Exif Info of Tiff image
            //Images.Tiff.UpdateExifInfo();

            //Update Exif Info of Tiff Image using Stream
            //Images.Tiff.UpdateExifInfoUsingStream();

            //Update Exif Info of Tiff image
            //Images.Tiff.UpdateExifInfoUsingProperties();

            //Remove Exif Info of Tiff image
            //Images.Tiff.RemoveExifInfo();

            // Read IPTC Metadata 
            //Images.Tiff.ReadIPTCMetadata();

            //Remove XMP Metadata
            //Images.Tiff.RemoveXMPMetadata();

            //Extract Values of Certain Tiff Tags 
            //Images.Tiff.ExtractSpecificTiffTags();

            //Update Exif Info of Tiff image using shortcut properties
            //Images.Tiff.UpdateExifMetadataUsingShortcutProperties();

            //Update Exif Info of Tiff image by replacing tag collection 
            //Images.Tiff.UpdateExifMetadatByReplacingTagCollection();

            //Update Exif IFD Tags of Tiff image using shortcut properties
            //Images.Tiff.UpdateExifIFDTagsUsingShortcutProperties();

            //Update Exif IFD Tags of Tiff image by replacing tag collection 
            //Images.Tiff.UpdateExifIFDTagsByReplacingTagCollection();

            #endregion

            #region Working with Wmf
            //Get metadata properties of Wmf image
            //Images.WMF.GetMetadataProperties();
            #endregion

            #region Working with WebP
            //Get metadata properties of WebP image
            //Images.WebP.GetMetadataProperties();
            #endregion

            #region Working with Emf
            //Get metadata properties of emf image
            //Images.EMF.GetMetadataProperties();
            #endregion

            #region Working with Djvu
            //Get metadata properties of emf image
            //Images.DJVU.GetMetadataProperties();
            #endregion

            #region Working with BMP images
            //Get metadata properties of bmp image
            //Images.BMP.GetMetadataProperties();
            //Read Header properties of a bmp image
            //Images.BMP.GetHeaderProperties();
            #endregion

            #region Retrieve Image Size
            //Retrive the height and width of images of supported formats
            //Images.RetrieveImageSize("Images/SampleImages");
            #endregion

            #region Working with Dicom images
            //detect DICOM format 
            //Images.DICOM.DetectDicomFormat();
            //Read metadata of a DICOM file
            //Images.DICOM.GetMetadataProperties();
            //export metadata of a DICOM file to csv/xls file
            //Images.DICOM.ExportMetadata();

            #endregion

            #region Read Byte order of images
            //Reads byte order of images of supported formats
            //Images.ReadByteOrder("Images/SampleImages");


            #endregion

            #endregion

            #region Working with PSD

            // Read metadata of PSD file
            //Images.Psd.GetPsdInfo();

            // Read XMP metadata of PSD file
            //Images.Psd.GetXMPProperties();

            // Read Image Resource Block
            //Images.Psd.ReadImageResourceBlocks();

            // Read IPTC Metadata 
            //Images.Psd.ReadIPTCMetadata();

            // Update IPTC Metadata 
            //Images.Psd.UpdateIPTCMetadata();

            // Remove IPTC Metadata 
            //Images.Psd.RemoveIPTCMetadata();

            // Read IPTC Metadata PSD file using stream
            //Images.Psd.ReadIPTCMetadatasUsingStream();

            // Update IPTC Metadata using steam
            //Images.Psd.UpdateIPTCMetadataUsingStream();

            // Read Layers
            //Images.Psd.ReadLayers();

            // Read EXIF Metadata
            //Images.Psd.ReadEXIFMetadata();

            #endregion

            #region Working CAD files

            //Read basic metadata properties in DWG file
            //Images.Cad.GetMetadatPropertiesInDWG();

            //Read basic metadata properties in DXF file
            //Images.Cad.GetMetadatPropertiesInDXF();
            #endregion

            #region Working emails
            #region Working with Outlook Email
            //Get Outlook email metadata
            //Emails.OutLook.GetOutlookEmailMetadata();

            //Remove Outlook email attachment
            //Emails.OutLook.RemoveOutlookEmailAttachments();

            //Remove Outlook email metadata
            //Emails.OutLook.RemoveOutlookEmailMetadata();
            #endregion

            #region Working with Email message
            //Get email metadata
            //Emails.Eml.GetEmailMetadata();

            //Remove email attachment
            //Emails.Eml.RemoveEmailAttachments();

            //Remove email metadata
            //Emails.Eml.RemoveEmailMetadata();
            #endregion
            #endregion

            #region Working with APIs

            //Compare document metadata
            //APIs.Document.CompareDocument("Documents/Pdf/sample2.pdf", "Documents/Pdf/sample.pdf", ComparerSearchType.Difference);

            //Search document metadata in document
            //APIs.Document.SearchMetadata("Documents/Xls/sample.xls", "Author", SearchCondition.Contains);

            //Search document metadata in image
            //APIs.Image.SearchMetadata("Images/Tiff/sample.tif", "Owner", SearchCondition.Contains);

            //Replace metadata properties in documents
            //APIs.Document.ReplaceMetadataProperties("Documents/Doc/sample.doc");

            //Replace author name using custom Replace Handler in documents
            //APIs.Document.ReplaceAuthorName("Documents/Doc/sample.doc");

            //Detect protection in documents
            //Documents.DetectProtection("Documents/Doc/sample.doc");

            //Detect document format at runtime in a folder
            //Documents.RuntimeFormatDetection("Documents/Doc");


            //Compare Exif metadata in images
            //APIs.Image.CompareExifMetadata("Images/Jpeg/sample.jpg", "Images/Jpeg/sample2.jpg", ComparerSearchType.Difference);

            //Export metadata
            //APIs.ExportMetadata("Documents/Pdf/sample2.pdf", ExportTypes.ToExcel);

            #endregion

            #region Working with Utilities
            //ExStart:DocCleanerUsage
            //DocCleaner: Cleans metadata from all Doc files, created by an author, in a directory
            //DocCleaner docCleaner = new DocCleaner("Documents/Doc");
            //docCleaner.RemoveMetadataByAuthor("Usman Aziz");
            //ExEnd:DocCleanerUsage

            //ExStart:PhotoCleanerUsage
            //PhotoCleaner: Cleans GPS data from photos in a directory
            //PhotoCleaner photoCleaner = new PhotoCleaner("Images/Jpeg");
            //photoCleaner.RemoveExifLocation();
            //ExEnd:PhotoCleanerUsage

            //ExStart:JpegPhotoParserUsage
            //JpegPhotoParser: Finds photos taken on a specific camera in a directory
            //JpegPhotoParser jpegPhotoParser = new JpegPhotoParser("Images/Jpeg");
            //jpegPhotoParser.FilterByCameraManufacturer("Sony");
            //ExEnd:JpegPhotoParserUsage

            //ExStart:FormatRecognizerUsage
            //FormatRecognizer: Recognizes the format of all files in a directory 
            //Common.GetFileFormats("Documents/Doc");
            //ExEnd:FormatRecognizerUsage


            //DocumentTypeDetector : Gets files of a specific document type
            //ExStart:DocumentTypeDetectorUsage
            // path to the input directory
            //const string dir = @"C:\download files";
            // get all jpeg files
            //string[] files = DocumentTypeDetector.GetFiles(dir, DocumentType.Jpeg);
            //ExEnd:DocumentTypeDetectorUsage

            //DocumentTypeDetector : Gets files of a specific document type
            //ExStart:DocumentTypeDetectorUsage2
            // path to the input directory
            //const string dir1 = @"C:\download files";
            // initialize DirectoryInfo
            //DirectoryInfo directoryInfo = new DirectoryInfo(dir1);
            // get files using extension method
            //FileInfo[] files2 = directoryInfo.GetFiles(DocumentType.Jpeg);
            //ExEnd:DocumentTypeDetectorUsage2

            ////MIMETypeDetector : Retrieves MIME type of the specific file or file stream.
            ////ExStart:MIMETypeDetectorUsage
            //// path to the input directory
            //   const string dir = "Documents/Doc";
            //// get all jpeg files
            //   MIMETypeDetector.GetMimeType(dir);
            ////ExEnd:MIMETypeDetectorUsage

            ////MIMETypeDetector : Using MIMEType property in FormatBase class or it's children.
            ////ExStart:MIMETypeDetectorUsage2
            //// path to a file
            //   const string filePath = "Documents/Doc/sample.doc";
            //// get all jpeg files
            //MIMETypeDetector.GetMimeTypeUsingFormatBaseApproach(filePath);
            ////ExEnd:MIMETypeDetectorUsage2

            //ExStart:ReadMetadataUsingKey
            //Read metadata property by defined key for any supported format
            //Common.ReadMetadataUsingKey("Different Formats");
            //ExEnd:ReadMetadataUsingKey

            //ExStart:MetadataEnumerationUsage
            //Enumerates any type of metadata
            //Common.EnumerateMetadata("Different Formats");
            //ExEnd:MetadataEnumerationUsage

            #endregion

            #region Working with MP3 Files

            //Export metadata of Mp3 format to Excel.
            //AudioFormats.Mp3.ExportMetadataToExcel();

            // Detect MP3 audio format
            //AudioFormats.Mp3.DetectMp3Format();

            //Read ID3v2 tag in MP3 format
            //AudioFormats.Mp3.ReadID3v2Tag();

            // Update ID3v2Tag
            //AudioFormats.Mp3.UpdateID3v2Tag();

            // Remove ID3v2Tag
            //AudioFormats.Mp3.RemoveID3v2Tag();

            //Read ID3v1 tag in MP3 format
            //AudioFormats.Mp3.ReadID3v1Tag();

            //Read MPEG audio information
            //AudioFormats.Mp3.ReadMPEGAudioInfo();

            // Read Layrics3 Tag
            //AudioFormats.Mp3.ReadLyrics3Tag();

            // Update Lyrics3 Tag
            AudioFormats.Mp3.UpdateLyrics3Tag();

            // Update Lyrics3 Tag by replacing whole field collection
            AudioFormats.Mp3.UpdateLyrics3TagByReplacingWholefieldCollection();

            // Update Lyrics3 Tag by replacing whole tag
            AudioFormats.Mp3.UpdateLyrics3TagByReplacingWholeTag();

            // Remove Lyrics3 Tag
            //AudioFormats.Mp3.RemoveLyrics3Tag();

            // Clean metadata 
            //AudioFormats.Mp3.CleanMetadata();

            // Remove APEv2 Tag
            //AudioFormats.Mp3.RemoveAPEV2Tag();


            // Update ID3v1Tag
            //AudioFormats.Mp3.UpdateID3v1Tag();

            //Read ID3 Metadata directtly from MP3
            //AudioFormats.Mp3.ReadId3MetadataDirectly();

            //Read APEV2 tag in MP3 files
            //AudioFormats.Mp3.ReadApev2Tag();

            //Validate ID3 input metadata before saviing
            //AudioFormats.Mp3.ValidateID3Metadata();

            //Read additional properties from ID3v2 tag
            //AudioFormats.Mp3.ReadAdditionalID3v2Properties();

            //Update ID3v2 tag using properties 
            //AudioFormats.Mp3.UpdateID3v2TagUsingProperties();

            //Update ID3v1 tag using properties 
            //AudioFormats.Mp3.UpdateID3v1TagUsingProperties();

            //Ability to read Image cover from ID3 audio tag
            //AudioFormats.Mp3.ReadImageCoverID3();

            //Read Image Cover using Metadata Utility
            //AudioFormats.Mp3.ReadImageCoverMetadataUtility();

            //Update or Remove image cover from ID3 audio tag
            //AudioFormats.Mp3.UpdateOrRemoveImageCoverID3();

            //Read ID3v2 tag in MP3 format using stream
            //AudioFormats.Mp3.ReadID3v2TagUsingStream();

            // Update ID3v2Tag
            //AudioFormats.Mp3.UpdateID3v2TagUsingStream();


            #endregion

            #region Working with WAV Files

            // Detect WAV format
            //AudioFormats.Wav.DetectWavFormat();

            // Read Audio Details 
            //AudioFormats.Wav.ReadAudioDetails();

            // Update XMP Metadata  
            //AudioFormats.Wav.UpdateXmpMetadata();

            //Remove XMP Metadata
            //AudioFormats.Wav.RemoveXmpMetadata();

            //Update XMP Metadata using stream
            //AudioFormats.Wav.UpdateXmpMetadataUsingStream();



            #endregion

            #region Working with Video Formats
            //Detect AVI format using format factory
            //VideoFormats.Avi.DetectAviFormat();

            //Read Header information in AVI format
            //VideoFormats.Avi.ReadAviMainHeader();

            //Export Metadata of AVI Format file
            //VideoFormats.Avi.ExportMetadata();

            //Read,write or update xmp metadata in AVI format
            //VideoFormats.Avi.DealWithXmpMetaData();

            //Clean metadata in AVI format
            //VideoFormats.Avi.CleanMetadata();

            //Clean metadata in AVI using Stream
            //VideoFormats.Avi.ReadAviMainHeaderUsingStream();

            //Detect Mov file format using format factory
            //VideoFormats.Mov.DetectMovFormat();

            //Get Mov format metadata
            //VideoFormats.Mov.GetMovFormatMetadata();

            //Get Mov format metadata
            //VideoFormats.Mov.GetMovFormatMetadata();

            #endregion

            #region Working with Archives

            #region Working with Zip format 
            //Detect Zip file format using format factory
            //Archives.Zip.DetectZipFormat();

            //Get Zip format metadata
            //Archives.Zip.GetZipMatadata();

            // Get ZIP format metadata using stream
            //Archives.Zip.GetZipMatadataUsingStream();

            //Remove ZIP format 
            //Archives.Zip.RemoveComment();

            //Update ZIP format Comment 
            //Archives.Zip.UpdateComment();

            #endregion

            #endregion

            #region Working with Torrent Files
            #region Working with Bit Torrent
            //Read Bit Torrent File Metadata
            //Torrent.BitTorrent.GetTorrentMetadata();
            //Update Bit Torrent File Metadata 
            //Torrent.BitTorrent.UpdateTorrentMedata();
            //Read Bit Torrent File Metadata Using Stream
            //Torrent.BitTorrent.GetTorrentMetadataUsingStream();
            #endregion
            #endregion

            #region Working with DublinCore Metadata
            //Get DublinCore of supported file formats using MetadataUtility class
            //DublinCore.GetDublinCoreMetadata();

            //Get DublinCore Metadata of supported file formats using IDublinCore Interface
            //DublinCore.GetDublinCoreMetadataUsingIDublinCore();



            #endregion
            Console.ReadKey();



        }
    }
}
