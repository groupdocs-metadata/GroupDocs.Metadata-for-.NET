// initialize Docformat
DocFormat docFormat = new DocFormat(Common.MapSourceFilePath(filePath));
                    
//Clean metadata
docFormat.CleanMetadata();

// save output file...
docFormat.Save(Common.MapDestinationFilePath(filePath));

