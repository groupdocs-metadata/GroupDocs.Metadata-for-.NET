using System.Collections.Generic;
using System.Windows.Forms;
using GroupDocs.Metadata.Tools;
using GroupDocs.Metadata.Xmp;
using GroupDocs.Metadata.Xmp.Types.Complex;

namespace MetadataEditor.UserControls
{
    public partial class ucXmpTree : UserControl
    {        
        public ucXmpTree()
        {
            InitializeComponent();
        }        

        public void LoadControl(XmpPacketWrapper xmpMetadata)
        {            
            treeView1.Nodes.Clear();

            if (xmpMetadata != null)
            {
                foreach (XmpPackage package in xmpMetadata.Packages)
                {
                    treeView1.Nodes.Add(package.NamespaceUri, package.NamespaceUri);

                    TreeNode treePackage = treeView1.Nodes[package.NamespaceUri];
                    foreach (KeyValuePair<string, XmpValueBase> pair in package)
                    {
                        XmpArray xmpArray = pair.Value as XmpArray;
                        LangAlt langAlt = pair.Value as LangAlt;
                        XmpComplexType xmpComplex = pair.Value as XmpComplexType;

                        if (xmpArray != null)
                        {
                            treePackage.Nodes.Add(pair.Key, pair.Key);
                            foreach (string arrayItem in xmpArray.Values)
                            {
                                treePackage.Nodes[pair.Key].Nodes.Add(arrayItem, arrayItem);
                            }
                        }
                        else if (langAlt != null)
                        {
                            treePackage.Nodes.Add(pair.Key, pair.Key);
                            treePackage.Nodes[pair.Key].Nodes.Add(pair.Key + langAlt.ToString(), langAlt.ToString());
                        }
                        else
                        {
                            string xmpProperty = string.Format("{0} - {1}", pair.Key, pair.Value.ToString());
                            treePackage.Nodes.Add(pair.Key, xmpProperty);
                        }
                    }
                }
            }

            treeView1.ExpandAll();
        }
    }
}
