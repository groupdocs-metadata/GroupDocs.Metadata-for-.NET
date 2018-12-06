using System;
using System.Collections.Generic;
using GroupDocs.Metadata.Formats.Image;
using GroupDocs.Metadata.Xmp.Schemes;
using GroupDocs.Metadata.Xmp;
using GroupDocs.Metadata.Examples.Utilities.CSharp;
using GroupDocs.Metadata.Tools;
using System.Drawing;
using System.IO;
using GroupDocs.Metadata.Formats.Cad;
using GroupDocs.Metadata.Formats;
using System.Text.RegularExpressions;

namespace GroupDocs.Metadata.Examples.CSharp
{
    public static class DublinCore
    {
        private const string XMPFilesDirectory = "../../../Data/Source/XMPFiles/";
        /// <summary>
        /// Get Dublin Core metadata using MetadataUtility class.
        /// Feature is supported in version 18.5 or greater of the API
        /// </summary>
        public static void GetDublinCoreMetadata()
        {
            try
            {
                string[] files = Directory.GetFiles(XMPFilesDirectory);
                foreach (string file in files)
                {
                    try
                    {
                        DublinCoreMetadata dublinCoreMetadata = (DublinCoreMetadata)MetadataUtility.ExtractSpecificMetadata(file, MetadataType.DublinCore);
                        if (dublinCoreMetadata != null)
                        {
                            Console.WriteLine(dublinCoreMetadata.Creator);
                            Console.WriteLine(dublinCoreMetadata.Format);
                            Console.WriteLine(dublinCoreMetadata.Subject);
                        }
                    }
                    catch
                    {
                        Console.WriteLine("Could not load {0}", file);
                    }
                }

            }
            catch (Exception)
            {

                throw;
            }
        }
        /// <summary>
        /// Get DublinCore Metadata of supported file formats using IDublinCore Interface.
        /// Feature is supported in version 18.5 or greater of the API
        /// </summary>
        public static void GetDublinCoreMetadataUsingIDublinCore()
        {
            try
            {
                string[] files = Directory.GetFiles(XMPFilesDirectory);
                foreach (string file in files)
                {
                    try
                    {
                        using (FormatBase format = FormatFactory.RecognizeFormat(file))
                        {
                            IDublinCore dublinCoreContainer = format as IDublinCore;
                            if (dublinCoreContainer != null)
                            {
                                DublinCoreMetadata dublinCoreMetadata = dublinCoreContainer.GetDublinCore();
                                if (dublinCoreMetadata != null)
                                {
                                    Console.WriteLine(dublinCoreMetadata.Creator);
                                    Console.WriteLine(dublinCoreMetadata.Format);
                                    Console.WriteLine(dublinCoreMetadata.Subject);
                                }
                            }
                        }
                    }
                    catch
                    {
                        Console.WriteLine("Could not load {0}", file);
                    }
                }

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
