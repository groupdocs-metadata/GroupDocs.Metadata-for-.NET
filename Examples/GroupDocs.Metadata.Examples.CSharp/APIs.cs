using GroupDocs.Metadata.Examples.CSharp.Utilities;
using GroupDocs.Metadata.Examples.Utilities.CSharp;
using GroupDocs.Metadata;
using GroupDocs.Metadata.Formats.Image;
using GroupDocs.Metadata.Tools;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;

namespace GroupDocs.Metadata.Examples.CSharp
{
    public static class APIs
    {
        public static class Document
        {
            /// <summary>
            /// Compares metadata of two documents and displays result 
            /// </summary> 
            public static void CompareDocument(string firstDocument, string secondDocument, ComparerSearchType type)
            {
                try
                {
                    //ExStart:ComparisonAPI
                    firstDocument = Common.MapSourceFilePath(firstDocument);
                    secondDocument = Common.MapSourceFilePath(secondDocument);

                    MetadataPropertyCollection differences = ComparisonFacade.CompareDocuments(firstDocument, secondDocument, type);

                    foreach (MetadataProperty property in differences)
                    {
                        Console.WriteLine("{0} : {1}", property.Name, property.Value);
                    }
                    //ExEnd:ComparisonAPI
                }
                catch (Exception exp)
                {
                    Console.WriteLine("Exception occurred: " + exp.Message);
                }

            }
            /// <summary>
            /// Searches metadata in document 
            /// </summary> 
            public static void SearchMetadata(string filePath, string propertyName, SearchCondition searchCondition)
            {
                try
                {
                    //ExStart:DocumentSearchAPI
                    filePath = Common.MapSourceFilePath(filePath);

                    MetadataPropertyCollection properties = SearchFacade.ScanDocument(filePath, propertyName, searchCondition);

                    foreach (MetadataProperty property in properties)
                    {
                        Console.WriteLine("{0} : {1}", property.Name, property.Value);
                    }
                    //ExEnd:DocumentSearchAPI
                }
                catch (Exception exp)
                {
                    Console.WriteLine("Exception occurred: " + exp.Message);
                }

            }

            /// <summary>
            /// Replaces author name in document using custom ReplaceHandler
            /// </summary> 
            public static void ReplaceAuthorName(string filePath)
            {
                try
                {
                    //ExStart:ReplaceAuthorName
                    // initialize custom handler, send output path using constructor
                    IReplaceHandler<MetadataProperty> replaceHandler = new AuthorReplaceHandler(Common.MapDestinationFilePath(filePath));

                    // replace author
                    int affectedPropertiesCount = SearchFacade.ReplaceInDocument(Common.MapSourceFilePath(filePath), replaceHandler);
                    //ExEnd:ReplaceAuthorName
                }
                catch (Exception exp)
                {
                    Console.WriteLine("Exception occurred: " + exp.Message);
                }

            }
            /// <summary>
            /// Replaces author name in document using custom ReplaceHandler
            /// </summary> 
            public static void ReplaceMetadataProperties(string filePath)
            {
                try
                {
                    //ExStart:ReplaceMetadataProperties
                    // replace 'author' value
                    SearchFacade.ReplaceInDocument(Common.MapSourceFilePath(filePath), "Author", "Jack London", SearchCondition.Matches, Common.MapDestinationFilePath(filePath));

                    // replace all properties contained 'co' to 'some value'
                    SearchFacade.ReplaceInDocument(Common.MapSourceFilePath(filePath), "co", "some value", SearchCondition.Contains, Common.MapDestinationFilePath(filePath));
                    //ExEnd:ReplaceMetadataProperties
                }
                catch (Exception exp)
                {
                    Console.WriteLine("Exception occurred: " + exp.Message);
                }

            }
        }
        public static class Image
        {
            /// <summary>
            /// Searches metadata in image 
            /// </summary> 
            public static void SearchMetadata(string filePath, string propertyName, SearchCondition searchCondition)
            {
                try
                {
                    //ExStart:ImageSearchAPI
                    filePath = Common.MapSourceFilePath(filePath);

                    // looking the software
                    ExifProperty[] properties = SearchFacade.ScanExif(filePath, propertyName, searchCondition);

                    foreach (ExifProperty property in properties)
                    {
                        Console.WriteLine("{0} : {1}", property.Name, property.ToString());
                    }
                    //ExEnd:ImageSearchAPI
                }
                catch (Exception exp)
                {
                    Console.WriteLine("Exception occurred: " + exp.Message);
                }

            }

            /// <summary>
            /// Compares EXIF metadata of two jpeg files 
            /// </summary> 
            public static void CompareExifMetadata(string firstFile, string secondFile, ComparerSearchType type)
            {
                try
                {
                    //ExStart:ExifComparisonAPI
                    firstFile = Common.MapSourceFilePath(firstFile);
                    secondFile = Common.MapSourceFilePath(secondFile);

                    ExifProperty[] differences = ComparisonFacade.CompareExif(firstFile, secondFile, type);

                    foreach (ExifProperty property in differences)
                    {
                        Console.WriteLine("{0} : {1}", property.Name, property.ToString());
                    }
                    //ExEnd:ExifComparisonAPI
                }
                catch (Exception exp)
                {
                    Console.WriteLine("Exception occurred: " + exp.Message);
                }

            }
        }

        /// <summary>
        /// Exports metadata of specified file into specified type 
        /// </summary> 
        public static void ExportMetadata(string filePath, int exportType)
        {
            try
            {
                //ExStart:ExportMetadataAPI
                filePath = Common.MapSourceFilePath(filePath);

                if (exportType == ExportTypes.ToExcel)
                {
                    //ExStart:ExportMetadataToExcel
                    // path to the output file
                    string outputPath = Common.MapDestinationFilePath("metadata.xlsx"); 

                    // export to excel
                    byte[] content = ExportFacade.ExportToExcel(filePath);

                    // write data to the file
                    File.WriteAllBytes(outputPath, content);
                    //ExEnd:ExportMetadataToExcel
                }
                else if (exportType == ExportTypes.ToCSV)
                {
                    //ExStart:ExportMetadataToCVS
                    // path to the output file
                    string outputPath = Common.MapDestinationFilePath("metadata.csv"); 

                    // export to csv
                    byte[] content = ExportFacade.ExportToCsv(filePath);

                    // write data to the file
                    File.WriteAllBytes(outputPath, content);
                    //ExEnd:ExportMetadataToCVS
                }
                else  
                {
                    //ExStart:ExportMetadataToDataSet
                    // export to DataSet
                    DataSet ds = ExportFacade.ExportToDataSet(filePath);
                    // get first table
                    DataTable products = ds.Tables[0];

                    // need to System.Data.DataSetExtension reference            
                    IEnumerable<DataRow> query =
                    from product in products.AsEnumerable()
                    select product;

                    Console.WriteLine("Properties:");
                    foreach (DataRow p in query)
                    {
                        Console.Write(p.Field<string>("Metadata property"));
                        Console.Write(": ");
                        Console.WriteLine(p.Field<string>("Value"));
                    }
                    //ExEnd:ExportMetadataToDataSet
                }
                //ExEnd:ExportMetadataAPI
            }
            catch (Exception exp)
            {
                Console.WriteLine("Exception occurred: " + exp.Message);
            }

        }
    }
}
