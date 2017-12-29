using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudyLab.Controllers
{
    public class WebApiController : Controller
    {
        // GET: WebApi
        public ActionResult Index()
        {
            return View();
        }
    }
}