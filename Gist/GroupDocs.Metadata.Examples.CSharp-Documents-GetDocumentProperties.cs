// initialize DocFormat
DocFormat docFormat = new DocFormat(Common.MapSourceFilePath(filePath));

// initialize metadata
DocMetadata docMetadata = docFormat.DocumentProperties;

// get properties
Console.WriteLine("Built-in Properties: ");
foreach (var property in docMetadata)
{
    // check if built-in property
    if (docMetadata.IsBuiltIn(property.Key))
    {
        Console.WriteLine("{0} : {1}", property.Key, property.Value);
    }
}

Console.WriteLine("\nCustom Properties");
foreach (KeyValuePair<string, PropertyValue> keyValuePair in docMetadata)
{
    // check if prooerty is not built-in
    if (!docMetadata.IsBuiltIn(keyValuePair.Key))
    {
        // get property value
        PropertyValue propertyValue = docMetadata[keyValuePair.Key];
        Console.WriteLine("Key: {0}, Type:{1}, Value: {2}", keyValuePair.Key, propertyValue.Type, propertyValue);
    }
}
