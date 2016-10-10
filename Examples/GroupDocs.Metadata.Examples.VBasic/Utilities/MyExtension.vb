Imports GroupDocs.Metadata
Imports GroupDocs.Metadata.Tools
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
'ExStart:DocumentTypeDetectorDirectoryExtension
Namespace System.IO
    Public Module MyExtesion
        <Runtime.CompilerServices.Extension()> _
        Public Function GetFiles(directoryInfo As Global.System.IO.DirectoryInfo, documentType As DocumentType) As Global.System.IO.FileInfo()
            Dim files As Global.System.IO.FileInfo() = directoryInfo.GetFiles()

            ' return empty array if directory is empty
            If files.Length = 0 Then
                Return New Global.System.IO.FileInfo(-1) {}
            End If

            Dim result As New List(Of Global.System.IO.FileInfo)()

            For Each fileInfo As Global.System.IO.FileInfo In files
                Using fileFormatChecker As New FileFormatChecker(fileInfo.FullName)
                    If fileFormatChecker.VerifyFormat(documentType) Then
                        result.Add(fileInfo)
                    End If
                End Using
            Next

            Return result.ToArray()
        End Function
    End Module
End Namespace
'ExEnd:DocumentTypeDetectorDirectoryExtension