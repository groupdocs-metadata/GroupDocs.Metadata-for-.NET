using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using Office = Microsoft.Office.Core;
using Outlook = Microsoft.Office.Interop.Outlook;
using System.Windows.Forms;
using System.Drawing;

// TODO:  Follow these steps to enable the Ribbon (XML) item:

// 1: Copy the following code block into the ThisAddin, ThisWorkbook, or ThisDocument class.

//  protected override Microsoft.Office.Core.IRibbonExtensibility CreateRibbonExtensibilityObject()
//  {
//      return new Ribbon1();
//  }

// 2. Create callback methods in the "Ribbon Callbacks" region of this class to handle user
//    actions, such as clicking a button. Note: if you have exported this Ribbon from the Ribbon designer,
//    move your code from the event handlers to the callback methods and modify the code to work with the
//    Ribbon extensibility (RibbonX) programming model.

// 3. Assign attributes to the control tags in the Ribbon XML file to identify the appropriate callback methods in your code.  

// For more information, see the Ribbon XML documentation in the Visual Studio Tools for Office Help.


namespace GroupDocs.Metadata.OutlookAddin
{
    [ComVisible(true)]
    public class Ribbon1 : Office.IRibbonExtensibility
    {
        private Office.IRibbonUI ribbon;

        public Ribbon1()
        {
        }
        public void SendMessageUsingGroupDocsMetadata(Office.IRibbonControl control)
        {
            try
            {
                //Create open file dialog...
                OpenFileDialog ofdAttachFile = new OpenFileDialog();

                //Initialize open file dialog...
                InitializeOpenFileDialog(ofdAttachFile);

                DialogResult result = ofdAttachFile.ShowDialog();

                string strFileName = string.Empty;
                string message = string.Empty;

                if (result == DialogResult.OK)
                {
                    MessageBox.Show("Cleaning of multiple files may take time. Please be patient.");
                    foreach (string fileName in ofdAttachFile.FileNames)
                    {
                        //Get file name...
                        strFileName = fileName;

                        try
                        {
                            //Clean metadata of file...
                            message = MetadataCleaner.CleanDocument(strFileName);
                        }
                        catch (Exception exp)
                        {
                            MessageBox.Show("Exception in cleaning file: " + exp.Message);
                        }
                        try
                        {
                            //Get mail item of Outlook...
                            Outlook.MailItem mail = Globals.ThisAddIn.Application.ActiveInspector().CurrentItem;
                            
                            //Attach file with mail
                            mail.Attachments.Add(strFileName, Outlook.OlAttachmentType.olByValue, 1, strFileName);
                            
                            //Display mail...
                            mail.Display();

                        }
                        catch (Exception exp)
                        {
                            MessageBox.Show("Exception in attachment: " + exp.Message);
                        }
                    }
                }

            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
        }

        protected void InitializeOpenFileDialog(OpenFileDialog ofd)
        {
            try
            {
                //Set filters...
                ofd.Filter = "Documents (*.XLS;*.XLSX;*.DOC;*.DOCX;*.PPT;*.PPTX;*.PDF)|*.XLS;*.XLSX;*.PPT;*.PPTX;*.DOC;*.DOCX;*.PDF|" + "Images (*.PNG;*.JPG;*.JPEG;*.GIF)|*.BMP;*.JPG;*.GIF|" + "All files (*.*)|*.*";

                //Allow the user to select multiple files...
                ofd.Multiselect = true;

                //Set title of dialog...
                ofd.Title = "Select file(s)";
            }
            catch
            { }
        }
        public Bitmap GetCustomImage(Office.IRibbonControl control)
        {
            //Set icon for the add-in
            return Properties.Resources.icon;
        }

        #region IRibbonExtensibility Members

        public string GetCustomUI(string ribbonID)
        {
            return GetResourceText("GroupDocs.Metadata.OutlookAddin.Ribbon1.xml");
        }

        #endregion

        #region Ribbon Callbacks
        //Create callback methods here. For more information about adding callback methods, select the Ribbon XML item in Solution Explorer and then press F1

        public void Ribbon_Load(Office.IRibbonUI ribbonUI)
        {
            this.ribbon = ribbonUI;
        }

        #endregion

        #region Helpers

        private static string GetResourceText(string resourceName)
        {
            Assembly asm = Assembly.GetExecutingAssembly();
            string[] resourceNames = asm.GetManifestResourceNames();
            for (int i = 0; i < resourceNames.Length; ++i)
            {
                if (string.Compare(resourceName, resourceNames[i], StringComparison.OrdinalIgnoreCase) == 0)
                {
                    using (StreamReader resourceReader = new StreamReader(asm.GetManifestResourceStream(resourceNames[i])))
                    {
                        if (resourceReader != null)
                        {
                            return resourceReader.ReadToEnd();
                        }
                    }
                }
            }
            return null;
        }

        #endregion
    }
}
