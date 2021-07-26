using System.Collections.Generic;

namespace GroupDocs.Metadata.WebForms.Products.Metadata.DTO
{
    public class PostedMetadataPackageDto
    {
        public string id { get; set; }

        public IEnumerable<PropertyDto> properties { get; set; }
    }
}