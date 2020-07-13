using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CategoryPJ.Commont;
using Modelclass.DAO;

namespace CategoryPJ.Controllers
{
    public class TemplateController : Controller
    {
        // GET: Template
        public PartialViewResult Index(int id)
        {
            var template = new TemplateDAO().TemByCategory(id);
            ViewBag.category = new CategoryDAO().ListAll();
            return PartialView(template);
        }

        public ActionResult Details(int id)
        {
            var template = new TemplateDAO().ViewDetails(id);
            ViewBag.User = (CurrentUser)Session[CommontConst.USER_SECCION];
            return View(template);
        }
    }
}