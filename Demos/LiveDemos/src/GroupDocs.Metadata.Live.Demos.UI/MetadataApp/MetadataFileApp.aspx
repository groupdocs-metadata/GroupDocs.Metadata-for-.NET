<%@ Page Title="DOC, DOCX, DOT, DOTX, DOCM, XLS, XLSX, XLSM, XLTM, PPT, PPTX, POTM, POTX, PPTM, PPS, PPSX‎, PPSM, MSG, EML, ONE, VSD, VDX, VSDX, VSS, VSX, MPP, ODT, ODS, PDF, PSD, DWG, DXF, MP3, WAV, AVI, MOV, QT, FLV, EMF, WMF, VCF‎, JPG, JPEG, JPE, JP2, PNG, GIF, TIFF, WEBP, BMP, DJVU, DJV, DICOM‎, MKV, MKA, MK3D, WEBM‎, EPUB, ZIP, ZIPX, TORRENT, ASF and files online Metadata Editor - GroupDocs.App" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MetadataFileApp.aspx.cs" Inherits="GroupDocs.Metadata.Live.Demos.UI.MetadataApp.MetadataFileApp" %>

<asp:Content ID="HeadContents1" ContentPlaceHolderID="HeadContents" runat="server">

	<meta charset="UTF-8">
	<meta name="author" content="groupdocs.app" />
	<meta name="keywords" content="<%=metakeywords %>" />
	<link rel="canonical" href="https://products.groupdocs.app/metadata/total" />
	<link rel="icon" type="image/png" sizes="16x16" href="https://products.groupdocs.app/images/groupdocs1616.png">
	<meta property="og:site_name" content="Free Online <%=fileFormat  %>Metadata Editor" />
	<meta property="og:title" content="<%=metatitle %>" />
	<meta property="og:description" content="<%=metadescription %>" />
	<meta property="og:image" content="https://products.groupdocs.app/images/groupdocsapp.png" />
	<meta property="og:type" content="website" />
	<meta property="og:url" content="https://products.groupdocs.app/metadata/total" />
	<meta name="twitter:card" content="summary_large_image">
	<meta name="twitter:site" content="@groupdocsapp">
	<meta name="twitter:creator" content="@groupdocsapp">
	<meta name="twitter:title" content="<%=metatitle %>">
	<meta name="twitter:description" content="<%=metadescription %>">
	<meta name="twitter:image:src" content="https://products.groupdocs.app/images/groupdocsapp.png" />
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

	<script lang="javascript" type="text/javascript">
		function TriggerFileUpload() {
			$('#<%=btnView.ClientID %>').click();
		}

		var size = 2;

		var id = 0;

		function ProgressBar() {

			if (document.getElementById('<%=FileUpload1.ClientID %>').value != "") {

				document.getElementById("progressbar").style.display = "block";


				id = setInterval("progress()", 10);

				return true;
			}
		}

		function progress() {

			size = size + 1;

			if (size > 299) {

				clearTimeout(id);

			}

			document.getElementById("progressbar").style.width = size + "%";
		}
	</script>

	<!-- GroupDocs.Apps UI Template Starts Here -->
	<asp:Panel ID="pnlTest" runat="server">
		<div class="container-fluid GroupDocsApps pb5">
			<div class="container">
				<div class="row">

					<div class="col-md-12 pt-5 pb-5" style="padding-bottom: 0px!important;">
						<asp:HiddenField ID="hdnGroupDocsProductName" runat="server" />
						<h1 id="hheading" runat="server">Free Online Document & Image Metadata Editor & Cleaner</h1>
						<h2 style="font-size: 22px !important; color: #fff !important;" id="hdescription" runat="server">View, Edit, Remove and Export Metadata from your Word, PDF, PowerPoint, Excel and more than 50 types of documents & images, 100% free online!</h2>
						<h1 runat="server" visible="false" id="hFeatureTitle"></h1>
						<h4 runat="server" visible="false" id="hPageTitle"></h4>
						<div>
							<div class="uploadfile">

								<div class="filedropdown">
									<div class="filedrop">
										<label class="dz-message needsclick"><% = Resources["DropOrUploadFile"] %></label>
										<input type="file" class="uploadfileinput" name="FileUpload1" id="FileUpload1" onchange="TriggerFileUpload()" runat="server" />
										<br />
										<asp:RequiredFieldValidator ID="rfvFile" SetFocusOnError="true" ValidationGroup="uploadFile" runat="server"
											ErrorMessage="*" ControlToValidate="FileUpload1" Display="Dynamic"
											ForeColor="Red"></asp:RequiredFieldValidator>

										<asp:RegularExpressionValidator ValidationGroup="uploadFile" ID="ValidateFileType"
											ControlToValidate="FileUpload1" runat="server" ForeColor="Red"
											Display="Dynamic" Enabled="true" />

										<asp:HiddenField ID="hdnAllowedFileTypes" runat="server" Value="" />

										<asp:HiddenField ID="hdnDownloadFileName" runat="server" Value="" />
										<asp:HiddenField ID="hdnDownloadFileURL" runat="server" Value="" />

										<div class="fileupload">
											<div class="progress">
												<div class="progress-bar progress-bar-striped progress-bar-success progress-bar-animated" id="progressbar" role="progressbar" style="width: 0%" aria-valuenow="25" aria-valuemin="0" aria-valuemax="100"></div>
											</div>
											<span class="filename"><a onclick='removefile()'>
												<label for="uploadfileinput" class="custom-file-upload"></label>
												<i class="fa fa-times"></i></a></span>
										</div>
									</div>


									<p runat="server" id="pMessage" style="width: 65%; position: relative; color: red; margin: 50px auto 30px;">
									</p>
									<div class="convertbtn" style="display: none;">
										<asp:Button class="btn btn-success btn-lg" ID="btnView" ValidationGroup="uploadFile" runat="server" OnClientClick="return ProgressBar()" OnClick="btnView_Click" />
									</div>
								</div>
							</div>
						</div>
					</div>
				</div>
			</div>
		</div>
	</asp:Panel>

	<div class="col-md-12 pt-5 bg-gray tc" style="padding-bottom: 0px!important;" id="dvAllFormats" runat="server">
		<div class="container">
			<div class="col-md-12 pull-left">
				<h2 class="h2title">GroupDocs.Metadata App</h2>
				<p>GroupDocs.Metadata App Supported Document and Image Formats</p>
				<div class="diagram1 d2 d1-net">
					<div class="d1-row">
						<div class="d1-col d1-left">
							<header>Microsoft Office, Project &amp; Visio</header>
							<ul>
								<li><strong>Word:</strong> DOC, DOCX, DOT, DOTX, DOCM</li>
								<li><strong>Excel:</strong> XLS, XLSX, XLSM, XLT, XLTX, XLTM</li>
								<li><strong>PowerPoint:</strong> PPT, PPTX, POT, POTX</li>
								<li><strong>Outlook:</strong> MSG, EML</li>
								<li><strong>OneNote:</strong> ONE</li>
								<li><strong>Visio:</strong> VDX, VSD, VSDX, VSS, VSX</li>
								<li><strong>Project:</strong> MPP</li>
							</ul>
						</div>
						<!--/left-->
						<div class="d1-col d1-right">
							<header>Image, Audio &amp; Other Formats</header>
							<ul>
								<li><strong>Image Formats:</strong> JPEG, JPG, JPE, Jpeg2000, JP2, PNG, GIF, TIFF, WebP, BMP, DjVu, DICOM</li>
								<li><strong>Portable Document Format:</strong> PDF</li>
								<li><strong>Open Document Format:</strong> ODT, ODS</li>
								<li><strong>AutoCAD Drawings:</strong> DWG, DXF</li>
								<li><strong>Audio Formats:</strong> MP3, WAV</li>
								<li><strong>Metafiles:</strong> EMF, WMF</li>
								<li><strong>Photoshop:</strong> PSD</li>
								<li><strong>Video: </strong>AVI, MOV, QT</li>
								<li><strong>Others: </strong>EPUB, ZIP, ZIPX, TORRENT</li>
							</ul>
						</div>
						<!--/right-->
					</div>
					<!--/row-->
					<div class="d1-logo">
						<img src="https://www.groupdocs.cloud/templates/groupdocs/images/product-logos/90x90-noborder/groupdocs-metadata-net.png" alt=".NET Metadata APIs"><header>GroupDocs.Metadata</header>
						<footer><small>App</small></footer>
					</div>
					<!--/logo-->
				</div>
			</div>
		</div>
	</div>

	<div class="col-md-12 pull-left d-flex d-wrap bg-gray appfeaturesectionlist" id="dvFormatSection" runat="server" visible="false">
		<div class="col-md-6 cardbox tc col-md-offset-3 b6">
			<h3 runat="server" id="hExtension1"></h3>
			<p runat="server" id="hExtension1Description"></p>
		</div>
	</div>

	<!-- HowTo Section -->
	<div class="col-md-12 tl bg-darkgray howtolist">
		<div class="container tl dflex">

			<div class="col-md-2 howtosectiongfx">
				<img src="/img/howto.png">
			</div>
			<div class="howtosection col-md-12">
				<div>
					<h4><i class="fa fa-question-circle "></i>&nbsp;<b>How to view, edit, clean & export a <%=fileFormat  %><%=docOrImage  %> metadata using GroupDocs Metadata Editor App</b></h4>
					<ul>
						<li>Click inside the file drop area to upload a <%=fileFormat  %>file or drag & drop a <%=fileFormat  %>file.</li>
						<li>File will be automatically rendered for you to view/edit/clean metadata instantly.</li>
						<li>View & update metadata for built-in, XMP, EXIF and custom properties.</li>
						<li>Download the original <%=fileFormat  %>file with metadata.</li>
						<li>Download the <%=fileFormat  %>file with updated metadata properties.</li>
						<li>Clean metadata and download the updated <%=fileFormat  %>file.</li>
						<li>Export the metadata from <%=fileFormat  %>file to Excel and CSV format.</li>
					</ul>
				</div>
			</div>
		</div>
	</div>

	<div class="col-md-12 pt-5 app-features-section" style="padding-bottom: 0px!important;">
		<div class="container tc pt-5">
			<div class="col-md-4">
				<div class="imgcircle fasteasy">
					<img src="../../img/fast-easy.png" />
				</div>
				<h4>Fast and Easy <%=fileFormat  %>Metadata Editor</h4>
				<p>Upload your <%=fileFormat  %>document and you will be redirected to the <%=fileFormat  %>Metadata Editor with great user experience and many more features.</p>
				<p id="h4para" runat="server" visible="false">.</p>
			</div>

			<div class="col-md-4">
				<div class="imgcircle anywhere">
					<img src="../../img/anywhere.png" />
				</div>
				<h4>Edit Metadata <%=fileFormat  %>from Anywhere</h4>
				<p>It works from all platforms including Windows, Mac, Android and iOS. All <%=fileFormat  %>files are processed on our servers. No plugin or software installation required for you..</p>
			</div>

			<div class="col-md-4">
				<div class="imgcircle quality">
					<img src="../../img/quality.png" />
				</div>
				<h4>Metadata Editor Quality</h4>
				<p><%= Resources["PoweredBy"] %> <a runat="server" target="_blank" id="aPoweredBy"></a>All <%=fileFormat  %>files are processed using GroupDocs APIs.</p>
			</div>
		</div>
	</div>
	<script>   

		$('.fileupload').hide();

		$('.uploadfileinput').change(function () {
			//return;
			var file = $('.uploadfileinput')[0].files[0].name;
			var ext = file.split('.').pop();
			ext = ext.toLowerCase();
			if (document.getElementById('<%=hdnAllowedFileTypes.ClientID %>').value.includes(ext)) {

				$('.filename label').text(file);
				$('.fileupload').show();
			}

		});
		function removefile() {
			$('.fileupload').hide();
			document.getElementById('progressbar').style.width = "0%";
			$('.uploadfileinput').show();

		}
		function ConvertAnotherFile() {
			$('.fileupload').hide();
			document.getElementById('progressbar').style.width = "0%";
			$('.filedropdown').show();
			$('.fileformatsico').show();

		}

		function AssignBtnToText(obj) {
			var t = $(obj).text();
			document.getElementById('ctl00_MainContent_OptionSelector_btnTo').innerHTML = t;
			document.getElementById("ctl00_MainContent_OptionSelector_hdnToValue").value = t;

		}

	</script>
	<script>
		if (/Android|webOS|iPhone|iPad|iPod|BlackBerry|IEMobile|Opera Mini/i.test(navigator.userAgent)) {

			var swiper = new Swiper('.swiper-container', {
				slidesPerView: 5,
				spaceBetween: 20,
				// init: false,
				pagination: {
					el: '.swiper-pagination',
					clickable: true,
				},
				navigation: {
					nextEl: '.swiper-button-next',
					prevEl: '.swiper-button-prev',
				},
				breakpoints: {
					868: {
						slidesPerView: 4,
						spaceBetween: 20,
					},
					668: {
						slidesPerView: 2,
						spaceBetween: 0,
					}
				}
			});
		}
	</script>

</asp:Content>
