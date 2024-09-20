// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2024 GroupDocs. All Rights Reserved.
// </copyright>

namespace GroupDocs.Metadata.Examples.CSharp
{
    using System.IO;

    public static class Constants
    {
        static Constants()
        {
            if (!Directory.Exists(OutputPath))
                Directory.CreateDirectory(OutputPath);
        }

        public const string ResourcesPath = @".\Resources\";

        public static readonly string LicenseFilePath = @"C:\Work\License\GroupDocs.Metadata.Product.Family.lic";

        public static readonly string InputPath = Path.Combine(ResourcesPath, @"SampleFiles");
        public static readonly string OutputPath = Path.Combine(ResourcesPath, @"SampleFiles\Output");

        
        public static readonly string InputDocx = Path.Combine(InputPath, "input.docx");
        public static readonly string InputPptx = Path.Combine(InputPath, "input.pptx");
        public static readonly string InputXlsx = Path.Combine(InputPath, "input.xlsx");
        public static readonly string InputVsdx = Path.Combine(InputPath, "input.vsdx");
        public static readonly string InputVdx = Path.Combine(InputPath, "input.vdx");
        public static readonly string InputPdf = Path.Combine(InputPath, "input.pdf");
        public static readonly string CopyPdf = Path.Combine(InputPath, "copy.pdf");
        public static readonly string InputOne = Path.Combine(InputPath, "input.one");
        public static readonly string InputDoc = Path.Combine(InputPath, "input.doc");
        public static readonly string InputPpt = Path.Combine(InputPath, "input.ppt");
        public static readonly string InputXls = Path.Combine(InputPath, "input.xls");
        public static readonly string InputJpeg = Path.Combine(InputPath, "input.jpg");
        public static readonly string InputPng = Path.Combine(InputPath, "input.png");
        public static readonly string InputGif = Path.Combine(InputPath, "input.gif");
        public static readonly string InputDng = Path.Combine(InputPath, "sample1.dng");
        public static readonly string InputMpp = Path.Combine(InputPath, "input.mpp");
        public static readonly string InputBmp = Path.Combine(InputPath, "input.bmp");
        public static readonly string InputJpeg2000 = Path.Combine(InputPath, "input.jp2");
        public static readonly string InputDicom = Path.Combine(InputPath, "input.dicom");
        public static readonly string InputAsf = Path.Combine(InputPath, "input.asf");
        public static readonly string InputAvi = Path.Combine(InputPath, "input.avi");
        public static readonly string InputFlv = Path.Combine(InputPath, "input.flv");
        public static readonly string InputMkv = Path.Combine(InputPath, "input.mkv");
        public static readonly string InputMov = Path.Combine(InputPath, "input.mov");
        public static readonly string InputWav = Path.Combine(InputPath, "input.wav");
        public static readonly string InputZip = Path.Combine(InputPath, "input.zip");
        public static readonly string InputRar = Path.Combine(InputPath, "input.rar");
        public static readonly string InputTar = Path.Combine(InputPath, "input.tar");
        public static readonly string InputSevenZip = Path.Combine(InputPath, "input.7z");
        public static readonly string InputVcf = Path.Combine(InputPath, "input.vcf");
        public static readonly string InputDxf = Path.Combine(InputPath, "input.dxf");
        public static readonly string InputEpub = Path.Combine(InputPath, "input.epub");
        public static readonly string InputEml = Path.Combine(InputPath, "input.eml");
        public static readonly string InputMsg = Path.Combine(InputPath, "input.msg");
        public static readonly string InputTtf = Path.Combine(InputPath, "input.ttf");
        public static readonly string InputTorrent = Path.Combine(InputPath, "input.torrent");
        public static readonly string PngWithXmp = Path.Combine(InputPath, "xmp.png");
        public static readonly string GifWithXmp = Path.Combine(InputPath, "xmp.gif");
        public static readonly string JpegWithXmp = Path.Combine(InputPath, "xmp.jpg");
        public static readonly string TiffWithExif = Path.Combine(InputPath, "exif.tiff");
        public static readonly string TiffWithIptc = Path.Combine(InputPath, "iptc.tiff");
        public static readonly string JpegWithExif = Path.Combine(InputPath, "exif.jpg");
        public static readonly string JpegWithIptc = Path.Combine(InputPath, "iptc.jpg");
        public static readonly string PsdWithIptc = Path.Combine(InputPath, "iptc.psd");
        public static readonly string PsdWithExif = Path.Combine(InputPath, "exif.psd");
        public static readonly string JpegWithIrb = Path.Combine(InputPath, "irb.jpg");
        public static readonly string JpegWithBarcodes = Path.Combine(InputPath, "barcode.jpg");
        public static readonly string PsdWithIrb = Path.Combine(InputPath, "irb.psd");
        public static readonly string ProtectedDocx = Path.Combine(InputPath, "protected.docx");
        public static readonly string SignedPdf = Path.Combine(InputPath, "signed.pdf");
        public static readonly string MkvWithSubtitles = Path.Combine(InputPath, "subtitles.mkv");
        public static readonly string MP3WithID3V1 = Path.Combine(InputPath, "id3v1.mp3");
        public static readonly string MP3WithID3V2 = Path.Combine(InputPath, "id3v2.mp3");
        public static readonly string MP3WithLyrics = Path.Combine(InputPath, "lyrics.mp3");
        public static readonly string MP3WithApe = Path.Combine(InputPath, "ape.mp3");
        public static readonly string CanonJpeg = Path.Combine(InputPath, "canon_raw.jpg");
        public static readonly string NikonJpeg = Path.Combine(InputPath, "nikon_raw.jpg");
        public static readonly string PanasonicJpeg = Path.Combine(InputPath, "panasonic_raw.jpg");
        public static readonly string SonyJpeg = Path.Combine(InputPath, "sony_raw.jpg");
        public static readonly string InputCr2 = Path.Combine(InputPath, "input.CR2");

        public static readonly string Input3ds = Path.Combine(InputPath, "input.3ds");
        public static readonly string InputDae = Path.Combine(InputPath, "input.dae");
        public static readonly string InputFbx = Path.Combine(InputPath, "input.fbx");
        public static readonly string InputStl = Path.Combine(InputPath, "input.stl");

        public static readonly string InputKml = Path.Combine(InputPath, "input.kml");


        public static readonly string OutputDocx = Path.Combine(OutputPath, "output.docx");
        public static readonly string OutputPptx = Path.Combine(OutputPath, "output.pptx");
        public static readonly string OutputXlsx = Path.Combine(OutputPath, "output.xlsx");
        public static readonly string OutputVsdx = Path.Combine(OutputPath, "output.vsdx");
        public static readonly string OutputVdx = Path.Combine(OutputPath, "output.vdx");
        public static readonly string OutputPdf = Path.Combine(OutputPath, "output.pdf");
        public static readonly string OutputOne = Path.Combine(OutputPath, "output.one");
        public static readonly string OutputDoc = Path.Combine(OutputPath, "output.doc");
        public static readonly string OutputPpt = Path.Combine(OutputPath, "output.ppt");
        public static readonly string OutputXls = Path.Combine(OutputPath, "output.xls");
        public static readonly string OutputMpp = Path.Combine(OutputPath, "output.mpp");
        public static readonly string OutputJpeg = Path.Combine(OutputPath, "output.jpg");
        public static readonly string OutputPng = Path.Combine(OutputPath, "output.png");
        public static readonly string OutputGif = Path.Combine(OutputPath, "output.gif");
        public static readonly string OutputTiff = Path.Combine(OutputPath, "output.tiff");
        public static readonly string OutputPsd = Path.Combine(OutputPath, "output.psd");
        public static readonly string OutputBmp = Path.Combine(OutputPath, "output.bmp");
        public static readonly string OutputMp3 = Path.Combine(OutputPath, "output.mp3");
        public static readonly string OutputZip = Path.Combine(OutputPath, "output.zip");
        public static readonly string OutputEml = Path.Combine(OutputPath, "output.eml");
        public static readonly string OutputMsg = Path.Combine(OutputPath, "output.msg");
        public static readonly string OutputTorrent = Path.Combine(OutputPath, "output.torrent");
        public static readonly string OutputCsv = Path.Combine(OutputPath, "output.csv");
        public static readonly string OutputEpub = Path.Combine(OutputPath, "output.epub");
        public static readonly string OutputDxf = Path.Combine(OutputPath, "output.dxf");
        public static readonly string OutputXml = Path.Combine(OutputPath, "output.xml");

        public static readonly string ImportPdf = Path.Combine(InputPath, "pdf.json");
    }
}

