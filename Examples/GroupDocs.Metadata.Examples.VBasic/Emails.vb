
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports GroupDocs.Metadata.Formats.Email 
Imports GroupDocs.Metadata.Examples.VBasic.Utilities

Namespace GroupDocs.Metadata.Examples.VBasic
    Public NotInheritable Class Emails
        Private Sub New()
        End Sub
        Public NotInheritable Class OutLook
            Private Sub New()
            End Sub
            ' initialize files path
            'ExStart:SourceOutlookFilePath
            Private Const filePath As String = "Emails/Outlook/sample.msg"
            'ExEnd:SourceOutlookFilePath

            ''' <summary>
            ''' Gets Outlook email file's metadata
            ''' </summary>
            Public Shared Sub GetOutlookEmailMetadata()
                Try
                    'ExStart:GetOutlookEmailMessageMetadata
                    ' initialize outlookFormat
                    Dim msgFormat As New OutlookMessage(Common.MapSourceFilePath(filePath))

                    ' get metadata
                    Dim metadata As OutlookMessageMetadata = msgFormat.GetMsgInfo()

                    ' display metadata
                    Console.WriteLine("Body: " + metadata.Body)
                    Console.WriteLine("DeliveryTime: " + metadata.DeliveryTime)
                    Console.WriteLine("Recipients: " + metadata.Recipients(0))
                    Console.WriteLine("Subject: " + metadata.Subject)                    
                    Console.WriteLine("Attachments: " + metadata.Attachments(0))
		   'ExEnd:GetOutlookEmailMessageMetadata
                Catch exp As Exception
                    Console.WriteLine(exp.Message)
                End Try
            End Sub

            ''' <summary>
            ''' Removes Outlook email attachments
            ''' </summary>
            Public Shared Sub RemoveOutlookEmailAttachments()
                Try
                    'ExStart:RemoveOutlookEmailAttachments
                    ' initialize outlookFormat 
                    Dim outlookFormat As New OutlookMessage(Common.MapSourceFilePath(filePath))

                    ' remove attachments
                    outlookFormat.RemoveAttachments()

                    ' commit changes                    
                    outlookFormat.Save(Common.MapDestinationFilePath(filePath))
		   'ExEnd:RemoveOutlookEmailAttachments
                Catch exp As Exception
                    Console.WriteLine(exp.Message)
                End Try
            End Sub

            ''' <summary>
            ''' Removes email metadata
            ''' </summary>
            Public Shared Sub RemoveOutlookEmailMetadata()
                Try
                    'ExStart:RemoveOutlookEmailMetadata
                    ' initialize outlookFormat 
                    Dim outlookFormat As New OutlookMessage(Common.MapSourceFilePath(filePath))

                    ' remove metadata
                    outlookFormat.CleanMetadata()

                    ' commit changes                    
                    outlookFormat.Save(Common.MapDestinationFilePath(filePath))
		    'ExEnd:RemoveOutlookEmailMetadata
                Catch exp As Exception
                    Console.WriteLine(exp.Message)
                End Try
            End Sub
        End Class

        Public NotInheritable Class Eml
            Private Sub New()
            End Sub
            ' initialize files path
            'ExStart:SourceEmailFilePath 
            Private Const filePath As String = "Emails/Eml/sample.eml"
            'ExEnd:SourceEmailFilePath

            ''' <summary>
            ''' Gets email file's metadata
            ''' </summary>
            Public Shared Sub GetEmailMetadata()
                Try
                    'ExStart:GetEmailMessageMetadata
                    ' initialize EmlFormat 
                    Dim emlFormat As New EmlFormat(Common.MapSourceFilePath(filePath))
                    ' get metadata
                    Dim metadata As EmlMetadata = emlFormat.GetEmlInfo()

                    ' display metadata
                    Console.WriteLine("CC: {0}", metadata.CC(0))
                    Console.WriteLine("Mail Address From: {0}", metadata.MailAddressFrom)
                    Console.WriteLine("Subject: {0}", metadata.Subject)                    
                    Console.WriteLine("Attachments: {0}", metadata.Attachments(0))
		    'ExEnd:GetEmailMessageMetadata
                Catch exp As Exception
                    Console.WriteLine(exp.Message)
                End Try
            End Sub
            ''' <summary>
            ''' Removes email attachments
            ''' </summary>
            Public Shared Sub RemoveEmailAttachments()
                Try
                    'ExStart:RemoveEmailAttachments
                    ' initialize emlFormat 
                    Dim emlFormat As New EmlFormat(Common.MapSourceFilePath(filePath))

                    ' remove attachments
                    emlFormat.RemoveAttachments()

                    ' commit changes                    
                    emlFormat.Save(Common.MapDestinationFilePath(filePath))
		    'ExEnd:RemoveEmailAttachments
                Catch exp As Exception
                    Console.WriteLine(exp.Message)
                End Try
            End Sub
            ''' <summary>
            ''' Removes email metadata
            ''' </summary>
            Public Shared Sub RemoveEmailMetadata()
                Try
                    'ExStart:RemoveEmailMetadata
                    ' initialize emlFormat 
                    Dim emlFormat As New EmlFormat(Common.MapSourceFilePath(filePath))

                    ' remove metadata
                    emlFormat.CleanMetadata()

                    ' commit changes
                    emlFormat.Save(Common.MapDestinationFilePath(filePath))
                    'ExEnd:RemoveEmailMetadata
                Catch exp As Exception
                    Console.WriteLine(exp.Message)
                End Try
            End Sub
        End Class
    End Class
End Namespace
