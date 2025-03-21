﻿// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2025 GroupDocs. All Rights Reserved.
// </copyright>

namespace GroupDocs.Metadata.Examples.CSharp.Migration.WorkingWithRegularExpressions
{
    using System;
    using System.Text.RegularExpressions;
    using Common;

    /// <summary>
    /// This code snippet demonstrates how to update metadata properties using a regular expression.
    /// </summary>
    public class UpdatePropertiesByRegex
    {
        public static void Run()
        {
            Console.WriteLine("\n--------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("[Example Migration] # UpdatePropertiesByRegex : How to update metadata properties using a regular expression.\n");
            var pattern = new Regex("^author|company$", RegexOptions.IgnoreCase);
            var replaceValue = new PropertyValue("Aspose");

            using (Metadata metadata = new Metadata(Constants.InputDocx))
            {
                // This method updates writable properties across all metadata packages and works with all supported formats
                metadata.UpdateProperties(p => pattern.IsMatch(p.Name), replaceValue);

                metadata.Save(Constants.OutputDocx);
            }
        }
    }
}
