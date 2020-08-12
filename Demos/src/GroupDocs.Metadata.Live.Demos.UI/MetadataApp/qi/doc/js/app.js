(function () {
	'use strict';
	var app = angular.module('myApp', [
		'ngSanitize',
		'ngAnimate',
		'ngQuantum',
		'ngResource'
	]);

	app.value('PageList', customPageList);

	app.run(['$templateCache', '$cacheFactory',
		function ($templateCache, $cacheFactory) {
			$templateCache = false;
		}]);

	app.config(['$httpProvider',
		function ($httpProvider) {
			$httpProvider.defaults.cache = false;
		}]);

	app.config(['$rootScopeProvider',
		function ($rootScopeProvider) {
			$rootScopeProvider.digestTtl(5);
		}]);

	app.factory('MetadataPropertyFactory', function ($resource) {
		return $resource(apiURL + '/api/GroupDocsMetadata/MetadataProperty', {}, {
			query: {
				method: 'GET',
				isArray: true
				
			}
		});
	});


	app.factory('MetadataProtectedFactory', function ($resource) {		
		return $resource(apiURL + '/api/GroupDocsMetadata/MetadataProtected', {}, {
			query: {
				method: 'GET',
				isArray: false			
			}
		});
	});

	
	function isProtectedDocument(MetadataProtectedFactory, $scope, MetadataPropertyFactory) {	
		$scope.loading.show();
		$scope.MetaDataProtected = MetadataProtectedFactory.query({
			file: fileName,
			foldername: folderName
		}, function (data) {
				debugger;
				var docPassword = "";
				if (data.OutputType === "Success") {						
					docPassword = prompt("Document is Password Protected. Please enter valid password to proceed.", "");					
					if (docPassword !== "" && docPassword !== null) {						
						GetMetadataProperties(MetadataPropertyFactory, $scope, docPassword);
					} else {
						window.location = '/metadata/total';						
					}
				} else {
					GetMetadataProperties(MetadataPropertyFactory, $scope, '');
				}				
				$scope.MetaDataProtected = docPassword;

				var cleanMetadata = "/GroupDocsapi/api/GroupDocsMetadata/CleanMetadata?file=" + fileName + "&folderName=" + folderName + "&filePassword=" + docPassword;
				document.getElementById("cleanMetadata").href = cleanMetadata;
				
			$scope.loading.hide();
		}, function (error) {				
			alert(error.data.Message);
			
		});
	}

	function GetMetadataProperties(MetadataPropertyFactory, $scope, docPassword) {
		$scope.loading.show();		
		if (lstMetadataProperties.length === 0) {
			$scope.MetadataProperties = MetadataPropertyFactory.query({
				file: fileName,
				foldername: folderName,
				filePassword: docPassword
			}, function (data) {
				$scope.MetadataProperties = data;
				lstMetadataProperties = $scope.MetadataProperties;
				$scope.loading.hide();
			}, function (error) {
				alert(error.data.Message);
			});
		}
		document.getElementsByName("dvPages")[0].style.cssText = "height: 100vh; width: auto!important; background-color: #fff; background-image: none!important;";
	};

	app.controller('MetadataAPIController',
		function ViewerAPIController($scope, $sce, $http, $resource, $loading, $timeout, $q, $alert, MetadataProtectedFactory, MetadataPropertyFactory) {
			var $that = this;

			$scope.MetadataProperties = {}
		
			$scope.loadingButtonSucces = function () {
				return $timeout(function () {
					return true;
				}, 2000);
			};

			$scope.existApp = function (isExit) {
				if (isExit)
					window.location = '/metadata/total';
				else
					window.location = '';
			};

			$scope.loading = new $loading({
				busyText: ' Please wait while loading...',
				theme: 'info',
				timeout: false,
				showSpinner: true
			});

			
			isProtectedDocument(MetadataProtectedFactory, $scope, MetadataPropertyFactory);
			//GetMetadataProperties(MetadataPropertyFactory, $scope);
			

			$scope.newField = {};
			$scope.editing = 0;

			$scope.editAppKey = function (field) {
				$scope.loading.show();
				$scope.editing = $scope.MetadataProperties.indexOf(field);
				$scope.newField = angular.copy(field);
				$scope.loading.hide();
			};

			$scope.saveField = function (txtName) {
				if ($scope.editing !== false) {
					$scope.loading.show();
					lstMetadataProperties[$scope.editing].Value = angular.element(document.getElementsByName(txtName)).val();
					$scope.loading.hide();
				}
			};

			$scope.cancel = function (index) {
				if ($scope.editing !== false) {
					$scope.MetadataProperties[$scope.editing] = $scope.newField;
					$scope.editing = false;
				}
			};

			$scope.cleanMetadata = function (isAll) {
				$scope.loading.show();
				
				var docPass = $scope.MetaDataProtected;				
				if (isAll) {					
					window.location = apiURL + '/api/GroupDocsMetadata/CleanMetadata?file=' + fileName + '&folderName=' + folderName + "&filePassword=" + docPass;
				}
				$scope.loading.hide();
			};

			$scope.exportMetadata = function (isExcel) {
				var docPass = $scope.MetaDataProtected;
				$scope.loading.show();
				window.location = apiURL + '/api/GroupDocsMetadata/ExportMetadata?file=' + fileName + '&folderName=' + folderName + "&isExcel=" + isExcel + "&filePassword=" + docPass;
				$scope.loading.hide();
			};

			$scope.editMetadata = function (isAll) {
				$scope.loading.show();
				var objXhr = new XMLHttpRequest();
				var mydata = new FormData();
				var docPass = $scope.MetaDataProtected;

				objXhr.open("POST", apiURL + '/api/GroupDocsMetadata/UpdateMetadata?file=' + fileName + '&folderName=' + folderName + '&filePassword=' + docPass, false);
				mydata.append("lstProperties", JSON.stringify(lstMetadataProperties));
				objXhr.send(mydata);

				if (objXhr.status === 200) {
					window.location = apiURL + '/api/GroupDocsMetadata/downloaddocument?file=' + fileName + '&folderName=' + folderName + '&isUpdated=true';
				}
				else {
					alert('Unable to update information, please try again.');
				}

				$scope.loading.hide();
			};

			$scope.getError = function () {
				var deferred = $q.defer();

				setTimeout(function () {
					deferred.reject('Error');
				}, 1000);
				return deferred.promise;
			};

			$scope.displayAlert = function (title, message, theme) {
				$alert(message, title, theme);
			};

			if (customPageList.length <= 0) {
				$scope.PageList = customPageList;
			}
		});
})();