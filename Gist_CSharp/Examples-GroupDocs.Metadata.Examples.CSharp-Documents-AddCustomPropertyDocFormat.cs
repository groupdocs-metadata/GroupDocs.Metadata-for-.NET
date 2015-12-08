// initialize DocFormat
DocFormat docFormat = new DocFormat(Common.MapSourceFilePath(filePath));

// initialize DocMetadata
DocMetadata metadata = docFormat.DocumentProperties;


string propertyName = "New Custom Property";
string propertyValue = "123";

// add boolean key
if (!metadata.ContainsKey(propertyName))
{
    // add property
    metadata.Add(propertyName, propertyValue);
}

// save file in destination folder
docFormat.Save(Common.MapDestinationFilePath(filePath));
