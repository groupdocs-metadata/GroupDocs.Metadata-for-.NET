
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports GroupDocs.Metadata.Formats
Imports GroupDocs.Metadata.Formats.Document 
Imports GroupDocs.Metadata.Tools
Imports System.IO 

Namespace Utilities
    'ExStart:DocCleaner
    Public Class DocCleaner
        ' Absolute path to the GroupDocs.Metadata license file
        Private Const LicensePath As String = "GroupDocs.Metadata.lic"

        ' Absolute path to the documents directory
        Public Property DocumentsPath() As String
            Get
                Return m_DocumentsPath
            End Get
            Set(value As String)
                m_DocumentsPath = value
            End Set
        End Property
        Private m_DocumentsPath As String

        Shared Sub New()
            ' set product license 
            '             * uncomment following function if you have product license
            '             * 

            'SetInternalLicense()
        End Sub

        Public Sub New(documentsPath As String)
            ' check if directory exists
            If Not Directory.Exists(Common.MapSourceFilePath(documentsPath)) Then
                Throw New DirectoryNotFoundException(Convert.ToString("Directory not found: ") & documentsPath)
            End If

            Me.DocumentsPath = documentsPath
        End Sub
        ''' <summary>
        ''' Applies the product license
        ''' </summary>
        Private Shared Sub SetInternalLicense()
            Dim license As New License()
            license.SetLicense(LicensePath)
        End Sub

        ''' <summary>
        ''' Takes author name and removes metadata in files created by specified author
        ''' </summary>
        ''' <param name="authorName">Author name</param>
        Public Sub RemoveMetadataByAuthor(authorName As String)
            ' Map directory in source folder
            Dim sourceDirectoryPath As String = Common.MapSourceFilePath(Me.DocumentsPath)

            ' get files presented in target directory
            Dim files As String() = Directory.GetFiles(sourceDirectoryPath)

            For Each path__1 As String In files
                ' recognize format
                Dim format As FormatBase = FormatFactory.RecognizeFormat(path__1)

                ' initialize DocFormat
                Dim docFormat As DocFormat = TryCast(format, DocFormat)
                If docFormat IsNot Nothing Then
                    ' get document properties
                    Dim properties As DocMetadata = docFormat.DocumentProperties

                    ' check if author is the same
                    If String.Equals(properties.Author, authorName, StringComparison.OrdinalIgnoreCase) Then
                        ' remove comments
                        docFormat.ClearComments()

                        Dim customKeys As New List(Of String)()

                        ' find all custom keys
                        For Each keyValuePair As KeyValuePair(Of String, PropertyValue) In properties
                            If Not properties.IsBuiltIn(keyValuePair.Key) Then
                                customKeys.Add(keyValuePair.Key)
                            End If
                        Next

                        ' and remove all of them
                        For Each key As String In customKeys
                            properties.Remove(key)
                        Next
                        '====== yet to change things =========================
                        ' and commit changes
                        Dim fileName As String = Path.GetFileName(path__1)
                        Dim outputFilePath As String = Common.MapDestinationFilePath(Convert.ToString(Me.DocumentsPath & Convert.ToString("/")) & fileName)
                        '=====================================================
                        docFormat.Save(outputFilePath)
                    End If
                End If
            Next

            Console.WriteLine("Press any key to exit.")
        End Sub
    End Class
    'ExEnd:DocCleaner
End Namespace
 
