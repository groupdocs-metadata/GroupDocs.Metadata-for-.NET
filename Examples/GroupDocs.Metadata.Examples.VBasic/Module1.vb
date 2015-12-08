﻿
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports GroupDocs.Metadata

Namespace GroupDocs.Metadata.Examples.VBasic

    Module Module1

        Sub Main()
            ' Apply product license
            '             * Uncomment following function if you have product license.
            '             

            Common.ApplyLicense()

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
            'Images.Jpeg.GetExifInfo()

            'Update Exif Info of Jpeg image
            'Images.Jpeg.UpdateExifInfo()

            'Remove Exif Info of Jpeg image
            'Images.Jpeg.RemoveExifInfo()

            '#End Region

            '#Region "Working with Png"

            'Get XMP properties of Png image
            Images.Png.GetXMPProperties()

            'Update XMP properties of Png image
            Images.Png.UpdateXMPData()

            'Remove XMP properties of Png image
            Images.Png.RemoveXMPData()

            '#End Region
 

            '#End Region
            Console.ReadKey()

        End Sub

    End Module
End Namespace