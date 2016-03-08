
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports GroupDocs.Metadata
Imports GroupDocs.Metadata.Examples.VBasic.Utilities
Namespace GroupDocs.Metadata.Examples.VBasic

    Module Module1

        Sub Main()
            ' Apply product license
            '             * Uncomment following function if you have product license.
            '             

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

            'Remove custom property of Doc file
            Documents.Doc.RemoveCustomProperties()

            'Clear custom property of Doc file
            Documents.Doc.ClearCustomProperties()

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

            '#End Region

            '#Region "Working with OneNote Files"

            'Get metadata of OneNote file
            Documents.OneNote.GetMetadata()

            'Get Pages Info of OneNote file 
            Documents.OneNote.GetPagesInfo()

            '#End Region

            '#End Region


            '#Region "Working with Images"

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

            'Remove XMP properties of Jpeg image
            Images.Jpeg.RemoveXMPData()

            'Get Exif Info of Jpeg image
            Images.Jpeg.GetExifInfo()

            'Update Exif Info of Jpeg image
            Images.Jpeg.UpdateExifInfo()

            'Remove Exif Info of Jpeg image
            Images.Jpeg.RemoveExifInfo()

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

            'Get Exif Info of Tiff image
            Images.Tiff.GetExifInfo()

            'Update Exif Info of Tiff image
            Images.Tiff.UpdateExifInfo()

            'Remove Exif Info of Tiff image
            Images.Tiff.RemoveExifInfo()

            '#End Region

            '#End Region
            '#Region "Working with PSD"

            'Get metadata of PSD file
            Images.Psd.GetPsdInfo()

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


            '#Region "Working with Utilities"
            'ExStart:DocCleanerUsage
            'DocCleaner: Cleans metadata from all Doc files, created by an author, in a directory
            Dim docCleaner As New DocCleaner("Documents/Doc")
            docCleaner.RemoveMetadataByAuthor("Usman Aziz")
            'ExEnd:DocCleanerUsage

            'ExStart:MetadataComparerUsage
            'MetadataComparer: Compares metadata of two files and returns properties that which are different in second file 
            Common.CompareFilesMetadata("Documents/Doc/sample1.doc", "Documents/Doc/sample2.doc")
            'ExEnd:MetadataComparerUsage

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
            Common.GetFileFormats("Documents/Pdf")
            'ExEnd:FormatRecognizerUsage


            '#End Region


            Console.ReadKey()

        End Sub

    End Module
End Namespace
