using Newtonsoft.Json;
using System.Collections.Generic;

namespace GroupDocs.Metadata.MVC.Products.Common.Entity.Web
{
    public class LoadDocumentEntity
    {
        ///Document Guid
        [JsonProperty]
        private string guid;

        ///list of pages        
        [JsonProperty]
        private List<PageDescriptionEntity> pages = new List<PageDescriptionEntity>();

        public void SetGuid(string guid)
        {
            this.guid = guid;
        }

        public void SetPages(PageDescriptionEntity page)
        {
            this.pages.Add(page);
        }
    }
}