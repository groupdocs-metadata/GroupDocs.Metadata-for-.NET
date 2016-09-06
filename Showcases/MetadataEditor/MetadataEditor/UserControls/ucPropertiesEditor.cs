using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using GroupDocs.Metadata.MetadataProperties;
using GroupDocs.Metadata.Tools;

namespace MetadataEditor.UserControls
{
    public partial class ucPropertiesEditor : UserControl
    {
        public ucPropertiesEditor()
        {
            InitializeComponent();
        }

        public void LoadControl(MetadataPropertyCollection metadataCollection)
        {
            List<PropertyItem> values = new List<PropertyItem>();
            foreach (MetadataProperty prop in metadataCollection)
            {
                if (prop.Value == null)
                {
                    continue;
                }

                if (prop.Value.Type != MetadataPropertyType.String)
                {
                    continue;
                }

                values.Add(new PropertyItem(prop.Name, prop.Value.ToString(), prop.IsBuiltInProperty));
            }
            gridDocumentProperties.DataSource = values;
        }

        public MetadataPropertyCollection GetProperties()
        {
            List<PropertyItem> list = (List<PropertyItem>)gridDocumentProperties.DataSource;

            List<MetadataProperty> result = new List<MetadataProperty>();
            foreach (var propertyItem in list)
            {
                //if (!propertyItem.IsChanged)
                //{
                //    continue;
                //}

                result.Add(new MetadataProperty()
                {
                    Name = propertyItem.Name,
                    Value = new PropertyValue(propertyItem.Value)
                });
            }

            return new MetadataPropertyCollection(result.ToArray());
        }

        public class PropertyItem
        {
            public string Name { get; set; }
            public string Value { get; set; }
            public bool IsBuiltIn { get; set; }
            //public bool IsChanged { get; set; }

            public PropertyItem(string name, string value, bool isBuiltIn)
            {
                this.Name = name;
                this.Value = value;
                this.IsBuiltIn = isBuiltIn;
            }
        }
    }
}
