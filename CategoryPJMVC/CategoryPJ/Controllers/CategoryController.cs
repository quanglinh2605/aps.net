using Modelclass.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CategoryPJ.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        public ActionResult Index(int id)
        {

            return View();
        }
        [ChildActionOnly]
        public PartialViewResult CategorySlide()
        {
            var model = new CategoryDAO().ListAll();
            return PartialView(model);
        }
    }
}