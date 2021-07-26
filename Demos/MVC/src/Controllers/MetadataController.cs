using System.Web.Mvc;

namespace GroupDocs.Metadata.MVC.Controllers
{
    /// <summary>
    /// Metadata Web page controller
    /// </summary>
    public class MetadataController : Controller
    {       
        public ActionResult Index()
        {
            return View();
        }
    }
}