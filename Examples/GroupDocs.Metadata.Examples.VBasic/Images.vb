
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports GroupDocs.Metadata.Formats.Image
Imports GroupDocs.Metadata.Xmp.Schemas.DublinCore
Imports GroupDocs.Metadata.Xmp
Imports GroupDocs.Metadata.Standards.Exif
Imports GroupDocs.Metadata.Standards.Exif.Jpeg
Imports GroupDocs.Metadata.Examples.VBasic.Utilities
Imports GroupDocs.Metadata.Formats.AdobeApplication
Imports GroupDocs.Metadata.Standards.Psd
Imports GroupDocs.Metadata.Xmp.Types.Complex.Font
Imports GroupDocs.Metadata.Xmp.Types.Complex.Dimensions
Imports GroupDocs.Metadata.Xmp.Schemas.CameraRaw
Imports GroupDocs.Metadata.Xmp.Types.Complex.Colorant
Imports GroupDocs.Metadata.Tools.Search
Imports GroupDocs.Metadata.Xmp.Schemas.BasicJob
Imports GroupDocs.Metadata.Xmp.Types.Complex.BasicJob
Imports System.Drawing
Imports System.IO
Imports GroupDocs.Metadata.Xmp.Types.Complex.Thumbnail

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
                        Try
                            Dim xmpNodeView As XmpNodeView = xmpProperties(key)
                            Console.WriteLine("[{0}] = {1}", xmpNodeView.Name, xmpNodeView.Value)
                        Catch
                        End Try
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
            ''' Updates XMP values of Jpeg file and creates output file
            ''' </summary> 
            Public Shared Sub UpdateXMPValues()
                Try
                    'ExStart:UpdateXmpValuesJpegImage
                    ' initialize JpegFormat
                    Dim jpegFormat As New JpegFormat(Common.MapSourceFilePath(filePath))

                    Const dcFormat As String = "test format"
                    Dim dcContributors As String() = {"test contributor"}
                    Const dcCoverage As String = "test coverage"
                    Const phCity As String = "NY"
                    Const phCountry As String = "USA"
                    Const xmpCreator As String = "GroupDocs.Metadata"

                    jpegFormat.XmpValues.Schemes.DublinCore.Format = dcFormat
                    jpegFormat.XmpValues.Schemes.DublinCore.Contributors = dcContributors
                    jpegFormat.XmpValues.Schemes.DublinCore.Coverage = dcCoverage
                    jpegFormat.XmpValues.Schemes.Photoshop.City = phCity
                    jpegFormat.XmpValues.Schemes.Photoshop.Country = phCountry
                    jpegFormat.XmpValues.Schemes.XmpBasic.CreatorTool = xmpCreator

                    ' commit changes
                    jpegFormat.Save(Common.MapDestinationFilePath(filePath))
                    'ExEnd:UpdateXmpValuesJpegImage
                    Console.WriteLine("File saved in destination folder.")
                Catch exp As Exception
                    Console.WriteLine(exp.Message)
                End Try
            End Sub
            ''' <summary>
            ''' Updates PagedText XMP data of Jpeg file and creates output file
            ''' </summary> 
            Public Shared Sub UpdatePagedTextXMPProperties()
                Try
                    'ExStart:UpdatePagedTextXmpPropertiesJpegImage
                    ' initialize JpegFormat
                    Dim jpegFormat As New JpegFormat(Common.MapSourceFilePath(filePath))

                    ' get access to PagedText schema
                    Dim package = jpegFormat.XmpValues.Schemes.PagedText


                    ' update MaxPageSize
                    package.MaxPageSize = New Dimensions(600, 800)

                    ' update number of pages
                    package.NumberOfPages = 10

                    ' update plate names
                    package.PlateNames = New String() {"1", "2", "3"}

                    ' commit changes
                    jpegFormat.Save(Common.MapDestinationFilePath(filePath))
                    'ExEnd:UpdatePagedTextXmpPropertiesJpegImage
                    Console.WriteLine("File saved in destination folder.")
                Catch exp As Exception
                    Console.WriteLine(exp.Message)
                End Try
            End Sub
            ''' <summary>
            ''' Updates CameraRaw XMP data of Jpeg file and creates output file
            ''' </summary> 
            Public Shared Sub UpdateCameraRawXMPProperties()
                Try
                    'ExStart:UpdateCameraRawXmpPropertiesJpegImage
                    ' initialize JpegFormat
                    Dim JpegFormat As New JpegFormat(Common.MapSourceFilePath(filePath))

                    ' get access to CameraRaw schema
                    Dim package = JpegFormat.XmpValues.Schemes.CameraRaw

                    ' update properties
                    package.AutoBrightness = True
                    package.AutoContrast = True
                    package.CropUnits = CropUnits.Pixels

                    ' update white balance
                    package.SetWhiteBalance(WhiteBalance.Auto)

                    ' commit changes
                    JpegFormat.Save(Common.MapDestinationFilePath(filePath))
                    'ExEnd:UpdateCameraRawXmpPropertiesJpegImage
                    Console.WriteLine("File saved in destination folder.")
                Catch exp As Exception
                    Console.WriteLine(exp.Message)
                End Try
            End Sub
            ''' <summary>
            ''' Updates Basic Job XMP data of Jpeg file and creates output file
            ''' </summary> 
            Public Shared Sub UpdateBasicJobXMPProperties()
                Try
                    'ExStart:UpdateBasicJobTicketXmpPropertiesJpegImage
                    ' initialize JpegFormat
                    Dim jpegFormat As New JpegFormat(Common.MapSourceFilePath(filePath))

                    ' get xmp data
                    Dim xmp = jpegFormat.GetXmpData()

                    Dim package As BasicJobTicketPackage = Nothing

                    ' looking for the BasicJob schema if xmp data is presented
                    If xmp IsNot Nothing Then
                        package = TryCast(xmp.GetPackage(Namespaces.BasicJob), BasicJobTicketPackage)
                    Else
                        xmp = New XmpPacketWrapper()
                    End If

                    If package Is Nothing Then
                        ' create package if not exist
                        package = New BasicJobTicketPackage()

                        ' and add it to xmp data
                        xmp.AddPackage(package)
                    End If

                    ' create array of jobs
                    Dim jobs As Job() = New Job(0) {}
                    jobs(0) = New Job() With { _
                         .Id = "1", _
                         .Name = "test job" _
                    }

                    ' update schema
                    package.SetJobs(jobs)

                    ' update xmp data
                    jpegFormat.SetXmpData(xmp)

                    ' commit changes
                    jpegFormat.Save(Common.MapDestinationFilePath(filePath))
                    'ExEnd:UpdateBasicJobTicketXmpPropertiesJpegImage

                    Console.WriteLine("File saved in destination folder.")
                Catch exp As Exception
                    Console.WriteLine(exp.Message)
                End Try
            End Sub
            ''' <summary>
            ''' Updates thumbnails in XMP data of Jpeg file and creates output file
            ''' </summary> 
            Public Shared Sub UpdateThumbnailInXMPData()
                Try
                    'ExStart:UpdateThumbnailXmpPropertiesJpegImage

                    Dim path As String = Common.MapSourceFilePath(filePath)
                    ' initialize JpegFormat
                    Dim jpegFormat As New JpegFormat(Common.MapSourceFilePath(filePath))

                    ' get image base64 string
                    Dim base64String As String
                    Using image__1 As Image = Image.FromFile(path)
                        Using m As New MemoryStream()
                            image__1.Save(m, image__1.RawFormat)
                            Dim imageBytes As Byte() = m.ToArray()

                            ' Convert byte[] to Base64 String
                            base64String = Convert.ToBase64String(imageBytes)
                        End Using
                    End Using

                    ' create image thumbnail
                    Dim thumbnail As New Thumbnail() With { _
                         .ImageBase64 = base64String _
                    }

                    ' initialize array and add thumbnail
                    Dim thumbnails As Thumbnail() = New Thumbnail(0) {}
                    thumbnails(0) = thumbnail

                    ' update thumbnails property in XMP Basic schema
                    jpegFormat.XmpValues.Schemes.XmpBasic.Thumbnails = thumbnails

                    ' commit changes
                    jpegFormat.Save(Common.MapDestinationFilePath(filePath))

                    'ExEnd:UpdateThumbnailXmpPropertiesJpegImage

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
                        ' get longitude
                        Console.WriteLine("Longitude: {0}", exif.GPSData.Longitude(0).ToString())
                        ' get latitude
                        Console.WriteLine("Latitude: {0}", exif.GPSData.Latitude(0).ToString())
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
            ''' Updates Exif info using properties and creates output file
            ''' </summary> 
            Public Shared Sub UpdateExifInfoUsingProperties()
                Try
                    'ExStart:UpdateExifValuesUsingPropertiesJpegImage
                    ' initialize JpegFormat
                    Dim jpegFormat As New JpegFormat(Common.MapSourceFilePath(filePath))

                    ' get EXIF data
                    Dim exif As JpegExifInfo = DirectCast(jpegFormat.ExifValues, JpegExifInfo)

                    ' set artist
                    exif.Artist = "new test artist"

                    ' set the name of the camera's owner
                    exif.CameraOwnerName = "new camera owner's name"

                    ' set description
                    exif.ImageDescription = "update test description"

                    ' commit changes
                    jpegFormat.Save(Common.MapDestinationFilePath(filePath))
                    'ExEnd:UpdateExifValuesUsingPropertiesJpegImage

                    Console.WriteLine("File saved in destination folder.")
                Catch exp As Exception
                    Console.WriteLine(exp.Message)
                End Try
            End Sub
            ''' <summary>
            ''' Removes GPS Data of Jpeg file and creates output file
            ''' </summary> 
            Public Shared Sub RemoveGPSData()
                Try
                    'ExStart:RemoveGPSDataJpegImage
                    ' initialize JpegFormat
                    Dim jpegFormat As New JpegFormat(Common.MapSourceFilePath(filePath))

                    ' get location
                    Dim location As GpsLocation = jpegFormat.GetGpsLocation()
                    If location IsNot Nothing Then
                        ' remove GPS location
                        jpegFormat.RemoveGpsLocation()
                    End If

                    ' commit changes
                    jpegFormat.Save(Common.MapDestinationFilePath(filePath))
                    'ExEnd:RemoveGPSDataJpegImage

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
                    If gifFormat.IsSupportedXmp Then
                        ' get XMP data
                        Dim xmpProperties As XmpProperties = gifFormat.GetXmpProperties()

                        ' show XMP data
                        For Each key As String In xmpProperties.Keys
                            Dim xmpNodeView As XmpNodeView = xmpProperties(key)
                            Console.WriteLine("[{0}] = {1}", xmpNodeView.Name, xmpNodeView.Value)
                        Next
                        'ExEnd:GetXMPPropertiesGifImage
                    End If
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
                    If gifFormat.IsSupportedXmp Then
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
                    End If
                    'ExEnd:UpdateXMPPropertiesGifImage

                    Console.WriteLine("File saved in destination folder.")
                Catch exp As Exception
                    Console.WriteLine(exp.Message)
                End Try
            End Sub
            ''' <summary>
            ''' Updates XMP values of Gif file and creates output file
            ''' </summary> 
            Public Shared Sub UpdateXMPValues()
                Try
                    'ExStart:UpdateXmpValuesGifImage
                    ' initialize GifFormat
                    Dim GifFormat As New GifFormat(Common.MapSourceFilePath(filePath))

                    Const dcFormat As String = "test format"
                    Dim dcContributors As String() = {"test contributor"}
                    Const dcCoverage As String = "test coverage"
                    Const phCity As String = "NY"
                    Const phCountry As String = "USA"
                    Const xmpCreator As String = "GroupDocs.Metadata"

                    GifFormat.XmpValues.Schemes.DublinCore.Format = dcFormat
                    GifFormat.XmpValues.Schemes.DublinCore.Contributors = dcContributors
                    GifFormat.XmpValues.Schemes.DublinCore.Coverage = dcCoverage
                    GifFormat.XmpValues.Schemes.Photoshop.City = phCity
                    GifFormat.XmpValues.Schemes.Photoshop.Country = phCountry
                    GifFormat.XmpValues.Schemes.XmpBasic.CreatorTool = xmpCreator

                    ' commit changes
                    GifFormat.Save(Common.MapDestinationFilePath(filePath))
                    'ExEnd:UpdateXmpValuesGifImage
                    Console.WriteLine("File saved in destination folder.")
                Catch exp As Exception
                    Console.WriteLine(exp.Message)
                End Try
            End Sub
            ''' <summary>
            ''' Updates PagedText XMP data of Gif file and creates output file
            ''' </summary> 
            Public Shared Sub UpdatePagedTextXMPProperties()
                Try
                    'ExStart:UpdatePagedTextXmpPropertiesGifImage
                    ' initialize GifFormat
                    Dim GifFormat As New GifFormat(Common.MapSourceFilePath(filePath))

                    ' get access to PagedText schema
                    Dim package = GifFormat.XmpValues.Schemes.PagedText

                    ' update MaxPageSize
                    package.MaxPageSize = New Dimensions(600, 800)

                    ' update number of pages
                    package.NumberOfPages = 10

                    ' update plate names
                    package.PlateNames = New String() {"1", "2", "3"}

                    ' commit changes
                    GifFormat.Save(Common.MapDestinationFilePath(filePath))
                    'ExEnd:UpdatePagedTextXmpPropertiesGifImage
                    Console.WriteLine("File saved in destination folder.")
                Catch exp As Exception
                    Console.WriteLine(exp.Message)
                End Try
            End Sub
            ''' <summary>
            ''' Updates CameraRaw XMP data of Gif file and creates output file
            ''' </summary> 
            Public Shared Sub UpdateCameraRawXMPProperties()
                Try
                    'ExStart:UpdateCameraRawXmpPropertiesGifImage
                    ' initialize GifFormat
                    Dim GifFormat As New GifFormat(Common.MapSourceFilePath(filePath))

                    ' get access to CameraRaw schema
                    Dim package = GifFormat.XmpValues.Schemes.CameraRaw

                    ' update properties
                    package.AutoBrightness = True
                    package.AutoContrast = True
                    package.CropUnits = CropUnits.Pixels

                    ' update white balance
                    package.SetWhiteBalance(WhiteBalance.Auto)

                    ' commit changes
                    GifFormat.Save(Common.MapDestinationFilePath(filePath))
                    'ExEnd:UpdateCameraRawXmpPropertiesGifImage
                    Console.WriteLine("File saved in destination folder.")
                Catch exp As Exception
                    Console.WriteLine(exp.Message)
                End Try
            End Sub
            ''' <summary>
            ''' Updates Basic Job XMP data of Gif file and creates output file
            ''' </summary> 
            Public Shared Sub UpdateBasicJobXMPProperties()
                Try
                    'ExStart:UpdateBasicJobTicketXmpPropertiesGifImage
                    ' initialize GifFormat
                    Dim gifFormat As New GifFormat(Common.MapSourceFilePath(filePath))

                    ' get xmp data
                    Dim xmp = gifFormat.GetXmpData()

                    Dim package As BasicJobTicketPackage = Nothing

                    ' looking for the BasicJob schema if xmp data is presented
                    If xmp IsNot Nothing Then
                        package = TryCast(xmp.GetPackage(Namespaces.BasicJob), BasicJobTicketPackage)
                    Else
                        xmp = New XmpPacketWrapper()
                    End If

                    If package Is Nothing Then
                        ' create package if not exist
                        package = New BasicJobTicketPackage()

                        ' and add it to xmp data
                        xmp.AddPackage(package)
                    End If

                    ' create array of jobs
                    Dim jobs As Job() = New Job(0) {}
                    jobs(0) = New Job() With { _
                         .Id = "1", _
                         .Name = "test job" _
                    }

                    ' update schema
                    package.SetJobs(jobs)

                    ' update xmp data
                    gifFormat.SetXmpData(xmp)

                    ' commit changes
                    gifFormat.Save(Common.MapDestinationFilePath(filePath))
                    'ExEnd:UpdateBasicJobTicketXmpPropertiesGifImage

                    Console.WriteLine("File saved in destination folder.")
                Catch exp As Exception
                    Console.WriteLine(exp.Message)
                End Try
            End Sub
            ''' <summary>
            ''' Updates thumbnails in XMP data of Gif file and creates output file
            ''' </summary> 
            Public Shared Sub UpdateThumbnailInXMPData()
                Try
                    'ExStart:UpdateThumbnailXmpPropertiesGifImage

                    Dim path As String = Common.MapSourceFilePath(filePath)
                    ' initialize GifFormat
                    Dim gifFormat As New GifFormat(Common.MapSourceFilePath(filePath))

                    ' get image base64 string
                    Dim base64String As String
                    Using image__1 As Image = Image.FromFile(path)
                        Using m As New MemoryStream()
                            image__1.Save(m, image__1.RawFormat)
                            Dim imageBytes As Byte() = m.ToArray()

                            ' Convert byte[] to Base64 String
                            base64String = Convert.ToBase64String(imageBytes)
                        End Using
                    End Using

                    ' create image thumbnail
                    Dim thumbnail As New Thumbnail() With { _
                         .ImageBase64 = base64String _
                    }

                    ' initialize array and add thumbnail
                    Dim thumbnails As Thumbnail() = New Thumbnail(0) {}
                    thumbnails(0) = thumbnail

                    ' update thumbnails property in XMP Basic schema
                    gifFormat.XmpValues.Schemes.XmpBasic.Thumbnails = thumbnails

                    ' commit changes
                    gifFormat.Save(Common.MapDestinationFilePath(filePath))

                    'ExEnd:UpdateThumbnailXmpPropertiesGifImage

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
                    If gifFormat.IsSupportedXmp Then
                        ' remove XMP package
                        gifFormat.RemoveXmpData()

                        ' commit changes
                        gifFormat.Save(Common.MapDestinationFilePath(filePath))
                    End If
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
            Private Const filePath As String = "Images/Png/sample2.png"
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
            ''' Updates XMP values of Png file and creates output file
            ''' </summary> 
            Public Shared Sub UpdateXMPValues()
                Try
                    'ExStart:UpdateXmpValuesPngImage
                    ' initialize PngFormat
                    Dim PngFormat As New PngFormat(Common.MapSourceFilePath(filePath))

                    Const dcFormat As String = "test format"
                    Dim dcContributors As String() = {"test contributor"}
                    Const dcCoverage As String = "test coverage"
                    Const phCity As String = "NY"
                    Const phCountry As String = "USA"
                    Const xmpCreator As String = "GroupDocs.Metadata"

                    PngFormat.XmpValues.Schemes.DublinCore.Format = dcFormat
                    PngFormat.XmpValues.Schemes.DublinCore.Contributors = dcContributors
                    PngFormat.XmpValues.Schemes.DublinCore.Coverage = dcCoverage
                    PngFormat.XmpValues.Schemes.Photoshop.City = phCity
                    PngFormat.XmpValues.Schemes.Photoshop.Country = phCountry
                    PngFormat.XmpValues.Schemes.XmpBasic.CreatorTool = xmpCreator

                    ' commit changes
                    PngFormat.Save(Common.MapDestinationFilePath(filePath))
                    'ExEnd:UpdateXmpValuesPngImage
                    Console.WriteLine("File saved in destination folder.")
                Catch exp As Exception
                    Console.WriteLine(exp.Message)
                End Try
            End Sub
            ''' <summary>
            ''' Updates PagedText XMP data of Png file and creates output file
            ''' </summary> 
            Public Shared Sub UpdatePagedTextXMPProperties()
                Try
                    'ExStart:UpdatePagedTextXmpPropertiesPngImage
                    ' initialize PngFormat
                    Dim PngFormat As New PngFormat(Common.MapSourceFilePath(filePath))

                    ' get access to PagedText schema
                    Dim package = PngFormat.XmpValues.Schemes.PagedText

                    ' update MaxPageSize
                    package.MaxPageSize = New Dimensions(600, 800)

                    ' update number of pages
                    package.NumberOfPages = 10

                    ' update plate names
                    package.PlateNames = New String() {"1", "2", "3"}

                    ' commit changes
                    PngFormat.Save(Common.MapDestinationFilePath(filePath))
                    'ExEnd:UpdatePagedTextXmpPropertiesPngImage
                    Console.WriteLine("File saved in destination folder.")
                Catch exp As Exception
                    Console.WriteLine(exp.Message)
                End Try
            End Sub
            ''' <summary>
            ''' Updates CameraRaw XMP data of Png file and creates output file
            ''' </summary> 
            Public Shared Sub UpdateCameraRawXMPProperties()
                Try
                    'ExStart:UpdateCameraRawXmpPropertiesPngImage
                    ' initialize PngFormat
                    Dim PngFormat As New PngFormat(Common.MapSourceFilePath(filePath))

                    ' get access to CameraRaw schema
                    Dim package = PngFormat.XmpValues.Schemes.CameraRaw

                    ' update properties
                    package.AutoBrightness = True
                    package.AutoContrast = True
                    package.CropUnits = CropUnits.Pixels

                    ' update white balance
                    package.SetWhiteBalance(WhiteBalance.Auto)

                    ' commit changes
                    PngFormat.Save(Common.MapDestinationFilePath(filePath))
                    'ExEnd:UpdateCameraRawXmpPropertiesPngImage
                    Console.WriteLine("File saved in destination folder.")
                Catch exp As Exception
                    Console.WriteLine(exp.Message)
                End Try
            End Sub
            ''' <summary>
            ''' Updates Basic Job XMP data of Png file and creates output file
            ''' </summary> 
            Public Shared Sub UpdateBasicJobXMPProperties()
                Try
                    'ExStart:UpdateBasicJobTicketXmpPropertiesPngImage
                    ' initialize PngFormat
                    Dim pngFormat As New PngFormat(Common.MapSourceFilePath(filePath))

                    ' get xmp data
                    Dim xmp = pngFormat.GetXmpData()

                    Dim package As BasicJobTicketPackage = Nothing

                    ' looking for the BasicJob schema if xmp data is presented
                    If xmp IsNot Nothing Then
                        package = TryCast(xmp.GetPackage(Namespaces.BasicJob), BasicJobTicketPackage)
                    Else
                        xmp = New XmpPacketWrapper()
                    End If

                    If package Is Nothing Then
                        ' create package if not exist
                        package = New BasicJobTicketPackage()

                        ' and add it to xmp data
                        xmp.AddPackage(package)
                    End If

                    ' create array of jobs
                    Dim jobs As Job() = New Job(0) {}
                    jobs(0) = New Job() With { _
                         .Id = "1", _
                         .Name = "test job" _
                    }

                    ' update schema
                    package.SetJobs(jobs)

                    ' update xmp data
                    pngFormat.SetXmpData(xmp)

                    ' commit changes
                    pngFormat.Save(Common.MapDestinationFilePath(filePath))
                    'ExEnd:UpdateBasicJobTicketXmpPropertiesPngImage

                    Console.WriteLine("File saved in destination folder.")
                Catch exp As Exception
                    Console.WriteLine(exp.Message)
                End Try
            End Sub
            ''' <summary>
            ''' Updates thumbnails in XMP data of Png file and creates output file
            ''' </summary> 
            Public Shared Sub UpdateThumbnailInXMPData()
                Try
                    'ExStart:UpdateThumbnailXmpPropertiesPngImage

                    Dim path As String = Common.MapSourceFilePath(filePath)
                    ' initialize PngFormat
                    Dim pngFormat As New PngFormat(Common.MapSourceFilePath(filePath))

                    ' get image base64 string
                    Dim base64String As String
                    Using image__1 As Image = Image.FromFile(path)
                        Using m As New MemoryStream()
                            image__1.Save(m, image__1.RawFormat)
                            Dim imageBytes As Byte() = m.ToArray()

                            ' Convert byte[] to Base64 String
                            base64String = Convert.ToBase64String(imageBytes)
                        End Using
                    End Using

                    ' create image thumbnail
                    Dim thumbnail As New Thumbnail() With { _
                         .ImageBase64 = base64String _
                    }

                    ' initialize array and add thumbnail
                    Dim thumbnails As Thumbnail() = New Thumbnail(0) {}
                    thumbnails(0) = thumbnail

                    ' update thumbnails property in XMP Basic schema
                    pngFormat.XmpValues.Schemes.XmpBasic.Thumbnails = thumbnails

                    ' commit changes
                    pngFormat.Save(Common.MapDestinationFilePath(filePath))

                    'ExEnd:UpdateThumbnailXmpPropertiesPngImage

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

        Public NotInheritable Class Tiff
            Private Sub New()
            End Sub
            ' initialize file path
            'ExStart:SourceTiffFilePath
            Private Const filePath As String = "Images/Tiff/sample.tif"
            'ExEnd:SourceTiffFilePath

            ''' <summary>
            ''' Gets Exif info from Tiff file
            ''' </summary> 
            Public Shared Sub GetExifInfo()
                Try
                    'ExStart:GetExifPropertiesTiffImage
                    ' initialize TiffFormat
                    Dim tiffFormat As New TiffFormat(Common.MapSourceFilePath(filePath))

                    ' get EXIF data
                    Dim exif As ExifInfo = tiffFormat.GetExifInfo()

                    If exif IsNot Nothing Then
                        ' get BodySerialNumber 
                        Console.WriteLine("Body Serial Number: {0}", exif.BodySerialNumber)
                        ' get CameraOwnerName 
                        Console.WriteLine("Camera Owner Name: {0}", exif.CameraOwnerName)
                        ' get CFAPattern 
                        Console.WriteLine("CFA Pattern: {0}", exif.CFAPattern)
                        ' get GPSData 
                        Console.WriteLine("GPS Data: {0}", exif.GPSData)
                        ' get UserComment 
                        Console.WriteLine("User Comment: {0}", exif.UserComment)
                        'ExEnd:GetExifPropertiesTiffImage
                    End If
                Catch exp As Exception
                    Console.WriteLine(exp.Message)
                End Try
            End Sub
            ''' <summary>
            ''' Updates Exif info of Tiff file and creates output file
            ''' </summary> 
            Public Shared Sub UpdateExifInfo()
                Try
                    'ExStart:UpdateExifPropertiesTiffImage
                    ' initialize TiffFormat
                    Dim tiffFormat As New TiffFormat(Common.MapSourceFilePath(filePath))

                    ' get EXIF data
                    Dim exif As ExifInfo = tiffFormat.GetExifInfo()

                    exif.UserComment = "New User Comment"
                    exif.BodySerialNumber = "New Body Serial Number"
                    exif.CameraOwnerName = "New Camera Owner Name"

                    ' update EXIF info
                    tiffFormat.UpdateExifInfo(exif)

                    ' commit changes and save output file
                    'ExEnd:UpdateExifPropertiesTiffImage
                    tiffFormat.Save(Common.MapDestinationFilePath(filePath))
                Catch exp As Exception
                    Console.WriteLine(exp.Message)
                End Try
            End Sub
            ''' <summary>
            ''' Updates Exif info using properties and creates output file
            ''' </summary> 
            Public Shared Sub UpdateExifInfoUsingProperties()
                Try
                    'ExStart:UpdateExifValuesUsingPropertiesTiffImage
                    ' initialize TiffFormat
                    Dim tiffFormat As New TiffFormat(Common.MapSourceFilePath(filePath))

                    tiffFormat.ExifValues.CameraOwnerName = "camera owner's name"

                    ' set user comment
                    tiffFormat.ExifValues.UserComment = "user's comment"

                    ' commit changes
                    tiffFormat.Save(Common.MapDestinationFilePath(filePath))
                    'ExEnd:UpdateExifValuesUsingPropertiesTiffImage

                    Console.WriteLine("File saved in destination folder.")
                Catch exp As Exception
                    Console.WriteLine(exp.Message)
                End Try
            End Sub
            ''' <summary>
            ''' Removes Exif info from Tiff file
            ''' </summary> 
            Public Shared Sub RemoveExifInfo()
                Try
                    'ExStart:RemoveExifPropertiesTiffImage
                    ' initialize TiffFormat
                    Dim tiffFormat As New TiffFormat(Common.MapSourceFilePath(filePath))

                    ' remove Exif info
                    tiffFormat.RemoveExifInfo()

                    ' commit changes and save output file
                    'ExEnd:RemoveExifPropertiesTiffImage
                    tiffFormat.Save(Common.MapDestinationFilePath(filePath))
                Catch exp As Exception
                    Console.WriteLine(exp.Message)
                End Try
            End Sub

        End Class

        Public NotInheritable Class Psd
            Private Sub New()
            End Sub
            ' initialize file path
            'ExStart:SourcePSDFilePath
            Private Const filePath As String = "Images/Psd/sample.psd"
            'ExEnd:SourcePSDFilePath

            ''' <summary>
            ''' Gets Psd Info
            ''' </summary> 
            Public Shared Sub GetPsdInfo()
                Try
                    'ExStart:GetPsdInfo
                    ' initialize PsdFormat 
                    Dim psdFormat As New PsdFormat(Common.MapSourceFilePath(filePath))

                    ' get PSD info
                    Dim metadata As PsdMetadata = psdFormat.GetPsdInfo()

                    If metadata IsNot Nothing Then
                        ' get ChannelsCount 
                        Console.WriteLine("Channels Count: {0}", metadata.ChannelsCount)
                        ' get ColorMode 
                        Console.WriteLine("Color Mode: {0}", metadata.ColorMode)
                        ' get CompressionMethod 
                        Console.WriteLine("Compression Method: {0}", metadata.CompressionMethod)
                        ' get Height 
                        Console.WriteLine("Height: {0}", metadata.Height)
                        ' get Width 
                        Console.WriteLine("Width: {0}", metadata.Width)
                        ' get PhotoshopVersion 

                        Console.WriteLine("Photoshop Version: {0}", metadata.PhotoshopVersion)
                        'ExEnd:GetPsdInfo
                    End If
                Catch exp As Exception
                    Console.WriteLine(exp.Message)
                End Try
            End Sub


        End Class

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
                    'ExEnd:ImageSearchAPI
                Next
            Catch exp As Exception
                Console.WriteLine("Exception occurred: " + exp.Message)
            End Try

        End Sub
    End Class

End Namespace

