using System.Web.Mvc;

namespace StudyLab.Controllers
{
    [Authorize]
    public class MvcController : Controller
    {
        // GET: Mvc
        public ActionResult Index()
        {
            return View();
        }
    }
}