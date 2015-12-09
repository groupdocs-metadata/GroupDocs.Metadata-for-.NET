
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports GroupDocs.Metadata.Formats.Image
Imports GroupDocs.Metadata.Xmp.Schemas.DublinCore
Imports GroupDocs.Metadata.Xmp
Imports GroupDocs.Metadata.Standards.Exif
Imports GroupDocs.Metadata.Standards.Exif.Jpeg

Namespace GroupDocs.Metadata.Examples.VBasic
    Public NotInheritable Class Images
        Private Sub New()
        End Sub
        Public NotInheritable Class Jpeg
            Private Sub New()
            End Sub
            ' initialize file path
            Private Const filePath As String = "Images/Jpeg/sample.jpg"

#Region "working with XMP data"
            ''' <summary>
            '''Gets XMP properties from Jpeg file
            ''' </summary> 
            Public Shared Sub GetXMPProperties()
                Try

                    ' initialize JpegFormat
                    Dim jpegFormat As New JpegFormat(Common.MapSourceFilePath(filePath))

                    ' get XMP data
                    Dim xmpProperties As XmpProperties = jpegFormat.GetXmpProperties()

                    ' show XMP data
                    For Each key As String In xmpProperties.Keys
                        Dim xmpNodeView As XmpNodeView = xmpProperties(key)
                        Console.WriteLine("[{0}] = {1}", xmpNodeView.Name, xmpNodeView.Value)
                    Next
                Catch exp As Exception
                    Console.WriteLine(exp.Message)
                End Try
            End Sub
            ''' <summary>
            ''' Updates XMP data of Jpeg file and creates output file
            ''' </summary> 
            Public Shared Sub UpdateXMPProperties()
                Try

                    ' initialize JpegFormat
                    Dim jpegFormat As New JpegFormat(Common.MapSourceFilePath(filePath))

                    ' get xmp wrapper
                    Dim xmpPacket As XmpPacketWrapper = jpegFormat.GetXmpData()

                    ' create xmp wrapper is not exist
                    If xmpPacket Is Nothing Then
                        xmpPacket = New XmpPacketWrapper()
                    End If

                    ' check if DublinCore schema is exist
                    If Not xmpPacket.ContainsPackage(Namespaces.DublinCore) Then
                        ' if no - add DublinCore schema
                        xmpPacket.AddPackage(New DublinCorePackage())
                    End If

                    ' get DublinCore package
                    Dim dublinCorePackage As DublinCorePackage = DirectCast(xmpPacket.GetPackage(Namespaces.DublinCore), DublinCorePackage)

                    ' get details from user
                    Console.WriteLine("Enter author's name:")
                    Dim authorName As String = Console.ReadLine()

                    Console.WriteLine("Enter description name:")
                    Dim description As String = Console.ReadLine()

                    Console.WriteLine("Enter subject:")
                    Dim subject As String = Console.ReadLine()

                    Console.WriteLine("Enter publisher:")
                    Dim publisher As String = Console.ReadLine()

                    Console.WriteLine("Enter title:")
                    Dim title As String = Console.ReadLine()

                    ' set author
                    dublinCorePackage.SetAuthor(authorName)
                    ' set description
                    dublinCorePackage.SetDescription(description)
                    ' set subject
                    dublinCorePackage.SetSubject(subject)
                    ' set publisher
                    dublinCorePackage.SetPublisher(publisher)
                    ' set title
                    dublinCorePackage.SetTitle(title)
                    ' update XMP package
                    jpegFormat.SetXmpData(xmpPacket)

                    ' commit changes
                    jpegFormat.Save(Common.MapDestinationFilePath(filePath))
                    Console.WriteLine("File saved in destination folder.")
                Catch exp As Exception
                    Console.WriteLine(exp.Message)
                End Try
            End Sub
            ''' <summary>
            ''' Removes XMP data of Jpeg file and creates output file
            ''' </summary> 
            Public Shared Sub RemoveXMPData()
                Try

                    ' initialize JpegFormat
                    Dim jpegFormat As New JpegFormat(Common.MapSourceFilePath(filePath))

                    ' remove XMP package
                    jpegFormat.RemoveXmpData()

                    ' commit changes
                    jpegFormat.Save(Common.MapDestinationFilePath(filePath))

                    Console.WriteLine("File saved in destination folder.")
                Catch exp As Exception
                    Console.WriteLine(exp.Message)
                End Try
            End Sub
#End Region

#Region "working with Exif properties"
            ''' <summary>
            ''' Gets Exif info from Jpeg file
            ''' </summary> 
            Public Shared Sub GetExifInfo()
                Try

                    ' initialize JpegFormat
                    Dim jpegFormat As New JpegFormat(Common.MapSourceFilePath(filePath))

                    ' get EXIF data
                    Dim exif As JpegExifInfo = DirectCast(jpegFormat.GetExifInfo(), JpegExifInfo)

                    If exif IsNot Nothing Then
                        ' get artist 
                        Console.WriteLine("Artist: {0}", exif.Artist)
                        ' get description 
                        Console.WriteLine("Description: {0}", exif.ImageDescription)
                        ' get user's comment 
                        Console.WriteLine("User Comment: {0}", exif.UserComment)
                        ' get user's Model 
                        Console.WriteLine("Model: {0}", exif.Model)
                        ' get user's Make 
                        Console.WriteLine("Make: {0}", exif.Make)
                        ' get user's CameraOwnerName 
                        Console.WriteLine("CameraOwnerName: {0}", exif.CameraOwnerName)
                    End If
                Catch exp As Exception
                    Console.WriteLine(exp.Message)
                End Try
            End Sub
            ''' <summary>
            ''' Updates Exif info of Jpeg file and creates output file
            ''' </summary> 
            Public Shared Sub UpdateExifInfo()
                Try

                    ' initialize JpegFormat
                    Dim jpegFormat As New JpegFormat(Common.MapSourceFilePath(filePath))

                    ' get EXIF data
                    Dim exif As JpegExifInfo = DirectCast(jpegFormat.GetExifInfo(), JpegExifInfo)
                    If exif Is Nothing Then
                        ' initialize EXIF data if null
                        exif = New JpegExifInfo()
                    End If

                    ' set artist
                    exif.Artist = "Usman"
                    ' set make
                    exif.Make = "Sony"
                    ' set model
                    exif.Model = "S120"
                    ' set the name of the camera's owner
                    exif.CameraOwnerName = "Owner"
                    ' set description
                    exif.ImageDescription = "sample description"

                    ' update EXIF data
                    jpegFormat.SetExifInfo(exif)

                    ' commit changes
                    jpegFormat.Save(Common.MapDestinationFilePath(filePath))

                    Console.WriteLine("File saved in destination folder.")
                Catch exp As Exception
                    Console.WriteLine(exp.Message)
                End Try
            End Sub
            ''' <summary>
            ''' Removes Exif info of Jpeg file and creates output file
            ''' </summary> 
            Public Shared Sub RemoveExifInfo()
                Try

                    ' initialize JpegFormat
                    Dim jpegFormat As New JpegFormat(Common.MapSourceFilePath(filePath))

                    ' remove Exif info
                    jpegFormat.RemoveExifInfo()

                    ' commit changes
                    jpegFormat.Save(Common.MapDestinationFilePath(filePath))
                Catch exp As Exception
                    Console.WriteLine(exp.Message)
                End Try
            End Sub
#End Region

        End Class
        Public NotInheritable Class Gif
            Private Sub New()
            End Sub
            ' initialize file path
            Private Const filePath As String = "Images/Gif/sample.gif"

            ''' <summary>
            '''Gets XMP properties of Gif file
            ''' </summary> 
            Public Shared Sub GetXMPProperties()
                Try

                    ' initialize GifFormat
                    Dim gifFormat As New GifFormat(Common.MapSourceFilePath(filePath))

                    ' get XMP data
                    Dim xmpProperties As XmpProperties = gifFormat.GetXmpProperties()

                    ' show XMP data
                    For Each key As String In xmpProperties.Keys
                        Dim xmpNodeView As XmpNodeView = xmpProperties(key)
                        Console.WriteLine("[{0}] = {1}", xmpNodeView.Name, xmpNodeView.Value)
                    Next
                Catch exp As Exception
                    Console.WriteLine(exp.Message)
                End Try
            End Sub
            ''' <summary>
            ''' Updates XMP data of Gif file and creates output file
            ''' </summary> 
            Public Shared Sub UpdateXMPProperties()
                Try

                    ' initialize GifFormat
                    Dim gifFormat As New GifFormat(Common.MapSourceFilePath(filePath))

                    ' get xmp wrapper
                    Dim xmpPacket As XmpPacketWrapper = gifFormat.GetXmpData()

                    ' create xmp wrapper is not exist
                    If xmpPacket Is Nothing Then
                        xmpPacket = New XmpPacketWrapper()
                    End If

                    ' check if DublinCore schema is exist
                    If Not xmpPacket.ContainsPackage(Namespaces.DublinCore) Then
                        ' if no - add DublinCore schema
                        xmpPacket.AddPackage(New DublinCorePackage())
                    End If

                    ' get DublinCore package
                    Dim dublinCorePackage As DublinCorePackage = DirectCast(xmpPacket.GetPackage(Namespaces.DublinCore), DublinCorePackage)

                    ' get details from user
                    Console.WriteLine("Enter author's name:")
                    Dim authorName As String = Console.ReadLine()

                    Console.WriteLine("Enter description:")
                    Dim description As String = Console.ReadLine()

                    Console.WriteLine("Enter subject:")
                    Dim subject As String = Console.ReadLine()

                    Console.WriteLine("Enter publisher:")
                    Dim publisher As String = Console.ReadLine()

                    Console.WriteLine("Enter title:")
                    Dim title As String = Console.ReadLine()

                    ' set author
                    dublinCorePackage.SetAuthor(authorName)
                    ' set description
                    dublinCorePackage.SetDescription(description)
                    ' set subject
                    dublinCorePackage.SetSubject(subject)
                    ' set publisher
                    dublinCorePackage.SetPublisher(publisher)
                    ' set title
                    dublinCorePackage.SetTitle(title)
                    ' update XMP package
                    gifFormat.SetXmpData(xmpPacket)

                    ' commit changes
                    gifFormat.Save(Common.MapDestinationFilePath(filePath))

                    Console.WriteLine("File saved in destination folder.")
                Catch exp As Exception
                    Console.WriteLine(exp.Message)
                End Try
            End Sub
            ''' <summary>
            ''' Removes XMP data of Gif file and creates output file
            ''' </summary> 
            Public Shared Sub RemoveXMPProperties()
                Try

                    ' initialize GifFormat
                    Dim gifFormat As New GifFormat(Common.MapSourceFilePath(filePath))

                    ' remove XMP package
                    gifFormat.RemoveXmpData()

                    ' commit changes
                    gifFormat.Save(Common.MapDestinationFilePath(filePath))

                    Console.WriteLine("File saved in destination folder.")
                Catch exp As Exception
                    Console.WriteLine(exp.Message)
                End Try
            End Sub

        End Class


        Public NotInheritable Class Png
            Private Sub New()
            End Sub
            ' initialize file path
            Private Const filePath As String = "Images/Png/sample.png"

            ''' <summary>
            '''Gets XMP properties from Png file
            ''' </summary> 
            Public Shared Sub GetXMPProperties()
                Try

                    ' initialize PngFormat
                    Dim pngFormat As New PngFormat(Common.MapSourceFilePath(filePath))

                    ' get XMP data
                    Dim xmpProperties As XmpProperties = pngFormat.GetXmpProperties()

                    If xmpProperties IsNot Nothing Then
                        ' show XMP data
                        For Each key As String In xmpProperties.Keys
                            Dim xmpNodeView As XmpNodeView = xmpProperties(key)
                            Console.WriteLine("[{0}] = {1}", xmpNodeView.Name, xmpNodeView.Value)
                        Next
                    Else
                        Console.WriteLine("No XMP property found.")
                    End If
                Catch exp As Exception
                    Console.WriteLine(exp.Message)
                End Try
            End Sub
            ''' <summary>
            ''' Updates XMP data of Png file and creates output file
            ''' </summary> 
            Public Shared Sub UpdateXMPData()
                Try

                    ' initialize PngFormat
                    Dim pngFormat As New PngFormat(Common.MapSourceFilePath(filePath))

                    ' get xmp wrapper
                    Dim xmpPacket As XmpPacketWrapper = pngFormat.GetXmpData()

                    ' create xmp wrapper is not exist
                    If xmpPacket Is Nothing Then
                        xmpPacket = New XmpPacketWrapper()
                    End If

                    ' check if DublinCore schema is exist
                    If Not xmpPacket.ContainsPackage(Namespaces.DublinCore) Then
                        ' if no - add DublinCore schema
                        xmpPacket.AddPackage(New DublinCorePackage())
                    End If

                    ' get DublinCore package
                    Dim dublinCorePackage As DublinCorePackage = DirectCast(xmpPacket.GetPackage(Namespaces.DublinCore), DublinCorePackage)

                    ' get details from user
                    Console.WriteLine("Enter author's name:")
                    Dim authorName As String = Console.ReadLine()

                    Console.WriteLine("Enter description name:")
                    Dim description As String = Console.ReadLine()

                    Console.WriteLine("Enter subject:")
                    Dim subject As String = Console.ReadLine()

                    Console.WriteLine("Enter publisher:")
                    Dim publisher As String = Console.ReadLine()

                    Console.WriteLine("Enter title:")
                    Dim title As String = Console.ReadLine()

                    ' set author
                    dublinCorePackage.SetAuthor(authorName)
                    ' set description
                    dublinCorePackage.SetDescription(description)
                    ' set subject
                    dublinCorePackage.SetSubject(subject)
                    ' set publisher
                    dublinCorePackage.SetPublisher(publisher)
                    ' set title
                    dublinCorePackage.SetTitle(title)
                    ' update XMP package
                    pngFormat.SetXmpData(xmpPacket)

                    ' commit changes
                    pngFormat.Save(Common.MapDestinationFilePath(filePath))

                    Console.WriteLine("File saved in destination folder.")
                Catch exp As Exception
                    Console.WriteLine(exp.Message)
                End Try
            End Sub
            ''' <summary>
            ''' Removes XMP data of Png file and creates output file
            ''' </summary> 
            Public Shared Sub RemoveXMPData()
                Try

                    ' initialize PngFormat
                    Dim pngFormat As New PngFormat(Common.MapSourceFilePath(filePath))

                    ' remove XMP package
                    pngFormat.RemoveXmpData()

                    ' commit changes
                    pngFormat.Save(Common.MapDestinationFilePath(filePath))

                    Console.WriteLine("File saved in destination folder.")
                Catch exp As Exception
                    Console.WriteLine(exp.Message)
                End Try
            End Sub

        End Class
    End Class
End Namespace

'=======================================================
'Service provided by Telerik (www.telerik.com)
'Conversion powered by NRefactory.
'Twitter: @telerik
'Facebook: facebook.com/telerik
'=======================================================

