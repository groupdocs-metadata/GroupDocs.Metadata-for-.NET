---
id: groupdocs-metadata-for-net-19-11-release-notes
url: metadata/net/groupdocs-metadata-for-net-19-11-release-notes
title: GroupDocs.Metadata for .NET 19.11 Release Notes
weight: 1
description: ""
keywords: 
productName: GroupDocs.Metadata for .NET
hideChildren: False
---
{{< alert style="info" >}}This page contains release notes for GroupDocs.Metadata for .NET 19.11{{< /alert >}}

## Major Features

{{< alert style="danger" >}}In this version we're introducing a new public API which was designed to be simple and easy to use. For more details about the new API please check the Public Docs section. The legacy API have been moved to the Legacy namespace so after update to this version it is required to make project-wide replacement of namespace usages from GroupDocs.Metadata. to GroupDocs.Metadata.Legacy to resolve build issues.{{< /alert >}}

## Full List of Issues Covering all Changes in this Release

| Key | Summary | Category |
| --- | --- | --- |
| METADATANET-3000 | New Public API | Feature |

## Public API and Backward Incompatible Changes

### All public types from the GroupDocs.Metadata namespace are moved and marked as obsolete

#### All public types from the GroupDocs.Metadata namespace 

1.  Have been moved to the **GroupDocs.Metadata.Legacy** namespace
2.  Marked as **Obsolete** with the following message: *This class/interface/enum is obsolete and will be removed in future releases.*

###### div.rbtoc1591864333428 { padding-top: 0px; padding-right: 0px; padding-bottom: 0px; padding-left: 0px; }div.rbtoc1591864333428 ul { list-style-type: disc; list-style-image: none; margin-left: 0px; }div.rbtoc1591864333428 li { margin-left: 0px; padding-left: 0px; }

###### GroupDocs.Metadata

New namespace: **GroupDocs.Metadata.Legacy**

Types:

*   DigitalSignature
*   DimensionInfo
*   DocumentInfo
*   DocumentMetadata<T>
*   DocumentMetadataKey
*   DublinCoreMetadata
*   ExifMetadataKey
*   IptcMetadataKey
*   License
*   LoadOptions
*   Metadata
*   MetadataContainer
*   MetadataKey
*   MetadataKey.Doc
*   MetadataKey.DocumentInfo
*   MetadataKey.EXIF
*   MetadataKey.Id3v1
*   MetadataKey.Id3v2
*   MetadataKey.IPTC
*   MetadataKey.IPTC.ApplicationRecord
*   MetadataKey.IPTC.EnvelopeRecord
*   MetadataKey.PDF
*   MetadataKey.Ppt
*   MetadataKey.Xls
*   MetadataKey.XMP
*   MetadataKey.XMP.BaseSchema
*   MetadataKey.XMP.DublinCore
*   MetadataProperty
*   MetadataPropertyCollection
*   Metered
*   MIMEType
*   PageInfo
*   PropertyValue
*   ThumbnailMetadata
*   XmpMetadataKey
*   Rectangle
*   IBarCodeDetector
*   IDocumentFormat
*   IDublinCore
*   IExif
*   IImageResourceBlocks
*   IInspectable<R, O>
*   IIptc
*   IMetadataProperty
*   IProtectableFormat
*   ISignedFormat
*   IXmp
*   ByteOrder
*   DocumentType
*   FileType
*   MetadataPropertyType
*   MetadataType

###### GroupDocs.Metadata.Exceptions

New namespace: **GroupDocs.Metadata.Legacy.Exceptions**

Types:

*   DocumentProtectedException
*   GroupDocsMetadataException
*   InvalidFormatException
*   MetadataValidationException
*   XmpContainerException
*   XmpException

###### GroupDocs.Metadata.Formats

New namespace: **GroupDocs.Metadata.Legacy.Formats**

Types:

*   FormatBase
*   RiffFormat

###### GroupDocs.Metadata.Formats.Archive

New namespace: **GroupDocs.Metadata.Legacy.Formats.Archive**

Types:

*   ZipFileInfo
*   ZipFormat
*   ZipMetadata
*   ZipCompressionMethod

###### GroupDocs.Metadata.Formats.Audio

New namespace: **GroupDocs.Metadata.Legacy.Formats.Audio**

Types:

*   Apev2Metadata
*   AttachedPictureFrame
*   CommentsFrame
*   Id3Tag
*   Id3v1Tag
*   Id3v2Tag
*   Lyrics3Field
*   Lyrics3Tag
*   MLLTFrame
*   Mp3Format
*   MpegAudio
*   PrivateFrame
*   TagFrame
*   TagFrameFlags
*   TextFrame
*   UrlLinkFrame
*   UserDefinedFrame
*   UserDefinedUrlLinkFrame
*   WavAudioInfo
*   WavFormat
*   MpegChannelMode

###### GroupDocs.Metadata.Formats.BusinessCard

New namespace: **GroupDocs.Metadata.Legacy.Formats.BusinessCard**

Types:

*   VCardAgentRecordMetadata
*   VCardBaseMetadata
*   VCardBinaryRecordMetadata
*   VCardCalendarRecordsetMetadata
*   VCardCommunicationRecordsetMetadata
*   VCardCustomRecordMetadata
*   VCardDateTimeRecordMetadata
*   VCardDeliveryAddressingRecordsetMetadata
*   VCardExplanatoryRecordsetMetadata
*   VCardFormat
*   VCardGeneralRecordsetMetadata
*   VCardGeographicalRecordsetMetadata
*   VCardIdentificationRecordsetMetadata
*   VCardMetadata
*   VCardOrganizationalRecordsetMetadata
*   VCardRecordMetadata
*   VCardRecordsetMetadata
*   VCardSecurityRecordsetMetadata
*   VCardTextRecordMetadata
*   VCardContentType

###### GroupDocs.Metadata.Formats.Cad

New namespace: **GroupDocs.Metadata.Legacy.Formats.Cad**

Types:

*   CadMetadata
*   DwgFormat
*   DxfFormat

###### GroupDocs.Metadata.Formats.Cryptography

New namespace: **GroupDocs.Metadata.Legacy.Formats.Cryptography**

Types:

*   Cms
*   CmsAttribute
*   CmsCertificate
*   CmsEncapsulatedContentInfo
*   CmsSignerInfo
*   Oid

###### GroupDocs.Metadata.Formats.Document

New namespace: **GroupDocs.Metadata.Legacy.Formats.Document**

Types:

*   DocComment
*   DocField
*   DocFormat
*   DocInspectionOptions
*   DocInspectionResult
*   DocMetadata
*   DocMetadataProperty
*   DocumentFormat<T, TK, TDi>
*   OneNoteFormat
*   OneNoteMetadata
*   OneNotePageInfo
*   PdfAnnotation
*   PdfAttachment
*   PdfBookmark
*   PdfFormat
*   PdfFormField
*   PdfInspectionOptions
*   PdfInspectionResult
*   PdfMetadata
*   PdfMetadataProperty
*   PptComment
*   PptFormat
*   PptInspectionOptions
*   PptInspectionResult
*   PptMetadata
*   PptMetadataProperty
*   PptSlide
*   Revision
*   RevisionCollection
*   VisioFormat
*   VisioMetadata
*   VisioMetadataProperty
*   XlsComment
*   XlsContentProperty
*   XlsFormat
*   XlsInspectionOptions
*   XlsInspectionResult
*   XlsMetadata
*   XlsMetadataProperty
*   XlsSheet
*   DocInspectorOptionsEnum
*   PdfInspectorOptionsEnum
*   PptInspectorOptionsEnum
*   RevisionType
*   XlsInspectorOptionsEnum

###### GroupDocs.Metadata.Formats.Ebook

New namespace: **GroupDocs.Metadata.Legacy.Formats.Ebook**

Types:

*   EpubFormat
*   EpubMetadata

###### GroupDocs.Metadata.Formats.Email

New namespace: **GroupDocs.Metadata.Legacy.Formats.Email**

Types:

*   EmlFormat
*   EmlMetadata
*   OutlookMessage
*   OutlookMessageMetadata

###### GroupDocs.Metadata.Formats.Font

New namespace: **GroupDocs.Metadata.Legacy.Formats.Font**

Types:

*   OpenTypeBaseNameRecord
*   OpenTypeFormat
*   OpenTypeMacintoshNameRecord
*   OpenTypeMetadata
*   OpenTypeUnicodeNameRecord
*   OpenTypeWindowsNameRecord
*   OpenTypeDigitalSignatureFlags
*   OpenTypeDirectionHint
*   OpenTypeFlags
*   OpenTypeIsoEncoding
*   OpenTypeLicensingRights
*   OpenTypeMacintoshEncoding
*   OpenTypeMacintoshLanguage
*   OpenTypeName
*   OpenTypePlatform
*   OpenTypeStyle
*   OpenTypeUnicodeEncoding
*   OpenTypeVersion
*   OpenTypeWeight
*   OpenTypeWidth
*   OpenTypeWindowsEncoding
*   OpenTypeWindowsLanguage

###### GroupDocs.Metadata.Formats.Image

New namespace: **GroupDocs.Metadata.Legacy.Formats.Image**

Types:

*   BmpFormat
*   BmpHeader
*   CanonCameraSettings
*   CanonMakerNotes
*   DICOMFormat
*   DicomMetadata
*   DjvuFormat
*   EmfFormat
*   ExifDictionaryBase
*   ExifIfdInfo
*   ExifInfo
*   ExifMetadata
*   GifFormat
*   GpsInfo
*   GpsLocation
*   ImageFormat
*   ImageResourceBlock
*   ImageResourceMetadata
*   IptcApplicationRecord
*   IptcCollection
*   IptcDataSet
*   IptcDataSetCollection
*   IptcEnvelopeRecord
*   IptcMetadata
*   IptcProperty
*   Jp2Format
*   JpegFormat
*   MakerNotesBase
*   NikonMakerNotes
*   PanasonicMakerNotes
*   PngFormat
*   PsdFormat
*   PsdLayer
*   PsdMetadata
*   Rational
*   SonyMakerNotes
*   SRational
*   TiffArrayTagT
*   TiffAsciiTag
*   TiffByteTag
*   TiffDoubleTag
*   TiffFloatTag
*   TiffFormat
*   TiffIfd
*   TiffLongTag
*   TiffRationalTag
*   TiffSByteTag
*   TiffShortTag
*   TiffSLongTag
*   TiffSRationalTag
*   TiffSShortTag
*   TiffTag
*   TiffUndefinedTag
*   WebPFormat
*   WmfFormat
*   ApplicationRecordKeywords
*   EnvelopeRecordKeywords
*   ExifGPSAltitudeRef
*   ImageResourceIds
*   IptcDataSetType
*   IptcPropertyType
*   TiffTagIdEnum
*   TiffTagType

###### GroupDocs.Metadata.Formats.Project

New namespace: **GroupDocs.Metadata.Legacy.Formats.Project**

Types:

*   MppFormat
*   MppMetadata

###### GroupDocs.Metadata.Formats.Torrent

New namespace: **GroupDocs.Metadata.Legacy.Formats.Torrent**

Types:

*   TorrentFileInfo
*   TorrentFormat
*   TorrentMetadata

###### GroupDocs.Metadata.Formats.Video

New namespace: **GroupDocs.Metadata.Legacy.Formats.Video**

Types:

*   AsfAudioStreamProperty
*   AsfBaseDescriptor
*   AsfBaseStreamProperty
*   AsfCodecInfo
*   AsfContentDescriptor
*   AsfFormat
*   AsfMetadata
*   AsfMetadataDescriptor
*   AsfMetadataDescriptorCollection
*   AsfVideoStreamProperty
*   AviFormat
*   AviHeader
*   FlvFormat
*   FlvHeader
*   MatroskaAudioTrackMetadata
*   MatroskaBaseMetadata
*   MatroskaEbmlHeaderMetadata
*   MatroskaFormat
*   MatroskaSegmentInfoMetadata
*   MatroskaSimpleTagMetadata
*   MatroskaSubtitle
*   MatroskaSubtitleTrackMetadata
*   MatroskaTagMetadata
*   MatroskaTrackMetadata
*   MatroskaVideoTrackMetadata
*   MovFormat
*   QuickTimeAtom
*   QuickTimeMetadata
*   AsfCodecType
*   AsfDescriptorType
*   AsfExtendedStreamPropertiesFlags
*   AsfFilePropertiesFlag
*   AsfStreamType
*   AviHeaderFlags
*   MatroskaContentType
*   MatroskaTargetTypeValue
*   MatroskaTrackType
*   MatroskaVideoDisplayUnit
*   MatroskaVideoFieldOrder
*   MatroskaVideoFlagInterlaced
*   MatroskaVideoStereoMode

###### GroupDocs.Metadata.Preview

New namespace: **GroupDocs.Metadata.Legacy.Preview**

Types:

*   PreviewFactory
*   PreviewHandler
*   PreviewImageData
*   PreviewInvalidPasswordException
*   PreviewNotSupportedException
*   PreviewPage
*   ProtectableDocumentPreviewHandler
*   PreviewUnitOfMeasurement

###### GroupDocs.Metadata.Preview.Formats

New namespace: **GroupDocs.Metadata.Legacy.Preview.Formats**

Types:

*   CellsPreviewHandler
*   DiagramPreviewHandler
*   DjvuImagePreviewHandler
*   GifImagePreviewHandler
*   ImagePreviewHandler
*   NotesPreviewHandler
*   PdfPreviewHandler
*   SlidesPreviewHandler
*   TiffImagePreviewHandler
*   WordsPreviewHandler

###### GroupDocs.Metadata.Tools

New namespace: **GroupDocs.Metadata.Legacy.Tools**

Types:

*   ComparisonFacade
*   ExportBuilder
*   ExportFacade
*   FileFormatChecker
*   FormatFactory
*   MetadataUtility
*   SearchFacade
*   IExportBuilder
*   IInspectionOptions
*   IInspectorResult
*   IReplaceHandlerT
*   ComparerSearchType
*   ExportFormat
*   SearchCondition

###### GroupDocs.Metadata.Xmp

New namespace: **GroupDocs.Metadata.Legacy.Xmp**

Types:

*   ClosedChoiceT
*   ColorantBase
*   ColorantCMYK
*   ColorantLAB
*   ColorantRGB
*   Dimensions
*   Font
*   Job
*   LangAlt
*   Namespaces
*   RenditionClass
*   ResourceEvent
*   ResourceRef
*   StringChoice
*   Thumbnail
*   Version
*   XmpAgentName
*   XmpArray
*   XmpArrayBaseT
*   XmpBoolean
*   XmpComplexType
*   XmpDate
*   XmpEditableCollection
*   XmpElementBase
*   XmpGuid
*   XmpHeaderPI
*   XmpInteger
*   XmpLocale
*   XmpMeta
*   XmpMetadata
*   XmpMetadataProperty
*   XmpMIMEType
*   XmpNodeView
*   XmpPackage
*   XmpPackageBaseCollection
*   XmpPacketWrapper
*   XmpProperties
*   XmpRational
*   XmpRdfRoot
*   XmpReal
*   XmpSchemes
*   XmpText
*   XmpTrailerPI
*   XmpTypeBase
*   XmpValueBase
*   IXmlValue
*   IXmpType
*   ColorantColorMode
*   ColorType
*   XmpArrayType
*   XmpNodeViewType

###### GroupDocs.Metadata.Xmp.Schemes

New namespace: **GroupDocs.Metadata.Legacy.Xmp.Schemes**

Types:

*   AudioChannelType
*   AudioSampleType
*   BasicJobTicketPackage
*   CameraRawPackage
*   DublinCorePackage
*   IptcCorePackage
*   IptcExtensionPackage
*   IptcIIMPackage
*   PagedTextPackage
*   PdfPackage
*   PhotoshopPackage
*   Time
*   Timecode
*   TimeFormat
*   WhiteBalance
*   XmpBasicPackage
*   XmpDynamicMediaPackage
*   XmpMediaManagementPackage
*   XmpRightsManagementPackage
*   CropUnits
*   PhotoshopColorMode
*   ProjectType
