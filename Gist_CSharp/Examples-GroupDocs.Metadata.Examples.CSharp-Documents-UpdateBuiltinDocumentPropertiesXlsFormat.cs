// initialize XlsFormat
XlsFormat xlsFormat = new XlsFormat(Common.MapSourceFilePath(filePath));

// initialize XlsMetadata
XlsMetadata xlsMetadata = xlsFormat.DocumentProperties;
 
//update document property...
xlsMetadata.Author = "New author";
xlsMetadata.Subject = "New subject";

//save output file...
xlsFormat.Save(Common.MapDestinationFilePath(filePath));
