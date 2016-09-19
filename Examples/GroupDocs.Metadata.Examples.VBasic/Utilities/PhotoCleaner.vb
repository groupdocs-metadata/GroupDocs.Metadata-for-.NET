Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports GroupDocs.Metadata.Tools 
Imports System.IO
Imports GroupDocs.Metadata.Formats.Image

Namespace Utilities
    'ExStart:PhotoCleaner
    Public Class PhotoCleaner
        ' absolute path to the GroupDocs.Metadata license file.
        Private Const LicensePath As String = "GroupDocs.Metadata.lic"

        ' absolute path to the photos directory.
        Public Property CleanerPath() As String
            Get
                Return m_CleanerPath
            End Get
            Set(value As String)
                m_CleanerPath = value
            End Set
        End Property
        Private m_CleanerPath As String

        Shared Sub New()
            ' set product license 
            '             * uncomment following function if you have product license
            '             * 

            'SetInternalLicense()
        End Sub

        Public Sub New(cleanerPath As String)
            ' check if directory exists
            If Not Directory.Exists(Common.MapSourceFilePath(cleanerPath)) Then
                Throw New DirectoryNotFoundException(Convert.ToString("Directory not found: ") & cleanerPath)
            End If
            ' set property
            Me.CleanerPath = cleanerPath
        End Sub
        ''' <summary>
        ''' Applies the product license
        ''' </summary>
        Private Shared Sub SetInternalLicense()
            Dim license As New License()
            license.SetLicense(LicensePath)
        End Sub
        ''' <summary>
        ''' Removes GPS data and updates the image files in a directory
        ''' </summary>
        Public Sub RemoveExifLocation()
            ' Map directory in source folder
            Dim sourceDirectoryPath As String = Common.MapSourceFilePath(Me.CleanerPath)

            ' get array of file in specific directory
            Dim files As String() = Directory.GetFiles(sourceDirectoryPath)

            For Each path As String In files
                ' get EXIF data if exists
                Dim exifMetadata As ExifMetadata = DirectCast(MetadataUtility.ExtractSpecificMetadata(path, MetadataType.EXIF), ExifMetadata)

                If exifMetadata IsNot Nothing Then
                    Dim exifInfo As ExifInfo = exifMetadata.Data

                    If exifInfo.GPSData IsNot Nothing Then
                        ' set altitude, latitude and longitude to null values
                        exifInfo.GPSData.Altitude = Nothing
                        exifInfo.GPSData.Latitude = Nothing
                        exifInfo.GPSData.LatitudeRef = Nothing
                        exifInfo.GPSData.Longitude = Nothing
                        exifInfo.GPSData.LongitudeRef = Nothing
                    End If

                    ' and update file
                    MetadataUtility.UpdateMetadata(path, exifMetadata)
                End If
            Next
            Console.WriteLine("Press any key to exit.")
        End Sub
    End Class
    'ExEnd:PhotoCleaner
End Namespace


