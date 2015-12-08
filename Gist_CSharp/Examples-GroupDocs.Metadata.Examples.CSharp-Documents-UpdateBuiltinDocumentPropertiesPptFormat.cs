// initialize PptFormat
PptFormat pptFormat = new PptFormat(Common.MapSourceFilePath(filePath));

// initialize PptMetadata
PptMetadata pptMetadata = pptFormat.DocumentProperties;
  
// update document property
pptMetadata.Author = "New author";
pptMetadata.Subject = "New subject";
pptMetadata.Manager = "Usman";

//save output file...
pptFormat.Save(Common.MapDestinationFilePath(filePath));
