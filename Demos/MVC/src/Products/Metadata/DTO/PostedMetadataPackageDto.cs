using System.Collections.Generic;

namespace GroupDocs.Metadata.MVC.Products.Metadata.DTO
{
    public class PostedMetadataPackageDto
    {
        public string id { get; set; }

        public IEnumerable<PropertyDto> properties { get; set; }
    }
}