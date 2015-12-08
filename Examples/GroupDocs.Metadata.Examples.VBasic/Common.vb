
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.IO
Imports GroupDocs.Metadata.Tools
Imports GroupDocs.Metadata

Namespace GroupDocs.Metadata.Examples.VBasic
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

    End Class
End Namespace

 

