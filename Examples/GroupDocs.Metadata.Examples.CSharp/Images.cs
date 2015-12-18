using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GroupDocs.Metadata.Formats.Image;
using GroupDocs.Metadata.Xmp.Schemas.DublinCore;
using GroupDocs.Metadata.Xmp; 
using GroupDocs.Metadata.Standards.Exif;
using GroupDocs.Metadata.Standards.Exif.Jpeg;
using GroupDocs.Metadata.Examples.Utilities.CSharp;

namespace GroupDocs.Metadata.Examples.CSharp
{
    public static class Images
    {
        public static class Jpeg
        {
            // initialize file path
            //ExStart:SourceJpegFilePath
            private const string filePath = "Images/Jpeg/sample.jpg";
            //ExEnd:SourceJpegFilePath
            #region working with XMP data
            /// <summary>
            ///Gets XMP properties from Jpeg file
            /// </summary> 
            public static void GetXMPProperties()
            {
                try
                {
                    //ExStart:GetXmpPropertiesJpegImage
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
                    //ExEnd:GetXmpPropertiesJpegImage
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
                    //ExStart:UpdateXmpPropertiesJpegImage
                    // initialize JpegFormat
                    JpegFormat jpegFormat = new JpegFormat(Common.MapSourceFilePath(filePath));

                    // get xmp wrapper
                    XmpPacketWrapper xmpPacket = jpegFormat.GetXmpData();

                    // create xmp wrapper if not exists
                    if (xmpPacket == null)
                    {
                        xmpPacket = new XmpPacketWrapper();
                    }

                    // check if DublinCore schema exists
                    if (!xmpPacket.ContainsPackage(Namespaces.DublinCore))
                    {
                        // if not - add DublinCore schema
                        xmpPacket.AddPackage(new DublinCorePackage());
                    }

                    // get DublinCore package
                    DublinCorePackage dublinCorePackage = (DublinCorePackage)xmpPacket.GetPackage(Namespaces.DublinCore);
                     
                    string authorName = "New author"; 
                    string description = "New description";
                    string subject = "New subject" ;
                    string publisher = "New publisher";
                    string title = "New title";

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
                    //ExEnd:UpdateXmpPropertiesJpegImage
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
                    //ExStart:RemoveXmpPropertiesJpegImage
                    // initialize JpegFormat
                    JpegFormat jpegFormat = new JpegFormat(Common.MapSourceFilePath(filePath));

                    // remove XMP package
                    jpegFormat.RemoveXmpData();

                    // commit changes
                    jpegFormat.Save(Common.MapDestinationFilePath(filePath));
                    //ExEnd:RemoveXmpPropertiesJpegImage
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
                    //ExStart:GetExifPropertiesJpegImage
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
                        // get user's Model 
                        Console.WriteLine("Model: {0}", exif.Model);
                        // get user's Make 
                        Console.WriteLine("Make: {0}", exif.Make);
                        // get user's CameraOwnerName 
                        Console.WriteLine("CameraOwnerName: {0}", exif.CameraOwnerName);
                    }
                    //ExEnd:GetExifPropertiesJpegImage
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
                    //ExStart:UpdateExifPropertiesJpegImage
                    // initialize JpegFormat
                    JpegFormat jpegFormat = new JpegFormat(Common.MapSourceFilePath(filePath));
                    
                    // get EXIF data
                    JpegExifInfo exif = (JpegExifInfo)jpegFormat.GetExifInfo();
                    if (exif == null)
                    {
                        // initialize EXIF data if null
                        exif = new JpegExifInfo();
                    }
 
                    // set artist
                    exif.Artist = "Usman";
                    // set make
                    exif.Make = "ABC"; 
                    // set model
                    exif.Model = "S120"; 
                    // set the name of the camera's owner
                    exif.CameraOwnerName = "Owner"; 
                    // set description
                    exif.ImageDescription = "sample description";

                    // update EXIF data
                    jpegFormat.SetExifInfo(exif);

                    // commit changes
                    jpegFormat.Save(Common.MapDestinationFilePath(filePath));
                    //ExEnd:UpdateExifPropertiesJpegImage
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
                    //ExStart:RemoveExifPropertiesJpegImage
                    // initialize JpegFormat
                    JpegFormat jpegFormat = new JpegFormat(Common.MapSourceFilePath(filePath));
                    
                    // remove Exif info
                    jpegFormat.RemoveExifInfo();

                    // commit changes
                    jpegFormat.Save(Common.MapDestinationFilePath(filePath));
                    //ExEnd:RemoveExifPropertiesJpegImage
                    Console.WriteLine("File saved in destination folder.");
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
            //ExStart:SourceGifFilePath
            private const string filePath = "Images/Gif/sample.gif";
            //ExEnd:SourceGifFilePath
            /// <summary>
            ///Gets XMP properties of Gif file
            /// </summary> 
            public static void GetXMPProperties()
            {
                try
                {
                    //ExStart:GetXMPPropertiesGifImage
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
                    //ExEnd:GetXMPPropertiesGifImage
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
                    //ExStart:UpdateXMPPropertiesGifImage
                    // initialize GifFormat
                    GifFormat gifFormat = new GifFormat(Common.MapSourceFilePath(filePath));

                    // get xmp wrapper
                    XmpPacketWrapper xmpPacket = gifFormat.GetXmpData();

                    // create xmp wrapper if not exists
                    if (xmpPacket == null)
                    {
                        xmpPacket = new XmpPacketWrapper();
                    }

                    // check if DublinCore schema exists
                    if (!xmpPacket.ContainsPackage(Namespaces.DublinCore))
                    {
                        // if not - add DublinCore schema
                        xmpPacket.AddPackage(new DublinCorePackage());
                    }

                    // get DublinCore package
                    DublinCorePackage dublinCorePackage = (DublinCorePackage)xmpPacket.GetPackage(Namespaces.DublinCore);

                    string authorName = "New author";
                    string description = "New description";
                    string subject = "New subject";
                    string publisher = "New publisher";
                    string title = "New title";

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
                    //ExEnd:UpdateXMPPropertiesGifImage
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
                    //ExStart:RemoveXMPPropertiesGifImage 
                    // initialize GifFormat
                    GifFormat gifFormat = new GifFormat(Common.MapSourceFilePath(filePath));

                    // remove XMP package
                    gifFormat.RemoveXmpData();

                    // commit changes
                    gifFormat.Save(Common.MapDestinationFilePath(filePath));
                    //ExEnd:RemoveXMPPropertiesGifImage 
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
            //ExStart:SourcePngFilePath
            private const string filePath = "Images/Png/sample.png";
            //ExEnd:SourcePngFilePath
            /// <summary>
            ///Gets XMP properties from Png file
            /// </summary> 
            public static void GetXMPProperties()
            {
                try
                {
                    //ExStart:GetXMPPropertiesPngImage 
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
                        Console.WriteLine("No XMP data found.");
                    }
                    //ExEnd:GetXMPPropertiesPngImage 
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
                    //ExStart:UpdateXMPPropertiesPngImage 
                    // initialize PngFormat
                    PngFormat pngFormat = new PngFormat(Common.MapSourceFilePath(filePath));

                    // get xmp wrapper
                    XmpPacketWrapper xmpPacket = pngFormat.GetXmpData();

                    // create xmp wrapper if not exists
                    if (xmpPacket == null)
                    {
                        xmpPacket = new XmpPacketWrapper();
                    }

                    // check if DublinCore schema exists
                    if (!xmpPacket.ContainsPackage(Namespaces.DublinCore))
                    {
                        // if not - add DublinCore schema
                        xmpPacket.AddPackage(new DublinCorePackage());
                    }

                    // get DublinCore package
                    DublinCorePackage dublinCorePackage = (DublinCorePackage)xmpPacket.GetPackage(Namespaces.DublinCore);

                    string authorName = "New author";
                    string description = "New description";
                    string subject = "New subject";
                    string publisher = "New publisher";
                    string title = "New title";

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
                    //ExEnd:UpdateXMPPropertiesPngImage 
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
                    //ExStart:RemoveXMPPropertiesPngImage 
                    // initialize PngFormat
                    PngFormat pngFormat = new PngFormat(Common.MapSourceFilePath(filePath));

                    // remove XMP package
                    pngFormat.RemoveXmpData();

                    // commit changes
                    pngFormat.Save(Common.MapDestinationFilePath(filePath));
                    //ExEnd:RemoveXMPPropertiesPngImage 
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
