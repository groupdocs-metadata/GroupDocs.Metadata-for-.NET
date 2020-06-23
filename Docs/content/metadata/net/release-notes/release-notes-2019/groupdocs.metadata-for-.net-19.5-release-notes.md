---
id: groupdocs-metadata-for-net-19-5-release-notes
url: metadata/net/groupdocs-metadata-for-net-19-5-release-notes
title: GroupDocs.Metadata for .NET 19.5 Release Notes
weight: 3
description: ""
keywords: 
productName: GroupDocs.Metadata for .NET
hideChildren: False
---
{{< alert style="info" >}}This page contains release notes for GroupDocs.Metadata for .NET 19.5{{< /alert >}}

## Major Features

There are the following features and enhancements in this release:

*   Add support for the vCard format
*   Add support for the pps, ppsx and ppsm PowerPoint formats
*   Implement the ability to get the metered credit consumption statistic

## Full List of Issues Covering all Changes in this Release

| Key | Summary | Category |
| --- | --- | --- |
| METADATANET-1177 | Add support for the vCard format | New Feature |
| METADATANET-2833 | Add support for the pps, ppsx and ppsm PowerPoint formats | Enhancement |
| METADATANET-2918 | Implement the ability to get the metered credit consumption statistic | Enhancement |

## Public API and Backward Incompatible Changes

{{< alert style="info" >}}This section lists public API changes that were introduced in GroupDocs.Metadata for .NET 19.5. It includes not only new and obsoleted public methods, but also a description of any changes in the behavior behind the scenes in GroupDocs.Metadata which may affect existing code. Any behavior introduced that could be seen as regression and modifies existing behavior is especially important and is documented here.{{< /alert >}}

### Add support for the vCard format

**Public API Changes**

The *GroupDocs.Metadata.Formats.BusinessCard* namespace has been introduced

The *VCard* item has been added to the *DocumentType* enum

The *VCardAgentRecordMetadata* class has been added to the* GroupDocs.Metadata.Formats.BusinessCard* namespace

The *ContentType* property has been added to the *VCardAgentRecordMetadata* class

The *Value* property has been added to the *VCardAgentRecordMetadata* class

The *VCardBaseMetadata* class has been added to the *GroupDocs.Metadata.Formats.BusinessCard* namespace

The *VCardBinaryRecordMetadata* class has been added to the *GroupDocs.Metadata.Formats.BusinessCard* namespace

The *ContentType* property has been added to the *VCardBinaryRecordMetadata* class

The *Value* property has been added to the *VCardBinaryRecordMetadata* class

The *VCardCalendarRecordsetMetadata* class has been added to the* GroupDocs.Metadata.Formats.BusinessCard* namespace

The *BusyTimeRecords* property has been added to the *VCardCalendarRecordsetMetadata* class

The *BusyTimeEntries* property has been added to the *VCardCalendarRecordsetMetadata* class

The *CalendarAddressRecords* property has been added to the *VCardCalendarRecordsetMetadata* class

The *CalendarAddresses* property has been added to the *VCardCalendarRecordsetMetadata* class

The *CalendarUriRecords* property has been added to the *VCardCalendarRecordsetMetadata* class

The *UriCalendarEntries* property has been added to the *VCardCalendarRecordsetMetadata* class

The *VCardCommunicationRecordsetMetadata* class has been added to the *GroupDocs.Metadata.Formats.BusinessCard* namespace

The *TelephoneRecords* property has been added to the *VCardCommunicationRecordsetMetadata* class

The *Telephones* property has been added to the *VCardCommunicationRecordsetMetadata* class

The *EmailRecords* property has been added to the *VCardCommunicationRecordsetMetadata* class

The *Emails* property has been added to the *VCardCommunicationRecordsetMetadata* class

The *Mailer* property has been added to the *VCardCommunicationRecordsetMetadata* class

The *ImppRecords* property has been added to the *VCardCommunicationRecordsetMetadata* class

The *ImppEntries* property has been added to the *VCardCommunicationRecordsetMetadata* class

The *LanguageRecords* property has been added to the *VCardCommunicationRecordsetMetadata* class

The *Languages* property has been added to the *VCardCommunicationRecordsetMetadata* class

The *VCardContentType* enum has been added to the *GroupDocs.Metadata.Formats.BusinessCard* namespace

The *Custom* item has been added to the *VCardContentType* enum

The *Text* item has been added to the *VCardContentType* enum

The *Binary* item has been added to the *VCardContentType* enum

The *DateTime* item has been added to the *VCardContentType* enum

The *Agent* item has been added to the *VCardContentType* enum

The *VCardCustomRecordMetadata* class has been added to the *GroupDocs.Metadata.Formats.BusinessCard* namespace

The *ContentType* property has been added to the *VCardCustomRecordMetadata* class

The *Value* property has been added to the *VCardCustomRecordMetadata* class

The *VCardDateTimeRecordMetadata* class has been added to the *GroupDocs.Metadata.Formats.BusinessCard* namespace

The *ContentType* property has been added to the *VCardDateTimeRecordMetadata* class

The *Value* property has been added to the *VCardDateTimeRecordMetadata* class

The *VCardDeliveryAddressingRecordsetMetadata* class has been added to the *GroupDocs.Metadata.Formats.BusinessCard* namespace

The *AddressRecords* property has been added to the *VCardDeliveryAddressingRecordsetMetadata* class

The *Addresses* property has been added to the *VCardDeliveryAddressingRecordsetMetadata* class

The *LabelRecords* property has been added to the *VCardDeliveryAddressingRecordsetMetadata* class

The *Labels* property has been added to the *VCardDeliveryAddressingRecordsetMetadata* class

The *VCardExplanatoryRecordsetMetadata* class has been added to the *GroupDocs.Metadata.Formats.BusinessCard* namespace

The *CategoryRecords* property has been added to the *VCardExplanatoryRecordsetMetadata* class

The *Categories* property has been added to the *VCardExplanatoryRecordsetMetadata* class

The *NoteRecords* property has been added to the *VCardExplanatoryRecordsetMetadata* class

The *Notes* property has been added to the *VCardExplanatoryRecordsetMetadata* class

The *ProductIdentifierRecord* property has been added to the *VCardExplanatoryRecordsetMetadata* class

The *ProductIdentifier* property has been added to the *VCardExplanatoryRecordsetMetadata* class

The *Revision* property has been added to the *VCardExplanatoryRecordsetMetadata* class

The *SortString* property has been added to the *VCardExplanatoryRecordsetMetadata* class

The *SoundRecords* property has been added to the *VCardExplanatoryRecordsetMetadata* class

The *SoundBinaryRecords* property has been added to the *VCardExplanatoryRecordsetMetadata* class

The *BinarySounds* property has been added to the *VCardExplanatoryRecordsetMetadata* class

The *SoundUriRecords* property has been added to the *VCardExplanatoryRecordsetMetadata* class

The *UriSounds* property has been added to the *VCardExplanatoryRecordsetMetadata* class

The *UidRecord* property has been added to the *VCardExplanatoryRecordsetMetadata* class

The *Uid* property has been added to the *VCardExplanatoryRecordsetMetadata* class

The *PidIdentifierRecords* property has been added to the *VCardExplanatoryRecordsetMetadata* class

The *PidIdentifiers* property has been added to the *VCardExplanatoryRecordsetMetadata* class

The *UrlRecords* property has been added to the *VCardExplanatoryRecordsetMetadata* class

The *Urls* property has been added to the *VCardExplanatoryRecordsetMetadata* class

The *Version* property has been added to the *VCardExplanatoryRecordsetMetadata* class

The *VCardFormat* class has been added to the *GroupDocs.Metadata.Formats.BusinessCard* namespace

The *VCardFormat(String)* constructor has been added to the *VCardFormat* class

The *VCardFormat(Stream)* constructor has been added to the *VCardFormat* class

The *VCardInfo* property has been added to the *VCardFormat* class

The *VCardGeneralRecordsetMetadata* class has been added to the *GroupDocs.Metadata.Formats.BusinessCard* namespace

The *SourceRecords* property has been added to the *VCardGeneralRecordsetMetadata* class

The *Sources* property has been added to the *VCardGeneralRecordsetMetadata* class

The *NameOfSource* property has been added to the *VCardGeneralRecordsetMetadata* class

The *Kind* property has been added to the *VCardGeneralRecordsetMetadata* class

The *XmlRecords* property has been added to the *VCardGeneralRecordsetMetadata* class

The *XmlEntries* property has been added to the *VCardGeneralRecordsetMetadata* class

The *VCardGeographicalRecordsetMetadata* class has been added to the *GroupDocs.Metadata.Formats.BusinessCard* namespace

The *TimeZoneRecords* property has been added to the *VCardGeographicalRecordsetMetadata* class

The *TimeZones* property has been added to the *VCardGeographicalRecordsetMetadata* class

The *GeographicPositionRecords* property has been added to the *VCardGeographicalRecordsetMetadata* class

The *GeographicPositions* property has been added to the *VCardGeographicalRecordsetMetadata* class

The *VCardIdentificationRecordsetMetadata* class has been added to the *GroupDocs.Metadata.Formats.BusinessCard* namespace

The *FormattedNameRecords* property has been added to the *VCardIdentificationRecordsetMetadata* class

The *FormattedNames* property has been added to the *VCardIdentificationRecordsetMetadata* class

The *NameRecord* property has been added to the *VCardIdentificationRecordsetMetadata* class

The *Name* property has been added to the *VCardIdentificationRecordsetMetadata* class

The *NicknameRecords* property has been added to the *VCardIdentificationRecordsetMetadata* class

The *Nicknames* property has been added to the *VCardIdentificationRecordsetMetadata* class

The *PhotoRecords* property has been added to the *VCardIdentificationRecordsetMetadata* class

The *PhotoBinaryRecords* property has been added to the *VCardIdentificationRecordsetMetadata* class

The *BinaryPhotos* property has been added to the *VCardIdentificationRecordsetMetadata* class

The *PhotoUriRecords* property has been added to the *VCardIdentificationRecordsetMetadata* class

The *UriPhotos* property has been added to the *VCardIdentificationRecordsetMetadata* class

The *BirthdateRecords* property has been added to the *VCardIdentificationRecordsetMetadata* class

The *BirthdateDateTimeRecord* property has been added to the *VCardIdentificationRecordsetMetadata* class

The *DateTimeBirthdate* property has been added to the *VCardIdentificationRecordsetMetadata* class

The *BirthdateTextRecords* property has been added to the *VCardIdentificationRecordsetMetadata* class

The *TextBirthdates* property has been added to the *VCardIdentificationRecordsetMetadata* class

The *AnniversaryRecord* property has been added to the *VCardIdentificationRecordsetMetadata* class

The *AnniversaryDateTimeRecord* property has been added to the *VCardIdentificationRecordsetMetadata* class

The *DateTimeAnniversary* property has been added to the *VCardIdentificationRecordsetMetadata* class

The *AnniversaryTextRecord* property has been added to the *VCardIdentificationRecordsetMetadata* class

The *TextAnniversary* property has been added to the *VCardIdentificationRecordsetMetadata* class

The *GenderRecord* property has been added to the *VCardIdentificationRecordsetMetadata* class

The *Gender* property has been added to the *VCardIdentificationRecordsetMetadata* class

The *VCardMetadata* class has been added to the *GroupDocs.Metadata.Formats.BusinessCard* namespace

The *GeneralRecordset* property has been added to the *VCardMetadata* class

The *IdentificationRecordset* property has been added to the *VCardMetadata* class

The *DeliveryAddressingRecordset* property has been added to the *VCardMetadata* class

The *CommunicationRecordset* property has been added to the *VCardMetadata* class

The *GeographicalRecordset* property has been added to the *VCardMetadata* class

The *OrganizationalRecordset* property has been added to the *VCardMetadata* class

The *ExplanatoryRecordset* property has been added to the *VCardMetadata* class

The *SecurityRecordset* property has been added to the *VCardMetadata* class

The *CalendarRecordset* property has been added to the *VCardMetadata* class

The *ExtensionRecords* property has been added to the *VCardMetadata* class

The *GetAvailableGroups* method has been added to the *VCardMetadata* class

The *FilterByGroup(String)* method has been added to the *VCardMetadata* class

The *FilterHomeTags* method has been added to the *VCardMetadata* class

The *FilterWorkTags* method has been added to the *VCardMetadata* class

The *FilterPreferred* method has been added to the *VCardMetadata* class

The *VCardOrganizationalRecordsetMetadata* class has been added to the *GroupDocs.Metadata.Formats.BusinessCard* namespace

The *TitleRecords* property has been added to the *VCardOrganizationalRecordsetMetadata* class

The *Titles* property has been added to the *VCardOrganizationalRecordsetMetadata* class

The *RoleRecords* property has been added to the *VCardOrganizationalRecordsetMetadata* class

The *Roles* property has been added to the *VCardOrganizationalRecordsetMetadata* class

The *LogoRecords* property has been added to the *VCardOrganizationalRecordsetMetadata* class

The *LogoBinaryRecords* property has been added to the *VCardOrganizationalRecordsetMetadata* class

The *BinaryLogos* property has been added to the *VCardOrganizationalRecordsetMetadata* class

The *LogoUriRecords* property has been added to the *VCardOrganizationalRecordsetMetadata* class

The *UriLogos* property has been added to the *VCardOrganizationalRecordsetMetadata* class

The *AgentRecords* property has been added to the *VCardOrganizationalRecordsetMetadata* class

The *AgentObjectRecord* property has been added to the *VCardOrganizationalRecordsetMetadata* class

The *ObjectAgent* property has been added to the *VCardOrganizationalRecordsetMetadata* class

The *AgentUriRecords* property has been added to the *VCardOrganizationalRecordsetMetadata* class

The *UriAgents* property has been added to the *VCardOrganizationalRecordsetMetadata* class

The *OrganizationNameRecords* property has been added to the *VCardOrganizationalRecordsetMetadata* class

The *OrganizationNames* property has been added to the *VCardOrganizationalRecordsetMetadata* class

The *MemberRecords* property has been added to the *VCardOrganizationalRecordsetMetadata* class

The *Members* property has been added to the *VCardOrganizationalRecordsetMetadata* class

The *RelationshipRecords* property has been added to the *VCardOrganizationalRecordsetMetadata* class

The *Relationships* property has been added to the *VCardOrganizationalRecordsetMetadata* class

The *VCardRecordMetadata* class has been added to the *GroupDocs.Metadata.Formats.BusinessCard* namespace

The *Group* property has been added to the *VCardRecordMetadata* class

The *ValueParameters* property has been added to the *VCardRecordMetadata* class

The *PrefParameter* property has been added to the *VCardRecordMetadata* class

The *AltIdParameter* property has been added to the *VCardRecordMetadata* class

The *TypeParameters* property has been added to the *VCardRecordMetadata* class

The *EncodingParameter* property has been added to the *VCardRecordMetadata* class

The *LanguageParameter* property has been added to the *VCardRecordMetadata* class

The *AnonymParameters* property has been added to the *VCardRecordMetadata* class

The *ContentType* property has been added to the *VCardRecordMetadata* class

The *VCardRecordsetMetadata* class has been added to the *GroupDocs.Metadata.Formats.BusinessCard* namespace

The *VCardSecurityRecordsetMetadata* class has been added to the *GroupDocs.Metadata.Formats.BusinessCard* namespace

The *AccessClassification* property has been added to the *VCardSecurityRecordsetMetadata* class

The *PublicKeyRecords* property has been added to the *VCardSecurityRecordsetMetadata* class

The *PublicKeyBinaryRecords* property has been added to the *VCardSecurityRecordsetMetadata* class

The *BinaryPublicKeys* property has been added to the *VCardSecurityRecordsetMetadata* class

The *PublicKeyUriRecords* property has been added to the *VCardSecurityRecordsetMetadata* class

The *UriPublicKeys* property has been added to the *VCardSecurityRecordsetMetadata* class

The *VCardTextRecordMetadata* class has been added to the *GroupDocs.Metadata.Formats.BusinessCard* namespace

The *ContentType* property has been added to the *VCardTextRecordMetadata* class

The *MediaTypeParameter* property has been added to the *VCardTextRecordMetadata* class

The *CharsetParameter* property has been added to the *VCardTextRecordMetadata* class

The *Value* property has been added to the *VCardTextRecordMetadata* class

The *IsQuotedPrintable* property has been added to the *VCardTextRecordMetadata* class

The *GetReadabilityValue(String)* method has been added to the *VCardTextRecordMetadata* class

The *VCard* item has been added to the *MetadataType* enum

##### Use cases

Read vCard properties using simplified APIs



```csharp
static void Main(string[] args)
{
	License l = new License();
	l.SetLicense(@"D:\GroupDocs.Metadata.lic");

	using (VCardFormat format = new VCardFormat(@"D:\input.vcf"))
	{
		foreach (VCardMetadata vCard in format.VCardInfo)
		{
			Console.WriteLine(vCard.IdentificationRecordset.Name);
			PrintArray(vCard.IdentificationRecordset.FormattedNames);
			PrintArray(vCard.CommunicationRecordset.Emails);
			PrintArray(vCard.CommunicationRecordset.Telephones);
		}
	}

	Console.ReadKey();
}

private static void PrintArray(string[] values)
{
	if (values != null)
	{
		foreach (string value in values)
		{
			Console.WriteLine(value);
		}
	}
}
```

Read vCard properties along with descriptive parameters



```csharp
using (VCardFormat format = new VCardFormat(@"D:\input.vcf"))
{
	foreach (VCardMetadata vCard in format.VCardInfo)
	{
		if (vCard.IdentificationRecordset.PhotoUriRecords != null)
		{
			// Iterate all photos represented by URIs
			foreach (VCardTextRecordMetadata photoUriRecord in vCard.IdentificationRecordset.PhotoUriRecords)
			{
				// Print the property value
				Console.WriteLine(photoUriRecord.Value);

				// Print some additional parameters of the property
				Console.WriteLine(photoUriRecord.ContentType);
				Console.WriteLine(photoUriRecord.MediaTypeParameter);
				if (photoUriRecord.TypeParameters != null)
				{
					foreach (string parameter in photoUriRecord.TypeParameters)
					{
						Console.WriteLine(parameter);
					}
				}
				Console.WriteLine(photoUriRecord.PrefParameter);
			}
		}
	}
}
```

Filter vCard properties



```csharp
static void Main(string[] args)
{
	License l = new License();
	l.SetLicense(@"D:\GroupDocs.Metadata.lic");

	using (VCardFormat format = new VCardFormat(@"D:\input.vcf"))
	{
		foreach (VCardMetadata vCard in format.VCardInfo)
		{
			// Print most preferred work phone numbers and work emails
			VCardMetadata filtered = vCard.FilterWorkTags().FilterPreferred();
			PrintArray(filtered.CommunicationRecordset.Telephones);
			PrintArray(filtered.CommunicationRecordset.Emails);
		}
	}

	Console.ReadKey();
}
 
private static void PrintArray(string[] values)
{
	if (values != null)
	{
		foreach (string value in values)
		{
			Console.WriteLine(value);
		}
	}
}
```

### Add support for the pps, ppsx and ppsm PowerPoint formats

This enhancement allows a user to work with pps, ppsx and ppsm files

**Public API Changes**

The *Pps* item has been added to the *FileType* enum

The *Ppsx* item has been added to the *FileType* enum

The *Ppsm* item has been added to the *FileType* enum

##### Use cases

Read or write pps, ppsx and ppsm files using the *PptFormat* class



```csharp
using (PptFormat format = new PptFormat(@"D:\input.pps"))
{
	// Read the file type
	Console.WriteLine(format.FileType);
	
	// Work with the loaded file as you normally do with all other presentations

	// Save all changes
	format.Save(@"D:\output.pps");
}
```

### Implement the ability to get the metered credit consumption statistic

This enhancement allows a user to check metered credit consumption

##### Public API changes

The *GetConsumptionCredit* method has been added to the *Metered* class

##### Use cases

Check the amount of spent credits



```csharp
// Apply your metered license
Metered metered = new Metered();
metered.SetMeteredKey("PublicKey", "PrivateKey");

// Load a file
using (FormatBase format = FormatFactory.RecognizeFormat(@"D:\input.doc"))
{
	// Use library features
	var metadata = format.GetMetadata();

	// Check credit consumption
	var credits = Metered.GetConsumptionCredit();

	// ...
}
```
