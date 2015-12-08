// initialize PptFormat
PptFormat pptFormat = new PptFormat(Common.MapSourceFilePath(filePath));

// initialize PptMetadata
PptMetadata pptMetadata = pptFormat.DocumentProperties;

// built-in properties
Console.WriteLine("\nBuilt-in Properties");
foreach (var property in pptMetadata)
{
    if (pptMetadata.IsBuiltIn(property.Key))
    {
        Console.WriteLine("{0} : {1}", property.Key, property.Value);
    }
}
