---
id: evaluation-limitations-and-licensing
url: metadata/net/evaluation-limitations-and-licensing
title: Evaluation Limitations and Licensing
weight: 5
description: ""
keywords: 
productName: GroupDocs.Metadata for .NET
hideChildren: False
---
{{< alert style="info" >}}GroupDocs.Metadata also works without the license in trial mode with certain limitations{{< /alert >}}

## Evaluation Version Limitations

You can easily download GroupDocs.Metadata for evaluation. The evaluation download is the same as the purchased download. The evaluation version simply becomes licensed when you add a few lines of code to apply the license. You will face following limitations while using the API without the license.  

| API | Limitations |
| --- | --- |
| Document properties (Pdf, Word, Excel, PowerPoint, Visio, etc) | Only first 5 properties can be read |
| XMP API | Only first 2 XMP schemes can be read |
| EXIF API | GPS IFD and image thumbnail are unavailable  
Only first 5 properties can be read |
| IPTC API | Only first 5 properties can be read |
| Id3v2, Lyrics3, APEv2 tags | Only first 5 properties can be read |
| QuickTime atoms | Only first 5 atoms can be read |
| File open | Open maximum 15 files, otherwise, API throws exception |
| File save | Not supported in trial mode |

## Licensing 

The license file contains details such as the product name, number of developers it is licensed to, subscription expiry date and so on. It contains the digital signature, so don't modify the file. Even inadvertent addition of an extra line break into the file will invalidate it. You need to set a license before utilizing GroupDocs.Metadata API if you want to avoid its evaluation limitations. 

The license can be loaded from a file or stream object. The easiest way to set a license is to put the license file in the same folder as the GroupDocs.Metadata.dll file and specify the file name, without a path, as shown in the examples below.

### Applying License from File

The code below will explain how to apply a  product license.

```csharp
// For complete examples and data files, please go to https://github.com/groupdocs-metadata/GroupDocs.Metadata-for-.NET

// initialize License
License lic = new License();

// apply license
lic.SetLicense("GroupDocs.Metadata.lic");

```

### Applying License from Stream

The following example shows how to load a license from a stream.

```csharp
// For complete examples and data files, please go to https://github.com/groupdocs-metadata/GroupDocs.Metadata-for-.NET

using (FileStream fileStream = new FileStream("GroupDocs.Metadata.lic", FileMode.Open, FileAccess.Read))
{
    License lic = new License();
    lic.SetLicense(fileStream);
}
```

{{< alert style="info" >}}Calling License.SetLicense multiple times is not harmful but simply wastes processor time. If you are developing a Windows Forms or console application, call License.SetLicense in your startup code, before using GroupDocs.Metadata classes. When developing an ASP.NET application, you can call License.SetLicense from the Global.asax.cs (Global.asax.vb) file in the Application_Start protected method. It is called once when the application starts. Do not call License.SetLicense from within Page_Load methods since it means the license will be loaded every time a web page is loaded.{{< /alert >}}

### Applying Metered License

{{< alert style="info" >}}You can also set Metered license as an alternative to license file. It is a new licensing mechanism that will be used along with existing licensing method. It is useful for the customers who want to be billed based on the usage of the API features. For more details, please refer to Metered Licensing FAQ section.{{< /alert >}}

Here are the simple steps to use the `Metered` class.

1.  Create an instance of `Metered` class.
2.  Pass public & private keys to `setMeteredKey` method.
3.  Do processing (perform task).
4.  call method `getConsumptionQuantity` of the `Metered` class.
5.  It will return the amount/quantity of API requests that you have consumed so far.
6.  call method `getConsumptionCredit` of the `Metered` class (Since version 19.5).
7.  It will return the credit that you have consumed so far.

Following is the sample code demonstrating how to use `Metered` class.

```csharp
// For complete examples and data files, please go to https://github.com/groupdocs-metadata/GroupDocs.Metadata-for-.NET

// initialize Metered API
Metered metered = new Metered();

// set-up credentials
metered.SetMeteredKey("publicKey", "privateKey");

```
