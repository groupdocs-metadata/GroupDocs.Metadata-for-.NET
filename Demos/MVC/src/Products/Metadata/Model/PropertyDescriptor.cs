
namespace GroupDocs.Metadata.MVC.Products.Metadata.Model
{
    public class PropertyDescriptor
    {
        public PropertyDescriptor(string name, PropertyType type, AccessLevels accessLevel)
        {
            Name = name;
            Type = type;
            AccessLevel = accessLevel;
        }

        public string Name { get; private set; }

        public PropertyType Type { get; private set; }

        public AccessLevels AccessLevel { get; private set; }
    }
}