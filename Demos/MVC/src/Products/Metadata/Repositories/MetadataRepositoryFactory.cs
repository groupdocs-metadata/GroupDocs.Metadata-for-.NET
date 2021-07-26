
using GroupDocs.Metadata.Common;
using GroupDocs.Metadata.Formats.BusinessCard;
using GroupDocs.Metadata.Formats.Font;
using GroupDocs.Metadata.Formats.Video;
using GroupDocs.Metadata.Standards.Exif;
using GroupDocs.Metadata.MVC.Products.Metadata.Repositories.Asf;
using GroupDocs.Metadata.MVC.Products.Metadata.Repositories.Fonts;
using GroupDocs.Metadata.MVC.Products.Metadata.Repositories.Matroska;

namespace GroupDocs.Metadata.MVC.Products.Metadata.Repositories
{
    public static class MetadataRepositoryFactory
    {
        public static MetadataPackageRepository Create(MetadataPackage branchPackage)
        {
            switch (branchPackage.MetadataType)
            {
                case MetadataType.Xmp:
                    return new XmpMetadataRepository(branchPackage);
                case MetadataType.Exif:
                    if (branchPackage is ExifPackage)
                    {
                        return new ExifMetadataRepository(branchPackage);
                    }
                    return new OneLevelMetadataRepository(branchPackage);
                case MetadataType.Iptc:
                    return new IptcMetadataRepository(branchPackage);
                case MetadataType.ID3V2:
                    return new ID3V2TagRepository(branchPackage);
                case MetadataType.Matroska:
                    if (branchPackage is MatroskaTag)
                    {
                        return new MatroskaTagRepository(branchPackage);
                    }
                    if (branchPackage is MatroskaTrack)
                    {
                        return new MatroskaTrackRepository(branchPackage);
                    }
                    return new OneLevelMetadataRepository(branchPackage);
                case MetadataType.FileFormat:
                    return new FileTypeRepository(branchPackage);
                case MetadataType.VCard:
                    if (branchPackage is VCardCard)
                    {
                        return new VCardRepository(branchPackage);
                    }
                    return new OneLevelMetadataRepository(branchPackage);
                case MetadataType.Asf:
                    if (branchPackage is AsfPackage)
                    {
                        return new AsfRepository(branchPackage);
                    }
                    if (branchPackage is AsfCodec)
                    {
                        return new AsfCodecRepository(branchPackage);
                    }
                    if (branchPackage is AsfBaseStreamProperty)
                    {
                        return new AsfStreamRepository(branchPackage);
                    }
                    return new OneLevelMetadataRepository(branchPackage);
                case MetadataType.OpenType:
                    if (branchPackage is OpenTypeFont)
                    {
                        return new OpenTypeRepository(branchPackage);
                    }
                    return new OneLevelMetadataRepository(branchPackage);
                case MetadataType.DigitalSignature:
                    return new DigitalSignatureRepository(branchPackage);
                default:
                    return new OneLevelMetadataRepository(branchPackage);
            }
        }
    }
}