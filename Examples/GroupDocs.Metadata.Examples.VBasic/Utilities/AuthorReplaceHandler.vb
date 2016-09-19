Imports GroupDocs.Metadata.Tools

'ExStart:AuthorReplaceHandler
''' <summary>
''' This class updates author to 'Jack London'
''' </summary>
Public Class AuthorReplaceHandler
    Implements IReplaceHandler(Of MetadataProperty)

    Private _outputPath As String

    Public Sub New(outputPath As String)
        Me._outputPath = outputPath
    End Sub

    Public Function Handle([property] As MetadataProperty) As Boolean Implements IReplaceHandler(Of MetadataProperty).Handle
        ' if property name is 'author'
        If [property].Name.ToLower() = "author" Then
            ' update property value
            [property].Value = New PropertyValue("Jack London")

            ' and mark property as updated
            Return True
        End If

        ' ignore all other properties
        Return False
    End Function

    Public ReadOnly Property OutputPath() As String Implements IReplaceHandler(Of MetadataProperty).OutputPath
        Get
            Return _outputPath
        End Get
    End Property
End Class
'ExEnd:AuthorReplaceHandler