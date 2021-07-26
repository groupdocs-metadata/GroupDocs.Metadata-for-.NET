
using GroupDocs.Metadata.Common;
using GroupDocs.Metadata.MVC.Products.Metadata.Model;
using System;
using System.Collections.Generic;

namespace GroupDocs.Metadata.MVC.Products.Metadata.Repositories
{
    public abstract class EnumMapperRepository : MetadataPackageRepository
    {
        private readonly IDictionary<string, Type> enumMap;

        protected EnumMapperRepository(MetadataPackage branchPackage, IDictionary<string, Type> enumMap) : base(branchPackage)
        {
            this.enumMap = enumMap;
        }

        public override IEnumerable<Property> GetProperties()
        {
            foreach (var property in base.GetProperties())
            {
                if (enumMap.ContainsKey(property.Name))
                {
                    yield return new Property(property.Name, PropertyType.String, Enum.GetName(enumMap[property.Name], property.Value));
                }
                else
                {
                    yield return property;
                }
            }
        }

        protected override IEnumerable<MetadataPackage> GetPackages()
        {
            yield return BranchPackage;
        }
    }
}