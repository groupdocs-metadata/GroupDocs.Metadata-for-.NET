using GroupDocs.Metadata;
using GroupDocs.Metadata.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GroupDocs.Metadata.Examples.CSharp.Utilities
{
    //ExStart:AuthorReplaceHandler
    /// <summary>
    /// This class updates author to 'Jack London'
    /// </summary>
    public class AuthorReplaceHandler : IReplaceHandler<MetadataProperty>
    {
        public AuthorReplaceHandler(string outputPath)
        {
            this.OutputPath = outputPath;
        }

        public string OutputPath { get; private set; }

        public bool Handle(MetadataProperty property)
        {
            // if property name is 'author'
            if (property.Name.ToLower() == "author")
            {
                // update property value
                property.Value = new PropertyValue("Jack London");

                // and mark property as updated
                return true;
            }

            // ignore all other properties
            return false;
        }
    }
    //ExEnd:AuthorReplaceHandler
}
