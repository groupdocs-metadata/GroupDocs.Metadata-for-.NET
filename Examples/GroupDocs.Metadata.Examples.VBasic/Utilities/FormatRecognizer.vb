
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.IO
Imports GroupDocs.Metadata.Formats
Imports GroupDocs.Metadata.Tools

Namespace Utilities
    'ExStart:FormatRecognizer
    Public Class FormatRecognizer
        ' absolute path to the GroupDocs.Metadata license file.
        Private Const LicensePath As String = "GroupDocs.Metadata.lic"

        Shared Sub New()
            ' set product license 
            '             * uncomment following function if you have product license
            '             * 

            SetInternalLicense()
        End Sub

        ''' <summary>
        ''' Applies the product license
        ''' </summary>
        Private Shared Sub SetInternalLicense()

            Dim license As New License()
            license.SetLicense(LicensePath)
        End Sub

        ''' <summary>
        ''' Gets directory name and recognizes format of files in that directory
        ''' </summary>
        ''' <param name="directorPath">Directory path</param>
        Public Sub GetFileFormats(directorPath As String)
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
    End Class
    'ExEnd:FormatRecognizer
End Namespace
 
