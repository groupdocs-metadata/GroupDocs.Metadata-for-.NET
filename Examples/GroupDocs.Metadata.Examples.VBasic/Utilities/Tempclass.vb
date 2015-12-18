
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports GroupDocs.Metadata.Formats.Document
Imports GroupDocs.Metadata.Standards.Doc 
Imports GroupDocs.Metadata.MetadataProperties
Imports GroupDocs.Metadata.Exceptions

Namespace Utilities
    Class Tempclass
        Public Shared Sub GetDocumentProperties(filePath As String)
            'ExStart:InvalidFormatException
            Try
                ' initialize DocFormat
                Dim docFormat As New DocFormat(Common.MapSourceFilePath(filePath))

                ' initialize metadata
                Dim docMetadata As DocMetadata = docFormat.DocumentProperties

                ' get properties
                Console.WriteLine("Built-in Properties: ")
                For Each [property] As KeyValuePair(Of String, PropertyValue) In docMetadata
                    ' check if built-in property
                    If docMetadata.IsBuiltIn([property].Key) Then
                        Console.WriteLine("{0} : {1}", [property].Key, [property].Value)
                    End If
                Next
            Catch ex As InvalidFormatException
                Console.WriteLine("File is not DOC: {0}", ex.Message)
            End Try
            'ExEnd:InvalidFormatException
        End Sub
    End Class
End Namespace
 
