using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GroupDocs.Metadata.Formats;
using System.IO;
using GroupDocs.Metadata.Tools;
using GroupDocs.Metadata.Formats.Image;

namespace GroupDocs.Metadata.Examples.Utilities.CSharp
{
    //ExStart:JpegPhotoParser
    public class JpegPhotoParser
    {
     
        // absolute path to the GroupDocs.Metadata license file.
        private const string LicensePath = @"GroupDocs.Metadata.lic";

        // absolute path to the photos directory.
        public string PhotosDirectory { get; set; }

        static JpegPhotoParser()
        {
            /* set product license 
             * uncomment following function if you have product license
             * */
            //SetInternalLicense();
        }

        public JpegPhotoParser(string photosDirectory)
        {
            // check if directory exists
            if (!Directory.Exists(Common.MapSourceFilePath( photosDirectory)))
            {
                throw new DirectoryNotFoundException("Directory not found: " + photosDirectory);
            }
            // set property
            this.PhotosDirectory = photosDirectory;
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
        /// Takes manufacturer as input and returns photos made on particular camera
        /// </summary>
        /// <param name="manufacturer">Camera manufacturer name</param> 
        public void FilterByCameraManufacturer(string manufacturer)
        {
            // Map directory in source folder
            string sourceDirectoryPath = Common.MapSourceFilePath(this.PhotosDirectory);
            // get jpeg files
            string[] files = Directory.GetFiles(sourceDirectoryPath, "*.jpg");

            List<string> result = new List<string>();

            foreach (string path in files)
            {
                // recognize file
                FormatBase format = FormatFactory.RecognizeFormat(path);

                // casting to JpegFormat
                if (format is JpegFormat)
                {
                    JpegFormat jpeg = (JpegFormat)format;

                    // get exif data
                    JpegExifInfo exif = (JpegExifInfo)jpeg.GetExifInfo();

                    if (exif != null)
                    {
                        if (string.Compare(exif.Make, manufacturer, StringComparison.OrdinalIgnoreCase) == 0)
                        {
                            // add file path to list
                            result.Add(Path.GetFileName(path));
                        }
                    }
                }
            }
            Console.WriteLine(string.Join("\n", result));
        }
    }
    //ExEnd:JpegPhotoParser
}
