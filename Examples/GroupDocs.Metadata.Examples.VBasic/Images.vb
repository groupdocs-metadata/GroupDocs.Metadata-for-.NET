
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
            'ExStart:SourceJpegFilePath
            Private Const filePath As String = "Images/Jpeg/sample.jpg"
            'ExEnd:SourceJpegFilePath
#Region "working with XMP data"
            ''' <summary>
            '''Gets XMP properties from Jpeg file
            ''' </summary> 
            Public Shared Sub GetXMPProperties()
                Try
                    'ExStart:GetXmpPropertiesJpegImage
                    ' initialize JpegFormat
                    Dim jpegFormat As New JpegFormat(Common.MapSourceFilePath(filePath))

                    ' get XMP data
                    Dim xmpProperties As XmpProperties = jpegFormat.GetXmpProperties()

                    ' show XMP data
                    For Each key As String In xmpProperties.Keys
                        Dim xmpNodeView As XmpNodeView = xmpProperties(key)
                        Console.WriteLine("[{0}] = {1}", xmpNodeView.Name, xmpNodeView.Value)
                        'ExEnd:GetXmpPropertiesJpegImage
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
                    'ExStart:UpdateXmpPropertiesJpegImage
                    ' initialize JpegFormat
                    Dim jpegFormat As New JpegFormat(Common.MapSourceFilePath(filePath))

                    ' get xmp wrapper
                    Dim xmpPacket As XmpPacketWrapper = jpegFormat.GetXmpData()

                    ' create xmp wrapper if not exists
                    If xmpPacket Is Nothing Then
                        xmpPacket = New XmpPacketWrapper()
                    End If

                    ' check if DublinCore schema exists
                    If Not xmpPacket.ContainsPackage(Namespaces.DublinCore) Then
                        ' if not - add DublinCore schema
                        xmpPacket.AddPackage(New DublinCorePackage())
                    End If

                    ' get DublinCore package
                    Dim dublinCorePackage As DublinCorePackage = DirectCast(xmpPacket.GetPackage(Namespaces.DublinCore), DublinCorePackage)

                    Dim authorName As String = "New author"
                    Dim description As String = "New description"
                    Dim subject As String = "New subject"
                    Dim publisher As String = "New publisher"
                    Dim title As String = "New title"

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
                    'ExEnd:UpdateXmpPropertiesJpegImage
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
                    'ExStart:RemoveXmpPropertiesJpegImage
                    ' initialize JpegFormat
                    Dim jpegFormat As New JpegFormat(Common.MapSourceFilePath(filePath))

                    ' remove XMP package
                    jpegFormat.RemoveXmpData()

                    ' commit changes
                    jpegFormat.Save(Common.MapDestinationFilePath(filePath))
                    'ExEnd:RemoveXmpPropertiesJpegImage
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
                    'ExStart:GetExifPropertiesJpegImage
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
                        'ExEnd:GetExifPropertiesJpegImage
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
                    'ExStart:UpdateExifPropertiesJpegImage
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
                    exif.Make = "ABC"
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
                    'ExEnd:UpdateExifPropertiesJpegImage
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
                    'ExStart:RemoveExifPropertiesJpegImage
                    ' initialize JpegFormat
                    Dim jpegFormat As New JpegFormat(Common.MapSourceFilePath(filePath))

                    ' remove Exif info
                    jpegFormat.RemoveExifInfo()

                    ' commit changes
                    jpegFormat.Save(Common.MapDestinationFilePath(filePath))
                    'ExEnd:RemoveExifPropertiesJpegImage
                    Console.WriteLine("File saved in destination folder.")
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
            'ExStart:SourceGifFilePath
            Private Const filePath As String = "Images/Gif/sample.gif"
            'ExEnd:SourceGifFilePath
            ''' <summary>
            '''Gets XMP properties of Gif file
            ''' </summary> 
            Public Shared Sub GetXMPProperties()
                Try
                    'ExStart:GetXMPPropertiesGifImage
                    ' initialize GifFormat
                    Dim gifFormat As New GifFormat(Common.MapSourceFilePath(filePath))

                    ' get XMP data
                    Dim xmpProperties As XmpProperties = gifFormat.GetXmpProperties()

                    ' show XMP data
                    For Each key As String In xmpProperties.Keys
                        Dim xmpNodeView As XmpNodeView = xmpProperties(key)
                        Console.WriteLine("[{0}] = {1}", xmpNodeView.Name, xmpNodeView.Value)
                        'ExEnd:GetXMPPropertiesGifImage
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
                    'ExStart:UpdateXMPPropertiesGifImage
                    ' initialize GifFormat
                    Dim gifFormat As New GifFormat(Common.MapSourceFilePath(filePath))

                    ' get xmp wrapper
                    Dim xmpPacket As XmpPacketWrapper = gifFormat.GetXmpData()

                    ' create xmp wrapper if not exists
                    If xmpPacket Is Nothing Then
                        xmpPacket = New XmpPacketWrapper()
                    End If

                    ' check if DublinCore schema exists
                    If Not xmpPacket.ContainsPackage(Namespaces.DublinCore) Then
                        ' if not - add DublinCore schema
                        xmpPacket.AddPackage(New DublinCorePackage())
                    End If

                    ' get DublinCore package
                    Dim dublinCorePackage As DublinCorePackage = DirectCast(xmpPacket.GetPackage(Namespaces.DublinCore), DublinCorePackage)

                    Dim authorName As String = "New author"
                    Dim description As String = "New description"
                    Dim subject As String = "New subject"
                    Dim publisher As String = "New publisher"
                    Dim title As String = "New title"

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
                    'ExEnd:UpdateXMPPropertiesGifImage
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
                    'ExStart:RemoveXMPPropertiesGifImage 
                    ' initialize GifFormat
                    Dim gifFormat As New GifFormat(Common.MapSourceFilePath(filePath))

                    ' remove XMP package
                    gifFormat.RemoveXmpData()

                    ' commit changes
                    gifFormat.Save(Common.MapDestinationFilePath(filePath))
                    'ExEnd:RemoveXMPPropertiesGifImage 
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
            'ExStart:SourcePngFilePath
            Private Const filePath As String = "Images/Png/sample.png"
            'ExEnd:SourcePngFilePath
            ''' <summary>
            '''Gets XMP properties from Png file
            ''' </summary> 
            Public Shared Sub GetXMPProperties()
                Try
                    'ExStart:GetXMPPropertiesPngImage 
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
                        Console.WriteLine("No XMP data found.")
                        'ExEnd:GetXMPPropertiesPngImage 
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
                    'ExStart:UpdateXMPPropertiesPngImage 
                    ' initialize PngFormat
                    Dim pngFormat As New PngFormat(Common.MapSourceFilePath(filePath))

                    ' get xmp wrapper
                    Dim xmpPacket As XmpPacketWrapper = pngFormat.GetXmpData()

                    ' create xmp wrapper if not exists
                    If xmpPacket Is Nothing Then
                        xmpPacket = New XmpPacketWrapper()
                    End If

                    ' check if DublinCore schema exists
                    If Not xmpPacket.ContainsPackage(Namespaces.DublinCore) Then
                        ' if not - add DublinCore schema
                        xmpPacket.AddPackage(New DublinCorePackage())
                    End If

                    ' get DublinCore package
                    Dim dublinCorePackage As DublinCorePackage = DirectCast(xmpPacket.GetPackage(Namespaces.DublinCore), DublinCorePackage)

                    Dim authorName As String = "New author"
                    Dim description As String = "New description"
                    Dim subject As String = "New subject"
                    Dim publisher As String = "New publisher"
                    Dim title As String = "New title"

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
                    'ExEnd:UpdateXMPPropertiesPngImage 
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
                    'ExStart:RemoveXMPPropertiesPngImage 
                    ' initialize PngFormat
                    Dim pngFormat As New PngFormat(Common.MapSourceFilePath(filePath))

                    ' remove XMP package
                    pngFormat.RemoveXmpData()

                    ' commit changes
                    pngFormat.Save(Common.MapDestinationFilePath(filePath))
                    'ExEnd:RemoveXMPPropertiesPngImage 
                    Console.WriteLine("File saved in destination folder.")
                Catch exp As Exception
                    Console.WriteLine(exp.Message)
                End Try
            End Sub

        End Class
    End Class
End Namespace

