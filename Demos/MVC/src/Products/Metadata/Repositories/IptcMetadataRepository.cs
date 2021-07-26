using GroupDocs.Metadata.Common;
using GroupDocs.Metadata.Standards.Iptc;
using GroupDocs.Metadata.MVC.Products.Metadata.Model;
using GroupDocs.Metadata.MVC.Products.Metadata.Model.IPTC;
using System.Collections.Generic;

namespace GroupDocs.Metadata.MVC.Products.Metadata.Repositories
{
    public class IptcMetadataRepository : MetadataPackageRepository
    {
        private readonly HashSet<MetadataPropertyType> supportedPropertyTypes = new HashSet<MetadataPropertyType>
        {
            MetadataPropertyType.String,
            MetadataPropertyType.DateTime,
            MetadataPropertyType.Integer,
            MetadataPropertyType.ByteArray,
        };

        public IptcMetadataRepository(MetadataPackage branchPackage) : base(branchPackage)
        {
        }

        public override IEnumerable<Property> GetProperties()
        {
            foreach (var package in GetPackages())
            {
                foreach (var property in package)
                {
                    var dataSet = (IptcDataSet)property;
                    if (IsDataSetSupported(dataSet))
                    {
                        yield return new IptcProperty(dataSet.RecordNumber, dataSet.DataSetNumber, (PropertyType)property.Value.Type, property.Value.RawValue);
                    }
                }
            }
        }

        public override IEnumerable<Model.PropertyDescriptor> GetDescriptors()
        {
            foreach (var package in GetPackages())
            {
                foreach (var descriptor in package.KnowPropertyDescriptors)
                {
                    if (supportedPropertyTypes.Contains(descriptor.Type))
                    {
                        yield return new IptcPropertyDescriptor(descriptor.Name, (PropertyType)descriptor.Type, (AccessLevels)descriptor.AccessLevel);
                    }
                }
            }
        }

        public override void RemoveProperty(string name)
        {
            base.RemoveProperty(IptcProperty.UserFriendlyNameToName(name));
        }

        public override void SaveProperty(string name, PropertyType type, dynamic value)
        {
            if (value != null)
            {
                string searchName = IptcProperty.UserFriendlyNameToName(name);
                var propertyValue = CreatePropertyValue((MetadataPropertyType)type, value);
                Func<MetadataProperty, bool> condition = p => p.Name == searchName;
                BranchPackage.SetProperties(condition, propertyValue);
            }
        }

        protected override IEnumerable<MetadataPackage> GetPackages()
        {
            foreach (var recordProperty in BranchPackage)
            {
                yield return recordProperty.Value.ToClass<IptcRecord>();
            }
        }

        protected bool IsDataSetSupported(IptcDataSet dataSet)
        {
            if (supportedPropertyTypes.Contains(dataSet.Value.Type))
            {
                return true;
            }

            if (dataSet.Value.Type == MetadataPropertyType.PropertyValueArray)
            {
                var values = dataSet.Value.ToArray<PropertyValue>();
                if (values != null && values.Length > 0 && values[0].Type != MetadataPropertyType.ByteArray)
                {
                    return true;
                }
            }

            return false;
        }
    }
}