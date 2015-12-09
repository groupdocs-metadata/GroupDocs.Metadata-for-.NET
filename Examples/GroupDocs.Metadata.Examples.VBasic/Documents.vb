
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports GroupDocs.Metadata.Formats.Document
Imports GroupDocs.Metadata.Standards.Doc
Imports GroupDocs.Metadata.MetadataProperties
Imports GroupDocs.Metadata.Standards.Pdf
Imports GroupDocs.Metadata.Standards.Ppt
Imports GroupDocs.Metadata.Standards.Xls

Namespace GroupDocs.Metadata.Examples.VBasic
    Public NotInheritable Class Documents
        Private Sub New()
        End Sub
        Public NotInheritable Class Doc
            Private Sub New()
            End Sub
            ' initialize file path
            Private Const filePath As String = "Documents/Doc/sample.doc"

#Region "working with built-in document properties"

            ''' <summary>
            ''' Gets builtin document properties from Doc file 
            ''' </summary> 
            Public Shared Sub GetDocumentProperties()
                Try
                    'ExStart:GetBuiltinDocumentPropertiesDocFormat
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
                        'ExEnd:GetBuiltinDocumentPropertiesDocFormat
                    Next
                Catch exp As Exception
                    Console.WriteLine(exp.Message)
                End Try
            End Sub
            ''' <summary>
            ''' Updates document properties of Doc file and creates output file
            ''' </summary> 
            Public Shared Sub UpdateDocumentProperties()
                Try
                    'ExStart:UpdateBuiltinDocumentPropertiesDocFormat
                    ' initialize DocFormat
                    Dim docFormat As New DocFormat(Common.MapSourceFilePath(filePath))

                    ' initialize DocMetadata
                    Dim docMetadata As DocMetadata = docFormat.DocumentProperties

                    'update document property...
                    docMetadata.Author = "Usman"
                    docMetadata.Company = "Aspose"
                    docMetadata.Manager = "Usman Aziz"

                    'save output file...
                    docFormat.Save(Common.MapDestinationFilePath(filePath))

                    'ExEnd:UpdateBuiltinDocumentPropertiesDocFormat

                    Console.WriteLine("Updated Successfully.")
                Catch exp As Exception
                    Console.WriteLine(exp.Message)
                End Try

            End Sub
            ''' <summary>
            ''' Removes document properties of Doc file and creates output file
            ''' </summary> 
            Public Shared Sub RemoveDocumentProperties()
                Try
                    'ExStart:RemoveBuiltinDocumentPropertiesDocFormat
                    ' initialize Docformat
                    Dim docFormat As New DocFormat(Common.MapSourceFilePath(filePath))

                    'Clean metadata
                    docFormat.CleanMetadata()

                    ' save output file...
                    docFormat.Save(Common.MapDestinationFilePath(filePath))

                    'ExEnd:RemoveBuiltinDocumentPropertiesDocFormat


                    Console.WriteLine("File saved in destination folder.")
                Catch exp As Exception
                    Console.WriteLine(exp.Message)
                End Try
            End Sub
#End Region

#Region "working with custom properties"
            ''' <summary>
            ''' Adds custom property in Doc file and creates output file
            ''' </summary> 
            Public Shared Sub AddCustomProperty()
                Try
                    'ExStart:AddCustomPropertyDocFormat
                    ' initialize DocFormat
                    Dim docFormat As New DocFormat(Common.MapSourceFilePath(filePath))

                    ' initialize DocMetadata
                    Dim metadata As DocMetadata = docFormat.DocumentProperties


                    Dim propertyName As String = "New Custom Property"
                    Dim propertyValue As String = "123"

                    ' add boolean key
                    If Not metadata.ContainsKey(propertyName) Then
                        ' add property
                        metadata.Add(propertyName, propertyValue)
                    End If

                    ' save file in destination folder
                    docFormat.Save(Common.MapDestinationFilePath(filePath))
                    'ExEnd:AddCustomPropertyDocFormat


                    Console.WriteLine("File saved in destination folder.")
                Catch exp As Exception
                    Console.WriteLine(exp.Message)
                End Try
            End Sub
            ''' <summary>
            ''' Gets custom properties of Doc file
            ''' </summary>
            Public Shared Sub GetCustomProperties()
                Try
                    'ExStart:GetCustomPropertiesDocFormat
                    ' initialize DocFormat
                    Dim docFormat As New DocFormat(Common.MapSourceFilePath(filePath))

                    ' initialize metadata
                    Dim docMetadata As DocMetadata = docFormat.DocumentProperties

                    ' get properties  
                    Console.WriteLine(vbLf & "Custom Properties")
                    For Each keyValuePair As KeyValuePair(Of String, PropertyValue) In docMetadata
                        ' check if property is not built-in
                        If Not docMetadata.IsBuiltIn(keyValuePair.Key) Then
                            ' get property value
                            Dim propertyValue As PropertyValue = docMetadata(keyValuePair.Key)
                            Console.WriteLine("Key: {0}, Type:{1}, Value: {2}", keyValuePair.Key, propertyValue.Type, propertyValue)
                        End If
                        'ExEnd:GetCustomPropertiesDocFormat
                    Next
                Catch exp As Exception
                    Console.WriteLine(exp.Message)
                End Try
            End Sub
            ''' <summary>
            ''' Removes custom properties of Doc file and creates output file
            ''' </summary> 
            Public Shared Sub RemoveCustomProperties()
                Try
                    'ExStart:RemoveCustomPropertyDocFormat
                    ' initialize DocFormat
                    Dim docFormat As New DocFormat(Common.MapSourceFilePath(filePath))

                    ' initialize DocMetadata
                    Dim metadata As DocMetadata = docFormat.DocumentProperties

                    Dim propertyName As String = "New Custom Property"

                    ' check if property is not built-in
                    If metadata.ContainsKey(propertyName) Then
                        If Not metadata.IsBuiltIn(propertyName) Then
                            ' remove property

                            metadata.Remove(propertyName)
                        Else
                            Console.WriteLine("Can not remove built-in property.")
                        End If
                    Else
                        Console.WriteLine("Property does not exist.")
                    End If

                    Dim isexist As Boolean = metadata.ContainsKey(propertyName)

                    ' save file in destination folder
                    docFormat.Save(Common.MapDestinationFilePath(filePath))
                    'ExEnd:RemoveCustomPropertyDocFormat

                    Console.WriteLine("File saved in destination folder.")
                Catch exp As Exception
                    Console.WriteLine(exp.Message)
                End Try
            End Sub
#End Region

#Region "working with document comments"
            ''' <summary>
            ''' Gets document comments of Doc file
            ''' </summary> 
            Public Shared Sub GetDocumentComments()
                Try

                    ' initialize DocFormat
                    Dim docFormat As New DocFormat(Common.MapSourceFilePath(filePath))

                    'get comments...
                    Dim comments As DocComment() = docFormat.ExtractComments()

                    'get commnets by author...
                    'DocComment[] comments = docFormat.ExtractComments("USMAN");

                    ' display comments
                    For Each comment As DocComment In comments
                        Console.WriteLine("Author: ", comment)
                        Console.WriteLine("Created on Date: ", comment.CreatedDate)
                        Console.WriteLine("Initials: ", comment.Initials)
                        Console.WriteLine(vbLf)
                    Next
                Catch exp As Exception
                    Console.WriteLine(exp.Message)
                End Try
            End Sub
            ''' <summary>
            ''' Removes document comments of Doc file  
            ''' </summary> 
            Public Shared Sub RemoveComments()
                Try

                    ' initialize DocFormat
                    Dim docFormat As New DocFormat(Common.MapSourceFilePath(filePath))

                    ' remove comments
                    docFormat.ClearComments()

                    ' save file in destination folder
                    docFormat.Save(Common.MapDestinationFilePath(filePath))



                    Console.WriteLine("File saved in destination folder.")
                Catch exp As Exception
                    Console.WriteLine(exp.Message)
                End Try
            End Sub
#End Region

#Region "working with pages and words"
            ''' <summary>
            ''' Gets word count and page count of Doc file
            ''' </summary> 
            Public Shared Sub GetWordAndPageCount()
                Try

                    ' initialize DocFormat
                    Dim docFormat As New DocFormat(Common.MapSourceFilePath(filePath))

                    ' Get words count...
                    Dim wordsCount As Integer = docFormat.GetWordsCount()

                    ' Get pages count...
                    Dim pageCounts As Integer = docFormat.GetPagesCount()

                    Console.WriteLine("Words: {0}", wordsCount)


                    Console.WriteLine("Pages: {0}", pageCounts)
                Catch exp As Exception
                    Console.WriteLine(exp.Message)
                End Try
            End Sub
#End Region
        End Class

        Public NotInheritable Class Pdf
            Private Sub New()
            End Sub
            ' initialize file path
            Private Const filePath As String = "Documents/Pdf/sample.pdf"

#Region "working with builtin document properties"
            ''' <summary>
            ''' Gets builtin document properties of Pdf file  
            ''' </summary> 
            Public Shared Sub GetDocumentProperties()
                Try
                    'ExStart:GetBuiltinDocumentPropertyPdfFormat
                    ' initialize Pdfformat
                    Dim pdfFormat As New PdfFormat(Common.MapSourceFilePath(filePath))

                    ' initialize PdfMetadata
                    Dim pdfMetadata As PdfMetadata = pdfFormat.DocumentProperties

                    ' built-in properties
                    Console.WriteLine("Built-in Properties")
                    For Each [property] As KeyValuePair(Of String, PropertyValue) In pdfMetadata
                        ' check if built-in property
                        If pdfMetadata.IsBuiltIn([property].Key) Then
                            Console.WriteLine("{0} : {1}", [property].Key, [property].Value)
                        End If
                        'ExEnd:GetBuiltinDocumentPropertyPdfFormat
                    Next
                Catch exp As Exception
                    Console.WriteLine(exp.Message)
                End Try
            End Sub
            ''' <summary>
            ''' Updates document properties of Pdf file and creates output file
            ''' </summary> 
            Public Shared Sub UpdateDocumentProperties()
                Try

                    'ExStart:UpdateBuiltinDocumentPropertyPdfFormat
                    ' initialize PdfFormat
                    Dim pdfFormat As New PdfFormat(Common.MapSourceFilePath(filePath))

                    ' initialize PdfMetadata
                    Dim pdfMetadata As PdfMetadata = pdfFormat.DocumentProperties

                    'update document property...
                    pdfMetadata.Author = "New author"
                    pdfMetadata.Subject = "New subject"
                    pdfMetadata.CreatedDate = DateTime.Now

                    'save output file...
                    pdfFormat.Save(Common.MapDestinationFilePath(filePath))

                    'ExEnd:UpdateBuiltinDocumentPropertyPdfFormat

                    Console.WriteLine("File saved in destination folder.")
                Catch exp As Exception
                    Console.WriteLine(exp.Message)
                End Try

            End Sub
            ''' <summary>
            ''' Removes document properties of Pdf file and creates output file
            ''' </summary> 
            Public Shared Sub RemoveDocumentProperties()
                Try
                    'ExStart:RemoveBuiltinDocumentPropertyPdfFormat
                    ' initialize PdfFormat
                    Dim pdfFormat As New PdfFormat(Common.MapSourceFilePath(filePath))

                    pdfFormat.CleanMetadata()

                    'save output file...
                    pdfFormat.Save(Common.MapDestinationFilePath(filePath))
                    'ExEnd:RemoveBuiltinDocumentPropertyPdfFormat



                    Console.WriteLine("File saved in destination folder.")
                Catch exp As Exception
                    Console.WriteLine(exp.Message)
                End Try
            End Sub
#End Region

#Region "working with custom properties"
            ''' <summary>
            ''' Adds custom property in Pdf file and creates output file
            ''' </summary> 
            Public Shared Sub AddCustomProperty()
                Try
                    'ExStart:AddCustomDocumentPropertyPdfFormat
                    ' initialize PdfFormat
                    Dim pdfFormat As New PdfFormat(Common.MapSourceFilePath(filePath))

                    ' initialize PdfMetadata
                    Dim metadata As PdfMetadata = pdfFormat.DocumentProperties

                    Dim propertyName As String = "New Custom Property"
                    Dim propertyValue As String = "123"


                    ' check if property already exists
                    If Not metadata.ContainsKey(propertyName) Then
                        ' add property
                        metadata.Add(propertyName, propertyValue)
                    End If

                    ' save file in destination folder
                    pdfFormat.Save(Common.MapDestinationFilePath(filePath))
                    'ExEnd:AddCustomDocumentPropertyPdfFormat


                    Console.WriteLine("File saved in destination folder.")
                Catch exp As Exception
                    Console.WriteLine(exp.Message)
                End Try
            End Sub
            ''' <summary>
            ''' Gets custom properties of Pdf file
            ''' </summary>
            Public Shared Sub GetCustomProperties()
                Try
                    'ExStart:GetCustomDocumentPropertiesPdfFormat
                    ' initialize Pdfformat
                    Dim pdfFormat As New PdfFormat(Common.MapSourceFilePath(filePath))

                    ' initialize PdfMetadata
                    Dim pdfMetadata As PdfMetadata = pdfFormat.DocumentProperties

                    Console.WriteLine(vbLf & "Custom Properties")
                    For Each keyValuePair As KeyValuePair(Of String, PropertyValue) In pdfMetadata
                        ' check if property is not built-in
                        If Not pdfMetadata.IsBuiltIn(keyValuePair.Key) Then
                            ' get property value
                            Dim propertyValue As PropertyValue = pdfMetadata(keyValuePair.Key)
                            Console.WriteLine("Key: {0}, Type:{1}, Value: {2}", keyValuePair.Key, propertyValue.Type, propertyValue)
                        End If
                        'ExEnd:GetCustomDocumentPropertiesPdfFormat
                    Next
                Catch exp As Exception
                    Console.WriteLine(exp.Message)
                End Try
            End Sub
            ''' <summary>
            ''' Removes custom property of Pdf file and creates output file
            ''' </summary> 
            Public Shared Sub RemoveCustomProperties()
                Try
                    'ExStart:RemoveCustomDocumentPropertiesPdfFormat
                    ' initialize PdfFormat
                    Dim pdfFormat As New PdfFormat(Common.MapSourceFilePath(filePath))

                    ' initialize PdfMetadata
                    Dim metadata As PdfMetadata = pdfFormat.DocumentProperties

                    Dim propertyName As String = "New Custom Property"

                    ' check if property is not built-in
                    If Not metadata.IsBuiltIn(propertyName) Then
                        ' remove property
                        metadata.Remove(propertyName)
                    Else
                        Console.WriteLine("Can not remove built-in property.")
                    End If

                    ' save file in destination folder
                    pdfFormat.Save(Common.MapDestinationFilePath(filePath))
                    'ExEnd:RemoveCustomDocumentPropertiesPdfFormat

                    Console.WriteLine("File saved in destination folder.")
                Catch exp As Exception
                    Console.WriteLine(exp.Message)
                End Try
            End Sub
#End Region
        End Class

        Public NotInheritable Class Ppt
            Private Sub New()
            End Sub
            ' initialize file path
            Private Const filePath As String = "Documents/Ppt/sample.ppt"

#Region "working with builtin document properties"
            ''' <summary>
            ''' Gets builtin document properties of Ppt file  
            ''' </summary> 
            Public Shared Sub GetDocumentProperties()
                Try
                    ' ExStart:GetBuiltinDocumentPropertiesPptFormat
                    ' initialize PptFormat
                    Dim pptFormat As New PptFormat(Common.MapSourceFilePath(filePath))

                    ' initialize PptMetadata
                    Dim pptMetadata As PptMetadata = pptFormat.DocumentProperties

                    ' built-in properties
                    Console.WriteLine(vbLf & "Built-in Properties")
                    For Each [property] As KeyValuePair(Of String, PropertyValue) In pptMetadata
                        If pptMetadata.IsBuiltIn([property].Key) Then
                            Console.WriteLine("{0} : {1}", [property].Key, [property].Value)
                        End If
                        'ExEnd:GetBuiltinDocumentPropertiesPptFormat
                    Next
                Catch exp As Exception
                    Console.WriteLine(exp.Message)
                End Try
            End Sub
            ''' <summary>
            ''' Updates document properties of Ppt file and creates output file
            ''' </summary> 
            Public Shared Sub UpdateDocumentProperties()
                Try
                    'ExStart:UpdateBuiltinDocumentPropertiesPptFormat
                    ' initialize PptFormat
                    Dim pptFormat As New PptFormat(Common.MapSourceFilePath(filePath))

                    ' initialize PptMetadata
                    Dim pptMetadata As PptMetadata = pptFormat.DocumentProperties

                    ' update document property
                    pptMetadata.Author = "New author"
                    pptMetadata.Subject = "New subject"
                    pptMetadata.Manager = "Usman"

                    'save output file...
                    pptFormat.Save(Common.MapDestinationFilePath(filePath))
                    'ExEnd:UpdateBuiltinDocumentPropertiesPptFormat

                    Console.WriteLine("File saved in destination folder.")
                Catch exp As Exception
                    Console.WriteLine(exp.Message)
                End Try

            End Sub
            ''' <summary>
            ''' Removes document properties of Ppt file and creates output file
            ''' </summary> 
            Public Shared Sub RemoveDocumentProperties()
                Try
                    'ExStart:RemoveBuiltinDocumentPropertiesPptFormat
                    ' initialize PptFormat
                    Dim pptFormat As New PptFormat(Common.MapSourceFilePath(filePath))

                    ' clean metadata
                    pptFormat.CleanMetadata()

                    ' save output file...
                    pptFormat.Save(Common.MapDestinationFilePath(filePath))
                    'ExEnd:RemoveBuiltinDocumentPropertiesPptFormat


                    Console.WriteLine("File saved in destination folder.")
                Catch exp As Exception
                    Console.WriteLine(exp.Message)
                End Try
            End Sub
#End Region

#Region "working with custom properties"
            ''' <summary>
            ''' Adds custom property in Ppt file and creates output file
            ''' </summary> 
            Public Shared Sub AddCustomProperty()
                Try
                    'ExStart:AddCustomDocumentPropertiesPptFormat
                    ' initialize PptFormat
                    Dim pptFormat As New PptFormat(Common.MapSourceFilePath(filePath))

                    ' initialize PptMetadata
                    Dim metadata As PptMetadata = pptFormat.DocumentProperties

                    ' set property details 
                    Dim propertyName As String = "New custom property"
                    Dim propertyValue As String = "Value"

                    ' check if property already exists
                    If Not metadata.ContainsKey(propertyName) Then
                        ' add property
                        metadata.Add(propertyName, propertyValue)
                    End If

                    ' save file in destination folder
                    pptFormat.Save(Common.MapDestinationFilePath(filePath))
                    'ExEnd:AddCustomDocumentPropertiesPptFormat


                    Console.WriteLine("File saved in destination folder.")
                Catch exp As Exception
                    Console.WriteLine(exp.Message)
                End Try
            End Sub
            ''' <summary>
            ''' Gets custom properties of Ppt file  
            ''' </summary> 
            Public Shared Sub GetCustomProperties()
                Try
                    'ExStart:GetCustomDocumentPropertiesPptFormat
                    ' initialize PptFormat
                    Dim pptFormat As New PptFormat(Common.MapSourceFilePath(filePath))

                    ' initialize PptMetadata
                    Dim pptMetadata As PptMetadata = pptFormat.DocumentProperties

                    Console.WriteLine(vbLf & "Custom Properties")
                    For Each keyValuePair As KeyValuePair(Of String, PropertyValue) In pptMetadata
                        ' check if property is not built-in
                        If Not pptMetadata.IsBuiltIn(keyValuePair.Key) Then
                            ' get property value
                            Dim propertyValue As PropertyValue = pptMetadata(keyValuePair.Key)
                            Console.WriteLine("Key: {0}, Type:{1}, Value: {2}", keyValuePair.Key, propertyValue.Type, propertyValue)
                        End If
                        'ExEnd:GetCustomDocumentPropertiesPptFormat
                    Next
                Catch exp As Exception
                    Console.WriteLine(exp.Message)
                End Try
            End Sub
            ''' <summary>
            ''' Removes custom property of Ppt file and creates output file
            ''' </summary> 
            Public Shared Sub RemoveCustomProperties()
                Try
                    'ExStart:RemoveCustomDocumentPropertiesPptFormat
                    ' initialize PptFormat
                    Dim pptFormat As New PptFormat(Common.MapSourceFilePath(filePath))

                    ' initialize PptMetadata
                    Dim metadata As PptMetadata = pptFormat.DocumentProperties

                    Dim propertyName As String = "New custom property"

                    ' check if property is not built-in
                    If Not metadata.IsBuiltIn(propertyName) Then
                        ' remove property
                        metadata.Remove(propertyName)
                    Else
                        Console.WriteLine("Can not remove built-in property.")
                    End If

                    ' save file in destination folder
                    pptFormat.Save(Common.MapDestinationFilePath(filePath))
                    'ExEnd:RemoveCustomDocumentPropertiesPptFormat

                    Console.WriteLine("File saved in destination folder.")
                Catch exp As Exception
                    Console.WriteLine(exp.Message)
                End Try
            End Sub
#End Region
        End Class

        Public NotInheritable Class Xls
            Private Sub New()
            End Sub
            ' initialize file path
            Private Const filePath As String = "Documents/Xls/sample.xls"

#Region "working with builtin document properties"
            ''' <summary>
            ''' Gets builtin document properties of Xls file  
            ''' </summary> 
            Public Shared Sub GetDocumentProperties()
                Try
                    'ExStart:GetBuiltinDocumentPropertiesXlsFormat
                    ' initialize XlsFormat
                    Dim xlsFormat As New XlsFormat(Common.MapSourceFilePath(filePath))

                    ' initialize XlsMetadata
                    Dim xlsMetadata As XlsMetadata = xlsFormat.DocumentProperties

                    ' built-in properties
                    Console.WriteLine(vbLf & "Built-in Properties")
                    For Each [property] As KeyValuePair(Of String, PropertyValue) In xlsMetadata
                        ' check if property is biltin
                        If xlsMetadata.IsBuiltIn([property].Key) Then
                            Console.WriteLine("{0} : {1}", [property].Key, [property].Value)
                        End If
                        'ExEnd:GetBuiltinDocumentPropertiesXlsFormat
                    Next
                Catch exp As Exception
                    Console.WriteLine(exp.Message)
                End Try
            End Sub
            ''' <summary>
            ''' Updates document properties of Xls file and creates output file
            ''' </summary> 
            Public Shared Sub UpdateDocumentProperties()
                Try
                    'ExStart:UpdateBuiltinDocumentPropertiesXlsFormat
                    ' initialize XlsFormat
                    Dim xlsFormat As New XlsFormat(Common.MapSourceFilePath(filePath))

                    ' initialize XlsMetadata
                    Dim xlsMetadata As XlsMetadata = xlsFormat.DocumentProperties

                    'update document property...
                    xlsMetadata.Author = "New author"
                    xlsMetadata.Subject = "New subject"

                    'save output file...
                    xlsFormat.Save(Common.MapDestinationFilePath(filePath))
                    'ExEnd:UpdateBuiltinDocumentPropertiesXlsFormat

                    Console.WriteLine("File saved in destination folder.")
                Catch exp As Exception
                    Console.WriteLine(exp.Message)
                End Try

            End Sub
            ''' <summary>
            ''' Removes document properties of Xls file and creates output file
            ''' </summary> 
            Public Shared Sub RemoveDocumentProperties()
                Try
                    'ExStart:RemoveBuiltinDocumentPropertiesXlsFormat
                    ' initialize XlsFormat
                    Dim xlsFormat As New XlsFormat(Common.MapSourceFilePath(filePath))

                    ' clean metadata
                    xlsFormat.CleanMetadata()

                    'save output file...
                    xlsFormat.Save(Common.MapDestinationFilePath(filePath))
                    'ExEnd:RemoveBuiltinDocumentPropertiesXlsFormat


                    Console.WriteLine("File saved in destination folder.")
                Catch exp As Exception
                    Console.WriteLine(exp.Message)
                End Try
            End Sub
#End Region

#Region "working with custom properties"
            ''' <summary>
            ''' Adds custom property in Xls file and creates output file
            ''' </summary> 
            Public Shared Sub AddCustomProperty()
                Try
                    'ExStart:AddCustomDocumentPropertiesXlsFormat
                    ' initialize XlsFormat
                    Dim xlsFormat As New XlsFormat(Common.MapSourceFilePath(filePath))

                    ' initialize XlsMetadata
                    Dim metadata As XlsMetadata = xlsFormat.DocumentProperties

                    Dim propertyName As String = "New Custom Property"
                    Dim propertyValue As String = "123"

                    ' check if property already exists
                    If Not metadata.ContainsKey(propertyName) Then
                        ' add property
                        metadata.Add(propertyName, propertyValue)
                    End If

                    ' save file in destination folder
                    xlsFormat.Save(Common.MapDestinationFilePath(filePath))
                    'ExEnd:AddCustomDocumentPropertiesXlsFormat


                    Console.WriteLine("File saved in destination folder.")
                Catch exp As Exception
                    Console.WriteLine(exp.Message)
                End Try
            End Sub
            ''' <summary>
            ''' Gets custom properties of Xls file  
            ''' </summary> 
            Public Shared Sub GetCustomProperties()
                Try
                    'ExStart:GetCustomDocumentPropertiesXlsFormat
                    ' initialize XlsFormat
                    Dim xlsFormat As New XlsFormat(Common.MapSourceFilePath(filePath))

                    ' initialize XlsMetadata
                    Dim xlsMetadata As XlsMetadata = xlsFormat.DocumentProperties

                    Console.WriteLine(vbLf & "Custom Properties")
                    For Each keyValuePair As KeyValuePair(Of String, PropertyValue) In xlsMetadata
                        ' check if property is not built-in
                        If Not xlsMetadata.IsBuiltIn(keyValuePair.Key) Then
                            ' get property value
                            Dim propertyValue As PropertyValue = xlsMetadata(keyValuePair.Key)
                            Console.WriteLine("Key: {0}, Type:{1}, Value: {2}", keyValuePair.Key, propertyValue.Type, propertyValue)
                        End If
                        'ExEnd:GetCustomDocumentPropertiesXlsFormat
                    Next
                Catch exp As Exception
                    Console.WriteLine(exp.Message)
                End Try
            End Sub
            ''' <summary>
            ''' Removes custom property of Xls file and creates output file
            ''' </summary> 
            Public Shared Sub RemoveCustomProperties()
                Try
                    'ExStart:RemoveCustomDocumentPropertiesXlsFormat
                    ' initialize XlsFormat
                    Dim xlsFormat As New XlsFormat(Common.MapSourceFilePath(filePath))

                    ' initialize XlsMetadata
                    Dim metadata As XlsMetadata = xlsFormat.DocumentProperties

                    Dim propertyName As String = "New Custom Property"

                    ' check if property is not built-in
                    If Not metadata.IsBuiltIn(propertyName) Then
                        ' remove property
                        metadata.Remove(propertyName)
                    Else
                        Console.WriteLine("Can not remove built-in property.")
                    End If

                    ' save file in destination folder
                    xlsFormat.Save(Common.MapDestinationFilePath(filePath))
                    'ExEnd:RemoveCustomDocumentPropertiesXlsFormat

                    Console.WriteLine("File saved in destination folder.")
                Catch exp As Exception
                    Console.WriteLine(exp.Message)
                End Try
            End Sub
#End Region
        End Class
    End Class
End Namespace

'=======================================================
'Service provided by Telerik (www.telerik.com)
'Conversion powered by NRefactory.
'Twitter: @telerik
'Facebook: facebook.com/telerik
'=======================================================
