using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GroupDocs.Metadata;
using GroupDocs.Metadata.Examples.Utilities.CSharp;

namespace GroupDocs.Metadata.Examples.CSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            /* Apply product license
             * Uncomment following function if you have product license.
             */
            //Common.ApplyLicense();

            #region Working with Documents

            #region Working with Doc Files

            //Get document properties of Doc file
            Documents.Doc.GetDocumentProperties();

            //Update document properties of Doc file
            Documents.Doc.UpdateDocumentProperties();

            //Remove document properties of Doc file
            Documents.Doc.RemoveDocumentProperties();

            //Add custom property in Doc file
            Documents.Doc.AddCustomProperty();

            //Get custom properties in Doc file
            Documents.Doc.GetCustomProperties();

            //Remove custom property of Doc file
            Documents.Doc.RemoveCustomProperties();

            #endregion

            #region Working with Ppt Files

            //Get document properties of Ppt file
            Documents.Ppt.GetDocumentProperties();

            //Update document properties of Ppt file
            Documents.Ppt.UpdateDocumentProperties();

            //Remove document properties of Ppt file
            Documents.Ppt.RemoveDocumentProperties();

            //Add custom property in Ppt file
            Documents.Ppt.AddCustomProperty();

            //Get custom properties in Ppt file
            Documents.Ppt.GetCustomProperties();

            //Remove custom property of Ppt file
            Documents.Ppt.RemoveCustomProperties();

            #endregion

            #region Working with Xls Files

            //Get document properties of Xls file
            Documents.Xls.GetDocumentProperties();

            //Update document properties of Xls file
            Documents.Xls.UpdateDocumentProperties();

            //Remove document properties of Xls file
            Documents.Xls.RemoveDocumentProperties();

            //Add custom property in Xls file
            Documents.Xls.AddCustomProperty();

            //Get custom properties in Xls file
            Documents.Xls.GetCustomProperties();

            //Remove custom property of Xls file
            Documents.Xls.RemoveCustomProperties();

            #endregion

            #region Working with Pdf Files

            //Get document properties of Pdf file
            Documents.Pdf.GetDocumentProperties();

            //Update document properties of Pdf file
            Documents.Pdf.UpdateDocumentProperties();

            //Remove document properties of Pdf file
            Documents.Pdf.RemoveDocumentProperties();

            //Add custom property in Pdf file
            Documents.Pdf.AddCustomProperty();

            //Get custom properties in Pdf file
            Documents.Pdf.GetCustomProperties();

            //Remove custom property of Pdf file
            Documents.Pdf.RemoveCustomProperties();

            #endregion

            #endregion


            #region Working with Images

            #region Working with Gif

            //Get XMP properties of Gif image
            Images.Gif.GetXMPProperties();

            //Update XMP properties of Gif image
            Images.Gif.UpdateXMPProperties();

            //Remove XMP properties of Gif image
            Images.Gif.RemoveXMPProperties();

            #endregion

            #region Working with Jpeg

            //Get XMP properties of Jpeg image
            Images.Jpeg.GetXMPProperties();

            //Update XMP properties of Jpeg image
            Images.Jpeg.UpdateXMPProperties();

            //Remove XMP properties of Jpeg image
            Images.Jpeg.RemoveXMPData();

            //Get Exif Info of Jpeg image
            Images.Jpeg.GetExifInfo();

            //Update Exif Info of Jpeg image
            Images.Jpeg.UpdateExifInfo();

            //Remove Exif Info of Jpeg image
            Images.Jpeg.RemoveExifInfo();

            #endregion

            #region Working with Png

            //Get XMP properties of Png image
            Images.Png.GetXMPProperties();

            //Update XMP properties of Png image
            Images.Png.UpdateXMPData();

            //Remove XMP properties of Png image
            Images.Png.RemoveXMPData();

            #endregion



            #endregion

            #region Working with Utilities
            //ExStart:DocCleanerUsage
            //DocCleaner: Cleans metadata from all Doc files, created by an author, in a directory
            DocCleaner docCleaner = new DocCleaner("Documents/Doc");
            docCleaner.RemoveMetadataByAuthor("Usman Aziz");
            //ExEnd:DocCleanerUsage

            //ExStart:MetadataComparerUsage
            //MetadataComparer: Compares metadata of two files and returns properties that which are different in second file 
            Common.CompareFilesMetadata("Documents/Doc/sample1.doc", "Documents/Doc/sample2.doc");
            //ExEnd:MetadataComparerUsage

            //ExStart:PhotoCleanerUsage
            //PhotoCleaner: Cleans GPS data from photos in a directory
            PhotoCleaner photoCleaner = new PhotoCleaner("Images/Jpeg");
            photoCleaner.RemoveExifLocation();
            //ExEnd:PhotoCleanerUsage

            //ExStart:JpegPhotoParserUsage
            //JpegPhotoParser: Finds photos taken on a specific camera in a directory
            JpegPhotoParser jpegPhotoParser = new JpegPhotoParser("Images/Jpeg");
            jpegPhotoParser.FilterByCameraManufacturer("Sony");
            //ExEnd:JpegPhotoParserUsage

            //ExStart:FormatRecognizerUsage
            //FormatRecognizer: Recognizes the format of all files in a directory 
            Common.GetFileFormats("Documents/Pdf");
            //ExEnd:FormatRecognizerUsage

            
            #endregion

            Console.ReadKey();

        }



    }
}
