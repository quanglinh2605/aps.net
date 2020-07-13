using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using E_Greetings.Models.Bussiness.ModuleAdmin;
using E_Greetings.Models.ModelsView;
using PagedList;

namespace E_Greetings.Controllers
{
    public class CategoryController : Controller
    {
        CategoryAction ca = new CategoryAction();
        // GET: Category
        public ActionResult showCate( int? page)
        {
            int pagenumber = page ?? 1;
            int pagesize = 10;
            List<CategoryView> lscate = new List<CategoryView>();
            lscate = ca.showCate("");
            return View(lscate.ToPagedList(pagenumber,pagesize));
        }
        [HttpPost]
        public ActionResult showCate(int? page, string name)
        {
            int pagenumber = page ?? 1;
            int pagesize = 10;
            List<CategoryView> lscate = new List<CategoryView>();
            lscate = ca.showCate(name);
            return View(lscate.ToPagedList(pagenumber, pagesize));
        }
        public ActionResult createCate()
        {
            return View();
        }
        [HttpPost]
        public ActionResult createCate(CategoryView model)
        {
            if (ca.createCate(model))
            {
                return RedirectToAction("showCate");
            };
            ViewBag.Mess = "Can't Add";
            return View(model);
        }
        [ChildActionOnly]
        public ActionResult MainMenu()
        {
            var model = ca.showCate("");
            return PartialView(model);
        }
    }
}