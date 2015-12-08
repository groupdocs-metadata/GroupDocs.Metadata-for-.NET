// initialize Pdfformat
PdfFormat pdfFormat = new PdfFormat(Common.MapSourceFilePath(filePath));

// initialize PdfMetadata
PdfMetadata pdfMetadata = pdfFormat.DocumentProperties;

Console.WriteLine("\nCustom Properties");
foreach (KeyValuePair<string, PropertyValue> keyValuePair in pdfMetadata)
{
    // check if property is not built-in
    if (!pdfMetadata.IsBuiltIn(keyValuePair.Key))
    {
        // get property value
        PropertyValue propertyValue = pdfMetadata[keyValuePair.Key];
        Console.WriteLine("Key: {0}, Type:{1}, Value: {2}", keyValuePair.Key, propertyValue.Type, propertyValue);
    }
}
