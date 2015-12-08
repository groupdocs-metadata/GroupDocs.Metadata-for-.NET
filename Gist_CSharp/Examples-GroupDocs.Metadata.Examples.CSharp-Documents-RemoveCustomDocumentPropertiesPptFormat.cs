// initialize PptFormat
PptFormat pptFormat = new PptFormat(Common.MapSourceFilePath(filePath));

// initialize PptMetadata
PptMetadata metadata = pptFormat.DocumentProperties;
 
string propertyName = "New custom property";

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
pptFormat.Save(Common.MapDestinationFilePath(filePath));
