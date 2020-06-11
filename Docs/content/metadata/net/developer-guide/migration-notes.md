---
id: migration-notes
url: metadata/net/migration-notes
title: Migration Notes
weight: 3
description: ""
keywords: 
productName: GroupDocs.Metadata for .NET
hideChildren: False
---
# Why To Migrate?

Here are the key reasons to use the new API provided by GroupDocs.Metadata for .NET starting from version 19.11:

*   The* Metadata* class is introduced as a **single entry point** to manage metadata in files of all supported formats.
*   Extracting and updating metadata was unified for all supported formats.
*   The product architecture was redesigned from scratch in order to simplify most common operations with metadata properties.
*   Getting document information and preview generation procedures were simplified.

# How To Migrate?

Here is a brief comparison of how to manage metadata using the old and new API.


### Loading Files

#### Any Supported Format

The following examples show how to load a file of any supported format.

**Old API**

```csharp
using (FormatBase format = FormatFactory.RecognizeFormat(@"D:\input.doc"))
{
	// ...
}
```

**New API**

```csharp
using (Metadata metadata = new Metadata(@"D:\input.doc"))
{
	// ...
}
```

#### Some Specific Format

The code samples below demonstrate how to load a file of a specific format.

**Old API**

```csharp
using (XlsFormat xlsFormat = new XlsFormat(@"D:\input.xls"))
{
	// ...
}
```

**New API**

```csharp
var loadOptions = new LoadOptions(FileFormat.Spreadsheet);
using (Metadata metadata = new Metadata(Constants.InputXls, loadOptions))
{
	var root = metadata.GetRootPackage<SpreadsheetRootPackage>();

	// ...
}
```

### Working with Metadata using Regular Expressions

#### Finding Metadata using Regular Expressions

The following code snippets retrieve metadata from a file using a regular expression.

**Old API**

```csharp
Regex pattern = new Regex("author|company", RegexOptions.IgnoreCase);

// This method works with document formats only
MetadataPropertyCollection properties = SearchFacade.ScanDocument(@"D:\input.docx", pattern);
for (int i = 0; i < properties.Count; i++)
{
	Console.WriteLine(properties[i]);
}
```

**New API**

```csharp
Regex pattern = new Regex("author|company", RegexOptions.IgnoreCase);

using (Metadata metadata = new Metadata(@"D:\input.docx"))
{
	// This method searches for properties across all metadata packages and works with all supported formats
	var properties = metadata.FindProperties(p => pattern.IsMatch(p.Name) || pattern.IsMatch(p.Value.ToString()));

	foreach (var property in properties)
	{
		Console.WriteLine("{0} = {1}", property.Name, property.Value);
	}
}
```

#### Replacing Metadata using Regular Expressions

The following code snippets show how to replace metadata properties using a regular expression.

**Old API**

```csharp
Regex pattern = new Regex("^author|company$", RegexOptions.IgnoreCase);
string replaceValue = "Aspose";

// This method works with document formats only
SearchFacade.ReplaceInDocument(@"D:\input.docx", pattern, replaceValue, @"D:\output.docx");
```

**New API**

```csharp
var pattern = new Regex("^author|company$", RegexOptions.IgnoreCase);
var replaceValue = new PropertyValue("Aspose");

using (Metadata metadata = new Metadata(@"D:\input.docx"))
{
	// This method updates writable properties across all metadata packages and works with all supported formats
	metadata.UpdateProperties(p => pattern.IsMatch(p.Name), replaceValue);

	metadata.Save(@"D:\output.docx");
}
```

### Comparing Metadata

#### Get the Difference between Two Sets of Metadata Properties

The code samples below demonstrate how to get the difference of two collections of properties extracted from different files.

**Old API**

```csharp
var firstDocument = @"D:\input1.docx";
var secondDocument = @"D:\input2.docx";

MetadataPropertyCollection differnces = ComparisonFacade.CompareDocuments(firstDocument, secondDocument, ComparerSearchType.Difference);

foreach(MetadataProperty property in differnces)
{
    Console.WriteLine("{0} : {1}", property.Name, property.Value);
}
```

**New API**

```csharp
// The predicate to extract metadata properties we want to compare
// In this code sample we retrieve built-in document properties
Common.Func<MetadataProperty, bool> predicate = p => p.Tags.Contains(Tags.Document.BuiltIn);

using (Metadata metadata1 = new Metadata(@"D:\input1.docx"))
using (Metadata metadata2 = new Metadata(@"D:\input2.docx"))
{
	// You can implement your own equality comparer for metadata properties
	// In this code sample, we just use the old one that worked in previous versions of GroupDocs.Metadata
	var difference = metadata1.FindProperties(predicate).Except(metadata2.FindProperties(predicate), new MetadataPropertyEqualityComparer());
	foreach (var property in difference)
	{
		Console.WriteLine("{0} = {1}", property.Name, property.Value);
	}
}
```

#### Get the Intersection of Two Sets of Metadata Properties

The code samples below demonstrate how to get the intersection of two collections of properties extracted from different files.

**Old API**

```csharp
var firstDocument = @"D:\input1.jpg";
var secondDocument = @"D:\input2.jpg";

TiffTag[] intersection = ComparisonFacade.CompareExifTags(firstFile, secondFile, ComparerSearchType.Intersection);

foreach (TiffTag tag in intersection)
{
    Console.WriteLine(tag.DefinedTag);
    Console.WriteLine(tag.TagType);
    Console.WriteLine(tag.GetFormattedValue());
}
```

**New API**

```csharp
// The predicate to extract metadata properties we want to compare
// In this code sample we retrieve TIFF/EXIF tags
Common.Func<MetadataProperty, bool> predicate = p => p is TiffTag;

using (Metadata metadata1 = new Metadata(@"D:\input1.jpg"))
using (Metadata metadata2 = new Metadata(@"D:\input2.jpg"))
{
	// You can implement your own equality comparer for metadata properties
	// In this code sample, we just use the old one that worked in previous versions of GroupDocs.Metadata
	var intersection = metadata1.FindProperties(predicate).Intersect(metadata2.FindProperties(predicate), new MetadataPropertyEqualityComparer());

	foreach (var property in intersection)
	{
		Console.WriteLine("{0} = {1}", property.Name, property.Value);
	}
}
```

### Exporting Metadata

#### Export Metadata Properties to CSV

The following code snippets show how to export metadata properties to a CSV file.

**Old API**

```csharp
string outputPath = @"D:\metadata.csv";

// export to csv
byte[] content = ExportFacade.ExportToCsv(@"D:\input.eml");

// write data to the file
File.WriteAllBytes(outputPath, content);
```

**New API**

```csharp
using (Metadata metadata = new Metadata(@"D:\input.eml"))
{
	// We use a predicate that extracts all metadata properties
	var properties = metadata.FindProperties(p => true);

	const string delimiter = ";";
	StringBuilder builder = new StringBuilder();
	builder.AppendFormat("Name{0}Value", delimiter);
	builder.AppendLine();
	foreach (var property in properties)
	{
		builder.AppendFormat(@"""{0}""{1}""{2}""", property.Name, delimiter, FormatValue(property.Value));
		builder.AppendLine();
	}

	File.WriteAllText(@"D:\metadata.csv", builder.ToString());
}
```

{{< alert style="info" >}}The implementation of the FormatValue method used in the code sample above can be different depending on your task so we just omitted it here. Please see the full code of the method in the sample project on GitHub.{{< /alert >}}

### Using the Replace API

#### Update Values with IReplaceHandler

The code samples below show how to update metadata properties using a custom filter.

**Old API (Implementation of IReplaceHandler)**

```csharp
/// <summary>
/// This class updates author to 'Jack London'
/// </summary>
public class AuthorReplaceHandler : IReplaceHandler<MetadataProperty>
{
    public AuthorReplaceHandler(string outputPath)
    {
        this.OutputPath = outputPath;
    }

    public string OutputPath { get; private set; }

    public bool Handle(MetadataProperty property)
    {
        // if property name is 'author'
        if (property.Name.ToLower() == "author")
        {
            // update property value
            property.Value = new PropertyValue("Jack London");
            // and mark property as updated
            return true;
        }

        // ignore all other properties
        return false;
    }
}
```

**Old API (Usage of AuthorReplaceHandler)**

```csharp
// initialize custom handler, send output path using constructor
IReplaceHandler<MetadataProperty> replaceHandler = new AuthorReplaceHandler(@"D:\output.docx");
// replace author
int affectedPropertiesCount = SearchFacade.ReplaceInDocument(@"D:\intput.docx", replaceHandler);
```

In the new API there is no need to use the IReplaceHandler interface since you have full control over property filters using the GrooupDocs.Metadata search engine.

**New API**

```csharp
using (Metadata metadata = new Metadata(@"D:\intput.docx"))
{
	var affected = metadata.UpdateProperties(
		p => string.Equals(p.Name, "author", StringComparison.OrdinalIgnoreCase),
				new PropertyValue("Jack London"));
				
	Console.WriteLine(affected);

	metadata.Save(@"D:\output.docx");
}
```

### Extracting a Specific Metadata Package

#### Extract a Metadata Package of a Specific Type

The code samples below demonstrate how to fetch a metadata package with a specific type.

**Old API**

```csharp
DublinCoreMetadata dublinCoreMetadata = (DublinCoreMetadata)MetadataUtility.ExtractSpecificMetadata("D:\input.docx", MetadataType.DublinCore);

if (dublinCoreMetadata != null)
{
	Console.WriteLine(dublinCoreMetadata.Creator);
	Console.WriteLine(dublinCoreMetadata.Format);
	Console.WriteLine(dublinCoreMetadata.Subject);
}
```

**New API**

```csharp
using (Metadata metadata = new Metadata("D:\input.docx"))
{
	var property = metadata.FindProperties(p => p.Value.RawValue is DublinCorePackage).FirstOrDefault();

	if (property != null)
	{
		var package = property.Value.ToClass<DublinCorePackage>();
		Console.WriteLine(package.Format);
		Console.WriteLine(package.Contributor);
		Console.WriteLine(package.Coverage);
		Console.WriteLine(package.Creator);
		Console.WriteLine(package.Source);
		Console.WriteLine(package.Description);

		// ...
	}
}
```
