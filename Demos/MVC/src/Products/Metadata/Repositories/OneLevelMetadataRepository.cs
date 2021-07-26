
using GroupDocs.Metadata.Common;
using System.Collections.Generic;

namespace GroupDocs.Metadata.MVC.Products.Metadata.Repositories
{
    public class OneLevelMetadataRepository : MetadataPackageRepository
    {
        public OneLevelMetadataRepository(MetadataPackage branchPackage) : base(branchPackage)
        {
        }

        protected override IEnumerable<MetadataPackage> GetPackages()
        {
            yield return BranchPackage;
        }
    }
}