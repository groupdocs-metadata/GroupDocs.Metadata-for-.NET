// initialize PdfFormat
PdfFormat pdfFormat = new PdfFormat(Common.MapSourceFilePath(filePath));
                    
// initialize PdfMetadata
PdfMetadata pdfMetadata = pdfFormat.DocumentProperties;
 
//update document property...
pdfMetadata.Author = "New author";
pdfMetadata.Subject = "New subject";
pdfMetadata.CreatedDate = DateTime.Now;

//save output file...
pdfFormat.Save(Common.MapDestinationFilePath(filePath));

