using GroupDocs.Metadata.Common;
using GroupDocs.Metadata.Options;
using GroupDocs.Metadata.MVC.Products.Common.Entity.Web;
using GroupDocs.Metadata.MVC.Products.Common.Resources;
using GroupDocs.Metadata.MVC.Products.Common.Util.Comparator;
using GroupDocs.Metadata.MVC.Products.Metadata.Config;
using GroupDocs.Metadata.MVC.Products.Metadata.DTO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Web;

namespace GroupDocs.Metadata.MVC.Products.Metadata.Services
{
    public class FileService
    {
        private readonly MetadataConfiguration metadataConfiguration;

        public FileService(MetadataConfiguration metadataConfiguration)
        {
            this.metadataConfiguration = metadataConfiguration;
        }

        public IEnumerable<FileDescriptionEntity> LoadFileTree()
        {
            List<FileDescriptionEntity> fileList = new List<FileDescriptionEntity>();
            if (!string.IsNullOrEmpty(metadataConfiguration.GetFilesDirectory()))
            {
                var currentPath = metadataConfiguration.GetFilesDirectory();
                List<string> allFiles = new List<string>(Directory.GetFiles(currentPath));
                allFiles.AddRange(Directory.GetDirectories(currentPath));

                // TODO: get temp directory name
                string tempDirectoryName = "temp";

                allFiles.Sort(new FileNameComparator());
                allFiles.Sort(new FileDateComparator());

                foreach (string file in allFiles)
                {
                    FileInfo fileInfo = new FileInfo(file);
                    // check if current file/folder is hidden
                    if (!(tempDirectoryName.Equals(Path.GetFileName(file)) ||
                        fileInfo.Attributes.HasFlag(FileAttributes.Hidden) ||
                        fileInfo.Name.StartsWith(".") ||
                        Path.GetFileName(file).Equals(Path.GetFileName(metadataConfiguration.GetFilesDirectory()))))
                    {
                        FileDescriptionEntity fileDescription = new FileDescriptionEntity();
                        fileDescription.guid = Path.GetFileName(file);
                        fileDescription.name = Path.GetFileName(file);
                        // set is directory true/false
                        fileDescription.isDirectory = fileInfo.Attributes.HasFlag(FileAttributes.Directory);
                        // set file size
                        if (!fileDescription.isDirectory)
                        {
                            fileDescription.size = fileInfo.Length;
                        }
                        // add object to array list
                        fileList.Add(fileDescription);
                    }
                }
            }
            return fileList;
        }

        public LoadDocumentEntity LoadDocument(PostedDataDto postedData)
        {
            // get/set parameters
            string filePath = metadataConfiguration.GetAbsolutePath(postedData.guid);
            string password = string.IsNullOrEmpty(postedData.password) ? null : postedData.password;
            LoadDocumentEntity loadDocumentEntity = new LoadDocumentEntity();

            // set password for protected document
            var loadOptions = new LoadOptions
            {
                Password = password
            };

            using (GroupDocs.Metadata.Metadata metadata = new GroupDocs.Metadata.Metadata(filePath, loadOptions))
            {
                GroupDocs.Metadata.Common.IReadOnlyList<PageInfo> pages = metadata.GetDocumentInfo().Pages;

                using (MemoryStream stream = new MemoryStream())
                {
                    PreviewOptions previewOptions = new PreviewOptions(pageNumber => stream, (pageNumber, pageStream) => { });
                    previewOptions.PreviewFormat = PreviewOptions.PreviewFormats.PNG;

                    int pageCount = pages.Count;
                    if (metadataConfiguration.GetPreloadPageCount() > 0)
                    {
                        pageCount = metadataConfiguration.GetPreloadPageCount();
                    }
                    for (int i = 0; i < pageCount; i++)
                    {
                        previewOptions.PageNumbers = new[] { i + 1 };
                        try
                        {
                            metadata.GeneratePreview(previewOptions);
                        }
                        catch (NotSupportedException)
                        {
                            continue;
                        }

                        PageDescriptionEntity pageData = GetPageDescriptionEntities(pages[i]);
                        string encodedImage = Convert.ToBase64String(stream.ToArray());
                        pageData.SetData(encodedImage);
                        loadDocumentEntity.SetPages(pageData);
                        stream.SetLength(0);
                    }
                }
            }

            loadDocumentEntity.SetGuid(postedData.guid);

            // return document description
            return loadDocumentEntity;
        }

        public UploadedDocumentEntity UploadDocument(HttpRequest request)
        {
            string url = request.Form["url"];
            // get documents storage path
            string documentStoragePath = metadataConfiguration.GetFilesDirectory();
            bool rewrite = bool.Parse(request.Form["rewrite"]);
            string fileSavePath = string.Empty;
            if (string.IsNullOrEmpty(url))
            {
                // Get the uploaded document from the Files collection
                var httpPostedFile = request.Files["file"];
                if (httpPostedFile == null || Path.IsPathRooted(httpPostedFile.FileName))
                {
                    throw new ArgumentException("Could not upload the file");
                }
                if (rewrite)
                {
                    // Get the complete file path
                    fileSavePath = Path.Combine(documentStoragePath, httpPostedFile.FileName);
                }
                else
                {
                    fileSavePath = Resources.GetFreeFileName(documentStoragePath, httpPostedFile.FileName);
                }

                // Save the uploaded file to "UploadedFiles" folder
                httpPostedFile.SaveAs(fileSavePath);

            }
            else
            {
                using (WebClient client = new WebClient())
                {
                    // get file name from the URL
                    Uri uri = new Uri(url);
                    string fileName = Path.GetFileName(uri.LocalPath);
                    if (rewrite)
                    {
                        // Get the complete file path
                        fileSavePath = Path.Combine(documentStoragePath, fileName);
                    }
                    else
                    {
                        fileSavePath = Resources.GetFreeFileName(documentStoragePath, fileName);
                    }
                    // Download the Web resource and save it into the current filesystem folder.
                    client.DownloadFile(url, fileSavePath);
                }
            }

            UploadedDocumentEntity uploadedDocument = new UploadedDocumentEntity();
            uploadedDocument.guid = Path.GetFileName(fileSavePath);

            return uploadedDocument;
        }

        private PageDescriptionEntity GetPageDescriptionEntities(PageInfo page)
        {
            PageDescriptionEntity pageDescriptionEntity = new PageDescriptionEntity();
            pageDescriptionEntity.number = page.PageNumber;
            pageDescriptionEntity.height = page.Height;
            pageDescriptionEntity.width = page.Width;
            return pageDescriptionEntity;
        }
    }
}