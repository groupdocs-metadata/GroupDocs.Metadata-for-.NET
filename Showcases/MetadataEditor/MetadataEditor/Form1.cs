using System;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using GroupDocs.Metadata.Formats;
using GroupDocs.Metadata.Tools;
using GroupDocs.Metadata.Xmp;
using MetadataEditor.UserControls;
using GroupDocs.Metadata;

namespace MetadataEditor
{
    public partial class frmMain : Form
    {
        private ucPropertiesEditor propertiesEditor;
        private string filePath;

        static frmMain()
        {
            GroupDocs.Metadata.License license = new GroupDocs.Metadata.License();
           
            //license.SetLicense(@"D:\GroupDocs.Total.lic");
            license.SetLicense(@"D:\Aspose Projects\LICENSE\GroupDocs.Total.lic");
        }

        public frmMain()
        {
            InitializeComponent();
            tabMetadataTypes.Visible = false;
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                tabMetadataTypes.TabPages.Clear();

                DataSet ds;

                using (StreamReader streamReader = new StreamReader(openFileDialog.FileName))
                {
                    try
                    {
                        ds = ExportFacade.ExportToDataSet(streamReader.BaseStream);
                    }
                    catch (GroupDocs.Metadata.Exceptions.InvalidFormatException)
                    {
                        MessageBox.Show(@"This format is not supported");
                        return;
                    }
                    catch (GroupDocs.Metadata.Exceptions.GroupDocsException ex)
                    {
                        MessageBox.Show(string.Format("Error: {0}", ex.Message));
                        return;
                    }
                }

                propertiesEditor = null;
                saveMetadata.FileName = openFileDialog.FileName;

                if (ds.Tables.Count == 0)
                {
                    MessageBox.Show(@"Metadata not found");
                }
                else
                {
                    for (int i = 0; i < ds.Tables.Count; i++)
                    {
                        DataTable table = ds.Tables[i];

                        Control child;
                        string tabName;

                        switch (table.TableName.ToLower())
                        {
                            case "xmp":
                                tabName = "XMP metadata";
                                XmpPacketWrapper xmpPacket = MetadataUtility.ExtractXmpPackage(openFileDialog.FileName);
                                ucXmpTree xmpTree = new ucXmpTree();                                
                                xmpTree.LoadControl(xmpPacket);
                                ResizeControl(xmpTree);
                                child = xmpTree;
                                break;

                            case "pdf":
                            case "doc":
                            case "xls":
                            case "ppt":
                                tabName = "Document properties";
                                MetadataPropertyCollection properties = MetadataUtility.ExtractDocumentProperties(openFileDialog.FileName);                                
                                propertiesEditor= new ucPropertiesEditor();
                                ResizeControl(propertiesEditor);
                                propertiesEditor.LoadControl(properties);
                                child = propertiesEditor;
                                break;

                            default:
                                tabName = string.Format("{0} metadata", table.TableName);
                                DataGridView gridView = new DataGridView();
                                ResizeControl(gridView);
                                gridView.DataSource = table;
                                child = gridView;
                                break;
                        }

                        tabMetadataTypes.TabPages.Add(tabName);
                        TabPage addedTab = tabMetadataTypes.TabPages[i];
                                                
                        //addedTab.Anchor = AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Right | AnchorStyles.Top;
                        addedTab.Controls.Add(child);
                    }

                    tabMetadataTypes.Visible = true;
                }
            }
        }

        private void ResizeControl(Control control)
        {
            control.Anchor = AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Right | AnchorStyles.Top;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void poweredByGroupDocsMetadataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProcessStartInfo sInfo = new ProcessStartInfo("http://www.groupdocs.com/dot-net/document-metadata-library");
            Process.Start(sInfo);
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (propertiesEditor != null)
            {                
                if (saveMetadata.ShowDialog() == DialogResult.OK)
                {
                    MetadataPropertyCollection changedProperties = propertiesEditor.GetProperties();
                    FormatBase format = GroupDocs.Metadata.Tools.FormatFactory.RecognizeFormat(openFileDialog.FileName);
                    IDocumentFormat documentFormat = format as IDocumentFormat;
                    documentFormat.SetProperties(changedProperties);
                    format.Save(saveMetadata.FileName);
                }
            }
        }
    }
}
