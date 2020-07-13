using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models.EF;
using Models.DAO;

namespace Furniture.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Admin/Category
        public ActionResult Index(string keyword, int page = 1, int pagesize = 10)
        {
            var dao = new CategoryDao();
            ViewBag.keyword = keyword;
            return View(dao.pagetolist(keyword,page,pagesize));
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Category model)
        {
            if (ModelState.IsValid)
            {
                var dao = new CategoryDao();
                var result = dao.Insert(model);
                if (result > 0)
                    return RedirectToAction("Index");
                else ModelState.AddModelError("", "Them danh muc thanh cong");
            }
            return View();
        }
        [HttpGet]
        public ActionResult Edit(long id)
        {
            return View();
        }
        [HttpPost]
        public ActionResult Edit(Category model)
        {
            if (ModelState.IsValid)
            {
                var dao = new CategoryDao();
                var result = dao.Update(model);
                if (result)
                    return RedirectToAction("Index");
                else ModelState.AddModelError("", "Cap nhat danh muc thanh cong");
            }
            return View();
        }
        [HttpDelete]
        public ActionResult Delete(long id)
        {
            var dao = new CategoryDao();
            dao.Delete(id);
            return View();
        }
    }
}