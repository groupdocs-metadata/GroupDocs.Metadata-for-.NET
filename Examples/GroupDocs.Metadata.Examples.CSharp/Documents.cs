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

namespace GroupDocs.Metadata.Examples.CSharp
{
    public static class Documents
    {
        public static class Doc
        {
            // initialize file path
            //ExStart:SourceDocFilePath
            private const string filePath = "Documents/Doc/sample.doc";
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
                    DocFormat docFormat = new DocFormat(Common.MapSourceFilePath(filePath));

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
                    //ExEnd:GetBuiltinDocumentPropertiesDocFormat
                }
                catch (Exception exp)
                {
                    Console.WriteLine(exp.Message);
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
                    DocFormat docFormat = new DocFormat(Common.MapSourceFilePath(filePath));

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
                    DocFormat docFormat = new DocFormat(Common.MapSourceFilePath(filePath));

                    //Clean metadata
                    docFormat.CleanMetadata();

                    // save output file...
                    docFormat.Save(Common.MapDestinationFilePath(filePath));

                    //ExEnd:RemoveBuiltinDocumentPropertiesDocFormat
                    Console.WriteLine("File saved in destination folder.");


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
                    DocFormat docFormat = new DocFormat(Common.MapSourceFilePath(filePath));

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
                    DocFormat docFormat = new DocFormat(Common.MapSourceFilePath(filePath));

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
                    DocFormat docFormat = new DocFormat(Common.MapSourceFilePath(filePath));

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
                    DocFormat docFormat = new DocFormat(Common.MapSourceFilePath(filePath));

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
                    DocFormat docFormat = new DocFormat(Common.MapSourceFilePath(filePath));

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
                    DocFormat docFormat = new DocFormat(Common.MapSourceFilePath(filePath));

                    // remove comments
                    docFormat.ClearComments();

                    // save file in destination folder
                    docFormat.Save(Common.MapDestinationFilePath(filePath));

                    Console.WriteLine("File saved in destination folder.");


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
                    DocFormat docFormat = new DocFormat(Common.MapSourceFilePath(filePath));

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
                    DocFormat docFormat = new DocFormat(Common.MapSourceFilePath(filePath));

                    // Get words count...
                    int wordsCount = docFormat.GetWordsCount();

                    // Get pages count...
                    int pageCounts = docFormat.GetPagesCount();

                    Console.WriteLine("Words: {0}", wordsCount);
                    Console.WriteLine("Pages: {0}", pageCounts);


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
                    DocFormat docFormat = new DocFormat(Common.MapSourceFilePath(filePath));

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
                    DocFormat docFormat = new DocFormat(Common.MapSourceFilePath(filePath));

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
                DocFormat docFormat = new DocFormat(Common.MapSourceFilePath(filePath));

                // update document properties
                docFormat.DocumentProperties.Author = "Joe Doe";
                docFormat.DocumentProperties.Company = "Aspose";

                // and commit changes
                docFormat.Save();
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
                    DocFormat docFormat = new DocFormat(Common.MapSourceFilePath(filePath));

                    // and try to get document properties
                    var documentProperties = docFormat.DocumentProperties;
                }
                catch (DocumentProtectedException ex)
                {
                    Console.WriteLine("File is protected by password PDF: {0}", ex.Message);
                }
                //ExEnd:DocumentProtectedException
            }
            #endregion

        }

        public static class Pdf
        {
            // initialize file path
            //ExStart:SourcePdfFilePath
            private const string filePath = "Documents/Pdf/Annotated.pdf";
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
                    PdfFormat pdfFormat = new PdfFormat(Common.MapSourceFilePath(filePath));

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
                    PdfFormat pdfFormat = new PdfFormat(Common.MapSourceFilePath(filePath));

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
                    PdfFormat pdfFormat = new PdfFormat(Common.MapSourceFilePath(filePath));

                    pdfFormat.CleanMetadata();

                    //save output file...
                    pdfFormat.Save(Common.MapDestinationFilePath(filePath));
                    //ExEnd:RemoveBuiltinDocumentPropertyPdfFormat

                    Console.WriteLine("File saved in destination folder.");


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
                    PdfFormat pdfFormat = new PdfFormat(Common.MapSourceFilePath(filePath));

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
                    PdfFormat pdfFormat = new PdfFormat(Common.MapSourceFilePath(filePath));

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
                    PdfFormat pdfFormat = new PdfFormat(Common.MapSourceFilePath(filePath));

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
                    PdfFormat PdfFormat = new PdfFormat(Common.MapSourceFilePath(filePath));

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
                    PdfFormat pdfFormat = new PdfFormat(Common.MapSourceFilePath(filePath));

                    // get pdf schema
                    PdfPackage pdfPackage = pdfFormat.XmpValues.Schemes.Pdf;

                    Console.WriteLine("Keywords: {0}", pdfPackage.Keywords);
                    Console.WriteLine("PdfVersion: {0}", pdfPackage.PdfVersion);
                    Console.WriteLine("Producer: {0}", pdfPackage.Producer);
                    //ExEnd:GetXMPPropertiesPdfFormat
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
                    PdfFormat pdfFormat = new PdfFormat(Common.MapSourceFilePath(filePath));

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
                    PdfFormat pdfFormat = new PdfFormat(Common.MapSourceFilePath(filePath));

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
                    //ExEnd:RemoveHiddenDataPdfFormat
                }
                catch (Exception exp)
                {
                    Console.WriteLine(exp.Message);
                }
            }
            #endregion
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
                    XlsFormat xlsFormat = new XlsFormat(Common.MapSourceFilePath(filePath));

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
                    XlsFormat xlsFormat = new XlsFormat(Common.MapSourceFilePath(filePath));

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
                    XlsFormat xlsFormat = new XlsFormat(Common.MapSourceFilePath(filePath));

                    // clean metadata
                    xlsFormat.CleanMetadata();

                    //save output file...
                    xlsFormat.Save(Common.MapDestinationFilePath(filePath));
                    //ExEnd:RemoveBuiltinDocumentPropertiesXlsFormat
                    Console.WriteLine("File saved in destination folder.");


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
                    XlsFormat xlsFormat = new XlsFormat(Common.MapSourceFilePath(filePath));

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
                    XlsFormat xlsFormat = new XlsFormat(Common.MapSourceFilePath(filePath));

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
                    XlsFormat xlsFormat = new XlsFormat(Common.MapSourceFilePath(filePath));

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
                    XlsFormat xlsFormat = new XlsFormat(Common.MapSourceFilePath(filePath));

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
                    XlsFormat xlsFormat = new XlsFormat(Common.MapSourceFilePath(filePath));

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
                    XlsFormat xlsFormat = new XlsFormat(Common.MapSourceFilePath(filePath));

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
                    //ExEnd:RemoveHiddenDataInXls
                }
                catch (Exception exp)
                {
                    Console.WriteLine(exp.Message);
                }
            }
            #endregion
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
                    OneNoteFormat oneNoteFormat = new OneNoteFormat(Common.MapSourceFilePath(filePath));

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
                    OneNoteFormat oneNoteFormat = new OneNoteFormat(Common.MapSourceFilePath(filePath));

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
                    MppFormat mppFormat = new MppFormat(Common.MapSourceFilePath(filePath));

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
                    //ExEnd:GetMetadataMppFormat
                }
                catch (Exception exp)
                {
                    Console.WriteLine(exp.Message);
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
                    MppFormat mppFormat = new MppFormat(Common.MapSourceFilePath(filePath));

                    // get document properties
                    MppMetadata properties = mppFormat.GetProperties();

                    if (mppFormat != null)
                    {
                        // get Author 
                        Console.WriteLine("Author: {0}", properties.Author);
                        // get Company 
                        Console.WriteLine("Company: {0}", properties.Title);
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
                VisioFormat visioFormat = new VisioFormat(Common.MapSourceFilePath(filePath));

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

       
        /// <summary>
        /// Detects document protection
        /// </summary> 
        public static void DetectProtection(string filePath)
        {
            try
            {
                //ExStart:DetectProtection
                FormatBase format = FormatFactory.RecognizeFormat(Common.MapSourceFilePath(filePath));

                if (format.Type.ToString().ToLower() == "doc")
                {
                    // initialize DocFormat
                    DocFormat docFormat = new DocFormat(Common.MapSourceFilePath(filePath));

                    // determines whether document is protected by password
                    Console.WriteLine(docFormat.IsProtected ? "Document is protected" : "Document is protected");
                }
                else if (format.Type.ToString().ToLower() == "pdf")
                {
                    // initialize DocFormat
                    PdfFormat pdfFormat = new PdfFormat(Common.MapSourceFilePath(filePath));

                    // determines whether document is protected by password
                    Console.WriteLine(pdfFormat.IsProtected ? "Document is protected" : "Document is protected");
                }
                else if (format.Type.ToString().ToLower() == "xls")
                {
                    // initialize DocFormat
                    XlsFormat xlsFormat = new XlsFormat(Common.MapSourceFilePath(filePath));

                    // determines whether document is protected by password
                    Console.WriteLine(xlsFormat.IsProtected ? "Document is protected" : "Document is protected");
                }
                else if (format.Type.ToString().ToLower() == "ppt")
                {
                    // initialize DocFormat
                    PptFormat pptFormat = new PptFormat(Common.MapSourceFilePath(filePath));

                    // determines whether document is protected by password
                    Console.WriteLine(pptFormat.IsProtected ? "Document is protected" : "Document is protected");
                }
                else
                {
                    Console.WriteLine("Invalid Format.");
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
            //string directoryPath = @"C:\\download files";
            string[] files = Directory.GetFiles(directoryPath);

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
    
    }
}