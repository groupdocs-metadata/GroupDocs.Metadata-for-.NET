Imports GroupDocs.Metadata.Examples.VBasic.Utilities
Imports GroupDocs.Metadata.Formats
Imports GroupDocs.Metadata.Tools
Imports System.IO

Namespace GroupDocs.Metadata.Examples.CSharp.Utilities
	'ExStart:MIMETypeDetector
	Public Class MIMETypeDetector

		''' <summary>
		'''Retrieves MIME type of the specific file or file stream.
		''' </summary>
		''' <param name="directory">Directory Path</param>
		Public Shared Sub GetMimeType(directory__1 As String)
			Try
				'ExStart: MIMETypeDetection
				' get all files inside directory
				Dim files As String() = Directory.GetFiles(Common.MapSourceFilePath(directory__1))

				For Each path__2 As String In files
					' get MIME type string
					Dim mimeType As String = MetadataUtility.GetMimeType(path__2)

					Console.WriteLine("File: {0}, MIME type: {1}", Path.GetFileName(path__2), mimeType)
					'ExEnd: MIMETypeDetection
				Next
			Catch exp As Exception
				Console.WriteLine("Exception occurred: " + exp.Message)
			End Try
		End Sub

		''' <summary>
		''' Gets and returns MIME type in the file using MIMEType property in FormatBase class or it's children.
		''' </summary>
		''' <param name="path">File Path</param> 
		Public Shared Sub GetMimeTypeUsingFormatBaseApproach(filePath As String)
			Try
				'ExStart: MIMETypeDetectionUsingFormatBase
				' recognize format
				Dim format As FormatBase = FormatFactory.RecognizeFormat(Common.MapSourceFilePath(filePath))

				' and get MIME type
				Dim mimeType As String = format.MIMEType
					'ExEnd: MIMETypeDetectionUsingFormatBase
				Console.WriteLine("MIME type: {0}", mimeType)
			Catch exp As Exception
				Console.WriteLine("Exception occurred: " + exp.Message)
			End Try
		End Sub
	End Class
	'ExEnd:MIMETypeDetector
End Namespace
