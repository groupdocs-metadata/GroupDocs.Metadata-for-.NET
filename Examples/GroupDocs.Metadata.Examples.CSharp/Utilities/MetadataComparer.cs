using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using GroupDocs.Metadata.MetadataProperties;
using GroupDocs.Metadata.Tools;

namespace GroupDocs.Metadata.Examples.Utilities.CSharp
{
    //ExStart:MetadataComparer
    public class MetadataComparer
    {
        // absolute path to the GroupDocs.Metadata license file.
        private const string LicensePath = @"GroupDocs.Metadata.lic";
        
        static MetadataComparer()
        {
            /* set product license 
             * uncomment following function if you have product license
             * */
            SetInternalLicense();
        }
 
        /// <summary>
        /// Applies the product license
        /// </summary>
        private static void SetInternalLicense()
        { 
            License license = new License();
            license.SetLicense(LicensePath);
        }
        /// <summary>
        /// Compares and finds metadata difference of two files 
        /// </summary>
        /// <param name="filePath1">First file path</param>
        /// <param name="filePath2">Second file path</param>
        public void CompareFilesMetadata(string filePath1, string filePath2)
        {
            try
            {
                // path to the document
                filePath1 = Common.MapSourceFilePath(filePath1);

                // path to the compared document
                filePath2 = Common.MapSourceFilePath(filePath2);

                // get diffences between metadata
                MetadataPropertyCollection diffenceProperties = MetadataUtility.CompareDoc(filePath1, filePath2);

                // go through collection and show differences
                foreach (MetadataProperty property in diffenceProperties)
                {
                    Console.WriteLine("Property = {0}, value = {1}", property.Name, property.Value);
                }
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.Message);
            }
        }
    }
    //ExEnd:MetadataComparer
}
