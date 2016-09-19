Imports GroupDocs.Metadata.Examples.VBasic.Utilities 
Imports GroupDocs.Metadata
Imports GroupDocs.Metadata.Formats.Image
Imports GroupDocs.Metadata.Tools
Imports System.Collections.Generic
Imports System.Data
Imports System.IO
Imports System.Linq
Imports System.Text

Namespace GroupDocs.Metadata.Examples.VBasic
    Public NotInheritable Class APIs
        Private Sub New()
        End Sub
        Public NotInheritable Class Document
            Private Sub New()
            End Sub
            ''' <summary>
            ''' Compares metadata of two documents and displays result 
            ''' </summary> 
            Public Shared Sub CompareDocument(firstDocument As String, secondDocument As String, type As ComparerSearchType)
                Try
                    'ExStart:ComparisonAPI
                    firstDocument = Common.MapSourceFilePath(firstDocument)
                    secondDocument = Common.MapSourceFilePath(secondDocument)

                    Dim differences As MetadataPropertyCollection = ComparisonFacade.CompareDocuments(firstDocument, secondDocument, type)

                    For Each [property] As MetadataProperty In differences
                        Console.WriteLine("{0} : {1}", [property].Name, [property].Value)
                        'ExEnd:ComparisonAPI
                    Next
                Catch exp As Exception
                    Console.WriteLine("Exception occurred: " + exp.Message)
                End Try

            End Sub
            ''' <summary>
            ''' Searches metadata in document 
            ''' </summary> 
            Public Shared Sub SearchMetadata(filePath As String, propertyName As String, searchCondition As SearchCondition)
                Try
                    'ExStart:DocumentSearchAPI
                    filePath = Common.MapSourceFilePath(filePath)

                    Dim properties As MetadataPropertyCollection = SearchFacade.ScanDocument(filePath, propertyName, searchCondition)

                    For Each [property] As MetadataProperty In properties
                        Console.WriteLine("{0} : {1}", [property].Name, [property].Value)
                        'ExEnd:DocumentSearchAPI
                    Next
                Catch exp As Exception
                    Console.WriteLine("Exception occurred: " + exp.Message)
                End Try

            End Sub

            ''' <summary>
            ''' Replaces author name in document using custom ReplaceHandler
            ''' </summary> 
            Public Shared Sub ReplaceAuthorName(filePath As String)
                Try
                    'ExStart:ReplaceAuthorName
                    ' initialize custom handler, send output path using constructor
                    Dim replaceHandler As IReplaceHandler(Of MetadataProperty) = New AuthorReplaceHandler(Common.MapDestinationFilePath(filePath))

                    ' replace author
                    'ExEnd:ReplaceAuthorName
                    Dim affectedPropertiesCount As Integer = SearchFacade.ReplaceInDocument(Common.MapSourceFilePath(filePath), replaceHandler)
                Catch exp As Exception
                    Console.WriteLine("Exception occurred: " + exp.Message)
                End Try

            End Sub
            ''' <summary>
            ''' Replaces author name in document using custom ReplaceHandler
            ''' </summary> 
            Public Shared Sub ReplaceMetadataProperties(filePath As String)
                Try
                    'ExStart:ReplaceMetadataProperties
                    ' replace 'author' value
                    SearchFacade.ReplaceInDocument(Common.MapSourceFilePath(filePath), "Author", "Jack London", SearchCondition.Matches, Common.MapDestinationFilePath(filePath))

                    ' replace all properties contained 'co' to 'some value'
                    SearchFacade.ReplaceInDocument(Common.MapSourceFilePath(filePath), "co", "some value", SearchCondition.Contains, Common.MapDestinationFilePath(filePath))
                    'ExEnd:ReplaceMetadataProperties
                Catch exp As Exception
                    Console.WriteLine("Exception occurred: " + exp.Message)
                End Try

            End Sub
        End Class
        Public NotInheritable Class Image
            Private Sub New()
            End Sub
            ''' <summary>
            ''' Searches metadata in image 
            ''' </summary> 
            Public Shared Sub SearchMetadata(filePath As String, propertyName As String, searchCondition As SearchCondition)
                Try
                    'ExStart:ImageSearchAPI
                    filePath = Common.MapSourceFilePath(filePath)

                    ' looking the software
                    Dim properties As ExifProperty() = SearchFacade.ScanExif(filePath, propertyName, searchCondition)

                    For Each [property] As ExifProperty In properties
                        Console.WriteLine("{0} : {1}", [property].Name, [property].ToString())
                    Next
                    'ExEnd:ImageSearchAPI
                Catch exp As Exception
                    Console.WriteLine("Exception occurred: " + exp.Message)
                End Try

            End Sub

            ''' <summary>
            ''' Compares EXIF metadata of two jpeg files 
            ''' </summary> 
            Public Shared Sub CompareExifMetadata(firstFile As String, secondFile As String, type As ComparerSearchType)
                Try
                    'ExStart:ExifComparisonAPI
                    firstFile = Common.MapSourceFilePath(firstFile)
                    secondFile = Common.MapSourceFilePath(secondFile)

                    Dim differences As ExifProperty() = ComparisonFacade.CompareExif(firstFile, secondFile, type)

                    For Each [property] As ExifProperty In differences
                        Console.WriteLine("{0} : {1}", [property].Name, [property].ToString())
                    Next
                    'ExEnd:ExifComparisonAPI
                Catch exp As Exception
                    Console.WriteLine("Exception occurred: " + exp.Message)
                End Try

            End Sub
        End Class

        ''' <summary>
        ''' Exports metadata of specified file into specified type 
        ''' </summary> 
        Public Shared Sub ExportMetadata(filePath As String, exportType As Integer)
            Try
                'ExStart:ExportMetadataAPI
                filePath = Common.MapSourceFilePath(filePath)

                If exportType = ExportTypes.ToExcel Then
                    'ExStart:ExportMetadataToExcel
                    ' path to the output file
                    Dim outputPath As String = Common.MapDestinationFilePath("metadata.xlsx")

                    ' export to excel
                    Dim content As Byte() = ExportFacade.ExportToExcel(filePath)

                    ' write data to the file
                    File.WriteAllBytes(outputPath, content)
                    'ExEnd:ExportMetadataToExcel
                ElseIf exportType = ExportTypes.ToCSV Then
                    'ExStart:ExportMetadataToCSV
                    ' path to the output file
                    Dim outputPath As String = Common.MapDestinationFilePath("metadata.csv")

                    ' export to csv
                    Dim content As Byte() = ExportFacade.ExportToCsv(filePath)

                    ' write data to the file
                    File.WriteAllBytes(outputPath, content)
                    'ExEnd:ExportMetadataToCSV
                Else
                    'ExStart:ExportMetadataToDataSet
                    ' export to DataSet
                    Dim ds As DataSet = ExportFacade.ExportToDataSet(filePath)
                    ' get first table
                    Dim products As DataTable = ds.Tables(0)

                    ' need to System.Data.DataSetExtension reference            
                    Dim query As IEnumerable(Of DataRow) = From product In products.AsEnumerable()

                    Console.WriteLine("Properties:")
                    For Each p As DataRow In query
                        Console.Write(p.Field(Of String)("Metadata property"))
                        Console.Write(": ")
                        Console.WriteLine(p.Field(Of String)("Value"))
                    Next
                    'ExEnd:ExportMetadataToDataSet
                    'ExEnd:ExportMetadataAPI
                End If
            Catch exp As Exception
                Console.WriteLine("Exception occurred: " + exp.Message)
            End Try

        End Sub
    End Class
End Namespace
