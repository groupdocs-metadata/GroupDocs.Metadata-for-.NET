// initialize PdfFormat
PdfFormat pdfFormat = new PdfFormat(Common.MapSourceFilePath(filePath));

// initialize PdfMetadata
PdfMetadata metadata = pdfFormat.DocumentProperties;

string propertyName = "New Custom Property";

// check if property is not built-in
if (!metadata.IsBuiltIn(propertyName))
{
    // remove property
    metadata.Remove(propertyName);
}
else
{
    Console.WriteLine("Can not remove built-in property.");
}

// save file in destination folder
pdfFormat.Save(Common.MapDestinationFilePath(filePath));
