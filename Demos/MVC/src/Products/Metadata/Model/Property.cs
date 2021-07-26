
namespace GroupDocs.Metadata.MVC.Products.Metadata.Model
{
    public class Property
    {
        public Property(string name, PropertyType type, object value)
        {
            Name = name;
            Type = type;
            Value = value;
        }

        public string Name { get; private set; }

        public PropertyType Type { get; private set; }

        public object Value { get; private set; }
    }
}