// initialize XlsFormat
XlsFormat xlsFormat = new XlsFormat(Common.MapSourceFilePath(filePath));

// initialize XlsMetadata
XlsMetadata metadata = xlsFormat.DocumentProperties;

string propertyName = "New Custom Property";
string propertyValue = "123";

// check if property already exists
if (!metadata.ContainsKey(propertyName))
{
    // add property
    metadata.Add(propertyName, propertyValue);
}

// save file in destination folder
xlsFormat.Save(Common.MapDestinationFilePath(filePath));
