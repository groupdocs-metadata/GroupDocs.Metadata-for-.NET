// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2023 GroupDocs. All Rights Reserved.
// </copyright>

namespace GroupDocs.Metadata.Examples.CSharp.Migration.WorkingWithRegularExpressions
{
    using System;
    using System.Text.RegularExpressions;

    /// <summary>
    /// This code snippet demonstrates how to search for metadata properties using a regular expression.
    /// </summary>
    public class FindPropertiesByRegex
    {
        public static void Run()
        {
            Regex pattern = new Regex("author|company", RegexOptions.IgnoreCase);

            using (Metadata metadata = new Metadata(Constants.InputDocx))
            {
                // This method searches for properties across all metadata packages and works with all supported formats
                var properties = metadata.FindProperties(p => pattern.IsMatch(p.Name) || pattern.IsMatch(p.Value.ToString()));
                foreach (var property in properties)
                {
                    Console.WriteLine("{0} = {1}", property.Name, property.Value);
                }
            }
        }
    }
}
