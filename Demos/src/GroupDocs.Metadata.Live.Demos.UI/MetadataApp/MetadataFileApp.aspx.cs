using System;
using System.Web;
using System.Web.UI;
using GroupDocs.Metadata.Live.Demos.UI.Models;
using GroupDocs.Metadata.Live.Demos.UI.Config;
using GroupDocs.Metadata.Live.Demos.UI.Helpers;
using System.Globalization;
using System.Text.RegularExpressions;
using GroupDocs.Metadata.Common;

namespace GroupDocs.Metadata.Live.Demos.UI.MetadataApp
{
	public partial class MetadataFileApp : BasePage
	{
		public string fileFormat = "";
		public string metatitle = "";
		public string metadescription = "";
		public string metakeywords = "";
		public string docOrImage = "";
		public string docOrImageTitled = "";

		protected void Page_Load(object sender, EventArgs e)
		{
			metatitle = "Free Online Document Metadata Editor & Cleaner - GroupDocs.App";
			metadescription = "View, edit, remove and export metadata from your files/documents in seconds. 100% free online document and image metadata editor, secure and easy to use! GroupDocs.App — advanced online tool that solving any problems with any files.";
			metakeywords = "View metadata, edit metadata, clean metadata, export metadata, compare document, edit document, view edit clean document metadata, search in documents, document watermark, view document, merge document, split document, combine document, extract document, view/edit/clean & export metadata from documents like Word, Excel, Powerpoint, PDF, JPG, EPUB & images, free online document metadata editor, ilove documents";
			docOrImage = "document";
			docOrImageTitled = "Document";

			if (!IsPostBack)
			{
				aPoweredBy.InnerText = "GroupDocs.Metadata";
				aPoweredBy.HRef = "https://products.GroupDocs.com/metadata";

				BuildValidator();

				hFeatureTitle.InnerText = "GroupDocs Metadata App";
				hPageTitle.InnerHtml = "View your file metadata online from anywhere";

				btnView.Text = Resources["btnViewNow"];
				rfvFile.ErrorMessage = Resources["SelectorDropFileMessage"];
				h4para.InnerText = string.Format(Resources["MetadataFeature1Description"], "");
				hdescription.InnerHtml = "View, Edit, Remove and Export Metadata online, from any device with a modern browser like Chrome, Opera and Firefox.";

				if (Page.RouteData.Values["fileformat"] != null)
				{
					if (!Page.RouteData.Values["fileformat"].ToString().ToLower().Equals("total"))
					{
						hheading.InnerHtml = "Free Online  " + Page.RouteData.Values["fileformat"].ToString().ToUpper() + " " + docOrImageTitled + " Metadata Editor & Cleaner";
						hdescription.InnerHtml = "View, Edit, Remove and Export " + Page.RouteData.Values["fileformat"].ToString().ToUpper() + " Metadata" + " online, from any device, with a modern browser like Chrome, Firefox.";

						metatitle = "Free Online " + Page.RouteData.Values["fileformat"].ToString().ToUpper() + " " + docOrImageTitled + " Metadata Editor & Cleaner - GroupDocs.App";
						metadescription = "View, edit, clean and export metadata from your " + Page.RouteData.Values["fileformat"].ToString().ToUpper() + " files/documents in seconds. 100% free online " + Page.RouteData.Values["fileformat"].ToString().ToUpper() + " document metadata editor, secure and easy to use! GroupDocs.App — advanced online tool that solving any problems with any files.";
						metakeywords = "View " + Page.RouteData.Values["fileformat"].ToString().ToUpper() + " metadata, edit " + Page.RouteData.Values["fileformat"].ToString().ToUpper() + " metadata, clean " + Page.RouteData.Values["fileformat"].ToString().ToUpper() + " metadata, export " + Page.RouteData.Values["fileformat"].ToString().ToUpper() + " metadata, compare " + Page.RouteData.Values["fileformat"].ToString().ToUpper() + " document, edit " + Page.RouteData.Values["fileformat"].ToString().ToUpper() + " document, view edit clean " + Page.RouteData.Values["fileformat"].ToString().ToUpper() + " document metadata, search in " + Page.RouteData.Values["fileformat"].ToString().ToUpper() + " documents, " + Page.RouteData.Values["fileformat"].ToString().ToUpper() + " document watermark, view " + Page.RouteData.Values["fileformat"].ToString().ToUpper() + " document, merge " + Page.RouteData.Values["fileformat"].ToString().ToUpper() + " document, split " + Page.RouteData.Values["fileformat"].ToString().ToUpper() + " document, combine " + Page.RouteData.Values["fileformat"].ToString().ToUpper() + " document, extract " + Page.RouteData.Values["fileformat"].ToString().ToUpper() + " document, view/edit/clean & export metadata from documents like Word, Excel, Powerpoint, PDF, JPG, EPUB, " + Page.RouteData.Values["fileformat"].ToString().ToUpper() + " & images, free online " + Page.RouteData.Values["fileformat"].ToString().ToUpper() + " document metadata editor, ilove " + Page.RouteData.Values["fileformat"].ToString().ToUpper() + " documents";
						hdescription.InnerHtml = "View, Edit, Remove and Export " + Page.RouteData.Values["fileformat"].ToString().ToUpper() + " Metadata online from any device, with a modern browser like Chrome, Opera and Firefox.";

						fileFormat = Page.RouteData.Values["fileformat"].ToString().ToUpper() + " ";

					}
				}
			}

			Page.Title = metatitle;
			Page.MetaDescription = metadescription;
		}
        
		private void BuildValidator()
		{
			string validationExpression = "";
			string validFileExtensions = GetValidFileExtensions(validationExpression);
			string supportedFileExtensions = "";

			if (Page.RouteData.Values["fileformat"] != null)
			{
				if (!Page.RouteData.Values["fileformat"].ToString().ToLower().Equals("total"))
				{
					fileFormat = Page.RouteData.Values["fileformat"].ToString();
					validationExpression = "." + fileFormat.ToLower();
					validFileExtensions = fileFormat;
					supportedFileExtensions = fileFormat;
				}
			}
			else
			{
                Configuration.GroupDocsAppsAPIBasePath = Request.Url.Scheme + "://" + Request.Url.Authority + Request.ApplicationPath.TrimEnd('/') + "/";
                Configuration.FileDownloadLink = Configuration.GroupDocsAppsAPIBasePath + "DownloadFile.aspx";
                Response response = GroupDocsMetadataApiHelper.GetAllMetadataSupportedFormats();
				if (response == null)
				{
					throw new Exception(Resources["APIResponseTime"]);
				}
				else if (response.StatusCode == 200)
				{
					if (response.OutputType.Length > 0)
					{
						validationExpression = "." + response.OutputType.Replace(", ", "|.").ToLower();
						validFileExtensions = response.OutputType;
						supportedFileExtensions = response.OutputType;
					}
				}
			}

			ValidateFileType.ValidationExpression = @"(.*?)(" + validationExpression.ToLower() + "|" + validationExpression.ToUpper() + ")$";

			int index = supportedFileExtensions.LastIndexOf(",");
			if (index != -1)
			{
				string substr = supportedFileExtensions.Substring(index);
				string str = substr.Replace(",", " or");
				supportedFileExtensions = supportedFileExtensions.Replace(substr, str);
			}

			ValidateFileType.ErrorMessage = Resources["InvalidFileExtension"] + " " + supportedFileExtensions;
			hdnAllowedFileTypes.Value = validFileExtensions.ToLower();
		}


		private string GetValidFileExtensions(string validationExpression)
		{
			string validFileExtensions = validationExpression.Replace(".", "").Replace("|", ", ").ToUpper();

			int index = validFileExtensions.LastIndexOf(",");
			if (index != -1)
			{
				string substr = validFileExtensions.Substring(index);
				string str = substr.Replace(",", " or");
				validFileExtensions = validFileExtensions.Replace(substr, str);
			}

			return validFileExtensions;
		}

		private string TitleCase(string value)
		{
			return new CultureInfo("en-US", false).TextInfo.ToTitleCase(value);
		}

		protected void btnView_Click(object sender, EventArgs e)
		{
			if (IsValid)
			{
                Configuration.GroupDocsAppsAPIBasePath = Request.Url.Scheme + "://" + Request.Url.Authority + Request.ApplicationPath.TrimEnd('/') + "/";
                Configuration.FileDownloadLink = Configuration.GroupDocsAppsAPIBasePath + "DownloadFile.aspx";
                // Access the File using the Name of HTML INPUT File.
                HttpPostedFile postedFile = Request.Files["ctl00$MainContent$FileUpload1"];

				pMessage.Attributes.Remove("class");
				pMessage.InnerHtml = "";

				// Check if File is available.                

				if (postedFile != null && postedFile.ContentLength > 0)
				{
					// remove any invalid character from the filename.
					string fn = Regex.Replace(System.IO.Path.GetFileName(postedFile.FileName).Trim(), @"\A(?!(?:COM[0-9]|CON|LPT[0-9]|NUL|PRN|AUX|com[0-9]|con|lpt[0-9]|nul|prn|aux)|[\s\.])[^\\\/:*"" ?<>|]{ 1,254}\z", "");
					fn = fn.Replace(" ", String.Empty);

					string SaveLocation = Configuration.AssetPath + fn;
					SaveLocation = SaveLocation.Replace("'", "");

					try
					{
						postedFile.SaveAs(SaveLocation);
						var isFileUploaded = FileManager.UploadFile(SaveLocation, "emailTo.Value");

						if ((isFileUploaded != null) && (isFileUploaded.FileName.Trim() != ""))
						{
							Response.Redirect("/metadata/" + isFileUploaded.FolderId + "/" + HttpUtility.UrlEncode(isFileUploaded.FileName.Trim()) + "/");
						}
					}
					catch (Exception ex)
					{
						pMessage.InnerHtml = "Error: " + ex.Message;
						pMessage.Attributes.Add("class", "alert alert-danger");
					}
				}
			}
		}
	}
}