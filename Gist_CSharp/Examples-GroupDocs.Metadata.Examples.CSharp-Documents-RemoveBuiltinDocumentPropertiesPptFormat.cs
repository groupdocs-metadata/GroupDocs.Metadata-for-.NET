// initialize PptFormat
PptFormat pptFormat = new PptFormat(Common.MapSourceFilePath(filePath));

// clean metadata
pptFormat.CleanMetadata();

// save output file...
pptFormat.Save(Common.MapDestinationFilePath(filePath));
