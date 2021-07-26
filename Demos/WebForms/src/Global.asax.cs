using System;
using System.Web;
using System.Web.Routing;
using System.Web.Http;
using GroupDocs.Metadata.WebForms.AppDomainGenerator;

namespace GroupDocs.Metadata.WebForms
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Fix required to use several GroupDocs products in one project.
            // Set GroupDocs products assemblies names           
            string metadataAssemblyName = "GroupDocs.Metadata.dll";
            // set GroupDocs.Metadata license
            DomainGenerator metadataDomainGenerator = new DomainGenerator(metadataAssemblyName, "GroupDocs.Metadata.License");
            metadataDomainGenerator.SetMetadataLicense();

            // Code that runs on application startup
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}