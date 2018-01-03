using System.Web.Mvc;

namespace StudyLab.Controllers
{
    [Authorize]
    public class JavaScriptController : Controller
    {
        // GET: JavaScript
        public ActionResult Index()
        {
            return View();
        }
    }
}