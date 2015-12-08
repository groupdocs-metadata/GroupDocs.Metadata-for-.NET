// initialize XlsFormat
XlsFormat xlsFormat = new XlsFormat(Common.MapSourceFilePath(filePath));

// initialize XlsMetadata
XlsMetadata xlsMetadata = xlsFormat.DocumentProperties;

// built-in properties
Console.WriteLine("\nBuilt-in Properties");
foreach (var property in xlsMetadata)
{
    // check if property is biltin
    if (xlsMetadata.IsBuiltIn(property.Key))
    {
        Console.WriteLine("{0} : {1}", property.Key, property.Value);
    }
}
