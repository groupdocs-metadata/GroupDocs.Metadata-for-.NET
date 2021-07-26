
using GroupDocs.Metadata.Common;
using GroupDocs.Metadata.Standards.Xmp;
using System.Collections.Generic;

namespace GroupDocs.Metadata.WebForms.Products.Metadata.Repositories
{
    public class XmpMetadataRepository : MetadataPackageRepository
    {
        public XmpMetadataRepository(MetadataPackage branchPackage) : base(branchPackage)
        {
        }

        protected override IEnumerable<MetadataPackage> GetPackages()
        {
            return ((XmpPacketWrapper)BranchPackage).Packages;
        }
    }
}