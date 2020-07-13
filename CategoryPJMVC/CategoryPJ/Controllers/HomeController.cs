using Modelclass.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CategoryPJ.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            ViewBag.Tem = new TemplateDAO().List();
            
            var model = new CategoryDAO().ListAll();
            return PartialView(model);
        }

        [ChildActionOnly]
        public ActionResult MainMenu()
        {
            var model = new CategoryDAO().ListAll();
            return PartialView(model);
        }
        [ChildActionOnly]
        public ActionResult MainTop()
        {
            var model = new CategoryDAO().ListAll();
            return PartialView(model);
        }

        [ChildActionOnly]
        public PartialViewResult Slide()
        {
            var model = new CategoryDAO().ListAll();
            return PartialView(model);
        }
    }
}