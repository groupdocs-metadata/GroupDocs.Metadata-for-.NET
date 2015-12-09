using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GroupDocs.Metadata.Formats.Document;
using GroupDocs.Metadata.Standards.Doc;
using GroupDocs.Metadata.MetadataProperties;
using GroupDocs.Metadata.Standards.Pdf;
using GroupDocs.Metadata.Standards.Ppt;
using GroupDocs.Metadata.Standards.Xls;

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
                            // get property value
                            PropertyValue propertyValue = docMetadata[keyValuePair.Key];
                            Console.WriteLine("Key: {0}, Type:{1}, Value: {2}", keyValuePair.Key, propertyValue.Type, propertyValue);
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
                        Console.WriteLine("Author: ", comment);
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
            #endregion
        }

        public static class Ppt
        {
            // initialize file path
            //ExStart:SourcePptFilePath
            private const string filePath = "Documents/Ppt/sample.ppt";
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
            #endregion
        }
    }
}
