using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GroupDocs.Metadata.Formats.Image;
using GroupDocs.Metadata.Xmp;
using GroupDocs.Metadata.Tools;
using GroupDocs.Metadata.Standards.Xmp;
using GroupDocs.Metadata.Xmp.Types.Basic;
using GroupDocs.Metadata.Xmp.Types.Derived;
using GroupDocs.Metadata.Xmp.Types.Complex.Colorant;
using GroupDocs.Metadata.Xmp.Types.Complex.Dimensions;
using GroupDocs.Metadata.Xmp.Types.Complex.Font;
using GroupDocs.Metadata.Xmp.Types.Complex.ResourceEvent;
using GroupDocs.Metadata.Xmp.Types.Complex.ResourceRef;
using GroupDocs.Metadata.Xmp.Schemas.XmpMM;
using System.Drawing;
using System.IO;
using GroupDocs.Metadata.Xmp.Types.Complex.Thumbnail;
using GroupDocs.Metadata.Xmp.Types.Complex.Version;


namespace GroupDocs.Metadata.Examples.Utilities.CSharp
{
    public class XMPData
    {
        public void GetXMPData()
        {
            try
            {
                //ExStart:GetXMPData
                // create new instance of GifFormat
                GifFormat gif = new GifFormat(@"C:\sample.gif");

                // old version of gif format does not support xmp
                if (!gif.IsSupportedXmp)
                {
                    return;
                }

                // get XMP data
                XmpPacketWrapper xmp = gif.GetXmpData();
                //ExEnd:GetXMPData
            }
            catch (Exception exp)
            { 
            
            }
        }
        public void RemoveXMPData()
        {
            try
            {
                //ExStart:RemoveXMPData
                // create new instance of JpegFormat
                JpegFormat jpeg = new JpegFormat(@"C:\image.jpg");

                // use RemoveXmpData method to remove xmp metadata
                jpeg.RemoveXmpData();
                //ExEnd:RemoveXMPData
            }
            catch (Exception exp)
            {

            }
        }
        public void UpdateXMPData()
        {
            try
            {
                //ExStart:UpdateXMP
                // path to the modified file
                string filePath = "Images/Jpeg/sample.jpg";

                // get xmp wrapper
                XmpPacketWrapper xmpWrapper = MetadataUtility.ExtractXmpPackage(filePath);

                // if wrapper is null
                if (xmpWrapper == null)
                {
                    // create it
                    xmpWrapper = new XmpPacketWrapper();
                }

                // create package
                XmpPackage addingSchema = new XmpPackage("rs", "http://www.metadataworkinggroup.com/schemas/regions/");

                // set date property
                addingSchema.AddValue("rs:createdDate", DateTime.UtcNow);

                // set string property
                addingSchema.AddValue("rs:File", "File name");

                //initialze unordered xmp array
                XmpArray managersArray = new XmpArray(XmpArrayType.UNORDERED);
                managersArray.AddItem("Joe Doe");
                managersArray.AddItem("Adam White");

                // set array property
                addingSchema.SetArray("rs:managers", managersArray);

                // initialize xmp language alternative
                LangAlt availableDays = new LangAlt();
                // add first value for 'en-us' language
                availableDays.AddLanguage("en-us", "Tue");
                // add second value for 'en-us' languge
                availableDays.AddLanguage("en-us", "Fri");

                // set LangAlt property
                addingSchema.SetLangAlt("rs:days", availableDays);

                // update xmp wrapper with new schema
                xmpWrapper.AddPackage(addingSchema);

                // create XmpMetadata with updated wrapper
                XmpMetadata xmpMetadata = new XmpMetadata();
                xmpMetadata.XmpPacket = xmpWrapper;

                // update XMP
                MetadataUtility.UpdateMetadata(filePath, xmpMetadata);
                //ExEnd:UpdateXMP
            }
            catch (Exception exp)
            {

            }
        }
        public void CreateBasicXMPTypes()
        {
            //ExStart:CreateXMPBoolean
            // create XmpBoolean from string
            XmpBoolean xmpBoolean = new XmpBoolean("True");

            // create XmpBoolean using .NET bool
            XmpBoolean xmpBoolean2 = new XmpBoolean(true);

            // values should be equal
            if (xmpBoolean.Value == xmpBoolean2.Value)
            {
                Console.WriteLine("Equals!");
            }
            //ExEnd:CreateXMPBoolean
            

            //ExStart:CreateXMPDate
            // create date from string
            XmpDate date1 = new XmpDate("2016-01-10");

            // create the same date using.NET DateTime
            XmpDate date2 = new XmpDate(new DateTime(2016, 01, 10));
            //ExEnd:CreateXMPDate

        }
        public void CreateDerivedXMPTypes()
        {
            //ExStart:CreateXMPGuid
            // init new C# struct Guid
            Guid guid = Guid.NewGuid();

            // create xmp guid using C# struct
            XmpGuid xmpGuid = new XmpGuid(guid);

            // create xmp guid using it's string representation
            XmpGuid xmpGuid2 = new XmpGuid(guid.ToString());
            //ExEnd:CreateXMPGuid
            

            //ExStart:CreateRational
            int numerator = 1;
            int denominator = 10;

            // create xmp rational
            Rational rational = new Rational(numerator, denominator);

            // float value should be 0.1
            float value = rational.FloatValue;
            //ExEnd:CreateRational

            
            //ExStart:CreateLanguageAlternative
            // init LangAlt with default value
            LangAlt langAlt = new LangAlt("XMP - Extensible Metadata Platform");

            // add value for en-us language
            langAlt.AddLanguage("en-us", "XMP - Extensible Metadata Platform");

            // add value for French language
            langAlt.AddLanguage("fr", "XMP - Une Platforme Extensible pour les Métadonnées");
            //ExEnd:CreateLanguageAlternative

        }
        public void CreateComplexXMPTypes()
        {
            //ExStart:CreateColorant
            // create RGB colorant with R, G, B components
            ColorantRGB rgbColorant = new ColorantRGB(254, 254, 1);

            // create CMYK colorant with Black, Cyan, Magenta, Yellow components
            ColorantCMYK cmykColorant = new ColorantCMYK(10, 10, 1, 50);
            //ExEnd:CreateColorant


            //ExStart:CreateDimensions
            int width = 100;
            int height = 50;

            // create dimensions
            Dimensions dimensions = new Dimensions(width, height);
            dimensions.Units = "inch";

            // create dimensions using object initializer
            Dimensions dimensions2 = new Dimensions();
            dimensions2.Width = width;
            dimensions2.Height = height;
            dimensions2.Units = "inch";
            //ExEnd:CreateDimensions


            //ExStart:CreateFont
            string fontFamily = "Arial";

            // create Arial font
            GroupDocs.Metadata.Xmp.Types.Complex.Font.Font font = new GroupDocs.Metadata.Xmp.Types.Complex.Font.Font(fontFamily);
            //ExEnd:CreateFont


            //ExStart:CreateResourceEvent
            // create ResourceEvent type
            ResourceEvent resourceEvent = new ResourceEvent();

            // set the action that occurred
            resourceEvent.Action = "edited";

            // Additional description of the action
            resourceEvent.Parameters = "secon version";
            //ExEnd:CreateResourceEvent


            //ExStart:CreateResourceRef
            ResourceRef expectedValue = new ResourceRef
            {
                DocumentUri = "074255bf-78bc-4002-89dc-cd7538b40fe0",
                InstanceId = "42a841b7-48d4-4988-8988-53d2c6e7525d"
            };

            // create XmpMediaManagementPackage
            XmpMediaManagementPackage package = new XmpMediaManagementPackage();

            // update DerivedFrom property
            package.SetDerivedFrom(expectedValue);

            // check value
            ResourceRef value = (ResourceRef)package["xmpMM:DerivedFrom"];
            //ExEnd:CreateResourceRef


            //ExStart:CreateThumbnail
            // path to the image
            string imagePath = @"C:\\image.jpg";
            string base64String;

            // use System.Drawing to get image base64 string
            using ( Image image = Image.FromFile(imagePath))
            {
                using (MemoryStream m = new MemoryStream())
                {
                    image.Save(m, image.RawFormat);
                    byte[] imageBytes = m.ToArray();

                    // Convert byte[] to Base64 String
                    base64String = Convert.ToBase64String(imageBytes);
                }
            }

            // xmp thumbnail width
            int thumbnailWidth = 100;

            // xmp thumbnail height
            int thumbnailHeight = 50;

            // create xmp thumbnail 
            Thumbnail thumbnail = new Thumbnail(thumbnailWidth, thumbnailHeight);

            // add provide image base64 string
            thumbnail.ImageBase64 = base64String;
            //ExEnd:CreateThumbnail


            //ExStart:CreateVersion
            // create new instance of Version
            GroupDocs.Metadata.Xmp.Types.Complex.Version.Version version = new GroupDocs.Metadata.Xmp.Types.Complex.Version.Version();

            // set version number
            version.VersionText = "1.0";

            // set version date
            version.ModifiedDate = DateTime.UtcNow;

            // set person who modified this version
            version.Modifier = "Joe Doe";

            // set version additional comments
            version.Comments = "First version, created by: Joe Doe";
            //ExEnd:CreateVersion
        }
    }
}
