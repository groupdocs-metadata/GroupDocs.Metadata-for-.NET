using GroupDocs.Metadata.MVC.Products.Common.Entity.Web;
using System.Collections.Generic;

namespace GroupDocs.Metadata.MVC.Products.Metadata.DTO
{
    public class PostedDataDto : PostedDataEntity
    {
        /// <summary>
        /// Collection of the document properties with their data.
        /// </summary>
        public IEnumerable<PostedMetadataPackageDto> packages { get; set; }
    }
}