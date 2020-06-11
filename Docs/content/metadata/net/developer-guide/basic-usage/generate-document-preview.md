---
id: generate-document-preview
url: metadata/net/generate-document-preview
title: Generate document preview
weight: 6
description: ""
keywords: 
productName: GroupDocs.Metadata for .NET
hideChildren: False
---
If you need to implement a UI for your application it can be useful to generate image previews for a document the users are going to work with. Such previews can be easily displayed on a web page or in an appropriate component of a desktop/mobile application. The code sample below demonstrates how to generate image previews for certain document pages.

Here are the steps to generate a document preview for a particular page:

1.  [Load]({{< ref "metadata/net/developer-guide/basic-usage/generate-document-preview.md" >}}) a document to preview
2.  Specify a delegate that will be used to create the page streams (please see the [CreatePageStream](https://apireference.groupdocs.com/net/metadata/groupdocs.metadata.options/createpagestream) delegate for more information)
3.  Specify the page numbers
4.  Generate previews for desired pages using the [GeneratePreview](https://apireference.groupdocs.com/net/metadata/groupdocs.metadata/metadata/methods/generatepreview) method of the [Metadata](https://apireference.groupdocs.com/net/metadata/groupdocs.metadata/metadata) class

**BasicUsage.GenerateFilePreview**

```csharp
using (Metadata metadata = new Metadata(Constants.InputDocx))
{
	PreviewOptions previewOptions = new PreviewOptions(pageNumber => File.Create($"{Constants.OutputPath}\\result_{pageNumber}.png"));
	previewOptions.PreviewFormat = PreviewOptions.PreviewFormats.PNG;
	previewOptions.PageNumbers = new int[] { 1 };
	metadata.GeneratePreview(previewOptions);
}
```

## More resources

### Advanced usage topics

To learn more about document watermarking features and get familiar how to manage watermarks and more, please refer to the  [advanced usage section]({{< ref "metadata/net/developer-guide/advanced-usage/_index.md" >}}).

### GitHub examples

You may easily run the code above and see the feature in action in our GitHub examples:

*   [GroupDocs.Metadata for .NET examples](https://github.com/groupdocs-metadata/GroupDocs.Metadata-for-.NET)
    
*   [GroupDocs.Metadata for Java examples](https://github.com/groupdocs-metadata/GroupDocs.Metadata-for-Java)
    

### Free online document metadata management App

Along with full featured .NET library we provide simple, but powerful free Apps.

You are welcome to view and edit metadata of PDF, DOC, DOCX, PPT, PPTX, XLS, XLSX, emails, images and more with our free online [Free Online Document Metadata Viewing and Editing App](https://products.groupdocs.app/metadata).
