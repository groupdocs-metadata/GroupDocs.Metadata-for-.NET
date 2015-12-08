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
