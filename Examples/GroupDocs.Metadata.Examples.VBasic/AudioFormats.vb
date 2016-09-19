Imports GroupDocs.Metadata.Examples.VBasic.Utilities
Imports GroupDocs.Metadata.Formats
Imports GroupDocs.Metadata.Formats.Audio
Imports GroupDocs.Metadata.Tools
Imports System.Collections.Generic
Imports System.IO
Imports System.Linq
Imports System.Text

Namespace GroupDocs.Metadata.Examples.VBasic
    Public NotInheritable Class AudioFormats
        Private Sub New()
        End Sub
        Public NotInheritable Class Mp3
            Private Sub New()
            End Sub
            ' initialize file path and directory path
            'ExStart:SourceMp3FilePath + SourceMp3DirectoryPath
            'string dir = @"C:\\download files";
            Private Const directoryPath As String = "Audio/Mp3"
            Private Const filePath As String = "Audio/Mp3/test.mp3"
            'ExEnd:SourceMp3FilePath + SourceMp3DirectoryPath


            ''' <summary>
            '''  Exports metadata of Mp3 format to Excel. 
            '''  Each new metadata type will be presented in separate sheet
            ''' </summary>
            Public Shared Sub ExportMetadataToExcel()
                'ExStart:ExportMP3MetadataToExcel
                ' path to the out dir
                Dim outputDir As String = directoryPath

                ' get mp3 files only
                Dim files As String() = Directory.GetFiles(directoryPath, "*.mp3")

                For Each path__1 As String In files
                    ' get excel file as byte array
                    Dim bytes As Byte() = ExportFacade.ExportToExcel(path__1)

                    ' prepare excel file name
                    Dim resultFileName As String = String.Format("{0}\{1}.xlsx", outputDir, Path.GetFileNameWithoutExtension(path__1))

                    ' remove output file if exist
                    If File.Exists(resultFileName) Then
                        File.Delete(resultFileName)
                    End If

                    ' write file to the file system
                    File.WriteAllBytes(resultFileName, bytes)
                Next
                'ExEnd:ExportMP3MetadataToExcel
            End Sub

            ''' <summary>
            ''' Detects MP3 audio format
            ''' Recognition engine detect file only by internal file structure, not extension
            ''' 
            ''' </summary>
            Public Shared Sub DetectMp3Format()
                'ExStart:DetectMp3Format
                Dim files As String() = Directory.GetFiles(directoryPath)

                For Each path__1 As String In files
                    ' detect format
                    Dim format As FormatBase = FormatFactory.RecognizeFormat(path__1)
                    If format Is Nothing Then
                        ' skip unsupported format
                        Continue For
                    End If

                    If format.Type = DocumentType.Mp3 Then
                        Console.WriteLine("File {0} has MP3 format", Path.GetFileName(path__1))
                    End If
                Next
                'ExEnd:DetectMp3Format
            End Sub


            ''' <summary>
            ''' Reads ID3v2 tag in MP3 format
            ''' Supported ID3v2.3 and ID3v2.4, ID3v2.2 is obsolete by ID3.org
            ''' </summary> 
            Public Shared Sub ReadID3v2Tag()
                Try
                    'ExStart:ReadID3v2Tag
                    ' initialize Mp3Format class
                    Dim mp3Format As New Mp3Format((Common.MapSourceFilePath(filePath)))

                    ' get ID3 v2 tag
                    Dim id3v2 As Id3v2Tag = mp3Format.Id3v2
                    If id3v2 IsNot Nothing Then
                        ' write ID3v2 version
                        Console.WriteLine("Version: {0}", id3v2.Version)

                        ' write known frames' values
                        Console.WriteLine("Album: {0}", id3v2.Album)
                        Console.WriteLine("Comment: {0}", id3v2.Comment)
                        Console.WriteLine("Composers: {0}", id3v2.Composers)

                        ' in trial mode only first 5 frames are available
                        Dim idFrames As TagFrame() = id3v2.Frames

                        For Each tagFrame As TagFrame In idFrames
                            Console.WriteLine("Frame: {0}, value: {1}", tagFrame.Name, tagFrame.GetFormattedValue())
                        Next
                    End If
                    'ExEnd:ReadID3v2Tag
                Catch ex As Exception
                    Console.WriteLine(ex.Message)
                End Try
            End Sub

            ''' <summary>
            ''' Reads ID3v1 tag in MP3 format
            ''' </summary> 
            ''' 
            Public Shared Sub ReadID3v1Tag()
                Try
                    'ExStart:ReadID3v1Tag
                    ' initialize Mp3Format class
                    Dim mp3Format As New Mp3Format((Common.MapSourceFilePath(filePath)))

                    ' get ID3v1 tag
                    Dim id3V1 As Id3v1Tag = mp3Format.Id3v1

                    'NOTE: please remember you may use different approaches to getting metadata                

                    ' second approach
                    'id3V1 = (Id3v1Tag)MetadataUtility.ExtractSpecificMetadata(file, MetadataType.Id3v1);

                    ' check if ID3v1 is presented. It could be absent in Mpeg file.
                    If id3V1 IsNot Nothing Then
                        ' Display version
                        Console.WriteLine("ID3v1 version: {0}", id3V1.Version)

                        ' Display tag properties
                        Console.WriteLine("Album: {0}", id3V1.Album)
                        Console.WriteLine("Artist: {0}", id3V1.Artist)
                        Console.WriteLine("Comment: {0}", id3V1.Comment)
                        Console.WriteLine("Genre: {0}", id3V1.Genre)
                        Console.WriteLine("Title: {0}", id3V1.Title)
                        Console.WriteLine("Year: {0}", id3V1.Year)

                        If id3V1.Version = "ID3v1.1" Then
                            ' Track number is presented only in ID3 v1.1
                            Console.WriteLine("Track number: {0}", id3V1.TrackNumber)
                        End If

                    End If
                    'ExEnd:ReadID3v1Tag
                Catch ex As Exception
                    Console.WriteLine(ex.Message)
                End Try
            End Sub

            ''' <summary>
            ''' Reads MPEG audio information
            ''' </summary> 
            ''' 
            Public Shared Sub ReadMPEGAudioInfo()
                Try
                    'ExStart:ReadMPEGAudioInfo
                    ' initialize Mp3Format class
                    Dim mp3Format As New Mp3Format((Common.MapSourceFilePath(filePath)))

                    ' get MPEG audio info
                    Dim audioInfo As MpegAudio = mp3Format.AudioDetails

                    ' display MPEG audio version
                    Console.WriteLine("MPEG audio version: {0}", audioInfo.MpegAudioVersion)

                    ' display layer version
                    Console.WriteLine("Layer version: {0}", audioInfo.LayerVersion)

                    ' display protected bit
                    'ExEnd:ReadMPEGAudioInfo
                    Console.WriteLine("Is protected: {0}", audioInfo.IsProtected)
                Catch ex As Exception
                    Console.WriteLine(ex.Message)
                End Try
            End Sub

        End Class
    End Class
End Namespace
