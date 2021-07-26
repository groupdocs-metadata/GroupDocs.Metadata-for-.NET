﻿
using GroupDocs.Metadata.Common;
using System.Collections.Generic;

namespace GroupDocs.Metadata.WebForms.Products.Metadata.Repositories
{
    public class DigitalSignatureRepository : MetadataPackageRepository
    {
        public DigitalSignatureRepository(MetadataPackage branchPackage) : base(branchPackage)
        {
        }

        protected override IEnumerable<MetadataPackage> GetPackages()
        {
            yield break;
        }
    }
}