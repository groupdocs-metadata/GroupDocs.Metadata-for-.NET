---
id: extracting-property-values
url: metadata/net/extracting-property-values
title: Extracting property values
weight: 2
description: ""
keywords: 
productName: GroupDocs.Metadata for .NET
hideChildren: False
---
The most common way to get the metadata property value is to check its type and convert it to the appropriate platform-specific type.

**AdvancedUsage.ExtractingPropertyValues.ExtractUsingType**

```csharp
using (Metadata metadata = new Metadata(Constants.InputDocx))
{
	// Fetch all metadata properties from the file
	var properties = metadata.FindProperties(p => true);
	foreach (var property in properties)
	{
		// Process string and DateTime properties only
		if (property.Value.Type == MetadataPropertyType.String)
		{
			Console.Write(property.Value.ToClass<string>());
		}
		else if (property.Value.Type == MetadataPropertyType.DateTime)
		{
			Console.Write(property.Value.ToStruct(DateTime.MinValue));
		}
	}
}
```

But if it's necessary to process all supported types of values you may find the alternative way more convenient.

**AdvancedUsage.ExtractingPropertyValues.ExtractUsingAcceptor**

```csharp
static void Main(string[] args)
{
    using (Metadata metadata = new Metadata(Constants.InputDocx))
    {
        // Fetch all metadata properties
        var properties = metadata.FindProperties(p => true);
 
        var valueAcceptor = new CustomValueAcceptor();
        foreach (var property in properties)
        {
            // Extract the property value using a custom acceptor
            property.Value.AcceptValue(valueAcceptor);
        }
    }
    Console.ReadKey();
}

private class CustomValueAcceptor : ValueAcceptor
{
    protected override void AcceptNull()
    {
        Console.WriteLine("Null value extracted");
    }
 
    protected override void Accept(string value)
    {
        Console.WriteLine("String value extracted: {0}", value);
    }
 
    protected override void Accept(bool value)
    {
        Console.WriteLine("Boolean value extracted: {0}", value);
    }
 
    protected override void Accept(DateTime value)
    {
        Console.WriteLine("DateTime value extracted: {0}", value);
    }
 
    protected override void Accept(TimeSpan value)
    {
        Console.WriteLine("DateTime value extracted: {0}", value);
    }
 
    protected override void Accept(int value)
    {
        Console.WriteLine("Integer value extracted: {0}", value);
    }
 
    protected override void Accept(long value)
    {
        Console.WriteLine("Long value extracted: {0}", value);
    }
 
    protected override void Accept(double value)
    {
        Console.WriteLine("Double value extracted: {0}", value);
    }
 
    protected override void Accept(string[] value)
    {
        Console.WriteLine("String array extracted: {0}", value?.Length ?? 0);
    }
 
    protected override void Accept(byte[] value)
    {
        Console.WriteLine("Byte array extracted: {0}", value?.Length ?? 0);
    }
 
    protected override void Accept(double[] value)
    {
        Console.WriteLine("Double array extracted: {0}", value?.Length ?? 0);
    }
 
    protected override void Accept(int[] value)
    {
        Console.WriteLine("Integer array extracted: {0}", value?.Length ?? 0);
    }
 
    protected override void Accept(long[] value)
    {
        Console.WriteLine("Long array extracted: {0}", value?.Length ?? 0);
    }
 
    protected override void Accept(MetadataPackage value)
    {
        Console.WriteLine("Metadata package value extracted: {0}", value);
    }
 
    protected override void Accept(MetadataPackage[] value)
    {
        Console.WriteLine("Metadata package array extracted: {0}", value?.Length ?? 0);
    }
 
    protected override void Accept(Guid value)
    {
        Console.WriteLine("Guid value extracted: {0}", value);
    }
 
    protected override void Accept(PropertyValue[] value)
    {
        Console.WriteLine("Property value array extracted: {0}", value?.Length ?? 0);
    }
}
```

## More resources

### GitHub examples

You may easily run the code above and see the feature in action in our GitHub examples:

*   [GroupDocs.Metadata for .NET examples](https://github.com/groupdocs-metadata/GroupDocs.Metadata-for-.NET)
    
*   [GroupDocs.Metadata for Java examples](https://github.com/groupdocs-metadata/GroupDocs.Metadata-for-Java)
    

### Free online document metadata management App

Along with full featured .NET library we provide simple, but powerful free Apps.

You are welcome to view and edit metadata of PDF, DOC, DOCX, PPT, PPTX, XLS, XLSX, emails, images and more with our free online [Free Online Document Metadata Viewing and Editing App](https://products.groupdocs.app/metadata).
