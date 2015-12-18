
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.IO
Imports GroupDocs.Metadata.Tools
Imports GroupDocs.Metadata
Imports GroupDocs.Metadata.Formats
Imports GroupDocs.Metadata.MetadataProperties

Namespace Utilities
    Public NotInheritable Class Common
        Private Sub New()
        End Sub
        'ExStart:CommonProperties
        Private Const SourceFolderPath As String = "../../../Data/Source/"
        Private Const DestinationFolderPath As String = "../../../Data/Destination/"
        Private Const LicenseFilePath As String = "Groupdocs.Metadata.lic"
        'ExEnd:CommonProperties

        'ExStart:MapSourceFilePath
        ''' <summary>
        ''' Maps source file path
        ''' </summary>
        ''' <param name="SourceFileName">Source File Name</param>
        ''' <returns>Returns complete path of source file</returns>
        Public Shared Function MapSourceFilePath(SourceFileName As String) As String
            Try
                Return SourceFolderPath & SourceFileName
            Catch exp As Exception
                Console.WriteLine(exp.Message)
                Return exp.Message
            End Try
        End Function
        'ExEnd:MapSourceFilePath
        'ExStart:MapDestinationFilePath
        ''' <summary>
        ''' Maps destination file path
        ''' </summary>
        ''' <param name="DestinationFileName">Destination File Name</param>
        ''' <returns>Returns complete path of destination file</returns>
        Public Shared Function MapDestinationFilePath(DestinationFileName As String) As String
            Try
                Return DestinationFolderPath & DestinationFileName
            Catch exp As Exception
                Console.WriteLine(exp.Message)
                Return exp.Message
            End Try
        End Function
        'ExEnd:MapDestinationFilePath

        'ExStart:ApplyLicense
        ''' <summary>
        ''' Applies product license
        ''' </summary>
        Public Shared Sub ApplyLicense()
            Try
                ' initialize License
                Dim lic As New License()

                ' apply license
                lic.SetLicense(LicenseFilePath)
            Catch exp As Exception
                Console.WriteLine(exp.Message)
            End Try
        End Sub
        'ExEnd:ApplyLicense

        'ExStart:FormatRecognizer
        ''' <summary>
        ''' Gets directory name and recognizes format of files in that directory
        ''' </summary>
        ''' <param name="directorPath">Directory path</param>
        Public Shared Sub GetFileFormats(directorPath As String)
            Try
                ' path to the document
                directorPath = Common.MapSourceFilePath(directorPath)

                ' get array of files inside directory
                Dim files As String() = Directory.GetFiles(directorPath)

                For Each path__1 As String In files
                    ' recognize file by it's signature
                    Dim format As FormatBase = FormatFactory.RecognizeFormat(path__1)

                    If format IsNot Nothing Then
                        Console.WriteLine("File: {0}, type: {1}", Path.GetFileName(path__1), format.Type)
                    End If
                Next
            Catch exp As Exception
                Console.WriteLine(exp.Message)
            End Try
        End Sub
        'ExEnd:FormatRecognizer

        'ExStart:MetadataComparer
        ''' <summary>
        ''' Compares and finds metadata difference of two files 
        ''' </summary>
        ''' <param name="filePath1">First file path</param>
        ''' <param name="filePath2">Second file path</param>
        Public Shared Sub CompareFilesMetadata(filePath1 As String, filePath2 As String)
            Try
                ' path to the document
                filePath1 = Common.MapSourceFilePath(filePath1)

                ' path to the compared document
                filePath2 = Common.MapSourceFilePath(filePath2)

                ' get diffences between metadata
                Dim diffenceProperties As MetadataPropertyCollection = MetadataUtility.CompareDoc(filePath1, filePath2)

                ' go through collection and show differences
                For Each [property] As MetadataProperty In diffenceProperties
                    Console.WriteLine("Property = {0}, value = {1}", [property].Name, [property].Value)
                Next
            Catch exp As Exception
                Console.WriteLine(exp.Message)
            End Try
        End Sub
        'ExEnd:MetadataComparer
    End Class
End Namespace



