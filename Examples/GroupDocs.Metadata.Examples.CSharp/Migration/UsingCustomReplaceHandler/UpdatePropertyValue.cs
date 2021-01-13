// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2021 GroupDocs. All Rights Reserved.
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
