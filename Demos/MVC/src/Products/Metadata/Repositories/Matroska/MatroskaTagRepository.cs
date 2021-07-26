

using GroupDocs.Metadata.Common;
using GroupDocs.Metadata.Formats.Video;
using GroupDocs.Metadata.MVC.Products.Metadata.Model;
using System.Collections.Generic;

namespace GroupDocs.Metadata.MVC.Products.Metadata.Repositories.Matroska
{
    public class MatroskaTagRepository : MetadataPackageRepository
    {
        private const string TargetTypeValue = "TargetTypeValue";

        public MatroskaTagRepository(MetadataPackage branchPackage) : base(branchPackage)
        {
        }

        public override IEnumerable<Property> GetProperties()
        {
            foreach (var property in base.GetProperties())
            {
                if (property.Name == TargetTypeValue)
                {
                    yield return new Property(property.Name, PropertyType.String, ((MatroskaTargetTypeValue)property.Value).ToString());
                }
                else
                {
                    yield return property;
                }
            }

            foreach (var simpleTag in ((MatroskaTag)BranchPackage).SimpleTags)
            {
                if (simpleTag.Value.Type == MetadataPropertyType.String)
                {
                    yield return new Property(simpleTag.Name, PropertyType.String, simpleTag.Value.RawValue);
                }
            }
        }

        protected override IEnumerable<MetadataPackage> GetPackages()
        {
            yield return BranchPackage;
        }
    }
}