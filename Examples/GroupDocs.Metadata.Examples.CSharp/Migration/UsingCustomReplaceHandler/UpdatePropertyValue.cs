// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2024 GroupDocs. All Rights Reserved.
// </copyright>

namespace GroupDocs.Metadata.Examples.CSharp.Migration.UsingCustomReplaceHandler
{
    using Common;
    using System;

    /// <summary>
    /// This code sample demonstrates how to update metadata property values using a custom filter.
    /// </summary>
    public class UpdatePropertyValue
    {
        public static void Run()
        {
            Console.WriteLine("\n--------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("[Example Migration] # UpdatePropertyValue : How to update metadata property values using a custom filter.\n");
            using (Metadata metadata = new Metadata(Constants.InputDocx))
            {
                var affected = metadata.UpdateProperties(
                    p => string.Equals(p.Name, "author", StringComparison.OrdinalIgnoreCase),
                            new PropertyValue("Jack London"));

                Console.WriteLine(affected);

                metadata.Save(Constants.OutputDocx);
            }
        }
    }
}
