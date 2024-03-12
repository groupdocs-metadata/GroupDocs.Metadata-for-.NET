// <copyright company="Aspose Pty Ltd">
//  Copyright (C) 2011-2024 GroupDocs. All Rights Reserved.
// </copyright>


namespace GroupDocs.Metadata.Examples.CSharp.AdvancedUsage.ManagingMetadataForSpecificFormats.Ebook
{
    using Formats.Ebook;
    using Common;
    using System;

    /// <summary>
    /// This example shows how to update Dublin Core metadata in EPUB files.
    /// </summary>
    public class EpubUpdateDublinCoreProperties
    {
        public static void Run()
        {
            Console.WriteLine("\n--------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("[Example Advanced Usage] # EpubUpdateDublinCoreProperties : How to update Dublin Core metadata in EPUB files.\n");
            using (Metadata metadata = new Metadata(Constants.InputEpub))
            {
                var root = metadata.GetRootPackage<EpubRootPackage>();

                root.DublinCorePackage.SetProperties(p => p.Name == "dc:creator", new PropertyValue("GroupDocs"));
                root.DublinCorePackage.SetProperties(p => p.Name == "dc:description", new PropertyValue("test e-book"));
                root.DublinCorePackage.SetProperties(p => p.Name == "dc:title", new PropertyValue("test EPUB"));
                root.DublinCorePackage.SetProperties(p => p.Name == "dc:date", new PropertyValue(DateTime.Now.ToString()));

                // ...

                metadata.Save(Constants.OutputEpub);
            }
        }
    }
}
