
using GroupDocs.Metadata.Common;
using GroupDocs.Metadata.Standards.Exif;
using System.Collections.Generic;

namespace GroupDocs.Metadata.MVC.Products.Metadata.Repositories
{
    public class ExifMetadataRepository : MetadataPackageRepository
    {
        public ExifMetadataRepository(MetadataPackage branchPackage) : base(branchPackage)
        {
        }

        protected override IEnumerable<MetadataPackage> GetPackages()
        {
            var exifPackage = (ExifPackage)BranchPackage;
            yield return exifPackage.ExifIfdPackage;
            yield return exifPackage.GpsPackage;
            yield return exifPackage;
        }
    }
}