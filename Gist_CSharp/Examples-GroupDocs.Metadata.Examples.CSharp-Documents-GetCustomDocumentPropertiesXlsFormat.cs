// initialize XlsFormat
XlsFormat xlsFormat = new XlsFormat(Common.MapSourceFilePath(filePath));

// initialize XlsMetadata
XlsMetadata xlsMetadata = xlsFormat.DocumentProperties;
   
Console.WriteLine("\nCustom Properties");
foreach (KeyValuePair<string, PropertyValue> keyValuePair in xlsMetadata)
{
    // check if property is not built-in
    if (!xlsMetadata.IsBuiltIn(keyValuePair.Key))
    {
        // get property value
        PropertyValue propertyValue = xlsMetadata[keyValuePair.Key];
        Console.WriteLine("Key: {0}, Type:{1}, Value: {2}", keyValuePair.Key, propertyValue.Type, propertyValue);
    }
}
