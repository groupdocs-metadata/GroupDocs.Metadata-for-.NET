using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GroupDocs.Metadata.Tools;
using GroupDocs.Metadata.Formats.Image;
using System.IO;

namespace GroupDocs.Metadata.Examples.Utilities.CSharp
{
    //ExStart:PhotoCleaner
    public class PhotoCleaner
    {
        // absolute path to the GroupDocs.Metadata license file.
        private const string LicensePath = @"GroupDocs.Metadata.lic";

        // absolute path to the photos directory.
        public string CleanerPath { get; set; }

        static PhotoCleaner()
        {
            /* set product license 
             * uncomment following function if you have product license
             * */
            //SetInternalLicense();
        }

        public PhotoCleaner(string cleanerPath)
        {
            // check if directory exists
            if (!Directory.Exists(Common.MapSourceFilePath( cleanerPath)))
            {
                throw new DirectoryNotFoundException("Directory not found: " + cleanerPath);
            }
            // set property
            this.CleanerPath = cleanerPath;
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
        /// Removes GPS data and updates the image files in a directory
        /// </summary>
        public void RemoveExifLocation()
        {
            // Map directory in source folder
            string sourceDirectoryPath = Common.MapSourceFilePath(this.CleanerPath);

            // get array of file in specific directory
            string[] files = Directory.GetFiles(sourceDirectoryPath);

            foreach (string path in files)
            {
                // get EXIF data if exists
                ExifMetadata exifMetadata = (ExifMetadata)MetadataUtility.ExtractSpecificMetadata(path, MetadataType.EXIF);

                if (exifMetadata != null)
                {
                    ExifInfo exifInfo = exifMetadata.Data;

                    if (exifInfo.GPSData != null)
                    {
                        // set altitude, latitude and longitude to null values
                        exifInfo.GPSData.Altitude = null;
                        exifInfo.GPSData.Latitude = null;
                        exifInfo.GPSData.LatitudeRef = null;
                        exifInfo.GPSData.Longitude = null;
                        exifInfo.GPSData.LongitudeRef = null;
                    }

                    // and update file
                    MetadataUtility.UpdateMetadata(path, exifMetadata);
                }
            }
            Console.WriteLine("Press any key to exit.");
        }
    }
    //ExEnd:PhotoCleaner
}
