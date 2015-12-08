// initialize DocFormat
DocFormat docFormat = new DocFormat(Common.MapSourceFilePath(filePath));

// initialize metadata
DocMetadata docMetadata = docFormat.DocumentProperties;

// get properties  
Console.WriteLine("\nCustom Properties");
foreach (KeyValuePair<string, PropertyValue> keyValuePair in docMetadata)
{
    // check if property is not built-in
    if (!docMetadata.IsBuiltIn(keyValuePair.Key))
    {
        // get property value
        PropertyValue propertyValue = docMetadata[keyValuePair.Key];
        Console.WriteLine("Key: {0}, Type:{1}, Value: {2}", keyValuePair.Key, propertyValue.Type, propertyValue);
    }
}
