// initialize DocFormat
DocFormat docFormat = new DocFormat(Common.MapSourceFilePath(filePath));

// initialize DocMetadata
DocMetadata docMetadata = docFormat.DocumentProperties;
                    
//update document property...
docMetadata.Author = "Usman";
docMetadata.Company = "Aspose";
docMetadata.Manager = "Usman Aziz";

//save output file...
docFormat.Save(Common.MapDestinationFilePath(filePath));

