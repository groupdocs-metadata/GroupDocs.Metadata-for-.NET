// initialize PptFormat
PptFormat pptFormat = new PptFormat(Common.MapSourceFilePath(filePath));

// initialize PptMetadata
PptMetadata pptMetadata = pptFormat.DocumentProperties;

Console.WriteLine("\nCustom Properties");
foreach (KeyValuePair<string, PropertyValue> keyValuePair in pptMetadata)
{
    // check if property is not built-in
    if (!pptMetadata.IsBuiltIn(keyValuePair.Key))
    {
        // get property value
        PropertyValue propertyValue = pptMetadata[keyValuePair.Key];
        Console.WriteLine("Key: {0}, Type:{1}, Value: {2}", keyValuePair.Key, propertyValue.Type, propertyValue);
    }
}
