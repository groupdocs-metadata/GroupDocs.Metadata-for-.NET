Imports GroupDocs.Metadata.Tools

'ExStart:DocumentTypeDetector
Public NotInheritable Class DocumentTypeDetector
    Private Sub New()
    End Sub
    ''' <summary>
    ''' Gets and returns document type in the file
    ''' </summary>
    ''' <param name="path">File Path</param> 
    Public Shared Function GetDocumentType(path As String) As DocumentType
        Using fileFormatChecker As New FileFormatChecker(path)
            Return fileFormatChecker.GetDocumentType()
        End Using
    End Function

    ''' <summary>
    ''' Gets and returns files of a specific document type
    ''' </summary>
    ''' <param name="directory">Directory Path</param>
    ''' <param name="documentType">Document Type</param>
    ''' <returns>String array containing file paths</returns>
    Public Shared Function GetFiles(directory As String, documentType As DocumentType) As String()
        ' get all files using Directory.GetFiles approach
        Dim files As String() = Global.System.IO.Directory.GetFiles(directory, "*.*")

        ' return empty array if directory is empty
        If files.Length = 0 Then
            Return New String(-1) {}
        End If

        Dim result As New List(Of String)()

        For Each path As String In files
            Using fileFormatChecker As New FileFormatChecker(path)
                If fileFormatChecker.VerifyFormat(documentType) Then
                    result.Add(path)
                End If
            End Using
        Next

        Return result.ToArray()
    End Function

End Class
'ExEnd:DocumentTypeDetector
