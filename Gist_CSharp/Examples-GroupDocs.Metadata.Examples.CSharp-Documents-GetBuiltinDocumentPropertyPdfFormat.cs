// initialize Pdfformat
PdfFormat pdfFormat = new PdfFormat(Common.MapSourceFilePath(filePath));

// initialize PdfMetadata
PdfMetadata pdfMetadata = pdfFormat.DocumentProperties;

// built-in properties
Console.WriteLine("Built-in Properties");
foreach (var property in pdfMetadata)
{
    // check if built-in property
    if (pdfMetadata.IsBuiltIn(property.Key))
    {
        Console.WriteLine("{0} : {1}", property.Key, property.Value);
    }
}
