// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2020 GroupDocs. All Rights Reserved.
// </copyright>

namespace GroupDocs.Metadata.Examples.CSharp.Migration.ExportingMetadataProperties
{
    using System;
    using System.IO;
    using System.Text;
    using Common;

    /// <summary>
    /// This code sample demonstrates how to export all metadata properties to a CSV file.
    /// </summary>
    public class ExportPropertiesToCsv
    {
        public static void Run()
        {
            using (Metadata metadata = new Metadata(Constants.InputEml))
            {
                // We use a predicate that extracts all metadata properties
                var properties = metadata.FindProperties(p => true);

                const string delimiter = ";";
                StringBuilder builder = new StringBuilder();
                builder.AppendFormat("Name{0}Value", delimiter);
                builder.AppendLine();
                foreach (var property in properties)
                {
                    builder.AppendFormat(@"""{0}""{1}""{2}""", property.Name, delimiter, FormatValue(property.Value));
                    builder.AppendLine();
                }

                File.WriteAllText(Constants.OutputCsv, builder.ToString());
            }
        }

        private static string FormatValue(PropertyValue propertyValue)
        {
            if (propertyValue == null || propertyValue.RawValue == null)
            {
                return null;
            }

            object value = propertyValue.RawValue;

            StringBuilder result = new StringBuilder();
            if (value.GetType().IsArray)
            {
                const int arrayMaxLength = 20;
                const string arrayStartCharacter = "[";
                const string arrayEndCharacter = "]";

                Array array = (Array)value;
                if (array.Length > 0)
                {
                    result.Append(arrayStartCharacter);
                    for (int index = 0; index < array.Length; index++)
                    {
                        object item = array.GetValue(index);
                        result.AppendFormat("{0},", item);
                        if (index > arrayMaxLength)
                        {
                            result.Append("...");
                            break;
                        }
                    }
                    result = result.Remove(result.Length - 1, 1);
                    result.Append(arrayEndCharacter);
                }
            }
            else
            {
                result.Append(value);
            }

            result.Replace("\"", "\"\"");
            return result.ToString();
        }
    }
}
