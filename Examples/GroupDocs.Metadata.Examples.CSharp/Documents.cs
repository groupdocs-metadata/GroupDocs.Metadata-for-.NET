using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GroupDocs.Metadata.Formats.Document;
using GroupDocs.Metadata;
using GroupDocs.Metadata.Tools;
using GroupDocs.Metadata.Examples.Utilities.CSharp;
using GroupDocs.Metadata.Xmp.Schemes;
using GroupDocs.Metadata.Formats;
using GroupDocs.Metadata.Examples.CSharp.Utilities;
using GroupDocs.Metadata.Formats.Project;
using GroupDocs.Metadata.Exceptions;
using System.IO;
using GroupDocs.Metadata.Xmp;
using GroupDocs.Metadata.Formats.Ebook;
using GroupDocs.Metadata.Formats.Image;
using System.Text.RegularExpressions;

namespace GroupDocs.Metadata.Examples.CSharp
{
    public static class Documents
    {
        public static class Doc
        {
            // initialize file path
            //ExStart:SourceDocFilePath
            private const string filePath = "Documents/Doc/sample.docx";
            //ExEnd:SourceDocFilePath
            #region working with built-in document properties

            /// <summary>
            /// Gets builtin document properties from Doc file 
            /// </summary> 
            public static void GetDocumentProperties()
            {
                try
                {
                    //ExStart:GetBuiltinDocumentPropertiesDocFormat
                    // initialize DocFormat
                    using (DocFormat docFormat = new DocFormat(Common.MapSourceFilePath(filePath)))
                    {

                        // initialize metadata
                        DocMetadata docMetadata = docFormat.DocumentProperties;

                        // get properties
                        Console.WriteLine("Built-in Properties: ");
                        foreach (KeyValuePair<string, PropertyValue> property in docMetadata)
                        {
                            // check if built-in property
                            if (docMetadata.IsBuiltIn(property.Key))
                            {
                                Console.WriteLine("{0} : {1}", property.Key, property.Value);
                            }
                        } 
                    }
                    //ExEnd:GetBuiltinDocumentPropertiesDocFormat
                }
                catch (Exception exp)
                {
                    Console.WriteLine(exp.Message);
                }
            }

            /// <summary>
            /// Reads all metadata keys of the Word document
            /// </summary> 
            /// <param name="directoryPath">Path to the files</param>
            public static void ReadMetadataUsingKeys(string directoryPath)
            {
                try
                {
                    //ExStart:ReadMetadataUsingKeys
                    //Get all Word documents inside directory
                    string[] files = Directory.GetFiles(Common.MapSourceFilePath(directoryPath), "*.doc");

                    foreach (string path in files)
                    {
                        Console.WriteLine("Document: {0}", Path.GetFileName(path));

                        // open Word document
                        using (DocFormat doc = new DocFormat(path))
                        {
                            // get metadata
                            Metadata metadata = doc.DocumentProperties;

                            // print all metadata keys presented in DocumentProperties
                            foreach (string key in metadata.Keys)
                            {
                                Console.WriteLine(key);
                            }
                        }
                    }
                    //ExEnd:ReadMetadataUsingKeys
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            /// <summary>
            /// Update Metadata Using Regex 
            /// Feature is supported in version 18.5 or greater of the API
            /// </summary>
            public static void ReplaceMetadataUsingRegex()
            {
                try
                {
                    Regex pattern = new Regex("^author|company$", RegexOptions.IgnoreCase);
                    string replaceValue = "Aspose";
                    SearchFacade.ReplaceInDocument(Common.MapSourceFilePath(filePath), pattern, replaceValue, Common.MapDestinationFilePath(filePath));
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }
            }

            /// <summary>
            /// Find Metadata Using Regex 
            /// Feature is supported in version 18.5 or greater of the API
            /// </summary>
            public static void FindMetadataUsingRegex()
            {
                try
                {
                    Regex pattern = new Regex("author|company", RegexOptions.IgnoreCase);
                    MetadataPropertyCollection properties = SearchFacade.ScanDocument(Common.MapDestinationFilePath(filePath), pattern);
                    for (int i = 0; i < properties.Count; i++)
                    {
                        Console.WriteLine(properties[i]);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }           
            }

            /// <summary>
            /// Read ImageCover using Metadata Utility 
            /// Feature is supported in version 18.4 or greater of the API
            /// </summary>
            public static void ReadImageCoverMetadataUtility()
            {
                try
                {
                    //Read DublinCore Metadata
                    ThumbnailMetadata thumbnailMetadata = (ThumbnailMetadata)MetadataUtility.ExtractSpecificMetadata(Common.MapSourceFilePath(filePath), MetadataType.Thumbnail);

                    if (thumbnailMetadata != null)
                    {
                        // get Mime Type 
                        Console.WriteLine(thumbnailMetadata.MimeType);
                        // get Length 
                        Console.WriteLine(thumbnailMetadata.ImageData.Length);

                    }

                }
                catch (Exception exp)
                {

                    Console.WriteLine(exp.Message);
                }
            }

            /// <summary>
            /// Read DublinCore Metadata using Metadata Utility 
            /// Feature is supported in version 18.4 or greater of the API
            /// </summary>
            public static void ReadDublinCoreMetadata()
            {
                try
                {
                    // read dublin-core metadata
                    DublinCoreMetadata dublinCore = (DublinCoreMetadata)MetadataUtility.ExtractSpecificMetadata(Common.MapSourceFilePath(filePath), MetadataType.DublinCore);

                    // get creator
                    Console.WriteLine("Creator = {0}", dublinCore.Creator);

                    // get publisher
                    Console.WriteLine("Publisher = {0}", dublinCore.Publisher);

                    // get contributor
                    Console.WriteLine("Contributor = {0}", dublinCore.Contributor);

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            /// <summary>
            /// Updates document properties of Doc file and creates output file
            /// </summary> 
            public static void UpdateDocumentProperties()
            {
                try
                {
                    //ExStart:UpdateBuiltinDocumentPropertiesDocFormat
                    // initialize DocFormat
                    using (DocFormat docFormat = new DocFormat(Common.MapSourceFilePath(filePath)))
                    {

                        // initialize DocMetadata
                        DocMetadata docMetadata = docFormat.DocumentProperties;

                        //update document property...
                        docMetadata.Author = "Usman";
                        docMetadata.Company = "Aspose";
                        docMetadata.Manager = "Usman Aziz";

                        //save output file...
                        docFormat.Save(Common.MapDestinationFilePath(filePath));
                        //ExEnd:UpdateBuiltinDocumentPropertiesDocFormat
                        Console.WriteLine("Updated Successfully."); 
                    }

                }
                catch (Exception exp)
                {
                    Console.WriteLine(exp.Message);
                }

            }
            /// <summary>
            /// Removes document properties of Doc file and creates output file
            /// </summary> 
            public static void RemoveDocumentProperties()
            {
                try
                {
                    //ExStart:RemoveBuiltinDocumentPropertiesDocFormat
                    // initialize Docformat
                    using (DocFormat docFormat = new DocFormat(Common.MapSourceFilePath(filePath)))
                    {
                        //Clean metadata
                        docFormat.CleanMetadata();

                        // save output file...
                        docFormat.Save(Common.MapDestinationFilePath(filePath));
                        //ExEnd:RemoveBuiltinDocumentPropertiesDocFormat
                        Console.WriteLine("File saved in destination folder."); 
                    }


                }
                catch (Exception exp)
                {
                    Console.WriteLine(exp.Message);
                }
            }
            #endregion

            #region working with custom properties
            /// <summary>
            /// Adds custom property in Doc file and creates output file
            /// </summary> 
            public static void AddCustomProperty()
            {
                try
                {
                    //ExStart:AddCustomPropertyDocFormat
                    // initialize DocFormat
                    using (DocFormat docFormat = new DocFormat(Common.MapSourceFilePath(filePath)))
                    {

                        // initialize DocMetadata
                        DocMetadata metadata = docFormat.DocumentProperties;


                        string propertyName = "New Custom Property";
                        string propertyValue = "123";

                        // add boolean key
                        if (!metadata.ContainsKey(propertyName))
                        {
                            // add property
                            metadata.Add(propertyName, propertyValue);
                        }

                        // save file in destination folder
                        docFormat.Save(Common.MapDestinationFilePath(filePath));
                        //ExEnd:AddCustomPropertyDocFormat
                        Console.WriteLine("File saved in destination folder."); 
                    }


                }
                catch (Exception exp)
                {
                    Console.WriteLine(exp.Message);
                }
            }
            /// <summary>
            /// Gets custom properties of Doc file
            /// </summary>
            public static void GetCustomProperties()
            {
                try
                {
                    //ExStart:GetCustomPropertiesDocFormat
                    // initialize DocFormat
                    using (DocFormat docFormat = new DocFormat(Common.MapSourceFilePath(filePath)))
                    {
                  
                        // initialize metadata
                        DocMetadata docMetadata = docFormat.DocumentProperties;

                        // get properties  
                        Console.WriteLine("\nCustom Properties");
                        foreach (KeyValuePair<string, PropertyValue> keyValuePair in docMetadata)
                        {
                            // check if property is not built-in
                            if (!docMetadata.IsBuiltIn(keyValuePair.Key))
                            {
                                try
                                {
                                    // get property value
                                    PropertyValue propertyValue = docMetadata[keyValuePair.Key];
                                    Console.WriteLine("Key: {0}, Type:{1}, Value: {2}", keyValuePair.Key, propertyValue.Type, propertyValue);
                                }
                                catch { }
                            }
                        } 
                    }
                    //ExEnd:GetCustomPropertiesDocFormat
                }
                catch (Exception exp)
                {
                    Console.WriteLine(exp.Message);
                }
            }
            /// <summary>
            /// Removes custom properties of Doc file and creates output file
            /// </summary> 
            public static void RemoveCustomProperties()
            {
                try
                {
                    //ExStart:RemoveCustomPropertyDocFormat
                    // initialize DocFormat
                    using (DocFormat docFormat = new DocFormat(Common.MapSourceFilePath(filePath)))
                    {

                        // initialize DocMetadata
                        DocMetadata metadata = docFormat.DocumentProperties;

                        string propertyName = "New Custom Property";

                        // check if property is not built-in
                        if (metadata.ContainsKey(propertyName))
                        {
                            if (!metadata.IsBuiltIn(propertyName))
                            {
                                // remove property
                                metadata.Remove(propertyName);

                            }
                            else
                            {
                                Console.WriteLine("Can not remove built-in property.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Property does not exist.");
                        }

                        bool isexist = metadata.ContainsKey(propertyName);

                        // save file in destination folder
                        docFormat.Save(Common.MapDestinationFilePath(filePath));
                        //ExEnd:RemoveCustomPropertyDocFormat
                        Console.WriteLine("File saved in destination folder."); 
                    }

                }
                catch (Exception exp)
                {
                    Console.WriteLine(exp.Message);
                }
            }
            /// <summary>
            /// Clears custom properties of Doc file and creates output file
            /// </summary> 
            public static void ClearCustomProperties()
            {
                try
                {
                    //ExStart:ClearCustomPropertyDocFormat
                    // initialize DocFormat
                    using (DocFormat docFormat = new DocFormat(Common.MapSourceFilePath(filePath)))
                    {
                        // use one of the following methods
                        // method:1 - clear custom properties 
                        docFormat.ClearCustomProperties();

                        // method:2 - clear custom properties 
                        docFormat.DocumentProperties.ClearCustomData();

                        // save file in destination folder
                        docFormat.Save(Common.MapDestinationFilePath(filePath));
                        //ExEnd:ClearCustomPropertyDocFormat
                        Console.WriteLine("File saved in destination folder."); 
                    }

                }
                catch (Exception exp)
                {
                    Console.WriteLine(exp.Message);
                }
            }
            #endregion

            #region working with document comments
            /// <summary>
            /// Gets document comments of Doc file
            /// </summary> 
            public static void GetDocumentComments()
            {
                try
                {

                    // initialize DocFormat
                    using (DocFormat docFormat = new DocFormat(Common.MapSourceFilePath(filePath)))
                    {
                        //get comments...
                        DocComment[] comments = docFormat.ExtractComments();

                        //get commnets by author...
                        //DocComment[] comments = docFormat.ExtractComments("USMAN");

                        // display comments
                        foreach (DocComment comment in comments)
                        {
                            Console.WriteLine("Author: ", comment.Author);
                            Console.WriteLine("Created on Date: ", comment.CreatedDate);
                            Console.WriteLine("Initials: ", comment.Initials);
                            Console.WriteLine("\n");
                        } 
                    }
                }
                catch (Exception exp)
                {
                    Console.WriteLine(exp.Message);
                }
            }
            /// <summary>
            /// Removes document comments of Doc file  
            /// </summary> 
            public static void RemoveComments()
            {
                try
                {

                    // initialize DocFormat
                    using (DocFormat docFormat = new DocFormat(Common.MapSourceFilePath(filePath)))
                    {

                        // remove comments
                        docFormat.ClearComments();

                        // save file in destination folder
                        docFormat.Save(Common.MapDestinationFilePath(filePath));

                        Console.WriteLine("File saved in destination folder."); 
                    }


                }
                catch (Exception exp)
                {
                    Console.WriteLine(exp.Message);
                }
            }

            /// <summary>
            /// Updates document comments of Doc file  
            /// </summary> 
            public static void UpdateComments()
            {
                try
                {
                    //ExStart:UpdateDocumentComment
                    // initialize DocFormat
                    using (DocFormat docFormat = new DocFormat(Common.MapSourceFilePath(filePath)))
                    {

                        // extract comments
                        DocComment[] comments = docFormat.ExtractComments();

                        if (comments.Length > 0)
                        {
                            // get first comment if exist
                            var comment = comments[0];

                            // change comment's author
                            comment.Author = "Jack London";

                            // change comment's text
                            comment.Text = "This comment is created using GroupDocs.Metadata";

                            // update comment
                            docFormat.UpdateComment(comment.Id, comment);
                        }

                        // save file in destination folder
                        docFormat.Save(Common.MapDestinationFilePath(filePath));

                        Console.WriteLine("File saved in destination folder."); 
                    }
                    //ExEnd:UpdateDocumentComment

                }
                catch (Exception exp)
                {
                    Console.WriteLine(exp.Message);
                }
            }
            #endregion

            #region working with pages and words
            /// <summary>
            /// Gets word count and page count of Doc file
            /// </summary> 
            public static void GetWordAndPageCount()
            {
                try
                {

                    // initialize DocFormat
                    using (DocFormat docFormat = new DocFormat(Common.MapSourceFilePath(filePath)))
                    {
                     

                        // Get words count...
                        int wordsCount = docFormat.GetWordsCount();

                        // Get pages count...
                        int pageCounts = docFormat.GetPagesCount();

                        Console.WriteLine("Words: {0}", wordsCount);
                        Console.WriteLine("Pages: {0}", pageCounts); 
                    }


                }
                catch (Exception exp)
                {
                    Console.WriteLine(exp.Message);
                }
            }
            #endregion

            #region working with hidden fields
            /// <summary>
            /// Gets comments, merge fields and hidden fields of Doc file
            /// </summary> 
            public static void GetHiddenData()
            {
                try
                {
                    //ExStart:GetHiddenDataInDocument
                    // initialize DocFormat
                    using (DocFormat docFormat = new DocFormat(Common.MapSourceFilePath(filePath)))
                    {

                        // inspect document
                        //InspectionResult inspectionResult = docFormat.InspectDocument();
                        DocInspectionResult inspectionResult = docFormat.InspectDocument();

                        // display comments
                        if (inspectionResult.Comments.Length > 0)
                        {
                            Console.WriteLine("Comments in document:");
                            foreach (DocComment comment in inspectionResult.Comments)
                            {
                                Console.WriteLine("Comment: {0}", comment.Text);
                                Console.WriteLine("Author: {0}", comment.Author);
                                Console.WriteLine("Date: {0}", comment.CreatedDate);
                            }
                        }

                        // display merge fields
                        if (inspectionResult.Fields.Length > 0)
                        {
                            Console.WriteLine("\nMerge Fields in document:");
                            foreach (DocField field in inspectionResult.Fields)
                            {
                                Console.WriteLine(field.Name);
                            }
                        }

                        // display hidden fields 
                        if (inspectionResult.HiddenText.Length > 0)
                        {
                            Console.WriteLine("\nHiddent text in document:");
                            foreach (string word in inspectionResult.HiddenText)
                            {
                                Console.WriteLine(word);
                            }
                        } 
                    }
                    //ExEnd:GetHiddenDataInDocument

                }
                catch (Exception exp)
                {
                    Console.WriteLine(exp.Message);
                }
            }
            /// <summary>
            /// Gets comments, merge fields and hidden fields of Doc file
            /// </summary> 
            public static void RemoveMergeFields()
            {
                try
                {
                    //ExStart:RemoveHiddenDataInDocument
                    // initialize DocFormat
                    using (DocFormat docFormat = new DocFormat(Common.MapSourceFilePath(filePath)))
                    {

                        // inspect document
                        //InspectionResult inspectionResult = docFormat.InspectDocument();
                        DocInspectionResult inspectionResult = docFormat.InspectDocument();

                        // if merge fields are presented
                        if (inspectionResult.Fields.Length > 0)
                        {
                            // remove it
                            docFormat.RemoveHiddenData(new DocInspectionOptions(DocInspectorOptionsEnum.Fields));

                            // save file in destination folder
                            docFormat.Save(Common.MapDestinationFilePath(filePath));
                        }
                        //ExEnd:RemoveHiddenDataInDocument

                        Console.WriteLine("File saved in destination folder."); 
                    }
                }
                catch (Exception exp)
                {
                    Console.WriteLine(exp.Message);
                }
            }
            #endregion

            #region Working with Original File Docs
            /// <summary>
            ///  Save Changes after updating metadata of specific format
            /// </summary>
            public static void SaveFileAfterMetadataUpdate()
            {
                //ExStart:SaveFileAfterMetadataUpdate
                // initialize DocFormat
                using (DocFormat docFormat = new DocFormat(Common.MapSourceFilePath(filePath)))
                {

                    // update document properties
                    docFormat.DocumentProperties.Author = "Joe Doe";
                    docFormat.DocumentProperties.Company = "Aspose";

                    // and commit changes
                    docFormat.Save(); 
                }
                //ExEnd:SaveFileAfterMetadataUpdate
            }

            /// <summary>
            ///  Throw an Exception for Protected Document
            /// </summary>
            public static void DocumentProtectedException()
            {
                //ExStart:DocumentProtectedException
                // initialize DocFormat
                try
                {
                    using (DocFormat docFormat = new DocFormat(Common.MapSourceFilePath(filePath)))
                    {

                        // and try to get document properties
                        var documentProperties = docFormat.DocumentProperties; 
                    }
                }
                catch (DocumentProtectedException ex)
                {
                    Console.WriteLine("File is protected by password PDF: {0}", ex.Message);
                }
                //ExEnd:DocumentProtectedException
            }
            #endregion

            #region Working with Revisions
            /// <summary>
            /// Shows how to read all track changes(revisions) in Word document.
            /// Feature is supported by version 17.05 or greater
            /// </summary>
            public static void ReadAllRevisions()
            {
                //ExStart:ReadAllRevisions
                // initialize DocFormat
                using (DocFormat docFormat = new DocFormat(Common.MapSourceFilePath(filePath)))
                {

                    // get revisions
                    RevisionCollection revisionCollection = docFormat.Revisions;

                    // get revisions count
                    Console.WriteLine("Revisions: {0}", revisionCollection.Count);

                    foreach (Revision revision in revisionCollection)
                    {
                        // display revision type
                        Console.WriteLine("Revision -  type: {0}, ", revision.RevisionType);

                        // display revision author
                        Console.Write("author: {0}, ", revision.Author);

                        // display revision date
                        Console.Write("date: {0}", revision.DateTime);
                    } 
                }
                //ExEnd:ReadAllRevisions
            }

            /// <summary>
            /// Shows how to accept all changes in Word document.
            /// Feature is supported by version 17.05 or greater
            /// </summary>
            public static void AcceptAllChanges() {
                //ExStart:AcceptAllChanges
                // initialize DocFormat
                using (DocFormat docFormat = new DocFormat(Common.MapSourceFilePath(filePath)))
                {

                    // get revisions
                    RevisionCollection revisionCollection = docFormat.Revisions;

                    // accept all revisions
                    revisionCollection.AcceptAll();

                    // and commit changes
                    docFormat.Save(); 
                }
                //ExEnd:AcceptAllChanges
            }

            /// <summary>
            /// Shows how to reject all changes in Word document.
            /// Feature is supported by version 17.05 or greater
            /// </summary>
            public static void RejectAllChanges() {
                //ExStart:RejectAllChanges
                // initialize DocFormat
                using (DocFormat docFormat = new DocFormat(Common.MapSourceFilePath(filePath)))
                {

                    // get revisions
                    RevisionCollection revisionCollection = docFormat.Revisions;

                    // reject all revisions
                    revisionCollection.RejectAll();

                    // and commit changes
                    docFormat.Save(); 
                }
                //ExEnd:RejectAllChanges
            }
            #endregion

            ///<summary>
            ///Reads calculated document info for MS Word format
            ///</summary>
            public static void ReadDocumentInfo()
            {
                //ExStart:ReadDocumentInfo
                // initialize DocFormat
                using (DocFormat docFormat = new DocFormat(Common.MapSourceFilePath(filePath)))
                {

                    // get document info
                    DocumentInfo documentInfo = docFormat.DocumentInfo;

                    // display characters count
                    long charactersCount = documentInfo.CharactersCount;
                    Console.WriteLine("Characters count: {0}", charactersCount);

                    // display pages count
                    int pagesCount = documentInfo.PagesCount;
                    Console.WriteLine("Pages count: {0}", pagesCount); 
                }
                //ExEnd:ReadDocumentInfo 
            }

            ///<summary>
            ///Displays file type of the Word document
            ///</summary>
            public static void DisplayFileType()
            {
                //ExStart:DisplayFileType
                // initialize DocFormat
                using (DocFormat docFormat = new DocFormat(Common.MapSourceFilePath(filePath)))
                {

                    // display file type
                    switch (docFormat.FileType)
                    {
                        case FileType.Doc:
                            Console.WriteLine("Old binary document");
                            break;

                        case FileType.Docx:
                            Console.WriteLine("XML-based document");
                            break;
                    } 
                }
                //ExEnd:DisplayFileType
            }

            ///<summary>
            ///Reads Digital signatre in Word Document
            ///</summary>
            public static void ReadDigitalSignature()
            {
                //ExStart:ReadDigitalSignature
                // initialize DocFormat
                using (DocFormat docFormat = new DocFormat(Common.MapSourceFilePath(filePath)))
                {

                    // if document contains digital signatures
                    if (docFormat.HasDigitalSignatures)
                    {
                        // then inspect it
                        var inspectionResult = docFormat.InspectDocument();

                        // and get digital signatures
                        DigitalSignature[] signatures = inspectionResult.DigitalSignatures;

                        foreach (DigitalSignature signature in signatures)
                        {
                            // get certificate subject
                            Console.WriteLine("Certificate subject: {0}", signature.CertificateSubject);

                            // get certificate sign time
                            Console.WriteLine("Signed time: {0}", signature.SignTime);
                        }
                    } 
                }
                //ExEnd:ReadDigitalSignature
            }

            ///<summary>
            ///Removes digital signature from word document
            ///</summary>
            public static void RemoveDigitalSignature()
            {
                //ExStart:RemoveDigitalSignature
                // initialize DocFormat
                using (DocFormat docFormat = new DocFormat(Common.MapSourceFilePath(filePath)))
                {

                    // if document contains digital signatures
                    if (docFormat.HasDigitalSignatures)
                    {
                        // then remove them
                        docFormat.RemoveHiddenData(new DocInspectionOptions(DocInspectorOptionsEnum.DigitalSignatures));

                        // and commit changes
                        docFormat.Save();
                    } 
                }
                //ExEnd:RemoveDigitalSignature
            }

        }

        public static class EPUB
        {
            // initialize file path
            //ExStart:SourceEPUBFilePath
            private const string filePath = "Documents/Epub/sample.epub";
            //ExEnd:SourceEPUBFilePath

            public static void DetectEPUBFormat()
            {
                //ExStart:DetectEPUBFormat
                //using FormatFactory
                EpubFormat epubFormat = (EpubFormat)FormatFactory.RecognizeFormat(Common.MapSourceFilePath(filePath));
                // or
                // just try to open
                //EpubFormat epubFormat = new EpubFormat(file);
                if (epubFormat.Type.ToString().ToLower() == "epub")
                {
                    Console.WriteLine("File has valid EPUB Format");
                }
                //ExEnd:DetectEPUBFormat

            }

            public static void ReadEPUBFormatMetadata()
            {
                //ExStart:ReadEPUBFormatMetadata

                // open EPUB file
                using (EpubFormat epub = new EpubFormat(Common.MapSourceFilePath(filePath)))
                {

                    // read EPUB metadata
                    EpubMetadata metadata = epub.GetEpubMetadata();

                    // get keys
                    string[] keys = metadata.Keys;

                    foreach (string key in keys)
                    {
                        // get next metadata property
                        MetadataProperty property = metadata[key];

                        // and print it
                        Console.WriteLine(property);
                    } 
                }
                //ExEnd:ReadEPUBFormatMetadata
            }

            public static void ReadDublinCoreMetadata()
            {
                // open EPUB file
                using (EpubFormat epub = new EpubFormat(Common.MapSourceFilePath(filePath)))
                {

                    // read dublin-core metadata
                    DublinCoreMetadata dublinCore = epub.GetDublinCore();

                    // get creator
                    string creator = dublinCore.Creator;

                    // get publisher
                    string publisher = dublinCore.Publisher;

                    // get contributor
                    string contributor = dublinCore.Contributor; 
                }
            }
            /// <summary>
            /// Read Image cover from EPUB format
            /// Feature is supported in version 18.2 or greater of the API
            /// </summary>
            public static void ReadImageCover()
            {
                try
                {
                    // open EPUB file
                    using (EpubFormat epub = new EpubFormat(Common.MapSourceFilePath(filePath)))
                    {
                        // read image cover as array of bytes
                        byte[] imageCoverData = epub.GetImageCoverBytes();

                        // check if cover is exist
                        if (imageCoverData != null)
                        {
                            // create stream
                            using (MemoryStream stream = new MemoryStream(imageCoverData))
                            {
                                // get image type
                                using (ImageFormat image = ImageFormat.FromStream(stream))
                                {

                                    // display MIME type
                                    Console.WriteLine("Image type: {0}", image.MIMEType);

                                    // display dimensions
                                    Console.WriteLine("width: {0}, height: {1}", image.Width, image.Height);

                                    // and store it to the file system
                                    image.Save(string.Format(Common.MapSourceFilePath(filePath), image.Type)); 
                                }
                            }
                        }
                    }

                }
                catch (Exception exp)
                {

                    Console.WriteLine(exp.Message);
                }
                
            }
            /// <summary>
            /// Read Epub package version
            /// Feature is supported in version 18.2 or greater of the API
            /// </summary>
            public static void ReadEPUBPackageVersion()
            {
                try
                {
                    // open EPUB file
                    using (EpubFormat epub = new EpubFormat(Common.MapSourceFilePath(filePath)))
                    {
                        // read EPUB metadata
                        EpubMetadata metadata = epub.GetEpubMetadata();

                        // and get version
                        Console.WriteLine("Version = {0}", metadata.Version);
                    }
                }
                catch (Exception exp)
                {

                    Console.WriteLine(exp.Message);
                }
            }
            /// <summary>
            /// Read Dublin Core Medata using MetadataUtility
            /// Feature is supported in version 18.4 or greater of the API
            /// </summary>
            public static void ReadDublinCoreMetadataUtility()
            {
                try
                {
                    // read dublin-core metadata
                    DublinCoreMetadata dublinCore = (DublinCoreMetadata)MetadataUtility.ExtractSpecificMetadata(Common.MapSourceFilePath(filePath), MetadataType.DublinCore);

                    // get creator
                    Console.WriteLine("Creator = {0}", dublinCore.Creator);

                    // get publisher
                    Console.WriteLine("Publisher = {0}", dublinCore.Publisher);

                    // get contributor
                    Console.WriteLine("Contributor = {0}", dublinCore.Contributor);

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            /// <summary>
            /// Read ImageCover using Metadata Utility 
            /// Feature is supported in version 18.4 or greater of the API
            /// </summary>
            public static void ReadImageCoverMetadataUtility()
            {
                try
                {
                    //Read DublinCore Metadata
                    ThumbnailMetadata thumbnailMetadata = (ThumbnailMetadata)MetadataUtility.ExtractSpecificMetadata(Common.MapSourceFilePath(filePath), MetadataType.Thumbnail);

                    if (thumbnailMetadata!=null)
                    {
                        // get Mime Type 
                        Console.WriteLine(thumbnailMetadata.MimeType);
                        // get Length 
                        Console.WriteLine(thumbnailMetadata.ImageData.Length);

                    }
                            
                }
                catch (Exception exp)
                {

                    Console.WriteLine(exp.Message);
                }
            }

            public static void GetMetadataUsingStream()
            {
                try
                {
                    using (Stream stream = File.Open(Common.MapSourceFilePath(filePath), FileMode.Open, FileAccess.ReadWrite))
                    {
                        using (EpubFormat format = new EpubFormat(stream))
                        {
                            // read dublin-core metadata
                            DublinCoreMetadata dublinCore = format.GetDublinCore();
                            // Working with the epub book metadata

                            // get creator
                            Console.WriteLine("Creator = {0}", dublinCore.Creator);

                            // get publisher
                            Console.WriteLine("Publisher = {0}", dublinCore.Publisher);

                            // get contributor
                            Console.WriteLine("Contributor = {0}", dublinCore.Contributor);
                        }
                        // The stream is still open here
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    

        public static class Pdf
        {
            // initialize file path
            //ExStart:SourcePdfFilePath
            private const string filePath = "Documents/Pdf/sample.pdf";
            //ExEnd:SourcePdfFilePath
            #region working with builtin document properties
            /// <summary>
            /// Gets builtin document properties of Pdf file  
            /// </summary> 
            public static void GetDocumentProperties()
            {
                try
                {
                    //ExStart:GetBuiltinDocumentPropertyPdfFormat
                    // initialize Pdfformat
                    using (PdfFormat pdfFormat = new PdfFormat(Common.MapSourceFilePath(filePath)))
                    {

                        // initialize PdfMetadata
                        PdfMetadata pdfMetadata = pdfFormat.DocumentProperties;

                        // built-in properties
                        Console.WriteLine("Built-in Properties");
                        foreach (KeyValuePair<string, PropertyValue> property in pdfMetadata)
                        {
                            // check if built-in property
                            if (pdfMetadata.IsBuiltIn(property.Key))
                            {
                                Console.WriteLine("{0} : {1}", property.Key, property.Value);
                            }
                        } 
                    }
                    //ExEnd:GetBuiltinDocumentPropertyPdfFormat
                }
                catch (Exception exp)
                {
                    Console.WriteLine(exp.Message);
                }
            }
            /// <summary>
            /// Updates document properties of Pdf file and creates output file
            /// </summary> 
            public static void UpdateDocumentProperties()
            {
                try
                {

                    //ExStart:UpdateBuiltinDocumentPropertyPdfFormat
                    // initialize PdfFormat
                    using (PdfFormat pdfFormat = new PdfFormat(Common.MapSourceFilePath(filePath)))
                    {

                        // initialize PdfMetadata
                        PdfMetadata pdfMetadata = pdfFormat.DocumentProperties;

                        //update document property...
                        pdfMetadata.Author = "New author";
                        pdfMetadata.Subject = "New subject";
                        pdfMetadata.CreatedDate = DateTime.Now;

                        //save output file...
                        pdfFormat.Save(Common.MapDestinationFilePath(filePath));
                        //ExEnd:UpdateBuiltinDocumentPropertyPdfFormat
                        Console.WriteLine("File saved in destination folder."); 
                    }

                }
                catch (Exception exp)
                {
                    Console.WriteLine(exp.Message);
                }

            }
            /// <summary>
            /// Removes document properties of Pdf file and creates output file
            /// </summary> 
            public static void RemoveDocumentProperties()
            {
                try
                {
                    //ExStart:RemoveBuiltinDocumentPropertyPdfFormat
                    // initialize PdfFormat
                    using (PdfFormat pdfFormat = new PdfFormat(Common.MapSourceFilePath(filePath)))
                    {

                        pdfFormat.CleanMetadata();

                        //save output file...
                        pdfFormat.Save(Common.MapDestinationFilePath(filePath));
                        //ExEnd:RemoveBuiltinDocumentPropertyPdfFormat

                        Console.WriteLine("File saved in destination folder."); 
                    }


                }
                catch (Exception exp)
                {
                    Console.WriteLine(exp.Message);
                }
            }
            #endregion

            #region working with custom properties
            /// <summary>
            /// Adds custom property in Pdf file and creates output file
            /// </summary> 
            public static void AddCustomProperty()
            {
                try
                {
                    //ExStart:AddCustomDocumentPropertyPdfFormat
                    // initialize PdfFormat
                    using (PdfFormat pdfFormat = new PdfFormat(Common.MapSourceFilePath(filePath)))
                    {

                        // initialize PdfMetadata
                        PdfMetadata metadata = pdfFormat.DocumentProperties;

                        string propertyName = "New Custom Property";
                        string propertyValue = "123";


                        // check if property already exists
                        if (!metadata.ContainsKey(propertyName))
                        {
                            // add property
                            metadata.Add(propertyName, propertyValue);
                        }

                        // save file in destination folder
                        pdfFormat.Save(Common.MapDestinationFilePath(filePath));
                        //ExEnd:AddCustomDocumentPropertyPdfFormat
                        Console.WriteLine("File saved in destination folder."); 
                    }


                }
                catch (Exception exp)
                {
                    Console.WriteLine(exp.Message);
                }
            }
            /// <summary>
            /// Gets custom properties of Pdf file
            /// </summary>
            public static void GetCustomProperties()
            {
                try
                {
                    //ExStart:GetCustomDocumentPropertiesPdfFormat
                    // initialize Pdfformat
                    using (PdfFormat pdfFormat = new PdfFormat(Common.MapSourceFilePath(filePath)))
                    {

                        // initialize PdfMetadata
                        PdfMetadata pdfMetadata = pdfFormat.DocumentProperties;

                        Console.WriteLine("\nCustom Properties");
                        foreach (KeyValuePair<string, PropertyValue> keyValuePair in pdfMetadata)
                        {
                            // check if property is not built-in
                            if (!pdfMetadata.IsBuiltIn(keyValuePair.Key))
                            {
                                // get property value
                                PropertyValue propertyValue = pdfMetadata[keyValuePair.Key];
                                Console.WriteLine("Key: {0}, Type:{1}, Value: {2}", keyValuePair.Key, propertyValue.Type, propertyValue);
                            }
                        } 
                    }
                    //ExEnd:GetCustomDocumentPropertiesPdfFormat
                }
                catch (Exception exp)
                {
                    Console.WriteLine(exp.Message);
                }
            }
            /// <summary>
            /// Removes custom property of Pdf file and creates output file
            /// </summary> 
            public static void RemoveCustomProperties()
            {
                try
                {
                    //ExStart:RemoveCustomDocumentPropertiesPdfFormat
                    // initialize PdfFormat
                    using (PdfFormat pdfFormat = new PdfFormat(Common.MapSourceFilePath(filePath)))
                    {

                        // initialize PdfMetadata
                        PdfMetadata metadata = pdfFormat.DocumentProperties;

                        string propertyName = "New Custom Property";

                        // check if property is not built-in
                        if (!metadata.IsBuiltIn(propertyName))
                        {
                            // remove property
                            metadata.Remove(propertyName);
                        }
                        else
                        {
                            Console.WriteLine("Can not remove built-in property.");
                        }

                        // save file in destination folder
                        pdfFormat.Save(Common.MapDestinationFilePath(filePath));
                        //ExEnd:RemoveCustomDocumentPropertiesPdfFormat
                        Console.WriteLine("File saved in destination folder."); 
                    }

                }
                catch (Exception exp)
                {
                    Console.WriteLine(exp.Message);
                }
            }
            /// <summary>
            /// Clears custom properties of Pdf file and creates output file
            /// </summary> 
            public static void ClearCustomProperties()
            {
                try
                {
                    //ExStart:ClearCustomPropertyPdfFormat
                    // initialize PdfFormat
                    using (PdfFormat PdfFormat = new PdfFormat(Common.MapSourceFilePath(filePath)))
                    {

                        // use one of the following methods
                        // method:1 - clear custom properties 
                        PdfFormat.ClearCustomProperties();

                        // method:2 - clear custom properties
                        PdfFormat.DocumentProperties.ClearCustomData();

                        // save file in destination folder
                        PdfFormat.Save(Common.MapDestinationFilePath(filePath));
                        //ExEnd:ClearCustomPropertyPdfFormat
                        Console.WriteLine("File saved in destination folder."); 
                    }

                }
                catch (Exception exp)
                {
                    Console.WriteLine(exp.Message);
                }
            }
            #endregion

            #region working with XMP data
            /// <summary>
            /// Gets XMP Data of Pdf file  
            /// </summary> 
            public static void GetXMPProperties()
            {
                try
                {
                    //ExStart:GetXMPPropertiesPdfFormat
                    // initialize Pdfformat
                    using (PdfFormat pdfFormat = new PdfFormat(Common.MapSourceFilePath(filePath)))
                    {

                        // get pdf schema
                        PdfPackage pdfPackage = pdfFormat.XmpValues.Schemes.Pdf;

                        Console.WriteLine("Keywords: {0}", pdfPackage.Keywords);
                        Console.WriteLine("PdfVersion: {0}", pdfPackage.PdfVersion);
                        Console.WriteLine("Producer: {0}", pdfPackage.Producer); 
                    }
                    //ExEnd:GetXMPPropertiesPdfFormat
                }
                catch (Exception exp)
                {
                    Console.WriteLine(exp.Message);
                }
            }

            /// <summary>
            /// Retrieves all XMP keys from PDF document  
            /// </summary> 
            public static void GetXMPPropertiesUsingKey(string directoryPath)
            {
                try
                {
                    //ExStart:GetXMPKeysPdfFormat
                    // get PDF files only
                    string[] files = Directory.GetFiles(Common.MapSourceFilePath(directoryPath), "*.pdf");

                    foreach (string path in files)
                    {
                        // try to get XMP metadata
                        Metadata metadata = MetadataUtility.ExtractSpecificMetadata(path, MetadataType.XMP);

                        // skip if file does not contain XMP metadata
                        if (metadata == null)
                        {
                            continue;
                        }

                        // cast to XmpMetadata
                        XmpMetadata xmpMetadata = metadata as XmpMetadata;

                        // and display all xmp keys
                        foreach (string key in xmpMetadata.Keys)
                        {
                            Console.WriteLine(key);
                        }
                    }
                    //ExEnd:GetXMPKeysPdfFormat
                }
                catch (Exception exp)
                {
                    Console.WriteLine(exp.Message);
                }
            }

            /// <summary>
            /// Updates XMP Data of Pdf file  
            /// </summary> 
            public static void UpdateXMPProperties()
            {
                try
                {
                    //ExStart:UpdateXMPPropertiesPdfFormat
                    // initialize Pdfformat
                    using (PdfFormat pdfFormat = new PdfFormat(Common.MapSourceFilePath(filePath)))
                    {

                        // get pdf schema
                        PdfPackage pdfPackage = pdfFormat.XmpValues.Schemes.Pdf;

                        // update keywords
                        pdfPackage.Keywords = "literature, programming";

                        // update pdf version
                        pdfPackage.PdfVersion = "1.0";

                        // pdf:Producer could not be updated
                        //pdfPackage.Producer="";

                        //save output file...
                        pdfFormat.Save(Common.MapDestinationFilePath(filePath)); 
                    }
                    //ExEnd:UpdateXMPPropertiesPdfFormat
                }
                catch (Exception exp)
                {
                    Console.WriteLine(exp.Message);
                }
            }
            #endregion

            #region Working with Hidden Data
            public static void RemoveHiddenData()
            {
                try
                {
                    //ExStart:RemoveHiddenDataPdfFormat
                    // initialize Pdfformat
                    using (PdfFormat pdfFormat = new PdfFormat(Common.MapSourceFilePath(filePath)))
                    {

                        // inspect document
                        PdfInspectionResult inspectionResult = pdfFormat.InspectDocument();

                        // get annotations
                        PdfAnnotation[] annotation = inspectionResult.Annotations;

                        // if annotations are presented
                        if (annotation.Length > 0)
                        {
                            // remove all annotation
                            pdfFormat.RemoveHiddenData(new PdfInspectionOptions(PdfInspectorOptionsEnum.Annotations));

                            //save output file...
                            pdfFormat.Save(Common.MapDestinationFilePath(filePath));
                        } 
                    }
                    //ExEnd:RemoveHiddenDataPdfFormat
                }
                catch (Exception exp)
                {
                    Console.WriteLine(exp.Message);
                }
            }
            #endregion

            /// <summary>
            /// Loads Only Existing Metadata Keys into PdfMetadata Class
            /// Feature is supported by version 17,03 or greater 
            /// </summary>
            public static void LoadExistingMetadataKeys()
            {
                try
                {
                    //ExStart:LoadExistingMetadataKeys
                    // initialize PdfFormat
                    using (PdfFormat pdfFormat = new PdfFormat(Common.MapSourceFilePath(filePath)))
                    {

                        // get pdf properties
                        PdfMetadata properties = pdfFormat.DocumentProperties;

                        // go through Keys property and display related PDF properties
                        foreach (string key in properties.Keys)
                        {
                            Console.WriteLine("[{0}]={1}", key, properties[key]);
                        } 
                    }
                    //ExEnd:LoadExistingMetadataKeys
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            /// <summary>
            /// Read DublinCore Metadata using Metadata Utility 
            /// Feature is supported in version 18.4 or greater of the API
            /// </summary>
            public static void ReadDublinCoreMetadata()
            {
                try
                {
                    // read dublin-core metadata
                    DublinCoreMetadata dublinCore = (DublinCoreMetadata)MetadataUtility.ExtractSpecificMetadata(Common.MapSourceFilePath(filePath), MetadataType.DublinCore);

                    // get creator
                    Console.WriteLine("Creator = {0}", dublinCore.Creator);

                    // get publisher
                    Console.WriteLine("Publisher = {0}", dublinCore.Publisher);

                    // get contributor
                    Console.WriteLine("Contributor = {0}", dublinCore.Contributor);

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public static class Ppt
        {
            // initialize file path
            //ExStart:SourcePptFilePath
            private const string filePath = "Documents/Ppt/sample.pptx";
            //ExEnd:SourcePptFilePath
            #region working with builtin document properties
            /// <summary>
            /// Gets builtin document properties of Ppt file  
            /// </summary> 
            public static void GetDocumentProperties()
            {
                try
                {
                    // ExStart:GetBuiltinDocumentPropertiesPptFormat
                    // initialize PptFormat
                    PptFormat pptFormat = new PptFormat(Common.MapSourceFilePath(filePath));

                    // initialize PptMetadata
                    PptMetadata pptMetadata = pptFormat.DocumentProperties;

                    // built-in properties
                    Console.WriteLine("\nBuilt-in Properties");
                    foreach (KeyValuePair<string, PropertyValue> property in pptMetadata)
                    {
                        if (pptMetadata.IsBuiltIn(property.Key))
                        {
                            Console.WriteLine("{0} : {1}", property.Key, property.Value);
                        }
                    }
                    //ExEnd:GetBuiltinDocumentPropertiesPptFormat
                }
                catch (Exception exp)
                {
                    Console.WriteLine(exp.Message);
                }
            }
            /// <summary>
            /// Updates document properties of Ppt file and creates output file
            /// </summary> 
            public static void UpdateDocumentProperties()
            {
                try
                {
                    //ExStart:UpdateBuiltinDocumentPropertiesPptFormat
                    // initialize PptFormat
                    PptFormat pptFormat = new PptFormat(Common.MapSourceFilePath(filePath));

                    // initialize PptMetadata
                    PptMetadata pptMetadata = pptFormat.DocumentProperties;

                    // update document property
                    pptMetadata.Author = "New author";
                    pptMetadata.Subject = "New subject";
                    pptMetadata.Manager = "Usman";

                    // set content type
                    pptMetadata.ContentType = "content type";

                    // set hyperlink base
                    pptMetadata.HyperlinkBase = "http://groupdocs.com";

                    // mark as shared
                    pptMetadata.SharedDoc = true;

                    //save output file...
                    pptFormat.Save(Common.MapDestinationFilePath(filePath));
                    //ExEnd:UpdateBuiltinDocumentPropertiesPptFormat
                    Console.WriteLine("File saved in destination folder.");

                }
                catch (Exception exp)
                {
                    Console.WriteLine(exp.Message);
                }

            }
            /// <summary>
            /// Removes document properties of Ppt file and creates output file
            /// </summary> 
            public static void RemoveDocumentProperties()
            {
                try
                {
                    //ExStart:RemoveBuiltinDocumentPropertiesPptFormat
                    // initialize PptFormat
                    PptFormat pptFormat = new PptFormat(Common.MapSourceFilePath(filePath));

                    // clean metadata
                    pptFormat.CleanMetadata();

                    // save output file...
                    pptFormat.Save(Common.MapDestinationFilePath(filePath));
                    //ExEnd:RemoveBuiltinDocumentPropertiesPptFormat
                    Console.WriteLine("File saved in destination folder.");


                }
                catch (Exception exp)
                {
                    Console.WriteLine(exp.Message);
                }
            }

            /// <summary>
            /// Reads document properties of Ppt file in an improved and fast way
            /// </summary> 
            public static void ImprovedMetadataReading()
            {
                //ExStart:ImprovedMetadataReadingPpt
                //initialize ppt format
                PptFormat ppt = new PptFormat(Common.MapSourceFilePath(filePath));
                //use faster way to read metadata properties of ppt document
                var properties = ppt.DocumentProperties;
                Console.WriteLine(properties);
                //ExEnd:ImprovedMetadataReadingPpt
            }
            #endregion

            #region working with custom properties
            /// <summary>
            /// Adds custom property in Ppt file and creates output file
            /// </summary> 
            public static void AddCustomProperty()
            {
                try
                {
                    //ExStart:AddCustomDocumentPropertiesPptFormat
                    // initialize PptFormat
                    PptFormat pptFormat = new PptFormat(Common.MapSourceFilePath(filePath));

                    // initialize PptMetadata
                    PptMetadata metadata = pptFormat.DocumentProperties;

                    // set property details 
                    string propertyName = "New custom property";
                    string propertyValue = "Value";

                    // check if property already exists
                    if (!metadata.ContainsKey(propertyName))
                    {
                        // add property
                        metadata.Add(propertyName, propertyValue);
                    }

                    // save file in destination folder
                    pptFormat.Save(Common.MapDestinationFilePath(filePath));
                    //ExEnd:AddCustomDocumentPropertiesPptFormat
                    Console.WriteLine("File saved in destination folder.");


                }
                catch (Exception exp)
                {
                    Console.WriteLine(exp.Message);
                }
            }
            /// <summary>
            /// Gets custom properties of Ppt file  
            /// </summary> 
            public static void GetCustomProperties()
            {
                try
                {
                    //ExStart:GetCustomDocumentPropertiesPptFormat
                    // initialize PptFormat
                    PptFormat pptFormat = new PptFormat(Common.MapSourceFilePath(filePath));

                    // initialize PptMetadata
                    PptMetadata pptMetadata = pptFormat.DocumentProperties;

                    Console.WriteLine("\nCustom Properties");
                    foreach (KeyValuePair<string, PropertyValue> keyValuePair in pptMetadata)
                    {
                        // check if property is not built-in
                        if (!pptMetadata.IsBuiltIn(keyValuePair.Key))
                        {
                            // get property value
                            PropertyValue propertyValue = pptMetadata[keyValuePair.Key];
                            Console.WriteLine("Key: {0}, Type:{1}, Value: {2}", keyValuePair.Key, propertyValue.Type, propertyValue);
                        }
                    }
                    //ExEnd:GetCustomDocumentPropertiesPptFormat
                }
                catch (Exception exp)
                {
                    Console.WriteLine(exp.Message);
                }
            }
            /// <summary>
            /// Removes custom property of Ppt file and creates output file
            /// </summary> 
            public static void RemoveCustomProperties()
            {
                try
                {
                    //ExStart:RemoveCustomDocumentPropertiesPptFormat
                    // initialize PptFormat
                    PptFormat pptFormat = new PptFormat(Common.MapSourceFilePath(filePath));

                    // initialize PptMetadata
                    PptMetadata metadata = pptFormat.DocumentProperties;

                    string propertyName = "New custom property";

                    // check if property is not built-in
                    if (!metadata.IsBuiltIn(propertyName))
                    {
                        // remove property
                        metadata.Remove(propertyName);
                    }
                    else
                    {
                        Console.WriteLine("Can not remove built-in property.");
                    }

                    // save file in destination folder
                    pptFormat.Save(Common.MapDestinationFilePath(filePath));
                    //ExEnd:RemoveCustomDocumentPropertiesPptFormat
                    Console.WriteLine("File saved in destination folder.");

                }
                catch (Exception exp)
                {
                    Console.WriteLine(exp.Message);
                }
            }
            /// <summary>
            /// Clears custom properties of Ppt file and creates output file
            /// </summary> 
            public static void ClearCustomProperties()
            {
                try
                {
                    //ExStart:ClearCustomPropertyPptFormat
                    // initialize PptFormat
                    PptFormat PptFormat = new PptFormat(Common.MapSourceFilePath(filePath));

                    // use one of the following methods
                    // method:1 - clear custom properties
                    PptFormat.ClearCustomProperties();

                    // method:2 - clear custom properties 
                    PptFormat.DocumentProperties.ClearCustomData();

                    // save file in destination folder
                    PptFormat.Save(Common.MapDestinationFilePath(filePath));
                    //ExEnd:ClearCustomPropertyPptFormat
                    Console.WriteLine("File saved in destination folder.");

                }
                catch (Exception exp)
                {
                    Console.WriteLine(exp.Message);
                }
            }
            #endregion

            #region working with hidden fields
            /// <summary>
            /// Gets Comments, and Hidden Slides of PowerPoint file
            /// </summary> 
            public static void GetHiddenData()
            {
                try
                {
                    //ExStart:GetHiddenDataInPPT
                    // initialize PptFormat
                    PptFormat pptFormat = new PptFormat(Common.MapSourceFilePath(filePath));

                    // get hidden data
                    PptInspectionResult hiddenData = pptFormat.InspectDocument();

                    // get comments
                    PptComment[] comments = hiddenData.Comments;

                    // get slides
                    PptSlide[] slides = hiddenData.HiddenSlides;

                    foreach (PptComment comment in comments)
                    {
                        Console.WriteLine("Author: {0}, Slide: {1}", comment.Author, comment.SlideId);
                    }
                    //ExEnd:GetHiddenDataInPPT
                }
                catch (Exception exp)
                {
                    Console.WriteLine(exp.Message);
                }
            }


            /// <summary>
            /// Removes Comments, and Hidden Slides of PowerPoint file
            /// </summary> 
            public static void RemoveHiddenData()
            {
                try
                {
                    //ExStart:RemoveHiddenDataInPPT
                    // initialize PptFormat
                    PptFormat pptFormat = new PptFormat(Common.MapSourceFilePath(filePath));

                    // get hidden data
                    PptInspectionResult hiddenData = pptFormat.InspectDocument();

                    // get comments
                    PptComment[] comments = hiddenData.Comments;

                    if (comments.Length > 0)
                    {
                        // remove all comments
                        pptFormat.RemoveHiddenData(new PptInspectionOptions(PptInspectorOptionsEnum.Comments));
                        Console.WriteLine("Comments removed.");

                        // and commit changes
                        pptFormat.Save();
                        Console.WriteLine("Changes saved successfully!");
                    }
                    else
                    {
                        Console.WriteLine("No comments found!");
                    }
                    //ExEnd:RemoveHiddenDataInPPT

                }
                catch (Exception exp)
                {
                    Console.WriteLine(exp.Message);
                }
            }

            #endregion
        }

        public static class Xls
        {
            // initialize file path
            //ExStart:SourceXlsFilePath
            private const string filePath = "Documents/Xls/sample.xls";
            //ExEnd:SourceXlsFilePath

            //initialize output file path
            //ExStart:DestinationXlsFilePath
            private const string outputFilePath = "Documents/Xls/metadata-xls.xls";
            private const string outputFilePathWithHiddenData = "Documents/Xls/hidden-data.xls";
            //ExEnd:DestinationXlsFilePath
            #region working with builtin document properties
            /// <summary>
            /// Gets builtin document properties of Xls file  
            /// </summary> 
            public static void GetDocumentProperties()
            {
                try
                {

                    //ExStart:GetBuiltinDocumentPropertiesXlsFormat
                    // initialize XlsFormat
                    using (XlsFormat xlsFormat = new XlsFormat(Common.MapSourceFilePath(filePath)))
                    {

                        // initialize XlsMetadata
                        XlsMetadata xlsMetadata = xlsFormat.DocumentProperties;

                        // built-in properties
                        Console.WriteLine("\nBuilt-in Properties");
                        foreach (KeyValuePair<string, PropertyValue> property in xlsMetadata)
                        {
                            // check if property is biltin
                            if (xlsMetadata.IsBuiltIn(property.Key))
                            {
                                Console.WriteLine("{0} : {1}", property.Key, property.Value);
                            }
                        } 
                    }
                    //ExEnd:GetBuiltinDocumentPropertiesXlsFormat
                }
                catch (Exception exp)
                {
                    Console.WriteLine(exp.Message);
                }
            }
            /// <summary>
            /// Updates document properties of Xls file and creates output file
            /// </summary> 
            public static void UpdateDocumentProperties()
            {
                try
                {
                    //ExStart:UpdateBuiltinDocumentPropertiesXlsFormat
                    // initialize XlsFormat
                    using (XlsFormat xlsFormat = new XlsFormat(Common.MapSourceFilePath(filePath)))
                    {

                        // initialize XlsMetadata
                        XlsMetadata xlsMetadata = xlsFormat.DocumentProperties;

                        //update document property...
                        xlsMetadata.Author = "New author";
                        xlsMetadata.Subject = "New subject";

                        //save output file...
                        xlsFormat.Save(Common.MapDestinationFilePath(filePath));
                        //ExEnd:UpdateBuiltinDocumentPropertiesXlsFormat
                        Console.WriteLine("File saved in destination folder."); 
                    }

                }
                catch (Exception exp)
                {
                    Console.WriteLine(exp.Message);
                }

            }
            /// <summary>
            /// Removes document properties of Xls file and creates output file
            /// </summary> 
            public static void RemoveDocumentProperties()
            {
                try
                {
                    //ExStart:RemoveBuiltinDocumentPropertiesXlsFormat
                    // initialize XlsFormat
                    using (XlsFormat xlsFormat = new XlsFormat(Common.MapSourceFilePath(filePath)))
                    {

                        // clean metadata
                        xlsFormat.CleanMetadata();

                        //save output file...
                        xlsFormat.Save(Common.MapDestinationFilePath(filePath));
                        //ExEnd:RemoveBuiltinDocumentPropertiesXlsFormat
                        Console.WriteLine("File saved in destination folder."); 
                    }


                }
                catch (Exception exp)
                {
                    Console.WriteLine(exp.Message);
                }
            }
            #endregion

            #region working with custom properties
            /// <summary>
            /// Adds custom property in Xls file and creates output file
            /// </summary> 
            public static void AddCustomProperty()
            {
                try
                {
                    //ExStart:AddCustomDocumentPropertiesXlsFormat
                    // initialize XlsFormat
                    using (XlsFormat xlsFormat = new XlsFormat(Common.MapSourceFilePath(filePath)))
                    {

                        // initialize XlsMetadata
                        XlsMetadata metadata = xlsFormat.DocumentProperties;

                        string propertyName = "New Custom Property";
                        string propertyValue = "123";

                        // check if property already exists
                        if (!metadata.ContainsKey(propertyName))
                        {
                            // add property
                            metadata.Add(propertyName, propertyValue);
                        }

                        // save file in destination folder
                        xlsFormat.Save(Common.MapDestinationFilePath(filePath));
                        //ExEnd:AddCustomDocumentPropertiesXlsFormat
                        Console.WriteLine("File saved in destination folder."); 
                    }


                }
                catch (Exception exp)
                {
                    Console.WriteLine(exp.Message);
                }
            }
            /// <summary>
            /// Gets custom properties of Xls file  
            /// </summary> 
            public static void GetCustomProperties()
            {
                try
                {
                    //ExStart:GetCustomDocumentPropertiesXlsFormat
                    // initialize XlsFormat
                    using (XlsFormat xlsFormat = new XlsFormat(Common.MapSourceFilePath(filePath)))
                    {

                        // initialize XlsMetadata
                        XlsMetadata xlsMetadata = xlsFormat.DocumentProperties;

                        Console.WriteLine("\nCustom Properties");
                        foreach (KeyValuePair<string, PropertyValue> keyValuePair in xlsMetadata)
                        {
                            // check if property is not built-in
                            if (!xlsMetadata.IsBuiltIn(keyValuePair.Key))
                            {
                                // get property value
                                PropertyValue propertyValue = xlsMetadata[keyValuePair.Key];
                                Console.WriteLine("Key: {0}, Type:{1}, Value: {2}", keyValuePair.Key, propertyValue.Type, propertyValue);
                            }
                        } 
                    }
                    //ExEnd:GetCustomDocumentPropertiesXlsFormat
                }
                catch (Exception exp)
                {
                    Console.WriteLine(exp.Message);
                }
            }
            /// <summary>
            /// Removes custom property of Xls file and creates output file
            /// </summary> 
            public static void RemoveCustomProperties()
            {
                try
                {
                    //ExStart:RemoveCustomDocumentPropertiesXlsFormat
                    // initialize XlsFormat
                    using (XlsFormat xlsFormat = new XlsFormat(Common.MapSourceFilePath(filePath)))
                    {

                        // initialize XlsMetadata
                        XlsMetadata metadata = xlsFormat.DocumentProperties;

                        string propertyName = "New Custom Property";

                        // check if property is not built-in
                        if (!metadata.IsBuiltIn(propertyName))
                        {
                            // remove property
                            metadata.Remove(propertyName);
                        }
                        else
                        {
                            Console.WriteLine("Can not remove built-in property.");
                        }

                        // save file in destination folder
                        xlsFormat.Save(Common.MapDestinationFilePath(filePath));
                        //ExEnd:RemoveCustomDocumentPropertiesXlsFormat
                        Console.WriteLine("File saved in destination folder."); 
                    }

                }
                catch (Exception exp)
                {
                    Console.WriteLine(exp.Message);
                }
            }
            /// <summary>
            /// Clears custom properties of Xls file and creates output file
            /// </summary> 
            public static void ClearCustomProperties()
            {
                try
                {
                    //ExStart:ClearCustomPropertyXlsFormat
                    // initialize XlsFormat
                    using (XlsFormat xlsFormat = new XlsFormat(Common.MapSourceFilePath(filePath)))
                    {

                        // use one of the following methods
                        // method:1 - clear custom properties
                        xlsFormat.ClearCustomProperties();

                        // method:2 - clear custom properties
                        xlsFormat.DocumentProperties.ClearCustomData();

                        // save file in destination folder
                        xlsFormat.Save(Common.MapDestinationFilePath(filePath));
                        //ExEnd:ClearCustomPropertyXlsFormat
                        Console.WriteLine("File saved in destination folder."); 
                    }

                }
                catch (Exception exp)
                {
                    Console.WriteLine(exp.Message);
                }
            }
            #endregion

            #region working with hidden fields
            /// <summary>
            /// Gets comments and hidden sheets of Xls file
            /// </summary> 
            public static void GetHiddenData()
            {
                try
                {
                    //ExStart:GetHiddenDataInXls
                    // initialize XlsFormat
                    using (XlsFormat xlsFormat = new XlsFormat(Common.MapSourceFilePath(filePath)))
                    {

                        // get hidden data
                        XlsInspectionResult hiddenData = xlsFormat.InspectDocument();

                        // get hidden sheets
                        XlsSheet[] hiddenSheets = hiddenData.HiddenSheets;

                        // get comments
                        XlsComment[] comments = hiddenData.Comments;

                        if (comments.Length > 0)
                        {
                            foreach (XlsComment comment in comments)
                            {
                                Console.WriteLine("Comment: {0}, Column: {1}", comment.ToString(), comment.Column);
                            }
                        }
                        else
                        {
                            Console.WriteLine("No comment found!");
                        } 
                    }
                    //ExEnd:GetHiddenDataInXls
                }
                catch (Exception exp)
                {
                    Console.WriteLine(exp.Message);
                }
            }
            /// <summary>
            /// Removes hidden data of Xls file
            /// </summary> 
            public static void RemoveHiddenData()
            {
                try
                {
                    //ExStart:RemoveHiddenDataInXls
                    // initialize XlsFormat
                    using (XlsFormat xlsFormat = new XlsFormat(Common.MapSourceFilePath(filePath)))
                    {

                        // get hidden data
                        XlsInspectionResult hiddenData = xlsFormat.InspectDocument();

                        // get hidden sheets
                        XlsSheet[] hiddenSheets = hiddenData.HiddenSheets;


                        // display hidden fields 
                        if (hiddenSheets.Length > 0)
                        {
                            // clear hidden sheets
                            xlsFormat.RemoveHiddenData(new XlsInspectionOptions(XlsInspectorOptionsEnum.HiddenSheets));
                            Console.WriteLine("Hidden sheets removed.");

                            // and commit changes
                            xlsFormat.Save();
                            Console.WriteLine("Changes save successfully!");
                        }
                        else
                            Console.WriteLine("No sheets found."); 
                    }
                    //ExEnd:RemoveHiddenDataInXls
                }
                catch (Exception exp)
                {
                    Console.WriteLine(exp.Message);
                }
            }
            #endregion

            #region working with content type document properties
            /// <summary>
            /// Gets content type document properties of Xls file  
            /// </summary> 
            public static void GetContentTypeDocumentProperties()
            {
                try
                {
                    //ExStart:GetContentTypeDocumentPropertiesXlsFormat
                    // initialize XlsFormat
                    using (XlsFormat xlsFormat = new XlsFormat(Common.MapSourceFilePath(filePath)))
                    {

                        // get xls properties
                        XlsMetadata xlsProperties = xlsFormat.DocumentProperties;

                        // get content properties
                        XlsContentProperty[] contentProperties = xlsProperties.ContentTypeProperties;

                        foreach (XlsContentProperty property in contentProperties)
                        {
                            Console.WriteLine("Property: {0}, value: {1}, type: {2}", property.Name, property.Value, property.PropertyType);
                        } 
                    }
                    //ExEnd:GetContentTypeDocumentPropertiesXlsFormat
                }
                catch (Exception exp)
                {
                    Console.WriteLine(exp.Message);
                }
            }
            #endregion

            #region working with exporting document properties
            /// <summary>
            /// Shows how to export content type properties to csv/excel
            /// </summary>
            public static void ContentTypePropertiesExport()
            {
                try
                {
                    //ExStart:ContentTypePropertiesExportXls
                    // export to excel
                    byte[] content = ExportFacade.ExportToExcel(Common.MapSourceFilePath(filePath));

                    // write data to the file
                    File.WriteAllBytes(Common.MapDestinationFilePath(outputFilePath), content);
                    //ExEnd:ContentTypePropertiesExportXls
                    Console.WriteLine("file has been exported");                    
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }

            /// <summary>
            /// shows how to add content type property
            /// </summary>
            public static void AddContentTypeProperty()
            {
                try
                {
                    //ExStart:AddContentTypePropertyXls
                    // initialize XlsFormat
                    using (XlsFormat xlsFormat = new XlsFormat(Common.MapSourceFilePath(filePath)))
                    {

                        // get all xls properties
                        XlsMetadata xlsProperties = xlsFormat.DocumentProperties;

                        // if Excel contains content type properties
                        if (xlsProperties.ContentTypeProperties.Length > 0)
                        {
                            // than remove all content type properties
                            xlsProperties.ClearContentTypeProperties();
                        }

                        // set hidden field
                        xlsProperties.AddContentTypeProperty("user hidden id", "asdk12dkvjdjh3");

                        // and commit changes
                        xlsFormat.Save(Common.MapDestinationFilePath(outputFilePathWithHiddenData));
                        //ExEnd:AddContentTypePropertyXls
                        Console.WriteLine("file has been exported"); 
                    }
                }

                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }


            #endregion

            /// <summary>
            /// Reads thumnail in excel file, since while using Excel format document may be empty. In this case need to check if thumbnail is not empty
            /// Feature is supported by version 17.3 or greater
            /// </summary>
            public static void ReadThumbnailXls()
            {
                try
                {
                    //ExStart:ReadThumbnailXls
                    // initialize XlsFormat
                    using (XlsFormat docFormat = new XlsFormat(Common.MapSourceFilePath(filePath)))
                    {

                        // get thumbnail
                        byte[] thumbnailData = docFormat.Thumbnail;

                        // check if first sheet is empty
                        if (thumbnailData.Length == 0)
                        {
                            Console.WriteLine("Excel sheet is empty and does not contain data");
                        }
                        else
                        {
                            // write thumbnail to PNG image since it has png format
                            File.WriteAllBytes(Common.MapDestinationFilePath("xlsThumbnail.png"), thumbnailData);
                        } 
                    }
                    //ExEnd:ReadThumbnailXls
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            /// <summary>
            /// Read ImageCover using Metadata Utility 
            /// Feature is supported in version 18.4 or greater of the API
            /// </summary>
            public static void ReadImageCoverMetadataUtility()
            {
                try
                {
                    //Read DublinCore Metadata
                    ThumbnailMetadata thumbnailMetadata = (ThumbnailMetadata)MetadataUtility.ExtractSpecificMetadata(Common.MapSourceFilePath(filePath), MetadataType.Thumbnail);

                    if (thumbnailMetadata != null)
                    {
                        // get Mime Type 
                        Console.WriteLine(thumbnailMetadata.MimeType);
                        // get Length 
                        Console.WriteLine(thumbnailMetadata.ImageData.Length);

                    }

                }
                catch (Exception exp)
                {

                    Console.WriteLine(exp.Message);
                }
            }
        }

        public static class OneNote
        {
            // initialize file path
            //ExStart:SourceOneNoteFilePath
            private const string filePath = "Documents/OneNote/sample.one";
            //ExEnd:SourceOneNoteFilePath

            /// <summary>
            /// Gets metadata of OneNote file  
            /// </summary> 
            public static void GetMetadata()
            {
                try
                {

                    //ExStart:GetMetadataOneNoteFormat
                    // initialize OneNoteFormat
                    using (OneNoteFormat oneNoteFormat = new OneNoteFormat(Common.MapSourceFilePath(filePath)))
                    {

                        // get metadata
                        var oneNoteMetadata = oneNoteFormat.GetMetadata();
                        if (oneNoteFormat != null)
                        {
                            // get IsFixedSize 
                            Console.WriteLine("IsFixedSize: {0}", oneNoteMetadata.IsFixedSize);
                            // get IsReadOnly 
                            Console.WriteLine("IsReadOnly: {0}", oneNoteMetadata.IsReadOnly);
                            // get IsSynchronized 
                            Console.WriteLine("IsSynchronized: {0}", oneNoteMetadata.IsSynchronized);
                            // get Length 
                            Console.WriteLine("Length: {0}", oneNoteMetadata.Length);
                            // get Rank 
                            Console.WriteLine("Rank: {0}", oneNoteMetadata.Rank);
                        } 
                    }
                    //ExEnd:GetMetadataOneNoteFormat
                }
                catch (Exception exp)
                {
                    Console.WriteLine(exp.Message);
                }
            }

            /// <summary>
            /// Gets pages of OneNote file  
            /// </summary> 
            public static void GetPagesInfo()
            {
                try
                {

                    //ExStart:GetPagesOneNoteFormat
                    // initialize OneNoteFormat
                    using (OneNoteFormat oneNoteFormat = new OneNoteFormat(Common.MapSourceFilePath(filePath)))
                    {

                        // get pages
                        OneNotePageInfo[] pages = oneNoteFormat.GetPages();

                        foreach (OneNotePageInfo info in pages)
                        {
                            // get Author 
                            Console.WriteLine("Author: {0}", info.Author);
                            // get CreationTime 
                            Console.WriteLine("CreationTime: {0}", info.CreationTime);
                            // get LastModifiedTime 
                            Console.WriteLine("LastModifiedTime: {0}", info.LastModifiedTime);
                            // get Title 
                            Console.WriteLine("Title: {0}", info.Title);

                            Console.WriteLine("\n\n");
                        } 
                    }
                    //ExEnd:GetPagesOneNoteFormat
                }
                catch (Exception exp)
                {
                    Console.WriteLine(exp.Message);
                }
            }


        }


        public static class MSProject
        {
            // initialize file path
            //ExStart:SourceMSProjectFilePath
            private const string filePath = "Documents/MSProject/sample.mpp";
            //ExEnd:SourceMSProjectFilePath

            /// <summary>
            /// Gets properties of MS Project file  
            /// </summary> 
            public static void GetMetadata()
            {
                try
                {
                    //ExStart:GetMetadataMppFormat
                    // initialize MppFormat
                    using (MppFormat mppFormat = new MppFormat(Common.MapSourceFilePath(filePath)))
                    {

                        // get document properties
                        MppMetadata properties = mppFormat.GetProperties();

                        if (mppFormat != null)
                        {
                            // get Author 
                            Console.WriteLine("Author: {0}", properties.Author);
                            // get Company 
                            Console.WriteLine("Company: {0}", properties.Company);
                            // get Keywords 
                            Console.WriteLine("Keywords: {0}", properties.Keywords);
                        } 
                    }
                    //ExEnd:GetMetadataMppFormat
                }
                catch (Exception exp)
                {
                    Console.WriteLine(exp.Message);
                }
            }
            /// <summary>
            /// Update MS Project Metadata
            /// Feature is supported in version 18.6 or greater of the API
            /// </summary>
            public static void UpdateMetadata()
            {
                using (MppFormat format = new MppFormat(Common.MapSourceFilePath(filePath)))
                {
                    format.ProjectInfo.Author = "John Smith";
                    format.ProjectInfo.Subject = "Test project";
                    format.ProjectInfo.Category = "Software Development";

                    format.Save(Common.MapDestinationFilePath(filePath));
                }
            }
            /// <summary>
            /// Clean MS Project Metadata
            /// Feature is supported in version 18.6 or greater of the API
            /// </summary>
            public static void CleanMetadata()
            {
                using(MppFormat format = new MppFormat(Common.MapSourceFilePath(filePath)))
                {
                    format.CleanMetadata();
                    format.Save(Common.MapDestinationFilePath(filePath));
                }
            }

            public static void UpdateMetadataUsingStream()
            {
                using (Stream stream = File.Open(Common.MapDestinationFilePath(filePath), FileMode.Open, FileAccess.ReadWrite))
                {
                    using (MppFormat format = new MppFormat(Common.MapSourceFilePath(filePath)))
                    {
                        format.ProjectInfo.Author = "John Smith";
                        format.ProjectInfo.Subject = "Test project";
                        format.ProjectInfo.Category = "Software Development";

                        format.Save(stream);
                    }
                    // The stream is still open here
                }
            }
        }

        public static class MSVisio
        {
            // initialize file path
            //ExStart:SourceMSProjectFilePath
            private const string filePath = "Documents/MSVisio/sample.vdx";
            //ExEnd:SourceMSProjectFilePath

            /// <summary>
            /// Gets properties of MS Visio file  
            /// </summary> 
            public static void GetMetadata()
            {
                try
                {
                    //ExStart:GetMetadataMppFormat
                    // initialize MppFormat
                    using (MppFormat mppFormat = new MppFormat(Common.MapSourceFilePath(filePath)))
                    {
                        // get document properties
                        MppMetadata properties = mppFormat.GetProperties();

                        if (mppFormat != null)
                        {
                            // get Author 
                            Console.WriteLine("Author: {0}", properties.Author);
                            // get Company 
                            Console.WriteLine("Company: {0}", properties.Title);
                        } 
                    }
                    //ExEnd:GetMetadataMppFormat
                }
                catch (Exception exp)
                {
                    Console.WriteLine(exp.Message);
                }
            }


            /// <summary>
            /// Sets properties of MS Project file  
            /// </summary> 
            public static void SetProperties()
            {
                // initialize VisioFormat
                using (VisioFormat visioFormat = new VisioFormat(Common.MapSourceFilePath(filePath)))
                {

                    // update creator
                    visioFormat.DocumentProperties.Creator = "John Doe";

                    // update title
                    visioFormat.DocumentProperties.Title = "Example Title";

                    // commit changes
                    visioFormat.Save();

                    Console.WriteLine("Creator: {0}: ", visioFormat.DocumentProperties.Creator);
                    Console.WriteLine("Title: {0}: ", visioFormat.DocumentProperties.Title); 
                }
            }
        }


        public static class ODT
        {
            //initialize file path
            //ExStart:SourceODTProjectFilePath
            private const string filePath = "Documents/Odt/sample.odt";
            //ExEnd:SourceODTProjectFilePath

            /// <summary>
            /// Gets properties of Open Document Format file  
            /// </summary> 
            public static void GetOdtMetadata()
            {
                try
                {
                    //ExStart:ReadOdtMetadata
                    // initialize DocFormat with ODT file's path
                    using (DocFormat docFormat = new DocFormat(Common.MapSourceFilePath(filePath)))
                    {
                        // read all metadata properties
                        Metadata metadata = docFormat.DocumentProperties;

                        // and display them
                        foreach (MetadataProperty property in metadata)
                        {
                            Console.WriteLine(property);
                        } 
                    }
                    //ExEnd:ReadOdtMetadata
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }


            }


            /// <summary>
            /// Updates properties of Open Document Format file  
            /// </summary> 
            public static void UpdateOdtMetadata()
            {
                try
                {
                    //ExStart:UpdateOdtMetadata
                    // initialize DocFormat with ODT file's path
                    using (DocFormat docFormat = new DocFormat(Common.MapSourceFilePath(filePath)))
                    {

                        // initialize DocMetadata
                        DocMetadata docMetadata = docFormat.DocumentProperties;

                        //update document property...
                        docMetadata.Author = "Rida ";
                        docMetadata.Company = "Aspose";
                        docMetadata.Manager = "Rida Fatima";

                        //save output file...
                        docFormat.Save(Common.MapDestinationFilePath(filePath));
                        //ExEnd:UpdateOdtMetadata
                        Console.WriteLine("Updated Successfully."); 
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }


            }
        }

        public class ODS {
            //initialize file path
            //ExStart:SourceOdsProjectFilePath
            private const string filePath = "Documents/Ods/sample.ods";
            //ExEnd:SourceOdsProjectFilePath

            /// <summary>
            /// Reads metadata in ODS format
            /// Feature is supported in version 17.9.0 or greater of the API
            /// </summary>
            public static void ReadOdsMetadata() {
                //ExStart:ReadOdsMetadata
                // initialize XlsFormat
                using (XlsFormat xlsFormat = new XlsFormat(Common.MapSourceFilePath(filePath)))
                {

                    // get document properties
                    XlsMetadata properties = xlsFormat.DocumentProperties;

                    // get author
                    string author = properties.Author;

                    // get company
                    string company = properties.Company;

                    // get created date of the document
                    DateTime createdDate = properties.CreatedTime; 
                }
                //ExEnd:ReadOdsMetadata
            }
        }



        /// <summary>
        /// Detects document protection
        /// </summary> 
        public static void DetectProtection(string filePath)
        {
            try
            {
                //ExStart:DetectProtection
                using (FormatBase format = FormatFactory.RecognizeFormat(Common.MapSourceFilePath(filePath)))
                {

                    if (format.Type.ToString().ToLower() == "doc")
                    {
                        // initialize DocFormat
                        using (DocFormat docFormat = new DocFormat(Common.MapSourceFilePath(filePath)))
                        {
                            // determines whether document is protected by password
                            Console.WriteLine(docFormat.IsProtected ? "Document is protected" : "Document is protected"); 
                        }
                    }
                    else if (format.Type.ToString().ToLower() == "pdf")
                    {
                        // initialize PdfFormat
                        using (PdfFormat pdfFormat = new PdfFormat(Common.MapSourceFilePath(filePath)))
                        {

                            // determines whether document is protected by password
                            Console.WriteLine(pdfFormat.IsProtected ? "Document is protected" : "Document is protected"); 
                        }
                    }
                    else if (format.Type.ToString().ToLower() == "xls")
                    {
                        // initialize XlsFormat
                        using (XlsFormat xlsFormat = new XlsFormat(Common.MapSourceFilePath(filePath)))
                        {
                            // determines whether document is protected by password
                            Console.WriteLine(xlsFormat.IsProtected ? "Document is protected" : "Document is protected"); 
                        }
                    }
                    else if (format.Type.ToString().ToLower() == "ppt")
                    {
                        // initialize DocFormat
                        using (PptFormat pptFormat = new PptFormat(Common.MapSourceFilePath(filePath)))
                        {
                            // determines whether document is protected by password
                            Console.WriteLine(pptFormat.IsProtected ? "Document is protected" : "Document is protected"); 
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid Format.");
                    } 
                }
                //ExEnd:DetectProtection
            }
            catch (Exception exp)
            {
                Console.WriteLine("Exception occurred: " + exp.Message);
            }

        }

        /// <summary>
        /// Detect document format at runtime 
        /// Enhancement in ver. 1.7
        /// </summary>
        public static void RuntimeFormatDetection(string directoryPath)
        {
            try
            {
                //string directoryPath = @"C:\\download files";
                string[] files = Directory.GetFiles(Common.MapSourceFilePath(directoryPath));

                foreach (string path in files)
                {
                    Metadata metadata = MetadataUtility.ExtractSpecificMetadata(path, MetadataType.Document);
                    // check if file has document format
                    if (metadata == null)
                    {
                        continue;
                    }

                    Console.WriteLine("File: {0}\n", Path.GetFileName(path));

                    IEnumerable<KeyValuePair<String, PropertyValue>> values = (IEnumerable<KeyValuePair<String, PropertyValue>>)metadata;

                    foreach (KeyValuePair<string, PropertyValue> keyValuePair in values)
                    {
                        Console.WriteLine("Metadata: {0}, value: {1}", keyValuePair.Key, keyValuePair.Value);
                    }

                    Console.WriteLine("\n**************************************************\n");
                }
            }
            catch (Exception exp)
            {
                Console.WriteLine("Exception occurred: " + exp.Message);
            }

        }

        /// <summary>
        /// Demonstrates how to read thumbnail in documents, here we are using Word document
        /// Feature is supported in version 17.03  or greater
        /// </summary>
        /// <param name="filePath"></param>
        public static void ReadThumbnail(string filePath)
        {
            try
            {
                //ExStart:ReadThumbnail
                // initialize DocFormat
                using (DocFormat docFormat = new DocFormat(Common.MapSourceFilePath(filePath)))
                {

                    // get thumbnail
                    byte[] thumbnailData = docFormat.Thumbnail;

                    // write thumbnail to PNG image since it has png format
                    File.WriteAllBytes(Common.MapDestinationFilePath("thumbnail.png"), thumbnailData); 
                }
                //ExEnd:ReadThumbnail
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Loads DocumentInfo property in DocumentFormat using lazy loading pattern
        /// Feature is supported by version 17.03 or greater
        /// </summary>
        /// <param name="filePath"></param>
        public static void LazyLoadDocumentInfoProperty(string filePath)
        {
            try
            {
                //ExStart:LazyLoadDocumentInfoProperty
                // initialize DocFormat
                using (DocFormat docFormat = new DocFormat(Common.MapSourceFilePath(filePath)))
                {

                    // get document info
                    DocumentInfo documentInfo = docFormat.DocumentInfo;

                    // next call returns previous documentInfo object
                    DocumentInfo next = docFormat.DocumentInfo; 
                }
                //ExEnd:LazyLoadDocumentInfoProperty
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

    }
}