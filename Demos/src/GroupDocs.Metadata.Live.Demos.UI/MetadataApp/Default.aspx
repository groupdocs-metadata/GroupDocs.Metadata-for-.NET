<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="GroupDocs.Metadata.Live.Demos.UI.MetadataApp.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" data-ng-app="myApp" style="height: 100%; overflow-y: hidden;">
<head runat="server">
	<meta charset="UTF-8">
	<meta http-equiv="X-UA-Compatible" content="IE=edge">
	<meta name="viewport" content="width=device-width" />

	<title>GroupDocs Metadata Editor App</title>
	<link href="/favicon.ico" rel="shortcut icon" type="image/vnd.microsoft.icon" />

	<script src="/MetadataApp/qi/doc/js/custom.js?v1.3"></script>
	<script>
		fileName = '<%= fileName%>';
		folderName = '<%= folderName%>';
	</script>

	<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.2/css/bootstrap.min.css">

	<link href="/qi/css/addon/effect-light.min.css" rel="stylesheet" />
	<link href="/qi/css/quantumui.min.css?v1.6" rel="stylesheet" />
	<link href="/qi/css/docstyle.css?v1.6" rel="stylesheet" />
	<script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/moment.js/2.10.6/moment.min.js"></script>
	<script src="https://code.angularjs.org/1.7.2/angular.min.js"></script>
	<script src="https://code.angularjs.org/1.7.2/angular-sanitize.min.js"></script>
	<script src="https://code.angularjs.org/1.7.2/angular-animate.min.js"></script>
	<script src="https://code.angularjs.org/1.7.2/angular-resource.min.js"></script>
	<script src="/qi/js/quantumui-all.min.js?v1.6"></script>
	<script src="/qi/config/icons.js"></script>
	<script src="/MetadataApp/qi/doc/js/app.js?v1.9"></script>
	<% if (Request.Url.AbsoluteUri.Contains("://products.groupdocs.app"))
		{ %>
	<!-- Only track live pages in Google Analytics -->
	<!-- Global site tag (gtag.js) - Google Analytics -->
	<script async src="https://www.googletagmanager.com/gtag/js?id=UA-27946748-4"></script>
	<script>
		window.dataLayer = window.dataLayer || [];
		function gtag() { dataLayer.push(arguments); }
		gtag('js', new Date());

		gtag('config', 'UA-27946748-4');
	</script>
	<% } %>
</head>
<body oncontextmenu="return true" data-ng-controller="MetadataAPIController" style="height: 100%; padding-top: 49px;">
	<header>
		<div class="navbar navbar-inverse navbar-fixed-top" style="margin: 0;">
			<div class="container-fluid ng-scope" style="padding-left: 3px!important;">
				<div class="pull-left" style="height: 50px; width: 35px;">
					<button type="button" class="navbar-toggle titip-right" data-title="Show Thumbnails" data-aside-toggle="#leftMenuAside" style="border: none!important;">
						<i class="glyphicon glyphicon-th-list"></i>
					</button>
				</div>
				<div class="navbar-header-right">
					<button type="button" class="navbar-toggle" data-nq-collapse="" data-target-id=".navbar-collapse" style="border: none!important;">
						<i class="glyphicon glyphicon-option-horizontal"></i>
					</button>
				</div>
				<div class="navbar-header">
					<a class="navbar-brand with-logo" href="#" style="position: relative;">
						<img src="/images/GroupDocs-logo.png" alt="GroupDocs Metadata App" />
					</a>
				</div>
				<div class="navbar-collapse collapse">
					<div class="nav navbar-nav navbar-right" style="height: 45px;">
						<button type="button" data-nq-modal-box="" data-box-type="confirm" class="navbar-toggle titip-left" data-after-confirm="existApp(true)" data-qs-content="<p><b>Are you sure, you want to close and exit the <i>GroupDocs Metadata Application</i>?</b><br /><br /><br /><b>Note:</b><i> All changes will be discarted.</i></p>" data-title="Close" style="border: none!important;">
							<i class="glyphicon glyphicon-remove"></i>
						</button>
					</div>
					<ul class="nav navbar-nav navbar-right" style="display: none;">
						<li>
							<button type="button" data-title="Downloads" role="button" data-nq-dropdown="" class="navbar-toggle titip-left" style="border: none!important;" data-qo-placement="bottom-right">
								<i class="glyphicon glyphicon-download-alt"></i><span class="caret"></span>
							</button>
							<ul class="dropdown-menu" tabindex="-1" role="menu">
								<li role="presentation"><a role="menuitem" tabindex="-1" target="_blank" ng-href="/GroupDocsapi/api/GroupDocsMetadata/downloaddocument?file=<%= fileName%>&folderName=<%= folderName%>&isImage=false"><i class="glyphicon glyphicon-download-alt"></i>&nbsp;Download Original</a></li>
								<li role="presentation"><a role="menuitem" tabindex="-1" target="_blank" ng-href="/GroupDocsapi/api/GroupDocsMetadata/downloaddocument?file=<%= fileName%>&folderName=<%= folderName%>&isImage=true"><i class="glyphicon glyphicon-compressed"></i>&nbsp;Download Clean</a></li>
							</ul>
						</li>
					</ul>

					<div class="nav navbar-nav navbar-right" style="color: #fff; padding-right: 5px;">
						<ul class="nav navbar-nav navbar-left">
							<li>
								<div style="margin-top: 15px;"><b>File:</b> <%= fileName%></div>
							</li>
						</ul>
					</div>
					<div class="nav navbar-nav navbar-left" style="height: 45px; padding-left: 1%;">
						<button type="button" data-nq-modal-box="" data-box-type="confirm" class="navbar-toggle titip-left" data-after-confirm="editMetadata(true)" data-qs-content="<p><b>Are you sure, you want to enable edit metadata information?</b></p>" data-title="Update Metadata" style="border: none!important;">
							<i class="glyphicon glyphicon-edit"></i>&nbsp;Update & Download
						</button>
					</div>
				</div>
			</div>
		</div>
	</header>
	<div style="width: 100%; background-color: #333333db; margin-top: -4px; background-image: none!important;" ng-init="asideSettings={enlargeHover:true, offCanvas:'mobile'}">
		<div id="leftMenuAside" data-nq-aside="myLeftAside" class="aside aside-with-menu"
			data-collapsible="true"
			data-top-offset="50px"
			data-off-canvas="{{asideSettings.offCanvas}}"
			data-pinnable="true"
			data-opened="true"
			data-collapsed="true"
			data-enlarge-hover="{{asideSettings.enlargeHover}}"
			data-ng-swipe-left="$aside.toggleCollapse(true);"
			data-ng-swipe-right="$aside.toggleCollapse(false);">
			<div class="aside-header">
				<div class="aside-buttons">
					<span ng-show="myLeftAside.$collapsed" ng-click="$aside.toggleCollapse()" class="titip-right" data-title="Collapse"><i class="glyphicon glyphicon-arrow-right"></i></span>
					<span ng-hide="myLeftAside.$collapsed" ng-click="$aside.toggleCollapse()" class="titip-right" data-title="Collapse"><i class="glyphicon glyphicon-arrow-left"></i></span>
					<span ng-hide="myLeftAside.$collapsed" ng-click="asideSettings.enlargeHover = !$aside.$pinned; $aside.togglePin();" class="titip-right" data-title="Toggle Pin"><i class="glyphicon glyphicon-pushpin"></i></span>
					<span ng-hide="myLeftAside.$collapsed" ng-click="$aside.close()" class="titip-right" data-title="Close"><i class="glyphicon glyphicon-remove"></i></span>
				</div>
				<span ng-hide="$aside.$collapsed" class="aside-title">Action Menu</span>
			</div>
			<div class="aside-body" style="overflow-y: auto;">
				<p style="padding: 10px 20px; margin: 0; white-space: nowrap; font-weight: bold; color: #fff; cursor: pointer;">
					<span ng-click="asideSettings.offCanvas = asideSettings.offCanvas == 'mobile' ? 'all': 'mobile'">
						<i class="glyphicon glyphicon-resize-horizontal"></i>
						<span ng-hide="$aside.$collapsed" class="menu-text"></span>
					</span>
				</p>
				<ul class="nav nav-stacked">
					<li>
						<a href="#" data-nq-modal-box="" data-box-type="confirm" data-after-confirm="existApp(false)" data-qs-content="<p><b>Are you sure, you want to refresh the <i>GroupDocs Metadata Application</i> data?</b><br /><br /><br /><b>Note:</b><i> All changes will be discarted.</i></p>">
							<i class="glyphicon glyphicon-home"></i>
							<span ng-hide="$aside.$collapsed" class="menu-text">Metadata Home</span>
						</a>
					</li>
					<li>
						<a href="#" data-nq-modal-box="" data-box-type="confirm" data-after-confirm="cleanMetadata(true)" data-qs-content="<p><b>Are you sure, you want to clean metadata information?</b><br /><br /><br /><b>Note:</b><i>Metadata cleaned file will be downloaded automatically.</i></p>">
							<i class="glyphicon glyphicon-trash"></i>
							<span ng-hide="$aside.$collapsed" class="menu-text">Clean Metadata</span>
						</a>
					</li>
					<li style="display: none;">
						<a href="#" data-nq-modal-box="" data-box-type="confirm" data-after-confirm="editMetadata(true)" data-qs-content="<p><b>Are you sure, you want to enable edit metadata information?</b></p>">
							<i class="glyphicon glyphicon-edit"></i>
							<span ng-hide="$aside.$collapsed" class="menu-text">Edit Metadata</span>
						</a>
					</li>
					<li>
						<a href="#" data-nq-collapse="" data-target-id="#collapseExample2">
							<i class="glyphicon glyphicon-export"></i>
							<span ng-hide="$aside.$collapsed" class="menu-text">Export Metadata</span>
						</a>
						<ul id="collapseExample2" class="nav nav-stacked" ng-hide="$aside.$collapsed" style="padding-left: 15px;">
							<li>
								<a href="#" data-nq-modal-box="" data-box-type="confirm" data-after-confirm="exportMetadata(true)" data-qs-content="<p><b>Are you sure, you want to export metadata information to <b>Excel</b> file?</b><br /><br /><br /><b>Note:</b><i>Metadata exported file will be downloaded automatically.</i></p>">
									<i class="glyphicon glyphicon-export"></i>
									<span class="menu-text">Export to Excel</span>
								</a>
							</li>
							<li>
								<a href="#" data-nq-modal-box="" data-box-type="confirm" data-after-confirm="exportMetadata(false)" data-qs-content="<p><b>Are you sure, you want to export metadata information to <b>CSV</b> file?</b><br /><br /><br /><b>Note:</b><i>Metadata exported file will be downloaded automatically.</i></p>">
									<i class="glyphicon glyphicon-export"></i>
									<span class="menu-text">Export to CSV</span>
								</a>
							</li>
						</ul>
					</li>
					<li>
						<a href="#" data-nq-collapse="" data-target-id="#collapseExample3">
							<i class="glyphicon glyphicon-download"></i>
							<span ng-hide="$aside.$collapsed" class="menu-text">Download File</span>
						</a>
						<ul id="collapseExample3" class="nav nav-stacked" ng-hide="$aside.$collapsed" style="padding-left: 15px;">
							<li>
								<a target="_blank" ng-href="/GroupDocsapi/api/GroupDocsMetadata/downloaddocument?file=<%= fileName%>&folderName=<%= folderName%>&isUpdated=false">
									<i class="glyphicon glyphicon-save-file"></i>
									<span class="menu-text">Download Original File</span>
								</a>
							</li>
							<li>
								<a target="_blank" ng-href="/GroupDocsapi/api/GroupDocsMetadata/downloaddocument?file=<%= fileName%>&folderName=<%= folderName%>&isUpdated=true">
									<i class="glyphicon glyphicon-save-file"></i>
									<span class="menu-text">Download Updated File</span>
								</a>
							</li>
							<li>
								<a target="_blank" id="cleanMetadata" ng-href="/GroupDocsapi/api/GroupDocsMetadata/CleanMetadata?file=<%= fileName%>&folderName=<%= folderName%>">
									<i class="glyphicon glyphicon-saved"></i>
									<span class="menu-text">Download Cleaned File</span>
								</a>
							</li>
						</ul>
					</li>
					<li style="display: none;">
						<a href="#" data-nq-collapse="" data-target-id="#collapseExample4">
							<i class="glyphicon glyphicon-envelope"></i>
							<span ng-hide="$aside.$collapsed" class="menu-text">Email Metadata</span>
						</a>
						<ul id="collapseExample4" class="nav nav-stacked" ng-hide="$aside.$collapsed" style="padding-left: 15px;">
							<li>
								<input id="emailbox" placeholder="enter email address" type="email" class="form-control" style="color: #000000;" /></li>
							<li>
								<a href="#">
									<i class="glyphicon glyphicon-send"></i>
									<span class="menu-text">Excel File</span>
								</a>
							</li>
							<li>
								<a href="#">
									<i class="glyphicon glyphicon-send"></i>
									<span class="menu-text">CSV File</span>
								</a>
							</li>
						</ul>
					</li>
				</ul>
			</div>
			<div class="aside-footer" style="padding-left: 20px; line-height: 35px;">
				<strong class="text-muted" ng-hide="$aside.$collapsed">GroupDocs Metadata App</strong>
			</div>
		</div>
		<div name="dvPages" class="content-wrapper container-fluid" style="height: 100vh; width: auto!important; background: #fff; background-image: url('/images/loader.gif'); background-repeat: no-repeat; background-position: center;">
			<div class="container-fluid view-container content-view">
				<div class="ui-view fastest slide-right-left ng-scope">
					<div class="container-fluid ng-scope">
						<div class="panel row panel-default no-bg panel-transparent">
							<h1>Metadata Details: <%= fileName%></h1>
							<div data-nq-tabset="" data-effect="from-top">
								<div data-nq-tab="">
									<span data-tab-heading=""><i class="glyphicon glyphicon-baby-formula"></i>&nbsp; Built-In Properties <font color="red">({{BuiltInProperties.length}})</font></span>
									<h4>Built-In Properties</h4>
									<div class="cover-panel">
										<table class="table">
											<thead>
												<tr class="bg-100">
													<th class="col-lg-1">#</th>
													<th>Property</th>
													<th>Value</th>
													<th>Built In</th>
													<th>Action</th>
												</tr>
											</thead>
											<tbody>
												<tr ng-repeat="item in MetadataProperties | filter:{ValueType:'BIP',IsBuiltIn:'true'} | orderBy:'Name' as BuiltInProperties" ng-value="item">
													<td>{{$index + 1}}</td>
													<td>{{ item.Name | uppercase}}</td>
													<td>
														<span data-ng-show="!editMode">{{ item.Value }}</span>
														<input type="text" name="{{$index}}-BIPT" data-ng-show="editMode" data-ng-model="item.Value" data-ng-required class="input-group" /></td>
													<td>{{ item.IsBuiltIn }}</td>
													<td>
														<button type="submit" data-ng-hide="editMode" data-ng-click="editMode = true; editAppKey(item)" class="btn btn-default">Edit</button>
														<button type="submit" data-ng-show="editMode" data-ng-click="editMode = false; saveField($index+'-BIPT')" class="btn btn-default">Save</button>
														<button type="submit" data-ng-show="editMode" data-ng-click="editMode = false; cancel()" class="btn btn-default">Cancel</button>
													</td>
												</tr>
											</tbody>
										</table>
									</div>
								</div>
								<div data-nq-tab="">
									<span data-tab-heading=""><i class="glyphicon glyphicon-duplicate"></i>&nbsp; Default Properties  <font color="red">({{DefaultProperties.length}})</font></span>
									<h4>Default Properties</h4>
									<div class="cover-panel">
										<table class="table">
											<thead>
												<tr class="bg-100">
													<th class="col-lg-1">#</th>
													<th>Property</th>
													<th>Value</th>
													<th>Built In</th>
													<th>Action</th>
												</tr>
											</thead>
											<tbody>
												<tr ng-repeat="item in MetadataProperties | filter:{ValueType:'BIP',IsBuiltIn:'false'} | orderBy:'Name' as DefaultProperties" ng-value="item">
													<td>{{$index + 1}}</td>
													<td>{{ item.Name | uppercase}}</td>
													<td>
														<span data-ng-show="!editMode">{{ item.Value }}</span>
														<input type="text" name="{{$index}}-BIPF" data-ng-show="editMode" data-ng-model="item.Value" data-ng-required class="input-group" /></td>
													<td>{{ item.IsBuiltIn }}</td>
													<td>
														<button type="submit" data-ng-hide="editMode" data-ng-click="editMode = true; editAppKey(item)" class="btn btn-default">Edit</button>
														<button type="submit" data-ng-show="editMode" data-ng-click="editMode = false; saveField($index+'-BIPF')" class="btn btn-default">Save</button>
														<button type="submit" data-ng-show="editMode" data-ng-click="editMode = false; cancel()" class="btn btn-default">Cancel</button>
													</td>
												</tr>
											</tbody>
										</table>
									</div>
								</div>
								<div data-nq-tab="">
									<span data-tab-heading=""><i class="glyphicon glyphicon-camera"></i>&nbsp; XMP Properties  <font color="red">({{XMPProperties.length}})</font></span>
									<h4>XMP Properties</h4>
									<div class="cover-panel">
										<table class="table">
											<thead>
												<tr class="bg-100">
													<th class="col-lg-1">#</th>
													<th>Property</th>
													<th>Value</th>
													<th>Action</th>
												</tr>
											</thead>
											<tbody>
												<tr ng-repeat="item in MetadataProperties | filter:{ValueType:'XMP'} | orderBy:'Name' as XMPProperties" ng-value="item">
													<td>{{$index + 1}}</td>
													<td>{{ item.Name | uppercase}}</td>
													<td>
														<span data-ng-show="!editMode">{{ item.Value }}</span>
														<input type="text" name="{{$index}}-XMPT" data-ng-show="editMode" data-ng-model="item.Value" data-ng-required class="input-group" /></td>
													<td>
														<button type="submit" data-ng-hide="editMode" data-ng-click="editMode = true; editAppKey(item)" class="btn btn-default">Edit</button>
														<button type="submit" data-ng-show="editMode" data-ng-click="editMode = false; saveField($index+'-XMPT')" class="btn btn-default">Save</button>
														<button type="submit" data-ng-show="editMode" data-ng-click="editMode = false; cancel()" class="btn btn-default">Cancel</button>
													</td>
												</tr>
											</tbody>
										</table>
									</div>
								</div>
								<div data-nq-tab="">
									<span data-tab-heading=""><i class="glyphicon glyphicon-edit"></i>&nbsp; Exif Information  <font color="red">({{ExifInformation.length}})</font></span>
									<h4>Exif Information</h4>
									<div class="cover-panel">
										<table class="table">
											<thead>
												<tr class="bg-100">
													<th class="col-lg-1">#</th>
													<th>Property</th>
													<th>Value</th>
													<th>Action</th>
												</tr>
											</thead>
											<tbody>
												<tr ng-repeat="item in MetadataProperties | filter:{ValueType:'EXI'} | orderBy:'Name' as ExifInformation" ng-value="item">
													<td>{{$index + 1}}</td>
													<td>{{ item.Name | uppercase}}</td>
													<td>
														<span data-ng-show="!editMode">{{ item.Value }}</span>
														<input type="text" name="{{$index}}-EXIT" data-ng-show="editMode" data-ng-model="item.Value" data-ng-required class="input-group" /></td>
													<td>{{ item.IsBuiltIn }}</td>
													<td>
														<button type="submit" data-ng-hide="editMode" data-ng-click="editMode = true; editAppKey(item)" class="btn btn-default">Edit</button>
														<button type="submit" data-ng-show="editMode" data-ng-click="editMode = false; saveField($index+'-EXIT')" class="btn btn-default">Save</button>
														<button type="submit" data-ng-show="editMode" data-ng-click="editMode = false; cancel()" class="btn btn-default">Cancel</button>
													</td>
												</tr>
											</tbody>
										</table>
									</div>
								</div>
								<div data-nq-tab="">
									<span data-tab-heading=""><i class="glyphicon glyphicon-edit"></i>&nbsp; Custom Properties  <font color="red">({{CustomProperties.length}})</font></span>
									<h4>Custom Properties</h4>
									<div class="cover-panel">
										<table class="table">
											<thead>
												<tr class="bg-100">
													<th class="col-lg-1">#</th>
													<th>Property</th>
													<th>Value</th>
													<th>Action</th>
												</tr>
											</thead>
											<tbody>
												<tr ng-repeat="item in MetadataProperties | filter:{ValueType:'CUP'} | orderBy:'Name' as CustomProperties" ng-value="item">
													<td>{{$index + 1}}</td>
													<td>{{ item.Name | uppercase}}</td>
													<td>
														<span data-ng-show="!editMode">{{ item.Value }}</span>
														<input type="text" name="{{$index}}-CUPT" data-ng-show="editMode" data-ng-model="item.Value" data-ng-required class="input-group" /></td>
													<td>{{ item.IsBuiltIn }}</td>
													<td>
														<button type="submit" data-ng-hide="editMode" data-ng-click="editMode = true; editAppKey(item)" class="btn btn-default">Edit</button>
														<button type="submit" data-ng-show="editMode" data-ng-click="editMode = false; saveField($index+'-CUPT')" class="btn btn-default">Save</button>
														<button type="submit" data-ng-show="editMode" data-ng-click="editMode = false; cancel()" class="btn btn-default">Cancel</button>
													</td>
												</tr>
											</tbody>
										</table>
									</div>
								</div>
							</div>
						</div>
					</div>
				</div>
			</div>
		</div>
	</div>
</body>
</html>
