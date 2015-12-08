// initialize XlsFormat
XlsFormat xlsFormat = new XlsFormat(Common.MapSourceFilePath(filePath));

// initialize XlsMetadata
XlsMetadata metadata = xlsFormat.DocumentProperties;

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
xlsFormat.Save(Common.MapDestinationFilePath(filePath));
