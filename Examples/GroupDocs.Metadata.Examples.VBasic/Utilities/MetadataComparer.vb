
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.IO
Imports GroupDocs.Metadata.MetadataProperties
Imports GroupDocs.Metadata.Tools

Namespace Utilities
    'ExStart:MetadataComparer
    Public Class MetadataComparer
        ' absolute path to the GroupDocs.Metadata license file.
        Private Const LicensePath As String = "GroupDocs.Metadata.lic"

        Shared Sub New()
            ' set product license 
            '             * uncomment following function if you have product license
            '             * 

            'SetInternalLicense()
        End Sub

        ''' <summary>
        ''' Applies the product license
        ''' </summary>
        Private Shared Sub SetInternalLicense()
            Dim license As New License()
            license.SetLicense(LicensePath)
        End Sub
        ''' <summary>
        ''' Compares and finds metadata difference of two files 
        ''' </summary>
        ''' <param name="filePath1">First file path</param>
        ''' <param name="filePath2">Second file path</param>
        Public Sub CompareFilesMetadata(filePath1 As String, filePath2 As String)
            Try
                ' path to the document
                filePath1 = Common.MapSourceFilePath(filePath1)

                ' path to the compared document
                filePath2 = Common.MapSourceFilePath(filePath2)

                ' get diffences between metadata
                Dim diffenceProperties As MetadataPropertyCollection = MetadataUtility.CompareDoc(filePath1, filePath2)

                ' go through collection and show differences
                For Each [property] As MetadataProperty In diffenceProperties
                    Console.WriteLine("Property = {0}, value = {1}", [property].Name, [property].Value)
                Next
            Catch exp As Exception
                Console.WriteLine(exp.Message)
            End Try
        End Sub
    End Class
    'ExEnd:MetadataComparer
End Namespace

 
