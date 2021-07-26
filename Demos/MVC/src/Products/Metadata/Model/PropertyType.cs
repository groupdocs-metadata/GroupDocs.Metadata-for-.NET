
namespace GroupDocs.Metadata.MVC.Products.Metadata.Model
{
    /// <summary>
    /// Defines metadata property types.
    /// </summary>
    public enum PropertyType
    {
        /// <summary>
        /// Represents an empty (null) property.
        /// </summary>
        Empty = 0,

        /// <summary>
        /// Represents a string property.
        /// </summary>
        String = 1,

        /// <summary>
        /// Represents a boolean property.
        /// </summary>
        Boolean = 2,

        /// <summary>
        /// Represents a date property.
        /// </summary>
        DateTime = 3,

        /// <summary>
        /// Represents a time property.
        /// </summary>
        TimeSpan = 4,

        /// <summary>
        /// Represents an integer property.
        /// </summary>
        Integer = 5,

        /// <summary>
        /// Represents a long integer property.
        /// </summary>
        Long = 6,

        /// <summary>
        /// Represents a property with a double or float value.
        /// </summary>
        Double = 7,

        /// <summary>
        /// Represents a string array property.
        /// </summary>
        StringArray = 8,

        /// <summary>
        /// Represents a byte array property.
        /// </summary>
        ByteArray = 9,

        /// <summary>
        /// Represents an array of double values.
        /// </summary>
        DoubleArray = 10,

        /// <summary>
        /// Represents an array of integer values.
        /// </summary>
        IntegerArray = 11,

        /// <summary>
        /// Represents an array of long values.
        /// </summary>
        LongArray = 12,

        /// <summary>
        /// Represents a nested metadata block.
        /// </summary>
        Metadata = 13,

        /// <summary>
        /// Represents an array of nested metadata blocks.
        /// </summary>
        MetadataArray = 14,

        /// <summary>
        /// Represents a global unique identifier value.
        /// </summary>
        Guid = 15,

        /// <summary>
        /// Represents a metadata property value array.
        /// </summary>
        PropertyValueArray = 16
    }
}