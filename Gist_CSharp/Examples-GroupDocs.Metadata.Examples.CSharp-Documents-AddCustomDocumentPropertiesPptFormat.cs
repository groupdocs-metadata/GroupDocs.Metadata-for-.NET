// initialize PptFormat
PptFormat pptFormat = new PptFormat(Common.MapSourceFilePath(filePath));

// initialize PptMetadata
PptMetadata metadata = pptFormat.DocumentProperties;

// set property details 
string propertyName = "New custom property";
string propertyValue = "Value";

// check if property already exists
if (!metadata.ContainsKey(propertyName))
{
    // add property
    metadata.Add(propertyName, propertyValue);
}

// save file in destination folder
pptFormat.Save(Common.MapDestinationFilePath(filePath));
