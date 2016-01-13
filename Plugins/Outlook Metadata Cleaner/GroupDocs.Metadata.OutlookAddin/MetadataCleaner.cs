using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using GroupDocs.Metadata.Tools;
using GroupDocs.Metadata;
using GroupDocs.Metadata.MetadataProperties;
using GroupDocs.Metadata.Formats;
using GroupDocs.Metadata.Standards.Exif;
using GroupDocs.Metadata.Formats.Document;
using GroupDocs.Metadata.Standards.Doc;
using GroupDocs.Metadata.Formats.Image;
using GroupDocs.Metadata.Standards.Xls;
using GroupDocs.Metadata.Standards.Pdf;
using GroupDocs.Metadata.Standards.Ppt;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Windows.Forms;
using GroupDocs.Metadata.Standards.Exif.Jpeg;
using GroupDocs.Metadata.Standards.Xmp;
using GroupDocs.Metadata.Xmp;
using GroupDocs.Metadata.Xmp.Schemas.DublinCore;

namespace GroupDocs.Metadata.OutlookAddin
{
    public static class MetadataCleaner
    {
        //ExStart:ApplyLicense
        /// <summary>
        /// Applies product license
        /// </summary>
        public static void ApplyLicense()
        {
            try
            {
                // initialize License
                License lic = new License();

                // apply license
                lic.SetLicense(System.Configuration.ConfigurationManager.AppSettings["LicensePath"].ToString());
            }
            catch (Exception exp)
            {

            }
        }
        //ExEnd:ApplyLicense
        public static string CleanDocument(string filePath)
        {

            try
            {
                try
                {
                    //Apply license...
                    ApplyLicense();

                }
                catch (Exception exp)
                {
                    MessageBox.Show("In Licence: " + exp.Message);
                }
                try
                {
                    //Recognize format of file...
                    FormatBase format = FormatFactory.RecognizeFormat(filePath);

                    if (format.Type.ToString().ToLower() == "doc" || format.Type.ToString().ToLower() == "docx")
                    {
                        // initialize DocFormat...
                        DocFormat docFormat = format as DocFormat;
                        if (docFormat != null)
                        {
                            // get document properties...
                            DocMetadata properties = new DocMetadata();
                            properties = docFormat.DocumentProperties;

                            //Remove custom properties...
                            foreach (KeyValuePair<string, PropertyValue> keyValuePair in properties)
                            {
                                if (!properties.IsBuiltIn(keyValuePair.Key))
                                {
                                    properties.Remove(keyValuePair.Key);
                                }
                            }

                            //Reset built-in properties...
                            properties.Author = "";
                            properties.Category = "";
                            properties.Comments = "";
                            properties.Company = "";
                            properties.ContentStatus = "";
                            properties.HyperlinkBase = "";
                            properties.Keywords = "";
                            properties.Manager = "";
                            properties.Title = "";

                            //Update metadata if file...
                            MetadataUtility.UpdateMetadata(filePath, properties);

                        }
                        return "1";
                    }
                    else if (format.Type.ToString().ToLower() == "xls" || format.Type.ToString().ToLower() == "xlsx")
                    {
                        //Initialize XlsFormat...
                        XlsFormat xlsFormat = format as XlsFormat;
                        if (xlsFormat != null)
                        { 
                            //Get document properties...
                            XlsMetadata properties = xlsFormat.DocumentProperties;
                            
                            //Remove custom properties...
                            foreach (KeyValuePair<string, PropertyValue> keyValuePair in properties)
                            {
                                if (!properties.IsBuiltIn(keyValuePair.Key))
                                {
                                    properties.Remove(keyValuePair.Key);
                                }
                            }

                            //Reset built-in properties...
                            properties.Author = "";
                            properties.Category = "";
                            properties.Comments = "";
                            properties.Company = "";
                            properties.HyperlinkBase = "";
                            properties.Keywords = "";
                            properties.Manager = "";
                            properties.Title = "";
                            properties.Subject = "";

                            //Update metadata in files...
                            MetadataUtility.UpdateMetadata(filePath, properties);
                        }
                        return "1";
                    }
                    else if (format.Type.ToString().ToLower() == "ppt" || format.Type.ToString().ToLower() == "pptx")
                    {
                        //Initialize PptFormat...
                        PptFormat pptFormat = format as PptFormat;
                        if (pptFormat != null)
                        {
                            //Get document properties...
                            PptMetadata properties = pptFormat.DocumentProperties;

                            //Remove custom properties
                            foreach (KeyValuePair<string, PropertyValue> keyValuePair in properties)
                            {
                                if (!properties.IsBuiltIn(keyValuePair.Key))
                                {
                                    properties.Remove(keyValuePair.Key);
                                }
                            }

                            //Reset built-in properties...
                            properties.Author = "";
                            properties.Category = "";
                            properties.Comments = "";
                            properties.Company = "";
                            properties.Keywords = "";
                            properties.Manager = "";
                            properties.Title = "";
                            properties.Subject = "";

                            //Update metadata of file...
                            MetadataUtility.UpdateMetadata(filePath, properties); 
                        }
                        return "1";
                    }
                    else if (format.Type.ToString().ToLower() == "pdf")
                    {
                        // initialize PdfFormat...
                        PdfFormat pdfFormat = format as PdfFormat;
                        if (pdfFormat != null)
                        {
                            // get document properties...
                            PdfMetadata properties = pdfFormat.DocumentProperties; 

                            // Remove custom properties...
                            foreach (KeyValuePair<string, PropertyValue> keyValuePair in properties)
                            {
                                if (!properties.IsBuiltIn(keyValuePair.Key))
                                {
                                    properties.Remove(keyValuePair.Key);
                                }
                            }

                            //Reset built-in properties...
                            properties.Author = "";
                            properties.CreatedDate = DateTime.MinValue;
                            properties.Keywords = "";
                            properties.ModifiedDate = DateTime.MinValue;
                            properties.Subject = "";
                            properties.TrappedFlag = false;
                            properties.Title = "";

                            //Update metadata of file... 
                            MetadataUtility.UpdateMetadata(filePath, properties);
                        }
                        return "1";
                    }
                    else if (format.Type.ToString().ToLower() == "jpeg" || format.Type.ToString().ToLower() == "jpg")
                    {
                        //Get EXIF data if exists 
                        ExifMetadata exifMetadata = (ExifMetadata)MetadataUtility.ExtractSpecificMetadata(filePath, MetadataType.EXIF);
                        
                        //Get XMP data if exists
                        XmpMetadata xmpMetadata = (XmpMetadata)MetadataUtility.ExtractSpecificMetadata(filePath, MetadataType.XMP);
                        if (exifMetadata != null)
                        {
                            //Remove exif info... 
                            ExifInfo exifInfo = exifMetadata.Data;

                            if (exifInfo.GPSData != null)
                            {
                                // set altitude, latitude and longitude to null values
                                exifInfo.GPSData.Altitude = null;
                                exifInfo.GPSData.Latitude = null;
                                exifInfo.GPSData.LatitudeRef = null;
                                exifInfo.GPSData.Longitude = null;
                                exifInfo.GPSData.LongitudeRef = null;
                            }
                            exifInfo.BodySerialNumber = "";
                            exifInfo.CameraOwnerName = "";
                            exifInfo.CFAPattern = new byte[] { 0 };
                        }
                        else
                        {
                            exifMetadata = new ExifMetadata();
                        }
                        try
                        {
                            //Remove XMP data...
                            XmpPacketWrapper xmpPacket = xmpMetadata.XmpPacket;
                            if (xmpPacket != null)
                            {
                                if (xmpPacket.ContainsPackage(Namespaces.DublinCore))
                                {
                                    // if not - add DublinCore schema
                                    xmpPacket.AddPackage(new DublinCorePackage());
                                    DublinCorePackage dublinCorePackage = (DublinCorePackage)xmpPacket.GetPackage(Namespaces.DublinCore);
                                    dublinCorePackage.Clear();
                                    xmpMetadata.XmpPacket = xmpPacket;
                                }
                            }
                        }
                        catch { }

                        //Update Exif info...
                        try
                        {
                            MetadataUtility.UpdateMetadata(filePath, exifMetadata);
                        }
                        catch { }

                        //Update XMP data...
                        try
                        {
                            MetadataUtility.UpdateMetadata(filePath, xmpMetadata);
                        }
                        catch { }

                        //Remove custom metadata if any...
                        MetadataUtility.CleanMetadata(filePath);
                        
                        return "1";
                    }
                    else if (format.Type.ToString().ToLower() == "png")
                    {
                        //Get XMP data...
                        XmpMetadata xmpMetadata = (XmpMetadata)MetadataUtility.ExtractSpecificMetadata(filePath, MetadataType.XMP);
                        try
                        {
                            //Remove XMP metadata...
                            XmpPacketWrapper xmpPacket = xmpMetadata.XmpPacket;
                            if (xmpPacket != null)
                            {
                                if (xmpPacket.ContainsPackage(Namespaces.DublinCore))
                                {
                                    // if not - add DublinCore schema
                                    xmpPacket.AddPackage(new DublinCorePackage());
                                    DublinCorePackage dublinCorePackage = (DublinCorePackage)xmpPacket.GetPackage(Namespaces.DublinCore);
                                    dublinCorePackage.Clear();
                                    xmpMetadata.XmpPacket = xmpPacket;

                                    //Update XMP metadata in file...
                                    MetadataUtility.UpdateMetadata(filePath, xmpMetadata);

                                    //Clean custom metadata if any...
                                    MetadataUtility.CleanMetadata(filePath);
                                }
                            }
                        }
                        catch { }

                        return "1";
                    }
                    else if (format.Type.ToString().ToLower() == "gif")
                    {
                        //Initialie GifFormat...
                        GifFormat gifFormat = new GifFormat(filePath);

                        //Check if Xmp supported...
                        if (gifFormat.IsSupportedXmp)
                        {
                            //Get XMP data...
                            XmpMetadata xmpMetadata = (XmpMetadata)MetadataUtility.ExtractSpecificMetadata(filePath, MetadataType.XMP);
                            try
                            {
                                XmpPacketWrapper xmpPacket = xmpMetadata.XmpPacket;
                                if (xmpPacket != null)
                                {
                                    if (xmpPacket.ContainsPackage(Namespaces.DublinCore))
                                    {
                                        // if not - add DublinCore schema
                                        xmpPacket.AddPackage(new DublinCorePackage());
                                        DublinCorePackage dublinCorePackage = (DublinCorePackage)xmpPacket.GetPackage(Namespaces.DublinCore);
                                        dublinCorePackage.Clear();
                                        xmpMetadata.XmpPacket = xmpPacket;

                                        //Update Xmp data in file...
                                        MetadataUtility.UpdateMetadata(filePath, xmpMetadata);
                                        //Clean custom metadata if any...
                                        MetadataUtility.CleanMetadata(filePath);
                                    }
                                }
                            }
                            catch { }
                        }
                        return "1";
                    }
                    else
                    {
                        return "Format not supported.";
                    }
                }
                catch( Exception exp)
                {
                    MessageBox.Show("Exception: " + exp.Message);
                    return exp.Message;
                }

            }
            catch (Exception exp)
            {
                return exp.Message;
            }

        }

    }
}
