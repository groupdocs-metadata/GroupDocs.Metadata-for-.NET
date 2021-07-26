using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using GroupDocs.Metadata.MVC.AppDomainGenerator;

namespace GroupDocs.Metadata.MVC
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            // Fix required to use several GroupDocs products in one project.
            // Set GroupDocs products assemblies names   
            string metadataAssemblyName = "GroupDocs.Metadata.dll";
            // set GroupDocs.Metadata license
            DomainGenerator metadataDomainGenerator = new DomainGenerator(metadataAssemblyName, "GroupDocs.Metadata.License");
            metadataDomainGenerator.SetMetadataLicense();

            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }       
    }     
}
