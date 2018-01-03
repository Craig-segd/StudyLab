using System.Web.Mvc;

namespace StudyLab.Controllers
{
    [Authorize]
    public class ReactController : Controller
    {
        // GET: React
        public ActionResult Index()
        {
            return View();
        }
    }
}