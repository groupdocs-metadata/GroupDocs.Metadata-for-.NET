
using System.Collections.Generic;

namespace GroupDocs.Metadata.MVC.Products.Metadata.DTO
{
    public class ExtractedPackageDto
    {
        public string id { get; set; }

        public string name { get; set; }

        public int index { get; set; }

        public int type { get; set; }

        public IEnumerable<PropertyDto> properties { get; set; }

        public IEnumerable<KnownPropertyDto> knownProperties { get; set; }
    }
}