using GroupDocs.Metadata.WebForms.Products.Common.Entity.Web;
using System.Collections.Generic;

namespace GroupDocs.Metadata.WebForms.Products.Metadata.DTO
{
    public class PostedDataDto : PostedDataEntity
    {
        /// <summary>
        /// Collection of the document properties with their data.
        /// </summary>
        public IEnumerable<PostedMetadataPackageDto> packages { get; set; }
    }
}