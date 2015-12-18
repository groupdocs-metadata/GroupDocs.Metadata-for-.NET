using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GroupDocs.Metadata.Formats.Document;
using GroupDocs.Metadata.Standards.Doc;
using GroupDocs.Metadata.Examples.Utilities.CSharp;
using GroupDocs.Metadata.MetadataProperties;
using GroupDocs.Metadata.Exceptions;

namespace GroupDocs.Metadata.Examples.Utilities.CSharp
{
    class Tempclass
    {
        public static void GetDocumentProperties(string filePath)
        {
            //ExStart:InvalidFormatException
            try
            {
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
            }
            catch (InvalidFormatException ex)
            {
                Console.WriteLine("File is not DOC: {0}", ex.Message);
            }
            //ExEnd:InvalidFormatException
        }
    }
}
