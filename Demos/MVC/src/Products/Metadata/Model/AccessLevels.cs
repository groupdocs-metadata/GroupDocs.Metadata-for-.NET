
using System;

namespace GroupDocs.Metadata.MVC.Products.Metadata.Model
{
    /// <summary>
    /// Defines access levels for metadata properties.
    /// </summary>
    [Flags]
    public enum AccessLevels
    {
        /// <summary>
        /// The property is read-only.
        /// </summary>
        Read = 0,

        /// <summary>
        /// It is possible to update the property.
        /// </summary>
        Update = 1,

        /// <summary>
        /// The property can be removed.
        /// </summary>
        Remove = 2,

        /// <summary>
        /// It is possible to add the property to the package.
        /// </summary>
        Add = 4,

        /// <summary>
        /// Grants full access to the property.
        /// </summary>
        Full = Update | Remove | Add,

        /// <summary>
        /// It is allowed to add and update the property. All other operations are restricted.
        /// </summary>
        AddOrUpdate = Add | Update,
    }
}