Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports GroupDocs.Metadata.Examples.VBasic.Utilities
Imports GroupDocs.Metadata.Formats
Imports GroupDocs.Metadata.Formats.Video
Imports GroupDocs.Metadata.Tools
Imports System.IO

Namespace GroupDocs.Metadata.Examples.VBasic
	Public NotInheritable Class VideoFormats
		Private Sub New()
		End Sub
		Public NotInheritable Class Avi
			Private Sub New()
			End Sub
			' initialize file path and directory path
			'ExStart:SourceAviFilePath + SourcAviDirectoryPath
			Private Const directoryPath As String = "Video/Avi"
			Private Const filePath As String = "Video/Avi/sample.avi"
			'ExEnd:SourceAviFilePath + SourcAviDirectoryPath

			'ExStart:OutputDataFilePathAvi
			Private Const OutputDataFilePathAvi As String = "Documents/Xls/metadata-avi.xls"

			''' <summary>
			''' Detects AVI video format via Format Factory
			''' </summary>
			Public Shared Sub DetectAviFormat()
				'ExStart:DetectAviFormat
				' recognize format
				Dim format As FormatBase = FormatFactory.RecognizeFormat(Common.MapSourceFilePath(filePath))

				' check format type
				If format.Type = DocumentType.AVI Then
					' cast it to AviFormat
					Dim aviFormat As AviFormat = TryCast(format, AviFormat)

					' and get it MIME type
					Dim mimeType As String = aviFormat.MIMEType
					Console.WriteLine(mimeType)
				End If
				'ExEnd:DetectAviFormat
			End Sub


			''' <summary>
			''' demonstrates how to read AVIMAINHEADER of AVI format
			''' </summary>
			Public Shared Sub ReadAviMainHeader()
				'ExStart:ReadAviMainHeader
				' initialize AviFormat
				Dim aviFormat As New AviFormat(Common.MapSourceFilePath(filePath))

				' get AVI header
				Dim header As AviHeader = aviFormat.Header

				' display video width
				Console.WriteLine("Video width: {0}", header.Width)

				' display video height
				Console.WriteLine("Video height: {0}", header.Height)

				' display total frames
				Console.WriteLine("Total frames: {0}", header.TotalFrames)

				' display number of streams in file
				Console.WriteLine("Number of streams: {0}", header.Streams)

				' display suggested buffer size for reading the file
				Console.WriteLine("Suggested buffer size: {0}", header.SuggestedBufferSize)
				'ExEnd:ReadAviMainHeader
			End Sub

			''' <summary>
			''' Exports AVI metadata to Csv,Xls file
			''' </summary>
			Public Shared Sub ExportMetadata()
				Try
					'ExStart:ExportMetadataAvi
					' export to excel
					Dim content As Byte() = ExportFacade.ExportToExcel(Common.MapSourceFilePath(filePath))

					' write data to the file
					File.WriteAllBytes(Common.MapDestinationFilePath(OutputDataFilePathAvi), content)
					'ExEnd:ExportMetadataAvi
					Console.WriteLine("Metadata has been export successfully")
				Catch ex As Exception
					Console.WriteLine(ex.Message)
				End Try

			End Sub
		End Class
	End Class
End Namespace