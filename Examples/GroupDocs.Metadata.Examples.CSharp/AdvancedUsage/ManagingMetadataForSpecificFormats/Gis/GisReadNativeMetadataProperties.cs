// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2025 GroupDocs. All Rights Reserved.
// </copyright>




namespace GroupDocs.Metadata.Examples.CSharp.AdvancedUsage.ManagingMetadataForSpecificFormats.Gis
{
    using System;
    using Formats.Gis;

    /// <summary>
    /// The following code snippet shows how to get metadata from a Gis file.
    /// </summary>
    public static class GisReadNativeMetadataProperties
    {
        public static void Run()
        {
            Console.WriteLine("\n--------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("[Example Advanced Usage] # GisReadNativeMetadataProperties : How to get metadata from a Gis file.\n");
            using (Metadata metadata = new Metadata(Constants.InputKml))
            {
                var root = metadata.GetRootPackage<GisRootPackage>();

                foreach (var feature in root.GisPackage.Features)
                {
                    foreach (var attribute in feature.Attributes)
                    {
                        Console.WriteLine(attribute.Name);
                        Console.WriteLine(attribute.Value);
                    }
                        
                }
            }
        }
    }
}
