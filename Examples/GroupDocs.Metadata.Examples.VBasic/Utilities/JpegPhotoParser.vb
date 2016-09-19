
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports GroupDocs.Metadata.Formats
Imports System.IO
Imports GroupDocs.Metadata.Tools
Imports GroupDocs.Metadata.Formats.Image 

Namespace Utilities
    'ExStart:JpegPhotoParser
    Public Class JpegPhotoParser

        ' absolute path to the GroupDocs.Metadata license file.
        Private Const LicensePath As String = "GroupDocs.Metadata.lic"

        ' absolute path to the photos directory.
        Public Property PhotosDirectory() As String
            Get
                Return m_PhotosDirectory
            End Get
            Set(value As String)
                m_PhotosDirectory = value
            End Set
        End Property
        Private m_PhotosDirectory As String

        Shared Sub New()
            ' set product license 
            '             * uncomment following function if you have product license
            '             * 

            'SetInternalLicense()
        End Sub

        Public Sub New(photosDirectory As String)
            ' check if directory exists
            If Not Directory.Exists(Common.MapSourceFilePath(photosDirectory)) Then
                Throw New DirectoryNotFoundException(Convert.ToString("Directory not found: ") & photosDirectory)
            End If
            ' set property
            Me.PhotosDirectory = photosDirectory
        End Sub

        ''' <summary>
        ''' Applies the product license
        ''' </summary>
        Private Shared Sub SetInternalLicense()
            Dim license As New License()
            license.SetLicense(LicensePath)
        End Sub

        ''' <summary>
        ''' Takes manufacturer as input and returns photos made on particular camera
        ''' </summary>
        ''' <param name="manufacturer">Camera manufacturer name</param> 
        Public Sub FilterByCameraManufacturer(manufacturer As String)
            ' Map directory in source folder
            Dim sourceDirectoryPath As String = Common.MapSourceFilePath(Me.PhotosDirectory)
            ' get jpeg files
            Dim files As String() = Directory.GetFiles(sourceDirectoryPath, "*.jpg")

            Dim result As New List(Of String)()

            For Each path__1 As String In files
                ' recognize file
                Dim format As FormatBase = FormatFactory.RecognizeFormat(path__1)

                ' casting to JpegFormat
                If TypeOf format Is JpegFormat Then
                    Dim jpeg As JpegFormat = DirectCast(format, JpegFormat)

                    ' get exif data
                    Dim exif As JpegExifInfo = DirectCast(jpeg.GetExifInfo(), JpegExifInfo)

                    If exif IsNot Nothing Then
                        If String.Compare(exif.Make, manufacturer, StringComparison.OrdinalIgnoreCase) = 0 Then
                            ' add file path to list
                            result.Add(Path.GetFileName(path__1))
                        End If
                    End If
                End If
            Next
            Console.WriteLine(String.Join(vbLf, result))
        End Sub
    End Class
    'ExEnd:JpegPhotoParser
End Namespace
 
