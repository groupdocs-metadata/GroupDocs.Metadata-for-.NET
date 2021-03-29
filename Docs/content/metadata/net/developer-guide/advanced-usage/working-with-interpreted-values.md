---
id: working-with-interpreted-values
url: metadata/net/working-with-interpreted-values
title: Traverse a whole metadata tree
weight: 8
description: ""
keywords: 
productName: GroupDocs.Metadata for .NET
hideChildren: False
---
Sometimes it's not really obvious what a particular metadata property is supposed to mean. A good example of such vague property is a numeric flag or enumeration. For example, here is the description of the EXIF ExposureProgram tag taken from the official EXIF specification:

{{< alert style="info" >}}
The class of the program used by the camera to set exposure when the picture is taken. The tag values are as follows.

0 = Not defined

1 = Manual

2 = Normal program

3 = Aperture priority

4 = Shutter priority

5 = Creative program

6 = Action program

7 = Portrait mode

8 = Landscape mode

{{< /alert >}}

As you can see, all modes are represented by numeric values. If you are not familiar with the specification, you will get a hard time converting these bare numbers to something meaningful. This is where interpreted values come into play. They provide a user-friendly description of the original property value. The code snippet below demonstrates how to extract the ExposureProgram property and display its original value and interpreted value.


```csharp
using (Metadata metadata = new Metadata(@"D:\input.heic"))
{
    var root = (IExif)metadata.GetRootPackage();
    if (root.ExifPackage != null)
    {
        var property = root.ExifPackage.ExifIfdPackage[TiffTagID.ExposureProgram] as TiffShortTag;
        if (property != null)
        {
            Console.WriteLine(property.TagValue[0]); // 2
            Console.WriteLine(property.InterpretedValue); // Normal program
        }
    }
}
```

From release to release, we add interpreters to metadata properties extracted from various formats. To get a full list of properties having interpreted values for a particular file please use the below example:

**AdvancedUsage.WorkingWithInterpretedValues**

```csharp
foreach (string file in Directory.GetFiles(Constants.InputPath))
{
    using (Metadata metadata = new Metadata(file))
    {
        if (metadata.FileFormat != FileFormat.Unknown && !metadata.GetDocumentInfo().IsEncrypted)
        {
            Console.WriteLine();
            Console.WriteLine(file);
            var properties = metadata.FindProperties(p => p.InterpretedValue != null);
            foreach (var property in properties)
            {
                Console.WriteLine(property.Name);
                Console.WriteLine(property.Value.RawValue);
                Console.WriteLine(property.InterpretedValue.RawValue);
            }
        }
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