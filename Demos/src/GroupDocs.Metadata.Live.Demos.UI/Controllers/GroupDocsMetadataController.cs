using System;
using System.IO;
using System.Web.Http;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net;
using GroupDocs.Metadata.Live.Demos.UI.Models;
using System.Linq;
using GroupDocs.Metadata.Formats.Document;
using System.Collections.Generic;
using System.Web.Http.Results;
using GroupDocs.Metadata.Formats.Audio;
using System.Web;
using Newtonsoft.Json;
using GroupDocs.Metadata.Common;
using GroupDocs.Metadata.Tagging;
using System.Text;
using GroupDocs.Metadata.Export;

namespace GroupDocs.Metadata.Live.Demos.UI.Controllers
{
    public class GroupDocsMetadataController : ApiControllerBase
    {
        [HttpGet]
        [ActionName("GetAllMetadataSupportedFormats")]
        public async Task<Response> GetAllMetadataSupportedFormats()
        {
            string logMsg = "ControllerName: GetAllMetadataSupportedFormats";

            try
            {
                string strFromExtensions = "";

                strFromExtensions = "DOC, DOCX, DOT, DOTX, DOCM, XLS, XLSX, XLSM, XLTM, PPT, PPTX, POTM, POTX, PPTM, PPS, PPSX‎, PPSM, MSG, EML, ONE, VSD, VDX, VSDX, VSS, VSX, MPP, ODT, ODS, PDF, PSD, DWG, DXF, MP3, WAV, AVI, MOV, QT, FLV, EMF, WMF, VCF‎, JPG, JPEG, JPE, JP2, PNG, GIF, TIFF, WebP, BMP, DJVU, DJV, DICOM‎, MKV, MKA, MK3D, WEBM‎, EPUB, ZIP, ZIPX, TORRENT, ASF, ";
                strFromExtensions = strFromExtensions.Trim().Trim(',');

                return await Task.FromResult(new Response
                {
                    OutputType = strFromExtensions.ToUpper(),
                    StatusCode = 200
                });
            }
            catch (Exception exc)
            {
                return new Response
                {
                    Status = exc.Message,
                    StatusCode = 500,
                    Text = exc.ToString()
                };
            }
        }

        [HttpGet]
        [ActionName("DownloadDocument")]
        public HttpResponseMessage DownloadDocument(string file, string folderName, bool isUpdated)
        {
            string logMsg = "ControllerName: MetadataDownloadDocument";
            FileStream original = null;
            try
            {
                file = file.Replace("../", "").Replace("//", "");
                folderName = folderName.Replace("../", "").Replace("//", "");
                string originalFilePath = AppSettings.WorkingDirectory + folderName + "/" + file;
                string originalOutfilePath = AppSettings.WorkingDirectory + folderName + "/" + (isUpdated ? "Updated_" + file : file);

                string parentFolder = Directory.GetParent(System.IO.Path.Combine(originalOutfilePath, @"..\..")).ToString();

                if (!parentFolder.ToLower().Equals(AppSettings.FilesBaseDirectory))
                {
                    throw new Exception("Invalid file path.");
                }
                if (!System.IO.File.Exists(originalOutfilePath))
                {
                    System.IO.File.Copy(originalFilePath, originalOutfilePath, true);
                }
                try
                {
                    original = System.IO.File.Open(originalOutfilePath, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                }
                catch (Exception x)
                {
                    throw x;
                }

                using (var ms = new MemoryStream())
                {
                    original.CopyTo(ms);
                    original.Close();
                    var result = new HttpResponseMessage(HttpStatusCode.OK)
                    {
                        Content = new ByteArrayContent(ms.ToArray())
                    };
                    result.Content.Headers.ContentDisposition =
                    new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment")
                    {
                        FileName = (isUpdated ? "Updated_" + file : file)
                    };

                    result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");

                    return result;
                }
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        [HttpGet]
        [ActionName("CleanMetadata")]
        public HttpResponseMessage CleanMetadata(string file, string folderName, string filePassword = "")
        {
            string logMsg = "ControllerName: CleanMetadata, path: " + folderName + "/" + file;

            try
            {
                string originalFilePath = AppSettings.WorkingDirectory + folderName + "/" + file;
                string OutfileName = "Cleaned_" + file;
                string OutfilePath = AppSettings.WorkingDirectory + folderName + "/" + OutfileName;

                System.IO.File.Copy(originalFilePath, OutfilePath, true);
                FileStream outputFile = System.IO.File.Open(originalFilePath, FileMode.Open, FileAccess.ReadWrite);

                GroupDocs.Metadata.Options.LoadOptions loadOptions = new GroupDocs.Metadata.Options.LoadOptions();
                loadOptions.Password = filePassword;


                GroupDocs.Metadata.Metadata metadata = new GroupDocs.Metadata.Metadata(outputFile, loadOptions);

                if (metadata.FileFormat != FileFormat.Unknown)
                {
                    IDocumentInfo info = metadata.GetDocumentInfo();
                    var fileFormat = info.FileType.FileFormat;

                    var affected = metadata.Sanitize();
                    Console.WriteLine("Properties removed: {0}", affected);

                    metadata.Save(OutfilePath);
                    metadata.Dispose();

                }
                else
                {
                    //throw new Exception("File format not supported.");
                }

                outputFile.Close();

                using (var ms = new MemoryStream())
                {
                    outputFile = System.IO.File.OpenRead(OutfilePath);
                    outputFile.CopyTo(ms);
                    outputFile.Close();

                    var result = new HttpResponseMessage(HttpStatusCode.OK)
                    {
                        Content = new ByteArrayContent(ms.ToArray())
                    };
                    result.Content.Headers.ContentDisposition =
                    new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment")
                    {
                        FileName = OutfileName
                    };
                    result.Content.Headers.ContentType =
                        new MediaTypeHeaderValue("application/octet-stream");

                    outputFile.Close();
                    System.IO.File.Delete(OutfilePath);

                    return result;
                }
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        [HttpGet]
        [ActionName("MetadataProperty")]
        public JsonResult<List<PropertyItem>> MetadataProperty(string file, string folderName, string filePassword = "")
        {
            string logMsg = "ControllerName: MetadataProperty, path: " + folderName + "/" + file;
            FileStream original = null;
            try
            {

                string originalFilePath = AppSettings.WorkingDirectory + folderName + "/" + file;
                string originalOutfileName = "Original_" + file;
                string originalOutfilePath = AppSettings.WorkingDirectory + folderName + "/" + originalOutfileName;

                if (!System.IO.File.Exists(originalOutfilePath))
                {
                    System.IO.File.Copy(originalFilePath, originalOutfilePath, true);
                }

                original = System.IO.File.Open(originalOutfilePath, FileMode.OpenOrCreate, FileAccess.ReadWrite);

                GroupDocs.Metadata.Options.LoadOptions loadOptions = new GroupDocs.Metadata.Options.LoadOptions();
                loadOptions.Password = filePassword;               
                

                GroupDocs.Metadata.Metadata metadata = new GroupDocs.Metadata.Metadata(original,loadOptions);

                List<PropertyItem> values = new List<PropertyItem>();

                if (metadata.FileFormat != FileFormat.Unknown)
                {
                    
                    IDocumentInfo info = metadata.GetDocumentInfo();
                    var fileFormat = info.FileType.FileFormat;

                    switch (fileFormat)
                    {
                        case FileFormat.WordProcessing:
                            values = AppendMetadata(metadata.FindProperties(p => p.Tags.Contains(Tags.Document.BuiltIn)).ToArray(), values);
                            values = AppendMetadata(metadata.FindProperties(p => !p.Tags.Contains(Tags.Document.BuiltIn)).ToArray(), values);                                                       
                            break;

                        case FileFormat.Spreadsheet:
                            values = AppendMetadata(metadata.FindProperties(p => p.Tags.Contains(Tags.Document.BuiltIn)).ToArray(), values);
                            values = AppendMetadata(metadata.FindProperties(p => !p.Tags.Contains(Tags.Document.BuiltIn)).ToArray(), values);
                            break;

                        case FileFormat.Presentation:
                            values = AppendMetadata(metadata.GetRootPackage<PresentationRootPackage>().ToArray(), values);
                            values = AppendMetadata(metadata.FindProperties(p => !p.Tags.Contains(Tags.Document.BuiltIn)).ToArray(), values);
                            break;

                        case FileFormat.Epub:
                            values = AppendMetadata(metadata.FindProperties(p => p.Tags.Contains(Tags.Document.BuiltIn)).ToArray(), values);
                            values = AppendMetadata(metadata.FindProperties(p => !p.Tags.Contains(Tags.Document.BuiltIn)).ToArray(), values);
                            break;

                        case FileFormat.Mp3:
                            values = AppendMetadata(metadata.GetRootPackage<MP3RootPackage>().ToArray(), values);
                            values = AppendMetadata(metadata.FindProperties(p => !p.Tags.Contains(Tags.Document.BuiltIn)).ToArray(), values);
                            break;

                        case FileFormat.Zip:
                            values = AppendMetadata(metadata.FindProperties(p => p.Tags.Contains(Tags.Document.BuiltIn)).ToArray(), values);
                            values = AppendMetadata(metadata.FindProperties(p => !p.Tags.Contains(Tags.Document.BuiltIn)).ToArray(), values);
                            break;

                        case FileFormat.Diagram:
                            values = AppendMetadata(metadata.FindProperties(p => p.Tags.Contains(Tags.Document.BuiltIn)).ToArray(), values);
                            values = AppendMetadata(metadata.FindProperties(p => !p.Tags.Contains(Tags.Document.BuiltIn)).ToArray(), values);
                            break;

                        case FileFormat.DjVu:
                            values = AppendMetadata(metadata.FindProperties(p => p.Tags.Contains(Tags.Document.BuiltIn)).ToArray(), values);
                            values = AppendMetadata(metadata.FindProperties(p => !p.Tags.Contains(Tags.Document.BuiltIn)).ToArray(), values);
                            break;

                        case FileFormat.WebP:
                            values = AppendMetadata(metadata.FindProperties(p => p.Tags.Contains(Tags.Document.BuiltIn)).ToArray(), values);
                            values = AppendMetadata(metadata.FindProperties(p => !p.Tags.Contains(Tags.Document.BuiltIn)).ToArray(), values);
                            Standards.Xmp.IXmp xmpWebP = metadata.GetRootPackage() as Standards.Xmp.IXmp;
                            if (xmpWebP != null && xmpWebP.XmpPackage != null)
                                values = AppendXMPData(xmpWebP.XmpPackage, values);
                            break;

                        case FileFormat.ProjectManagement:
                            values = AppendMetadata(metadata.FindProperties(p => p.Tags.Contains(Tags.Document.BuiltIn)).ToArray(), values);
                            values = AppendMetadata(metadata.FindProperties(p => !p.Tags.Contains(Tags.Document.BuiltIn)).ToArray(), values);
                            break;

                        case FileFormat.Mov:
                            values = AppendMetadata(metadata.FindProperties(p => p.Tags.Contains(Tags.Document.BuiltIn)).ToArray(), values);
                            values = AppendMetadata(metadata.FindProperties(p => !p.Tags.Contains(Tags.Document.BuiltIn)).ToArray(), values);
                            break;

                        case FileFormat.Wmf:
                            values = AppendMetadata(metadata.FindProperties(p => p.Tags.Contains(Tags.Document.BuiltIn)).ToArray(), values);
                            values = AppendMetadata(metadata.FindProperties(p => !p.Tags.Contains(Tags.Document.BuiltIn)).ToArray(), values);
                            break;

                        case FileFormat.Pdf:
                            Standards.Xmp.IXmp xmpPDF = metadata.GetRootPackage() as Standards.Xmp.IXmp;
                            if (xmpPDF != null && xmpPDF.XmpPackage != null)
                                values = AppendXMPData(xmpPDF.XmpPackage, values);

                            values = AppendMetadata(metadata.FindProperties(p => p.Tags.Contains(Tags.Document.BuiltIn)).ToArray(), values);
                            values = AppendMetadata(metadata.FindProperties(p => !p.Tags.Contains(Tags.Document.BuiltIn)).ToArray(), values);
                            break;

                        case FileFormat.Png:
                            Standards.Xmp.IXmp xmpPNG = metadata.GetRootPackage() as Standards.Xmp.IXmp;
                            if (xmpPNG != null && xmpPNG.XmpPackage != null)
                                values = AppendXMPData(xmpPNG.XmpPackage, values);
                            values = AppendMetadata(metadata.FindProperties(p => p.Tags.Contains(Tags.Document.BuiltIn)).ToArray(), values);
                            values = AppendMetadata(metadata.FindProperties(p => !p.Tags.Contains(Tags.Document.BuiltIn)).ToArray(), values);
                            break;

                        case FileFormat.Jpeg:
                            Standards.Xmp.IXmp xmpJPEG = metadata.GetRootPackage() as Standards.Xmp.IXmp;
                            Standards.Exif.IExif exifJPEG = metadata.GetRootPackage() as Standards.Exif.IExif;

                            if (xmpJPEG != null && xmpJPEG.XmpPackage != null)
                                values = AppendXMPData(xmpJPEG.XmpPackage, values);
                            if (exifJPEG != null && exifJPEG.ExifPackage != null)
                                values = AppendEXIData(exifJPEG.ExifPackage, values);

                            values = AppendMetadata(metadata.FindProperties(p => p.Tags.Contains(Tags.Document.BuiltIn)).ToArray(), values);
                            values = AppendMetadata(metadata.FindProperties(p => !p.Tags.Contains(Tags.Document.BuiltIn)).ToArray(), values);

                            break;

                        case FileFormat.Note:
                            values = AppendMetadata(metadata.FindProperties(p => p.Tags.Contains(Tags.Document.BuiltIn)).ToArray(), values);
                            values = AppendMetadata(metadata.FindProperties(p => !p.Tags.Contains(Tags.Document.BuiltIn)).ToArray(), values);
                            break;

                        case FileFormat.Wav:
                            Standards.Xmp.IXmp xmpWAV = metadata.GetRootPackage() as Standards.Xmp.IXmp;
                            if (xmpWAV != null && xmpWAV.XmpPackage != null)
                                values = AppendXMPData(xmpWAV.XmpPackage, values);

                            values = AppendMetadata(metadata.FindProperties(p => p.Tags.Contains(Tags.Document.BuiltIn)).ToArray(), values);
                            values = AppendMetadata(metadata.FindProperties(p => !p.Tags.Contains(Tags.Document.BuiltIn)).ToArray(), values);

                            break;

                        case FileFormat.Flv:
                            Standards.Xmp.IXmp xmpFLV = metadata.GetRootPackage() as Standards.Xmp.IXmp;
                            if (xmpFLV != null && xmpFLV.XmpPackage != null)
                                values = AppendXMPData(xmpFLV.XmpPackage, values);

                            values = AppendMetadata(metadata.FindProperties(p => p.Tags.Contains(Tags.Document.BuiltIn)).ToArray(), values);
                            values = AppendMetadata(metadata.FindProperties(p => !p.Tags.Contains(Tags.Document.BuiltIn)).ToArray(), values);
                            break;

                        case FileFormat.Tiff:
                            Standards.Xmp.IXmp xmpTIFF = metadata.GetRootPackage() as Standards.Xmp.IXmp;
                            Standards.Exif.IExif exifTIFF = metadata.GetRootPackage() as Standards.Exif.IExif;

                            if (xmpTIFF != null && xmpTIFF.XmpPackage != null)
                                values = AppendXMPData(xmpTIFF.XmpPackage, values);

                            if (exifTIFF != null && exifTIFF.ExifPackage != null)
                                values = AppendEXIData(exifTIFF.ExifPackage, values);


                            values = AppendMetadata(metadata.FindProperties(p => p.Tags.Contains(Tags.Document.BuiltIn)).ToArray(), values);
                            values = AppendMetadata(metadata.FindProperties(p => !p.Tags.Contains(Tags.Document.BuiltIn)).ToArray(), values);

                            break;

                        case FileFormat.Psd:
                            Standards.Xmp.IXmp xmpPSD = metadata.GetRootPackage() as Standards.Xmp.IXmp;
                            Standards.Exif.IExif exifPSD = metadata.GetRootPackage() as Standards.Exif.IExif;

                            if (xmpPSD != null && xmpPSD.XmpPackage != null)
                                values = AppendXMPData(xmpPSD.XmpPackage, values);

                            values = AppendMetadata(metadata.FindProperties(p => p.Tags.Contains(Tags.Document.BuiltIn)).ToArray(), values);
                            values = AppendMetadata(metadata.FindProperties(p => !p.Tags.Contains(Tags.Document.BuiltIn)).ToArray(), values);

                            if (exifPSD != null && exifPSD.ExifPackage != null)
                                values = AppendEXIData(exifPSD.ExifPackage, values);

                            break;

                        case FileFormat.Gif:
                            Standards.Xmp.IXmp xmpGIF = metadata.GetRootPackage() as Standards.Xmp.IXmp;
                            if (xmpGIF != null && xmpGIF.XmpPackage != null)
                                values = AppendXMPData(xmpGIF.XmpPackage, values);


                            values = AppendMetadata(metadata.FindProperties(p => p.Tags.Contains(Tags.Document.BuiltIn)).ToArray(), values);
                            values = AppendMetadata(metadata.FindProperties(p => !p.Tags.Contains(Tags.Document.BuiltIn)).ToArray(), values);
                            break;

                        case FileFormat.Bmp:
                            values = AppendMetadata(metadata.FindProperties(p => p.Tags.Contains(Tags.Document.BuiltIn)).ToArray(), values);
                            values = AppendMetadata(metadata.FindProperties(p => !p.Tags.Contains(Tags.Document.BuiltIn)).ToArray(), values);
                            break;

                        case FileFormat.Msg:
                            values = AppendMetadata(metadata.FindProperties(p => p.Tags.Contains(Tags.Document.BuiltIn)).ToArray(), values);
                            values = AppendMetadata(metadata.FindProperties(p => !p.Tags.Contains(Tags.Document.BuiltIn)).ToArray(), values);
                            break;

                        case FileFormat.Eml:
                            values = AppendMetadata(metadata.FindProperties(p => p.Tags.Contains(Tags.Document.BuiltIn)).ToArray(), values);
                            values = AppendMetadata(metadata.FindProperties(p => !p.Tags.Contains(Tags.Document.BuiltIn)).ToArray(), values);
                            break;

                        case FileFormat.Dwg:
                            values = AppendMetadata(metadata.FindProperties(p => p.Tags.Contains(Tags.Document.BuiltIn)).ToArray(), values);
                            values = AppendMetadata(metadata.FindProperties(p => !p.Tags.Contains(Tags.Document.BuiltIn)).ToArray(), values);
                            break;

                        case FileFormat.Dxf:
                            values = AppendMetadata(metadata.FindProperties(p => p.Tags.Contains(Tags.Document.BuiltIn)).ToArray(), values);
                            values = AppendMetadata(metadata.FindProperties(p => !p.Tags.Contains(Tags.Document.BuiltIn)).ToArray(), values);
                            break;

                        case FileFormat.Torrent:
                            values = AppendMetadata(metadata.FindProperties(p => p.Tags.Contains(Tags.Document.BuiltIn)).ToArray(), values);
                            values = AppendMetadata(metadata.FindProperties(p => !p.Tags.Contains(Tags.Document.BuiltIn)).ToArray(), values);
                            break;

                        default:
                            values = AppendMetadata(metadata.FindProperties(p => p.Tags.Contains(Tags.Document.BuiltIn)).ToArray(), values);
                            values = AppendMetadata(metadata.FindProperties(p => !p.Tags.Contains(Tags.Document.BuiltIn)).ToArray(), values);

                            break;
                    }
                    original.Close();
                    return Json(values);
                }
                else
                {
                    original.Close();
                    throw new Exception("Invalid file.");
                }
            }
            catch (Exception exc)
            {
                if (!exc.Message.Contains("Invalid file"))
                    if (original != null)
                        original.Close();
                throw exc;
            }
        }

        [HttpGet]
        [ActionName("MetadataProtected")]
        public Response MetadataProtected(string file, string folderName)
        {
            string logMsg = "ControllerName: MetadataProtected, path: " + folderName + "/" + file;
            FileStream original = null;
            try
            {
                bool isProtected = false;

                string originalFilePath = AppSettings.WorkingDirectory + folderName + "/" + file;
                string originalOutfileName = "Protected_" + file;
                string originalOutfilePath = AppSettings.WorkingDirectory + folderName + "/" + originalOutfileName;

                if (!System.IO.File.Exists(originalOutfilePath))
                {
                    System.IO.File.Copy(originalFilePath, originalOutfilePath, true);
                }

                original = System.IO.File.Open(originalOutfilePath, FileMode.OpenOrCreate, FileAccess.ReadWrite);

                GroupDocs.Metadata.Metadata metadata = new GroupDocs.Metadata.Metadata(original);

               

                if (metadata.FileFormat != FileFormat.Unknown)
                {

                    if (metadata.GetDocumentInfo().IsEncrypted) {

                        isProtected = true;
                    }
                    original.Close();

                    string result =  (isProtected) ? "Success" : "Fail";


                    
                    return new Response
                    {
                        OutputType = result,
                        StatusCode = 200
                    };
                   
                }
                else
                {
                    original.Close();
                    throw new Exception("Invalid file.");
                }
            }
            catch (Exception exc)
            {
                if (original != null)
                    original.Close();
                throw exc;
            }
        }

        [HttpGet]
        [ActionName("ExportMetadata")]
        public HttpResponseMessage ExportMetadata(string file, string folderName, bool isExcel, string filePassword = "")
        {
            string logMsg = "ControllerName: ExportMetadata, isExcel: " + isExcel.ToString() + "path: " + folderName + "/" + file;
            FileStream original = null;

            try
            {
				string originalFilePath = AppSettings.WorkingDirectory + folderName + "/" + file;
				string OutfileName = "Metadata_" + Path.GetFileNameWithoutExtension(file) + (isExcel ? ".xlsx" : ".csv");
				string OutfilePath = AppSettings.WorkingDirectory + folderName + "/" + OutfileName;

                System.IO.File.Copy(originalFilePath, OutfilePath, true);
                original = System.IO.File.Open(originalFilePath, FileMode.OpenOrCreate);


                GroupDocs.Metadata.Options.LoadOptions loadOptions = new GroupDocs.Metadata.Options.LoadOptions();
                loadOptions.Password = filePassword;


                GroupDocs.Metadata.Metadata metadata = new GroupDocs.Metadata.Metadata(original, loadOptions);

				var properties = metadata.FindProperties(p => true);

				if (isExcel)
				{
                    RootMetadataPackage root = metadata.GetRootPackage();
                    if (root != null)
                    {
                        ExportManager manager = new ExportManager(root);
                        manager.Export(OutfilePath, ExportFormat.Xlsx);
                    }
                }
				else
				{
                    const string delimiter = ";";
                    StringBuilder builder = new StringBuilder();
                    builder.AppendFormat("Name{0}Value", delimiter);
                    builder.AppendLine();
                    foreach (var property in properties)
                    {
                        builder.AppendFormat(@"""{0}""{1}""{2}""", property.Name, delimiter, FormatValue(property.Value));
                        builder.AppendLine();
                    }

                    System.IO.File.WriteAllText(OutfilePath, builder.ToString());
                }

                original.Close();
                using (var ms = new MemoryStream())
                {
                    original = System.IO.File.OpenRead(OutfilePath);
                    original.CopyTo(ms);

                    var result = new HttpResponseMessage(HttpStatusCode.OK)
                    {
                        Content = new ByteArrayContent(ms.ToArray())
                    };

                    result.Content.Headers.ContentDisposition =
                    new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment")
                    {
                        FileName = OutfileName
                    };

                    result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");

                    original.Close();

                    return result;
                }
            }
            catch (Exception exc)
            {
                if (original != null)
                    original.Close();
                throw exc;
            }
        }

        [HttpPost]
        [ActionName("UpdateMetadata")]
        public Response UpdateMetadata(string file, string folderName , string filePassword = "")
        {
            string logMsg = "ControllerName: UpdateMetadata, path: " + folderName + "/" + file;
            FileStream original = null;

            try
            {
                var httpRequest = HttpContext.Current.Request;
                var jsonObject = httpRequest.Params["lstProperties"];//.ToList<MetadataProperty>();

                List<PropertyItem> deserialized = JsonConvert.DeserializeObject<List<PropertyItem>>(jsonObject);
                
                string originalFilePath = AppSettings.WorkingDirectory + folderName + "/" + file;
                string originalOutfileName = "Updated_" + file;
                string originalOutfilePath = AppSettings.WorkingDirectory + folderName + "/" + originalOutfileName;

                if (!System.IO.File.Exists(originalOutfilePath))
                {
                    System.IO.File.Copy(originalFilePath, originalOutfilePath, true);
                }

                original = System.IO.File.Open(originalOutfilePath, FileMode.OpenOrCreate, FileAccess.ReadWrite);


                GroupDocs.Metadata.Options.LoadOptions loadOptions = new GroupDocs.Metadata.Options.LoadOptions();
                loadOptions.Password = filePassword;


                GroupDocs.Metadata.Metadata metadata = new GroupDocs.Metadata.Metadata(originalFilePath, loadOptions);                

                List<PropertyItem> values = new List<PropertyItem>();

                foreach (PropertyItem obj in deserialized)
                {

                    metadata.SetProperties(p => p.Name == obj.Name, new GroupDocs.Metadata.Common.PropertyValue(obj.Value.ToString()));

                }

                original.Dispose();

                if (!System.IO.File.Exists(originalOutfilePath))
                {
                    System.IO.File.Delete(originalFilePath);
                }


                metadata.Save(originalOutfilePath);
                metadata.Dispose();

                return new Response
                {
                    OutputType = "Successful",
                    StatusCode = 200
                };
            }
            catch (Exception exc)
            {
                if (original != null)
                    original.Close();
                throw exc;
            }
        }



        private List<PropertyItem> AppendMetadata(GroupDocs.Metadata.Common.MetadataProperty[] metadataArray, List<PropertyItem> values)
        {

            foreach (Common.MetadataProperty metadataPropert in metadataArray)
            {
                if (metadataPropert.Value != null && metadataPropert.Value.RawValue != null)
                {
                    bool isBuiltIn = (metadataPropert.Tags.Contains(Tags.Document.BuiltIn)) ? true : false;
                    try
                    {
                        if (!metadataPropert.Value.Type.ToString().Equals("StringArray"))
                        {
                            if (values.FindAll(t => t.Name.Equals(metadataPropert.Name)).Count == 0)
                                values.Add(new PropertyItem(metadataPropert.Name, metadataPropert.Value.RawValue.ToString(), "BIP", isBuiltIn));
                        }
                        else
                        {
                            object value = metadataPropert.Value.RawValue;
                            Array arrayVal = (Array)value;

                            string strValues = "[" + arrayVal.Length.ToString() + "] - ";
                            foreach (string str in arrayVal)
                            {
                                strValues += str + " ,";
                            }
                            if (values.FindAll(t => t.Name.Equals(metadataPropert.Name)).Count == 0)
                                values.Add(new PropertyItem(metadataPropert.Name, strValues.Trim(','), "BIP", isBuiltIn));
                        }
                    }
                    catch
                    {
                        continue;
                    }
                }
            }

            return values;
        }
        private List<PropertyItem> AppendXMPData(GroupDocs.Metadata.Standards.Xmp.XmpPacketWrapper xmpMetadata, List<PropertyItem> values)
        {
            if (xmpMetadata != null)
            {
                PropertyItem propertyItem;

                foreach (GroupDocs.Metadata.Standards.Xmp.XmpPackage package in xmpMetadata.Packages)
                {
                    try
                    {
                        foreach (GroupDocs.Metadata.Common.MetadataProperty pair in package)
                        {
                            try
                            {
                                GroupDocs.Metadata.Standards.Xmp.XmpArray xmpArray = pair.Value.RawValue as GroupDocs.Metadata.Standards.Xmp.XmpArray;
                                GroupDocs.Metadata.Standards.Xmp.XmpLangAlt langAlt = pair.Value.RawValue as GroupDocs.Metadata.Standards.Xmp.XmpLangAlt;

                                if (xmpArray != null)
                                {
                                    propertyItem = new PropertyItem(pair.Name, pair.Value.RawValue.ToString(), "XMP", false);

                                    if (values.FindAll(t => t.Name.Equals(pair.Name)).Count == 0)
                                        values.Add(propertyItem);

                                }
                                else if (langAlt != null)
                                {
                                    propertyItem = new PropertyItem(pair.Name + langAlt.ToString(), langAlt.ToString(), "XMP", false);

                                    if (values.FindAll(t => t.Name.Equals(pair.Name + langAlt.ToString())).Count == 0)
                                        values.Add(propertyItem);
                                }
                                else
                                {
                                    propertyItem = new PropertyItem(pair.Name, pair.Value.RawValue.ToString(), "XMP", false);

                                    if (values.FindAll(t => t.Name.Equals(pair.Name)).Count == 0)
                                        values.Add(propertyItem);
                                }
                            }
                            catch
                            {
                                continue;
                            }
                        }
                    }
                    catch
                    {
                        continue;
                    }
                }
            }

            return values;
        }
        private List<PropertyItem> AppendEXIData(GroupDocs.Metadata.Standards.Exif.ExifPackage exifInfo, List<PropertyItem> values)
        {
            if (exifInfo != null)
            {
                PropertyItem propertyItem;

                GroupDocs.Metadata.Common.MetadataProperty[] allTags = exifInfo.ToArray();

                foreach (GroupDocs.Metadata.Common.MetadataProperty tag in allTags)
                {
                    try
                    {
                        propertyItem = new PropertyItem(tag.Name, tag.Value.RawValue.ToString(), "EXI", false);

                        if (values.FindAll(t => t.Name.Equals(tag.Name)).Count == 0)
                            values.Add(propertyItem);
                    }
                    catch
                    {
                        continue;
                    }
                }
            }
            return values;
        }



        private static string FormatValue(PropertyValue propertyValue)
        {
            if (propertyValue == null || propertyValue.RawValue == null)
            {
                return null;
            }

            object value = propertyValue.RawValue;

            StringBuilder result = new StringBuilder();
            if (value.GetType().IsArray)
            {
                const int arrayMaxLength = 20;
                const string arrayStartCharacter = "[";
                const string arrayEndCharacter = "]";

                Array array = (Array)value;
                if (array.Length > 0)
                {
                    result.Append(arrayStartCharacter);
                    for (int index = 0; index < array.Length; index++)
                    {
                        object item = array.GetValue(index);
                        result.AppendFormat("{0},", item);
                        if (index > arrayMaxLength)
                        {
                            result.Append("...");
                            break;
                        }
                    }
                    result = result.Remove(result.Length - 1, 1);
                    result.Append(arrayEndCharacter);
                }
            }
            else
            {
                result.Append(value);
            }

            result.Replace("\"", "\"\"");
            return result.ToString();
        }

        public class PropertyItem
        {
            public string Name { get; set; }
            public string Value { get; set; }
            public string ValueType { get; set; }
            public bool IsBuiltIn { get; set; }

            public PropertyItem(string name, string value, string ValueType, bool isBuiltIn)
            {
                this.Name = name;
                this.Value = value;
                this.ValueType = ValueType;
                this.IsBuiltIn = isBuiltIn;
            }
        }
    }
}