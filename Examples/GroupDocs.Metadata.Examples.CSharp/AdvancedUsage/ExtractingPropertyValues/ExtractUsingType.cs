// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2021 GroupDocs. All Rights Reserved.
// </copyright>


namespace GroupDocs.Metadata.Examples.CSharp.AdvancedUsage.ExtractingPropertyValues
{
    using System;
    using Common;

    /// <summary>
    /// This code snippet demonstrates how to extract the property value using the Type property.
    /// </summary>
    public class ExtractUsingType
    {
        public static void Run()
        {
            using (Metadata metadata = new Metadata(Constants.InputDocx))
            {
                // Fetch all metadata properties from the file
                var properties = metadata.FindProperties(p => true);
                foreach (var property in properties)
                {
                    // Process string and DateTime properties only
                    if (property.Value.Type == MetadataPropertyType.String)
                    {
                        Console.WriteLine(property.Value.ToClass<string>());
                    }
                    else if (property.Value.Type == MetadataPropertyType.DateTime)
                    {
                        Console.WriteLine(property.Value.ToStruct(DateTime.MinValue));
                    }
                }
            }
        }
    }
}
