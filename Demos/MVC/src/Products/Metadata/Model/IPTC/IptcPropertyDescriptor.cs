
namespace GroupDocs.Metadata.MVC.Products.Metadata.Model.IPTC
{
    public class IptcPropertyDescriptor : PropertyDescriptor
    {
        public IptcPropertyDescriptor(string name, PropertyType type, AccessLevels accessLevel) 
            : base(IptcProperty.NameToUserFriendlyName(name), type, accessLevel)
        {
        }
    }
}