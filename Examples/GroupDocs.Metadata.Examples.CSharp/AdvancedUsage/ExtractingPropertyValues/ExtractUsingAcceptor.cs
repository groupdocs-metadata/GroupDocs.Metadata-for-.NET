// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2021 GroupDocs. All Rights Reserved.
// </copyright>


namespace GroupDocs.Metadata.Examples.CSharp.AdvancedUsage.ExtractingPropertyValues
{
    using System;
    using Common;

    /// <summary>
    /// This code snippet demonstrates how to extract the property value using a custom acceptor.
    /// </summary>
    public class ExtractUsingAcceptor
    {
        public static void Run()
        {
            using (Metadata metadata = new Metadata(Constants.InputDocx))
            {
                // Fetch all metadata properties
                var properties = metadata.FindProperties(p => true);

                var valueAcceptor = new CustomValueAcceptor();
                foreach (var property in properties)
                {
                    // Extract the property value using a custom acceptor
                    property.Value.AcceptValue(valueAcceptor);
                }
            }
        }

        private class CustomValueAcceptor : ValueAcceptor
        {
            protected override void AcceptNull()
            {
                Console.WriteLine("Null value extracted");
            }

            protected override void Accept(string value)
            {
                Console.WriteLine("String value extracted: {0}", value);
            }

            protected override void Accept(bool value)
            {
                Console.WriteLine("Boolean value extracted: {0}", value);
            }

            protected override void Accept(DateTime value)
            {
                Console.WriteLine("DateTime value extracted: {0}", value);
            }

            protected override void Accept(TimeSpan value)
            {
                Console.WriteLine("DateTime value extracted: {0}", value);
            }

            protected override void Accept(int value)
            {
                Console.WriteLine("Integer value extracted: {0}", value);
            }

            protected override void Accept(long value)
            {
                Console.WriteLine("Long value extracted: {0}", value);
            }

            protected override void Accept(double value)
            {
                Console.WriteLine("Double value extracted: {0}", value);
            }

            protected override void Accept(string[] value)
            {
                Console.WriteLine("String array extracted: {0}", value?.Length ?? 0);
            }

            protected override void Accept(byte[] value)
            {
                Console.WriteLine("Byte array extracted: {0}", value?.Length ?? 0);
            }

            protected override void Accept(double[] value)
            {
                Console.WriteLine("Double array extracted: {0}", value?.Length ?? 0);
            }

            protected override void Accept(int[] value)
            {
                Console.WriteLine("Integer array extracted: {0}", value?.Length ?? 0);
            }

            protected override void Accept(long[] value)
            {
                Console.WriteLine("Long array extracted: {0}", value?.Length ?? 0);
            }

            protected override void Accept(MetadataPackage value)
            {
                Console.WriteLine("Metadata package value extracted: {0}", value);
            }

            protected override void Accept(MetadataPackage[] value)
            {
                Console.WriteLine("Metadata package array extracted: {0}", value?.Length ?? 0);
            }

            protected override void Accept(Guid value)
            {
                Console.WriteLine("Guid value extracted: {0}", value);
            }

            protected override void Accept(PropertyValue[] value)
            {
                Console.WriteLine("Property value array extracted: {0}", value?.Length ?? 0);
            }
        }
    }
}
