// initialize PdfFormat
PdfFormat pdfFormat = new PdfFormat(Common.MapSourceFilePath(filePath));

// initialize PdfMetadata
PdfMetadata metadata = pdfFormat.DocumentProperties;
 
string propertyName = "New Custom Property";
string propertyValue = "123";


// check if property already exists
if (!metadata.ContainsKey(propertyName))
{
    // add property
    metadata.Add(propertyName, propertyValue);
}

// save file in destination folder
pdfFormat.Save(Common.MapDestinationFilePath(filePath));
