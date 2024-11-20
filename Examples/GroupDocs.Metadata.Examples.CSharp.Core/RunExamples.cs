// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2024 GroupDocs. All Rights Reserved.
// </copyright>


using GroupDocs.Metadata.Examples.CSharp.AdvancedUsage.ManagingMetadataForSpecificFormats.Gis;

namespace GroupDocs.Metadata.Examples.CSharp
{
    using BasicUsage;
    using QuickStart;
    using System;
    using AdvancedUsage;
    using AdvancedUsage.ExtractingPropertyValues;
    using AdvancedUsage.LoadingFiles;
    using AdvancedUsage.ManagingMetadataForSpecificFormats.Audio.MP3;
    using AdvancedUsage.ManagingMetadataForSpecificFormats.Audio.Wav;
    using AdvancedUsage.ManagingMetadataForSpecificFormats.Document.Diagram;
    using AdvancedUsage.ManagingMetadataForSpecificFormats.Document.Note;
    using AdvancedUsage.ManagingMetadataForSpecificFormats.Document.Pdf;
    using AdvancedUsage.ManagingMetadataForSpecificFormats.Document.Presentation;
    using AdvancedUsage.ManagingMetadataForSpecificFormats.Document.ProjectManagement;
    using AdvancedUsage.ManagingMetadataForSpecificFormats.Document.Spreadsheet;
    using AdvancedUsage.ManagingMetadataForSpecificFormats.Document.WordProcessing;
    using AdvancedUsage.ManagingMetadataForSpecificFormats.Image;
    using AdvancedUsage.ManagingMetadataForSpecificFormats.Image.Bmp;
    using AdvancedUsage.ManagingMetadataForSpecificFormats.Image.Dicom;
    using AdvancedUsage.ManagingMetadataForSpecificFormats.Image.Gif;
    using AdvancedUsage.ManagingMetadataForSpecificFormats.Image.Jpeg;
    using AdvancedUsage.ManagingMetadataForSpecificFormats.Image.Jpeg2000;
    using AdvancedUsage.ManagingMetadataForSpecificFormats.Image.Psd;
    using AdvancedUsage.ManagingMetadataForSpecificFormats.Archive;
    using AdvancedUsage.ManagingMetadataForSpecificFormats.BusinessCard;
    using AdvancedUsage.ManagingMetadataForSpecificFormats.Cad;
    using AdvancedUsage.ManagingMetadataForSpecificFormats.Ebook;
    using AdvancedUsage.ManagingMetadataForSpecificFormats.Email;
    using AdvancedUsage.ManagingMetadataForSpecificFormats.Font;
    using AdvancedUsage.ManagingMetadataForSpecificFormats.Image.Jpeg.MakerNote;
    using AdvancedUsage.ManagingMetadataForSpecificFormats.Image.Png;
    using AdvancedUsage.ManagingMetadataForSpecificFormats.Image.Tiff;
    using AdvancedUsage.ManagingMetadataForSpecificFormats.Peer2Peer;
    using AdvancedUsage.ManagingMetadataForSpecificFormats.Video.Asf;
    using AdvancedUsage.ManagingMetadataForSpecificFormats.Video.Avi;
    using AdvancedUsage.ManagingMetadataForSpecificFormats.Video.Flv;
    using AdvancedUsage.ManagingMetadataForSpecificFormats.Video.Matroska;
    using AdvancedUsage.ManagingMetadataForSpecificFormats.Video.Mov;
    using AdvancedUsage.SavingFiles;
    using AdvancedUsage.WorkingWithMetadataStandards.Exif;
    using AdvancedUsage.WorkingWithMetadataStandards.Iptc;
    using AdvancedUsage.WorkingWithMetadataStandards.Xmp;
    using Migration.ComparingMetadataProperties;
    using Migration.ExportingMetadataProperties;
    using Migration.ExtractingSpecificMetadataPackages;
    using Migration.UsingCustomReplaceHandler;
    using Migration.WorkingWithRegularExpressions;
    using GroupDocs.Metadata.Examples.CSharp.AdvancedUsage.ManagingMetadataForSpecificFormats.Image.Dng;
    using GroupDocs.Metadata.Examples.CSharp.AdvancedUsage.ManagingMetadataForSpecificFormats.Image.Raw;
    using GroupDocs.Metadata.Examples.CSharp.AdvancedUsage.ManagingMetadataForSpecificFormats.ThreeD;


    internal class RunExamples
    {
        private static void Main()
        {
            Console.WriteLine("Open RunExamples.cs.");
            Console.WriteLine("In Main() method uncomment the example that you want to run.");
            Console.WriteLine("=====================================================");

            #region Quick Start

            SetLicenseFromFile.Run();
            //SetLicenseFromStream.Run();
            //SetMeteredLicense.Run();

            #endregion

            #region Basic Usage

            GetDocumentInfo.Run();
            FindMetadataProperties.Run();
            RemoveMetadataProperties.Run();
            SetMetadataProperties.Run();
            CleanMetadata.Run();
            GenerateFilePreview.Run();

            #endregion

            #region Advanced Usage

            #region Extracting Property Values

            ExtractUsingType.Run();
            ExtractUsingAcceptor.Run();

            #endregion

            #region Loading Files

            LoadFromLocalDisk.Run();
            LoadFromStream.Run();
            LoadingFileOfSpecificFormat.Run();
            LoadPasswordProtectedDocument.Run();

            #endregion

            #region Saving Files

            SaveFileToOriginalSource.Run();
            SaveFileToSpecifiedLocation.Run();
            SaveFileToSpecifiedStream.Run();

            #endregion

            ExtractingMetadata.Run();
            UpdatingMetadata.Run();
            RemovingMetadata.Run();
            AddingMetadata.Run();
            SettingMetadata.Run();
            TraverseWholeMetadataTree.Run();
            GettingKnownPropertyDescriptors.Run();
            ExportingMetadataProperties.Run();
            WorkingWithInterpretedValues.Run();
            FindMetadataPropertiesByGroupTag.Run();
            ImportMetadata.Run();
            CopyToMetadata.Run();

            #region Managing metadata for specific formats

            #region Document

            #region WordProcessing

            WordProcessingReadBuiltInProperties.Run();
            WordProcessingUpdateBuiltInProperties.Run();
            WordProcessingReadCustomProperties.Run();
            WordProcessingUpdateCustomProperties.Run();
            WordProcessingReadInspectionProperties.Run();
            WordProcessingUpdateInspectionProperties.Run();
            WordProcessingReadDublinCoreProperties.Run();
            WordProcessingReadDocumentStatistics.Run();
            WordProcessingUpdateDocumentStatistics.Run();
            WordProcessingReadFileFormatProperties.Run();

            #endregion

            #region Spreadsheet

            SpreadsheetReadBuiltInProperties.Run();
            SpreadsheetReadCustomProperties.Run();
            SpreadsheetReadFileFormatProperties.Run();
            SpreadsheetReadInspectionProperties.Run();
            SpreadsheetUpdateBuiltInProperties.Run();
            SpreadsheetUpdateCustomProperties.Run();
            SpreadsheetUpdateInspectionProperties.Run();

            #endregion

            #region Presentation

            PresentationReadBuiltInProperties.Run();
            PresentationReadCustomProperties.Run();
            PresentationReadDocumentStatistics.Run();
            PresentationReadFileFormatProperties.Run();
            PresentationReadInspectionProperties.Run();
            PresentationUpdateBuiltInProperties.Run();
            PresentationUpdateCustomProperties.Run();
            PresentationUpdateInspectionProperties.Run();

            #endregion

            #region Pdf

            PdfReadBuiltInProperties.Run();
            PdfReadCustomProperties.Run();
            PdfReadDocumentStatistics.Run();
            PdfReadFileFormatProperties.Run();
            PdfReadInspectionProperties.Run();
            PdfUpdateBuiltInProperties.Run();
            PdfUpdateCustomProperties.Run();
            PdfUpdateInspectionProperties.Run();

            #endregion

            #region Diagram

            DiagramReadBuiltInProperties.Run();
            DiagramReadCustomProperties.Run();
            DiagramReadDocumentStatistics.Run();
            DiagramReadFileFormatProperties.Run();
            DiagramUpdateBuiltInProperties.Run();
            DiagramUpdateCustomProperties.Run();

            #endregion

            #region Note

            NoteReadInspectionProperties.Run();
            NoteReadDocumentStatistics.Run();

            #endregion

            #region ProjectManagement

            ProjectManagementReadBuiltInProperties.Run();
            ProjectManagementReadCustomProperties.Run();
            ProjectManagementUpdateBuiltInProperties.Run();
            ProjectManagementUpdateCustomProperties.Run();

            #endregion

            #endregion

            #region Image

            ImageReadFileFormatProperties.Run();

            BmpReadHeaderProperties.Run();

            DicomReadNativeMetadataProperties.Run();

            GifReadFileFormatProperties.Run();

            JpegReadImageResourceBlocks.Run();
            JpegDetectBarcodes.Run();
            JpegRemoveImageResourceBlocks.Run();

            MakerNoteReadAllTags.Run();
            MakerNoteReadCanonProperties.Run();
            MakerNoteReadNikonProperties.Run();
            MakerNoteReadPanasonicProperties.Run();
            MakerNoteReadSonyProperties.Run();

            Jpeg2000ReadComments.Run();

            PngReadTextChunks.Run();

            PsdReadNativeMetadataProperties.Run();
            PsdReadImageResourceBlocks.Run();
            PsdReadBasicExifProperties.Run();

            TiffReadBasicIptcProperties.Run();

            Cr2ReadFileFormatProperties.Run();

            DngReadFileFormatProperties.Run();

            #endregion

            #region Video

            AsfReadNativeMetadataProperties.Run();

            AviReadHeaderProperties.Run();
            AviReadInfoMetadata.Run();

            FlvReadHeaderProperties.Run();

            MatroskaReadNativeMetadataProperties.Run();
            MatroskaReadSubtitles.Run();

            MovReadQuickTimeAtoms.Run();

            #endregion

            #region Audio

            MP3ReadID3V1Tag.Run();
            MP3UpdateID3V1Tag.Run();
            MP3RemoveID3V1Tag.Run();
            MP3ReadID3V2Tag.Run();
            MP3UpdateID3V2Tag.Run();
            MP3RemoveID3V2Tag.Run();
            MP3ReadLyricsTag.Run();
            MP3UpdateLyricsTag.Run();
            MP3RemoveLyricsTag.Run();
            MP3ReadApeTag.Run();
            MP3RemoveApeTag.Run();
            MP3ReadMpegAudioMetadata.Run();

            WavReadNativeMetadataProperties.Run();
            WavReadInfoMetadata.Run();

            #endregion

            #region Other formats

            ZipReadNativeMetadataProperties.Run();
            ZipUpdateArchiveComment.Run();
            ZipRemoveArchiveComment.Run();

            VCardReadCardProperties.Run();
            VCardReadCardPropertiesWithParameters.Run();
            VCardFilterCardProperties.Run();

            CadReadNativeMetadataProperties.Run();
            DxfUpdateNativeMetadataProperties.Run();

            EpubReadNativeMetadataProperties.Run();
            EpubUpdateNativeMetadataProperties.Run();
            EpubReadDublinCoreProperties.Run();
            EpubUpdateDublinCoreProperties.Run();

            Fb2ReadProperties.Run();
            MobiReadProperties.Run();

            EmlReadNativeMetadataProperties.Run();
            MsgReadNativeMetadataProperties.Run();
            EmailRemoveAttachments.Run();
            EmailUpdateEmailFields.Run();
            MsgUpdateEmailFields.Run();

            OpenTypeReadNativeMetadataProperties.Run();
            OpenTypeReadDigitalSignatureProperties.Run();

            TorrentReadNativeMetadataProperties.Run();
            TorrentUpdateNativeMetadataProperties.Run();

            SevenZipReadNativeMetadataProperties.Run();
            RarReadNativeMetadataProperties.Run();
            TarReadNativeMetadataProperties.Run();

            DaeReadNativeMetadataProperties.Run();
            FbxReadNativeMetadataProperties.Run();
            StlReadNativeMetadataProperties.Run();
            ThreeDSReadNativeMetadataProperties.Run();

            GisReadNativeMetadataProperties.Run();

            #endregion

            #endregion

            #region Working with metadata standards

            #region Xmp

            ReadXmpProperties.Run();
            UpdateXmpProperties.Run();
            AddCustomXmpPackage.Run();
            RemoveXmpMetadata.Run();

            #endregion

            #region Exif

            ReadBasicExifProperties.Run();
            ReadExifTags.Run();
            UpdateExifProperties.Run();
            SetCustomExifTag.Run();
            RemoveExifMetadata.Run();
            ReadSpecificExifTag.Run();

            #endregion

            #region Iptc

            ReadBasicIptcProperties.Run();
            ReadIptcDataSets.Run();
            UpdateIptcProperties.Run();
            SetCustomIptcDataSet.Run();
            AddRepeatableIptcDataSet.Run();
            RemoveIptcMetadata.Run();

            #endregion

            #endregion

            #endregion

            #region Migration from old versions

            FindPropertiesByRegex.Run();
            UpdatePropertiesByRegex.Run();

            GetIntersectionOfExifProperties.Run();
            GetDifferenceOfDocumentProperties.Run();

            ExportPropertiesToCsv.Run();

            UpdatePropertyValue.Run();

            ExtractPackageUsingCommonApi.Run();

            #endregion

            Console.WriteLine();
            Console.WriteLine("All done.");
            Console.ReadKey();
        }
    }
}
