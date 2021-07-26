using GroupDocs.Metadata.Exceptions;
using GroupDocs.Metadata.MVC.Products.Common.Resources;
using GroupDocs.Metadata.MVC.Products.Metadata.Config;
using GroupDocs.Metadata.MVC.Products.Metadata.DTO;
using GroupDocs.Metadata.MVC.Products.Metadata.Services;
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace GroupDocs.Metadata.MVC.Products.Metadata.Controllers
{
    /// <summary>
    /// MetadataApiController
    /// </summary>
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class MetadataApiController : ApiController
    {
        private readonly Common.Config.GlobalConfiguration globalConfiguration;

        private readonly MetadataService metadataService;

        private readonly FileService fileService;

        /// <summary>
        /// Constructor
        /// </summary>
        public MetadataApiController()
        {
            globalConfiguration = new Common.Config.GlobalConfiguration();
            metadataService = new MetadataService(globalConfiguration.Metadata);
            fileService = new FileService(globalConfiguration.Metadata);
        }

        /// <summary>
        /// Load Metadata configuration
        /// </summary>
        /// <returns>Metadata configuration</returns>
        [HttpGet]
        [Route("loadConfig")]
        public MetadataConfiguration LoadConfig()
        {
            return globalConfiguration.Metadata;
        }

        /// <summary>
        /// Get all files and directories from storage
        /// </summary>
        /// <returns>List of files and directories</returns>
        [HttpPost]
        [Route("loadFileTree")]
        public HttpResponseMessage LoadFileTree()
        {
            if (!globalConfiguration.Metadata.browse)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, fileService.LoadFileTree());
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, Resources.GenerateException(ex));
            }
        }

        /// <summary>
        /// Get file properties
        /// </summary>
        /// <param name="postedData"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("loadProperties")]
        public HttpResponseMessage LoadProperties(PostedDataDto postedData)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, metadataService.GetPackages(postedData));
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, Resources.GenerateException(ex));
            }
        }

        /// <summary>
        /// Save file properties
        /// </summary>
        /// <param name="postedData"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("saveProperty")]
        public HttpResponseMessage SaveProperties(PostedDataDto postedData)
        {
            try
            {
                metadataService.SaveProperties(postedData);
                return Request.CreateResponse(HttpStatusCode.OK, new object());
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, Resources.GenerateException(ex));
            }
        }

        /// <summary>
        /// Removes all available metadata properties from the document
        /// </summary>
        /// <param name="postedData"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("clean")]
        public HttpResponseMessage CleanMetadata(PostedDataDto postedData)
        {
            try
            {
                metadataService.CleanMetadata(postedData);
                return Request.CreateResponse(HttpStatusCode.OK, new object());
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, Resources.GenerateException(ex));
            }
        }

        /// <summary>
        /// Remove file properties
        /// </summary>
        /// <param name="postedData"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("removeProperty")]
        public HttpResponseMessage RemoveProperty(PostedDataDto postedData)
        {
            try
            {
                metadataService.RemoveProperties(postedData);
                return Request.CreateResponse(HttpStatusCode.OK, new object());
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, Resources.GenerateException(ex));
            }
        }

        /// <summary>
        /// Load document description
        /// </summary>
        /// <param name="postedData">Post data</param>
        /// <returns>Document info object</returns>
        [HttpPost]
        [Route("loadDocumentDescription")]
        public HttpResponseMessage LoadDocumentDescription(PostedDataDto postedData)
        {
            string password = "";
            try
            {
                // return document description
                return Request.CreateResponse(HttpStatusCode.OK, fileService.LoadDocument(postedData));
            }
            catch (DocumentProtectedException ex)
            {
                return Request.CreateResponse(HttpStatusCode.Forbidden, Resources.GenerateException(ex, password));
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, Resources.GenerateException(ex));
            }
        }

        /// <summary>
        /// Download currently viewed document
        /// </summary>
        /// <param name="path">Path of the document to download</param>
        /// <returns>Document stream as attachment</returns>
        [HttpGet]
        [Route("downloadDocument")]
        public HttpResponseMessage DownloadDocument(string path)
        {
            if (!string.IsNullOrEmpty(path))
            {
                string absolutePath = globalConfiguration.Metadata.GetAbsolutePath(path);
                if (File.Exists(absolutePath))
                {
                    HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
                    var fileStream = new FileStream(absolutePath, FileMode.Open);
                    response.Content = new StreamContent(fileStream);
                    response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
                    response.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment");
                    response.Content.Headers.ContentDisposition.FileName = Path.GetFileName(absolutePath);
                    return response;
                }
            }

            return new HttpResponseMessage(HttpStatusCode.NotFound);
        }

        /// <summary>
        /// Exports all detected metadata properties to an Excel workbook
        /// </summary>
        /// <param name="postedData"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("export")]
        public HttpResponseMessage ExportProperties(PostedDataDto postedData)
        {
            var result = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new ByteArrayContent(metadataService.ExportMetadata(postedData))
            };
            result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
            {
                FileName = "ExportedProperties.xlsx"
            };
            result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");

            return result;
        }

        /// <summary>
        /// Upload document
        /// </summary>
        /// <returns>Uploaded document object</returns>
        [HttpPost]
        [Route("uploadDocument")]
        public HttpResponseMessage UploadDocument()
        {
            if (!globalConfiguration.Metadata.upload)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, fileService.UploadDocument(HttpContext.Current.Request));
            }
            catch (Exception ex)
            {
                // set exception message
                return Request.CreateResponse(HttpStatusCode.InternalServerError, Resources.GenerateException(ex));
            }
        }
    }
}