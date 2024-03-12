// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2024 GroupDocs. All Rights Reserved.
// </copyright>

namespace GroupDocs.Metadata.Examples.CSharp.AdvancedUsage.ManagingMetadataForSpecificFormats.Cad
{
    using Formats.Cad;
    using Common;
    using System;

    /// <summary>
    /// This code sample shows how to update metadata of a DXF drawing.
    /// </summary>
    public class DxfUpdateNativeMetadataProperties
    {
        public static void Run()
        {
            Console.WriteLine("\n--------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("[Example Advanced Usage] # DxfUpdateNativeMetadataProperties : How to update metadata of a DXF drawing.\n");
            using (Metadata metadata = new Metadata(Constants.InputDxf))
            {
                var root = metadata.GetRootPackage<CadRootPackage>();

                root.CadPackage.SetProperties(p => p.Name == "Author", new PropertyValue("GroupDocs"));
                root.CadPackage.SetProperties(p => p.Name == "Comments", new PropertyValue("test comment"));
                root.CadPackage.SetProperties(p => p.Name == "HyperlinkBase", new PropertyValue("test hyperlink base"));
                root.CadPackage.SetProperties(p => p.Name == "Keywords", new PropertyValue("test keywords"));
                root.CadPackage.SetProperties(p => p.Name == "LastSavedBy", new PropertyValue("test editor"));
                root.CadPackage.SetProperties(p => p.Name == "RevisionNumber", new PropertyValue("test revision number"));
                root.CadPackage.SetProperties(p => p.Name == "Subject", new PropertyValue("test subject"));
                root.CadPackage.SetProperties(p => p.Name == "Title", new PropertyValue("test title"));
                root.CadPackage.SetProperties(p => p.Name == "CreatedDateTime", new PropertyValue(DateTime.Now.AddDays(-1)));
                root.CadPackage.SetProperties(p => p.Name == "ModifiedDateTime", new PropertyValue(DateTime.Now));

                metadata.Save(Constants.OutputDxf);
            }
        }
    }
}
