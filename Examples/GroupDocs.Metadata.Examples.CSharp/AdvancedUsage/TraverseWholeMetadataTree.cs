// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2023 GroupDocs. All Rights Reserved.
// </copyright>

namespace GroupDocs.Metadata.Examples.CSharp.AdvancedUsage
{
    using System;
    using Common;

    /// <summary>
    /// This example demonstrates how to traverse the whole metadata tree for a specific file regardless of the format.
    /// </summary>
    public static class TraverseWholeMetadataTree
    {
        public static void Run()
        {
            using (Metadata metadata = new Metadata(Constants.JpegWithXmp))
            {
                DisplayMetadataTree(metadata.GetRootPackage(), 0);
            }
        }

        private static void DisplayMetadataTree(MetadataPackage package, int indent)
        {
            if (package != null)
            {
                var stringMetadataType = package.MetadataType.ToString();
                Console.WriteLine(stringMetadataType.PadLeft(stringMetadataType.Length + indent));
                foreach (MetadataProperty property in package)
                {
                    string stringPropertyRepresentation = string.Format("Name: {0}, Value: {1}", property.Name, property.Value);
                    Console.WriteLine(stringPropertyRepresentation.PadLeft(stringPropertyRepresentation.Length + indent + 1));
                    if (property.Value != null)
                    {
                        switch (property.Value.Type)
                        {
                            case MetadataPropertyType.Metadata:
                                DisplayMetadataTree(property.Value.ToClass<MetadataPackage>(), indent + 2);
                                break;
                            case MetadataPropertyType.MetadataArray:
                                DisplayMetadataTree(property.Value.ToArray<MetadataPackage>(), indent + 2);
                                break;
                        }
                    }
                }
            }
        }

        private static void DisplayMetadataTree(MetadataPackage[] packages, int indent)
        {
            if (packages != null)
            {
                foreach (var package in packages)
                {
                    DisplayMetadataTree(package, indent);
                }
            }
        }
    }
}
