

using System.Collections.Generic;

namespace GroupDocs.Metadata.MVC.Products.Metadata.Model
{
    public class Package
    {
        public Package(
            string id, 
            string name, 
            int index, 
            PackageType type, 
            IEnumerable<Property> properties, 
            IEnumerable<PropertyDescriptor> descriptors)
        {
            Id = id;
            Name = name;
            Index = index;
            Type = type;
            Properties = properties;
            Descriptors = descriptors;
        }

        public string Id { get; private set; }

        public string Name { get; private set; }

        public int Index { get; private set; }

        public PackageType Type { get; private set; }

        public IEnumerable<Property> Properties { get; private set; }

        public IEnumerable<PropertyDescriptor> Descriptors { get; private set; }
    }
}