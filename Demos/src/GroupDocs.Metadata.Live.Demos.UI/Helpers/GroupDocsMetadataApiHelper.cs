using System.Net.Http;
using System.Net.Http.Headers;
using GroupDocs.Metadata.Live.Demos.UI.Config;
using GroupDocs.Metadata.Live.Demos.UI.Models;

namespace GroupDocs.Metadata.Live.Demos.UI.Helpers
{
    public class GroupDocsMetadataApiHelper : ApiHelperBase
    {
		public static Response GetAllMetadataSupportedFormats()
		{
			Response metadataResponse = null;

			using (var client = new HttpClient())
			{
				client.DefaultRequestHeaders.Clear();
				client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
				System.Threading.Tasks.Task taskUpload = client.GetAsync(Configuration.GroupDocsAppsAPIBasePath + "api/GroupDocsMetadata/GetAllMetadataSupportedFormats").ContinueWith(task =>
				{
					if (task.Status == System.Threading.Tasks.TaskStatus.RanToCompletion)
					{
						HttpResponseMessage response = task.Result;
						if (response.IsSuccessStatusCode)
						{
							metadataResponse = response.Content.ReadAsAsync<Response>().Result;
						}
					}
				});
				taskUpload.Wait();
			}

			return metadataResponse;
		}
	}
}