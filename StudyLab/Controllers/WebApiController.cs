using System.Web.Mvc;

namespace StudyLab.Controllers
{
    [Authorize]
    public class WebApiController : Controller
    {
        // GET: WebApi
        public ActionResult Index()
        {
            return View();
        }
    }
}