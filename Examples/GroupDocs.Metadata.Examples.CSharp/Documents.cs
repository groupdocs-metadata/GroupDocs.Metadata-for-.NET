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
            private const string filePath = "Documents/Doc/sample.doc";

            #region working with built-in properties
            
            /// <summary>
            /// Gets document properties from Doc file 
            /// </summary> 
            public static void GetDocumentProperties()
            {
                try
                {
                    //ExStart:GetDocumentProperties
                    // initialize DocFormat
                    DocFormat docFormat = new DocFormat(Common.MapSourceFilePath(filePath));

                    // initialize metadata
                    DocMetadata docMetadata = docFormat.DocumentProperties;

                    // get properties
                    Console.WriteLine("Built-in Properties: ");
                    foreach (var property in docMetadata)
                    {
                        // check if built-in property
                        if (docMetadata.IsBuiltIn(property.Key))
                        {
                            Console.WriteLine("{0} : {1}", property.Key, property.Value);
                        }
                    }

                    Console.WriteLine("\nCustom Properties");
                    foreach (KeyValuePair<string, PropertyValue> keyValuePair in docMetadata)
                    {
                        // check if prooerty is not built-in
                        if (!docMetadata.IsBuiltIn(keyValuePair.Key))
                        {
                            // get property value
                            PropertyValue propertyValue = docMetadata[keyValuePair.Key];
                            Console.WriteLine("Key: {0}, Type:{1}, Value: {2}", keyValuePair.Key, propertyValue.Type, propertyValue);
                        }
                    }
                    //ExEnd:GetDocumentProperties
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
                    //ExStart:UpdateDocumentProperties
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

                    //ExEnd:UpdateDocumentProperties
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
                    //ExStart:RemoveDocumentProperties
                    // initialize Docformat
                    DocFormat docFormat = new DocFormat(Common.MapSourceFilePath(filePath));
                    
                    //Clean metadata
                    docFormat.CleanMetadata();

                    // save output file...
                    docFormat.Save(Common.MapDestinationFilePath(filePath));

                    //ExEnd:RemoveDocumentProperties
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
                     
                    // initialize DocFormat
                    DocFormat docFormat = new DocFormat(Common.MapSourceFilePath(filePath));

                    // initialize DocMetadata
                    DocMetadata metadata = docFormat.DocumentProperties;

                    // get property details from user
                    Console.WriteLine("Enter Property Name:");
                    string propertyName = Console.ReadLine();
                    Console.WriteLine("Enter Property Value:");
                    string propertyValue = Console.ReadLine();

                    // add boolean key
                    if (!metadata.ContainsKey(propertyName))
                    {
                        // add property
                        metadata.Add(propertyName, propertyValue);
                    }

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
            /// Removes custom properties of Doc file and creates output file
            /// </summary> 
            public static void RemoveCustomProperties()
            {
                try
                {
                     
                    // initialize DocFormat
                    DocFormat docFormat = new DocFormat(Common.MapSourceFilePath(filePath));

                    // initialize DocMetadata
                    DocMetadata metadata = docFormat.DocumentProperties;

                    // get property from user
                    Console.WriteLine("Enter Property Name:");
                    string propertyName = Console.ReadLine();

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
            private const string filePath = "Documents/Pdf/sample.pdf";

            #region working with document properties
            /// <summary>
            /// Gets document properties of Pdf file  
            /// </summary> 
            public static void GetDocumentProperties()
            {
                try
                {
                    
                    // initialize Pdfformat
                    PdfFormat pdfFormat = new PdfFormat(Common.MapSourceFilePath(filePath));

                    // initialize PdfMetadata
                    PdfMetadata pdfMetadata = pdfFormat.DocumentProperties;

                    // built-in properties
                    Console.WriteLine("Built-in Properties");
                    foreach (var property in pdfMetadata)
                    {
                        // check if built-in property
                        if (pdfMetadata.IsBuiltIn(property.Key))
                        {
                            Console.WriteLine("{0} : {1}", property.Key, property.Value);
                        }
                    }

                    // custom properties
                    Console.WriteLine("\nCustom Properties");
                    foreach (KeyValuePair<string, PropertyValue> keyValuePair in pdfMetadata)
                    {
                        // check if prooerty is not built-in
                        if (!pdfMetadata.IsBuiltIn(keyValuePair.Key))
                        {
                            // get property value
                            PropertyValue propertyValue = pdfMetadata[keyValuePair.Key];
                            Console.WriteLine("Key: {0}, Type:{1}, Value: {2}", keyValuePair.Key, propertyValue.Type, propertyValue);
                        }
                    }
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

                     
                    // initialize PdfFormat
                    PdfFormat pdfFormat = new PdfFormat(Common.MapSourceFilePath(filePath));
                    
                    // initialize PdfMetadata
                    PdfMetadata pdfMetadata = pdfFormat.DocumentProperties;

                    //get properties from user...
                    Console.WriteLine("Enter Author's Name: ");
                    string author = Console.ReadLine();
                    Console.WriteLine("Enter Subject: ");
                    string subject = Console.ReadLine();

                    //update document property...
                    pdfMetadata.Author = author;
                    pdfMetadata.Subject = subject;
                    pdfMetadata.CreatedDate = DateTime.Now;

                    //save output file...
                    pdfFormat.Save(Common.MapDestinationFilePath(filePath));
                    
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
                     
                    // initialize PdfFormat
                    PdfFormat pdfFormat = new PdfFormat(Common.MapSourceFilePath(filePath));
                    
                    pdfFormat.CleanMetadata();
                    
                    //save output file...
                    pdfFormat.Save(Common.MapDestinationFilePath(filePath));

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
                     
                    // initialize PdfFormat
                    PdfFormat pdfFormat = new PdfFormat(Common.MapSourceFilePath(filePath));

                    // initialize PdfMetadata
                    PdfMetadata metadata = pdfFormat.DocumentProperties;

                    // get property details from user
                    Console.WriteLine("Enter Property Name:");
                    string propertyName = Console.ReadLine();
                    Console.WriteLine("Enter Property Value:");
                    string propertyValue = Console.ReadLine();

                    // add boolean key
                    if (!metadata.ContainsKey(propertyName))
                    {
                        // add property
                        metadata.Add(propertyName, propertyValue);
                    }

                    // save file in destination folder
                    pdfFormat.Save(Common.MapDestinationFilePath(filePath));

                    Console.WriteLine("File saved in destination folder.");


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
                     
                    // initialize PdfFormat
                    PdfFormat pdfFormat = new PdfFormat(Common.MapSourceFilePath(filePath));

                    // initialize PdfMetadata
                    PdfMetadata metadata = pdfFormat.DocumentProperties;

                    // get property from user
                    Console.WriteLine("Enter Property Name:");
                    string propertyName = Console.ReadLine();

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
            private const string filePath = "Documents/Ppt/sample.ppt";

            #region working with document properties
            /// <summary>
            /// Gets document properties of Ppt file  
            /// </summary> 
            public static void GetDocumentProperties()
            {
                try
                {
                    
                    // initialize PptFormat
                    PptFormat pptFormat = new PptFormat(Common.MapSourceFilePath(filePath));

                    // initialize PptMetadata
                    PptMetadata pptMetadata = pptFormat.DocumentProperties;

                    // built-in properties
                    Console.WriteLine("\nBuilt-in Properties");
                    foreach (var property in pptMetadata)
                    {
                        Console.WriteLine("{0} : {1}", property.Key, property.Value);
                    }

                    // custom properties
                    Console.WriteLine("\nCustom Properties");
                    foreach (KeyValuePair<string, PropertyValue> keyValuePair in pptMetadata)
                    {
                        // check if prooerty is not built-in
                        if (!pptMetadata.IsBuiltIn(keyValuePair.Key))
                        {
                            // get property value
                            PropertyValue propertyValue = pptMetadata[keyValuePair.Key];
                            Console.WriteLine("Key: {0}, Type:{1}, Value: {2}", keyValuePair.Key, propertyValue.Type, propertyValue);
                        }
                    }
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
                     
                    // initialize PptFormat
                    PptFormat pptFormat = new PptFormat(Common.MapSourceFilePath(filePath));

                    // initialize PptMetadata
                    PptMetadata pptMetadata = pptFormat.DocumentProperties;

                    //get properties from user...
                    Console.WriteLine("Enter Author's Name: ");
                    string author = Console.ReadLine();
                    Console.WriteLine("Enter Subject: ");
                    string subject = Console.ReadLine();

                    //update document property...
                    pptMetadata.Author = author;
                    pptMetadata.Subject = subject;

                    //save output file...
                    pptFormat.Save(Common.MapDestinationFilePath(filePath));

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
                     
                    // initialize PptFormat
                    PptFormat pptFormat = new PptFormat(Common.MapSourceFilePath(filePath));

                    // clean metadata
                    pptFormat.CleanMetadata();

                    // save output file...
                    pptFormat.Save(Common.MapDestinationFilePath(filePath));

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
                     
                    // initialize PptFormat
                    PptFormat pptFormat = new PptFormat(Common.MapSourceFilePath(filePath));

                    // initialize PptMetadata
                    PptMetadata metadata = pptFormat.DocumentProperties;

                    // get property details from user
                    Console.WriteLine("Enter Property Name:");
                    string propertyName = Console.ReadLine();
                    Console.WriteLine("Enter Property Value:");
                    string propertyValue = Console.ReadLine();

                    // add boolean key
                    if (!metadata.ContainsKey(propertyName))
                    {
                        // add property
                        metadata.Add(propertyName, propertyValue);
                    }

                    // save file in destination folder
                    pptFormat.Save(Common.MapDestinationFilePath(filePath));

                    Console.WriteLine("File saved in destination folder.");


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
                     
                    // initialize PptFormat
                    PptFormat pptFormat = new PptFormat(Common.MapSourceFilePath(filePath));

                    // initialize PptMetadata
                    PptMetadata metadata = pptFormat.DocumentProperties;

                    // get property from user
                    Console.WriteLine("Enter Property Name:");
                    string propertyName = Console.ReadLine();

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
            private const string filePath = "Documents/Xls/sample.xls";

            #region working with document properties
            /// <summary>
            /// Gets document properties of Xls file  
            /// </summary> 
            public static void GetDocumentProperties()
            {
                try
                {
                    
                    // initialize XlsFormat
                    XlsFormat xlsFormat = new XlsFormat(Common.MapSourceFilePath(filePath));

                    // initialize XlsMetadata
                    XlsMetadata xlsMetadata = xlsFormat.DocumentProperties;

                    // built-in properties
                    Console.WriteLine("\nBuilt-in Properties");
                    foreach (var property in xlsMetadata)
                    {
                        Console.WriteLine("{0} : {1}", property.Key, property.Value);
                    }

                    // custom properties
                    Console.WriteLine("\nCustom Properties");
                    foreach (KeyValuePair<string, PropertyValue> keyValuePair in xlsMetadata)
                    {
                        // check if prooerty is not built-in
                        if (!xlsMetadata.IsBuiltIn(keyValuePair.Key))
                        {
                            // get property value
                            PropertyValue propertyValue = xlsMetadata[keyValuePair.Key];
                            Console.WriteLine("Key: {0}, Type:{1}, Value: {2}", keyValuePair.Key, propertyValue.Type, propertyValue);
                        }
                    }
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
                     
                    // initialize XlsFormat
                    XlsFormat xlsFormat = new XlsFormat(Common.MapSourceFilePath(filePath));

                    // initialize XlsMetadata
                    XlsMetadata xlsMetadata = xlsFormat.DocumentProperties;

                    //get properties from user...
                    Console.WriteLine("Enter Author's Name: ");
                    string author = Console.ReadLine();
                    Console.WriteLine("Enter Subject: ");
                    string subject = Console.ReadLine();

                    //update document property...
                    xlsMetadata.Author = author;
                    xlsMetadata.Subject = subject;

                    //save output file...
                    xlsFormat.Save(Common.MapDestinationFilePath(filePath));

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
                     
                    // initialize XlsFormat
                    XlsFormat xlsFormat = new XlsFormat(Common.MapSourceFilePath(filePath));

                    // clean metadata
                    xlsFormat.CleanMetadata();

                    //save output file...
                    xlsFormat.Save(Common.MapDestinationFilePath(filePath));

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
                     
                    // initialize XlsFormat
                    XlsFormat xlsFormat = new XlsFormat(Common.MapSourceFilePath(filePath));

                    // initialize XlsMetadata
                    XlsMetadata metadata = xlsFormat.DocumentProperties;

                    // get property details from user
                    Console.WriteLine("Enter Property Name:");
                    string propertyName = Console.ReadLine();
                    Console.WriteLine("Enter Property Value:");
                    string propertyValue = Console.ReadLine();

                    // add boolean key
                    if (!metadata.ContainsKey(propertyName))
                    {
                        // add property
                        metadata.Add(propertyName, propertyValue);
                    }

                    // save file in destination folder
                    xlsFormat.Save(Common.MapDestinationFilePath(filePath));

                    Console.WriteLine("File saved in destination folder.");


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
                     
                    // initialize XlsFormat
                    XlsFormat xlsFormat = new XlsFormat(Common.MapSourceFilePath(filePath));

                    // initialize XlsMetadata
                    XlsMetadata metadata = xlsFormat.DocumentProperties;

                    // get property from user
                    Console.WriteLine("Enter Property Name:");
                    string propertyName = Console.ReadLine();

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
