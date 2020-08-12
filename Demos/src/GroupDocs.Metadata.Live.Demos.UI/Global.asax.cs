using System;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using GroupDocs.Metadata.Live.Demos.UI.Config;
using System.Web.Http;

namespace GroupDocs.Metadata.Live.Demos.UI
{
	public class Global : HttpApplication
	{
		void Application_Start(object sender, EventArgs e)
		{     
            /*
            RouteTable.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = System.Web.Http.RouteParameter.Optional }
            );
            */

            RouteTable.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = System.Web.Http.RouteParameter.Optional }
            );

            // Set language name to load at application start
            //string _language = "EN";
            //SetResourceFile(_language, Request.Url.Host.Trim());
            RouteConfig.RegisterRoutes(RouteTable.Routes);
			BundleConfig.RegisterBundles(BundleTable.Bundles);

			RegisterCustomRoutes(RouteTable.Routes);

		}
		void Session_Start(object sender, EventArgs e)
		{
			//Check URL to set language resource file
			string _language = "EN";
			if (Request.Url.ToString().ToLower().Contains("zh."))
			{
				_language = "ZH";
			}
			SetResourceFile(_language, Request.Url.Host.Trim().Replace(".", ""));
		}

		private void SetResourceFile(string strLanguage, string HostName)
		{
			if (Session["GroupDocsAppResources"] == null)
				Session["GroupDocsAppResources"] = new GlobalAppHelper(HttpContext.Current, Application, "GroupDocsApps" + HostName, strLanguage);
		}

		void RegisterCustomRoutes(RouteCollection routes)
		{
            routes.Ignore("{resource}.axd/{*pathInfo}");


            routes.MapPageRoute(
                 "GroupDocsAppsMetadataRoute",
                 "metadata",
                 "~/MetadataApp/MetadataFileApp.aspx"
             );

            routes.MapPageRoute(
                "GroupDocsAppsMetadataRouteTotal",
                "metadata/total",
                "~/MetadataApp/MetadataFileApp.aspx"
            );

            routes.MapPageRoute(
                "GroupDocsAppsMetadataRoute2",
                "metadata/{fileformat}",
                "~/MetadataApp/MetadataFileApp.aspx"
            );

            routes.MapPageRoute(
                "GroupDocsAppsMetadataAppRoute",
                "metadata/{foldername}/{filename}",
                "~/MetadataApp/Default.aspx"
            );

        }
	}
}