using GroupDocs.Metadata.Common;
using GroupDocs.Metadata.MVC.Products.Metadata.Model;
using System;
using System.Collections.Generic;

namespace GroupDocs.Metadata.MVC.Products.Metadata.Repositories
{
    public abstract class MetadataPackageRepository
    {
        private readonly HashSet<MetadataPropertyType> supportedPropertyTypes = new HashSet<MetadataPropertyType>
        {
            MetadataPropertyType.String,
            MetadataPropertyType.DateTime,
            MetadataPropertyType.Integer,
            MetadataPropertyType.Long,
            MetadataPropertyType.Double,
            MetadataPropertyType.Boolean,

            MetadataPropertyType.PropertyValueArray,
            MetadataPropertyType.StringArray,
            MetadataPropertyType.ByteArray,
            MetadataPropertyType.DoubleArray,
            MetadataPropertyType.IntegerArray,
            MetadataPropertyType.LongArray
        };

        protected MetadataPackageRepository(MetadataPackage branchPackage)
        {
            BranchPackage = branchPackage;
        }

        protected MetadataPackage BranchPackage { get; private set; }

        public virtual IEnumerable<Model.PropertyDescriptor> GetDescriptors()
        {
            foreach (var package in GetPackages())
            {
                foreach (var descriptor in package.KnowPropertyDescriptors)
                {
                    if (IsPropertyTypeSupported(descriptor.Type))
                    {
                        yield return new Model.PropertyDescriptor(descriptor.Name, (PropertyType)descriptor.Type, (AccessLevels)descriptor.AccessLevel);
                    }
                }
            }
        }

        public virtual IEnumerable<Property> GetProperties()
        {
            foreach (var package in GetPackages())
            {
                foreach (var property in package)
                {
                    if (IsPropertyTypeSupported(property.Value.Type))
                    {
                        yield return new Property(property.Name, (PropertyType)property.Value.Type, property.Value.RawValue);
                    }
                }
            }
        }

        public virtual void RemoveProperty(string name)
        {
            foreach (var package in GetPackages())
            {
                package.RemoveProperties(p => string.Equals(p.Name, name, StringComparison.OrdinalIgnoreCase));
            }
        }

        public virtual void SaveProperty(string name, PropertyType type, dynamic value)
        {
            if (value != null)
            {
                var propertyValue = CreatePropertyValue((MetadataPropertyType)type, value);
                GroupDocs.Metadata.Common.Func<MetadataProperty, bool> condition = p => string.Equals(p.Name, name, StringComparison.OrdinalIgnoreCase);
                foreach (var package in GetPackages())
                {
                    package.SetProperties(condition, propertyValue);
                }
            }
        }

        protected abstract IEnumerable<MetadataPackage> GetPackages();

        protected bool IsPropertyTypeSupported(MetadataPropertyType type)
        {
            return supportedPropertyTypes.Contains(type);
        }

        protected PropertyValue CreatePropertyValue(MetadataPropertyType type, dynamic value)
        {
            if (type == MetadataPropertyType.Integer && value is long)
            {
                return new PropertyValue((int)value);
            }

            if (type == MetadataPropertyType.Double && value is long)
            {
                return new PropertyValue((double)value);
            }

            if (type == MetadataPropertyType.DateTime)
            {
                return new PropertyValue(DateTime.SpecifyKind((DateTime)value, DateTimeKind.Local));
            }

            return new PropertyValue(value);
        }
    }
}