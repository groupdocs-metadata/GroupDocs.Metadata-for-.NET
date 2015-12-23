
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports GroupDocs.Metadata.Formats.Image
Imports GroupDocs.Metadata.Xmp
Imports GroupDocs.Metadata.Tools
Imports GroupDocs.Metadata.Standards.Xmp
Imports GroupDocs.Metadata.Xmp.Types.Basic
Imports GroupDocs.Metadata.Xmp.Types.Derived
Imports GroupDocs.Metadata.Xmp.Types.Complex.Colorant
Imports GroupDocs.Metadata.Xmp.Types.Complex.Dimensions
Imports GroupDocs.Metadata.Xmp.Types.Complex.Font
Imports GroupDocs.Metadata.Xmp.Types.Complex.ResourceEvent
Imports GroupDocs.Metadata.Xmp.Types.Complex.ResourceRef
Imports GroupDocs.Metadata.Xmp.Schemas.XmpMM
Imports System.Drawing
Imports System.IO
Imports GroupDocs.Metadata.Xmp.Types.Complex.Thumbnail
Imports GroupDocs.Metadata.Xmp.Types.Complex.Version


Namespace Utilities
    Public Class XMPData
        Public Sub GetXMPData()
            Try
                'ExStart:GetXMPData
                ' create new instance of GifFormat
                Dim gif As New GifFormat("C:\sample.gif")

                ' old version of gif format does not support xmp
                If Not gif.IsSupportedXmp Then
                    Return
                End If

                ' get XMP data
                'ExEnd:GetXMPData
                Dim xmp As XmpPacketWrapper = gif.GetXmpData()

            Catch exp As Exception
            End Try
        End Sub
        Public Sub RemoveXMPData()
            Try
                'ExStart:RemoveXMPData
                ' create new instance of JpegFormat
                Dim jpeg As New JpegFormat("C:\image.jpg")

                ' use RemoveXmpData method to remove xmp metadata
                'ExEnd:RemoveXMPData
                jpeg.RemoveXmpData()

            Catch exp As Exception
            End Try
        End Sub
        Public Sub UpdateXMPData()
            Try
                'ExStart:UpdateXMP
                ' path to the modified file
                Dim filePath As String = "Images/Jpeg/sample.jpg"

                ' get xmp wrapper
                Dim xmpWrapper As XmpPacketWrapper = MetadataUtility.ExtractXmpPackage(filePath)

                ' if wrapper is null
                If xmpWrapper Is Nothing Then
                    ' create it
                    xmpWrapper = New XmpPacketWrapper()
                End If

                ' create package
                Dim addingSchema As New XmpPackage("rs", "http://www.metadataworkinggroup.com/schemas/regions/")

                ' set date property
                addingSchema.AddValue("rs:createdDate", DateTime.UtcNow)

                ' set string property
                addingSchema.AddValue("rs:File", "File name")

                'initialze unordered xmp array
                Dim managersArray As New XmpArray(XmpArrayType.UNORDERED)
                managersArray.AddItem("Joe Doe")
                managersArray.AddItem("Adam White")

                ' set array property
                addingSchema.SetArray("rs:managers", managersArray)

                ' initialize xmp language alternative
                Dim availableDays As New LangAlt()
                ' add first value for 'en-us' language
                availableDays.AddLanguage("en-us", "Tue")
                ' add second value for 'en-us' languge
                availableDays.AddLanguage("en-us", "Fri")

                ' set LangAlt property
                addingSchema.SetLangAlt("rs:days", availableDays)

                ' update xmp wrapper with new schema
                xmpWrapper.AddPackage(addingSchema)

                ' create XmpMetadata with updated wrapper
                Dim xmpMetadata As New XMPMetadata()
                xmpMetadata.XmpPacket = xmpWrapper

                ' update XMP
                'ExEnd:UpdateXMP
                MetadataUtility.UpdateMetadata(filePath, xmpMetadata)

            Catch exp As Exception
            End Try
        End Sub
        Public Sub CreateBasicXMPTypes()
            'ExStart:CreateXMPBoolean
            ' create XmpBoolean from string
            Dim xmpBoolean As New XmpBoolean("True")

            ' create XmpBoolean using .NET bool
            Dim xmpBoolean2 As New XmpBoolean(True)

            ' values should be equal
            If xmpBoolean.Value = xmpBoolean2.Value Then
                Console.WriteLine("Equals!")
            End If
            'ExEnd:CreateXMPBoolean


            'ExStart:CreateXMPDate
            ' create date from string
            Dim date1 As New XmpDate("2016-01-10")

            ' create the same date using.NET DateTime
            Dim date2 As New XmpDate(New DateTime(2016, 1, 10))
            'ExEnd:CreateXMPDate

        End Sub
        Public Sub CreateDerivedXMPTypes()
            'ExStart:CreateXMPGuid
            ' init new C# struct Guid
            Dim guid__1 As Guid = Guid.NewGuid()

            ' create xmp guid using C# struct
            Dim xmpGuid As New XmpGuid(guid__1)

            ' create xmp guid using it's string representation
            Dim xmpGuid2 As New XmpGuid(guid__1.ToString())
            'ExEnd:CreateXMPGuid


            'ExStart:CreateRational
            Dim numerator As Integer = 1
            Dim denominator As Integer = 10

            ' create xmp rational
            Dim rational As New Rational(numerator, denominator)

            ' float value should be 0.1
            Dim value As Single = rational.FloatValue
            'ExEnd:CreateRational


            'ExStart:CreateLanguageAlternative
            ' init LangAlt with default value
            Dim langAlt As New LangAlt("XMP - Extensible Metadata Platform")

            ' add value for en-us language
            langAlt.AddLanguage("en-us", "XMP - Extensible Metadata Platform")

            ' add value for French language
            langAlt.AddLanguage("fr", "XMP - Une Platforme Extensible pour les Métadonnées")
            'ExEnd:CreateLanguageAlternative

        End Sub
        Public Sub CreateComplexXMPTypes()
            'ExStart:CreateColorant
            ' create RGB colorant with R, G, B components
            Dim rgbColorant As New ColorantRGB(254, 254, 1)

            ' create CMYK colorant with Black, Cyan, Magenta, Yellow components
            Dim cmykColorant As New ColorantCMYK(10, 10, 1, 50)
            'ExEnd:CreateColorant


            'ExStart:CreateDimensions
            Dim width As Integer = 100
            Dim height As Integer = 50

            ' create dimensions
            Dim dimensions As New Dimensions(width, height)
            dimensions.Units = "inch"

            ' create dimensions using object initializer
            Dim dimensions2 As New Dimensions()
            dimensions2.Width = width
            dimensions2.Height = height
            dimensions2.Units = "inch"
            'ExEnd:CreateDimensions


            'ExStart:CreateFont
            Dim fontFamily As String = "Arial"

            ' create Arial font
            Dim font As New Global.GroupDocs.Metadata.Xmp.Types.Complex.Font.Font(fontFamily)
            'ExEnd:CreateFont


            'ExStart:CreateResourceEvent
            ' create ResourceEvent type
            Dim resourceEvent As New ResourceEvent()

            ' set the action that occurred
            resourceEvent.Action = "edited"

            ' Additional description of the action
            resourceEvent.Parameters = "secon version"
            'ExEnd:CreateResourceEvent


            'ExStart:CreateResourceRef
            Dim expectedValue As New ResourceRef() With { _
                .DocumentUri = "074255bf-78bc-4002-89dc-cd7538b40fe0", _
             .InstanceId = "42a841b7-48d4-4988-8988-53d2c6e7525d" _
            }

            ' create XmpMediaManagementPackage
            Dim package As New XmpMediaManagementPackage()

            ' update DerivedFrom property
            package.SetDerivedFrom(expectedValue)

            ' check value
            Dim value As ResourceRef = DirectCast(package("xmpMM:DerivedFrom"), ResourceRef)
            'ExEnd:CreateResourceRef


            'ExStart:CreateThumbnail
            ' path to the image
            Dim imagePath As String = "C:\\image.jpg"
            Dim base64String As String

            ' use System.Drawing to get image base64 string
            Using image__1 As Image = Image.FromFile(imagePath)
                Using m As New MemoryStream()
                    image__1.Save(m, image__1.RawFormat)
                    Dim imageBytes As Byte() = m.ToArray()

                    ' Convert byte[] to Base64 String
                    base64String = Convert.ToBase64String(imageBytes)
                End Using
            End Using

            ' xmp thumbnail width
            Dim thumbnailWidth As Integer = 100

            ' xmp thumbnail height
            Dim thumbnailHeight As Integer = 50

            ' create xmp thumbnail 
            Dim thumbnail As New Thumbnail(thumbnailWidth, thumbnailHeight)

            ' add provide image base64 string
            thumbnail.ImageBase64 = base64String
            'ExEnd:CreateThumbnail


            'ExStart:CreateVersion
            ' create new instance of Version
            Dim version As New Global.GroupDocs.Metadata.Xmp.Types.Complex.Version.Version()

            ' set version number
            version.VersionText = "1.0"

            ' set version date
            version.ModifiedDate = DateTime.UtcNow

            ' set person who modified this version
            version.Modifier = "Joe Doe"

            ' set version additional comments
            version.Comments = "First version, created by: Joe Doe"
            'ExEnd:CreateVersion
        End Sub
    End Class
End Namespace


