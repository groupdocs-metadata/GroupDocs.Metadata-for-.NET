using GroupDocs.Metadata.Common;

namespace GroupDocs.Metadata.WebForms.Products.Metadata.DTO
{
    /// <summary>
    /// File property entity
    /// </summary>
    public class PropertyDto
    {
        public string name { get; set; }

        public dynamic value { get; set; }

        public int type { get; set; }
    }
}