---
id: working-with-opentype-fonts
url: metadata/net/working-with-opentype-fonts
title: Working with OpenType fonts
weight: 6
description: ""
keywords: 
productName: GroupDocs.Metadata for .NET
hideChildren: False
---
OpenType is a format for scalable computer fonts. It was built on its predecessor TrueType, retaining TrueType's basic structure and adding many intricate data structures for prescribing typographic behavior.

{{< alert style="info" >}}Please find more information on the OpenType format here: https://en.wikipedia.org/wiki/OpenType.{{< /alert >}}

## Reading OpenType metadata

The GroupDocs.Metadata API supports extracting format-specific information from OpenType font files.

The following are the steps to read the header of an OpenType file.

1.  [Load]({{< ref "metadata/net/developer-guide/advanced-usage/loading-files/_index.md" >}}) an OpenType font file
2.  Get the root metadata package
3.  Extract  the native metadata package using [OpenTypeRootPackage.OpenTypePackage](https://apireference.groupdocs.com/net/metadata/groupdocs.metadata.formats.font/opentyperootpackage/properties/opentypepackage)
4.  Read the OpenType font properties

**AdvancedUsage.ManagingMetadataForSpecificFormats.Font.OpenTypeReadNativeMetadataProperties**

```csharp
using (Metadata metadata = new Metadata(Constants.InputTtf))
{
	var root = metadata.GetRootPackage<OpenTypeRootPackage>();
	// Read the OpenType font metadata
	foreach (var metadataEntry in root.OpenTypePackage.Fonts)
	{
		// Display the values of some metadata properties
		Console.WriteLine(metadataEntry.Created);
		Console.WriteLine(metadataEntry.DirectionHint);
		Console.WriteLine(metadataEntry.EmbeddingLicensingRights);
		Console.WriteLine(metadataEntry.Flags);
		Console.WriteLine(metadataEntry.FontFamilyName);
		Console.WriteLine(metadataEntry.FontRevision);
		Console.WriteLine(metadataEntry.FontSubfamilyName);
		Console.WriteLine(metadataEntry.FullFontName);
		Console.WriteLine(metadataEntry.GlyphBounds);
		Console.WriteLine(metadataEntry.MajorVersion);
		Console.WriteLine(metadataEntry.MinorVersion);
		Console.WriteLine(metadataEntry.Modified);
		Console.WriteLine(metadataEntry.SfntVersion);
		Console.WriteLine(metadataEntry.Style);
		Console.WriteLine(metadataEntry.TypographicFamily);
		Console.WriteLine(metadataEntry.TypographicSubfamily);
		Console.WriteLine(metadataEntry.Weight);
		Console.WriteLine(metadataEntry.Width);

		foreach (OpenTypeBaseNameRecord nameRecord in metadataEntry.Names)
		{
			Console.WriteLine(nameRecord.NameID);
			Console.WriteLine(nameRecord.Platform);
			Console.WriteLine(nameRecord.Value);

			OpenTypeMacintoshNameRecord macintoshNameRecord = nameRecord as OpenTypeMacintoshNameRecord;
			if (macintoshNameRecord != null)
			{
				Console.WriteLine(macintoshNameRecord.Encoding);
				Console.WriteLine(macintoshNameRecord.Language);
			}
			else
			{
				OpenTypeUnicodeNameRecord unicodeNameRecord = nameRecord as OpenTypeUnicodeNameRecord;
				if (unicodeNameRecord != null)
				{
					Console.WriteLine(unicodeNameRecord.Encoding);
				}
				else
				{
					OpenTypeWindowsNameRecord windowsNameRecord = nameRecord as OpenTypeWindowsNameRecord;
					if (windowsNameRecord != null)
					{
						Console.WriteLine(windowsNameRecord.Encoding);
						Console.WriteLine(windowsNameRecord.Language);
					}
				}
			}
		}
	}
}
```

## Reading digital signatures

The code snippet bellow demonstrates how to extract information about digital signatures associated with an OpenType font.

1.  [Load]({{< ref "metadata/net/developer-guide/advanced-usage/loading-files/_index.md" >}}) an OpenType font file
2.  Get the root metadata package
3.  Use the [DigitalSignaturePackage](https://apireference.groupdocs.com/net/metadata/groupdocs.metadata.formats.font/opentyperootpackage/properties/digitalsignaturepackage) property to get access to all digital signatures associated with the file

**AdvancedUsage.ManagingMetadataForSpecificFormats.Font.OpenTypeReadDigitalSignatureProperties**

```csharp
public static void Run()
{
	using (Metadata metadata = new Metadata(Constants.InputTtf))
	{
		var root = metadata.GetRootPackage<OpenTypeRootPackage>();
		if (root.DigitalSignaturePackage != null)
		{
			Console.WriteLine(root.DigitalSignaturePackage.Flags);
			foreach (var signature in root.DigitalSignaturePackage.Signatures)
			{
				Console.WriteLine(signature.SignTime);
				if (signature.DigestAlgorithms != null)
				{
					foreach (var signatureDigestAlgorithm in signature.DigestAlgorithms)
					{
						PrintOid(signatureDigestAlgorithm);
					}
				}
				if (signature.EncapsulatedContent != null)
				{
					PrintOid(signature.EncapsulatedContent.ContentType);
					Console.WriteLine(signature.EncapsulatedContent.ContentRawData.Length);
				}
				if (signature.Certificates != null)
				{
					foreach (var certificate in signature.Certificates)
					{
						Console.WriteLine(certificate.NotAfter);
						Console.WriteLine(certificate.NotBefore);
						Console.WriteLine(certificate.RawData.Length);
					}
				}
				if (signature.Signers != null)
				{
					foreach (var signerInfoEntry in signature.Signers)
					{
						Console.WriteLine(signerInfoEntry.SignatureValue);
						PrintOid(signerInfoEntry.DigestAlgorithm);
						PrintOid(signerInfoEntry.SignatureAlgorithm);
						Console.WriteLine(signerInfoEntry.SigningTime);
						PrintAttributes(signerInfoEntry.SignedAttributes);
						PrintAttributes(signerInfoEntry.UnsignedAttributes);
					}
				}
			}
		}
	}
}

private static void PrintOid(Oid oid)
{
	// Display the property name and value of OID
	if (oid != null)
	{
		Console.WriteLine(oid.FriendlyName);
		Console.WriteLine(oid.Value);
	}
}

private static void PrintAttributes(CmsAttribute[] attributes)
{
	//Display the CmsAttributes of an OID
	if (attributes != null)
	{
		foreach (CmsAttribute attribute in attributes)
		{
			PrintOid(attribute.Oid);
			Console.WriteLine(attribute.Value);
		}
	}
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