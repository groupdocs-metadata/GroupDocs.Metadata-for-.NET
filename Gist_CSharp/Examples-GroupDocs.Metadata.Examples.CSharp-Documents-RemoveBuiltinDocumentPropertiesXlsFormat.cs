// initialize XlsFormat
XlsFormat xlsFormat = new XlsFormat(Common.MapSourceFilePath(filePath));

// clean metadata
xlsFormat.CleanMetadata();

//save output file...
xlsFormat.Save(Common.MapDestinationFilePath(filePath));
