// initialize DocFormat
DocFormat docFormat = new DocFormat(Common.MapSourceFilePath(filePath));

// initialize DocMetadata
DocMetadata metadata = docFormat.DocumentProperties;

string propertyName = "New Custom Property";

// check if property is not built-in
if (metadata.ContainsKey(propertyName))
{
    if (!metadata.IsBuiltIn(propertyName))
    {
        // remove property
        metadata.Remove(propertyName);

    }
    else
    {
        Console.WriteLine("Can not remove built-in property.");
    }
}
else
{
    Console.WriteLine("Property does not exist.");
}

bool isexist = metadata.ContainsKey(propertyName);
                    
// save file in destination folder
docFormat.Save(Common.MapDestinationFilePath(filePath));
