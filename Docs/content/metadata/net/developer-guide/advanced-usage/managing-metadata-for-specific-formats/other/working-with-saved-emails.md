---
id: working-with-saved-emails
url: metadata/net/working-with-saved-emails
title: Working with saved Emails
weight: 5
description: ""
keywords: 
productName: GroupDocs.Metadata for .NET
hideChildren: False
---
GroupDocs.Metadata for .NET provides functionality that allows handling the most popular email message formats: EML and MSG. The following are some commonly used scenarios of working with the message content and metadata.

## Reading EML message metadata

The EML message format is used by many email clients including Novell GroupWise, Microsoft Outlook Express, Lotus notes, Windows Mail, Mozilla Thunderbird, and Postbox. The files contain the email contents as plain text in MIME format, containing the email header and body, including attachments in one or more of several formats. The code sample below demonstrates how to extract metadata from an EML message.

**AdvancedUsage.ManagingMetadataForSpecificFormats.<WBR>Email.EmlReadNativeMetadataProperties**

```csharp
using (Metadata metadata = new Metadata(Constants.InputEml))
{
	var root = metadata.GetRootPackage<EmlRootPackage>();

	Console.WriteLine(root.EmailPackage.Sender);
	Console.WriteLine(root.EmailPackage.Subject);

	foreach (string recipient in root.EmailPackage.Recipients)
	{
		Console.WriteLine(recipient);
	}

	foreach (var attachedFileName in root.EmailPackage.AttachedFileNames)
	{
		Console.WriteLine(attachedFileName);
	}

	foreach (var header in root.EmailPackage.Headers)
	{
		Console.WriteLine("{0} = {1}", header.Name, header.Value);
	}

	// ...
}
```

## Reading MSG metadata

MSG files are usually created by the Microsoft Outlook email client. The MSG format is used to represent individual email messages, appointments, contacts, tasks, and so on in the file system. The following code snippet shows how to read most common properties of an email message stored as an MSG file.

**AdvancedUsage.ManagingMetadataForSpecificFormats.<WBR>Email.MsgReadNativeMetadataProperties**

```csharp
using (Metadata metadata = new Metadata(Constants.InputMsg))
{
	var root = metadata.GetRootPackage<MsgRootPackage>();

	Console.WriteLine(root.EmailPackage.Sender);
	Console.WriteLine(root.EmailPackage.Subject);

	foreach (string recipient in root.EmailPackage.Recipients)
	{
		Console.WriteLine(recipient);
	}

	foreach (var attachedFileName in root.EmailPackage.AttachedFileNames)
	{
		Console.WriteLine(attachedFileName);
	}

	foreach (var header in root.EmailPackage.Headers)
	{
		Console.WriteLine("{0} = {1}", header.Name, header.Value);
	}

	Console.WriteLine(root.EmailPackage.Body);
	Console.WriteLine(root.EmailPackage.DeliveryTime);

	// ...
}
```

## Removing email attachments

Both root package classes representing metadata in email messages ([EmlRootPackage](https://apireference.groupdocs.com/net/metadata/groupdocs.metadata.formats.email/emlrootpackage) and [MsgRootPackage](https://apireference.groupdocs.com/net/metadata/groupdocs.metadata.formats.email/msgrootpackage)) have the common ancestor which is the [EmailRootPackage](https://apireference.groupdocs.com/net/metadata/groupdocs.metadata.formats.email/emailrootpackage) class. Since the MSG and EML formats have really similar functionality, in most cases, you don't need to know the exact type of a loaded message. It is possible to refer to the [EmailRootPackage](https://apireference.groupdocs.com/net/metadata/groupdocs.metadata.formats.email/emailrootpackage) class to access all basic features related to email messages. The following code sample shows how to remove all email message attachments using an instance of the [EmailRootPackage](https://apireference.groupdocs.com/net/metadata/groupdocs.metadata.formats.email/emailrootpackage) class.

**AdvancedUsage.ManagingMetadataForSpecificFormats.<WBR>Email.EmailRemoveAttachments**

```csharp
using (Metadata metadata = new Metadata(Constants.InputEml))
{
	var root = metadata.GetRootPackage<EmailRootPackage>();

	root.ClearAttachments();

	metadata.Save(Constants.OutputEml);
}
```

## More resources
### GitHub examples
You may easily run the code above and see the feature in action in our GitHub examples:
*   [GroupDocs.Metadata for .NET examples](https://github.com/groupdocs-metadata/GroupDocs.Metadata-for-.NET)    
*   [GroupDocs.Metadata for Java examples](https://github.com/groupdocs-metadata/GroupDocs.Metadata-for-Java)    

### Free online document metadata management App
Along with full featured .NET library we provide simple, but powerful free Apps.
You are welcome to view and edit metadata of PDF, DOC, DOCX, PPT, PPTX, XLS, XLSX, emails, images and more with our free online [Free Online Document Metadata Viewing and Editing App](https://products.groupdocs.app/metadata).
