using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace GroupDocs.Metadata.MVC
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            // Set GroupDocs.Metadata license
            Products.Common.Config.GlobalConfiguration globalConfiguration = new Products.Common.Config.GlobalConfiguration();
            string licensePath = globalConfiguration.Application.LicensePath;
            if (!string.IsNullOrEmpty(licensePath))
            {
                new License().SetLicense(licensePath);
            }

            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }       
    }     
}
