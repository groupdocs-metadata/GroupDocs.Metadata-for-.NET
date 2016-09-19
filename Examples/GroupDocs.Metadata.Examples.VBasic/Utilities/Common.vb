
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.IO
Imports GroupDocs.Metadata.Tools
Imports GroupDocs.Metadata
Imports GroupDocs.Metadata.Formats 

Namespace Utilities
    Public NotInheritable Class Common
        Private Sub New()
        End Sub
        'ExStart:CommonProperties
        Private Const SourceFolderPath As String = "../../../Data/Source/"
        Private Const DestinationFolderPath As String = "../../../Data/Destination/"
        Private Const LicenseFilePath As String = "Groupdocs.Total.lic"
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
        
    End Class
End Namespace



