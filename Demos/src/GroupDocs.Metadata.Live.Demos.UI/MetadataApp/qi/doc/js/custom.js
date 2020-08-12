var fileName = 'toconvertmyaccounts.docx';
var folderName = 'e98f9b3b-8aa2-4ed9-bf4b-88effc5f2494';
//var apiURL = '/GroupDocsAPI';
var apiURL = 'http://localhost:2122';
var currentPageCount = 1;
var totalPages = 1;
var currentSelectedPage = 1;
var customPageList = [];
var IsLoadingGif = false;
var prevoiusIndx = -1;
var imagedata = [];
var lstMetadataProperties = [];
var isSent = false;

function sleep(seconds) {
	var e = new Date().getTime() + (seconds * 100);
	while (new Date().getTime() <= e) { var a = 1; }
}