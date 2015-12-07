using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GroupDocs.Metadata.Formats.Image;
using GroupDocs.Metadata.Xmp.Schemas.DublinCore;
using GroupDocs.Metadata.Xmp;
using GroupDocs.Metadata.Standards.Exif.Tiff;
using GroupDocs.Metadata.Standards.Exif;
using GroupDocs.Metadata.Standards.Exif.Jpeg;

namespace GroupDocs.Metadata.Examples.CSharp
{
    public static class Images
    {
        public static class Jpeg
        {
            // initialize file path
            private const string filePath = "Images/Jpeg/sample.jpeg";

            #region working with XMP data
            /// <summary>
            ///Gets XMP properties from Jpeg file
            /// </summary> 
            public static void GetXMPProperties()
            {
                try
                {
                    
                    // initialize JpegFormat
                    JpegFormat jpegFormat = new JpegFormat(Common.MapSourceFilePath(filePath));

                    // get XMP data
                    XmpProperties xmpProperties = jpegFormat.GetXmpProperties();

                    // show XMP data
                    foreach (string key in xmpProperties.Keys)
                    {
                        XmpNodeView xmpNodeView = xmpProperties[key];
                        Console.WriteLine("[{0}] = {1}", xmpNodeView.Name, xmpNodeView.Value);
                    }
                }
                catch (Exception exp)
                {
                    Console.WriteLine(exp.Message);
                }
            }
            /// <summary>
            /// Updates XMP data of Jpeg file and creates output file
            /// </summary> 
            public static void UpdateXMPProperties()
            {
                try
                {
                     
                    // initialize JpegFormat
                    JpegFormat jpegFormat = new JpegFormat(Common.MapSourceFilePath(filePath));

                    // get xmp wrapper
                    XmpPacketWrapper xmpPacket = jpegFormat.GetXmpData();

                    // create xmp wrapper is not exist
                    if (xmpPacket == null)
                    {
                        xmpPacket = new XmpPacketWrapper();
                    }

                    // check if DublinCore schema is exist
                    if (!xmpPacket.ContainsPackage(Namespaces.DublinCore))
                    {
                        // if no - add DublinCore schema
                        xmpPacket.AddPackage(new DublinCorePackage());
                    }

                    // get DublinCore package
                    DublinCorePackage dublinCorePackage = (DublinCorePackage)xmpPacket.GetPackage(Namespaces.DublinCore);

                    // get details from user
                    Console.WriteLine("Enter author's name:");
                    string authorName = Console.ReadLine();
                    
                    Console.WriteLine("Enter description name:");
                    string description = Console.ReadLine();
                    
                    Console.WriteLine("Enter subject:");
                    string subject = Console.ReadLine();
                    
                    Console.WriteLine("Enter publisher:");
                    string publisher = Console.ReadLine();
                    
                    Console.WriteLine("Enter title:");
                    string title = Console.ReadLine();

                    // set author
                    dublinCorePackage.SetAuthor(authorName);
                    // set description
                    dublinCorePackage.SetDescription(description);
                    // set subject
                    dublinCorePackage.SetSubject(subject);
                    // set publisher
                    dublinCorePackage.SetPublisher(publisher);
                    // set title
                    dublinCorePackage.SetTitle(title);
                    // update XMP package
                    jpegFormat.SetXmpData(xmpPacket);

                    // commit changes
                    jpegFormat.Save(Common.MapDestinationFilePath(filePath));
                    Console.WriteLine("File saved in destination folder.");
                }
                catch (Exception exp)
                {
                    Console.WriteLine(exp.Message);
                }
            }
            /// <summary>
            /// Removes XMP data of Jpeg file and creates output file
            /// </summary> 
            public static void RemoveXMPData()
            {
                try
                {
                     
                    // initialize JpegFormat
                    JpegFormat jpegFormat = new JpegFormat(Common.MapSourceFilePath(filePath));

                    // remove XMP package
                    jpegFormat.RemoveXmpData();

                    // commit changes
                    jpegFormat.Save(Common.MapDestinationFilePath(filePath));

                    Console.WriteLine("File saved in destination folder.");
                }
                catch (Exception exp)
                {
                    Console.WriteLine(exp.Message);
                }
            }
            #endregion

            #region working with Exif properties
            /// <summary>
            /// Gets Exif info from Jpeg file
            /// </summary> 
            public static void GetExifInfo()
            {
                try
                {
                     
                    // initialize JpegFormat
                    JpegFormat jpegFormat = new JpegFormat(Common.MapSourceFilePath(filePath));

                    // get EXIF data
                    JpegExifInfo exif = (JpegExifInfo)jpegFormat.GetExifInfo();

                    if (exif != null)
                    {
                        // get artist 
                        Console.WriteLine("Artist: {0}", exif.Artist);
                        // get description 
                        Console.WriteLine("Description: {0}", exif.ImageDescription);
                        // get user's comment 
                        Console.WriteLine("User Comment: {0}", exif.UserComment);
                    }
                }
                catch(Exception exp)
                {
                    Console.WriteLine(exp.Message);
                }
            }
            /// <summary>
            /// Updates Exif info of Jpeg file and creates output file
            /// </summary> 
            public static void UpdateExifInfo()
            {
                try
                {
                     
                    // initialize JpegFormat
                    JpegFormat jpegFormat = new JpegFormat(Common.MapSourceFilePath(filePath));
                    
                    // get EXIF data
                    JpegExifInfo exif = (JpegExifInfo)jpegFormat.GetExifInfo();
                    if (exif == null)
                    {
                        // initialize EXIF data if null
                        exif = new JpegExifInfo();
                    }

                    // get details from user
                    Console.WriteLine("Enter artist:");
                    string artist = Console.ReadLine();
                    
                    Console.WriteLine("Enter camera owner name:");
                    string cameraOwnerName = Console.ReadLine();
                    
                    Console.WriteLine("Enter make:");
                    string make = Console.ReadLine();
                    
                    Console.WriteLine("Enter model:");
                    string model = Console.ReadLine();
                    
                    Console.WriteLine("Enter description:");
                    string description = Console.ReadLine();

                    // set artist
                    exif.Artist = artist;
                    // set make
                    exif.Make = make;
                    // set model
                    exif.Model = model;
                    // set the name of the camera's owner
                    exif.CameraOwnerName = cameraOwnerName;
                    // set description
                    exif.ImageDescription = description;

                    // update EXIF data
                    jpegFormat.SetExifInfo(exif);

                    // commit changes
                    jpegFormat.Save(Common.MapDestinationFilePath(filePath));

                    Console.WriteLine("File saved in destination folder.");
                }
                catch (Exception exp)
                {
                    Console.WriteLine(exp.Message);
                }
            }
            /// <summary>
            /// Removes Exif info of Jpeg file and creates output file
            /// </summary> 
            public static void RemoveExifInfo()
            {
                try
                {
                     
                    // initialize JpegFormat
                    JpegFormat jpegFormat = new JpegFormat(Common.MapSourceFilePath(filePath));

                    // not supported yet...
                }
                catch (Exception exp)
                {
                    Console.WriteLine(exp.Message);
                }
            }
            #endregion

        }
        public static class Gif
        {
            // initialize file path
            private const string filePath = "Images/Gif/sample.gif";

            /// <summary>
            ///Gets XMP properties of Gif file
            /// </summary> 
            public static void GetXMPProperties()
            {
                try
                {
                    
                    // initialize GifFormat
                    GifFormat gifFormat = new GifFormat(Common.MapSourceFilePath(filePath));

                    // get XMP data
                    XmpProperties xmpProperties = gifFormat.GetXmpProperties();

                    // show XMP data
                    foreach (string key in xmpProperties.Keys)
                    {
                        XmpNodeView xmpNodeView = xmpProperties[key];
                        Console.WriteLine("[{0}] = {1}", xmpNodeView.Name, xmpNodeView.Value);
                    }
                }
                catch (Exception exp)
                {
                    Console.WriteLine(exp.Message);
                }
            }
            /// <summary>
            /// Updates XMP data of Gif file and creates output file
            /// </summary> 
            public static void UpdateXMPProperties()
            {
                try
                {
                     
                    // initialize GifFormat
                    GifFormat gifFormat = new GifFormat(Common.MapSourceFilePath(filePath));

                    // get xmp wrapper
                    XmpPacketWrapper xmpPacket = gifFormat.GetXmpData();

                    // create xmp wrapper is not exist
                    if (xmpPacket == null)
                    {
                        xmpPacket = new XmpPacketWrapper();
                    }

                    // check if DublinCore schema is exist
                    if (!xmpPacket.ContainsPackage(Namespaces.DublinCore))
                    {
                        // if no - add DublinCore schema
                        xmpPacket.AddPackage(new DublinCorePackage());
                    }

                    // get DublinCore package
                    DublinCorePackage dublinCorePackage = (DublinCorePackage)xmpPacket.GetPackage(Namespaces.DublinCore);

                    // get details from user
                    Console.WriteLine("Enter author's name:");
                    string authorName = Console.ReadLine();
                    
                    Console.WriteLine("Enter description:");
                    string description = Console.ReadLine();
                    
                    Console.WriteLine("Enter subject:");
                    string subject = Console.ReadLine();
                    
                    Console.WriteLine("Enter publisher:");
                    string publisher = Console.ReadLine();
                    
                    Console.WriteLine("Enter title:");
                    string title = Console.ReadLine();

                    // set author
                    dublinCorePackage.SetAuthor(authorName);
                    // set description
                    dublinCorePackage.SetDescription(description);
                    // set subject
                    dublinCorePackage.SetSubject(subject);
                    // set publisher
                    dublinCorePackage.SetPublisher(publisher);
                    // set title
                    dublinCorePackage.SetTitle(title);
                    // update XMP package
                    gifFormat.SetXmpData(xmpPacket);

                    // commit changes
                    gifFormat.Save(Common.MapDestinationFilePath(filePath));

                    Console.WriteLine("File saved in destination folder.");
                }
                catch (Exception exp)
                {
                    Console.WriteLine(exp.Message);
                }
            }
            /// <summary>
            /// Removes XMP data of Gif file and creates output file
            /// </summary> 
            public static void RemoveXMPProperties()
            {
                try
                {
                     
                    // initialize GifFormat
                    GifFormat gifFormat = new GifFormat(Common.MapSourceFilePath(filePath));

                    // remove XMP package
                    gifFormat.RemoveXmpData();

                    // commit changes
                    gifFormat.Save(Common.MapDestinationFilePath(filePath));

                    Console.WriteLine("File saved in destination folder.");
                }
                catch (Exception exp)
                {
                    Console.WriteLine(exp.Message);
                }
            }

        }

        public static class Tiff
        {
            // initialize file path
            private const string filePath = "Images/Tiff/sample.tif";

            /// <summary>
            /// Gets Exif info from Tiff file
            /// </summary> 
            public static void GetExifInfo()
            {
                try
                {
                    
                    // initialize TiffFormat
                    TiffFormat tiffFormat = new TiffFormat(Common.MapSourceFilePath(filePath));

                    // get EXIF data
                    TiffExifInfo exif = (TiffExifInfo)tiffFormat.GetExifInfo();

                    if (exif != null)
                    {
                        // get GPS data 
                        Console.WriteLine("GPS: {0}", exif.GPSData);
                        // get user comment 
                        Console.WriteLine("User comment: {0}", exif.UserComment);
                    }
                }
                catch(Exception exp)
                {
                    Console.WriteLine(exp.Message);
                }
            }
            /// <summary>
            /// Updates Exif info of Tiff file and creates output file
            /// </summary> 
            public static void UpdateExifInfo()
            {
                try
                {
                     
                    // initialize TiffFormat
                    TiffFormat tiffFormat = new TiffFormat(Common.MapSourceFilePath(filePath));

                    // get EXIF data
                    //TiffExifInfo exif = (TiffExifInfo)tiffFormat.GetExifInfo();
                    GpsInfo gps = new GpsInfo { Altitude = new Rational(1, 5) };
                    TiffExifInfo exif = new TiffExifInfo()
                    {
                        //GPSData=gps,
                        UserComment = "This is updated comment.",
                    };
                    //if (exif == null)
                    //{
                    //    // initialize EXIF data if null
                    //    exif = new TiffExifInfo();
                    //}

                    //// get details from user
                    //Console.WriteLine("Enter comment:");
                    //string comment = Console.ReadLine();


                    //// set GPS data
                    //exif.GPSData.Altitude = new Rational(54,1); 
                    //// set comment
                    //exif.UserComment = comment; 


                    // update EXIF data
                    tiffFormat.SetExifInfo(exif);

                    // commit changes
                    tiffFormat.Save(Common.MapDestinationFilePath(filePath));

                    Console.WriteLine("File saved in destination folder.");
                }
                catch (Exception exp)
                {
                    Console.WriteLine(exp.Message);
                }
            }
            /// <summary>
            /// Removes Exif info of Tiff file and creates output file
            /// </summary> 
            public static void RemoveExifInfo()
            {
                try
                {
                     
                    // initialize TiffFormat
                    TiffFormat tiffFormat = new TiffFormat(Common.MapSourceFilePath(filePath));

                    // remove XMP package
                    tiffFormat.CleanMetadata();

                    // commit changes
                    tiffFormat.Save(Common.MapDestinationFilePath(filePath));

                    Console.WriteLine("File saved in destination folder.");
                }
                catch (Exception exp)
                {
                    Console.WriteLine(exp.Message);
                }
            }

        }
        public static class Png
        {
            // initialize file path
            private const string filePath = "Images/Png/sample.png";

            /// <summary>
            ///Gets XMP properties from Png file
            /// </summary> 
            public static void GetXMPProperties()
            {
                try
                {
                    
                    // initialize PngFormat
                    PngFormat pngFormat = new PngFormat(Common.MapSourceFilePath(filePath));

                    // get XMP data
                    XmpProperties xmpProperties = pngFormat.GetXmpProperties();

                    if (xmpProperties != null)
                    {
                        // show XMP data
                        foreach (string key in xmpProperties.Keys)
                        {
                            XmpNodeView xmpNodeView = xmpProperties[key];
                            Console.WriteLine("[{0}] = {1}", xmpNodeView.Name, xmpNodeView.Value);
                        }
                    }
                    else
                    {
                        Console.WriteLine("No XMP property found.");
                    }
                }
                catch (Exception exp)
                {
                    Console.WriteLine(exp.Message);
                }
            }
            /// <summary>
            /// Updates XMP data of Png file and creates output file
            /// </summary> 
            public static void UpdateXMPData()
            {
                try
                {
                     
                    // initialize PngFormat
                    PngFormat pngFormat = new PngFormat(Common.MapSourceFilePath(filePath));

                    // get xmp wrapper
                    XmpPacketWrapper xmpPacket = pngFormat.GetXmpData();

                    // create xmp wrapper is not exist
                    if (xmpPacket == null)
                    {
                        xmpPacket = new XmpPacketWrapper();
                    }

                    // check if DublinCore schema is exist
                    if (!xmpPacket.ContainsPackage(Namespaces.DublinCore))
                    {
                        // if no - add DublinCore schema
                        xmpPacket.AddPackage(new DublinCorePackage());
                    }

                    // get DublinCore package
                    DublinCorePackage dublinCorePackage = (DublinCorePackage)xmpPacket.GetPackage(Namespaces.DublinCore);

                    // get details from user
                    Console.WriteLine("Enter author's name:");
                    string authorName = Console.ReadLine();
                    
                    Console.WriteLine("Enter description name:");
                    string description = Console.ReadLine();
                    
                    Console.WriteLine("Enter subject:");
                    string subject = Console.ReadLine();
                    
                    Console.WriteLine("Enter publisher:");
                    string publisher = Console.ReadLine();
                    
                    Console.WriteLine("Enter title:");
                    string title = Console.ReadLine();

                    // set author
                    dublinCorePackage.SetAuthor(authorName);
                    // set description
                    dublinCorePackage.SetDescription(description);
                    // set subject
                    dublinCorePackage.SetSubject(subject);
                    // set publisher
                    dublinCorePackage.SetPublisher(publisher);
                    // set title
                    dublinCorePackage.SetTitle(title);
                    // update XMP package
                    pngFormat.SetXmpData(xmpPacket);

                    // commit changes
                    pngFormat.Save(Common.MapDestinationFilePath(filePath));

                    Console.WriteLine("File saved in destination folder.");
                }
                catch (Exception exp)
                {
                    Console.WriteLine(exp.Message);
                }
            }
            /// <summary>
            /// Removes XMP data of Png file and creates output file
            /// </summary> 
            public static void RemoveXMPData()
            {
                try
                {
                     
                    // initialize PngFormat
                    PngFormat pngFormat = new PngFormat(Common.MapSourceFilePath(filePath));

                    // remove XMP package
                    pngFormat.RemoveXmpData();

                    // commit changes
                    pngFormat.Save(Common.MapDestinationFilePath(filePath));

                    Console.WriteLine("File saved in destination folder.");
                }
                catch (Exception exp)
                {
                    Console.WriteLine(exp.Message);
                }
            }

        } 
    }
}
