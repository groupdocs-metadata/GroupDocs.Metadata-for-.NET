Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports GroupDocs.Metadata
Imports GroupDocs.Metadata.Examples.VBasic.Utilities 
Imports GroupDocs.Metadata.Tools

Namespace GroupDocs.Metadata.Examples.VBasic
    Class Program
        Public Shared Sub Main(args As String())
            ' Apply product license
            ' Uncomment following function if you have product license.

            'Common.ApplyLicense()

            '#Region "Working with Documents"

            '#Region "Working with Doc Files"

            'Get document properties of Doc file
            Documents.Doc.GetDocumentProperties()

            'Update document properties of Doc file
            Documents.Doc.UpdateDocumentProperties()

            'Remove document properties of Doc file
            Documents.Doc.RemoveDocumentProperties()

            'Add custom property in Doc file
            Documents.Doc.AddCustomProperty()

            'Get custom properties in Doc file
            Documents.Doc.GetCustomProperties()

            'Get hidden fields, merge fields and comments in Doc file
            Documents.Doc.GetHiddenData()

            'Remove merge fields in Doc file
            Documents.Doc.RemoveMergeFields()

            'Remove custom property of Doc file
            Documents.Doc.RemoveCustomProperties()

            'Clear custom property of Doc file
            Documents.Doc.ClearCustomProperties()

            'Remove document comments
            Documents.Doc.RemoveComments()

            'Update document comments
            Documents.Doc.UpdateComments()

            'update metadata and save the original file
            Documents.Doc.SaveFileAfterMetadataUpdate()

            '#End Region

            '#Region "Working with Ppt Files"

            'Get document properties of Ppt file
            Documents.Ppt.GetDocumentProperties()

            'Update document properties of Ppt file
            Documents.Ppt.UpdateDocumentProperties()

            'Remove document properties of Ppt file
            Documents.Ppt.RemoveDocumentProperties()

            'Add custom property in Ppt file
            Documents.Ppt.AddCustomProperty()

            'Get custom properties in Ppt file
            Documents.Ppt.GetCustomProperties()

            'Remove custom property of Ppt file
            Documents.Ppt.RemoveCustomProperties()

            'Gets Comments, and Hidden Slides of Ppt file
            Documents.Ppt.GetHiddenData()

            'Removes Comments, and Hidden Slides of Ppt File
            Documents.Ppt.RemoveHiddenData()

            '#End Region

            '#Region "Working with Xls Files"

            'Get document properties of Xls file
            Documents.Xls.GetDocumentProperties()

            'Update document properties of Xls file
            Documents.Xls.UpdateDocumentProperties()

            'Remove document properties of Xls file
            Documents.Xls.RemoveDocumentProperties()

            'Add custom property in Xls file
            Documents.Xls.AddCustomProperty()

            'Get custom properties in Xls file
            Documents.Xls.GetCustomProperties()

            'Remove custom property of Xls file
            Documents.Xls.RemoveCustomProperties()

            'Get Comments and Hidden Sheets in Xls file
            Documents.Xls.GetHiddenData()

            'Remove HiddenSheets and Comments in Xls file
            Documents.Xls.RemoveHiddenData()

            '#End Region

            '#Region "Working with Pdf Files"

            'Get document properties of Pdf file
            Documents.Pdf.GetDocumentProperties()

            'Update document properties of Pdf file
            Documents.Pdf.UpdateDocumentProperties()

            'Remove document properties of Pdf file
            Documents.Pdf.RemoveDocumentProperties()

            'Add custom property in Pdf file
            Documents.Pdf.AddCustomProperty()

            'Get custom properties in Pdf file
            Documents.Pdf.GetCustomProperties()

            'Remove custom property of Pdf file
            Documents.Pdf.RemoveCustomProperties()

            'Get XMP data in Pdf file
            Documents.Pdf.GetXMPProperties()

            'Update XMP data in Pdf file
            Documents.Pdf.UpdateXMPProperties()

            'Remove hidden data in Pdf file
            Documents.Pdf.RemoveHiddenData()

            '#End Region

            '#Region "Working with OneNote Files"

            'Get metadata of OneNote file
            Documents.OneNote.GetMetadata()

            'Get Pages Info of OneNote file 
            Documents.OneNote.GetPagesInfo()

            '#End Region

            '#Region "Working with MSVisio Files"

            'Set metadata of MSVisio File
            Documents.MSVisio.SetProperties()

            'Get metadata of MSVisio file
            Documents.OneNote.GetMetadata()

            '#End Region

            '#End Region

            '#Region "Working with Images"

            '#Region "Working with Jpeg2000"

            'Get XMP properties of Jpeg2000 image
            Images.JP2.GetXMPProperties()

            'Update XMP properties of Jpeg2000 image
            Images.JP2.UpdateXMPProperties()

            'Read Metadata of JP2 Format
            Images.JP2.ReadMetadataJP2()

            'Remove XMP properties of Jpeg2000 image
            Images.JP2.RemoveXMPData()

            '#End Region

            '#Region "Working with Gif"

            'Get XMP properties of Gif image
            Images.Gif.GetXMPProperties()

            'Update XMP properties of Gif image
            Images.Gif.UpdateXMPProperties()

            'Remove XMP properties of Gif image
            Images.Gif.RemoveXMPProperties()

            '#End Region

            '#Region "Working with Jpeg"

            'Get XMP properties of Jpeg image
            Images.Jpeg.GetXMPProperties()

            'Update XMP properties of Jpeg image
            Images.Jpeg.UpdateXMPProperties()

            'Update Camera Raw XMP values of Jpeg image
            Images.Jpeg.UpdateCameraRawXMPProperties()

            'Update Pagged Text XMP values of Jpeg image
            Images.Jpeg.UpdatePagedTextXMPProperties()

            'Update Basic Job XMP properties of Jpeg image
            Images.Jpeg.UpdateBasicJobXMPProperties()

            'Update thumbnail in XMP data of Jpeg image
            Images.Jpeg.UpdateThumbnailInXMPData()

            'Remove XMP properties of Jpeg image
            Images.Jpeg.RemoveXMPData()

            'Get Exif Info of Jpeg image
            Images.Jpeg.GetExifInfo()

            'Update Exif Info of Jpeg image
            Images.Jpeg.UpdateExifInfo()

            'Update Exif Info of Jpeg image using properties
            Images.Jpeg.UpdateExifInfoUsingProperties()

            'Remove GPS Info of Jpeg image
            Images.Jpeg.RemoveGPSData()

            'Remove Exif Info of Jpeg image
            Images.Jpeg.RemoveExifInfo()

            'Read IPTC properties in Jpeg image
            Images.Jpeg.GetIPTCMetadata()

            'Read IPTC XMP metadata in Jpeg image
            Images.Jpeg.GetIPTCPhotoMetadataFromXMP()

            'Update IPTC XMP metadata in Jpeg image
            Images.Jpeg.UpdateIPTCPhotoMetadataFromXMP()

            'Update IPTC metadata in Jpeg image
            Images.Jpeg.UpdateIPTCMetadataOfJPEG()

            'Remove IPTC metadata in Jpeg image
            Images.Jpeg.RemoveIPTCMetadataOfJPEG()

            'Detects Bar-Codes in teh Jpeg Image
            Images.Jpeg.DetectBarcodeinJpeg()

            ' Read Specific Exif tag
            Images.Jpeg.ReadExifTag()

            ' Read All Exif tags
            Images.Jpeg.ReadAllExifTags()

            ' Read Image Resource Blocks
            Images.Jpeg.ReadImageResourceBlocks()

            ' Remove Photoshop Metadata 
            Images.Jpeg.RemovePhotoshopMetadata()

            '#End Region

            '#Region "Working with Png"

            'Get XMP properties of Png image
            Images.Png.GetXMPProperties()

            'Update XMP properties of Png image
            Images.Png.UpdateXMPData()

            'Update XMP values of Png image
            Images.Png.UpdateXMPValues()

            'Update Camera Raw XMP values of Png image
            Images.Png.UpdateCameraRawXMPProperties()

            'Update Pagged Text XMP values of Png image
            Images.Png.UpdatePagedTextXMPProperties()

            'Remove XMP properties of Png image
            Images.Png.RemoveXMPData()

            '#End Region

            '#Region "Working with Tiff"

            'Get XMP properties of Tiff image
            Images.Tiff.GetXMPProperties()

            'Read File Directory Tags of Tiff Image
            Images.Tiff.ReadTiffFileDirectoryTags()

            'Read Exif Info of Tiff image
            Images.Tiff.GetExifInfo()

            'Update Exif Info of Tiff image
            Images.Tiff.UpdateExifInfo()

            'Update Exif Info of Tiff image
            Images.Tiff.UpdateExifInfoUsingProperties()

            'Remove Exif Info of Tiff image
            Images.Tiff.RemoveExifInfo()

            ' Read IPTC Metadata 
            Images.Tiff.ReadIPTCMetadata()

            '#End Region

            '#End Region

            '#Region "Working with PSD"

            ' Read metadata of PSD file
            Images.Psd.GetPsdInfo()

            ' Read XMP metadata of PSD file
            Images.Psd.GetXMPProperties()

            ' Read Image Resource Block
            Images.Psd.ReadImageResourceBlocks()

            ' Read IPTC Metadata 
            Images.Psd.ReadIPTCMetadata()

            '#End Region

            '#Region "Working CAD files"

            'Read basic metadata properties in DWG file
            Images.Cad.GetMetadatPropertiesInDWG()

            'Read basic metadata properties in DXF file
            Images.Cad.GetMetadatPropertiesInDXF()
            '#End Region

            '#Region "Working emails"
            '#Region "Working with Outlook Email"
            'Get Outlook email metadata
            Emails.OutLook.GetOutlookEmailMetadata()

            'Remove Outlook email attachment
            Emails.OutLook.RemoveOutlookEmailAttachments()

            'Remove Outlook email metadata
            Emails.OutLook.RemoveOutlookEmailMetadata()
            '#End Region

            '#Region "Working with Email message"
            'Get email metadata
            Emails.Eml.GetEmailMetadata()

            'Remove email attachment
            Emails.Eml.RemoveEmailAttachments()

            'Remove email metadata
            Emails.Eml.RemoveEmailMetadata()
            '#End Region
            '#End Region

            '#Region "Working with APIs"

            'Compare document metadata
            APIs.Document.CompareDocument("Documents/Pdf/sample2.pdf", "Documents/Pdf/sample.pdf", ComparerSearchType.Difference)

            'Search document metadata in document
            APIs.Document.SearchMetadata("Documents/Xls/sample.xls", "Author", SearchCondition.Contains)

            'Search document metadata in image
            APIs.Image.SearchMetadata("Images/Tiff/sample.tif", "Owner", SearchCondition.Contains)

            'Replace metadata properties in documents
            APIs.Document.ReplaceMetadataProperties("Documents/Doc/sample.doc")

            'Replace author name using custom Replace Handler in documents
            APIs.Document.ReplaceAuthorName("Documents/Doc/sample.doc")

            'Detect protection in documents
            Documents.DetectProtection("Documents/Doc/sample.doc")

            'Detect document format at runtime in a folder
            Documents.RuntimeFormatDetection("Documents/Doc")


            'Compare Exif metadata in images
            APIs.Image.CompareExifMetadata("Images/Jpeg/sample.jpg", "Images/Jpeg/sample2.jpg", ComparerSearchType.Difference)

            'Export metadata
            APIs.ExportMetadata("Documents/Pdf/sample2.pdf", ExportTypes.ToExcel)

            '#End Region

            '#Region "Working with Utilities"
            'ExStart:DocCleanerUsage
            'DocCleaner: Cleans metadata from all Doc files, created by an author, in a directory
            Dim docCleaner As New DocCleaner("Documents/Doc")
            docCleaner.RemoveMetadataByAuthor("Usman Aziz")
            'ExEnd:DocCleanerUsage

            'ExStart:PhotoCleanerUsage
            'PhotoCleaner: Cleans GPS data from photos in a directory
            Dim photoCleaner As New PhotoCleaner("Images/Jpeg")
            photoCleaner.RemoveExifLocation()
            'ExEnd:PhotoCleanerUsage

            'ExStart:JpegPhotoParserUsage
            'JpegPhotoParser: Finds photos taken on a specific camera in a directory
            Dim jpegPhotoParser As New JpegPhotoParser("Images/Jpeg")
            jpegPhotoParser.FilterByCameraManufacturer("Sony")
            'ExEnd:JpegPhotoParserUsage

            'ExStart:FormatRecognizerUsage
            'FormatRecognizer: Recognizes the format of all files in a directory 
            Common.GetFileFormats("Documents/Doc")
            'ExEnd:FormatRecognizerUsage

            '#End Region

            '#Region "Working with MP3 Files"

            'Export metadata of Mp3 format to Excel.
            AudioFormats.Mp3.ExportMetadataToExcel()

            ' Detect MP3 audio format
            AudioFormats.Mp3.DetectMp3Format()

            'Read ID3v2 tag in MP3 format
            AudioFormats.Mp3.ReadID3v2Tag()

            'Read ID3v1 tag in MP3 format
            AudioFormats.Mp3.ReadID3v1Tag()

            'Read MPEG audio information
            AudioFormats.Mp3.ReadMPEGAudioInfo()

            ' Read Layrics3 Tag
            AudioFormats.Mp3.ReadLayrics3Tag()

            ' Update ID3v1Tag
            AudioFormats.Mp3.UpdateID3v1Tag()
            '#End Region

            '#Region "Working with WAV Files"

            ' Detect WAV format
            AudioFormats.Wav.DetectWavFormat()

            ' Read Audio Details 
            AudioFormats.Wav.ReadAudioDetails()

            '#End Region

            Console.ReadKey()

        End Sub
    End Class
End Namespace