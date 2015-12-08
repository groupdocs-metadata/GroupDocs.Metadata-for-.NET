// initialize PdfFormat
PdfFormat pdfFormat = new PdfFormat(Common.MapSourceFilePath(filePath));
                    
pdfFormat.CleanMetadata();
                    
//save output file...
pdfFormat.Save(Common.MapDestinationFilePath(filePath));
